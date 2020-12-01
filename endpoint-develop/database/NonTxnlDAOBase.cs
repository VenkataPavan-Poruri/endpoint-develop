using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace database
{
    public abstract class NonTxnlDAOBase
    {
        public DbConnection GetDbconnection()
        {
            return new SqlConnection(GlobalAppSettings.ConnectionString);
        }

        public T fetchSingleResult<T>(string fetchQuery, DynamicParameters parameters)
        {
            T instance;

            //Query query = buildQueryWithParams(fetchQuery, parameters);
            using (IDbConnection connection = GetDbconnection())
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    instance = connection.QueryFirstOrDefault<T>(fetchQuery, parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception e)   //(NonUniqueResultException e)
                {
                    //getLogger().error("Non-unique result for '" + fetchQuery + "', with params: " + parameters.ToString());
                    throw e;
                }
            }

            return instance;
        }

        public T fetchSingleScalarAsNumber<T>(string query)
        {
            T instance;

            using (IDbConnection connection = GetDbconnection())
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    instance = connection.QuerySingleOrDefault<T>(query, null, commandType: CommandType.StoredProcedure);
                }
                catch (Exception e)   //(NonUniqueResultException e)
                {
                    //getLogger().error("Non-unique result for '" + fetchQuery + "', with params: " + parameters.ToString());
                    throw e;
                }
            }

            return instance;
        }

        public T fetchSingleScalarAsNumber<T>(string query, DynamicParameters parameters)
        {
            T instance;

            using (IDbConnection connection = GetDbconnection())
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    instance = connection.QuerySingleOrDefault<T>(query, parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception e)   //(NonUniqueResultException e)
                {
                    //getLogger().error("Non-unique result for '" + fetchQuery + "', with params: " + parameters.ToString());
                    throw e;
                }
            }

            return instance;
        }

        public long save<T>(string query, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            long id;

            using (IDbConnection connection = GetDbconnection())
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var tran = connection.BeginTransaction();
                    try
                    {
                        id = connection.QuerySingle<long>(query, parameters, commandType: commandType, transaction: tran);
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return id;

            //ID id = (ID)getCurrentSession().save(entity);
            //getCurrentSession().flush();
            //getCurrentSession().evict(entity);
            //getLogger().info("Saved object " + entity);
        }

        //public long update<T>(string query, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        //{
        //    long id;

        //    using (IDbConnection db = GetDbconnection())
        //    {
        //        try
        //        {
        //            if (db.State == ConnectionState.Closed)
        //                db.Open();

        //            var tran = db.BeginTransaction();

        //            try
        //            {
        //                id = db.QueryFirstOrDefault<long>(query, parameters, commandType: commandType, transaction: tran);
        //                tran.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                tran.Rollback();
        //                throw ex;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }

        //    return id;

        //    //ID id = (ID)getCurrentSession().save(entity);
        //    //getCurrentSession().flush();
        //    //getCurrentSession().evict(entity);
        //    //getLogger().info("Saved object " + entity);
        //}

        protected List<T> fetchAll<T>(string fetchAllQuery)
        {
            List<T> results = null;

            using (IDbConnection db = GetDbconnection())
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    results = db.Query<T>(fetchAllQuery, null, commandType: CommandType.StoredProcedure).ToList();
                }
                catch (Exception e)   //(NonUniqueResultException e)
                {
                    //getLogger().error("Non-unique result for '" + fetchQuery + "', with params: " + parameters.ToString());
                    throw e;
                }
            }

            return results;
        }

        public List<T> fetch<T>(string fetchQuery, DynamicParameters parameters)
        {
            List<T> result;

            //Query query = buildQueryWithParams(fetchQuery, parameters);
            using (IDbConnection connection = GetDbconnection())
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    result = connection.Query<T>(fetchQuery, parameters, commandType: CommandType.StoredProcedure).ToList();
                }
                catch (Exception e)   //(NonUniqueResultException e)
                {
                    //getLogger().error("Non-unique result for '" + fetchQuery + "', with params: " + parameters.ToString());
                    throw e;
                }
            }

            return result;
        }

        public long Delete<T>(string query, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            long id;

            using (IDbConnection connection = GetDbconnection())
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var tran = connection.BeginTransaction();
                    try
                    {
                        id = connection.QuerySingle<long>(query, parameters, commandType: commandType, transaction: tran);
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return id;

            //ID id = (ID)getCurrentSession().save(entity);
            //getCurrentSession().flush();
            //getCurrentSession().evict(entity);
            //getLogger().info("Saved object " + entity);
        }
    }
}