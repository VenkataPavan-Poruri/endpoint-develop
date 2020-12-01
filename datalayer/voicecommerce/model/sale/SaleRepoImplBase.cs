using datalayer.voicecommerce.model.card;
using System;
using System.Collections.Generic;
using System.Text;

namespace datalayer.voicecommerce.model.sale
{
    public abstract class SaleRepoImplBase<SR, SAR, FSR, OSR, SVR, SVAR, SCBR, SCBRR, SDR, SDRR, CDR, CIMR, CIVR, CSMR, CSVR> : SaleRepoInternal
    {
        private readonly CardRepo cardRepo;

            public SaleRepoImplBase(CardRepo cardRepo)
        {
            this.cardRepo = cardRepo;
        }

        public SaleRepo.SaleBuilder initialSaleBuilder()
        {
            throw new NotImplementedException();
        }

        CardRepo SaleRepoInternal.cardRepo()
        {
            throw new NotImplementedException();
        }

        //private Sale createSale(SaleBuilderInternal builder) throws EndpointException
        //{
        //    SR saleRep = dbSaleCreate(dbSaleRepFromParts(builder.getTimestamp(),
        //                                             builder.getAmount(), builder.getCurrency(),
        //                                             builder.getCard(), builder.getAuthType(),
        //                                             builder.getAuthMode(), builder.getRecurrenceFlag(),
        //                                             builder.getAuthenticationData(),
        //                                             builder.getFundsRecipient(),
        //                                             builder.getTerminal(),
        //                                             builder.getExplicitAcceptor(),
        //                                             builder.getSoftDescriptor(),
        //                                             builder.getSTAN(),
        //                                             builder.getGatewayRef(),
        //                                             builder.getInitialARN(),
        //                                             builder.getDebtRepayFlag(),
        //                                             builder.getChipDataId(),
        //                                             builder.getOtherAmountsTransaction(),
        //                                             builder.getFallBackFlag(),
        //                                             builder.getLocalTransTime(),
        //                                             builder.getCard().getTrackTwoServiceCode(),
        //                                             builder.getExemptionIndicator()));

        //return dbSaleFromRep(saleRep, builder.getCard(), builder.getTerminal(), builder.getExplicitAcceptor());
    }
}
