using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Share.Commands;
using PaymentContext.Share.Handlers;

namespace PaymentContext.Domain.Handlers
{

  public class SubscriptionHandler :
   Notifiable,
   IHandler<Commands.CreateBoletoSubscriptionCommand>
  //IHandler<Commands.CreatePaypalSubscriptionCommand>
  {
    private readonly IStudentRepository _repository;
    private readonly IEmailService _emailService;
    public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
    {
      _repository = repository;
      _emailService = emailService;
    }

    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
      //Fail Fast Validations
      command.Validate();
      if (command.Invalid)
      {
        AddNotifications(command);
        return new CommandResult(false, "Não foi possível realizar sua assinatura!");
      }

      //Verify if document is registered
      if (_repository.DocumentExists(command.Document))
        AddNotification("Document", "Este CPF já está em uso!");

      //verify if email already registered
      if (_repository.EmailExists(command.Email))
        AddNotification("Email", "Este Email já está em uso!");

      //generate VOs
      var name = new Name(command.FirstName, command.LastName);
      var document = new Document(command.Document, Domain.Enums.EDocumentType.CPF);
      var email = new Email(command.Email);
      var address = new Address(command.Street,
                                command.Number,
                                command.Neighborhood,
                                command.City,
                                command.State,
                                command.Country,
                                command.ZipCode);

      //generate Entities
      var student = new Student(name, document, email);
      var subscription = new Subscription(System.DateTime.Now.AddMonths(1));
      var payment = new BoletoPayment(command.BarCode,
                                      command.BoletoNumber,
                                      command.PaidDate,
                                      command.ExpireDate,
                                      command.Total,
                                      command.TotalPaid,
                                      command.Payer,
                                      new Document(command.Document, command.PayerDocumentType),
                                      address,
                                      email);

      //Relationships
      subscription.AddPayment(payment);
      student.AddSubscription(subscription);

      //group apply validations
      AddNotifications(name, document, email, address, student, subscription, payment);

      //check the notifications
      if (Invalid)
        return new CommandResult(false, "Não foi possível validar sua assinatura");

      //save infos
      _repository.CreateSubscription(student);

      //sent welcome e-mail
      _emailService.Send(student.Name.ToString(),
                         student.Email.Address,
                         "Welcome to wendreof.io",
                         "Your signature was created!");

      //return infos
      return new CommandResult(true, "Assinatura realizada com sucesso!");
    }
  }
}

//     public ICommandResult Handle(CreatePaypalSubscriptionCommand command)
//     {
//       //Verify if document is registered
//       if (_repository.DocumentExists(command.Document))
//         AddNotification("Document", "Este CPF já está em uso!");

//       //verify if email already registered
//       if (_repository.EmailExists(command.Email))
//         AddNotification("Email", "Este Email já está em uso!");

//       //generate VOs
//       var name = new Name(command.FirstName, command.LastName);
//       var document = new Document(command.Document, Domain.Enums.EDocumentType.CPF);
//       var email = new Email(command.Email);
//       var address = new Address(command.Street,
//                                 command.Number,
//                                 command.Neighborhood,
//                                 command.City,
//                                 command.State,
//                                 command.Country,
//                                 command.ZipCode);

//       //generate Entities
//       var student = new Student(name, document, email);
//       var subscription = new Subscription(System.DateTime.Now.AddMonths(1));
//       var payment = new PayPalPayment(command.TransactionCode,
//                                       command.PaidDate,
//                                       command.ExpireDate,
//                                       command.Total,
//                                       command.TotalPaid,
//                                       command.Payer,
//                                       new Document(command.Document, command.PayerDocumentType),
//                                       address,
//                                       email);

//       //Relationships
//       subscription.AddPayment(payment);
//       student.AddSubscription(subscription);

//       //group apply validations
//       AddNotifications(name, document, email, address, student, subscription, payment);

//       //save infos
//       _repository.CreateSubscription(student);

//       //sent welcome e-mail
//       _emailService.Send(student.Name.ToString(),
//                          student.Email.Address,
//                          "Welcome to wendreof.io",
//                          "Your signature was created!");

//       //return infos
//       return new CommandResult(true, "Assinatura realizada com sucesso!");
//     }
//   }
// }