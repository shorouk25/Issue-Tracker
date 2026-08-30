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
            var isEmailRegistered = await _userRepository.IsEmailRegisteredAsync(request.Email);
            if(isEmailRegistered)
            {
                throw new Exception("This email is already registered.");
            }

            var user = new Domain.Models.User
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role
            };
            await _userRepository.AddUserAsync(user);
            return Unit.Value;
        }
    }
}
