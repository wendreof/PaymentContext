using System;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Share.Commands;

namespace PaymentContext.Domain.Commands
{
  public class CreateBoletoSubscriptionCommand : Flunt.Notifications.Notifiable, ICommand
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public String BarCode { get; set; }
    public String BoletoNumber { get; set; }

    public string PayerNumber { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public Decimal Total { get; set; }
    public Decimal TotalPaid { get; set; }
    public String Payer { get; set; }
    public EDocumentType PayerDocumentType { get; set; }
    public string PayerEmail { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }

    public void Validate()
    {
      AddNotifications(new Contract()
       .Requires()
      .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
      .HasMinLen(LastName, 3, "Name.LastName", "SobreNome deve conter pelo menos 3 caracteres")
      .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres")
      );
    }
  }
}