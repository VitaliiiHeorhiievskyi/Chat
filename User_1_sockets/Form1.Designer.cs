
using System.Net.Sockets;

namespace LabOS_11_User_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Chat = new System.Windows.Forms.TextBox();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Chat
            // 
            this.textBox_Chat.Location = new System.Drawing.Point(48, 12);
            this.textBox_Chat.Multiline = true;
            this.textBox_Chat.Name = "textBox_Chat";
            this.textBox_Chat.ReadOnly = true;
            this.textBox_Chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Chat.Size = new System.Drawing.Size(253, 223);
            this.textBox_Chat.TabIndex = 0;
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(48, 264);
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.Size = new System.Drawing.Size(253, 27);
            this.textBox_Message.TabIndex = 1;
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(126, 311);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(94, 29);
            this.button_Send.TabIndex = 2;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 377);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.textBox_Chat);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User_1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Chat;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Button button_Send;
    }
}

