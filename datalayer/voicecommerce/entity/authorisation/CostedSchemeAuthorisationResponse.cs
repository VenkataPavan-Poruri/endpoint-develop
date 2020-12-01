using datalayer.voicecommerce.entity.costing;

namespace datalayer.voicecommerce.entity.authorisation
{
    public interface CostedSchemeAuthorisationResponse : SchemeAuthorisationResponse
	{

		CostDesignatorParameters CostDesignatorParameters { get; }

	}
}
