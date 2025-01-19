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
        public string Request { get; set; }
        public string Response { get; set; }
        public string Summary { get; set; }

        public md_NewMessage(int conversationId, string request, string response, string summary)
        {
            ConversationId = conversationId;
            Request = request;
            Response = response;
            Summary = summary;
        }
    }
}
