using datalayer.voicecommerce.entity.authorisation;
using datalayer.voicecommerce.entity.scheme;
using datalayer.voicecommerce.model.sale;
using endpoint_api.voicecommerce.api;
using System;
using System.Collections.Generic;
using System.Text;
using static datalayer.voicecommerce.model.sale.SaleRepo;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostContextImpl : SalePostContext
    {
        private SalePostRequest request;
        private readonly SalePostResponse response;

        public SaleBuilder saleBuilder;

        private SaleRepo.SaleAuthorisationResponseBuilder saleRespBuilder;

        private Scheme scheme;

        private ActionStatistics terminalCardStats;
        private ActionStatistics terminalSchemeStats;

        public SaleRepo SaleBuilder { get; set; }

        public virtual Scheme getScheme()
        {
            return scheme;
        }


        public virtual void setSaleBuilder(SaleRepo.SaleBuilder builder)
        {
            if (saleBuilder != null)
            {
                throw new Exception("Attempt to set builder twice");
            }
            saleBuilder = builder;
        }

        public SalePostContextImpl(SalePostRequest request, SalePostResponse response)
        {

            this.request = request;
            this.response = response;
        }


        public virtual SalePostRequest Request
        {
            get
            {
                return request;
            }
            set
            {
                request = value;
            }
        }


        public virtual SalePostResponse Response
        {
            get
            {
                return response;
            }
        }

        //public virtual SaleRepo SaleBuilder
        //{
        //    get
        //    {
        //        return saleBuilder_Conflict;
        //    }
        //    set
        //    {
        //        saleBuilder_Conflict = value;
        //    }
        //}


        public SaleRepo.SaleBuilder saleBuild()
        {
            return saleBuilder;
        }

        public virtual Sale Sale
        {
            get
            {
                Sale sale = null;
                SaleRepo.SaleBuilder builder = saleBuild();

                if (builder != null)
                {
                    sale = builder.createdSale();
                }
                return sale;
            }
        }

        public virtual SaleRepo.SaleAuthorisationResponseBuilder responseBuilder()
        {
            if (saleRespBuilder == null)
            {
                saleRespBuilder = saleBuilder.responseBuilder();
            }
            return saleRespBuilder;
        }

        public virtual SaleAuthorisationResponse SaleResponse
        {
            get
            {
                SaleAuthorisationResponse saleResp = null;
                SaleRepo.SaleAuthorisationResponseBuilder respBuilder = responseBuilder();

                if (respBuilder != null)
                {
                    saleResp = respBuilder.createdResponse();
                }

                return saleResp;
            }
        }


        public virtual Scheme Scheme
        {
            set
            {

                scheme = value;
            }
            get
            {
                return scheme;
            }
        }




        public virtual void setTerminalStatistics(ActionStatistics cardStats, ActionStatistics schemeStats)
        {
            terminalCardStats = cardStats;
            terminalSchemeStats = schemeStats;
        }

        public void setTerminalStatistics(object cardStatistics, object schemeStatistics)
        {
            throw new NotImplementedException();
        }

        public virtual ActionStatistics TerminalCardStatistics
        {
            get
            {
                return terminalCardStats;
            }
        }


        public virtual ActionStatistics TerminalSchemeStatitics
        {
            get
            {
                return terminalSchemeStats;
            }
        }

        //SalePostRequest SalePostContext.Request { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        SalePostResponse SalePostContext.Response
        {
            get => throw new NotImplementedException(); set => throw new NotImplementedException();
        }
        //SaleRepo SalePostContext.SaleBuilder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //Sale SalePostContext.Sale { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //ActionStatistics SalePostContext.TerminalCardStatistics { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //ActionStatistics SalePostContext.TerminalSchemeStatitics { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual Sale getSale()
        {
            Sale sale = null;
            SaleRepo.SaleBuilder builder = saleBuild();

            if (builder != null)
            {
                sale = builder.createdSale();
            }
            if (sale == null)
            {
                throw new Exception("Attempt to retrieve Sale before created");
            }
            return sale;
        }
        public virtual ActionStatistics getTerminalCardStatistics()
        {
            return terminalCardStats;
        }


        public virtual ActionStatistics getTerminalSchemeStatitics()
        {
            return terminalSchemeStats;
        }

    }
}
