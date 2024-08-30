using HrApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrApp.Contexts
{
    public partial class HrDBContext : DbContext
    {
        public HrDBContext(DbContextOptions<HrDBContext> options): base(options)
        {
        }
        public virtual DbSet<UserModel> User { get; set; }
        public virtual DbSet<EmployerModel> Employer { get; set; }
        public virtual DbSet<JobModel> Job { get; set; }
        public virtual DbSet<TrainingModel> Training { get; set; }
        public virtual DbSet<SalaryModel> Salary { get; set; }
        public virtual DbSet<AttendanceModel> Attendance { get; set; }
        public virtual DbSet<DepartmanModel> Departmen { get; set; }
        public virtual DbSet<LeaveRequestModel> LeaveRequest { get; set; }
        public virtual DbSet<PerformanceReviewModel> PerformanceReview { get; set; }
        public virtual DbSet<RecruitmentModel> Recruitment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.UserModel>(entity => {
                entity.HasKey(k => k.Id);
            });

            modelBuilder.Entity<Models.EmployerModel>(entity => {
                entity.HasKey(k => k.EmployeeId);
            });

            modelBuilder.Entity<Models.JobModel>(entity => {
                entity.HasKey(k => k.JobId);
            });

            modelBuilder.Entity<Models.TrainingModel>(entity => {
                entity.HasKey(k => k.TrainingId);
            });

            modelBuilder.Entity<Models.SalaryModel>(entity => {
                entity.HasKey(k => k.SalaryId);
            });

            modelBuilder.Entity<Models.AttendanceModel>(entity => {
                entity.HasKey(k => k.AttendanceId);
            });

            modelBuilder.Entity<Models.DepartmanModel>(entity => {
                entity.HasKey(k => k.DepartmantId);
            });

            modelBuilder.Entity<Models.LeaveRequestModel>(entity => {
                entity.HasKey(k => k.LeaveRequestId);
            });

            modelBuilder.Entity<Models.PerformanceReviewModel>(entity => {
                entity.HasKey(k => k.ReviewId);
            });

            modelBuilder.Entity<Models.RecruitmentModel>(entity => {
                entity.HasKey(k => k.RecruitmentId);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

