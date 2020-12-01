using core_develop.cashflows.common;
using core_develop.cashflows.core.authorisation;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class PipelineArnGeneratorStageUtility
    {
        public virtual string generateARN(ResponseCode responseCode, string bid, AuthScheme scheme, DateTime timestamp, params core_develop.cashflows.core.authorisation.Action[] successActions)
        {
            throw new NotImplementedException();
        }

    }
}