using System.Reflection.Metadata.Ecma335;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AccountRepository : RepositoryBase<long,Account> , IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context) : base(context) 
        {
            _context = context;
        }


        public EditAccountCommand GetDetailsBy(long id)
        {
           return _context.Accounts.Select(x => new EditAccountCommand()
            {
                Id = x.Id,
                Phone = x.Phone,
                FullName = x.FullName,
                RoleId = x.RoleId,
                UserName = x.UserName,
                
            }).FirstOrDefault(x => x.Id == id)!;
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _context.Accounts.Select(account => new AccountViewModel()
            {
                Id = account.Id,
                Phone = account.Phone,
                FullName = account.FullName,
                UserName = account.UserName,
                ProfilePhoto = account.ProfilePhoto,
                RoleId = 2,
                Role = "مدیر سیستم",
                CreationDate = account.CreationDate.ToFarsi()

            });
            
            if (!string.IsNullOrWhiteSpace(searchModel.FullName))
            {
                query = query.Where(x => x.FullName
                    .Contains(searchModel.FullName));
            }
            if (!string.IsNullOrWhiteSpace(searchModel.UserName))
            {
                query = query.Where(x => x.UserName
                    .Contains(searchModel.UserName));
            }
            if (!string.IsNullOrWhiteSpace(searchModel.Phone))
            {
                query = query.Where(x => x.Phone
                    .Contains(searchModel.Phone));
            }

            if (searchModel.RoleId != null)
            {
                query = query.Where(x => x.RoleId == searchModel.RoleId);
            }

            return query.OrderByDescending(x => x.Id).ToList();


        }
    }
}
