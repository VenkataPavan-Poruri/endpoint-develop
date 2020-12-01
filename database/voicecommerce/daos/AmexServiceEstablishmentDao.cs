using database.voicecommerce.domain;
using System.Collections.Generic;

namespace database.voicecommerce.daos
{
    public interface AmexServiceEstablishmentDao
    {
        AmexServiceEstablishmentEntity findByCurrency(string currency);
        IList<AmexServiceEstablishmentEntity> findAll();
        AmexServiceEstablishmentEntity findByCurrency(object currencyCode);
    }
}