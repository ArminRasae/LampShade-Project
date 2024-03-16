using System.Collections.Generic;
using System.Security.AccessControl;
using _0_Framework.Domain;

namespace IMSLP.Domain.Entities
{
    public class User : EntityBase
    {
        public string UserName { get;  set; }
        public string Password { get;  set; }
        public string Email { get;  set; }
        public string RealName { get;  set; }
        public string DescribeFirstContribution { get; set; }
        public string MusicalBackground { get;  set; }
        public string Languages { get;  set; }
        public string Affiliation { get;  set; }
        public bool IsDeleted { get;  set; }
        public bool IsAccountActive { get; set; }
        public string EmailActiveCode { get; set; }
    }
}
