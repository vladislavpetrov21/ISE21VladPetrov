﻿namespace TourAgencyView
{
    partial class FormStorages
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
			this.buttonRef = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonUpd = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonRef
			// 
			this.buttonRef.Location = new System.Drawing.Point(407, 164);
			this.buttonRef.Margin = new System.Windows.Forms.Padding(2);
			this.buttonRef.Name = "buttonRef";
			this.buttonRef.Size = new System.Drawing.Size(115, 27);
			this.buttonRef.TabIndex = 8;
			this.buttonRef.Text = "Обновить";
			this.buttonRef.UseVisualStyleBackColor = true;
			this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
			// 
			// buttonDel
			// 
			this.buttonDel.Location = new System.Drawing.Point(407, 118);
			this.buttonDel.Margin = new System.Windows.Forms.Padding(2);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(115, 27);
			this.buttonDel.TabIndex = 9;
			this.buttonDel.Text = "Удалить";
			this.buttonDel.UseVisualStyleBackColor = true;
			this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
			// 
			// buttonUpd
			// 
			this.buttonUpd.Location = new System.Drawing.Point(407, 72);
			this.buttonUpd.Margin = new System.Windows.Forms.Padding(2);
			this.buttonUpd.Name = "buttonUpd";
			this.buttonUpd.Size = new System.Drawing.Size(115, 27);
			this.buttonUpd.TabIndex = 10;
			this.buttonUpd.Text = "Изменить";
			this.buttonUpd.UseVisualStyleBackColor = true;
			this.buttonUpd.Click += new System.EventHandler(this.buttonUpd_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(407, 27);
			this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(115, 27);
			this.buttonAdd.TabIndex = 11;
			this.buttonAdd.Text = "Добавить";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(11, 11);
			this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.RowTemplate.Height = 28;
			this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView.Size = new System.Drawing.Size(364, 292);
			this.dataGridView.TabIndex = 7;
			// 
			// FormStorages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(539, 322);
			this.Controls.Add(this.buttonRef);
			this.Controls.Add(this.buttonDel);
			this.Controls.Add(this.buttonUpd);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.dataGridView);
			this.Name = "FormStorages";
			this.Text = "Склады";
			this.Load += new System.EventHandler(this.FormStorages_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
		}

		#endregion
		private System.Windows.Forms.Button buttonRef;
		private System.Windows.Forms.Button buttonDel;
		private System.Windows.Forms.Button buttonUpd;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.DataGridView dataGridView;
	}
}