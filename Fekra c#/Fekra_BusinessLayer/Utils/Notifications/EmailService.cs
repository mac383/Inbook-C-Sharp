﻿using Amazon;
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

        /*
            EmailService: هذه الخدمة مسؤولة عن إرسال رسائل التحقق عبر AWS SES.
            حالياً، هذه الخدمة غير مستخدمة.
        */

        private readonly string _sourceEmail = "";
        private readonly RegionEndpoint _awsRegion = RegionEndpoint.EUNorth1;
        private readonly string _accessKey = "";
        private readonly string _secretKey = "";

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
