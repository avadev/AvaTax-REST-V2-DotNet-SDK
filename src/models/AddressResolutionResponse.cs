using Avalara.AvaTax.RestClient;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Avalara.AvaTax.RestClient
{
    [Guid("d28daf72-8c6a-4b2d-981a-1990a1166ee8")]
    [ComVisible(true)]
    public class AddressResolutionResponse
    {
        public AddressResolutionResponse()
        {
            addressResolutionModel = new AddressResolutionModel();
        }

        public AddressResolutionModel addressResolutionModel;


        private string _statusCode="200";
        [DispId(1)]
        public string StatusCode
        {
            get
            {
                return this._statusCode;
            }
            set
            {
                this._statusCode = value;

            }
        }

        private string _message;
        [DispId(2)]
        public string Message
        {
            get
            {
                return this._message;
            }
            set
            {
                this._message = value;

            }
        }
    }
}
