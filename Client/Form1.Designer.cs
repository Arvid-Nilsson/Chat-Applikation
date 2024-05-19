namespace Client
{
    partial class Client
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
            this.lblIp = new System.Windows.Forms.Label();
            this.tbxIp = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbxMessages = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.tbxSendMessage = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPronouns = new System.Windows.Forms.Label();
            this.tbxPronouns = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(87, 192);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(79, 20);
            this.lblIp.TabIndex = 0;
            this.lblIp.Text = "IP-Adress";
            // 
            // tbxIp
            // 
            this.tbxIp.Location = new System.Drawing.Point(219, 192);
            this.tbxIp.Name = "tbxIp";
            this.tbxIp.Size = new System.Drawing.Size(100, 26);
            this.tbxIp.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(90, 274);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(86, 32);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Anslut";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbxMessages
            // 
            this.tbxMessages.Enabled = false;
            this.tbxMessages.Location = new System.Drawing.Point(90, 337);
            this.tbxMessages.Multiline = true;
            this.tbxMessages.Name = "tbxMessages";
            this.tbxMessages.Size = new System.Drawing.Size(229, 76);
            this.tbxMessages.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(219, 500);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(87, 32);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Sänd";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(219, 274);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(123, 32);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Koppla ifrån";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // tbxSendMessage
            // 
            this.tbxSendMessage.Location = new System.Drawing.Point(90, 454);
            this.tbxSendMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxSendMessage.Name = "tbxSendMessage";
            this.tbxSendMessage.Size = new System.Drawing.Size(229, 26);
            this.tbxSendMessage.TabIndex = 6;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(171, 40);
            this.tbxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(148, 26);
            this.tbxName.TabIndex = 7;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(58, 45);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Namn";
            // 
            // lblPronouns
            // 
            this.lblPronouns.AutoSize = true;
            this.lblPronouns.Location = new System.Drawing.Point(58, 100);
            this.lblPronouns.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPronouns.Name = "lblPronouns";
            this.lblPronouns.Size = new System.Drawing.Size(82, 20);
            this.lblPronouns.TabIndex = 10;
            this.lblPronouns.Text = "Pronomen";
            // 
            // tbxPronouns
            // 
            this.tbxPronouns.Location = new System.Drawing.Point(171, 95);
            this.tbxPronouns.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxPronouns.Name = "tbxPronouns";
            this.tbxPronouns.Size = new System.Drawing.Size(148, 26);
            this.tbxPronouns.TabIndex = 9;
            this.tbxPronouns.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 565);
            this.Controls.Add(this.lblPronouns);
            this.Controls.Add(this.tbxPronouns);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.tbxSendMessage);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbxMessages);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbxIp);
            this.Controls.Add(this.lblIp);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.TextBox tbxIp;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbxMessages;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox tbxSendMessage;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPronouns;
        private System.Windows.Forms.TextBox tbxPronouns;
    }
}

