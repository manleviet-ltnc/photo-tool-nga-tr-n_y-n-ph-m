﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manning.myphotoAlbum;
using Manning.MyPhotoControls;


namespace MyPhotos
{
    public partial class MainForm : Form
    {
        private Albummanager _manager;
        private Albummanager Manager
        {
            get
            {
                return _manager;
            }
            set
            {
                _manager = value;
                AssignSelectDropDown();
            }
        }

        private PixelDialog _dlgPixel = null;
        private PixelDialog PixelForm
        {
            get { return _dlgPixel; }
            set { _dlgPixel = value; }
        }

        internal ToolStrip MainToolStrip
        {
            get { return toolStripMain; }
        }

        public string AlbumPath
        {
            get { return Manager.FullName; }
        }

        public string AlbumTitle
        {
            get { return Manager.Album.Title; }
        }


        public MainForm()
        {
            InitializeComponent();
            NewAlbum();
        }

        public MainForm(string path, string pwd) : this()
        {
            Manager = new Albummanager(path, pwd);
        }
        private void NewAlbum()
        {
            if (Manager == null || SaveAndCloseAlbum())
            {
                Manager = new Albummanager();
                DisplayAlbum();
            }
        }
        private void DisplayAlbum()
        {
            pbxPhoto.Image = Manager.CurrentImage;
            SetTitleBar();
            SetStatusStrip(null);

            Point p = pbxPhoto.PointToClient(Form.MousePosition);
            UpdatePixelDialog(p.X, p.Y);
        }

        private void SetTitleBar()
        {
            Version ver = new Version(Application.ProductVersion);
            string name = Manager.FullName;
            Text = String.Format("{2} -MyPhotos {0:0}.{1:0}",
                ver.Major, ver.Minor, string.IsNullOrEmpty(name) ? "titled" : name);
        }


