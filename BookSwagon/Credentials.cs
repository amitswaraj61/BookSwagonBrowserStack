using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSwagon
{
    class Credentials
    {
        public string email = "";
        public string password = "";
        public string json = "";
        public string sendPassword = "";
        public string recEmail = "";

        public Credentials()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\Kis\\source\\repos\\BookSwagon\\BookSwagon\\Amitswaraj.json"))
            {
                json = r.ReadToEnd();
            }

            dynamic array = JsonConvert.DeserializeObject(json);
            Console.WriteLine("Array::::" + array["email"]);
            email = array["email"];
            password = array["password"];
            sendPassword = array["sender-password"];
            recEmail = array["receiver-email"];
        }
    }
}
