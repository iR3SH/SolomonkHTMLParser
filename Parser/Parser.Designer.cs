namespace Parser
{
    partial class Parser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Parser));
            this.loggerText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StateLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.NumRequestLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loggerText
            // 
            this.loggerText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loggerText.Location = new System.Drawing.Point(0, -3);
            this.loggerText.Name = "loggerText";
            this.loggerText.Size = new System.Drawing.Size(799, 385);
            this.loggerText.TabIndex = 0;
            this.loggerText.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Etat :";
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StateLabel.ForeColor = System.Drawing.Color.Green;
            this.StateLabel.Location = new System.Drawing.Point(51, 400);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(31, 15);
            this.StateLabel.TabIndex = 2;
            this.StateLabel.Text = "Prêt";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Charger les données";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // NumRequestLabel
            // 
            this.NumRequestLabel.AutoSize = true;
            this.NumRequestLabel.Location = new System.Drawing.Point(630, 404);
            this.NumRequestLabel.Name = "NumRequestLabel";
            this.NumRequestLabel.Size = new System.Drawing.Size(30, 15);
            this.NumRequestLabel.TabIndex = 4;
            this.NumRequestLabel.Text = "0 / 0";
            // 
            // Parser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NumRequestLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loggerText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Parser";
            this.Text = "SolomonkHTMLParser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Parser_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox loggerText;
        private Label label1;
        private Label StateLabel;
        private Button button1;
        private Label NumRequestLabel;
    }
}