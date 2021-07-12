using Library.Models.DataModels;
using Library.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Library.Interfaces
{
    public interface IAuthorService
    {
        AuthorVm GetAuthor(Expression<Func<Author, bool>> filterExpression);

        IEnumerable<AuthorVm> GetAuthors(Expression<Func<Author, bool>> filterExpression = null);
    }
}
