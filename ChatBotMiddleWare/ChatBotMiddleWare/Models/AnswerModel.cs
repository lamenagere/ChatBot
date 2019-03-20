using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBotMiddleWare.Models
{
    public class AnswerModel
    {

        public string text { get; set; }
        public string[] images { get; set; }
        public string conversationId { get; set; }

    }
}