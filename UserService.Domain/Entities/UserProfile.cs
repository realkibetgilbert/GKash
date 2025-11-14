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

        public UserProfile(
            long userId,
            string firstName,
            string lastName,
            DateTime dob,
            string nationalIdNumber)
        {
            if (userId <= 0)
                throw new ArgumentException("Invalid user ID.", nameof(userId));
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required.", nameof(lastName));
            if (string.IsNullOrWhiteSpace(nationalIdNumber))
                throw new ArgumentException("National ID is required.", nameof(nationalIdNumber));

            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = string.Empty;
            DOB = dob;
            NationalIdNumber = nationalIdNumber;
        }

        public void SetMiddleName(string middleName) => MiddleName = middleName;
        public void SetEmail(string email) => Email = email;
        public void SetGender(string gender) => Gender = gender;
        public void SetAlternativePhone(string phone) => AlternativePhoneNumber = phone;
        public void SetCounty(string county) => County = county;
        public void SetEducationLevel(string education) => EducationLevel = education;
        public void SetEmploymentType(string employment) => EmploymentType = employment;
        public void SetMonthlyIncome(decimal income) => MonthlyIncome = income;
        public void SetHasChildren(bool hasChildren) => HasChildren = hasChildren;
        public void SetHasActiveLoan(bool hasLoan) => HasActiveLoan = hasLoan;
        public void SetConsentToBeContacted(bool consent) => ConsentToBeContacted = consent;
        public void SetDeviceUsage(bool onlyUser, bool usedMoreThan3Months)
        {
            OnlyUserOfDevice = onlyUser;
            UsingDeviceMoreThan3Months = usedMoreThan3Months;
        }
        public void SetAdditionalContact(string name, string phone, string relationship)
        {
            AdditionalContactName = name;
            AdditionalContactPhone = phone;
            AdditionalContactRelationship = relationship;
        }
    }
}
