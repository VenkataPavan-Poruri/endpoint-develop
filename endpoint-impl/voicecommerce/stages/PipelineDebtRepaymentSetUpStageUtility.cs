using core_develop.cashflows.core.authorisation;
using datalayer.voicecommerce.model.card;
using datalayer.voicecommerce.model.terminal;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class PipelineDebtRepaymentSetUpStageUtility
    {
        public virtual ResponseCode checkDebtRepayFlag(Card card, bool debtRepaymentProfileFlag, Terminal terminal)
        {
            throw new NotImplementedException();
        }

        public virtual bool isDebtRepaymentTrans(Card card, Terminal terminal, bool debtRepaymentProfileFlag)
        {
            throw new NotImplementedException();
        }
    }
}