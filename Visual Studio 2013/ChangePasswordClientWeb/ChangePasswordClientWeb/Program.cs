using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChangePasswordClientWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var wb = new WebClient())
            {
                string url = "http://54.84.219.185/~carvajal/ChangePassword/controllers/WsController.php";
                var data = new NameValueCollection();

                data["domain"] = "aisfood.com";
                data["password"] = "aisfood#.$%203427166";

                var response = wb.UploadValues(url, "POST", data);

                var responseString = Encoding.UTF8.GetString(response);
            }
        }
    }
}
