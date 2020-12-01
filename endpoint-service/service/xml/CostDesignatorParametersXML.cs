using System;
using System.Collections.Generic;
using System.Text;

namespace endpoint_service.service.xml
{
    public class CostDesignatorParametersXML
    {
        private readonly string feeProgram;
        private readonly string description;
        private readonly string rateTier;

        public CostDesignatorParametersXML(string feeProgram, string description, string rateTier)
        {
            this.feeProgram = feeProgram;
            this.description = description;
            this.rateTier = rateTier;
        }


        public virtual string Program
        {
            get
            {
                return feeProgram;
            }
        }


        public virtual string Description
        {
            get
            {
                return description;
            }
        }


        public virtual string RateTier
        {
            get
            {
                return rateTier;
            }
        }
    }
}
