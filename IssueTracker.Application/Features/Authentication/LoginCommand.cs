using MediatR;

namespace IssueTracker.Application.Features.Authentication
{
    public class LoginCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
