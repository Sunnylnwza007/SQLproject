﻿namespace projectdata
{
    partial class OrderM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderM));
            this.button2 = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.buttomP = new System.Windows.Forms.Button();
            this.insert = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(840, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(220, 71);
            this.button2.TabIndex = 33;
            this.button2.Text = "ลบรายการสั่งวัตถุดิบ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(614, 92);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(220, 71);
            this.update.TabIndex = 32;
            this.update.Text = "อัพเดทสถานะ";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // buttomP
            // 
            this.buttomP.Location = new System.Drawing.Point(840, 15);
            this.buttomP.Name = "buttomP";
            this.buttomP.Size = new System.Drawing.Size(220, 71);
            this.buttomP.TabIndex = 31;
            this.buttomP.Text = "การจ่ายเงิน";
            this.buttomP.UseVisualStyleBackColor = true;
            this.buttomP.Click += new System.EventHandler(this.buttomP_Click);
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(614, 15);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(220, 71);
            this.insert.TabIndex = 30;
            this.insert.Text = "เพิ่มรายการสั่งวัตถุดิบ";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1074, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 74);
            this.button1.TabIndex = 29;
            this.button1.Text = "refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1144, 664);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(388, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(220, 71);
            this.button3.TabIndex = 39;
            this.button3.Text = "ดีเทลการสั่งวัตถุดิบ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 40;
            this.textBox1.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // OrderM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1182, 853);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.update);
            this.Controls.Add(this.buttomP);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderMaterial";
            this.Load += new System.EventHandler(this.OrderM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button buttomP;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}