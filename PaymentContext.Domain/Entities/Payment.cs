using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Share.Entities;

namespace PaymentContext.Domain.Entities
{
  public abstract class Payment : Entity
  {
    protected Payment(DateTime paidDate,
     DateTime expireDate,
      decimal total,
       decimal totalPaid,
        string payer,
         Document document,
         Address address,
         Email email)
    {
      Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
      PaidDate = paidDate;
      ExpireDate = expireDate;
      Total = total;
      TotalPaid = totalPaid;
      Payer = payer;
      Document = document;
      Address = address;
      Email = email;

      AddNotifications(new Contract()
        .Requires()
        .IsLowerOrEqualsThan(0, Total, "Payment.Total", "O total ñ pode ser 0")
        .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.Total", "Valor pago é menor do que u pgto")
      );
    }

    public string Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public Decimal Total { get; private set; }
    public Decimal TotalPaid { get; private set; }
    public String Payer { get; private set; }
    public Document Document { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
  }
}