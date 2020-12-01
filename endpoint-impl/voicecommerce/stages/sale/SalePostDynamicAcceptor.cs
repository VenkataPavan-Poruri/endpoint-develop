using datalayer.voicecommerce.model.sale;
using datalayer.voicecommerce.model.terminal;
using endpoint_api.voicecommerce.api;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostDynamicAcceptor : SalePostPipelineStageBase
    {
        private readonly SalePostPipelineStage _nextStage;
        private readonly PipelineExplicitAcceptorStageUtility _acceptorUtil;
        public SalePostDynamicAcceptor(PipelineExplicitAcceptorStageUtility acceptorUtility, SalePostPipelineStage next) : base(next)
        {
            _acceptorUtil = acceptorUtility;
            _nextStage = new SalePostSoftDescriptor(next);            
        }
        protected internal override void stageExecute(SalePostContext context)
        {
            SaleRepo.SaleBuilder builder = context.saleBuild();
            SalePostRequest request = context.Request;
            AcceptorDetail defaultAcceptorDetail = builder.Terminal.DefaultAcceptorDetail;
            AcceptorDetail dynamicAcceptor;
            if (request.hasDynamicAcceptor())
            {
                // So we have dynamic acceptor details provided, try to use.
                dynamicAcceptor = _acceptorUtil.obtainExplicitAcceptor(builder.Terminal, request.getDynamicAcceptorName(), request.getDynamicAcceptorStreet(), request.getDynamicAcceptorCity(), request.getDynamicAcceptorState(), request.getDynamicAcceptorPostalCode(), request.getDynamicAcceptorCustomerServicePhone(), request.getDynamicAcceptorSubMerchantId(), defaultAcceptorDetail.CustomerServiceEmail);

                if (dynamicAcceptor != null)
                {
                    //Logger.info("Dynamic Acceptor associated: " + dynamicAcceptor);
                    builder.ExplictAcceptor = dynamicAcceptor;
                }
                else
                {
                    //Logger.warn("Ignoring supplied Dynamic Acceptor");
                }
            }
            else
            {
                //Logger.warn("No Dynamic Acceptor - doing nothing");
            }

            nextStg(context);
        }
    }
}
