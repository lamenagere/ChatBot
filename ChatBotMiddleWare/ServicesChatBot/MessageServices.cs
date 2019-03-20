using ChatBotMiddleWare.Models;
using Microsoft.Bot.Connector.DirectLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServicesChatBot
{
    public class MessageServices
    {
        private readonly string directLineSecret = "DxFVyxUZjIk.jHP0wNdNMkRohtMA3U5_jS6UBs2eRtFDK_C1HsNXlis";
        public string baseURI = "https://directline.botframework.com/v3/directline/conversations";

        //recevoir QuestionModel
        //envoyer QuestionModel au Bot
        //récupérer la réponse du Bot
        //envoyer AnswerModel au front

        //public AnswerModel Answer(QuestionModel question)
        //{
        //    DirectLineClient directLineClient = new DirectLineClient(directLineSecret);

        //    directLineClient.HttpClient.PostAsync(baseURI, )

        //}


    }
}
