﻿namespace MyPhotoAlbumData
{
    partial class DataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAlbum = new System.Windows.Forms.ComboBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.pageAlbum = new System.Windows.Forms.TabPage();
            this.gridPhotoAlbum = new System.Windows.Forms.DataGridView();
            this.pagePhoto = new System.Windows.Forms.TabPage();
            this.pbxPhoto = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtPhotographer = new System.Windows.Forms.TextBox();
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.dtpDateTaken = new System.Windows.Forms.DateTimePicker();
            this.bsAlbum = new System.Windows.Forms.BindingSource(this.components);
            this.tcMain.SuspendLayout();
            this.pageAlbum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPhotoAlbum)).BeginInit();
            this.pagePhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAlbum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Album:";
            // 
            // cmbAlbum
            // 
            this.cmbAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAlbum.DropDownWidth = 500;
            this.cmbAlbum.FormattingEnabled = true;
            this.cmbAlbum.Location = new System.Drawing.Point(72, 13);
            this.cmbAlbum.Name = "cmbAlbum";
            this.cmbAlbum.Size = new System.Drawing.Size(237, 21);
            this.cmbAlbum.TabIndex = 1;
            this.cmbAlbum.SelectionChangeCommitted += new System.EventHandler(this.cmbAlbum_SelectionChangeCommitted);
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.Location = new System.Drawing.Point(347, 264);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.pageAlbum);
            this.tcMain.Controls.Add(this.pagePhoto);
            this.tcMain.Location = new System.Drawing.Point(16, 40);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(406, 218);
            this.tcMain.TabIndex = 4;
            // 
            // pageAlbum
            // 
            this.pageAlbum.Controls.Add(this.gridPhotoAlbum);
            this.pageAlbum.Location = new System.Drawing.Point(4, 22);
            this.pageAlbum.Name = "pageAlbum";
            this.pageAlbum.Padding = new System.Windows.Forms.Padding(3);
            this.pageAlbum.Size = new System.Drawing.Size(398, 155);
            this.pageAlbum.TabIndex = 0;
            this.pageAlbum.Text = "Album";
            this.pageAlbum.UseVisualStyleBackColor = true;
            // 
            // gridPhotoAlbum
            // 
            this.gridPhotoAlbum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPhotoAlbum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPhotoAlbum.Location = new System.Drawing.Point(3, 3);
            this.gridPhotoAlbum.Name = "gridPhotoAlbum";
            this.gridPhotoAlbum.Size = new System.Drawing.Size(392, 149);
            this.gridPhotoAlbum.TabIndex = 3;
            // 
            // pagePhoto
            // 
            this.pagePhoto.Controls.Add(this.dtpDateTaken);
            this.pagePhoto.Controls.Add(this.btnNext);
            this.pagePhoto.Controls.Add(this.btnPrevious);
            this.pagePhoto.Controls.Add(this.pbxPhoto);
            this.pagePhoto.Controls.Add(this.label6);
            this.pagePhoto.Controls.Add(this.label5);
            this.pagePhoto.Controls.Add(this.label4);
            this.pagePhoto.Controls.Add(this.txtNotes);
            this.pagePhoto.Controls.Add(this.txtPhotographer);
            this.pagePhoto.Controls.Add(this.txtCaption);
            this.pagePhoto.Controls.Add(this.label3);
            this.pagePhoto.Controls.Add(this.txtFileName);
            this.pagePhoto.Controls.Add(this.label2);
            this.pagePhoto.Location = new System.Drawing.Point(4, 22);
            this.pagePhoto.Name = "pagePhoto";
            this.pagePhoto.Padding = new System.Windows.Forms.Padding(3);
            this.pagePhoto.Size = new System.Drawing.Size(398, 192);
            this.pagePhoto.TabIndex = 1;
            this.pagePhoto.Text = "Photo";
            this.pagePhoto.UseVisualStyleBackColor = true;
            // 
            // pbxPhoto
            // 
            this.pbxPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxPhoto.Location = new System.Drawing.Point(20, 49);
            this.pbxPhoto.Name = "pbxPhoto";
            this.pbxPhoto.Size = new System.Drawing.Size(126, 96);
            this.pbxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxPhoto.TabIndex = 9;
            this.pbxPhoto.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "&Date Taken:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "&Notes:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Photographer:";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(181, 145);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(202, 41);
            this.txtNotes.TabIndex = 5;
            // 
            // txtPhotographer
            // 
            this.txtPhotographer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhotographer.Location = new System.Drawing.Point(258, 62);
            this.txtPhotographer.Name = "txtPhotographer";
            this.txtPhotographer.Size = new System.Drawing.Size(125, 20);
            this.txtPhotographer.TabIndex = 4;
            // 
            // txtCaption
            // 
            this.txtCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaption.Location = new System.Drawing.Point(258, 36);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(125, 20);
            this.txtCaption.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Caption:";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(91, 10);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(292, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "&File Name:";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrevious.Location = new System.Drawing.Point(6, 151);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 10;
            this.btnPrevious.Text = "Pre&vious";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.Location = new System.Drawing.Point(91, 151);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(73, 24);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = "Nex&t";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // dtpDateTaken
            // 
            this.dtpDateTaken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateTaken.Location = new System.Drawing.Point(258, 88);
            this.dtpDateTaken.Name = "dtpDateTaken";
            this.dtpDateTaken.Size = new System.Drawing.Size(125, 20);
            this.dtpDateTaken.TabIndex = 12;
            // 
            // bsAlbum
            // 
            this.bsAlbum.CurrentChanged += new System.EventHandler(this.bsAlbum_CurrentChanged);
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 289);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.cmbAlbum);
            this.Controls.Add(this.label1);
            this.Name = "DataForm";
            this.Text = "MyPhotoAlbumData";
            this.tcMain.ResumeLayout(false);
            this.pageAlbum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPhotoAlbum)).EndInit();
            this.pagePhoto.ResumeLayout(false);
            this.pagePhoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAlbum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAlbum;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage pageAlbum;
        private System.Windows.Forms.DataGridView gridPhotoAlbum;
        private System.Windows.Forms.TabPage pagePhoto;
        private System.Windows.Forms.PictureBox pbxPhoto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtPhotographer;
        private System.Windows.Forms.TextBox txtCaption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.DateTimePicker dtpDateTaken;
        private System.Windows.Forms.BindingSource bsAlbum;
    }
}

