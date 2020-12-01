using datalayer.voicecommerce.model.card;
using datalayer.voicecommerce.model.terminal;
using System;

namespace datalayer.voicecommerce.model.sale
{
    public interface Sale
    {

        long? Id { get; set; }

        string GatewayRef { get; }

        //AuthType AuthType { get; }

        long? Amount { get; }

        //Currency Currency { get; }

        //Card Card { get; }

        string BID { get; set; }

        string MID { get; }

        string TID { get; }

        //Terminal Terminal { get; }


        //AcceptorDetail AcceptorDetail { get; }

        /// <summary>
        /// 3DS data
        /// </summary>
        ////AuthenticationData AuthenticationData { get; }

        DateTime Timestamp { get; }

        //RecurrenceFlag RecurrenceFlag { get; }

        long? STAN { get; }

        int? TTN { get; }

        //FundsRecipient FundsRecipient { get; }

        string SoftDescriptor { get; }

        //SaleVoidAuthorisationResponse findSuccessfulVoid();
        bool hasLineItemDetail();
        //AuthMode AuthMode { get; }

        /// <summary>
        /// Initial Sale/Verify ARN * </summary>
        string InitialARN { get; }

        bool? DebtRepayFlag { get; }

        bool? FallBackFlag { get; }

        long? ChipDataId { get; }


        //ChipData ChipData { get; }

        long? OtherAmountsTransaction { get; }

        DateTime LocalTransTime { get; }

        string ExemptionIndicator { get; }
        Terminal Terminal { get; }
        Card Card { get; }
    }
}
