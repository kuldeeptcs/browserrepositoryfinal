namespace Medtronic_IEAddOn
{
    partial class SmileyPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmileyPopup));
            this.pictureBoxSmile = new System.Windows.Forms.PictureBox();
            this.pictureBoxFrown = new System.Windows.Forms.PictureBox();
            this.lblSmile = new System.Windows.Forms.Label();
            this.lblFrown = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSmile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxSmile
            // 
            this.pictureBoxSmile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSmile.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSmile.Image")));
            this.pictureBoxSmile.Location = new System.Drawing.Point(12, 13);
            this.pictureBoxSmile.Name = "pictureBoxSmile";
            this.pictureBoxSmile.Size = new System.Drawing.Size(36, 33);
            this.pictureBoxSmile.TabIndex = 0;
            this.pictureBoxSmile.TabStop = false;
            this.pictureBoxSmile.Click += new System.EventHandler(this.pictureBoxSmile_Click);
            this.pictureBoxSmile.MouseHover += new System.EventHandler(this.pictureBoxSmile_MouseHover);
            // 
            // pictureBoxFrown
            // 
            this.pictureBoxFrown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxFrown.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFrown.Image")));
            this.pictureBoxFrown.Location = new System.Drawing.Point(12, 52);
            this.pictureBoxFrown.Name = "pictureBoxFrown";
            this.pictureBoxFrown.Size = new System.Drawing.Size(36, 33);
            this.pictureBoxFrown.TabIndex = 1;
            this.pictureBoxFrown.TabStop = false;
            this.pictureBoxFrown.Click += new System.EventHandler(this.pictureBoxFrown_Click);
            this.pictureBoxFrown.MouseHover += new System.EventHandler(this.pictureBoxFrown_MouseHover);
            // 
            // lblSmile
            // 
            this.lblSmile.AutoSize = true;
            this.lblSmile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSmile.Font = new System.Drawing.Font("Effra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSmile.Location = new System.Drawing.Point(55, 14);
            this.lblSmile.Name = "lblSmile";
            this.lblSmile.Size = new System.Drawing.Size(87, 18);
            this.lblSmile.TabIndex = 2;
            this.lblSmile.Text = "Send a Smile";
            this.lblSmile.Click += new System.EventHandler(this.lblSmile_Click);
            // 
            // lblFrown
            // 
            this.lblFrown.AutoSize = true;
            this.lblFrown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFrown.Font = new System.Drawing.Font("Effra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrown.Location = new System.Drawing.Point(54, 55);
            this.lblFrown.Name = "lblFrown";
            this.lblFrown.Size = new System.Drawing.Size(92, 18);
            this.lblFrown.TabIndex = 2;
            this.lblFrown.Text = "Send a Frown";
            this.lblFrown.Click += new System.EventHandler(this.lblFrown_Click);
            // 
            // SmileyPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(149, 90);
            this.Controls.Add(this.lblFrown);
            this.Controls.Add(this.lblSmile);
            this.Controls.Add(this.pictureBoxFrown);
            this.Controls.Add(this.pictureBoxSmile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SmileyPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Feedback";
            this.Load += new System.EventHandler(this.SmileyPopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSmile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSmile;
        private System.Windows.Forms.PictureBox pictureBoxFrown;
        private System.Windows.Forms.Label lblSmile;
        private System.Windows.Forms.Label lblFrown;
    }
}