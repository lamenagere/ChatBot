using ChatBotMiddleWare.Models;
using ChatBotMiddleWare.Services;
using Microsoft.Bot.Connector.DirectLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ChatBotMiddleWare.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        ConversationManagerService _conversationManagerService;

        public ValuesController()
        {
            _conversationManagerService = new ConversationManagerService();
        }

        private readonly string directLineSecret = "DxFVyxUZjIk.jHP0wNdNMkRohtMA3U5_jS6UBs2eRtFDK_C1HsNXlis";
        public string baseURI = "https://directline.botframework.com/v3/directline/conversations";

        [HttpPost]
        [Route("start")]
        public IHttpActionResult StartConversation()
        {

            //var client = new DirectLineClient(directLineSecret);
            ////client.BaseUri = new Uri(baseURI);
            //var conversationInfo = client.Conversations.StartConversation();

            //System.Web.HttpContext.Current.Session["conversation"] = conversationInfo;
            var result = _conversationManagerService.StartNewConversation();
            return Ok(result);
        }

        [HttpPost]
        [Route("message")]
        public IHttpActionResult PostMessage(QuestionModel question)
        {

            var result = _conversationManagerService.GetMessage(question);

            //var client = new DirectLineClient(directLineSecret);
            ////var conversationInfo = client.Conversations.StartConversation();
            //var conversation = System.Web.HttpContext.Current.Session["conversation"] as Conversation;
            //Activity msg;

            //Activity message = new Activity
            //{
            //    From = new ChannelAccount("Toto42"),
            //    Text = question.text,
            //    Type = ActivityTypes.Message
            //};

            //try
            //{

            //    if (conversation == null) conversation = client.Conversations.StartConversation();

            //    var res = client.Conversations.PostActivity(question.conversationId, message);
            //    msg = client.Conversations.GetActivities(question.conversationId).Activities.Last();


            //}
            //catch (Exception ex)
            //{
            //    return InternalServerError(ex);
            //}

            //var answer = new AnswerModel()
            //{
            //    conversationId = msg.Conversation.Id,
            //    images = null,
            //    text = msg.Text
            //};

            //System.Web.HttpContext.Current.Session["conversation"] = conversation;


            return Ok(result);
        }

        //public async Task<bool> PostMessage(QuestionModel question)
        //{



        //}

    }
}
