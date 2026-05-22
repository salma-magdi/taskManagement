using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity;
using TaskManagmentApplication.DTO.response;

namespace TaskManagmentApplication.profile
{

    // domain  to response => resource => db , destination is response    db=> Dto
    public class DomainToResponse : Profile
    {
    public DomainToResponse()
        {
            CreateMap<Project, GetProjectResponse>();
            CreateMap<TaskItem,GetTaskResponse>();
        }
    }
}
