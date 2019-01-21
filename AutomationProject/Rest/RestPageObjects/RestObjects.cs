using AutomationProject.Rest.RestBaseClasses;
using RestSharp;

namespace AutomationProject.Rest.RestPageObjects
{
    // Not currently in use
    internal class RestObjects : RestBase
    {
        private readonly IRestClient _restClient;

        public RestObjects(IRestClient restClient)
        {
            _restClient = restClient;
        }

        #region PageObjects for Product



        #endregion

        #region Methods for ApiBase



        #endregion
    }
}
