using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace Reset_APi.Controllers
{
    public class CustomerController : ApiController
    {
        //1. Dịch vụ lấy thông tin của toàn bộ khách hàng
        [HttpGet]
        public List<tblKhach> GetCustomerLists()
        {
            LINQ_SQLDataContext dbCustomer = new LINQ_SQLDataContext();
            return dbCustomer.tblKhaches.ToList();
        }
        //2. Dịch vụ lấy thông tin một khách hàng với mã nào đó
         [HttpGet]
        public tblKhach GetCustomer(string id)
        {
            LINQ_SQLDataContext dbCustomer = new
           LINQ_SQLDataContext();
            return dbCustomer.tblKhaches.FirstOrDefault(x =>
           x.Makhach == id);
        }
        [HttpPost]
        public bool InsertNewCustomer(string id, string name,
            string adress, string phoneNumber)
        {
            try
            {
                LINQ_SQLDataContext dbCustomer = new
               LINQ_SQLDataContext();
                tblKhach customer = new tblKhach();
                customer.Makhach = id;
                customer.TenKhach = name;
                customer.DiaChi = adress;
                customer.DienThoai = phoneNumber;

                dbCustomer.tblKhaches.InsertOnSubmit(customer);
                dbCustomer.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpPut]
        public bool UpdateCustomer(string id, string name,
        string adress, string phoneNumber)
        {
            try
            {
                LINQ_SQLDataContext dbCustomer = new
               LINQ_SQLDataContext();
                //Lấy mã khách đã có
                tblKhach customer =
               dbCustomer.tblKhaches.FirstOrDefault(x => x.Makhach == id);
                if (customer == null) return false;
                customer.Makhach = id;
                customer.TenKhach = name;
                customer.DiaChi = adress;
                customer.DienThoai = phoneNumber;
                dbCustomer.SubmitChanges();//Xác nhận chỉnh 
               
            return true;
            }
            catch
            {
                return false;
            }
        }
        //5.httpDelete để xóa một Khách hàng
        [HttpDelete]
        public bool DeleteCustomer(string id)
        {
            try
            {
                LINQ_SQLDataContext dbCustomer = new
               LINQ_SQLDataContext();
                //Lấy mã khách đã có
                tblKhach customer =
               dbCustomer.tblKhaches.FirstOrDefault(x => x.Makhach == id);
                if (customer == null) return false;

                dbCustomer.tblKhaches.DeleteOnSubmit(customer);
                dbCustomer.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
