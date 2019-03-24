using System.Web.Http;
using System.Web.Http.Cors;
using ChatBot.Logic.Services;
using ChatBot.Logic.Models;

namespace ChatBotAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        ConversationManagerService _conversationManagerService;
        private readonly string directLineSecret = "DxFVyxUZjIk.jHP0wNdNMkRohtMA3U5_jS6UBs2eRtFDK_C1HsNXlis";
        public string baseURI = "https://directline.botframework.com/v3/directline/conversations";

        /// <summary>
        /// Constructor
        /// </summary>
        public ValuesController()
        {
            _conversationManagerService = new ConversationManagerService();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("start")]
        public IHttpActionResult StartConversation()
        {
            var result = _conversationManagerService.StartNewConversation();
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("message")]
        public IHttpActionResult PostMessage(QuestionModel question)
        {
            var result = _conversationManagerService.GetMessage(question);
            return Ok(result);
        }
    }
}
