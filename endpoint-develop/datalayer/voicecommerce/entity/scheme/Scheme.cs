using core_develop.cashflows.common;
using datalayer.voicecommerce.entity.authorisation.impl;
using datalayer.voicecommerce.model.sale;
using System;

namespace datalayer.voicecommerce.entity.scheme
{
    public interface Scheme
    {
        AuthScheme AuthScheme { get; }

        long? createStan(DateTime timestamp);
        SchemeAuthorisationResultOrResponse authoriseSale(Sale sale, string initialReferenceData);
    }
}
