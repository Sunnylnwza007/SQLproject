namespace projectdata
{
    partial class Requisition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Requisition));
            this.button2 = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.buttomP = new System.Windows.Forms.Button();
            this.insert = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttomd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(847, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(220, 71);
            this.button2.TabIndex = 45;
            this.button2.Text = "ลบรายการเบิก";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(621, 107);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(220, 71);
            this.update.TabIndex = 44;
            this.update.Text = "อัพเดทสถานะ";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // buttomP
            // 
            this.buttomP.Location = new System.Drawing.Point(847, 30);
            this.buttomP.Name = "buttomP";
            this.buttomP.Size = new System.Drawing.Size(220, 71);
            this.buttomP.TabIndex = 43;
            this.buttomP.Text = "คลังวัตถุดิบ";
            this.buttomP.UseVisualStyleBackColor = true;
            this.buttomP.Click += new System.EventHandler(this.buttomP_Click);
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(621, 30);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(220, 71);
            this.insert.TabIndex = 42;
            this.insert.Text = "เพิ่มรายการเบิก";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1081, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 74);
            this.button1.TabIndex = 41;
            this.button1.Text = "refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1144, 664);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // buttomd
            // 
            this.buttomd.Location = new System.Drawing.Point(395, 66);
            this.buttomd.Name = "buttomd";
            this.buttomd.Size = new System.Drawing.Size(220, 71);
            this.buttomd.TabIndex = 46;
            this.buttomd.Text = "ดีเทลการเบิก";
            this.buttomd.UseVisualStyleBackColor = true;
            this.buttomd.Click += new System.EventHandler(this.buttomd_Click);
            // 
            // Requisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(1182, 953);
            this.Controls.Add(this.buttomd);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.update);
            this.Controls.Add(this.buttomP);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Requisition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requisition";
            this.Load += new System.EventHandler(this.Requisition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button buttomP;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttomd;
    }
}