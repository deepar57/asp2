using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using WebStore.Clients.Base;
using WebStore.Domain;
using WebStore.Domain.Entities.Employees;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Employees
{
	public class EmployeesClient : BaseClient, IEmployeesData
	{
		public EmployeesClient(IConfiguration Configuration)
			: base(Configuration, WebAPI.Employees)
		{
		}

		public IEnumerable<Employee> Get()
		{
			//var cts = new CancellationTokenSource();
			//var cancel = cts.Token;
			//var task = GetAsync<string>(WebAPI.Employees, cancel);
			//cts.Cancel();

			return Get<IEnumerable<Employee>>(_ServiceAddress);
		}

		public Employee GetById(int id)
		{
			return Get<Employee>($"{_ServiceAddress}/{id}");
		}

		public int Add(Employee Employee)
		{
			return Post(_ServiceAddress, Employee).Content.ReadAsAsync<int>().Result;
		}

		public void Edit(Employee Employee)
		{
			Put(_ServiceAddress, Employee);
		}

		public bool Delete(int id)
		{
			return Delete($"{_ServiceAddress}/{id}").IsSuccessStatusCode;
		}

		public void SaveChanges()
		{
		}
	}
}
