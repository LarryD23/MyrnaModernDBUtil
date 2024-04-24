using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace MyrnaLoyDB_Final
{
    public class MyrnaLoyDBUtil
    {
        DatabaseProviderFactory factory;
        SqlDatabase sqlDB;

        public MyrnaLoyDBUtil()
        {
            factory = new DatabaseProviderFactory();
            sqlDB = (SqlDatabase)factory.CreateDefault();
        }

        public IEnumerable<GetFutureShows> GetFutureShows(DateTime dateLimit)
        {
            List<GetFutureShows> futureShows = new List<GetFutureShows>();

            using (DbCommand sprocCmd = sqlDB.GetStoredProcCommand("GetFutureShows"))
            {
                if (dateLimit > DateTime.Now)
                    sqlDB.AddInParameter(sprocCmd, "@FutureDate", DbType.DateTime, dateLimit);
                else
                    sqlDB.AddInParameter(sprocCmd, "@FutureDate", DbType.DateTime, DBNull.Value);
                using (IDataReader sprocReader = sqlDB.ExecuteReader(sprocCmd))
                {
                    while (sprocReader.Read())
                    {
                        GetFutureShows nextFutureShow = new GetFutureShows();
                        try
                        {
                            nextFutureShow.ShowTitle = sprocReader.GetString(0);
                            nextFutureShow.ShowDate = sprocReader.GetDateTime(1);

                            futureShows.Add(nextFutureShow);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception" + ex.Message);
                        }
                    }


                }

            }
            return futureShows;


        }
    }
}
