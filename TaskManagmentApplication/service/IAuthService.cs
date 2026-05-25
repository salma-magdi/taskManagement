using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagementDomain;
using TaskManagmentApplication.DTO.request;

namespace TaskManagmentApplication.service
{
    public interface IAuthService
    {
        Task<Auth> Register(RegisterDTO registeredModel);
        Task<Auth> Login(LoginDTO user);


    }
}
