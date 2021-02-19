using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAppWebApiEmp.Controllers
{
    public class Employee
    {
        public int Emp_Id { get; set; }
        public string Emp_Name { get; set; }
        public string Emp_City { get; set; }
        public Nullable<int> Emp_Age { get; set; }
    }
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        public Employee Get()
        {
            Employee emp = new Employee { Emp_Id = 1, Emp_Name = "cmm", Emp_Age = 20, Emp_City = "kl" };
            return emp;
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
