using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manning.myphotoAlbum
{
    public class PhotoAlbum : Collection<photograph>, IDisposable
    {
        private bool _hasChanged = false;
        public bool HasChanged
        {
            get
            {
                if (_hasChanged) return true;
                foreach (photograph p in this)
                    if (p.HasChanged) return true;
                return false;
            }
            set
            {
                _hasChanged = value;
                if (value == false)
                    foreach (photograph p in this)

                        p.HasChanged = false;
            }
        }
        public photograph Add(string filename)
        {
            photograph p = new photograph(filename);
            base.Add(p);
            return p;
        }
        protected override void ClearItems()
        {
            if (Count > 0)
            {
                Dispose();
                base.ClearItems();
                HasChanged = true;
            }
        }
        protected override void InsertItem(int index, photograph item)
        {
            base.InsertItem(index, item);
            HasChanged = true;
        }
        protected override void RemoveItem(int index)
        {
            Items[index].Dispose();
            base.RemoveItem(index);
            HasChanged = true;
        }
        protected override void SetItem(int index, photograph item)
        {
            base.SetItem(index, item);
            HasChanged = true;
        }
       public void Dispose ()
        {
            foreach (photograph p in this)
                p.Dispose();
        }
    }

}
