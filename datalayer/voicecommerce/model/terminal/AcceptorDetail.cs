namespace datalayer.voicecommerce.model.terminal
{
    public interface AcceptorDetail
	{

		long Id { get; }

		string Name { get; }

		string Street { get; }

		string City { get; }

		string State { get; }

		string PostalCode { get; }

		string CustomerServicePhoneNumber { get; }

		string SubMerchantId { get; }

		string CustomerServiceEmail { get; }
	}
}
