using System;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Queries
{
  public static class StudentQueries
  {
    public static System.Linq.Expressions.Expression<Func<Student, bool>> GetStudent(string document)
    {
      return x => x.Document.Number == document;
    }
  }
}