using MediatR;
using taskManagementDomain;
using TaskManagmentApplication.command.authenticationCommand;
using TaskManagmentApplication.DTO.request;
using TaskManagmentApplication.generalResponse;
using TaskManagmentApplication.service;

namespace TaskManagmentApplication.Handler.authenticationHandler
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, generalApiResponse<Auth>>
    {
        private readonly IAuthService authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<generalApiResponse<Auth>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var dto = new RegisterDTO
            {
                UserName = request.registeredUser.UserName,
                Email = request.registeredUser.Email,
                Password = request.registeredUser.Password,
            };

            var result = await authService.Register(dto);

            return generalApiResponse<Auth>.SuccessResult(result, "User registered successfully");
        }


    }
}