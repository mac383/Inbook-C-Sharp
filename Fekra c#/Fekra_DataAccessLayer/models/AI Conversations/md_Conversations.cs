﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.AI_Conversations
{
    public class md_Conversations
    {
        public int ConversationId { get; set; }
        public string Title { get; set; }
        public DateTime LastInteraction { get; set; }

        public md_Conversations(int conversationId, string title, DateTime lastInteraction)
        {
            ConversationId = conversationId;
            Title = title;
            LastInteraction = lastInteraction;
        }
    }
}
