using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
   public  class ErrorCodeBase
    {
        public HttpStatusCode StatusCode { get; set; }
        public ErrorResult errorResult { get; set; }
    }
}
