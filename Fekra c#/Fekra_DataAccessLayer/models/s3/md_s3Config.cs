using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.firebase
{
    public class md_s3Config
    {
        public string AccessKeyId { get; set; }
        public string SecretAccessKey { get; set; }
        public string Region { get; set; }

        public md_s3Config() { }

        public md_s3Config (string accessKeyId, string secretAccessKey, string region)
        {
            AccessKeyId = accessKeyId;
            SecretAccessKey = secretAccessKey;
            Region = region;
        }
    }

}
