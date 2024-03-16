using System.Diagnostics.CodeAnalysis;
using _0_Framework.Domain;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
       
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Phone { get; private set; }
        public string  Email { get; set; }

        public string ProfilePhoto { get; private set; }
        public long RoleId { get; private set; }

        public Account(string fullName, string userName, string password, string phone, string profilePhoto, long roleId)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            Phone = phone;
            ProfilePhoto = profilePhoto;
            RoleId = roleId;
        }

        public void Edit(string fullName, string userName, string phone, string profilePhoto, long roleId)
        {
            FullName = fullName;
            UserName = userName;
            Phone = phone;
            RoleId = roleId;
            if (!string.IsNullOrWhiteSpace(ProfilePhoto))
                ProfilePhoto = profilePhoto;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public override bool Equals(object? obj)
        {                                                                           
            return obj is Account account &&
                   Id == account.Id &&
                   CreationDate == account.CreationDate &&
                   FullName == account.FullName &&
                   UserName == account.UserName &&
                   Password == account.Password &&
                   Phone == account.Phone &&
                   ProfilePhoto == account.ProfilePhoto &&
                   RoleId == account.RoleId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CreationDate, FullName, UserName, Password, Phone, ProfilePhoto, RoleId);
        }
    }
}
