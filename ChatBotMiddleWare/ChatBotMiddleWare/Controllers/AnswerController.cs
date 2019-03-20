using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatBotMiddleWare.Controllers
{
    public class AnswerController : ApiController
    {

        public IHttpActionResult GetAnswer()
        {
            
            return Ok();
        }

        public IHttpActionResult PostAnswer()
        {

            return Ok();
        }
    }
}
