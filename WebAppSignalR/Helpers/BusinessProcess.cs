using System.Diagnostics;
using System.Threading;
using WebAppSignalR.ViewModels;

namespace WebAppSignalR.Helpers
{
    public class BusinessProcess : IProcessFiles
    {
        public  ResponseBiz ProcessFiles(ResponseBiz responseBiz)
        {

            for (int i = responseBiz.NumArchivo; i < 50; i++)
            {
                Thread.Sleep(5000);

                responseBiz.Message = $"Archivo #{i}";
                responseBiz.NumArchivo = i;
                responseBiz.List.Add(responseBiz.Message);
                return responseBiz;
            }

            responseBiz.Success = true;
            responseBiz.Message = "Proceso Terminado";
            
            return responseBiz;
        }
    }
}
