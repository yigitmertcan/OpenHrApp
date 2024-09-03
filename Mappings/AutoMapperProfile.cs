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
            CreateMap<TrainingRequest,TrainingModel > ()
                .ForMember(dest => dest.TrainingName, opt => opt.MapFrom(src => src.TrainingName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

            CreateMap<SalaryRequest,SalaryModel>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.EffectiveDate, opt => opt.MapFrom(src => src.EffectiveDate));

            CreateMap<EmployerRequest,EmployerModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => src.HireDate))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.Departman, opt => opt.MapFrom(src => src.Departman))
                .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
                .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => src.Manager))
                .ForMember(dest => dest.Subordinates, opt => opt.MapFrom(src => src.Subordinates));

            CreateMap<AttendanceRequest,AttendanceModel>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee))
                .ForMember(dest => dest.CheckInTime, opt => opt.MapFrom(src => src.CheckInTime))
                .ForMember(dest => dest.CheckOutTime, opt => opt.MapFrom(src => src.CheckOutTime))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))  ;

            CreateMap<DepartmanRequest,DepartmanModel > ()
               .ForMember(dest => dest.DepartmanName, opt => opt.MapFrom(src => src.DepartmanName))
               .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
               .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));

            CreateMap<JobRequest,JobModel>()
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
                .ForMember(dest => dest.JobDescription, opt => opt.MapFrom(src => src.JobDescription))
                .ForMember(dest => dest.MinSalary, opt => opt.MapFrom(src => src.MinSalary))
                .ForMember(dest => dest.MaxSalary, opt => opt.MapFrom(src => src.MaxSalary));

            CreateMap<PerformanceReviewRequest, PerformanceReviewModel>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee))
                .ForMember(dest => dest.ReviewDate, opt => opt.MapFrom(src => src.ReviewDate))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

            CreateMap<LeaveRequestRequest,LeaveRequestModel>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.LeaveType, opt => opt.MapFrom(src => src.LeaveType))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Reason, opt => opt.MapFrom(src => src.Reason));

        }
    }
}
