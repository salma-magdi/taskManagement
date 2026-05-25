using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagementDomain;
using TaskManagmentApplication.DTO.request;
using TaskManagmentApplication.generalResponse;

namespace TaskManagmentApplication.command.authenticationCommand
{
   public class LoginCommand:IRequest<generalApiResponse<Auth>>
    {
        public LoginCommand(LoginDTO user)
        {
            this.user = user;
        }

        public LoginDTO user { get; set; }
      

    }
}
