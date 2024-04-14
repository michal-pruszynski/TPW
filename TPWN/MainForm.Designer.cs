namespace TPW.Forms
{
    partial class MainForm
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
            this.addButton_Click = new System.Windows.Forms.Button();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // addButton_Click
            // 
            this.addButton_Click.Location = new System.Drawing.Point(361, 476);
            this.addButton_Click.Name = "addButton_Click";
            this.addButton_Click.Size = new System.Drawing.Size(75, 23);
            this.addButton_Click.TabIndex = 0;
            this.addButton_Click.Text = "Add";
            this.addButton_Click.UseVisualStyleBackColor = true;
            this.addButton_Click.Click += new System.EventHandler(this.addButton_Click_Click);
            // 
            // canvasPanel
            // 
            this.canvasPanel.BackColor = System.Drawing.Color.LightGray;
            this.canvasPanel.Location = new System.Drawing.Point(12, 12);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(800, 450);
            this.canvasPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 511);
            this.Controls.Add(this.addButton_Click);
            this.Controls.Add(this.canvasPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addButton_Click;
        private System.Windows.Forms.Panel canvasPanel;
    }
}

