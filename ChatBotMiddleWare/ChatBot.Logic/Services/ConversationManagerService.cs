using Microsoft.Bot.Connector.DirectLine;
using System.Linq;
using ChatBot.Logic.Models;
using ChatBot.Logic.Helpers;

namespace ChatBot.Logic.Services
{
    public class ConversationManagerService
    {
        private readonly string directLineSecret = "DxFVyxUZjIk.jHP0wNdNMkRohtMA3U5_jS6UBs2eRtFDK_C1HsNXlis";

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