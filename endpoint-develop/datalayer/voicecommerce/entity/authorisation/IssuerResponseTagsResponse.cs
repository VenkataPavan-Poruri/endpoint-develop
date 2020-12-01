using datalayer.voicecommerce.common;

namespace datalayer.voicecommerce.entity.authorisation
{
    public interface IssuerResponseTagsResponse : CostedSchemeAuthorisationResponse
	{
		IssuerResponseTags IssuerResponseTags { get; }
	}
}
