using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Logic.Models
{
    public class QuestionModel
    {

        public string text { get; set; }
        public string[] images { get; set; }
        public string conversationId { get; set; }
        public string userId { get; set; }
    }
}