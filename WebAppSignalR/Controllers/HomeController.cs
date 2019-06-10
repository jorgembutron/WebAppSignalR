using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using WebAppSignalR.Helpers;
using WebAppSignalR.Hubs;

namespace WebAppSignalR.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        
        private IHubContext<StamperHub> _stamperHub;
        private IProcessFiles _processFiles;

        public HomeController(IHubContext<StamperHub> stamperHub, IProcessFiles processFiles)
        { 
            _stamperHub = stamperHub;
            _processFiles = processFiles;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Privacy()
        {

            var responseBiz = new ResponseBiz() { NumArchivo = 1 };
            do
            {
                responseBiz = _processFiles.ProcessFiles(responseBiz);

                if (!responseBiz.Success)
                {
                    await _stamperHub.Clients.All.SendAsync("StatusUpdate", responseBiz.Message);
                    responseBiz.NumArchivo += 1;
                }



            } while (!responseBiz.Success);



            return Ok(responseBiz.List);

            //return View();
        }

    }
}


//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.SignalR;
//using WebAppSignalR.Hubs;
//using WebAppSignalR.Models;
//using WebAppSignalR.ViewModels;

//namespace WebAppSignalR.Controllers
//{
//    [Route("Home")]
//    public class HomeController : Controller
//    {
//        private IHubContext<StamperHub> _stamperHub;

//        public HomeController(IHubContext<StamperHub> stamperHub)
//        {
//            _stamperHub = stamperHub;
//        }
//        public IActionResult Index()
//        {

//            return View();
//        }

//       [HttpPost]
//        public async Task<IActionResult> Privacy()
//        {
//            //var model = new TimeStamper();
//            //var sw = new Stopwatch();
//            //sw.Start();

//            //Thread.Sleep(250000);

//            //model.ElapsedTime = sw.Elapsed.Seconds;

//            //sw.Stop();

//            await _stamperHub.Clients.All.SendAsync("UploadFiles");



//            return View();
//        }

//    }
//}
