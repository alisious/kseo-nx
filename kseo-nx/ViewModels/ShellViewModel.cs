using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class ShellViewModel :Conductor<Screen>.Collection.OneActive
    {

        public ShellViewModel()
        {
           BackToStartView();
        }

        public void BackToStartView()
        {
            DisplayName = "KSEO 2.0 - Strona startowa.";
            var ai = new StartPageViewModel {Parent = this};
            ActivateItem(ai);
        }

        public void ShowVerifications()
        {
            DisplayName = "KSEO 2.0 - Wyszukiwanie osoby.";
            var ai = new PersonSearchViewModel() { Parent = this };
            ActivateItem(ai);
        }

        public void CloseApplication()
        {
            this.TryClose();
        }
    }
}
