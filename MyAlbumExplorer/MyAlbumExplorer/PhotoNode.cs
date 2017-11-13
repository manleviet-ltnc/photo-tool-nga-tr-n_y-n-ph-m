using System;
using System.IO;
using System.Windows.Forms;
using Manning.myphotoAlbum;

namespace MyAlbumExplorer
{
    internal class PhotoNode : TreeNode, IRefreshableNode
    {
        private photograph _photo;
        public photograph Photograph
        {
            get { return _photo; }
        }
        public PhotoNode (photograph photo ) : base ()
        {
            if (photo == null)
                throw new ArgumentException("photo");
            _photo = photo;
            Text = photo.Caption;
            ImageKey = "Photo";
            SelectedImageKey = "Photo";
        }
        public void RefreshNode()
        {
            Text = Photograph.Caption;
        }
    }
}
