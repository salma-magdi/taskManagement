using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagementDomain;
using TaskManagmentApplication.DTO.request;

namespace TaskManagmentApplication.command.authenticationCommand
{
    public class RegisterCommand : IRequest<Auth>
    {
        public RegisterCommand(RegisterDTO registeredUser)
        {
            this.registeredUser = registeredUser;
        }

        public RegisterDTO registeredUser {  get; set; }
    }
}
