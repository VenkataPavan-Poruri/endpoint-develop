namespace datalayer.voicecommerce.model.card.impl
{
    public class ObfuscatedCardNumber : CardNumberAbstract
    {

        public ObfuscatedCardNumber(string obfCardNumber) : base(CardNumber_Type.OBFUSCATED, obfCardNumber)
        {
           // base.(CardNumber_Type.OBFUSCATED, obfCardNumber);
        }
    }
}
