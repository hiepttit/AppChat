namespace Chat_Client
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.list_Client = new System.Windows.Forms.CheckedListBox();
            this.txt_text = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_chat = new System.Windows.Forms.RichTextBox();
            this.lb_stt = new System.Windows.Forms.Label();
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(251, 23);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 15;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(69, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(172, 20);
            this.txtName.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.list_Client);
            this.groupBox2.Location = new System.Drawing.Point(383, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 202);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All Client";
            // 
            // list_Client
            // 
            this.list_Client.FormattingEnabled = true;
            this.list_Client.Location = new System.Drawing.Point(0, 19);
            this.list_Client.Name = "list_Client";
            this.list_Client.Size = new System.Drawing.Size(134, 184);
            this.list_Client.TabIndex = 8;
            // 
            // txt_text
            // 
            this.txt_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_text.Location = new System.Drawing.Point(15, 285);
            this.txt_text.Name = "txt_text";
            this.txt_text.Size = new System.Drawing.Size(312, 20);
            this.txt_text.TabIndex = 12;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(370, 285);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(103, 23);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_chat);
            this.groupBox1.Location = new System.Drawing.Point(11, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 180);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chat vs server";
            // 
            // rb_chat
            // 
            this.rb_chat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb_chat.Location = new System.Drawing.Point(3, 16);
            this.rb_chat.Name = "rb_chat";
            this.rb_chat.Size = new System.Drawing.Size(306, 161);
            this.rb_chat.TabIndex = 1;
            this.rb_chat.Text = "";
            // 
            // lb_stt
            // 
            this.lb_stt.AutoSize = true;
            this.lb_stt.Location = new System.Drawing.Point(12, 336);
            this.lb_stt.Name = "lb_stt";
            this.lb_stt.Size = new System.Drawing.Size(0, 13);
            this.lb_stt.TabIndex = 16;
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.Location = new System.Drawing.Point(383, 24);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisConnect.TabIndex = 17;
            this.btnDisConnect.Text = "DisConnect";
            this.btnDisConnect.UseVisualStyleBackColor = true;
            this.btnDisConnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 368);
            this.Controls.Add(this.btnDisConnect);
            this.Controls.Add(this.lb_stt);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txt_text);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox list_Client;
        private System.Windows.Forms.TextBox txt_text;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rb_chat;
        private System.Windows.Forms.Label lb_stt;
        private System.Windows.Forms.Button btnDisConnect;
    }
}

