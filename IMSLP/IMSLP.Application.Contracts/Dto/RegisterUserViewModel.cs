namespace IMSLP.Application.Contracts.Dto
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Email { get; set; }
        public string RealName { get; set; }
        public string DescribeFirstContribution { get; set; }
        public string MusicalBackground { get; set; }
        public string Languages { get; set; }
        public string Affiliation { get; set; }
        public bool IsDeleted { get; set; }
    }

    public enum RegisterUserResult
    {
        MobileExists,
        Success
    }


}
