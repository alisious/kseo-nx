using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using kseo_nx.DataAccess;

namespace kseo_nx.ViewModels
{
    public abstract class ContextEditor :Screen
    {
        protected ContextEditor(KseoNxDataContext context)
        {
            Context = context;
        }

        public KseoNxDataContext Context { get; private set; }
        
    }
}
