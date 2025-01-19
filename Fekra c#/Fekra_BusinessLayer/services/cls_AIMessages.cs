using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.AI_Messages;
using Fekra_DataAccessLayer.models.Branches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_AIMessages
    {
        public static bool ValidateObj_NewMode(md_NewMessage message)
        {
            if (message.ConversationId <= 0)
                return false;

            if (message.Request.Length <= 0)
                return false;

            if (message.Response.Length <= 0)
                return false;

            if (message.Summary.Length <= 0)
                return false;

            return true;
        }

        public static async Task<bool> HandleMessageAsync(md_NewMessage newMessage)
        {
            if (!ValidateObj_NewMode(newMessage))
                return false;

            return await cls_AIMessages_D.HandleMessageAsync(newMessage);
        }

        public static async Task<List<md_Messages>?> GetMessagesByConversationAsync(int conversationId)
        {
            return await cls_AIMessages_D.GetMessagesByConversationAsync(conversationId);
        }
    }
}