using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using kseo_nx.Model;

namespace kseo_nx.ViewModels
{
    
    public class ShellViewModel :Conductor<Screen>.Collection.OneActive,IShell
    {
        
        public ShellViewModel()
        {
           BackToStartView();
           NotifyOfPropertyChange(()=>UserName);
           NotifyOfPropertyChange(()=>DateOfOperations);
        }

        public string UserName
        {
            get { return Environment.UserName; }
        }

        public string DateOfOperations
        {
            get { return DateTime.Today.ToShortDateString(); }
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

        public void NewProvision()
        {
            DisplayName = "KSEO 2.0 - Nowe zabezpieczenie.";
            var ai = new ReservationWizardViewModel() { Parent = this };
            ActivateItem(ai);
        }

        public void NewPerson()
        {
            DisplayName = "KSEO 2.0 - Nowa osoba.";
            var ai = new RequestViewModel(UserName,RequestType.Create) { Parent = this };
            ActivateItem(ai);
        }

        public void EditPersonFile()
        {
            DisplayName = "KSEO 2.0 - Kartoteka osoby.";
            var ai = new PersonFileViewModel(Guid.Parse("e48c73a7-4dd9-4e78-9612-39f944d4d833")) { Parent = this };
            ActivateItem(ai);
        }


        public void CloseApplication()
        {
            this.TryClose();
        }
    }
}
