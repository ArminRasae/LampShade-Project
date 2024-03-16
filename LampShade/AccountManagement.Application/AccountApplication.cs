using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;

        public AccountApplication(IAccountRepository accountRepository, IFileUploader fileUploader, IPasswordHasher passwordHasher)
        {
            _accountRepository = accountRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
        }

        public OperationResult Create(CreateAccountCommand command)
        {
            var operation = new OperationResult();
            if (_accountRepository.Exists(x => x.FullName == command.FullName || x.Phone == x.Phone))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            var password = _passwordHasher.Hash(command.Password);

            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto,path);

            var entityAccount = new Account(command.FullName,command.UserName, password, command.Phone, picturePath, command.RoleId);
            
            _accountRepository.Create(entityAccount);
            _accountRepository.Save();
            return operation.Succeeded();
        }

        public EditAccountCommand GetDetailsBy(long id)
        {
            return _accountRepository.GetDetailsBy(id);
        }

        public OperationResult Edit(EditAccountCommand command)
        {
            var operation = new OperationResult();
            if(_accountRepository.Exists(x => x.UserName == command.UserName || x.Phone == command.Phone || x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            var details = _accountRepository.GetBy(command.Id);

            var path = $"profilePhoto";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto,path);
            details.Edit(command.FullName,command.UserName,command.Phone,picturePath,command.RoleId);
            if (details == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

            return operation.Succeeded();

        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var details = _accountRepository.GetBy(command.Id);
            if (details == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            var password = _passwordHasher.Hash(command.Password);
            details.ChangePassword(password);
            _accountRepository.Save();
            return operation.Succeeded();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }
    }

}
