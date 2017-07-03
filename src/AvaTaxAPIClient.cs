using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Avalara.AvaTax.RestClient;
using System.Text;

namespace Avalara.AvaTax.RestClient.net20
{
    [Guid("68fee11c-9b36-4e8a-a597-f69098f09f90")]
    [ComVisible(true)]
    public class AvaTaxAPIClient
    {
        private string _userName;
        private string _password;
        private string _url;

        [DispId(1)]
        public string URL
        {
            get
            {
                return this._url;
            }
            set
            {
                this._url = value;

            }
        }
        [DispId(2)]
        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                this._userName = value;

            }
        }
        [DispId(3)]
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;

            }
        }

        public AddressResolutionResponse ResolveAddress(AddressInfo request)
        {            
            AddressResolutionModel addressResolutionModel = new AddressResolutionModel();
            addressResolutionModel.address = new AddressInfo();

            addressResolutionModel.address.city = request.city;
            addressResolutionModel.address.country = request.country;
            addressResolutionModel.address.latitude = request.latitude;
            addressResolutionModel.address.longitude = request.longitude;
            addressResolutionModel.address.postalCode = request.postalCode;
            addressResolutionModel.address.region = request.region;
            addressResolutionModel.address.line1 = request.line1;
            addressResolutionModel.address.line2 = request.line2;
            addressResolutionModel.address.line3 = request.line3;
            //addressResolutionModel.address.TextCase = request.TextCase;

            AddressResolutionResponse addressResolutionResponse = new AddressResolutionResponse();
            addressResolutionResponse.StatusCode = "Success";
            try
            {
                using (var svcClient = new RESTClientJSON(CreateAuthHeader()))
                {
                    addressResolutionResponse.addressResolutionModel = svcClient.RestPost<AddressResolutionModel, AddressInfo>(URL + "/api/v2/addresses/resolve", request);
                }

            }
            catch (Exception ex)
            {
                addressResolutionResponse.Message = ex.Message;
                addressResolutionResponse.StatusCode = "Error";               
            }

            return addressResolutionResponse;
        }

        private Dictionary<string, string> CreateAuthHeader()
        {
            var auth = new Dictionary<string, string>();
            auth.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", _userName, _password))));
            return auth;
        }
    }
}
