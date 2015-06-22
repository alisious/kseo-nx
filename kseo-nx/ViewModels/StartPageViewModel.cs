using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class StartPageViewModel :Screen
    {
        public void Close()
        {
            
        }

        public void CheckPerson()
        {
            if (this.Parent!=null)
                (this.Parent as ShellViewModel).ShowVerifications();
        }
    }
}
