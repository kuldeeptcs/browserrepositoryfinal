namespace Medtronic_IEAddOn
{
    partial class FeedbackForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedbackForm));
            this.lblValidationMessage = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtFeedbackBox = new System.Windows.Forms.TextBox();
            this.lblHeadline = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblValidationMessage
            // 
            this.lblValidationMessage.AutoSize = true;
            this.lblValidationMessage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblValidationMessage.Font = new System.Drawing.Font("Effra", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidationMessage.ForeColor = System.Drawing.Color.Crimson;
            this.lblValidationMessage.Location = new System.Drawing.Point(12, 205);
            this.lblValidationMessage.Name = "lblValidationMessage";
            this.lblValidationMessage.Size = new System.Drawing.Size(0, 13);
            this.lblValidationMessage.TabIndex = 9;
            this.lblValidationMessage.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(105, 230);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(12, 230);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(87, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtFeedbackBox
            // 
            this.txtFeedbackBox.Font = new System.Drawing.Font("Effra", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFeedbackBox.Location = new System.Drawing.Point(12, 54);
            this.txtFeedbackBox.MaxLength = 500;
            this.txtFeedbackBox.Multiline = true;
            this.txtFeedbackBox.Name = "txtFeedbackBox";
            this.txtFeedbackBox.Size = new System.Drawing.Size(460, 148);
            this.txtFeedbackBox.TabIndex = 6;
            this.txtFeedbackBox.TabStop = false;
            this.txtFeedbackBox.TextChanged += new System.EventHandler(this.txtFeedbackBox_TextChanged);
            this.txtFeedbackBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFeedbackBox_KeyPress);
            // 
            // lblHeadline
            // 
            this.lblHeadline.AutoSize = true;
            this.lblHeadline.Font = new System.Drawing.Font("Effra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadline.Location = new System.Drawing.Point(12, 17);
            this.lblHeadline.Name = "lblHeadline";
            this.lblHeadline.Size = new System.Drawing.Size(272, 17);
            this.lblHeadline.TabIndex = 5;
            this.lblHeadline.Text = "We really appreciate your comments";
            this.lblHeadline.Click += new System.EventHandler(this.lblHeadline_Click);
            // 
            // FeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 272);
            this.Controls.Add(this.lblValidationMessage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtFeedbackBox);
            this.Controls.Add(this.lblHeadline);
            this.Font = new System.Drawing.Font("Effra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeedbackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THANK YOU FOR YOUR FEEDBACK";
            this.Load += new System.EventHandler(this.FeedbackForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValidationMessage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtFeedbackBox;
        private System.Windows.Forms.Label lblHeadline;
    }
}