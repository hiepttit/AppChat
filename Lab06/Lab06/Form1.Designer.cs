namespace Lab06
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.list_Client = new System.Windows.Forms.CheckedListBox();
            this.lb_soluong = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(30, 21);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(88, 37);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "StartServer";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(208, 21);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(84, 37);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "StopSever";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text receive from client:";
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(341, 139);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.Size = new System.Drawing.Size(305, 265);
            this.txtReceive.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "List client";
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(33, 459);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(346, 37);
            this.txtSend.TabIndex = 5;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(429, 460);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(87, 36);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // list_Client
            // 
            this.list_Client.FormattingEnabled = true;
            this.list_Client.Location = new System.Drawing.Point(33, 130);
            this.list_Client.Name = "list_Client";
            this.list_Client.Size = new System.Drawing.Size(290, 274);
            this.list_Client.TabIndex = 7;
            // 
            // lb_soluong
            // 
            this.lb_soluong.Location = new System.Drawing.Point(370, 30);
            this.lb_soluong.Name = "lb_soluong";
            this.lb_soluong.ReadOnly = true;
            this.lb_soluong.Size = new System.Drawing.Size(259, 20);
            this.lb_soluong.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 539);
            this.Controls.Add(this.lb_soluong);
            this.Controls.Add(this.list_Client);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.CheckedListBox list_Client;
        private System.Windows.Forms.TextBox lb_soluong;
    }
}

