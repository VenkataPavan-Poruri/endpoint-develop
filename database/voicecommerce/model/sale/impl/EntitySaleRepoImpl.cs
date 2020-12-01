using com.cashflows.core.authorisation;
using com.voicecommerce.endpoint.model.sale.impl;
using com.voicecommerce.payment.common.entities;
using database.voicecommerce.daos;
using database.voicecommerce.domain;
using datalayer.voicecommerce.common;
using datalayer.voicecommerce.entity;
using datalayer.voicecommerce.entity.authorisation.impl;
using datalayer.voicecommerce.entity.costing;
using datalayer.voicecommerce.entity.impl;
using datalayer.voicecommerce.entity.verify.impl;
using datalayer.voicecommerce.model.card;
using datalayer.voicecommerce.model.card.impl;
using datalayer.voicecommerce.model.chipdata;
using datalayer.voicecommerce.model.chipdata.impl;
using datalayer.voicecommerce.model.costing;
using datalayer.voicecommerce.model.costing.impl;
using datalayer.voicecommerce.model.sale;
using datalayer.voicecommerce.model.sale.impl;
using datalayer.voicecommerce.model.terminal;
using datalayer.voicecommerce.model.terminal.impl;
using Endpoint;
using endpoint_common.voicecommerce.common;
using System;
using System.Collections.Generic;
using System.Linq;
using static com.cashflows.core.common.EnumExtensions;
using static datalayer.voicecommerce.model.sale.SaleRepo;

