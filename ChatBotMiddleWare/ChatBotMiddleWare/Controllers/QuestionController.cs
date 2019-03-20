using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatBotMiddleWare.Controllers
{
    public class QuestionController : ApiController
    {

        public IHttpActionResult GetQuestion()
        {

            return Ok();
        }

        //public IHttpActionResult PostQuestion()
        //{

        //    return Ok();
        //}

    }
}
