using Fekra_DataAccessLayer.models.chatGPT;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fekra_BusinessLayer.services.chatGPT
{
    public class GptService
    {
        private readonly md_ChatGptConfig _gptConfig;
        private readonly HttpClient _httpClient;

        string _dhaferInitInfo = "أنت الآن في دور معلمة ذكية موجهة للطلاب في منصة inBook. يجب عليك الإجابة على جميع الأسئلة باللغة العربية وباللهجة العراقية فقط. احرصي على أن تكون إجاباتك واضحة، مشوقة، وسهلة الفهم. إذا كان هناك أي استفسار، قدمي الإجابة بطريقة مرحة ومحفزة، ولكن حافظي على الجدية والمصداقية في المعلومات. تذكري أن هدفك هو مساعدة الطلاب في مسيرتهم الدراسية الأكاديمية. كما يجب عليك أن تتجنب الإجابات الغير ذات صلة أو أي تعبير قد يسبب لبس. التزمي بالإجابات التي تركز على الموضوع ولا تخرجي عن سياق السؤال.";
        string rememberData = "اسمي مرتضئ, مبرمج فول ستاك, اعمل علئ تطوير منصة inbook لطلبة العراق للصفوف الثالث المتوسط, الرابع, الخامس, السادس الاعدادي";

        public GptService(md_ChatGptConfig gptConfig, IHttpClientFactory httpClientFactory)
        {
            _gptConfig = gptConfig;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<string?> GetResponseFromGptAsync(string userInput)
        {
            try
            {

                var chatHistory = new List<(string Question, string Answer)>
                {
                    ("كيف الحال", "انا بخير شكرا لك"),
                    ("ما هي البرمجة", "البرمجة عبارة عن تعليمات تكتب لبناء تطبيقات او انظمة...")
                };

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    throw new ArgumentException("المدخلات غير صالحة");
                }

                // دمج rememberData مع _dhaferInitInfo
                string fullSystemMessage = $"{_dhaferInitInfo}\nمعلومات إضافية للتذكر: {rememberData}";

                // بناء قائمة الرسائل
                var messages = new List<object>
                {
                    new { role = "system", content = fullSystemMessage }
                };

                // إضافة تاريخ المحادثة
                foreach (var (question, answer) in chatHistory)
                {
                    messages.Add(new { role = "user", content = question });
                    messages.Add(new { role = "assistant", content = answer });
                }

                // إضافة السؤال الحالي
                messages.Add(new { role = "user", content = userInput });

                // بناء الطلب
                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = messages,
                    temperature = 0.7
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions")
                {
                    Headers =
                    {
                        { "Authorization", $"Bearer {_gptConfig.Key}" }
                    },
                    Content = content
                };

                if (!string.IsNullOrEmpty(_gptConfig.OrganizationId))
                {
                    request.Headers.Add("OpenAI-Organization", _gptConfig.OrganizationId);
                }

                if (!string.IsNullOrEmpty(_gptConfig.ProjectId))
                {
                    request.Headers.Add("OpenAI-Project", _gptConfig.ProjectId);
                }

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    var messageContent = jsonResponse?.choices?[0]?.message?.content?.ToString();

                    if (!string.IsNullOrEmpty(messageContent))
                    {
                        return messageContent;
                    }
                    else
                    {
                        throw new Exception("لم يتمكن النظام من استخراج الإجابة.");
                    }
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    throw new Exception($"حدث خطأ أثناء الاتصال بـ GPT: {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"حدث خطأ أثناء معالجة الطلب: {ex.Message}");
            }
        }



        public async Task<string?> GenerateSummaryAsync(string previousSummary, string studentQuestion, string dhaferResponse)
        {
            try
            {
                // التأكد من أن المدخلات غير فارغة
                if (string.IsNullOrWhiteSpace(studentQuestion) || string.IsNullOrWhiteSpace(dhaferResponse))
                {
                    throw new ArgumentException("المدخلات غير صالحة");
                }

                // دمج الملخص السابق مع السؤال الجديد وإجابة "ظفر"
                string updatedSummary = $"الملخص القديم: {(string.IsNullOrEmpty(previousSummary) ? "لا يوجد ملخص" : previousSummary)}\n" +
                        $"الطلب: {studentQuestion}\n" +
                        $"الإجابة على الطلب: {dhaferResponse}\n" +
                        "------------------------------\n" +
                        "مرحبًا، أحتاج إلى توليد ملخص جديد استنادًا إلى المعلومات التالية. الغرض من هذا الملخص هو الحفاظ على سياق المحادثة وتوفير مرجع لاستخدامه في الطلبات المستقبلية. " +
                        "الملخص الجديد يجب أن يتضمن:\n" +
                        "1. تلخيص الطلب المقدم والإجابة عليه.\n" +
                        "2. دمج هذا التلخيص مع الملخص القديم (إن وجد).\n" +
                        "3. الحفاظ على المعلومات المهمة وتجنب التكرار.\n" +
                        "يجب أن يكون الملخص واضحًا وموجزًا ولا يتجاوز 1000 كلمة.";

                var messages = new List<object>
                {
                    new { role = "system", content = _dhaferInitInfo },
                    new { role = "user", content = updatedSummary }
                };

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = messages,
                    temperature = 0
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions")
                {
                    Headers =
                    {
                        { "Authorization", $"Bearer {_gptConfig.Key}" }
                    },
                    Content = content
                };

                if (!string.IsNullOrEmpty(_gptConfig.OrganizationId))
                {
                    request.Headers.Add("OpenAI-Organization", _gptConfig.OrganizationId);
                }

                if (!string.IsNullOrEmpty(_gptConfig.ProjectId))
                {
                    request.Headers.Add("OpenAI-Project", _gptConfig.ProjectId);
                }

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    var messageContent = jsonResponse?.choices?[0]?.message?.content?.ToString();

                    if (!string.IsNullOrEmpty(messageContent))
                    {
                        return messageContent;
                    }
                    else
                    {
                        throw new Exception("لم يتمكن النظام من استخراج الإجابة.");
                    }
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    throw new Exception($"حدث خطأ أثناء الاتصال بـ GPT: {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"حدث خطأ أثناء معالجة الطلب: {ex.Message}");
            }
        }

    }
}
