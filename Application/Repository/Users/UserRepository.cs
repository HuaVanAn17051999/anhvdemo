using Application.Contract.Criteria.Users;
using Application.Contract.Model.Common;
using Application.Entities;
using Application.Repository.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Users
{
    public class UserRepository : RespositoryBase<Entities.User, ShopDbContext>, IUserRepository
    {
        public UserRepository(ShopDbContext context) : base(context)
        {

        }
        public async Task<PageResultData<User>> SearchAsync(UserCriteria criteria)
        {
            var query = DbSet
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Where(x =>
                (
                    string.IsNullOrEmpty(criteria.FirstName) || x.FirstName.ToLower().Contains(criteria.FirstName.ToLower())
                )
                &&
                (
                    string.IsNullOrEmpty(criteria.LastName) || x.LastName.ToLower().Contains(criteria.LastName.ToLower())
                )
                &&
                (
                    string.IsNullOrEmpty(criteria.UserName) || x.UserName.ToLower().Contains(criteria.UserName.ToLower())
                )
                &&
                (
                    string.IsNullOrEmpty(criteria.Email) || x.Email.ToLower().Contains(criteria.Email.ToLower())
                )
                &&
                (
                    string.IsNullOrEmpty(criteria.Role)
                    ||
                    (
                        x.UserRoles.Any(ur => ur.Role.Name.ToLower().Equals(criteria.Role.ToLower()))
                    )
                )
               )
                .AsNoTracking();

            int totalRecord = await query.CountAsync();
            criteria.SortColumn = string.IsNullOrEmpty(criteria.SortColumn) ? string.Empty : criteria.SortColumn;
            bool isAsc = criteria.SortDirection.ToLower().Equals("asc");

            switch (criteria.SortColumn)
            {
                case "FirstName":
                    query = isAsc ? query.OrderBy(t => t.FirstName) : query.OrderByDescending(t => t.FirstName);
                    break;
                case "LastName":
                    query = isAsc ? query.OrderBy(t => t.LastName) : query.OrderByDescending(t => t.LastName);
                    break;

                case "UserName":
                    query = isAsc ? query.OrderBy(t => t.UserName) : query.OrderByDescending(t => t.UserName);
                    break;

                default:
                    query = isAsc ? query.OrderBy(t => t.Email) : query.OrderByDescending(t => t.Email);
                    break;
            }

            var returnData = await query.Skip(criteria.CurrentPage * criteria.ItemPerPage).Take(criteria.ItemPerPage).ToListAsync();

            return new PageResultData<Entities.User>(totalRecord, returnData);

        }
    }
}
