namespace datalayer.voicecommerce.model.card
{
    public interface CardNumber
	{
		string Number { get; }
		CardNumber_Type Type { get; }
	}
	public enum CardNumber_Type
	{
		CLEARTEXT,
		ENCRYPTED,
		HASHED,
		OBFUSCATED

	}
}
