using System;
using System.Collections.Generic;
using System.Linq;
namespace GymMembership
{
    class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string MembershipType { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}