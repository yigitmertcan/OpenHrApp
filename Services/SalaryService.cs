using AutoMapper;
using HrApp.Dtos.Requests;
using HrApp.Interfaces.Repositories;
using HrApp.Interfaces.Services;
using HrApp.Models;

namespace HrApp.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _SalaryRepository;
        private readonly IMapper _mapper;

        public SalaryService(ISalaryRepository SalaryRepository,IMapper mapper)
        {
            _SalaryRepository = SalaryRepository;
            _mapper = mapper;

        }

        public async Task<SalaryModel> CreateSalaryAsync(SalaryRequest salary)
        {
            SalaryModel salaryModel = _mapper.Map<SalaryModel>(salary);
            await _SalaryRepository.AddAsync(salaryModel);
            return salaryModel;
        }

        public async Task<List<SalaryModel>> GetAllSalarysAsync()
        {
            return await _SalaryRepository.GetAllAsync();
        }

        public async Task<SalaryModel> GetSalaryByIdAsync(int id)
        {
            return await _SalaryRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateSalaryAsync(SalaryModel salary)
        {
            var existingSalary = await _SalaryRepository.GetByIdAsync(salary.SalaryId);
            if (existingSalary == null)
            {
                return false;
            }

            existingSalary.SalaryId = salary.SalaryId;

            await _SalaryRepository.UpdateAsync(existingSalary);
            return true;
        }

        public async Task<bool> DeleteSalaryAsync(int id)
        {
            var salary = await _SalaryRepository.GetByIdAsync(id);
            if (salary == null)
            {
                return false;
            }

            await _SalaryRepository.DeleteAsync(salary);
            return true;
        }
    }
}
