using core_develop.cashflows.core.authorisation;
using core_develop.cashflows.endpoint.service.api;
using datalayer.voicecommerce.model.sale;
using endpoint_api.voicecommerce.api;
using endpoint_models.Request;
using endpoint_service.service.xml;
using System;

namespace endpoint_service.service.handler
{
    public class EPSSalePostResponseImpl : EPSCostedSchemeAuthorisationResponseBase, SalePostResponse
    {
        private SalePostXMLRequest apiRequest;
        SalePostXMLResponse responseXML;

        public EPSSalePostResponseImpl(SalePostXMLRequest apiRequest)
        {
            this.apiRequest = apiRequest;
        }
        public APIResponse getXML()
        {
             //return populateCostedResponse(responseXML, getAuthorisationResponse());
            return null;
        }


        //public readonly SalePostXMLResponse responseXML;

        //public ResponseCode nonAuthResponseCode;

        public SaleAuthorisationResponse authResponse;

        SaleAuthorisationResponse SalePostResponse.AuthorisationResponse { get; set; }
        ResponseCode SalePostResponse.ResponseCode { get; set; }
        public SaleAuthorisationResponse getAuthorisationResponse()
        {
            return authResponse;
        }

    }
}
