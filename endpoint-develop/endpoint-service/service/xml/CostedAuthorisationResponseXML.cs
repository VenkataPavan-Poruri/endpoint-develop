using System;
using System.Collections.Generic;
using System.Text;

namespace endpoint_service.service.xml
{
   public abstract class CostedAuthorisationResponseXML : AuthorisationResponseXML
    {
		public CostDesignatorParametersXML interchangeCostParameters;
		public CostDesignatorParametersXML transactionCostParameters;
        public CostedAuthorisationResponseXML(string apiResponseRef) : base(apiResponseRef)
        {
        }

        public virtual CostDesignatorParametersXML InterchangeCostParameters
		{
			get
			{
				return interchangeCostParameters;
			}
			set
			{
				this.interchangeCostParameters = value;
			}
		}




		public virtual CostDesignatorParametersXML TransactionCostParameters
		{
			get
			{
				return transactionCostParameters;
			}
		}


		public virtual CostDesignatorParametersXML TransactionDesingatorParameters
		{
			set
			{
				this.transactionCostParameters = value;
			}
		}
	}
}
