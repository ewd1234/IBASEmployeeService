namespace IBASEmployeeService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using IBASEmployeeService.Models;
    using System.IO.Pipelines;

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        private static readonly List<Employee> Employees = new()
        {
            new Employee() {
                Id = "21",
                Name = "Mette Bangsbo",
                Email = "meba@ibas.dk",
                LogInName = "MetBan",
                Department = new Department() {
                    Id = 1,
                    Name = "Salg"
                }
            },
            new Employee() {
                Id = "22",
                Name = "Hans Merkel",
                Email = "hame@ibas.dk",
                LogInName = "HanMer",
                Department = new Department() {
                    Id = 2,
                    Name = "Support"
                }
            },
            new Employee() {
                Id = "23",
                Name = "Karsten Mikkelsen",
                Email = "kami@ibas.dk",
                LogInName = "KarMik",
                Department = new Department() {
                    Id = 2,
                    Name = "Support"
                }
            },
            // --- 3 nye i IT ---
            new Employee() {
                Id = "24",
                Name = "Sofie Nielsen",
                Email = "soni@ibas.dk",
                LogInName = "SofNie",
                Department = new Department() {
                    Id = 3,
                    Name = "IT"
                }
            },
            new Employee() {
                Id = "25",
                Name = "Lars Poulsen",
                Email = "lapo@ibas.dk",
                LogInName = "LarPou",
                Department = new Department() {
                    Id = 3,
                    Name = "IT"
                }
            },
            new Employee() {
                Id = "26",
                Name = "Camilla Hansen",
                Email = "caha@ibas.dk",
                LogInName = "CamHan",
                Department = new Department() {
                    Id = 3,
                    Name = "IT"
                }
            },
            // --- 2 nye i Kantinen ---
            new Employee() {
                Id = "27",
                Name = "Peter Jensen",
                Email = "peje@ibas.dk",
                LogInName = "PetJen",
                Department = new Department() {
                    Id = 4,
                    Name = "Kantinen"
                }
            },
            new Employee() {
                Id = "28",
                Name = "Annette Olsen",
                Email = "anol@ibas.dk",
                LogInName = "AnnOls",
                Department = new Department() {
                    Id = 4,
                    Name = "Kantinen"
                }
        }
        };
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }


    [HttpGet("GetEmployees")]
    public IEnumerable<Employee> Get()
    {
        return Employees;
    }

    
    [HttpGet("GetEmployeesByDepartmentId/{departmentId}")]
        public ActionResult<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {

            var employees = Employees.Where(e => e.Department != null && e.Department.Id == departmentId);
            
            if (!employees.Any())
            {
                return NotFound();
            }

            return Ok(employees);
    }
}}