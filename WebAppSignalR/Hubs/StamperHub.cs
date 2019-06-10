using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebAppSignalR.Helpers;

namespace WebAppSignalR.Hubs
{
    public class StamperHub : Hub
    {

        public string ConnectionId { get; set; }

        public StamperHub()
        {

        }

        public async Task GetUpdate()
        {
            await Clients.Caller.SendAsync("StatusUpdate", "Terminando");

        }

        public override Task OnConnectedAsync()
        {
            ConnectionId = Context.ConnectionId;
            return Task.CompletedTask;
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.SignalR;
//using WebAppSignalR.Helpers;

//namespace WebAppSignalR.Hubs
//{
//    public class StamperHub : Hub
//    {

//        private BusinessProcess _businessProcess;

//        public StamperHub(BusinessProcess businessProcess)
//        {
//            _businessProcess = businessProcess;
//        }

//        public async Task GetUpdate()
//        {
//            var responseBiz = new ResponseBiz() { NumArchivo =  1};
//            do
//            {
//                responseBiz = _businessProcess.ProcessFiles(responseBiz);

//                if (!responseBiz.Success)
//                {

//                    //await Clients.Caller.ProcessFiles(responseBiz);
//                    await Clients.Caller.SendAsync("StatusUpdate", responseBiz.Message);
//                    responseBiz.NumArchivo += 1;
//                }



//            } while (!responseBiz.Success);

//            await Clients.Caller.SendAsync("finished");

//        }
//    }
//}


