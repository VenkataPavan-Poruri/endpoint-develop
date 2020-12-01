using core_develop.cashflows.common;
using core_develop.cashflows.core.common;
using System;

namespace datalayer.voicecommerce.model.card
{
    public interface PANRange
    {
		DateTime DateCreated { get; }

		DateTime DateUpdated { get; }

		long? LowerIIN { get; }

		long? UpperIIN { get; }

		//Country IssueCountry { get; }

		string SchemeProductId { get; }

		string DataSource { get; }

		int? Length { get; }

		bool? LuhnCheckNeeded { get; }

		bool? IssueNumberNeeded { get; }

		bool? StartDateNeeded { get; }

		char? ActiveInactiveCode { get; }

		AuthScheme Scheme { get; }

		string CardBrand { get; }

		char? Region { get; }

		long? BrandMappingId { get; }
		Country IssueCountry { get; }

        //bool acceptsPayments(PaymentType ofType);
    }
}
