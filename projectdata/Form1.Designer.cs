namespace projectdata
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.vender = new System.Windows.Forms.Button();
            this.orderp = new System.Windows.Forms.Button();
            this.orderm = new System.Windows.Forms.Button();
            this.storagep = new System.Windows.Forms.Button();
            this.storagem = new System.Windows.Forms.Button();
            this.customer = new System.Windows.Forms.Button();
            this.employee = new System.Windows.Forms.Button();
            this.manufacture = new System.Windows.Forms.Button();
            this.car = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // vender
            // 
            this.vender.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.vender, "vender");
            this.vender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.vender.Name = "vender";
            this.vender.UseVisualStyleBackColor = false;
            this.vender.Click += new System.EventHandler(this.button1_Click);
            // 
            // orderp
            // 
            this.orderp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.orderp, "orderp");
            this.orderp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.orderp.Name = "orderp";
            this.orderp.UseVisualStyleBackColor = false;
            this.orderp.Click += new System.EventHandler(this.button2_Click);
            // 
            // orderm
            // 
            this.orderm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.orderm, "orderm");
            this.orderm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.orderm.Name = "orderm";
            this.orderm.UseVisualStyleBackColor = false;
            this.orderm.Click += new System.EventHandler(this.button3_Click);
            // 
            // storagep
            // 
            this.storagep.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.storagep, "storagep");
            this.storagep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.storagep.Name = "storagep";
            this.storagep.UseVisualStyleBackColor = false;
            this.storagep.Click += new System.EventHandler(this.button4_Click);
            // 
            // storagem
            // 
            this.storagem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.storagem, "storagem");
            this.storagem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.storagem.Name = "storagem";
            this.storagem.UseVisualStyleBackColor = false;
            this.storagem.Click += new System.EventHandler(this.button5_Click);
            // 
            // customer
            // 
            this.customer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.customer, "customer");
            this.customer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.customer.Name = "customer";
            this.customer.UseVisualStyleBackColor = false;
            this.customer.Click += new System.EventHandler(this.button6_Click);
            // 
            // employee
            // 
            this.employee.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.employee, "employee");
            this.employee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.employee.Name = "employee";
            this.employee.UseVisualStyleBackColor = false;
            this.employee.Click += new System.EventHandler(this.button7_Click);
            // 
            // manufacture
            // 
            this.manufacture.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.manufacture, "manufacture");
            this.manufacture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.manufacture.Name = "manufacture";
            this.manufacture.UseVisualStyleBackColor = false;
            this.manufacture.Click += new System.EventHandler(this.button8_Click);
            // 
            // car
            // 
            this.car.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.car, "car");
            this.car.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.car.Name = "car";
            this.car.UseVisualStyleBackColor = false;
            this.car.Click += new System.EventHandler(this.button9_Click);
            // 
            // close
            // 
            resources.ApplyResources(this.close, "close");
            this.close.BackColor = System.Drawing.Color.Red;
            this.close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.close.Name = "close";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.monthCalendar1, "monthCalendar1");
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.employee);
            this.Controls.Add(this.manufacture);
            this.Controls.Add(this.car);
            this.Controls.Add(this.customer);
            this.Controls.Add(this.storagem);
            this.Controls.Add(this.storagep);
            this.Controls.Add(this.orderm);
            this.Controls.Add(this.orderp);
            this.Controls.Add(this.vender);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button vender;
        private System.Windows.Forms.Button orderp;
        private System.Windows.Forms.Button orderm;
        private System.Windows.Forms.Button storagep;
        private System.Windows.Forms.Button storagem;
        private System.Windows.Forms.Button customer;
        private System.Windows.Forms.Button employee;
        private System.Windows.Forms.Button manufacture;
        private System.Windows.Forms.Button car;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
    }
}

