using DevTest.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevTest.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<MembershipGroup> MembershipGroups { get; set; } = new List<MembershipGroup>();

    }
}