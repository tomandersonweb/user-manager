using System;
using System.Collections.Generic;
using System.Text;

namespace DevTest.Core.Abstract
{
    public interface IMembershipService
    {
        void SetMembership(Guid userId, Guid membershipGroupId);

        List<MembershipGroup> GetMembershipGroups();
    }

    public class Membership
    {
        public Guid UserId { get; set; }

        public Guid GroupId { get; set; }
    }

    public class MembershipGroup
    {
        public Guid GroupId { get; set; }

        public string GroupName { get; set; }
    }
}