        private void mnuFileLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Photo";
            dlg.Filter = "jpg files (*.jpg)|*.jpg"
                          + "|All files (*.*)|*.*";


            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbxPhoto.Image = new Bitmap(dlg.OpenFile());
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Unable to load file: " + ex.Message);
                    pbxPhoto.Image = null;
                }
                SetStatusStrip(dlg.FileName);
            }
            dlg.Dispose();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuImage_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ProcessImageClick(e);
        }
        private void ProcessImageClick(ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            string enumVal = item.Tag as string;
            if (enumVal != null)
            {
                pbxPhoto.SizeMode = (PictureBoxSizeMode)Enum.Parse(typeof(PictureBoxSizeMode), enumVal);
            }
        }

        private void mnuImage_DropDownOpening(object sender, EventArgs e)
        {
            ProcessImageOpening(sender as ToolStripDropDownItem);
        }
        private void ProcessImageOpening(ToolStripDropDownItem parent)
        {
            if (parent != null)
            {
                string enumVal = pbxPhoto.SizeMode.ToString();
                foreach (ToolStripMenuItem item in parent.DropDownItems)
                {
                    item.Enabled = (pbxPhoto.Image != null);
                    item.Checked = item.Tag.Equals(enumVal);
                }
            }
        }
        private void SetStatusStrip(string path)
        {
            if (pbxPhoto.Image != null)
            {
                sttInfo.Text = Manager.Current.Caption;
                sttImageSize.Text = String.Format("{0:#}x{1:#}",
                                               pbxPhoto.Image.Width,
                                               pbxPhoto.Image.Height);
                sttAlbumPos.Text = string.Format("{0:0}/{1:0}",
                                                 Manager.Index + 1,
                                                 Manager.Album.Count);
            }
            else
            {
                sttInfo.Text = null;
                sttImageSize.Text = null;
                sttAlbumPos.Text = null;
            }

        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            NewAlbum();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            string path = null;
            string password = null;
            if (AlbumController.OpenAlbumDialog(ref path, ref password))
            {
                if (!SaveAndCloseAlbum())
                    return;


                try
                {
                    // open the new album
                    //TODO: handle invalid album file 
                    Manager = new Albummanager(path, password);
                }
                catch (AlbumStorageException aex)
                {
                    string msg = String.Format("Unable to open album file {0}\n({1})",
                                              path, aex.Message);
                    MessageBox.Show(msg, "Unable to Open");
                    Manager = new Albummanager();
                }
                DisplayAlbum();
            }

        }
        private void SaveAlbum(string name)
        {
            try
            {
                Manager.Save(name, true);
            }
            catch (AlbumStorageException aex)
            {

                string msg = String.Format("Unable to save album {0} ({1})\n\n"
                                            + "Do you wish to save the album"
                                            + "under a alternate name?",
                                             name, aex.Message);
                DialogResult result = MessageBox.Show(msg, "Unable to save",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Error,
                                                      MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                    SaveAsAlbum();
            }
        }
        private void SaveAlbum()
        {
            if (string.IsNullOrEmpty(Manager.FullName))
                SaveAsAlbum();
            else
            {
                //Save the album under the existing name
                SaveAlbum(Manager.FullName);
            }
        }
        private void SaveAsAlbum()
        {
            string path = null;
            if (AlbumController.SaveAlbumDialog(ref path))
            {
                SaveAlbum(path);
                //Update title bar to include new name
                SetTitleBar();
            }
        }
        private bool SaveAndCloseAlbum()
        {
            DialogResult result = AlbumController.AskForSave(Manager);

            if (result == DialogResult.Yes)
                SaveAlbum();
            else if (result == DialogResult.Cancel)
                return false;

            if (Manager.Album != null)
                Manager.Album.Dispose();

            Manager = new Albummanager();
            SetTitleBar();
            return true;
        }


        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            SaveAlbum();
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveAsAlbum();
        }

        private void mnuEditAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Add photos";
            dlg.Multiselect = true;
            dlg.Filter = "Image Files (JPEG, GIF, BMP, etc.)|"
                           + "*.jpg;*.jpeg;*.gif;*.bmp;"
                           + "*.tif;*.tiff;*.png|"
                           + "GIF files (*.gif)|*.gif|"
                           + "TIFF files (*.tif;*.tiff)|*.tif;*.tiff|"
                           + "PNG files (*.png)|*.png|"
                            + "All files (*.*)|*.*";
            dlg.InitialDirectory = Environment.CurrentDirectory;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string[] files = dlg.FileNames;
                int index = 0;
                foreach (string s in files)
                {
                    photograph photo = new photograph(s);
                    index = Manager.Album.IndexOf(photo);
                    if (index < 0)
                        Manager.Album.Add(photo);
                    else
                        photo.Dispose();
                }
                Manager.Index = Manager.Album.Count - 1;
            }
            dlg.Dispose();
            DisplayAlbum();
        }

        private void mnuEditRemove_Click(object sender, EventArgs e)
        {
            if (Manager.Album.Count > 0)
            {
                Manager.Album.RemoveAt(Manager.Index);
                DisplayAlbum();
            }

        }

        private void mnuNext_Click(object sender, EventArgs e)
        {
            if (Manager.Index < Manager.Album.Count - 1)
            {
                Manager.Index++;
                DisplayAlbum();
            }
        }

        private void mnuPrevious_Click(object sender, EventArgs e)
        {
            if (Manager.Index > 0)
            {
                Manager.Index--;
                DisplayAlbum();
            }
        }

        private void ctxMenuPhoto_Opening(object sender, CancelEventArgs e)
        {
            mnuNext.Enabled = (Manager.Index < Manager.Album.Count - 1);
            mnuPrevious.Enabled = (Manager.Index > 0);
            mnuPhotoProps.Enabled = (Manager.Current != null);
            mnuAlbumProps.Enabled = (Manager.Album != null);
            mnuSlideShow.Enabled = (Manager.Album != null && Manager.Album.Count > 0);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (SaveAndCloseAlbum() == false)
                e.Cancel = true;
            else
                e.Cancel = false;
            base.OnFormClosing(e);
        }

        private void mnuPixelData_Click(object sender, EventArgs e)
        {
            if (PixelForm == null || PixelForm.IsDisposed)
            {
                PixelForm = PixelDialog.GlobalInstance;
                PixelForm.Owner = this;

            }
            PixelForm.Show();

            Point p = pbxPhoto.PointToClient(Form.MousePosition);
            UpdatePixelDialog(p.X, p.Y);
            UpdatePixelButton(true);

        }
        private void UpdatePixelDialog(int x, int y)
        {
            if (IsMdiChild)
                PixelForm = PixelDialog.GlobalInstance;

            if (PixelForm != null && PixelForm.Visible)
            {
                Bitmap bmp = Manager.CurrentImage;
                PixelForm.Text = (Manager.CurrentImage == null) ? "Pixel Data " : Manager.Current.Caption;

                if (bmp == null || !pbxPhoto.DisplayRectangle.Contains(x, y))
                    PixelForm.ClearPixelData();
                else
                    PixelForm.UpdatePixelData(x, y, bmp,
                                              pbxPhoto.DisplayRectangle,
                                              new Rectangle(0, 0, bmp.Width, bmp.Height),
                                              pbxPhoto.SizeMode);


            }
        }

        private void pbxPhoto_MouseMove(object sender, MouseEventArgs e)
        {
            UpdatePixelDialog(e.X, e.Y);
        }

        private void mnuPhotoProps_Click(object sender, EventArgs e)
        {
            if (Manager.Current == null)
                return;

            using (PhotoEditDialog dlg = new PhotoEditDialog(Manager))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    DisplayAlbum();
            }
        }

        private void mnuAlbumProps_Click(object sender, EventArgs e)
        {
            if (Manager.Album == null)
                return;
            using (AlbumEditDialog dlg
            = new AlbumEditDialog(Manager))
            {
                if (dlg.ShowDialog()
                == DialogResult.OK)
                    DisplayAlbum();
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '+':
                    mnuNext.PerformClick();
                    e.Handled = true;
                    break;
                case '-':
                    mnuPrevious.PerformClick();
                    e.Handled = true;
                    break;
            }
            // Invoke the base method
            base.OnKeyPress(e);
        }
        private const int WM_KEYDOWN = 0x100;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.Msg == WM_KEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Tab:
                        mnuNext.PerformClick();
                        return true;

                    case Keys.Shift | Keys.Tab:
                        mnuPrevious.PerformClick();
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void mnuSlideShow_Click(object sender, EventArgs e)
        {
            using (SlideShowDialog dlg = new SlideShowDialog(Manager))
            {
                dlg.ShowDialog();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            this.tsbNew.Tag = mnuFileNew;
            this.tsbOpen.Tag = mnuFileOpen;
            this.tsbSave.Tag = mnuFileSave;
            this.tsbPrint.Tag = mnufilePrint;
            this.tsbCut.Tag = mnuEditCut;
            this.tsbCopy.Tag = mnuEditCopy;
            this.tsbPaste.Tag = MnuEditPaste;
            this.tsbHelp.Tag = mnuHelpAbout;

            this.tsbPrevious.Tag = mnuPrevious;
            this.tsbNext.Tag = mnuNext;

            toolStripMain.ImageList = imageListArrows;
            tsbPrevious.ImageIndex = 1;
            tsbNext.ImageIndex = 0;

            tsbAlbumProps.Tag = mnuAlbumProps;
            tsbPhotoProps.Tag = mnuPhotoProps;
            tsbPixelData.Tag = tsbPixelData.Image;

            tsdImage.DropDown = mnuImage.DropDown;

            if (IsMdiChild)
            {
                menuStrip1.Visible = false;
                DisplayAlbum();
            }
            if (this.IsMdiChild)
            {
                menuStrip1.Visible = false;
                toolStripMain.Visible = false;
                DisplayAlbum();
            }

            base.OnLoad(e);
        }

        private void tsb_Click(Object sender, EventArgs e)
        {
            // Ensure sender is a menu item
            ToolStripItem item = sender as ToolStripItem;
            if (item != null)
            {
                ToolStripMenuItem mi = item.Tag as ToolStripMenuItem;
                if (mi != null)
                    mi.PerformClick();
            }
        }

        private void tsbPixelData_Click(object sender, EventArgs e)
        {
            Form f = PixelForm;
            if (f == null || f.IsDisposed || !f.Visible)
                mnuPixelData.PerformClick();
            else
                f.Hide();
            UpdatePixelButton(PixelForm.Visible);
        }
        private void UpdatePixelButton(bool visible)
        {
            tsbPixelData.Checked = visible;

            if (visible)
                tsbPixelData.Image = tsbPixelData2.Image;
            else
                tsbPixelData.Image = (Image)tsbPixelData.Tag;
        }

        protected override void OnActivated(EventArgs e)
        {
            if (_dlgPixel != null)
                UpdatePixelButton(_dlgPixel.Visible);


            base.OnActivated(e);
        }

        private void AssignSelectDropDown()
        {
            ToolStripDropDown drop = new ToolStripDropDown();

            PhotoAlbum a = Manager.Album;
            for (int i = 0; i < a.Count; i++)
            {
                PictureBox box = new PictureBox();
                box.SizeMode = PictureBoxSizeMode.Zoom;
                box.Image = a[i].Image;
                box.Dock = DockStyle.Fill;

                ToolStripControlHost host = new ToolStripControlHost(box);
                host.AutoSize = false;
                host.Size = new Size(tssSelect.Width, tssSelect.Width);
                host.Tag = i;
                host.Click += delegate (object o, EventArgs e)
                {
                    int x = (int)(o as ToolStripItem).Tag;
                    Manager.Index = x;
                    drop.Close();
                    DisplayAlbum();
                };
                drop.Items.Add(host);
            }
            if (drop.Items.Count > 0)
            {
                tssSelect.DropDown = drop;
                tssSelect.DefaultItem = drop.Items[0];
            }

        }

        protected override void OnEnter(EventArgs e)
        {
            if (IsMdiChild)
                UpdatePixelButton( PixelDialog.GlobalInstance.Visible);
            base.OnEnter(e);
        }
    }

    }
    