namespace database.voicecommerce.model.sale.impl
{
    /// <summary>
    /// Implementation of SaleRepo that uses SaleImpl as its Sale representation.
    /// </summary>
    public class EntitySaleRepoImpl : SaleRepoImplBase<SaleEntity, SaleAuthResponseEntity, FailedSaleEntity, OpenSaleEntity, SaleVoidEntity, SaleVoidAuthResponseEntity,
                                                       SaleChargebackEntity, SaleChargebackReversalEntity, SaleDisputeEntity, SaleDisputeReversalEntity, ChipDataEntity,
                                                       CostInterchangeParamMastercardEntity, CostInterchangeParamVisaEntity, CostSchemeParamMastercardEntity, CostSchemeParamVisaEntity>
    {
        private readonly SaleDAO saleDAO;
        private readonly FailedSaleDAO failedSaleDAO;
        private readonly SaleAuthResponseDAO saleAuthRespDAO;
        private readonly SaleVoidDAO saleVoidDAO;
        private readonly SaleVoidAuthResponseDAO saleVoidRespDAO;
        private readonly OpenSaleDAO openSaleDAO;
        private readonly SaleChargebackDAO saleChargebackDAO;
        private readonly SaleChargebackReversalDAO saleChargebackReversalDAO;
        private readonly SaleDisputeDAO saleDisputeDAO;
        private readonly SaleDisputeReversalDAO saleDisputeReversalDAO;

        //private readonly TransactionTemplate txn;
        private readonly ChipDataDao chipDataDAO;

        private readonly CostInterchangeParamMastercardDAO costInterchangeParamMastercardDAO;
        private readonly CostInterchangeParamVisaDAO costInterchangeParamVisaDAO;
        private readonly CostSchemeParamMastercardDAO costSchemeParamMastercardDAO;
        private readonly CostSchemeParamVisaDAO costSchemeParamVisaDAO;

        public EntitySaleRepoImpl(SaleDAO saleDAO, SaleAuthResponseDAO saleAuthRespDAO,
                              FailedSaleDAO failedSaleDAO,
                              SaleVoidDAO saleVoidDAO, SaleVoidAuthResponseDAO saleVoidRespDAO,
                              OpenSaleDAO openSaleDAO, SaleChargebackDAO saleChargebackDAO,
                              SaleChargebackReversalDAO saleChargebackReversalDAO, SaleDisputeDAO saleDisputeDAO,
                              SaleDisputeReversalDAO saleDisputeReversalDAO,
                              CardRepo cardRepo, TerminalRepoInternal termRepo, VerifyRepoInternal verifyRepo, ChipDataDao chipDataDAO,
                              // PlatformTransactionManager txnMgr, ChipDataDao chipDataDAO,
                              CostInterchangeParamMastercardDAO costInterchangeParamMastercardDAO,
                              CostInterchangeParamVisaDAO costInterchangeParamVisaDAO,
                              CostSchemeParamMastercardDAO costSchemeParamMastercardDAO,
                              CostSchemeParamVisaDAO costSchemeParamVisaDAO) : base(cardRepo, termRepo, verifyRepo)
        {
            //base(cardRepo, termRepo, verifyRepo);
            this.saleDAO = saleDAO;
            this.saleAuthRespDAO = saleAuthRespDAO;
            this.failedSaleDAO = failedSaleDAO;
            this.saleVoidDAO = saleVoidDAO;
            this.saleVoidRespDAO = saleVoidRespDAO;
            this.openSaleDAO = openSaleDAO;
            this.saleChargebackDAO = saleChargebackDAO;
            this.saleChargebackReversalDAO = saleChargebackReversalDAO;
            this.saleDisputeDAO = saleDisputeDAO;
            this.saleDisputeReversalDAO = saleDisputeReversalDAO;
            //this.txn = new TransactionTemplate(txnMgr);
            this.chipDataDAO = chipDataDAO;
            this.costInterchangeParamMastercardDAO = costInterchangeParamMastercardDAO;
            this.costInterchangeParamVisaDAO = costInterchangeParamVisaDAO;
            this.costSchemeParamMastercardDAO = costSchemeParamMastercardDAO;
            this.costSchemeParamVisaDAO = costSchemeParamVisaDAO;
        }

        protected override SaleEntity dbSaleCreate(SaleEntity saleRep)
        {
            Int64 id = saleDAO.Create(saleRep);

            // Reload the Sale so we have knowledge of the TTN (generated at insert
            // time) - Best way? Maybe not, but should suffice.
            return saleDAO.Find(id);
        }

        protected override SaleEntity dbSaleRepFromParts(DateTime timestamp, long amount, CurrencyEnums currency,
                                               Card card, AuthType authType,
                                               AuthMode authMode, RecurrenceFlagEnums recurrence,
                                               AuthenticationData authenticationData,
                                               FundsRecipient fundsRecipient,
                                               Terminal terminal,
                                               AcceptorDetail explicitAcceptor,
                                               string softDescriptor, long stan,
                                               string gatewayRef, string intialARN,
                                               bool debtRepayFlag, Int64 chipDataId,
                                               Int64 otherAmountsTransaction, bool fallBackFlag,
                                               DateTime localTransTime, string trackTwoServiceCode, string exemptionIndicator)
        {
            SaleEntity entity = new SaleEntity();

            //Assert.notNull(currency, "Null currency");
            //Assert.notNull(terminal, "Null terminal");
            //Assert.notNull(authType, "Null auth type");
            //Assert.notNull(card, "Null card");
            //Assert.notNull(card.getEncryptedCardNumber(), "Null encrypted number");
            //Assert.notNull(card.getHashedCardNumber(), "Null hashed number");
            //Assert.notNull(card.getObfuscatedCardNumber(), "Null obfuscated number");

            entity.Reference = gatewayRef;
            entity.Amount = amount;
            entity.CurrencyCode = currency.isoCode;
            entity.EncCardNumber = card.getEncryptedCardNumber().getNumber();
            entity.HashedCardNumber = card.getHashedCardNumber().getNumber();
            entity.ObfuscatedCardNumber = card.getObfuscatedCardNumber().getNumber();
            entity.ExpiryDate = card.getExpiryDate().getCardDate();
            entity.IssueDate = card.getIssueDate().getCardDate();

            if (card.getAddressVerificationData() != null)
            {
                entity.CardholderAddress = card.getAddressVerificationData().getCardholderAddress();
                entity.PostalCode = card.getAddressVerificationData().getPostalCode();
            }

            entity.CardSequenceNumber = card.getCardSequenceNumber();
            entity.Mid = terminal.getMID();
            entity.Tid = terminal.getTID();
            entity.Bid = terminal.getBID();
            entity.AuthType = authType.ToString();

            if (authMode != null)
            {
                entity.AuthMode = authMode.ToString();
            }

            entity.RecurrenceFlag = recurrence.ToString();

            if (authenticationData != null)
            {
                entity.EciFlag = authenticationData.getEciFlag();
                entity.Xid = authenticationData.getXid();
                entity.AcsData = authenticationData.getAcsData();

                // Mastercard Authentications 3Ds version - Storing Version and TransId whenever EP receives it.
                // We can't just base the scheme check on ECI Flags as there are few ECI values which are common in between Visa and MC.
                entity.ProgProtocol = authenticationData.getVersion();
                entity.DsTransId = authenticationData.getDsTransId();
            }

            entity.Stan = stan;

            if (fundsRecipient != null)
            {
                entity.RecipientDOB = fundsRecipient.getDateOfBirth();
                entity.RecipientSurname = fundsRecipient.getSurname();
                entity.RecipientAccountNumber = fundsRecipient.getAccountNumber();
                entity.RecipientPostalCode = fundsRecipient.getPostalCode();
            }

            entity.Timestamp = timestamp;

            if (explicitAcceptor != null)
            {
                entity.ExplicitAcceptorId = explicitAcceptor.getId();
            }

            if (softDescriptor != null)
            {
                entity.SoftDescriptor = softDescriptor;
            }

            entity.InitialSaleARN = intialARN;
            entity.DebtRepayFlag = debtRepayFlag;
            entity.ChipDataId = chipDataId;
            entity.OtherAmountsTransaction = otherAmountsTransaction;
            entity.FallBackFlag = fallBackFlag;
            entity.LocalTransTimestamp = localTransTime;
            entity.TrackTwoServiceCode = trackTwoServiceCode;
            entity.ExemptionIndicator = exemptionIndicator;

            return entity;
        }

        protected override Sale dbSaleFromRep(SaleEntity saleRep, Card useCard, Terminal useTerminal, AcceptorDetail useAcceptor)
        {
            SaleImpl sale = null;

            if (saleRep != null)
            {
                Card card;
                AVSData avsData;
                CurrencyEnums currency = Currency.currencynames.Where(x => x.name == saleRep.CurrencyCode).FirstOrDefault();

                if ((saleRep.CardholderAddress != null) || (saleRep.PostalCode != null))
                {
                    avsData = new AVSData(saleRep.CardholderAddress, saleRep.PostalCode);
                }
                else
                {
                    avsData = null;
                }

                if (useCard == null)
                {
                    // Create a card from the entity.
                    CardRepo.CardBuilder cardBuilder = cardRepo.builder();

                    cardBuilder.setEncryptedNumbers(new EncryptedCardNumber(saleRep.EncCardNumber),
                                            new HashedCardNumber(saleRep.HashedCardNumber),
                                            new ObfuscatedCardNumber(saleRep.ObfuscatedCardNumber));
                    cardBuilder.setExpiryDate(new CardDate(saleRep.ExpiryDate));
                    cardBuilder.setIssueDate(new CardDate(saleRep.IssueDate));
                    cardBuilder.setAVSData(avsData);
                    cardBuilder.setCardSequenceNumber(saleRep.CardSequenceNumber);
                    cardBuilder.setTrackTwoServiceCode(saleRep.TrackTwoServiceCode);
                    card = cardBuilder.create();
                }
                else
                {
                    // Have a given Card use that.
                    //Assert.isTrue(useCard.getHashedCardNumber().getNumber().Equals(saleRep.getHashedCardNumber()));
                    card = useCard;
                }

                Enum.TryParse(saleRep.AuthType, out AuthType authType);
                Enum.TryParse(saleRep.RecurrenceFlag, out RecurrenceFlagEnums recurrenceFlag);
                Enum.TryParse(saleRep.AuthMode, out AuthMode authMode);

                AuthenticationData authData = new AuthenticationData(saleRep.EciFlag, saleRep.Xid,
                                                                     saleRep.AcsData, saleRep.ProgProtocol,
                                                                     saleRep.DsTransId);
                FundsRecipient recipient = new FundsRecipient(saleRep.RecipientDOB,
                                                              saleRep.RecipientSurname,
                                                              saleRep.RecipientAccountNumber,
                                                              saleRep.RecipientPostalCode);
                sale = new SaleImpl(saleRep.Id, saleRep.Reference, saleRep.Amount, currency,
                                    saleRep.Bid, saleRep.Mid, saleRep.Tid, useTerminal,
                                    card, authType,
                                    authData, recurrenceFlag,
                                    saleRep.Stan, saleRep.Ttn, recipient,
                                    saleRep.ExplicitAcceptorId, useAcceptor,
                                    saleRep.Timestamp, saleRep.SoftDescriptor, this,
                                    authMode, //saleRep.AuthMode != null ? AuthMode.valueOf(saleRep.AuthMode) : AuthMode.NONE,
                                    saleRep.InitialSaleARN,
                                    saleRep.DebtRepayFlag, saleRep.ChipDataId,
                                    saleRep.OtherAmountsTransaction, saleRep.FallBackFlag,
                                    saleRep.LocalTransTimestamp, saleRep.ExemptionIndicator);
            }
            return sale;
        }

        protected override SaleEntity dbSaleLoad(long id)
        {
            return saleDAO.Find(id);
        }

        protected override SaleEntity dbSaleFindByARN(string arn)
        {
            return saleDAO.FindByAcquirerReferenceNumber(arn);
        }

        protected override SaleEntity dbSaleFindByReference(string reference)
        {
            return saleDAO.FindByGatewayReference(reference);
        }

        protected override Int64 dbFailedSaleCreate(FailedSaleEntity failedSaleRep)
        {
            failedSaleRep.ID = failedSaleDAO.Create(failedSaleRep);
            return failedSaleRep.ID;
        }

        protected override FailedSaleEntity dbFailedSaleRepFromParts(DateTime timestamp, Int64 amount,
                                                           string currencyCode,
                                                           string cardNumber,
                                                           string cardExpiry,
                                                           string cardIssue,
                                                           string cardAddress,
                                                           string cardPostalCode,
                                                           string authType, string authMode,
                                                           string recurrence, int eci,
                                                           string xid, string acsData, string progProtocol,
                                                           string bid, string mid, string tid,
                                                           string gatewayRef,
                                                           string initialARN,
                                                           AuthScheme scheme,
                                                           ResponseCode responseCode,
                                                           Boolean debtRepayFlag,
                                                           Int64 chipDataId)
        {
            FailedSaleEntity entity = new FailedSaleEntity();

            entity.REFERENCE = gatewayRef;
            entity.AMOUNT = Convert.ToInt32(amount);
            entity.AUTH_TYPE = authType;
            entity.AUTH_MODE = authMode;
            entity.AUTH_SCHEME = scheme.ToString();
            entity.TERMINAL_CURRENCY_CODE = currencyCode;
            entity.RECURRENCE_FLAG = recurrence;

            entity.HASHED_CARD_NUMBER = (cardRepo.hashNumber(new ClearTextCardNumber(cardNumber)).getNumber());
            entity.OBFUSCATED_CARD_NUMBER = cardRepo.obfuscateNumber(new ClearTextCardNumber(cardNumber)).getNumber();

            //try
            //{
            //  entity.HASHED_CARD_NUMBER = (cardRepo().hashNumber(new ClearTextCardNumber(cardNumber)).getNumber());

            //}
            //catch (CardHandlingException e)
            //{
            //    entity.HASHED_CARD_NUMBER = cardNumber;
            //}

            //try
            //{
            //    entity.OBFUSCATED_CARD_NUMBER = cardRepo().obfuscateNumber(new ClearTextCardNumber(cardNumber)).getNumber())
            //}
            //catch (CardHandlingException e)
            //{
            //    entity.OBFUSCATED_CARD_NUMBER = cardNumber;
            //}

            entity.EXPIRY_DATE = cardExpiry;
            entity.ISSUE_DATE = cardIssue;
            entity.CARDHOLDER_ADDRESS = cardAddress;
            entity.POSTAL_CODE = cardPostalCode;

            entity.MID = mid;
            entity.TID = tid;
            entity.BID = bid;

            entity.ECI_FLAG = eci;
            entity.XID = xid;
            entity.ACS_DATA = acsData;

            //Mastercard Authentications 3Ds version
            if (eci != null && (eci == 1 || eci == 2))
            {
                entity.PROGRAM_PROTOCOL = progProtocol;
            }

            entity.REQ_TIMESTAMP = timestamp.ToString();
            entity.INITIAL_SALE_ARN = initialARN;
            entity.RESPONSE_CODE = responseCode.GetCode();   //((responseCode != null) ? responseCode.getCode() : null);
            entity.DEBT_REPAY_FLAG = debtRepayFlag.ToString();
            entity.CHIP_DATA_ID = Convert.ToInt32(chipDataId);
            return entity;
        }

        protected override FailedSaleEntity dbFailedSaleLoad(long id)
        {
            return failedSaleDAO.Find(id);
        }

        protected override OpenSaleEntity dbOpenSaleCreate(OpenSaleEntity openSaleRep)
        {
            openSaleDAO.create(openSaleRep);
            return openSaleRep;
        }

        protected override List<OpenSaleEntity> dbOpenSalesFindTimedOut(DateTime timeoutDate)
        {
            return openSaleDAO.findTimedOutOpenSales(timeoutDate);
        }

        protected override void dbOpenSaleRemove(long saleId)
        {
            openSaleDAO.delete(saleId);
        }

        protected override OpenSale dbOpenSaleFromRep(OpenSaleEntity entity)
        {
            OpenSale openSale = null;

            if (entity != null)
            {
                Enum.TryParse(entity.AUTH_SCHEME, out AuthScheme scheme);

                openSale = new OpenSaleImpl(entity.ID, scheme,
                                            entity.SALE_TIMESTAMP);
            }

            return openSale;
        }

        protected override OpenSaleEntity dbOpenSaleRepFromParts(long saleId, AuthScheme scheme)
        {
            OpenSaleEntity entity = new OpenSaleEntity();

            entity.ID = saleId;
            entity.AUTH_SCHEME = scheme.ToString();
            return entity;
        }

        protected override SaleAuthResponseEntity dbSaleAuthRespCreate(SaleAuthResponseEntity saleAuthRespRep)
        {
            saleAuthRespDAO.Create(saleAuthRespRep);
            return saleAuthRespRep;
        }

        protected override SaleAuthorisationResponse dbSaleAuthRespFromRep(SaleAuthResponseEntity entity, Sale useSale)
        {
            SaleAuthorisationResponse response = null;

            if (entity != null)
            {
                CostDesignatorParameters costParams;
                SchemeCostParameters interParams;
                SchemeCostParameters transParams;
                SchemeAuthorisationResult authResult = null;
                ResponseCode responseCode;
                //VerificationResponse addrResponse = new VerificationResponse();
                VerificationResponse postalResponse = new VerificationResponse();
                VerificationResponse cvvResponse = new VerificationResponse();

                Enum.TryParse(entity.MappedAvsAddressResponseCode, out VerificationResponse addrResponse);

                AuthScheme authScheme;

                responseCode = ResponseCode.Get(entity.MappedResponseCode);

                if (!string.IsNullOrEmpty(entity.MappedAvsAddressResponseCode))
                {
                    Enum.TryParse(entity.MappedAvsAddressResponseCode, out addrResponse);
                }

                if (entity.MappedAvsPostalResponseCode != null)
                {
                    Enum.TryParse(entity.MappedAvsPostalResponseCode, out postalResponse);
                }

                if (entity.MappedCvvResponseCode != null)
                {
                    Enum.TryParse(entity.MappedCvvResponseCode, out cvvResponse);
                }

                Enum.TryParse(entity.AuthScheme, out authScheme);

                interParams = new SchemeCostParameters(entity.IntchgFeeProgram,
                                                       entity.IntchgFeeTier,
                                                       entity.IntchgDescription,
                                                       entity.IntchgRateTier);

                transParams = new SchemeCostParameters(entity.TxncstFeeProgram,
                                                       entity.TxncstFeeTier,
                                                       entity.TxncstDescription,
                                                       entity.TxncstRateTier);

                costParams = new CostDesignatorParameters(interParams, transParams);

                if (entity.ResponseCode != null)
                {
                    authResult = new SchemeAuthorisationResult(entity.AuthCode,
                                                     entity.ResponseCode,
                                                     entity.ReferenceData,
                                                     entity.SchemeCvvResponseCode,
                                                     entity.SchemeAvsResponseCode,
                                                     new IssuerResponseTags(null, null, entity.IssuerAuthenticationData),
                                                     entity.SchemeAdditionalData);
                }
                response = new SaleAuthorisationResponseImpl(entity.Id,
                                                         authScheme,
                                                         authResult,
                                                         entity.AuthTimestamp,
                                                         entity.AcquirerReferenceNumber,
                                                         costParams,
                                                         useSale,
                                                         responseCode,
                                                         cvvResponse,
                                                         addrResponse,
                                                         postalResponse,
                                                         entity.MappedAdditionalData,
                                                         this);
            }
            return response;
        }

        protected override SaleAuthResponseEntity dbSaleAuthRespRepFromParts(long saleId,
                                                                   DateTime timestamp,
                                                                   ResponseCode responseCode,
                                                                   VerificationResponse avsAddressResponse,
                                                                   VerificationResponse avsPostalCodeResponse,
                                                                   VerificationResponse cvvResponse,
                                                                   string arn,
                                                                   AuthScheme scheme,
                                                                   SchemeAuthorisationResult authResult,
                                                                   CostDesignatorParameters costParams,
                                                                   string schemeAdditionalData,
                                                                   string mappedAdditionalData,
                                                                   string issuerAuthenticationData)

        {
            SaleAuthResponseEntity entity = new SaleAuthResponseEntity();

            entity.Id = saleId;
            entity.AuthTimestamp = timestamp;

            entity.MappedResponseCode = responseCode.GetCode();

            if (authResult != null)
            {
                entity.AuthCode = authResult.getSchemeAuthCode();
                entity.ResponseCode = authResult.getSchemeResponseCode();
                entity.SchemeCvvResponseCode = authResult.getSchemeCvvResponseCode();
                entity.MappedCvvResponseCode = cvvResponse.ToString();

                //if (cvvResponse != null)
                //{
                //}

                entity.SchemeAvsResponseCode = authResult.getSchemeAvsResponseCode();

                if (avsAddressResponse != null)
                {
                    entity.MappedAvsAddressResponseCode = avsAddressResponse.ToString();
                }
                if (avsPostalCodeResponse != null)
                {
                    entity.MappedAvsPostalResponseCode = avsPostalCodeResponse.ToString();
                }

                entity.ReferenceData = authResult.getSchemeReferenceData();

                if (schemeAdditionalData != null)
                {
                    entity.SchemeAdditionalData = schemeAdditionalData;
                }
            }
            entity.AcquirerReferenceNumber = arn;
            entity.AuthScheme = scheme.ToString();

            if (costParams != null && costParams.getInterchangeParameters() != null)
            {
                entity.IntchgFeeProgram = costParams.getInterchangeParameters().getFeeProgram();
                entity.IntchgRateTier = costParams.getInterchangeParameters().getRateTier();
                entity.IntchgFeeTier = costParams.getInterchangeParameters().getFeeTier();
                entity.IntchgDescription = costParams.getInterchangeParameters().getDescription();
            }

            if (costParams != null && costParams.getTransactionParameters() != null)
            {
                entity.TxncstFeeProgram = costParams.getTransactionParameters().getFeeProgram();
                entity.TxncstDescription = costParams.getTransactionParameters().getDescription();
                entity.TxncstRateTier = costParams.getTransactionParameters().getRateTier();
                entity.TxncstFeeTier = costParams.getTransactionParameters().getFeeTier();
            }

            if (mappedAdditionalData != null)
            {
                entity.MappedAdditionalData = mappedAdditionalData;
            }

            if (issuerAuthenticationData != null)
            {
                entity.IssuerAuthenticationData = issuerAuthenticationData;
            }

            return entity;
        }

        protected override SaleAuthResponseEntity dbSaleAuthRespLoad(long id)
        {
            return saleAuthRespDAO.Find(id);
        }

        protected override SaleAuthResponseEntity dbSaleAuthRespFindByARN(string arn)
        {
            return saleAuthRespDAO.FindByAcquirerReferenceNumber(arn);
        }

        protected override SaleVoidEntity dbVoidCreate(SaleVoidEntity rep)
        {
            rep.Id = saleVoidDAO.Create(rep);
            return rep;
        }

        protected override SaleVoid dbVoidFromRep(SaleVoidEntity entity, SaleAuthorisationResponse useResponse, Sale useSale)
        {
            SaleVoidImpl saleVoid = null;

            if (entity != null)
            {
                Enum.TryParse(entity.Reason, out VoidReason reason);

                if (useResponse != null)
                {
                    // Check the entity has same sale as the response we've been given.
                    //Assert.isTrue(entity.getSaleId().Equals(useResponse.getSaleId()));
                    saleVoid = new SaleVoidImpl(entity.Id, entity.GatewayRef,
                                                entity.SaleARN,
                                                reason,
                                                entity.Timestamp,
                                                entity.Stan, useResponse, this);
                }
                else if (useSale != null)
                {
                    // Check the entity has same sale as we've been given.
                    //Assert.isTrue(entity.getSaleId().Equals(useSale.getId()));

                    saleVoid = new SaleVoidImpl(entity.Id, entity.GatewayRef,
                                                reason,
                                                entity.Timestamp,
                                                entity.Stan, useSale, this);
                }
                else
                {
                    saleVoid = new SaleVoidImpl(entity.Id, entity.GatewayRef,
                                                Convert.ToInt64(entity.SaleId), Convert.ToString(entity.SaleARN),
                                                reason,
                                                entity.Timestamp,
                                                entity.Stan, this);
                }
            }

            return saleVoid;
        }

        protected override SaleVoidEntity dbVoidRepFromParts(long saleId, string saleARN, DateTime timestamp, VoidReason reason, long stan, string gatewayRef)
        {
            SaleVoidEntity entity = new SaleVoidEntity();
            entity.SaleId = saleId;
            entity.Reason = reason.ToString();
            entity.Stan = stan;
            entity.SaleARN = saleARN;
            entity.GatewayRef = gatewayRef;
            entity.Timestamp = timestamp;
            return entity;
        }

        protected override SaleVoidEntity dbVoidLoad(long id)
        {
            return saleVoidDAO.Find(id);
        }

        protected override SaleVoidAuthResponseEntity dbVoidAuthRespCreate(SaleVoidAuthResponseEntity rep)
        {
            rep.Id = saleVoidRespDAO.Create(rep);
            return rep;
        }

        protected override SaleVoidAuthorisationResponse dbVoidAuthRespFromRep(SaleVoidAuthResponseEntity rep, SaleVoid useVoid)
        {
            SaleVoidAuthorisationResponse response = null;

            if (rep != null)
            {
                Enum.TryParse(rep.AuthScheme, out AuthScheme scheme);
                ResponseCode respCode = ResponseCode.Get(rep.MappedResponseCode);

                SchemeAuthorisationResult authResult = null;

                if (rep.ResponseCode != null)
                {
                    authResult = new SchemeAuthorisationResult(rep.AuthCode,
                                                     rep.ResponseCode,
                                                     rep.ReferenceData,
                                                     rep.MappedAdditionalData,
                                                     null, null);
                }
                if (useVoid == null)
                {
                    response = new SaleVoidAuthorisationResponseImpl(rep.Id, scheme,
                                                                authResult,
                                                                rep.AuthTimestamp,
                                                                rep.AcquirerReferenceNumber,
                                                                respCode,
                                                                rep.MappedAdditionalData,
                                                                this);
                }
                else
                {
                    response = new SaleVoidAuthorisationResponseImpl(rep.Id, scheme,
                                                                authResult,
                                                                rep.AuthTimestamp,
                                                                rep.AcquirerReferenceNumber,
                                                                useVoid,
                                                                respCode,
                                                                rep.MappedAdditionalData,
                                                                this);
                }
            }
            return response;
        }

        protected override SaleVoidAuthResponseEntity dbVoidAuthRespRepFromParts(long voidId, DateTime timestamp, AuthScheme scheme,
                                                                       string arn, ResponseCode responseCode, SchemeAuthorisationResult authResult,
                                                                       string schemeAdditionalData, string mappedAdditionalData)
        {
            SaleVoidAuthResponseEntity entity = new SaleVoidAuthResponseEntity();

            entity.Id = voidId;
            entity.AuthTimestamp = timestamp;
            entity.AuthScheme = scheme.ToString();
            entity.AcquirerReferenceNumber = arn;
            entity.MappedResponseCode = responseCode.GetCode();

            if (authResult != null)
            {
                entity.ResponseCode = authResult.getSchemeResponseCode();
                entity.ReferenceData = authResult.getSchemeReferenceData();
                entity.AuthCode = authResult.getSchemeAuthCode();

                if (schemeAdditionalData != null)
                {
                    entity.SchemeAdditionalData = schemeAdditionalData;
                }
            }

            if (mappedAdditionalData != null)
            {
                entity.MappedAdditionalData = mappedAdditionalData;
            }

            return entity;
        }

        protected override SaleVoidAuthResponseEntity dbVoidAuthRespLoad(long id)
        {
            return saleVoidRespDAO.Find(id);
        }

        protected override SaleVoidAuthResponseEntity dbVoidAuthRespFindByARN(string arn)
        {
            return saleVoidRespDAO.FindByAcquirerReferenceNumber(arn);
        }

        protected override List<SaleVoidAuthResponseEntity> dbVoidAuthRespFindForSale(long saleId)
        {
            return saleVoidRespDAO.FindForSale(saleId);
        }

        protected override SaleChargebackEntity dbChargebackCreate(SaleChargebackEntity rep)
        {
            rep.Id = saleChargebackDAO.Create(rep);
            return rep;
        }

        protected override SaleChargeback dbChargebackFromRep(SaleChargebackEntity rep)
        {
            SaleChargebackImpl saleChargeback = null;
            if (rep != null)
            {
                CurrencyEnums currency = Currency.currencynames.Where(x => x.name == rep.CurrencyCode).FirstOrDefault();
                Enum.TryParse(rep.Scheme, out AuthScheme authScheme);

                saleChargeback = new SaleChargebackImpl(
                        rep.Id,
                        rep.Mid,
                        rep.Tid,
                        rep.Bid,
                        rep.Ssid,
                        rep.OrigSaleARN,
                        rep.ChargebackARN,
                        rep.ChargebackAmount,
                        currency,
                        rep.DateUpdated,
                        rep.IssuerRef,
                        rep.ChargebackReasonCode,
                        authScheme,
                        rep.IsPartial,
                        this);
            }
            return saleChargeback;
        }

        protected override SaleChargebackEntity dbChargebackRepFromParts(DateTime dateUpdated, string bid,
                                                                string mid, string tid,
                                                                string schemeSpecificId,
                                                                AuthScheme scheme,
                                                                string reasonCode,
                                                                bool isPartial, long amount,
                                                                CurrencyEnums currency,
                                                                string origSaleARN,
                                                                string issuerRef, string arn)

        {
            SaleChargebackEntity entity = new SaleChargebackEntity();
            entity.Mid = mid;
            entity.Tid = tid;
            entity.Bid = bid;
            entity.Ssid = schemeSpecificId;
            entity.ChargebackReasonCode = reasonCode;
            entity.ChargebackAmount = amount;
            entity.OrigSaleARN = origSaleARN;
            entity.ChargebackARN = arn;
            entity.IssuerRef = issuerRef;
            entity.IsPartial = isPartial;
            entity.CurrencyCode = currency.isoCode;
            entity.Scheme = scheme.ToString();
            entity.DateUpdated = dateUpdated;
            return entity;
        }

        protected override SaleChargebackEntity dbChargebackLoad(long chargebackId)
        {
            return saleChargebackDAO.Find(chargebackId);
        }

        protected override List<SaleChargebackEntity> dbChargebacksFindByDates(DateTime startDate, DateTime endDate, string bid, AuthScheme scheme)
        {
            return saleChargebackDAO.FindByDates(startDate, endDate, bid, scheme);
        }

        protected override SaleChargebackReversalEntity dbChargebackReversalCreate(SaleChargebackReversalEntity rep)
        {
            rep.Id = saleChargebackReversalDAO.Create(rep);
            return rep;
        }

        protected override SaleChargebackReversal dbChargebackReversalFromRep(SaleChargebackReversalEntity entity)

        {
            SaleChargebackReversalImpl saleChargebackReversal = null;
            if (entity != null)
            {
                CurrencyEnums currency = Currency.currencynames.Where(x => x.name == entity.CurrencyCode).FirstOrDefault();
                Enum.TryParse(entity.Scheme, out AuthScheme scheme);

                saleChargebackReversal = new SaleChargebackReversalImpl(
                        entity.Id,
                        entity.Mid,
                        entity.Tid,
                        entity.Bid,
                        entity.Ssid,
                        entity.OrigSaleARN,
                        entity.ChargebackARN,
                        entity.ChargebackAmount,
                        currency,
                        entity.DateUpdated,
                        entity.IssuerRef,
                        entity.ChargebackReasonCode,
                        scheme,
                        entity.IsPartial,
                        entity.ChargebackReversalARN,
                        this);
            }
            return saleChargebackReversal;
        }

        protected override SaleChargebackReversalEntity dbChargebackReversalRepFromParts(DateTime dateUpdated,
                                                                               string bid,
                                                                               string mid,
                                                                               string tid,
                                                                               string schemeSpecificId,
                                                                               AuthScheme scheme,
                                                                               string reasonCode,
                                                                               Boolean isPartial,
                                                                               long amount,
                                                                               CurrencyEnums currency,
                                                                               string origSaleARN,
                                                                               string issuerRef,
                                                                               string arn)

        {
            SaleChargebackReversalEntity entity = new SaleChargebackReversalEntity();
            entity.Bid = bid;
            entity.Mid = mid;
            entity.Tid = tid;
            entity.Ssid = schemeSpecificId;
            entity.ChargebackReasonCode = reasonCode;
            entity.ChargebackAmount = amount;
            entity.OrigSaleARN = origSaleARN;
            entity.ChargebackARN = null;
            entity.IssuerRef = issuerRef;
            entity.IsPartial = isPartial;
            entity.CurrencyCode = currency.isoCode;
            entity.Scheme = scheme.ToString();
            entity.DateUpdated = dateUpdated;
            entity.ChargebackReversalARN = arn;
            return entity;
        }

        protected override SaleChargebackReversalEntity dbChargebackReversalLoad(long chargebackReversalId)
        {
            return saleChargebackReversalDAO.Find(chargebackReversalId);
        }

        protected override List<SaleChargebackReversalEntity> dbChargebackReversalsFindByDates(DateTime startDate, DateTime endDate, string bid)
        {
            return saleChargebackReversalDAO.FindByDates(startDate, endDate, bid);
        }

        protected override SaleDisputeEntity dbDisputeCreate(SaleDisputeEntity rep)
        {
            rep.Id = saleDisputeDAO.Create(rep);
            return rep;
        }

        protected override SaleDispute dbDisputeFromRep(SaleDisputeEntity rep)
        {
            SaleDisputeImpl dispute = null;

            if (rep != null)
            {
                CurrencyEnums currency = Currency.currencynames.Where(x => x.name == rep.CurrencyCode).FirstOrDefault();
                Enum.TryParse(rep.Scheme, out AuthScheme schema);

                dispute = new SaleDisputeImpl(
                        rep.Id,
                        rep.Mid,
                        rep.Tid,
                        rep.Bid,
                        rep.Ssid,
                        rep.OrigSaleARN,
                        rep.SaleDisputeARN,
                        rep.Amount,
                        DisputeWorkflow.getWorkflow(rep.Workflow),
                        currency,
                        rep.DateUpdated,
                        rep.IssuerRef,
                        rep.ReasonCode,
                        schema,
                        rep.IsPartialField,
                        rep.ClientCaseNumber,
                        rep.DisputeStatus,
                        rep.VrolBundleCaseNumber,
                        rep.VrolCaseNumber,
                        rep.DisputeCondition,
                        this);
            }
            return dispute;
        }

        protected override SaleDisputeEntity dbDisputeRepFromParts(DateTime dateUpdated, string bid,
                                                         string mid, string tid,
                                                         string schemeSpecificId,
                                                         AuthScheme scheme, string reasonCode,
                                                         DisputeWorkflowenums workflow,
                                                         Boolean isPartial, long amount,
                                                         CurrencyEnums currency,
                                                         string origSaleARN, string issuerRef,
                                                         string arn,
                                                         string clientCaseNumber,
                                                         string disputeStatus,
                                                         string vrolBundleCaseNumber,
                                                         string vrolCaseNumber,
                                                         string disputeCondition)
        {
            SaleDisputeEntity entity = new SaleDisputeEntity();
            entity.Mid = mid;
            entity.Tid = tid;
            entity.Bid = bid;
            entity.Ssid = schemeSpecificId;
            entity.ReasonCode = reasonCode;
            entity.Amount = amount;
            entity.Workflow = workflow.ToString();
            entity.OrigSaleARN = origSaleARN;
            entity.SaleDisputeARN = arn;
            entity.IssuerRef = issuerRef;
            entity.IsPartialField = isPartial;
            entity.CurrencyCode = currency.isoCode;
            entity.Scheme = scheme.ToString();
            entity.DateUpdated = dateUpdated;
            entity.ClientCaseNumber = clientCaseNumber;
            entity.DisputeStatus = disputeStatus;
            entity.VrolCaseNumber = vrolCaseNumber;
            entity.VrolBundleCaseNumber = vrolBundleCaseNumber;
            entity.DisputeCondition = disputeCondition;
            return entity;
        }

        protected override SaleDisputeEntity dbDisputeLoad(long disputeId)
        {
            return saleDisputeDAO.Find(disputeId);
        }

        protected override List<SaleDisputeEntity> dbDisputesFindByDates(DateTime startDate, DateTime endDate, string bid, AuthScheme scheme)
        {
            return saleDisputeDAO.FindByDates(startDate, endDate, bid, scheme);
        }

        protected override SaleDisputeReversal dbDisputeReversalFromRep(SaleDisputeReversalEntity rep)
        {
            SaleDisputeReversalImpl dispute = null;
            if (rep != null)
            {
                CurrencyEnums currency = Currency.currencynames.Where(x => x.name == rep.CurrencyCode).FirstOrDefault();
                Enum.TryParse(rep.Scheme, out AuthScheme scheme);

                dispute = new SaleDisputeReversalImpl(
                        rep.Id,
                        rep.Mid,
                        rep.Tid,
                        rep.Bid,
                        rep.Ssid,
                        rep.OrigSaleARN,
                        rep.DisputeARN,
                        rep.DisputeReversalARN,
                        rep.Amount,
                        currency,
                        rep.DateUpdated,
                        rep.IssuerRef,
                        rep.ReasonCode,
                        scheme,
                        rep.IsPartialField,
                        DisputeWorkflow.getWorkflow(rep.Workflow),
                        this);
            }

            return dispute;
        }

        protected override SaleDisputeReversalEntity dbDisputeReversalCreate(SaleDisputeReversalEntity rep)
        {
            rep.Id = saleDisputeReversalDAO.Create(rep);
            return rep;
        }

        protected override SaleDisputeReversalEntity dbDisputeReversalLoad(long disputeId)
        {
            return saleDisputeReversalDAO.Find(disputeId);
        }

        protected override List<SaleDisputeReversalEntity> dbDisputeReversalsFindByDates(DateTime startDate, DateTime endDate, string bid)
        {
            return saleDisputeReversalDAO.FindByDates(startDate, endDate, bid);
        }

        protected override SaleDisputeReversalEntity dbDisputeReversalRepFromParts(
                DateTime dateUpdated,
                string bid,
                string mid,
                string tid,
                string schemeSpecificId,
                AuthScheme scheme,
                string reasonCode,
                DisputeWorkflowenums workflow,
                Boolean isPartial,
                long amount,
                CurrencyEnums currency,
                string origSaleARN,
                string issuerRef,
                string disputeArn,
                string disputeReversalArn)
        {
            SaleDisputeReversalEntity entity = new SaleDisputeReversalEntity();
            entity.Mid = mid;
            entity.Tid = tid;
            entity.Bid = bid;
            entity.Ssid = schemeSpecificId;
            entity.ReasonCode = reasonCode;
            entity.Amount = amount;
            entity.Workflow = workflow.ToString();
            entity.OrigSaleARN = origSaleARN;
            entity.DisputeARN = disputeArn;
            entity.DisputeReversalARN = disputeReversalArn;
            entity.IssuerRef = issuerRef;
            entity.IsPartialField = isPartial;
            entity.CurrencyCode = currency.isoCode;
            entity.Scheme = scheme.ToString();
            entity.DateUpdated = dateUpdated;
            return entity;
        }

        protected ChipDataEntity chipDataEntityFromBuilder(ChipDataBuilder builder)
        {
            ChipDataEntity entity = new ChipDataEntity();
            entity.ApplicationCryptogram = builder.getApplicationCryptogram();
            entity.CryptogramInformationData = builder.getCryptogramInformationData();
            entity.IssuerApplicationData = builder.getIssuerApplicationData();
            entity.UnpredictableNumber = builder.getUnpredictableNumber();
            entity.ApplicationTransactionCounter = builder.getApplicationTransactionCounter();
            entity.TerminalVerificationResult = builder.getTerminalVerificationResult();
            entity.TransactionDate = builder.getTransactionDate();
            entity.TransactionType = builder.getTransactionType();
            entity.AmountAuthorized = builder.getAmountAuthorized();
            entity.TransactionCurrencyCode = builder.getTransactionCurrencyCode();
            entity.ApplicationIntercangeProfile = builder.getApplicationInterchangeProfile();
            entity.TerminalCountryCode = builder.getTerminalCountryCode();
            entity.CardHolderVerificationMethodResults = builder.getCardHolderVerificationMethodResults();
            entity.TerminalCapabilities = builder.getTerminalCapabilities();
            entity.DedicatedFileName = builder.getDedicatedFileName();
            entity.AmountOther = builder.getAmountOther();
            entity.TerminalType = builder.getTerminalType();
            entity.InterfaceDeviceSerialNumber = builder.getInterfaceDeviceSerialNumber();
            entity.TransactionCategoryCode = builder.getTransactionCategoryCode();
            entity.ApplicationVersionNumber = builder.getApplicationVersionNumber();
            entity.TransactionSequenceCounter = builder.getTransactionSequenceCounter();
            entity.IssuerAuthenticationData = builder.getIssuerAuthenticationData();
            entity.IssuerScriptTemplate1 = builder.getIssuerScriptTemplate1();
            entity.IssuerScriptTemplate2 = builder.getIssuerScriptTemplate2();
            entity.SecondaryPinBlock = builder.getSecondaryPinBlock();
            entity.IssuerScriptResults = builder.getIssuerScriptResults();
            entity.FormFactorIndicator = builder.getFormFactorIndicator();
            entity.CustomerExclusiveData = builder.getCustomerExclusiveData();

            return entity;
        }

        protected ChipData chipDataFromRep(ChipDataEntity entity)
        {
            ChipData chipData = null;

            if (entity != null)
            {
                chipData = new ChipDataImpl(entity.Id.Value, entity.ApplicationCryptogram,
                        entity.CryptogramInformationData, entity.IssuerApplicationData,
                        entity.UnpredictableNumber, entity.ApplicationTransactionCounter,
                        entity.TerminalVerificationResult, entity.TransactionDate, entity.TransactionType,
                        entity.AmountAuthorized, entity.TransactionCurrencyCode,
                        entity.ApplicationIntercangeProfile, entity.TerminalCountryCode,
                        entity.CardHolderVerificationMethodResults, entity.TerminalCapabilities,
                        entity.DedicatedFileName, entity.AmountOther, entity.TerminalType,
                        entity.InterfaceDeviceSerialNumber, entity.TransactionCategoryCode,
                        entity.ApplicationVersionNumber, entity.TransactionSequenceCounter,
                        entity.IssuerAuthenticationData, entity.IssuerScriptTemplate1,
                        entity.IssuerScriptTemplate2, entity.SecondaryPinBlock, entity.IssuerScriptResults,
                        entity.FormFactorIndicator, entity.CustomerExclusiveData);
            }
            return chipData;
        }

        protected override ChipDataEntity dbChipDataCreate(ChipDataEntity entity)
        {
            entity.Id = chipDataDAO.create(entity);
            return entity;
        }

        public ChipData loadChipDataById(long chipDataId)
        {
            ChipDataEntity entity = chipDataDAO.find(chipDataId);
            return chipDataFromRep(entity);
        }

        protected CostInterchangeParamMastercardEntity costInterchangeParamMastercardEntityFromBuilder(SaleRepo.CostInterchangeParamMastercardBuilder builder)
        {
            CostInterchangeParamMastercardEntity entity = new CostInterchangeParamMastercardEntity();

            entity.Id = builder.getId();
            entity.AccFundingSource = builder.getAccFundingSource();
            entity.Amount = builder.getAmount();
            entity.ApprovalCode = builder.getApprovalCode();
            entity.CabProgram = builder.getCabProgram();
            entity.CardDataInputMode = builder.getCardDataInputMode();
            entity.CardholderAuthCapability = builder.getCardholderAuthCapability();
            entity.CardholderAuthMethod = builder.getCardholderAuthMethod();
            entity.CardholderPresentData = builder.getCardPresentData();
            entity.CardPresentData = builder.getCardPresentData();
            entity.CardProgIdentifier = builder.getCardProgIdentifier();
            entity.CorporateCardCommonData = builder.getCorporateCardCommonData();
            entity.CorporateLineItemDetail = builder.getCorporateLineItemDetail();
            entity.CurrencyCode = builder.getCurrencyCode();
            entity.Date = builder.getDate();
            entity.FunctionCode = builder.getFunctionCode();
            entity.TranRef = builder.getTranRef();
            entity.GCMSProductIdentifier = builder.getGCMSProductIdentifier();
            entity.ICC = builder.getICC();
            entity.IRD = builder.getIRD();
            entity.IssuerCountryCode = builder.getIssuerCountryCode();
            entity.MCC = builder.getMCC();
            entity.MerchantCountryCode = builder.getMerchantCountryCode();
            entity.MTI = builder.getMTI();
            entity.PosTerminalInputCapability = builder.getPosTerminalInputCapability();
            entity.ProcessingCode = builder.getProcessingCode();
            entity.ProductType = builder.getProductType();
            entity.ServiceCode = builder.getServiceCode();
            entity.TimelinessDays = builder.getTimelinessDays();
            return entity;
        }

        protected CostInterchangeParamMastercard costInterchangeParamMastercardFromRep(CostInterchangeParamMastercardEntity entity)
        {
            CostInterchangeParamMastercard interchangeCostingParametersEntity = null;
            if (entity != null)
            {
                interchangeCostingParametersEntity = new CostInterchangeParamMastercardImpl(entity.Id.Value,
                                                                                          entity.TranRef,
                                                                                          entity.Amount.Value,
                                                                                          entity.CurrencyCode,
                                                                                          entity.Date,
                                                                                          entity.MerchantCountryCode,
                                                                                          entity.MCC.Value,
                                                                                          entity.IssuerCountryCode,
                                                                                          entity.CabProgram,
                                                                                          entity.IRD,
                                                                                          entity.PosTerminalInputCapability,
                                                                                          entity.CardDataInputMode,
                                                                                          entity.CardholderPresentData,
                                                                                          entity.CardPresentData.Value,
                                                                                          entity.CardholderAuthCapability.Value,
                                                                                          entity.CardholderAuthMethod.Value,
                                                                                          entity.ICC,
                                                                                          entity.TimelinessDays.Value,
                                                                                          entity.ServiceCode,
                                                                                          entity.AccFundingSource,
                                                                                          entity.ProductType,
                                                                                          entity.CardProgIdentifier,
                                                                                          entity.GCMSProductIdentifier,
                                                                                          entity.MTI,
                                                                                          entity.FunctionCode,
                                                                                          entity.ProcessingCode,
                                                                                          entity.ApprovalCode,
                                                                                          entity.CorporateCardCommonData,
                                                                                          entity.CorporateLineItemDetail);
            }
            return interchangeCostingParametersEntity;
        }

        protected override CostInterchangeParamMastercardEntity dbCostInterchangeParamMastercardCreate(CostInterchangeParamMastercardEntity entity)
        {
            entity.Id = costInterchangeParamMastercardDAO.create(entity);
            return entity;
        }

        public CostInterchangeParamMastercard loadCostInterchangeParamMastercardById(long interchangeCostingParametersId)
        {
            CostInterchangeParamMastercardEntity entity = costInterchangeParamMastercardDAO.find(interchangeCostingParametersId);
            return costInterchangeParamMastercardFromRep(entity);
        }

        protected CostInterchangeParamVisaEntity costInterchangeParamVisaEntityFromBuilder(CostInterchangeParamVisaBuilder builder)
        {
            CostInterchangeParamVisaEntity entity = new CostInterchangeParamVisaEntity();

            entity.Id = builder.getId();
            entity.TranRef = builder.getTranRef();
            entity.Amount = builder.getAmount();
            entity.CurrencyCode = builder.getCurrencyCode();
            entity.Date = builder.getDate();
            entity.MerchantCountryCode = builder.getMerchantCountryCode();
            entity.MCC = builder.getMCC();
            entity.IssuerCountryCode = builder.getIssuerCountryCode();
            entity.AFS = builder.getAFS();
            entity.ATI = builder.getATI();
            entity.AuthCharac = builder.getAuthCharac();
            entity.AuthCode = builder.getAuthCode();
            entity.AuthRespCode = builder.getAuthRespCode();
            entity.BusinessApplicationIdentifier = builder.getBusinessApplicationIdentifier();
            entity.CardCapabilityFlag = builder.getCardCapabilityFlag();
            entity.CardholderIdMethod = builder.getCardholderIdMethod();
            entity.ChipTerminalDeploymentFlag = builder.getChipTerminalDeploymentFlag();
            entity.CVVResult = builder.getCVVResult();
            entity.DCCI = builder.getDCCI();
            entity.FeeScenario = builder.getFeeScenario();
            entity.FPI = builder.getFPI();
            entity.MotoEci = builder.getMotoEci();
            entity.PID = builder.getPID();
            entity.PosEntryMode = builder.getPosEntryMode();
            entity.PosEnvCode = builder.getPosEnvCode();
            entity.PosTerminalCapability = builder.getPosTerminalCapability();
            entity.ProductSubtype = builder.getProductSubtype();
            entity.ProductType = builder.getProductType();
            entity.ReimbAttr = builder.getReimbAttr();
            entity.RequestedPaymentService = builder.getRequestedPaymentService();
            entity.TimelinessDays = builder.getTimelinessDays();

            return entity;
        }

        protected CostInterchangeParamVisa costInterchangeParamVisaFromRep(CostInterchangeParamVisaEntity entity)
        {
            CostInterchangeParamVisa interchangeCostingParametersEntity = null;
            if (entity != null)
            {
                interchangeCostingParametersEntity = new CostInterchangeParamVisaImpl(entity.Id.Value,
                                                                                      entity.TranRef,
                                                                                      entity.Amount.Value,
                                                                                      entity.CurrencyCode,
                                                                                      entity.Date,
                                                                                      entity.MerchantCountryCode,
                                                                                      entity.MCC.Value,
                                                                                      entity.IssuerCountryCode,
                                                                                      entity.AFS,
                                                                                      entity.ATI,
                                                                                      entity.AuthCharac,
                                                                                      entity.AuthCode,
                                                                                      entity.AuthRespCode,
                                                                                      entity.BusinessApplicationIdentifier,
                                                                                      entity.CardCapabilityFlag,
                                                                                      entity.CardholderIdMethod,
                                                                                      entity.ChipTerminalDeploymentFlag,
                                                                                      entity.CVVResult,
                                                                                      entity.DCCI,
                                                                                      entity.FeeScenario,
                                                                                      entity.FPI,
                                                                                      entity.MotoEci,
                                                                                      entity.PID,
                                                                                      entity.PosEntryMode,
                                                                                      entity.PosEnvCode,
                                                                                      entity.PosTerminalCapability,
                                                                                      entity.ProductSubtype,
                                                                                      entity.ProductType,
                                                                                      entity.ReimbAttr,
                                                                                      entity.RequestedPaymentService,
                                                                                      entity.TimelinessDays.Value);
            }
            return interchangeCostingParametersEntity;
        }

        protected override CostInterchangeParamVisaEntity dbCostInterchangeParamVisaCreate(CostInterchangeParamVisaEntity entity)
        {
            entity.Id = costInterchangeParamVisaDAO.create(entity);
            return entity;
        }

        public CostInterchangeParamVisa loadCostInterchangeParamVisaById(long costInterchangeParamVisaId)
        {
            CostInterchangeParamVisaEntity entity = costInterchangeParamVisaDAO.find(costInterchangeParamVisaId);
            return costInterchangeParamVisaFromRep(entity);
        }

        // Scheme costs
        protected CostSchemeParamMastercardEntity costSchemeParamMastercardEntityFromBuilder(CostSchemeParamMastercardBuilder builder)
        {
            CostSchemeParamMastercardEntity entity = new CostSchemeParamMastercardEntity();

            entity.Id = builder.getId();
            entity.TranRef = builder.getTranRef();
            entity.Amount = builder.getAmount();
            entity.CurrencyCode = builder.getCurrencyCode();
            entity.Date = builder.getDate();
            entity.MerchantCountryCode = builder.getMerchantCountryCode();
            entity.IssuerCountryCode = builder.getIssuerCountryCode();
            return entity;
        }

        protected CostSchemeParamMastercard costSchemeParamMastercardFromRep(CostSchemeParamMastercardEntity entity)
        {
            CostSchemeParamMastercard schemeCostingParametersEntity = null;

            if (entity != null)
            {
                schemeCostingParametersEntity = new CostSchemeParamMastercardImpl(entity.Id.Value,
                                                                                  entity.TranRef,
                                                                                  entity.Amount.Value,
                                                                                  entity.CurrencyCode,
                                                                                  entity.Date,
                                                                                  entity.MerchantCountryCode,
                                                                                  entity.IssuerCountryCode);
            }

            return schemeCostingParametersEntity;
        }

        protected override CostSchemeParamMastercardEntity dbCostSchemeParamMastercardCreate(CostSchemeParamMastercardEntity entity)
        {
            entity.Id = costSchemeParamMastercardDAO.create(entity);
            return entity;
        }

        public CostSchemeParamMastercard loadCostSchemeParamMastercardById(long costSchemeParamMastercardId)
        {
            CostSchemeParamMastercardEntity entity = costSchemeParamMastercardDAO.find(costSchemeParamMastercardId);
            return costSchemeParamMastercardFromRep(entity);
        }

        // Visa
        protected CostSchemeParamVisaEntity costSchemeParamVisaEntityFromBuilder(CostSchemeParamVisaBuilder builder)
        {
            CostSchemeParamVisaEntity entity = new CostSchemeParamVisaEntity();

            entity.Id = builder.getId();
            entity.TranRef = builder.getTranRef();
            entity.Amount = builder.getAmount();
            entity.CardType = builder.getCardType();
            entity.Currency = builder.getCurrencyCode();
            entity.Date = builder.getDate();
            entity.MerchantCountry = builder.getMerchantCountryCode();
            entity.IssuerCountry = builder.getIssuerCountryCode();
            return entity;
        }

        protected CostSchemeParamVisa costSchemeParamVisaFromRep(CostSchemeParamVisaEntity entity)
        {
            CostSchemeParamVisa schemeCostingParametersEntity = null;

            if (entity != null)
            {
                schemeCostingParametersEntity = new CostSchemeParamVisaImpl(entity.Id.Value,
                                                                            entity.TranRef,
                                                                            entity.Amount.Value,
                                                                            entity.CardType,
                                                                            entity.Currency,
                                                                            entity.Date,
                                                                            entity.MerchantCountry,
                                                                            entity.IssuerCountry);
            }

            return schemeCostingParametersEntity;
        }

        protected override CostSchemeParamVisaEntity dbCostSchemeParamVisaCreate(CostSchemeParamVisaEntity entity)
        {
            entity.Id = costSchemeParamVisaDAO.create(entity);
            return entity;
        }

        public CostSchemeParamVisa loadCostSchemeParamVisaById(long costSchemeParamVisaId)
        {
            CostSchemeParamVisaEntity entity = costSchemeParamVisaDAO.find(costSchemeParamVisaId);
            return costSchemeParamVisaFromRep(entity);
        }
    }
}