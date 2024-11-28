using Blazor_Server.Service.IService;
using Core.BethanysPieShopHR;

namespace Blazor_Server.Service
{
    public class MockEmployeeService : IEmployeeService
    {
        private List<Employee> _employees;
        private List<Country> _countries;
        private List<JobCategory> _jobCategories;

        private IEnumerable<Employee> Employees
        {
            get
            {
                if (_employees == null)
                    InitializeEmployees();
                return _employees;
            }
        }

        private List<Country> Countries
        {
            get
            {
                if (_countries == null)
                    InitializeCountries();
                return _countries;
            }
        }

        private List<JobCategory> JobCategories
        {
            get
            {
                if (_jobCategories == null)
                    InitializeJobCategories();
                return _jobCategories;
            }
        }

        private void InitializeJobCategories()
        {
            _jobCategories = new List<JobCategory>()
            {
                new JobCategory{Id = 1, Name = "Pie research"},
                new JobCategory{Id = 2, Name = "Sales"},
                new JobCategory{Id = 3, Name = "Management"},
                new JobCategory{Id = 4, Name = "Store staff"},
                new JobCategory{Id = 5, Name = "Finance"},
                new JobCategory{Id = 6, Name = "QA"},
                new JobCategory{Id = 7, Name = "IT"},
                new JobCategory{Id = 8, Name = "Cleaning"},
                new JobCategory{Id = 9, Name = "Bakery"},
                new JobCategory{Id = 9, Name = "Bakery"}

            };
        }

        private void InitializeCountries()
        {
            _countries = new List<Country>
            {
                new Country {Id = 1, Name = "Belgium"},
                new Country {Id = 2, Name = "Netherlands"},
                new Country {Id = 3, Name = "USA"},
                new Country {Id = 4, Name = "Japan"},
                new Country {Id = 5, Name = "China"},
                new Country {Id = 6, Name = "UK"},
                new Country {Id = 7, Name = "France"},
                new Country {Id = 8, Name = "Brazil"}
            };
        }

        private void InitializeEmployees()
        {
            if (_employees == null)
            {
                Employee e1 = new Employee
                {
                    CountryId = 1,
                    MaritalStatus = MaritalStatus.Single,
                    BirthDate = new DateTime(1979, 1, 16),
                    City = "Brussels",
                    Email = "bethany@bethanyspieshop.com",
                    Id = 1,
                    FirstName = "Bethany",
                    LastName = "Smith",
                    Gender = Gender.Female,
                    PhoneNumber = "324777888773",
                    Smoker = false,
                    Street = "Grote Markt 1",
                    Zip = "1000",
                    JobCategoryId = 1,
                    Comment = "Lorem Ipsum",
                    ExitDate = null,
                    JoinedDate = new DateTime(2015, 3, 1)
                };
                _employees = new List<Employee>() { e1 };
            }
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await Task.Run(() => Employees);
        }

        public async Task<List<Country>> GetAllCountries()
        {
            return await Task.Run(() => Countries);
        }

        public async Task<List<JobCategory>> GetAllJobCategories()
        {
            return await Task.Run(() => JobCategories);
        }

        public async Task<Employee> Get(int id)
        {
            return await Task.Run(() => { return Employees.FirstOrDefault(e => e.Id == id); });
        }

        public Task<Employee> Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
