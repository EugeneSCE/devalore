using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;

namespace DevaloreC_Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private HttpClient httpConector() {
            string Baseurl = "https://randomuser.me/";
            var objClient = new HttpClient();
            objClient.DefaultRequestHeaders.Accept.Clear();
            objClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            objClient.BaseAddress = new Uri(Baseurl);

            return objClient;
        }



        //GetUsersData
        [HttpGet(Name = "GetUsersData")]
 
        public async Task<string?> GetUsersData(string gender)
        {
                var client = httpConector();

            string query = "api/?results=10&gender=";

            if (gender == "Male" || gender == "male" || gender == "M" || gender == "m")
            {
                query = query + "male";

            }
            else if (gender == "Female" || gender == "female" || gender == "F" || gender == "f")
            {
                query = query + "female";

            }
            else {
                //return View();
                return "";
            }
            

            HttpResponseMessage Res = await client.GetAsync(query);


            if (Res.IsSuccessStatusCode)
            {
                var userResponse = Res.Content.ReadAsStringAsync().Result;
                


                var temp = JsonConvert.DeserializeObject(userResponse);
                


                return temp.ToString();
            }
 
            return "";
        }



        [HttpGet(Name = "GetMostPupalarCountry")]
        public async Task<string?> GetMostPupalarCountry()
        {
        //https://randomuser.me/api/?inc=location&results=5000
            var client = httpConector();
            string query = "/api/?inc=location&results=5000";
            HttpResponseMessage Res = await client.GetAsync(query);
            if (Res.IsSuccessStatusCode)
            {
                var userResponse = Res.Content.ReadAsStringAsync().Result;
                var temp = JsonConvert.DeserializeObject(userResponse);
                return "";
            }
            return "";
        }

        [HttpGet(Name = "GetListOfMails")]
        public async Task<string?> GetListOfMails()
        {
            var client = httpConector();
            string query = "api/?results=10&gender=";
            HttpResponseMessage Res = await client.GetAsync(query);
            if (Res.IsSuccessStatusCode)
            {
                var userResponse = Res.Content.ReadAsStringAsync().Result;
                var temp = JsonConvert.DeserializeObject(userResponse);
                return "";
            }
            return "";
        }

        [HttpGet(Name = "GetTheOldestUser")]
        public async Task<string?> GetTheOldestUser()
        {
            var client = httpConector();
            string query = "api/?results=10&gender=";
            HttpResponseMessage Res = await client.GetAsync(query);
            if (Res.IsSuccessStatusCode)
            {
                var userResponse = Res.Content.ReadAsStringAsync().Result;
                var temp = JsonConvert.DeserializeObject(userResponse);
                return "";
            }
            return "";
        }



    }
}
