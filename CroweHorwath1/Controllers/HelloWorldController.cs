using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CroweHorwath1.Models;

namespace CroweHorwath1.Controllers
{
    public class HelloWorldController : ApiController
    {
        List<Message> messages = new List<Message>
        {
            new Message { Id = 1, TextToDisplay = "Hello World" },
            new Message { Id = 2, TextToDisplay = "Hello World2" }

        };
   
        // GET: api/HelloWorld
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(messages);
            }
            catch(Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        // GET: api/HelloWorld/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(messages.Where(p => p.Id == id));
            }
            catch 
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No messages match this id"));
            }
        }

        // POST: api/HelloWorld
        public void Post([FromBody]string value)
        {
            try
            {
                
            }
            catch
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Adding messge was unsucessful"));
            }
        }

        // PUT: api/HelloWorld/5
        public void Put(int id, [FromBody]Message message)
        {
            try
            {
                
            }
            catch
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Updating message was unsucessful"));
            }
        }

        // DELETE: api/HelloWorld/5
        public void Delete(int id)
        {
            try
            {
                
            }
            catch
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Deleting message was unsucessful"));
            }
        }
    }
}
