using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppSignalR.Helpers
{
    public class ResponseBiz
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public int NumArchivo { get; set; }

        public List<string> List { get; set; } = new List<string>();
    }
}
