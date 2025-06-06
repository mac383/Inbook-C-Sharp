﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.chatGPT
{
    public class md_ChatGptRequest
    {
        public int ConversationId { get; set; }
        public string UserInput { get; set; }
        public string UserFullName { get; set; }
        public string MemoryData { get; set; }
        public string Topic { get; set; }
        public string Branch { get; set; }
        public bool IsFreeSubscription { get; set; }
        public List<PreviousConversation> PreviousConversations { get; set; }

        public md_ChatGptRequest(int conversationId, string userInput, string userFullName, string memoryData, string topic, string branch, bool isFreeSubscription, List<PreviousConversation> previousConversations)
        {
            ConversationId = conversationId;
            UserInput = userInput;
            UserFullName = userFullName;
            MemoryData = memoryData;
            Topic = topic;
            Branch = branch;
            IsFreeSubscription = isFreeSubscription;
            PreviousConversations = previousConversations ?? new List<PreviousConversation>();
        }
    }

    public class PreviousConversation
    {
        public string Request { get; set; }
        public string Response { get; set; }

        public PreviousConversation(string request, string response)
        {
            Request = request;
            Response = response;
        }
    }

}