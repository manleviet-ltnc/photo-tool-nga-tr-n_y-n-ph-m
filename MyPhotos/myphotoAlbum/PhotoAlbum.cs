using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Manning.myphotoAlbum
{
    public class PhotoAlbum : BindingList<photograph>, IDisposable
    {
        public enum DescriptorOption { FileName, Caption, DateTaken }
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                HasChanged = true;
            }
        }
        private DescriptorOption _descriptor;
        public DescriptorOption PhotoDescriptor
        {
            get { return _descriptor; }
            set
            {
                _descriptor = value;
                HasChanged = true;
            }
        }

        public string GetDesciptorFormat()
        {
            switch (PhotoDescriptor )
            {
                case DescriptorOption.Caption: return "c";
                case DescriptorOption.DateTaken: return "d";
                case DescriptorOption.FileName:
                default:
                    return "f";
            }
        }
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
        public PhotoAlbum()
        {
            ClearSettings();
        }
        public photograph Add(string filename)
        {
            photograph p = new photograph(filename);
            base.Add(p);
            return p;
        }
        private void ClearSettings()
        {
            _title = null;
            _descriptor = DescriptorOption.Caption;
        }
        protected override void ClearItems()
        {
            if (Count > 0)
            {
                foreach (photograph p in this)
                    p.Modified -= photo_Modified;
                Dispose();
                base.ClearItems();
                HasChanged = true;
            }
        }
        protected override void InsertItem(int index, photograph item)
        {
            item.Modified += photo_Modified;
            base.InsertItem(index, item);
            HasChanged = true;
        }
        protected override void RemoveItem(int index)
        {
            photograph p = Items[index];
            p.Modified -= photo_Modified;
            base.RemoveItem(index);
            p.ReleaseImage();
            HasChanged = true;
        }
        protected override void SetItem(int index, photograph item)
        {
            item.Modified += photo_Modified;
            base.SetItem(index, item);
            HasChanged = true;
        }
        private void photo_Modified(object sender, EventArgs e)
        {
            photograph photo = sender as photograph;
            if (photo != null)
            {
                int index = IndexOf(photo);
                ResetItem(index);
            }
        }
        public void Dispose()
        {
            ClearSettings();
            foreach (photograph p in this)
                p.Dispose();
        }
        public string GetDescription(photograph photo)
        {
            switch (PhotoDescriptor)
            {
                case DescriptorOption.Caption:
                    return photo.Caption;
                case DescriptorOption.DateTaken:
                    return photo.DateTaken.ToShortDateString();
                case DescriptorOption.FileName:
                    return photo.FileName;
            }
            throw new ArgumentException( "Unrecognized photo descriptor option.");
        }
        public string GetDescription(int index)
        {
            return GetDescription(this[index]);
        }
    }

}
