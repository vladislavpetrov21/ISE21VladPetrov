﻿namespace TourAgencyClientView
{
    partial class FormMain
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьЗаказToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сообщенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьЗаказToolStripMenuItem,
            this.обновитьСписокToolStripMenuItem,
            this.изменитьДанныеToolStripMenuItem,
            this.сообщенияToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // создатьЗаказToolStripMenuItem
            // 
            this.создатьЗаказToolStripMenuItem.Name = "создатьЗаказToolStripMenuItem";
            this.создатьЗаказToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.создатьЗаказToolStripMenuItem.Text = "Создать заказ";
            this.создатьЗаказToolStripMenuItem.Click += new System.EventHandler(this.CreateOrderToolStripMenuItem_Click);
            // 
            // обновитьСписокToolStripMenuItem
            // 
            this.обновитьСписокToolStripMenuItem.Name = "обновитьСписокToolStripMenuItem";
            this.обновитьСписокToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.обновитьСписокToolStripMenuItem.Text = "Обновить список";
            this.обновитьСписокToolStripMenuItem.Click += new System.EventHandler(this.RefreshOrderListToolStripMenuItem_Click);
            // 
            // изменитьДанныеToolStripMenuItem
            // 
            this.изменитьДанныеToolStripMenuItem.Name = "изменитьДанныеToolStripMenuItem";
            this.изменитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изменитьДанныеToolStripMenuItem.Text = "Изменить данные";
            this.изменитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.UpdateDataToolStripMenuItem_Click);
            // 
            // сообщенияToolStripMenuItem
            // 
            this.сообщенияToolStripMenuItem.Name = "сообщенияToolStripMenuItem";
            this.сообщенияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сообщенияToolStripMenuItem.Text = "Сообщения";
            this.сообщенияToolStripMenuItem.Click += new System.EventHandler(this.сообщенияToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 24);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(1050, 380);
            this.dataGridView.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 404);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Клиент турагенства";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьЗаказToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьСписокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сообщенияToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}