using DevTest.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DevTest.Core.Services
{
    public class MembershipService : IMembershipService
    {
        private static List<MembershipGroup> groups = new List<MembershipGroup>()
        {
            new MembershipGroup(){ GroupId = Guid.Parse("06e72ae4-b2dd-487f-aa15-4f5c65878f11"), GroupName = "Alpha", },
            new MembershipGroup(){ GroupId = Guid.Parse("06e72ae4-b2dd-487f-aa15-4f5c65878f22"), GroupName = "Beta" },
            new MembershipGroup(){ GroupId = Guid.Parse("06e72ae4-b2dd-487f-aa15-4f5c65878f33"), GroupName = "Gamma" }
        };

        public MembershipService()
        {

        }

        public void SetMembership(Guid userId, Guid membershipGroupId)
        {

        }

        public List<MembershipGroup> GetMembershipGroups()
        {
            return groups;
        }
    }
}
