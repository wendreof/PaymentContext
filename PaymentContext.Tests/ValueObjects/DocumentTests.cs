using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class DocumentTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
      Assert.Fail();
    }

    [TestMethod]
    public void ShouldReturnSuccessCNPJIsValid()
    {
      Assert.Fail();
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
      Assert.Fail();
    }

    [TestMethod]
    public void ShouldReturnSuccessCPFIsValid()
    {
      Assert.Fail();
    }
  }
}
