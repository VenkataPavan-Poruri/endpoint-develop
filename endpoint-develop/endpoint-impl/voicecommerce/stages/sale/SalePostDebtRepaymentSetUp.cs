using core_develop.cashflows.core.authorisation;
using datalayer.voicecommerce.model.card;
using datalayer.voicecommerce.model.sale;
using datalayer.voicecommerce.model.terminal;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostDebtRepaymentSetUp : SalePostPipelineStageBase
    {
        private PipelineDebtRepaymentSetUpStageUtility debtRepaymentSetUpUtility;
        public SalePostDebtRepaymentSetUp(SalePostPipelineStage next, PipelineDebtRepaymentSetUpStageUtility debtRepaymentSetUpUtility) : base(next)
        {

            this.debtRepaymentSetUpUtility = debtRepaymentSetUpUtility;
        }
        public override void stageExecute(SalePostContext context)
        {
            bool isDebtRepayTrans;
            ResponseCode errorCode;
            SaleRepo.SaleBuilder saleBuilder = context.saleBuild();
            Card card = saleBuilder.Card;
            bool debtRepaymentProfileFlag = context.Request.getDebtRepayFlag();
            Terminal terminal = saleBuilder.Terminal;
            errorCode = debtRepaymentSetUpUtility.checkDebtRepayFlag(card, debtRepaymentProfileFlag, terminal);
            isDebtRepayTrans = debtRepaymentSetUpUtility.isDebtRepaymentTrans(card, terminal, debtRepaymentProfileFlag);
            if (errorCode != null)
            {
                context.Response.ResponseCode = errorCode;
            }
            else
            {
                //Logger.info("Setting debt repayment flag: " + isDebtRepayTrans);
                saleBuilder.DebtRepayFlag = isDebtRepayTrans;
                nextStage(context);
            }
        }
    }
}
