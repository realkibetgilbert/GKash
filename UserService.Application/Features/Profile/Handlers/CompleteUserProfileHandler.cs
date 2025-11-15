using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.Features.Profile.Commands;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Application.Features.Profile.Handlers
{
    public class CompleteUserProfileHandler : IRequestHandler<CompleteUserProfileCommand, bool>
    {
        private readonly IUserRepository _users;
        private readonly IUserProfileRepository _profiles;

        public CompleteUserProfileHandler(
            IUserRepository users,
            IUserProfileRepository profiles)
        {
            _users = users;
            _profiles = profiles;
        }

        public async Task<bool> Handle(CompleteUserProfileCommand request, CancellationToken ct)
        {
            var user = await _users.GetByIdAsync(request.UserId);
            if (user == null)
                return false;

            var profile = new UserProfile
            {
                UserId = request.UserId,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                DOB = request.DOB,
                NationalIdNumber = request.NationalIdNumber,
                Email = request.Email,
                Gender = request.Gender,
                AlternativePhoneNumber = request.AlternativePhoneNumber,
                County = request.County,
                EducationLevel = request.EducationLevel,
                EmploymentType = request.EmploymentType,
                MonthlyIncome = request.MonthlyIncome,
                HasChildren = request.HasChildren,
                HasActiveLoan = request.HasActiveLoan,
                ConsentToBeContacted = request.ConsentToBeContacted,
                OnlyUserOfDevice = request.OnlyUserOfDevice,
                UsingDeviceMoreThan3Months = request.UsingDeviceMoreThan3Months,
                AdditionalContactName = request.AdditionalContactName,
                AdditionalContactPhone = request.AdditionalContactPhone,
                AdditionalContactRelationship = request.AdditionalContactRelationship
            };

            await _profiles.AddAsync(profile);

            user.IsProfileComplete = true;
            await _users.UpdateAsync(user);

            return true;
        }

    }
}
