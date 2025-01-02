using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.AI_Conversations;
using Fekra_DataAccessLayer.models.AIUserMemory;
using Fekra_DataAccessLayer.models.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_AIConversations
    {
        public static bool ValidateObj_UpdateMode(int conversationId, string title)
        {
            if (conversationId <= 0)
                return false;

            return Validation.CheckLength(1, 255, title);
        }

        public static async Task<int> AddNewConversationAsync(int userId)
        {
            return await cls_AIConversations_D.AddNewConversationAsync(userId);
        }

        public static async Task<bool> UpdateConversationTitleAsync(int conversationId, string newTitle)
        {
            return ValidateObj_UpdateMode(conversationId, newTitle) ? await cls_AIConversations_D.UpdateConversationTitleAsync(conversationId, newTitle) : false;
        }

        public static async Task<List<md_Conversations>?> GetAllConversationsAsync(int userId)
        {
            return await cls_AIConversations_D.GetAllConversationsAsync(userId);
        }

        public static async Task<bool> DeleteConversationAsync(int conversationId)
        {
            return await cls_AIConversations_D.DeleteConversationAsync(conversationId);
        }

        public static async Task<string> GetConversationSummaryAsync(int conversationId)
        {
            return await cls_AIConversations_D.GetConversationSummaryAsync(conversationId);
        }
    }
}
