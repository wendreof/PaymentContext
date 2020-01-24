using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentQueriesTest
  {

    private System.Collections.Generic.IList<Student> _students;

    public StudentQueriesTest()
    {
      for (var i = 0; i <= 10; i++)
      {
        _students.Add(new Student(
          new Name("Aluno", i.ToString()),
          new Document("11111111111" + i.ToString(), EDocumentType.CPF),
          new Email(i.ToString() + "@balta.io")
          ));
      }
    }

    [TestMethod]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
      var exp = StudentQueries.GetStudent("1234566");
      var student = _students.AsQueryable().Where(exp).FirstOrDefault();

      Assert.AreEqual(null, student);
    }

    [TestMethod]
    public void ShouldReturnStudentWhenDocumentExists()
    {
      var exp = StudentQueries.GetStudent("111111111111");
      var student = _students.AsQueryable().Where(exp).FirstOrDefault();

      Assert.AreEqual(null, student);
    }
  }
}
