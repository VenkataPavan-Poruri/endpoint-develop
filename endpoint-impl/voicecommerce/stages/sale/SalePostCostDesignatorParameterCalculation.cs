using core_develop.cashflows.core.authorisation;
using datalayer.voicecommerce.entity.authorisation.impl;
using datalayer.voicecommerce.entity.costing;
using datalayer.voicecommerce.model.sale;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostCostDesignatorParameterCalculation : SalePostPipelineStageBase
    {
        private readonly SalePostPipelineStage _nextStage;
        private readonly CostDesignatorParamCalculationStageUtility _costingUtility;
        public SalePostCostDesignatorParameterCalculation(CostDesignatorParamCalculationStageUtility costingUtility, SalePostPipelineStage next) : base(next)
        {
            _costingUtility = costingUtility;
            _nextStage = new SalePostLockMerchant(next);
        }
        protected internal override void stageExecute(SalePostContext context)
        {
            CostDesignatorParameters costDesignatorParameters = null;
            SchemeAuthorisationResult schemeAuthResult;
            SaleRepo.SaleAuthorisationResponseBuilder respBuilder;

            nextStg(context);

            respBuilder = context.responseBuilder();
            schemeAuthResult = respBuilder.AuthorisationResult;
            //Check the scheme response(if an exception is thrown, let it ripple through
            //if ((schemeAuthResult == null) || (respBuilder.ResponseCode.Action != core_develop.cashflows.core.authorisation.Action.APPROVE))
            if ((schemeAuthResult == null))
            {
                //Logger.debug("Auth request not approved, or no scheme response, " + "so no cost parameters will be calculated");
            }
            else
            {
                try
                {
                    costDesignatorParameters = _costingUtility.determineParameters(schemeAuthResult, respBuilder.AuthScheme, context.getSale());

                    if (costDesignatorParameters == null)
                    {
                        //Logger.warn("Could not determine cost descriptor parameters.");
                        // Setting this response code means the 'open' sale will not be removed,
                        // and therefore the next reversal job will reverseSaleAuthorisation the
                        // authorisation previously sent
                        respBuilder.ResponseCode = ResponseCode.COULD_NOT_DETERMINE_COST;
                    }
                    else
                    {
                        respBuilder.CostDesignatorParameters = costDesignatorParameters;
                    }
                }


                //catch (CostingTerminalConfigurationException cte)
                catch (Exception)
                {
                    //Logger.warn("Terminal miscofiguration", cte);
                    respBuilder.ResponseCode = ResponseCode.TXN_TERMINAL_CONFIG_MISMATCH;
                }
            }
        }
    }
}
