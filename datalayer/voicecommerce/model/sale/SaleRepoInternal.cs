using datalayer.voicecommerce.model.card;
using System;
using System.Collections.Generic;
using System.Text;

namespace datalayer.voicecommerce.model.sale
{
    interface SaleRepoInternal : SaleRepo
    {
        // Temporary: Needs to be here whilst SaleRepo isn't split into Internal/External interfaces.
        //TerminalRepoInternal terminalRepo();

        CardRepo cardRepo();

        //List<SaleVoidAuthorisationResponse> findVoidResponsesBySale(long saleId) throws EndpointException;

        //VerifyRepoInternal verifyRepo();
    }
}
