using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Users
{
    public class md_setImage
    {
        public int UserId { get; set; }
        public string ImageURL { get; set; }
        public string ImageName { get; set; }

        public md_setImage(int userId, string imageURL, string imageName)
        {
            UserId = userId;
            ImageURL = imageURL;
            ImageName = imageName;
        }
    }
}
