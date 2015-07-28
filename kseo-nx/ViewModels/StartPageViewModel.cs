using System;
using System.Collections.Generic;
using System.Dynamic;
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

        public void NewProvision()
        {
            if (this.Parent != null)
                (this.Parent as ShellViewModel).NewProvision();
        }

        public void NewPerson()
        {
            if (this.Parent != null)
                (this.Parent as ShellViewModel).NewPerson();
        }

        public void EditPersonFile()
        {
            var windowManager = IoC.Get<IWindowManager>();
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settings.WindowStyle = WindowStyle.ToolWindow;
            settings.WindowsState = WindowState.Maximized;
            var vm = new PersonFileViewModel(Guid.Empty) { DisplayName = "Kartoteka osoby." };
            windowManager.ShowDialog(vm, null, settings);
            
        }

    }
}
