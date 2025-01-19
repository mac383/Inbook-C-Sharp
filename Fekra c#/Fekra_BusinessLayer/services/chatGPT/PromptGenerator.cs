using Fekra_DataAccessLayer.models.chatGPT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services.chatGPT
{
    public class PromptGenerator
    {
        private string _userFullName { get; set; }
        private string _branch { get; set; }
        private string _topic { get; set; }
        private string? _rememberData { get; set; }
        private string? _summary { get; set; }

        public PromptGenerator(string userFullName, string branch, string topic, string? rememberData, string? summary)
        {
            _userFullName = userFullName;
            _branch = branch;
            _topic = topic;
            _rememberData = rememberData;
            _summary = summary;
        }

        public string GeneratePrompt()
        {
            string topicMessage = _topic == "غير ذلك"
                ? ""
                : $"الطالب يسأل عن مادة {_topic} في الصف {_branch}. احرص أن تكون إجاباتك ضمن المناهج العراقية لهذا الصف والمادة حصراً.";

            string prompt = $@"
أنتِ الآن في دور شخصية 'ظفر'، معلمة ذكية موجهة لطلبة العراق في منصة inBook (الصفوف الثالث المتوسط، الرابع، الخامس، والسادس الإعدادي). مهمتك هي مساعدة الطلاب في دراستهم باستخدام أسلوب سهل، ممتع، وباللهجة العراقية.

الطالب {_userFullName} يسأل الآن. يجب عليك الإجابة على الأسئلة باللغة العربية وباللهجة العراقية فقط. احرصي على أن تكون الإجابات واضحة، مشوقة، وسهلة الفهم. تأكدي أن جميع الإجابات تكون مستندة إلى المناهج العراقية فقط، مع أمثلة توضح الفكرة.

كوني مرنة ومحترفة في شرحك، وقدمي المعلومات بشكل تدريجي وبأسلوب يناسب الطلاب. إذا احتاج الطالب لتوضيح إضافي، كوني مستعدة لتعزيز الإجابة بأمثلة واقعية مرتبطة بحياتهم اليومية. ابتعدي عن أي إجابة غير دقيقة أو خارج المنهج العراقي.

تذكري دائمًا أن مهمتك هي مساعدة الطلاب، وكلما كانت الإجابة واضحة وبسيطة، كلما زادت فرصهم في النجاح.

{topicMessage}";

            // إضافة ملخص المحادثة إذا كان موجودًا
            if (!string.IsNullOrEmpty(_summary))
            {
                prompt += $"\nملخص المحادثة السابقة: {_summary}";
            }

            // إضافة معلومات إضافية إذا كانت موجودة
            if (!string.IsNullOrEmpty(_rememberData))
            {
                prompt += $"\nمعلومات إضافية للتذكر: {_rememberData}";
            }

            return prompt;
        }
    }
}
