using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
  [TestClass]
  public class SubscriptionHandlerTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists()
    {
      var handler = new SubscriptionHandler(new FakeStudentRepository(),
                                          new FakeEmailService());

      var command = new CreateBoletoSubscriptionCommand();
      command.FirstName = "Wendreo";
      command.LastName = "Fernandes";
      command.Document = "99999999999";
      command.Email = "wendreolf@outlook.com";
      command.BarCode = "123456789";
      command.BoletoNumber = "1234567";
      command.PayerNumber = "123121";
      command.PaidDate = DateTime.Now;
      command.ExpireDate = DateTime.Now.AddMonths(1); ;
      command.Total = 60;
      command.TotalPaid = 60;
      command.Payer = "Wayne Corp";
      command.PayerDocumentType = EDocumentType.CPF;
      command.PayerEmail = "batman@dc.com.us";
      command.Street = "asdas";
      command.Number = "asdasds";
      command.Neighborhood = "dsadasd";
      command.City = "asdasd";
      command.State = "asdas";
      command.Country = "asdasd";
      command.ZipCode = "12312312";

      handler.Handle(command);
      Assert.AreEqual(false, handler.Valid);
    }
  }
}

