using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class DocumentTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
      var doc = new Document("123", EDocumentType.CNPJ);
      Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessCNPJIsValid()
    {
      var doc = new Document("34110468000150", EDocumentType.CNPJ);
      Assert.IsTrue(doc.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
      var doc = new Document("123", EDocumentType.CPF);
      Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessCPFIsValid()
    {
      var doc = new Document("41720163839", EDocumentType.CPF);
      Assert.IsTrue(doc.Valid);
    }
  }
}
