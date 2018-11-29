using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRMApp.Model;
using CRMApp.Business;
using System.Data.SqlClient;

namespace CRMApp.Controllers
{
    public class SubscroptionsController : ApiController
    {
        protected CustomerService _serviceSub;

        public SubscroptionsController()
        {
            _serviceSub = new CustomerService();
        }

        public IList<Customer> GetAll()
        {
            var items = _serviceSub.LoadAll();
            return items;
        }

        public IHttpActionResult Get(int id)
        {
            var item = _serviceSub.Load(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
    }
}


