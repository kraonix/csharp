using System;
using System.Collections.Generic;
using System.Linq;
namespace GymMembership
{
    class GymManager
    {
        private List<Member> members = new List<Member>();
        private List<FitnessClass> classes = new List<FitnessClass>();
        private int memberIdCounter = 1;

        public void AddMember(string name, string membershipType, int months)
        {
            members.Add(new Member
            {
                MemberId = memberIdCounter++,
                Name = name,
                MembershipType = membershipType,
                JoinDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddMonths(months)
            });
        }

        public void AddClass(string className, string instructor, DateTime schedule, int maxParticipants)
        {
            classes.Add(new FitnessClass
            {
                ClassName = className,
                Instructor = instructor,
                Schedule = schedule,
                MaxParticipants = maxParticipants
            });
        }

        public bool RegisterForClass(int memberId, string className)
        {
            Member member = members.FirstOrDefault(m => m.MemberId == memberId);
            FitnessClass fitnessClass = classes.FirstOrDefault(c => c.ClassName.Equals(className, StringComparison.OrdinalIgnoreCase));

            if (member == null || fitnessClass == null)
                throw new Exception("Member or Class not found");

            if (fitnessClass.RegisteredMembers.Count >= fitnessClass.MaxParticipants)
                return false;

            if (!fitnessClass.RegisteredMembers.Contains(memberId))
                fitnessClass.RegisteredMembers.Add(memberId);

            return true;
        }

        public Dictionary<string, List<Member>> GroupMembersByMembershipType()
        {
            return members.GroupBy(m => m.MembershipType)
                          .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<FitnessClass> GetUpcomingClasses()
        {
            DateTime limit = DateTime.Now.AddDays(7);
            return classes.Where(c => c.Schedule >= DateTime.Now && c.Schedule <= limit)
                          .OrderBy(c => c.Schedule)
                          .ToList();
        }

        public List<Member> GetAllMembers() => members;
        public List<FitnessClass> GetAllClasses() => classes;
    }

}