using AngularCRUD.Models;  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace AngularCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        List<Employee> empList = new List<Employee>
        {
            new Employee(){Emp_Name = "CMM", Emp_Id = 1, Emp_Age=30, Emp_City="KL"},
            new Employee(){Emp_Name = "CYF", Emp_Id = 1, Emp_Age=30, Emp_City="Penang"}
        };

        
        // GET: Employee  
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>  
        ///   
        /// Get All Employee  
        /// </summary>  
        /// <returns></returns>  
        public JsonResult Get_AllEmployee()
        {
            //using (DemoEntities Obj = new DemoEntities())
            //{
            //    List<Employee> Emp = Obj.Employees.ToList();
            //    return Json(Emp, JsonRequestBehavior.AllowGet);
            //}
            if (System.Web.HttpContext.Current.Session["sessionString"] == null)
            {
                return Json(empList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                empList = (List<Employee>)System.Web.HttpContext.Current.Session["sessionString"];
                return Json(empList, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Get Employee With Id  
        /// </summary>  
        /// <param name="Id"></param>  
        /// <returns></returns>  
        public JsonResult Get_EmployeeById(string Id)
        {
            using (DemoEntities Obj = new DemoEntities())
            {
                int EmpId = int.Parse(Id);
                return Json(Obj.Employees.Find(EmpId), JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Insert New Employee  
        /// </summary>  
        /// <param name="Employe"></param>  
        /// <returns></returns>  
        public string Insert_Employee(Employee Employe)
        {
            if (Employe != null)
            {
                //using (DemoEntities Obj = new DemoEntities())
                //{
                //    Obj.Employees.Add(Employe);
                //    Obj.SaveChanges();
                //    return "Employee Added Successfully";
                //}
                empList.Add(Employe);
                System.Web.HttpContext.Current.Session["sessionString"] = empList;
                return "Employee Added Successfully";
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }

        }
        /// <summary>  
        /// Delete Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string Delete_Employee(Employee Emp)
        {
            if (Emp != null)
            {
                //using (DemoEntities Obj = new DemoEntities())
                //{
                //    var Emp_ = Obj.Entry(Emp);
                //    //if (Emp_.State == System.Data.Entity.EntityState.Detached)
                //    if (Emp_.State == EntityState.Detached)
                //    {
                //        Obj.Employees.Attach(Emp);
                //        Obj.Employees.Remove(Emp);
                //    }
                //    Obj.SaveChanges();
                //    return "Employee Deleted Successfully";
                //}
                if (System.Web.HttpContext.Current.Session["sessionString"] == null)
                {

                    var item = empList.First(x => x.Emp_Name == Emp.Emp_Name);
                    
                    empList.Remove(item);
                    System.Web.HttpContext.Current.Session["sessionString"] = empList;
                }
                else
                {
                    empList = (List<Employee>)System.Web.HttpContext.Current.Session["sessionString"];
                    empList.Remove(Emp);
                    System.Web.HttpContext.Current.Session["sessionString"] = empList;
                }
                return "Employee Deleted Successfully";
            }
            else
            {
                return "Employee Not Deleted! Try Again";
            }
        }
        /// <summary>  
        /// Update Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string Update_Employee(Employee Emp)
        {
            if (Emp != null)
            {
                //using (DemoEntities Obj = new DemoEntities())
                //{
                //    var Emp_ = Obj.Entry(Emp);
                //    Employee EmpObj = Obj.Employees.Where(x => x.Emp_Id == Emp.Emp_Id).FirstOrDefault();
                //    EmpObj.Emp_Age = Emp.Emp_Age;
                //    EmpObj.Emp_City = Emp.Emp_City;
                //    EmpObj.Emp_Name = Emp.Emp_Name;
                //    Obj.SaveChanges();
                //    return "Employee Updated Successfully";
                //}

                if (System.Web.HttpContext.Current.Session["sessionString"] == null)
                {
                    var item = empList.First(x => x.Emp_Name == Emp.Emp_Name);
                    if (item != null)
                    {
                        item.Emp_Age = Emp.Emp_Age;
                        item.Emp_City = Emp.Emp_City;
                        System.Web.HttpContext.Current.Session["sessionString"] = empList;
                    }
                    return "Employee Updated Successfully";
                }
                else
                {
                    empList = (List<Employee>)System.Web.HttpContext.Current.Session["sessionString"];
                    var item = empList.First(x => x.Emp_Name == Emp.Emp_Name);
                    if (item != null)
                    {
                        item.Emp_Age = Emp.Emp_Age;
                        item.Emp_City = Emp.Emp_City;
                        System.Web.HttpContext.Current.Session["sessionString"] = empList;
                    }
                    return "Employee Updated Successfully";
                }
            }
            else
            {
                return "Employee Not Updated! Try Again";
            }
        }
    }
}
