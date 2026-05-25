using MediatR;
using taskManagementDomain;
using TaskManagmentApplication.command.authenticationCommand;
using TaskManagmentApplication.generalResponse;
using TaskManagmentApplication.service;

namespace TaskManagmentApplication.Handler.authenticationHandler
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, generalApiResponse<Auth>>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<generalApiResponse<Auth>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
           await _authService.Login(request.user);
           return generalApiResponse
                <Auth>.SuccessResult(await _authService.Login(request.user), "Login successful");
        }
    }
}