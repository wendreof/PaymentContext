using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{

  public class CreditCardPayment : Payment
  {
    public CreditCardPayment(string cardHolderName,
     string cardNumber,
      string lastTransactionNumber,
       DateTime paidDate,
    DateTime expireDate,
    decimal total,
    decimal totalPaid,
    string payer,
    Document document,
    Address address,
    Email email) : base(
      paidDate,
      expireDate,
       total,
       totalPaid,
       payer,
        document,
       address,
        email)

    {
      CardHolderName = cardHolderName;
      CardNumber = cardNumber;
      LastTransactionNumber = lastTransactionNumber;
    }

    public String CardHolderName { get; private set; }
    public String CardNumber { get; private set; }
    public String LastTransactionNumber { get; private set; }
  }
}