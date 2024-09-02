using AutoMapper;
using HrApp.Dtos.Requests;
using HrApp.Models;
using Microsoft.AspNetCore.Identity;

namespace HrApp.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TrainingModel,TrainingRequest>()
                .ForMember(dest => dest.TrainingName, opt => opt.MapFrom(src => src.TrainingName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(null, opt => opt.MapFrom(src => src.TrainingId));

            CreateMap<SalaryModel, SalaryRequest>()
               .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
               .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee))
               .ForMember(dest => dest.EffectiveDate, opt => opt.MapFrom(src => src.EffectiveDate))
               .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
               .ForMember(null, opt => opt.MapFrom(src => src.SalaryId));

            CreateMap<EmployerModel, EmployerRequest>()
               .ForMember(null, opt => opt.MapFrom(src => src.EmployeeId))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            CreateMap<AttendanceModel, AttendanceRequest>()
               .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId));

            CreateMap<DepartmanModel, DepartmanRequest>()
               .ForMember(null, opt => opt.MapFrom(src => src.DepartmantId))
               .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

            CreateMap<JobModel, JobRequest>()
               .ForMember(null, opt => opt.MapFrom(src => src.JobId))
               .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
               .ForMember(dest => dest.JobDescription, opt => opt.MapFrom(src => src.JobDescription))
               .ForMember(dest => dest.MinSalary, opt => opt.MapFrom(src => src.MinSalary))
               .ForMember(dest => dest.MaxSalary, opt => opt.MapFrom(src => src.MaxSalary));

            CreateMap<LeaveRequestModel, LeaveRequestRequest>()
               .ForMember(null, opt => opt.MapFrom(src => src.LeaveRequestId))
               .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee));

        }
    }
}
