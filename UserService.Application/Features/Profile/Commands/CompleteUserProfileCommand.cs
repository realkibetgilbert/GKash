using MediatR;

namespace UserService.Application.Features.Profile.Commands
{
    public class CompleteUserProfileCommand : IRequest<bool>
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string NationalIdNumber { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string? AlternativePhoneNumber { get; set; }
        public string County { get; set; }
        public string EducationLevel { get; set; }
        public string EmploymentType { get; set; }
        public decimal? MonthlyIncome { get; set; }
        public bool? HasChildren { get; set; }
        public bool? HasActiveLoan { get; set; }
        public bool? ConsentToBeContacted { get; set; }
        public bool? OnlyUserOfDevice { get; set; }
        public bool? UsingDeviceMoreThan3Months { get; set; }
        public string AdditionalContactName { get; set; }
        public string AdditionalContactPhone { get; set; }
        public string AdditionalContactRelationship { get; set; }
    }
}
