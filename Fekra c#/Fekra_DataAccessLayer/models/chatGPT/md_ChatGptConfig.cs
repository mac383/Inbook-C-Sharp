using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.chatGPT
{
    public class md_ChatGptConfig
    {
        public string OrganizationId { get; set; }
        public string ProjectId { get; set; }
        public string Key { get; set; }

        public md_ChatGptConfig () { }
        public md_ChatGptConfig(string organizationId, string projectId, string key)
        {
            OrganizationId = organizationId;
            ProjectId = projectId;
            Key = key;
        }
    }
}
