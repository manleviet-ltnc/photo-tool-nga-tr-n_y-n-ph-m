﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Manning.myphotoAlbum;

namespace Manning.MyPhotoControls
{
    public partial class PhotoEditDialog : Manning.MyPhotoControls.BaseEditDialog
    {
        private photograph _photo;
        private photograph  Photo
        {
            get { return _photo; }
        }

        private Albummanager _manager = null;
        private Albummanager Manager
        {
            get { return _manager; }
        }

        protected  PhotoEditDialog()
        {
            InitializeComponent();
        }
        public PhotoEditDialog(photograph photo) : this()
        {
            if (photo == null)
                throw new ArgumentNullException(" The photo parameter cannot be null");

            InitializeDialog(photo);
        }
                public PhotoEditDialog(Albummanager mgr) : this()
                    {
                    if (mgr == null)
                        throw new ArgumentNullException("The mgr parameter cannot be null");
                    _manager = mgr;
                    InitializeDialog(mgr.Current);

               
        }

        private void InitializeDialog(photograph photo)
        {
            _photo = Photo;
            ResetDialog();
            mskDateTaken.ValidatingType = typeof(CurrentDate);
        }

        protected override void ResetDialog()
        {
            photograph photo = Photo;
            if (photo != null)
            {
                txtphotoFile.Text = photo.FileName;
                txtCaption.Text = photo.Caption;
                mskDateTaken.Text = photo.DateTaken.ToString();
                txtphotoGrapher.Text = photo.Photographer;
                txtNotes.Text = photo.Notes;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
         
            if (DialogResult == DialogResult.OK)
                SaveSetting();

        }
        private void SaveSetting()
        {
            photograph photo = Photo;
            if (photo != null)
            {
                photo.Caption = txtCaption.Text;
                photo.Photographer = txtphotoGrapher.Text;
                photo.Notes = txtNotes.Text;
                try
                {
                    photo.DateTaken = DateTime.Parse(mskDateTaken.Text);
                }
                catch (FormatException) { }
            }
        }

        private void txtCaption_TextChanged(object sender, EventArgs e)
        {
            Text = txtCaption.Text + " - Properties";
        }

        private static class CurrentDate
        {
            public static DateTime Parse(string input)
            {
                DateTime result = DateTime.Parse(input);
                if (result > DateTime.Now)
                    throw new FormatException("The given date is in the future.");

                return result;

            }


        }

        private void mskDateTaken_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                DialogResult result = MessageBox.Show("The Date Taken entry is invalid or"
                                                       + "in the future and may be ignored."
                                                       + "Do you wish to correct this?",
                                                       "Photo Properties",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);
                e.Cancel = (result == DialogResult.Yes);
            }
        }
    }


}