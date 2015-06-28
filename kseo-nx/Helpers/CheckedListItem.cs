using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kseo_nx.Helpers
{
    public class CheckedListItem<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _selected;
        private T _item;

        public CheckedListItem()
        { }

        public CheckedListItem(T item, bool selected = false)
        {
            this._item = item;
            this._selected = selected;
        }

        public T Item
        {
            get { return _item; }
            set
            {
                _item = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Item"));
            }
        }


        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Selected"));
            }
        }
    }
}
