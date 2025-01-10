using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.firebase
{
    public class md_FirebaseConfig
    {
        public string ApiKey { get; set; }
        public string AuthDomain { get; set; }
        public string ProjectId { get; set; }
        public string StorageBucket { get; set; }
        public string MessagingSenderId { get; set; }
        public string AppId { get; set; }
        public string MeasurementId { get; set; }

        public md_FirebaseConfig() { }

        public md_FirebaseConfig
            (
                string apiKey, string authDomain, string projectId, string storageBucket,
                string messagingSenderId, string appId, string measurementId
            )
        {
            ApiKey = apiKey;
            AuthDomain = authDomain;
            ProjectId = projectId;
            StorageBucket = storageBucket;
            MessagingSenderId = messagingSenderId;
            AppId = appId;
            MeasurementId = measurementId;
        }
    }

}
