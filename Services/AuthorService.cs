using AutoMapper;
using Library.DAL;
using Library.Interfaces;
using Library.Models.DataModels;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Library.Services
{
    public class AuthorService : BaseService, IAuthorService
    {
        public AuthorService(ILogger logger, IMapper mapper, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, LibraryContext dbContext)
            : base(logger, mapper, userManager, roleManager, dbContext)
        { }

        public AuthorVm GetAuthor(Expression<Func<Author, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException($"filterExpression is null");

                var authorEntity = DbContext.Authors.FirstOrDefault(filterExpression);

                var authorVm = Mapper.Map<AuthorVm>(authorEntity);
                return authorVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<AuthorVm> GetAuthors(Expression<Func<Author, bool>> filterExpression = null)
        {
            try
            {
                var authorsEntities = DbContext.Authors.AsQueryable();

                if (filterExpression != null)
                    authorsEntities = authorsEntities.Where(filterExpression);

                var authorsVm = Mapper.Map<IEnumerable<AuthorVm>>(authorsEntities);
                return authorsVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
