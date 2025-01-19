using Fekra_DataAccessLayer.models.chatGPT;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Azure.Core;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Errors;

namespace Fekra_BusinessLayer.services.chatGPT
{
    public class GptService
    {
        private readonly md_ChatGptConfig _gptConfig;
        private readonly HttpClient _httpClient;

        public GptService(md_ChatGptConfig gptConfig, IHttpClientFactory httpClientFactory)
        {
            _gptConfig = gptConfig;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<string> GenerateSummaryAsync(string previousSummary, string studentQuestion, string dhaferResponse)
        {
            try
            {
                if (string.IsNullOrEmpty(studentQuestion) || string.IsNullOrEmpty(dhaferResponse))
                    return previousSummary;

                string updatedSummary = $"الملخص القديم: {(string.IsNullOrEmpty(previousSummary) ? "لا يوجد ملخص حالياً" : previousSummary)}\n" +
                                        $"الطلب: {studentQuestion}\n" +
                                        $"الإجابة على الطلب: {dhaferResponse}\n" +
                                        "------------------------------\n" +
                                        "مرحبًا، أحتاج إلى توليد ملخص جديد استنادًا إلى المعلومات التالية. الهدف من هذا الملخص هو الحفاظ على سياق المحادثة وتوفير مرجع لاستخدامه في الطلبات المستقبلية. " +
                                        "الملخص الجديد يجب أن يتضمن:\n" +
                                        "1. تلخيص الطلب المقدم والإجابة عليه، مع التركيز على الأفكار الرئيسية.\n" +
                                        "2. دمج هذا التلخيص مع الملخص القديم (إن وجد) بطريقة تسهم في توفير مرجع واضح ومبسط.\n" +
                                        "3. الحفاظ على المعلومات المهمة وتجنب التكرار أو الحشو.\n" +
                                        "يجب أن يكون الملخص واضحًا، دقيقًا، وموجزًا ولا يتجاوز 1000 كلمة.";


                var messages = new List<object>
                {
                    new { role = "system", content = "أنتِ الآن في دور شخصية 'ظفر'، معلمة ذكية تقوم بتلخيص الطلبات مع إجاباتها ودمجها مع الملخص القديم (إن وجد) بطريقة تحافظ على سياق المحادثة. مهمتك هي تقديم ملخصات دقيقة وموجزة لضمان توافر مرجع سهل للطالب." },
                    new { role = "user", content = updatedSummary }
                };

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages,
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
                    request.Headers.Add("OpenAI-Organization", _gptConfig.OrganizationId);

                if (!string.IsNullOrEmpty(_gptConfig.ProjectId))
                    request.Headers.Add("OpenAI-Project", _gptConfig.ProjectId);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    return jsonResponse?.choices?[0]?.message?.content?.ToString() ?? previousSummary;
                }
                else return previousSummary;
            }
            catch
            {
                return previousSummary;
            }
        }

        public async Task<string> GetResponseFromGptAsync(md_ChatGptRequest userRequest, string summary)
        {
            if (string.IsNullOrWhiteSpace(userRequest.UserInput))
                return string.Empty;

            try
            {
                string systemMessage = new PromptGenerator(
                    userRequest.UserFullName,
                    userRequest.Branch,
                    userRequest.Topic,
                    userRequest.MemoryData,
                    summary
                ).GeneratePrompt();

                var messages = BuildMessages(systemMessage, userRequest);

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages,
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

                AddOptionalHeaders(request);

                var response = await _httpClient.SendAsync(request);

                return await HandleResponseAsync(response);
            }
            catch (Exception ex)
            {
                await LogErrorAsync(ex, userRequest);
                return string.Empty;
            }
        }

        private List<object> BuildMessages(string systemMessage, md_ChatGptRequest userRequest)
        {
            var messages = new List<object>
            {
                new { role = "system", content = systemMessage }
            };

            if (userRequest.PreviousConversations?.Any() == true)
            {
                var chatHistory = userRequest.PreviousConversations
                    .TakeLast(5)
                    .Select(pc => (pc.Request, pc.Response));

                foreach (var (question, answer) in chatHistory)
                {
                    messages.Add(new { role = "user", content = question });
                    messages.Add(new { role = "assistant", content = answer });
                }
            }

            messages.Add(new { role = "user", content = userRequest.UserInput });
            return messages;
        }

        private void AddOptionalHeaders(HttpRequestMessage request)
        {
            if (!string.IsNullOrEmpty(_gptConfig.OrganizationId))
                request.Headers.Add("OpenAI-Organization", _gptConfig.OrganizationId);

            if (!string.IsNullOrEmpty(_gptConfig.ProjectId))
                request.Headers.Add("OpenAI-Project", _gptConfig.ProjectId);
        }

        private async Task<string> HandleResponseAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseBody);
                return jsonResponse?.choices?[0]?.message?.content?.ToString() ?? string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }

        private async Task LogErrorAsync(Exception ex, md_ChatGptRequest userRequest)
        {
            string Params = cls_Errors_D.GetParams
            (
                () => userRequest.ConversationId,
                () => userRequest.UserInput,
                () => userRequest.UserFullName,
                () => userRequest.MemoryData,
                () => userRequest.Topic,
                () => userRequest.Branch
            );

            await cls_Errors_D.LogErrorAsync(new md_NewError
            (
                ex.Message,
                "Business Layer",
                ex.Source ?? "null",
                "GptService",
                "GetResponseFromGptAsync",
                ex.StackTrace ?? "null",
                null,
                Params
            ));
        }
    }
}
