using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Domain.Entities
{
    public class UserProfile
    {
        public long Id { get; private set; }        
        public long UserId { get; private set; } 
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DOB { get; private set; }
        public string NationalIdNumber { get; private set; }
        public string Email { get; private set; }
        public string Gender { get; private set; }
        public string AlternativePhoneNumber { get; private set; }
        public string County { get; private set; }
        public string EducationLevel { get; private set; }
        public string EmploymentType { get; private set; }
        public decimal? MonthlyIncome { get; private set; }
        public bool? HasChildren { get; private set; }
        public bool? HasActiveLoan { get; private set; }
        public bool? ConsentToBeContacted { get; private set; }
        public bool? OnlyUserOfDevice { get; private set; }
        public bool? UsingDeviceMoreThan3Months { get; private set; }
        public string AdditionalContactName { get; private set; }
        public string AdditionalContactPhone { get; private set; }
        public string AdditionalContactRelationship { get; private set; }

    }
}
