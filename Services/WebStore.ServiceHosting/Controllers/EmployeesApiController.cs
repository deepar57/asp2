using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore.Domain.Entities.Employees;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
	//[Route("api/[controller]")]
	[Route(WebAPI.Employees)]
	[ApiController]
	public class EmployeesApiController : ControllerBase, IEmployeesData
	{
		private readonly IEmployeesData _EmployeesData;

		public EmployeesApiController(IEmployeesData employeesData)
		{
			_EmployeesData = employeesData;
		}

		[HttpGet]
		public IEnumerable<Employee> Get()
		{
			return _EmployeesData.Get();
		}

		[HttpGet("{id}")]
		public Employee GetById(int id)
		{
			return _EmployeesData.GetById(id);
		}

		[HttpPost]
		public int Add([FromBody] Employee Employee)
		{
			int id = _EmployeesData.Add(Employee);
			SaveChanges();
			return id;
		}

		[HttpPut]
		public void Edit(Employee Employee)
		{
			_EmployeesData.Edit(Employee);
			SaveChanges();
		}

		[HttpDelete("{id}")]
		public bool Delete(int id)
		{
			bool success = _EmployeesData.Delete(id);
			SaveChanges();
			return success;
		}

		public void SaveChanges()
		{
			_EmployeesData.SaveChanges();
		}
	}
}
