using System.Collections.Generic;

namespace database.voicecommerce.daos
{

	using SessionFactory = org.hibernate.SessionFactory;
	using Logger = org.slf4j.Logger;
	using LoggerFactory = org.slf4j.LoggerFactory;
	using Repository = org.springframework.stereotype.Repository;
	using Propagation = org.springframework.transaction.annotation.Propagation;
	using Transactional = org.springframework.transaction.annotation.Transactional;

	using AmexServiceEstablishmentEntity = database.voicecommerce.daos.AmexServiceEstablishmentEntity;
	using AmexServiceEstablishmentEntityImpl = database.voicecommerce.daos.AmexServiceEstablishmentEntityImpl;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Repository public class AmexServiceEstablishmentDaoImpl extends TxnlDAOBase<database.voicecommerce.daos.AmexServiceEstablishmentEntity, database.voicecommerce.daos.AmexServiceEstablishmentEntityImpl, long> implements AmexServiceEstablishmentDao
	public class AmexServiceEstablishmentDaoImpl : TxnlDAOBase<AmexServiceEstablishmentEntity, AmexServiceEstablishmentEntityImpl, long>, AmexServiceEstablishmentDao
	{

		private static readonly Logger LOGGER = LoggerFactory.getLogger(typeof(AmexServiceEstablishmentDaoImpl));

//JAVA TO C# CONVERTER WARNING: 'final' parameters are ignored unless the option to convert to C# 7.2 'in' parameters is selected:
//ORIGINAL LINE: public AmexServiceEstablishmentDaoImpl(final org.hibernate.SessionFactory sessionFactory)
		public AmexServiceEstablishmentDaoImpl(SessionFactory sessionFactory) : base(sessionFactory, null)
		{
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Transactional(propagation = org.springframework.transaction.annotation.Propagation.REQUIRED, readOnly = true) public database.voicecommerce.daos.AmexServiceEstablishmentEntity findByCurrency(final String currency)
//JAVA TO C# CONVERTER WARNING: 'final' parameters are ignored unless the option to convert to C# 7.2 'in' parameters is selected:
		public virtual AmexServiceEstablishmentEntity findByCurrency(string currency)
		{
			IList<QueryParam> queryParams = new List<QueryParam>();
			queryParams.Add(new QueryParam("currency", currency));
			return fetchSingleResult(AmexServiceEstablishmentEntityImpl.QUERY_FindByCurrency, queryParams);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Transactional(propagation = org.springframework.transaction.annotation.Propagation.REQUIRED, readOnly = true) public java.util.List<database.voicecommerce.daos.AmexServiceEstablishmentEntity> findAll()
		public virtual IList<AmexServiceEstablishmentEntity> findAll()
		{
			return fetchAll(AmexServiceEstablishmentEntityImpl.QUERY_FindAll);
		}

		protected internal override Logger Logger
		{
			get
			{
				return LOGGER;
			}
		}
	}

}