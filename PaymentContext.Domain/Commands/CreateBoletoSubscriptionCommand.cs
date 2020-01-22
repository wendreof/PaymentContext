using System;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.Commands
{
  public class CreateBoletoSubscriptionCommand
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public String BarCode { get; private set; }
    public String BoletoNumber { get; private set; }

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
  }
}