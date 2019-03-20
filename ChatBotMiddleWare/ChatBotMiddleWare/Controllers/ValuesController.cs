using ChatBotMiddleWare.Models;
using Microsoft.Bot.Connector.DirectLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace ChatBotMiddleWare.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {

        private readonly string directLineSecret = "DxFVyxUZjIk.jHP0wNdNMkRohtMA3U5_jS6UBs2eRtFDK_C1HsNXlis";
        public string baseURI = "https://directline.botframework.com/v3/directline/conversations";

        [HttpPost]
        [Route("start")]
        public IHttpActionResult StartConversation()
        {

            var client = new DirectLineClient(directLineSecret);
            //client.BaseUri = new Uri(baseURI);
            var conversationInfo = client.Conversations.StartConversation();

            System.Web.HttpContext.Current.Session["conversation"] = conversationInfo;


            return Ok(conversationInfo.ConversationId);
        }

        [HttpPost]
        [Route("message")]
        public IHttpActionResult PostMessage(QuestionModel question)
        {
            var client = new DirectLineClient(directLineSecret);

            var converastion = System.Web.HttpContext.Current.Session["conversation"] as Conversation;

            Activity message = new Activity
            {
                From = new ChannelAccount("Toto42"),
                Text = question.question,
                Type = ActivityTypes.Message
            };

        
            var res = client.Conversations.PostActivity(converastion.ConversationId, message);

            var msg = client.Conversations.GetActivities(question.conversationId).Activities.Last();
            
            return Ok(msg);
        }

        //public async Task<bool> PostMessage(QuestionModel question)
        //{



        //}

    }
}
