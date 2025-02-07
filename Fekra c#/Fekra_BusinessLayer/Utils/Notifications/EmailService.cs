using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using System;
using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.Utils.Notifications
{
    public class EmailService : INotification
    {
        private readonly string _sourceEmail = "info@inbook.tech";
        private readonly RegionEndpoint _awsRegion = RegionEndpoint.EUNorth1;
        private readonly string _accessKey = "AKIA2MNVMGKABDHMQCYC";
        private readonly string _secretKey = "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";

        // first access key: AKIA2MNVMGKAFWMXYKPP
        // first secret key: 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
        // regin for s3    "region": "us-east-1"
        public async Task<string?> SendEmailVerification(string to, string messageHeader, string messageBody, string verificationKey)
        {
            try
            {
                var clientConfig = new AmazonSimpleEmailServiceConfig
                {
                    RegionEndpoint = _awsRegion
                };

                var client = new AmazonSimpleEmailServiceClient(_accessKey, _secretKey, clientConfig);

                var sendRequest = new SendEmailRequest
                {
                    Source = _sourceEmail,
                    Destination = new Destination { ToAddresses = new List<string> { to } },
                    Message = new Message
                    {
                        Subject = new Content(messageHeader),
                        Body = new Body
                        {
                            Html = new Content { Data = messageBody }
                        }
                    }
                };

                var response = await client.SendEmailAsync(sendRequest);

                return response.HttpStatusCode == System.Net.HttpStatusCode.OK ? verificationKey : null;
            }
            catch
            {
                return null;
            }
        }

    }
}
