using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyrnaLoyDB_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            MyrnaLoyDBUtil myrnaLoyDBUtil = new MyrnaLoyDBUtil();
            IEnumerable<GetFutureShows> futureShows = myrnaLoyDBUtil.GetFutureShows(DateTime.Now);

            foreach (GetFutureShows fShow in futureShows)
            {
                Console.WriteLine("The Next Show : {0} is at {1} ", fShow.ShowTitle, fShow.ShowDate);
            }
            Console.ReadLine();
        }
    }
}
