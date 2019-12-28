using System;

namespace PaymentContext.Domain.Entities
{
  public abstract class Payment
  {
    public string Number { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public Decimal Total { get; set; }
    public Decimal TotalPaid { get; set; }
    public String Owner { get; set; }
    public String Document { get; set; }
    public string Address { get; set; }
  }
  public class BoletoPayment : Payment
  {
    public String BarCode { get; set; }
    public String BoletoNumber { get; set; }
  }
  public class CreditCardPayment : Payment
  {
    public String CardHolderName { get; set; }
    public String CardNumber { get; set; }
    public String LastTransactionNumber { get; set; }
  }

  public class PayPalPayment : Payment
  {
    public String TransactionCode { get; set; }
  }
}