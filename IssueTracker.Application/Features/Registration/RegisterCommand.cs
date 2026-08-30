using IssueTracker.Domain.Enums;
using IssueTracker.Domain.Models;
using MediatR;

namespace IssueTracker.Application.Features.Registration
{
    public class RegisterCommand : IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
