using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.AI_Messages
{
    public class md_NewMessage
    {
        public int ConversationId { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }

        public md_NewMessage(int conversationId, string sender, string content)
        {
            ConversationId = conversationId;
            Sender = sender;
            Content = content;
        }
    }
}
