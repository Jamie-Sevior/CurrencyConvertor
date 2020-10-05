using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Currency_Converter.Models;

namespace Currency_Converter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Submit(string GCurAmnt, string GCurType, string WCurType)
        {
            GivenMoney UserQuery = new GivenMoney();
            UserQuery.Value = Convert.ToDouble(GCurAmnt);
            UserQuery.currency.Type = GCurType;
            UserQuery.wanted_currency.Type = WCurType;
            return APICall(UserQuery);
        }

        public IActionResult APICall(GivenMoney userQuery)
        {
            APIReturn ExchangeInfo = APICaller.CallApi();
            ConvertedMoney convertedMoney = new ConvertedMoney(userQuery, ExchangeInfo);
            return AnswerPage(convertedMoney);
        }

       
        public IActionResult AnswerPage(ConvertedMoney money)
        {
            return View(money);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
