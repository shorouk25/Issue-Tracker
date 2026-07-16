using MediatR;
using IssueTracker.Application.Interfaces;
using IssueTracker.Domain.Models;

namespace IssueTracker.Application.Features.Registration
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
            if(existingUser != null)
            {
                throw new Exception("This email is already registered.");
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Department = request.Department,
                Company = request.Company,
                Role = request.Role
            };
            await _userRepository.AddUserAsync(user);
            return Unit.Value;
        }
    }
}
