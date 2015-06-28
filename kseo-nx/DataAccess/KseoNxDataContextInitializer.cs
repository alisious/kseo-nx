using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kseo_nx.DataAccess
{
    public class KseoNxDataContextInitializer : DropCreateDatabaseIfModelChanges<KseoNxDataContext> //DropCreateDatabaseAlways<KseoContext>//
    {
        protected override void Seed(KseoNxDataContext context)
        {

        }
    }
}
