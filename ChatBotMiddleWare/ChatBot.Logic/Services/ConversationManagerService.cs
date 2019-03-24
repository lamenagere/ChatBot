using Microsoft.Bot.Connector.DirectLine;
using System.Linq;
using ChatBot.Logic.Models;
using ChatBot.Logic.Helpers;
using ChatBot.Dal;
using ChatBot.Dal.Entities;

namespace ChatBot.Logic.Services
{
    public class ConversationManagerService
    {
        private readonly string directLineSecret = "DxFVyxUZjIk.jHP0wNdNMkRohtMA3U5_jS6UBs2eRtFDK_C1HsNXlis";
        private ChatBotUnitOfWork _unitOfWork = new ChatBotUnitOfWork();


        public ConversationManagerService()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DirectLineClient CreateNewDirectLineClient()
        {
            var directLineClient = new DirectLineClient(directLineSecret);
            var newConversation = directLineClient.Conversations.StartConversation();
            ConversationMemoryCache.Add(newConversation.ConversationId, directLineClient);
            return directLineClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string StartNewConversation()
        {
            var directLineClient = new DirectLineClient(directLineSecret);
            var newConversation = directLineClient.Conversations.StartConversation();

            _unitOfWork.ConversationRepository.Add(new Dal.Entities.Conversation()
            {
                ConversationId = newConversation.ConversationId,
                Activities = null
            });
            _unitOfWork.Save();

            ConversationMemoryCache.Add(newConversation.ConversationId, directLineClient);
            return newConversation.ConversationId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conversationId"></param>
        /// <returns></returns>
        private DirectLineClient GetClient(string conversationId)
        {
            var client = ConversationMemoryCache.Get(conversationId);
            if (client == null)
            {
                client = CreateNewDirectLineClient();
            }
            return client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public AnswerModel GetMessage(QuestionModel question)
        {
            // récupère le DirectLineClient en mémoire par défaut
            // TODO: le récupérer en base si null
            var client = GetClient(question.conversationId);

            // Récupère l'utilisateur en base
            var user = _unitOfWork.UserRepository.GetByID(int.Parse(question.userId));

            // Créé le message à envoyer au Bot pour obtenir une réponse
            Microsoft.Bot.Connector.DirectLine.Activity userMessage = new Microsoft.Bot.Connector.DirectLine.Activity
            {
                From = new ChannelAccount(question.userId),
                Text = question.text,
                Type = ActivityTypes.Message
            };

            // envoie le message au Bot
            client.Conversations.PostActivity(question.conversationId, userMessage);

            // Récupère le message posté par l'utilisateur
            var msg = client.Conversations.GetActivities(question.conversationId).Activities.Last(act => act.From.Id == user.Id.ToString());

            // Récupère la réponse du Bot
            var response = client.Conversations.GetActivities(question.conversationId).Activities.Last();

            // Ajoute au contexte le message de l'utilisateur
            _unitOfWork.ActivityRepository.Add(new Dal.Entities.Activity()
            {
                Id = msg.Id,
                Text = msg.Text,
                User = user,
                Type = ActivityTypes.Message,
                ChannelId = msg.ChannelId,
                InputHint = msg.InputHint,
                ReplyToId = msg.ReplyToId,
                Timestamp = msg.Timestamp ?? System.DateTime.Now
            });
            // Ajoute au contexte la réponse
            _unitOfWork.ActivityRepository.Add(new Dal.Entities.Activity()
            {
                Id = response.Id,
                Text = response.Text,
                User = user,
                Type = ActivityTypes.Message,
                ChannelId = response.ChannelId,
                InputHint = response.InputHint,
                ReplyToId = response.ReplyToId,
                Timestamp = response.Timestamp ?? System.DateTime.Now
            });
            _unitOfWork.Save();

            var answer = new AnswerModel
            {
                conversationId = response.Conversation.Id,
                text = response.Text
            };
            return answer;
        }
    }
}