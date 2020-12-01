using System;

namespace datalayer.voicecommerce.model.card.impl
{
    public class CardNumberAbstract : CardNumber
    {
        private CardNumber_Type oBFUSCATED;
        private string obfCardNumber;

        public CardNumberAbstract(CardNumber_Type oBFUSCATED, string obfCardNumber)
        {
            this.oBFUSCATED = oBFUSCATED;
            this.obfCardNumber = obfCardNumber;
        }

        public string Number => throw new NotImplementedException();

        public CardNumber_Type Type => throw new NotImplementedException();
    }
}
