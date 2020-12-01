using datalayer.voicecommerce.generators;
using datalayer.voicecommerce.model.card;
using datalayer.voicecommerce.model.card.impl;
using System.Text;

namespace endpoint_service.service.xml
{
    public class CardXML
    {
        public string cardNumber;
        public string cvv;
        public CardDatesXML cardDates;
        public AVSDataXML avsData;


        private static CardNumberObfuscator obfuscator = new CardNumberObfuscator();


        //public CardXML(string number,
        //                CardDatesXML cardDates, string cvv,
        //                AVSDataXML avsData)
        //{
        //    this.cardNumber = number;
        //    this.cardDates = cardDates;
        //    this.cvv = (cvv != null) && (cvv.Trim().Length > 0) ? cvv : null;
        //    this.avsData = avsData;
        //}


        public string getCardNumber()
        {
            return cardNumber;
        }


        public string getExpiryDate()
        {
            return cardDates.getExpriryDate();
        }


        public string getIssueDate()
        {
            return cardDates.getIssueDate();
        }


        public string getCVV()
        {
            return cvv;
        }


        public AVSDataXML getAVSData()
        {
            return avsData;
        }


        private CardNumber getObfuscatedCardNumber()
        {
            return new ObfuscatedCardNumber(obfuscator.obfuscateCardNumber(cardNumber));
        }



        //public string toString()
        //{
        //    return new StringBuilder(this).
        //           append("obfuscatedCardNumber", getObfuscatedCardNumber()).
        //           append("expiryDate", cardDates.getExpriryDate()).
        //           append("issueDate", cardDates.getIssueDate()).
        //           append("AVS", avsData).
        //           append("CVV", (cvv != null) ? cvv.replaceAll("[0-9]", "*") : null).
        //           toString();
        //}
    }
}
