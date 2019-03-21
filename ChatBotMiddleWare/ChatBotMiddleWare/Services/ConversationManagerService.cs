using ChatBotMiddleWare.Helpers;
using ChatBotMiddleWare.Models;
using DAL.Context;
using Microsoft.Bot.Connector.DirectLine;
using System.Linq;

namespace ChatBotMiddleWare.Services
{
    public class ConversationManagerService
    {
        private readonly string directLineSecret = "DxFVyxUZjIk.jHP0wNdNMkRohtMA3U5_jS6UBs2eRtFDK_C1HsNXlis";
        private ChatBotContext _context;

        public ConversationManagerService()
        {
            _context = new ChatBotContext();
        }


        private DirectLineClient CreateNewDirectLineClient()
        {
            var directLineClient = new DirectLineClient(directLineSecret);
            var newConversation = directLineClient.Conversations.StartConversation();
            
            ConversationMemoryCache.Add(newConversation.ConversationId, directLineClient);
            return directLineClient;
        }

        public string StartNewConversation()
        {
            var directLineClient = new DirectLineClient(directLineSecret);
            var newConversation = directLineClient.Conversations.StartConversation();


            // Ajoute la conversation à la base
            DAL.Entities.Conversation conversation = new DAL.Entities.Conversation()
            {
                id = newConversation.ConversationId
            };
            _context.Conversations.Add(conversation);


            ConversationMemoryCache.Add(newConversation.ConversationId, directLineClient);
            return newConversation.ConversationId;
        }

        private DirectLineClient GetClient(string conversationId)
        {
            var client = ConversationMemoryCache.Get(conversationId);
            if (client == null)
            {
                client = CreateNewDirectLineClient();
            }
            return client;
        }

        public AnswerModel GetMessage(QuestionModel question)
        {
            var client = GetClient(question.conversationId);
       
            Activity userMessage = new Activity
            {
                From = new ChannelAccount("UserName"),
                Text = question.text,
                Type = ActivityTypes.Message
            };


            // Ajoute la activity à la base
            DAL.Entities.Activity activity = new DAL.Entities.Activity()
            {
                conversationId = question.conversationId,
                 text = question.text,
                 type = ActivityTypes.Message
            };
            _context.Activities.Add(activity);



            client.Conversations.PostActivity(question.conversationId, userMessage);
            var msg = client.Conversations.GetActivities(question.conversationId).Activities.Last();

            var answer = new AnswerModel
            {
                conversationId = msg.Conversation.Id,
                text = msg.Text
            };
            return answer;
        }
    }
}