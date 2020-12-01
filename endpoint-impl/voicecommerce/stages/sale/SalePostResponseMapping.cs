using core_develop.cashflows.common;
using core_develop.cashflows.core.authorisation;
using datalayer.voicecommerce.entity.authorisation.impl;
using datalayer.voicecommerce.model.sale;
using scheme_common.voicecommerce.response;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostResponseMapping : SalePostPipelineStageBase
    {
        private readonly SalePostPipelineStage _nextStage;
        private readonly ResponseMapper _responseMapper;
        public SalePostResponseMapping(SalePostPipelineStage next, ResponseMapper responseMapper) : base(next)
        {
            _responseMapper = responseMapper;
            _nextStage = new SalePostSchemeDispatch();
        }
        protected internal override void stageExecute(SalePostContext context)
        {
            SaleRepo.SaleAuthorisationResponseBuilder respBuilder;
            SchemeAuthorisationResult schemeAuthResult;

            nextStg(context);

            respBuilder = context.responseBuilder();
            schemeAuthResult = respBuilder.AuthorisationResult;

            string authCode = null;
            if (schemeAuthResult != null)
            {
                authCode = schemeAuthResult.SchemeAuthCode;
            }

            // As we maunally set this value it should only ever happen with Visa.
            if ((!string.ReferenceEquals(authCode, null)) && (authCode.Equals("REJECT")) && (respBuilder.AuthScheme == AuthScheme.VISA))
            {
                respBuilder.ResponseCode = ResponseCode.FORMAT_ERROR;
            }
            else
            {
                respBuilder.ResponseCode = _responseMapper.mapResponseCode(schemeAuthResult, respBuilder.ResponseCode, respBuilder.AuthScheme);
            }
            respBuilder.CvvResponseCode = _responseMapper.mapCvvResponseCode(schemeAuthResult, respBuilder.AuthScheme);

            respBuilder.AvsAddressResponseCode = _responseMapper.mapAvsAddressResponseCode(schemeAuthResult, respBuilder.AuthScheme);

            respBuilder.AvsPostalCodeResponseCode = _responseMapper.mappedAvsPostalResponseCodeCode(schemeAuthResult, respBuilder.AuthScheme);

            //Logger.info("Mapped response code is " + respBuilder.ResponseCode);
        }
    }
}
