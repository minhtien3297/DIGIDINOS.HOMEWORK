using DemoWebAPI.Models;
using DemoWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        IComments Icom;

        public ValuesController()

        {

            Icom = new Comments();

        }

        // GET api/values

        public IEnumerable<Comment> GetAlldata()

        {

            return Icom.ListofComment();

        }

        // GET api/values/5

        public string Get(int id)

        {

            return "value";

        }

        // POST api/values

        public void Post([FromBody] Comment Comment)

        {

            Icom.InsertComment(Comment);

        }

        // PUT api/values/5

        public void Put(int id, [FromBody] string value)

        {

        }

        // DELETE api/values/5

        public void Delete(int id)

        {

        }

    }
}
