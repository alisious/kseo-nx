using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace kseo_nx.Helpers
{
    public class CheckedList<T> :BindableCollection<CheckedListItem<T>>
    {
        public CheckedList(IEnumerable<T> items)
        {
            foreach (var i in items)
            {
               Add(new CheckedListItem<T>(){Item = i});
            }
        }


        public void SelectAll()
        {
            foreach (var i in this)
            {
                i.Selected = true;
            }
        }

        public void UnselectAll()
        {
            foreach (var i in this)
            {
                i.Selected = false;
            }
        }

        public void Select(T item)
        {
            foreach (var i in this.Where(i => i.Item.ToString() == item.ToString()))
            {
                i.Selected = true;
            }
        }

        public void Unselect(T item)
        {
            foreach (var i in this.Where(i => i.Item.ToString() == item.ToString()))
            {
                i.Selected = false;
            }
        }

        public void Select(T[] items)
        {
            foreach (var i in items)
            {
                Select(i);
            }
        }


        public void SelectFromLine(string itemsInLine)
        {
            Contract.Requires(itemsInLine!=null);
            var l = itemsInLine.Replace(", ",",").Split(',').ToList();
            foreach (var i in l.SelectMany(s => this.Where(i => i.Item.ToString() == s)))
            {
                i.Selected = true;
            }
        }

        public void Unselect(T[] items)
        {
            Contract.Requires(items!=null);
            foreach (var i in items)
            {
                Unselect(i);
            }
        }

        public List<T> GetSelected()
        {
            return (from i in this where i.Selected select i.Item).ToList();
        }

        public List<T> GetUnselected()
        {
            return (from i in this where !i.Selected select i.Item).ToList();
        }

        public string GetSelectedInLine()
        {
            return String.Join(", ", GetSelected());
        }

        public string GetUnelectedInLine()
        {
            return String.Join(", ", GetUnselected());
        }

        
    }
}
