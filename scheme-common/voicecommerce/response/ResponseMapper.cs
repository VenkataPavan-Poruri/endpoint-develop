using core_develop.cashflows.common;
using core_develop.cashflows.core.authorisation;
using datalayer.voicecommerce.entity.authorisation.impl;

namespace scheme_common.voicecommerce.response
{
    public interface ResponseMapper
    {
        ResponseCode mapResponseCode(SchemeAuthorisationResult result, ResponseCode responseCode, AuthScheme scheme);
        VerificationResponse mapCvvResponseCode(SchemeAuthorisationResult schemeAuthResult, AuthScheme authScheme);
        VerificationResponse mapAvsAddressResponseCode(SchemeAuthorisationResult schemeAuthResult, AuthScheme authScheme);
        VerificationResponse mappedAvsPostalResponseCodeCode(SchemeAuthorisationResult schemeAuthResult, AuthScheme authScheme);
    }
}
