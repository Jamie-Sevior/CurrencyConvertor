using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Currency_Converter.Models
{
    public class APICaller
    {

        public static  APIReturn CallApi()
        {
            APIReturn apiReturn = new APIReturn();
            string APICallStart = "https://v6.exchangerate-api.com/v6/";
            string APICallEnd = "/latest/USD";
            string APIKey = "ba735e7264e7ee889ff5e054";
            string APICall = APICallStart + APIKey + APICallEnd;

            using (var client = new HttpClient())
            {


                var response = client.GetAsync(APICall).Result;
                if (response.IsSuccessStatusCode)
                {

                    var JSONResponse = response.Content.ReadAsStringAsync();
                    string JSONResponsestring = JSONResponse.Result.ToString();
                    apiReturn = JsonConvert.DeserializeObject<APIReturn>(JSONResponsestring);
                }
                else
                {
                    apiReturn.base_code = "error";
                }
            }
            return apiReturn;
        }

        
    }
}
