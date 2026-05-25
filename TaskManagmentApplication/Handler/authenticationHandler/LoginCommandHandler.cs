using MediatR;
using taskManagementDomain;
using TaskManagmentApplication.command.authenticationCommand;
using TaskManagmentApplication.service;

namespace TaskManagmentApplication.Handler.authenticationHandler
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Auth>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Auth> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _authService.Login(request.user);
        }
    }
}