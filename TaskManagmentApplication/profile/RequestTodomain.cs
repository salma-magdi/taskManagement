using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity;
using TaskManagmentApplication.DTO.request;

namespace TaskManagmentApplication.profile
{

    // req to database 
    // resource => req 
    // destination is db  =>   dto=> db 
    public class RequestTodomain : Profile
    {
       public RequestTodomain()
        {
            CreateMap<CreateProjectRequest, Project>();
            CreateMap<UpdateProjectRequest, Project>();
            CreateMap<CreateTaskRequest, TaskItem>();
        }
    }
}
