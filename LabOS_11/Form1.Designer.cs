
namespace LabOS_11
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_pipes = new System.Windows.Forms.RadioButton();
            this.radioButton_sockets = new System.Windows.Forms.RadioButton();
            this.button_GoToChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(43, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hello! =)";
            // 
            // radioButton_pipes
            // 
            this.radioButton_pipes.AutoSize = true;
            this.radioButton_pipes.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton_pipes.Location = new System.Drawing.Point(43, 73);
            this.radioButton_pipes.Name = "radioButton_pipes";
            this.radioButton_pipes.Size = new System.Drawing.Size(90, 35);
            this.radioButton_pipes.TabIndex = 1;
            this.radioButton_pipes.TabStop = true;
            this.radioButton_pipes.Text = "Pipes";
            this.radioButton_pipes.UseVisualStyleBackColor = true;
            // 
            // radioButton_sockets
            // 
            this.radioButton_sockets.AutoSize = true;
            this.radioButton_sockets.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton_sockets.Location = new System.Drawing.Point(43, 104);
            this.radioButton_sockets.Name = "radioButton_sockets";
            this.radioButton_sockets.Size = new System.Drawing.Size(112, 35);
            this.radioButton_sockets.TabIndex = 2;
            this.radioButton_sockets.TabStop = true;
            this.radioButton_sockets.Text = "Sockets";
            this.radioButton_sockets.UseVisualStyleBackColor = true;
            // 
            // button_GoToChat
            // 
            this.button_GoToChat.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_GoToChat.Location = new System.Drawing.Point(32, 145);
            this.button_GoToChat.Name = "button_GoToChat";
            this.button_GoToChat.Size = new System.Drawing.Size(143, 41);
            this.button_GoToChat.TabIndex = 3;
            this.button_GoToChat.Text = "Go to chat";
            this.button_GoToChat.UseVisualStyleBackColor = true;
            this.button_GoToChat.Click += new System.EventHandler(this.button_GoToChat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 227);
            this.Controls.Add(this.button_GoToChat);
            this.Controls.Add(this.radioButton_sockets);
            this.Controls.Add(this.radioButton_pipes);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_pipes;
        private System.Windows.Forms.RadioButton radioButton_sockets;
        private System.Windows.Forms.Button button_GoToChat;
    }
}

