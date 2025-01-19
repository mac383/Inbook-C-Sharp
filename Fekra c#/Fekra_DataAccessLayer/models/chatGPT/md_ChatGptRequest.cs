using System;
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
        public List<PreviousConversation> PreviousConversations { get; set; }

        public md_ChatGptRequest(int conversationId, string userInput, string userFullName, string memoryData, string topic, string branch, List<PreviousConversation> previousConversations)
        {
            ConversationId = conversationId;
            UserInput = userInput;
            UserFullName = userFullName;
            MemoryData = memoryData;
            Topic = topic;
            Branch = branch;
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

//const requestData = {
//      userInput: "ما هي قوانين نيوتن؟",
//      memoryData: "بيانات ذاكرة خاصة بالمستخدم",
//      previousConversations:
//[
//        { request: "ما هو تعريف القوة؟", response: "القوة هي المؤثر الخارجي الذي يسبب تغيراً في حركة الجسم." },
//        { request: "ما هو تعريف الكتلة؟", response: "الكتلة هي مقدار المادة في الجسم." }
//      ],
//      topic: "الفيزياء",
//      branch: "الصف الخامس"
//    };


//const requestData = {
//  userInput: "ما هي قوانين نيوتن؟",
//  memoryData: "بيانات ذاكرة خاصة بالمستخدم",
//  previousConversations: [], // مصفوفة فارغة لعدم وجود محادثات سابقة
//  topic: "الفيزياء",
//  branch: "الصف الخامس"
//};