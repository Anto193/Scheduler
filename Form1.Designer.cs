namespace Scheduler
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
            this.auswahlScheduler = new System.Windows.Forms.ComboBox();
            this.speicherAuswahl = new System.Windows.Forms.Button();
            this.speicherAnzProzesse = new System.Windows.Forms.Button();
            this.numProzesse = new System.Windows.Forms.NumericUpDown();
            this.auswahlText = new System.Windows.Forms.Label();
            this.anzProzesseText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numProzesse)).BeginInit();
            this.SuspendLayout();
            // 
            // auswahlScheduler
            // 
            this.auswahlScheduler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.auswahlScheduler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.auswahlScheduler.FormattingEnabled = true;
            this.auswahlScheduler.Items.AddRange(new object[] {
            "First Come First Serve",
            "Shortest Job First",
            "Round Robin"});
            this.auswahlScheduler.Location = new System.Drawing.Point(546, 265);
            this.auswahlScheduler.Name = "auswahlScheduler";
            this.auswahlScheduler.Size = new System.Drawing.Size(214, 28);
            this.auswahlScheduler.TabIndex = 0;
            this.auswahlScheduler.SelectedIndexChanged += new System.EventHandler(this.auswahlScheduler_SelectedIndexChanged);
            // 
            // speicherAuswahl
            // 
            this.speicherAuswahl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speicherAuswahl.AutoSize = true;
            this.speicherAuswahl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.speicherAuswahl.Enabled = false;
            this.speicherAuswahl.Location = new System.Drawing.Point(546, 300);
            this.speicherAuswahl.Name = "speicherAuswahl";
            this.speicherAuswahl.Size = new System.Drawing.Size(82, 30);
            this.speicherAuswahl.TabIndex = 1;
            this.speicherAuswahl.Text = "speichern";
            this.speicherAuswahl.UseVisualStyleBackColor = true;
            this.speicherAuswahl.Click += new System.EventHandler(this.speicherAuswahl_Click);
            // 
            // speicherAnzProzesse
            // 
            this.speicherAnzProzesse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speicherAnzProzesse.AutoSize = true;
            this.speicherAnzProzesse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.speicherAnzProzesse.Enabled = false;
            this.speicherAnzProzesse.Location = new System.Drawing.Point(546, 332);
            this.speicherAnzProzesse.Name = "speicherAnzProzesse";
            this.speicherAnzProzesse.Size = new System.Drawing.Size(64, 30);
            this.speicherAnzProzesse.TabIndex = 5;
            this.speicherAnzProzesse.Text = "starten";
            this.speicherAnzProzesse.UseVisualStyleBackColor = true;
            this.speicherAnzProzesse.Visible = false;
            this.speicherAnzProzesse.Click += new System.EventHandler(this.speicherAnzProzesse_Click);
            // 
            // numProzesse
            // 
            this.numProzesse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numProzesse.AutoSize = true;
            this.numProzesse.Location = new System.Drawing.Point(546, 299);
            this.numProzesse.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numProzesse.Name = "numProzesse";
            this.numProzesse.Size = new System.Drawing.Size(214, 27);
            this.numProzesse.TabIndex = 6;
            this.numProzesse.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numProzesse.Visible = false;
            this.numProzesse.ValueChanged += new System.EventHandler(this.numProzesse_ValueChanged);
            // 
            // auswahlText
            // 
            this.auswahlText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.auswahlText.AutoSize = true;
            this.auswahlText.Location = new System.Drawing.Point(546, 242);
            this.auswahlText.Name = "auswahlText";
            this.auswahlText.Size = new System.Drawing.Size(271, 20);
            this.auswahlText.TabIndex = 7;
            this.auswahlText.Text = "Wählen Sie ein Schedulingverfahren aus";
            // 
            // anzProzesseText
            // 
            this.anzProzesseText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.anzProzesseText.AutoSize = true;
            this.anzProzesseText.Location = new System.Drawing.Point(546, 242);
            this.anzProzesseText.Name = "anzProzesseText";
            this.anzProzesseText.Size = new System.Drawing.Size(278, 20);
            this.anzProzesseText.TabIndex = 8;
            this.anzProzesseText.Text = "Geben Sie eine Anzahl von Prozessen ein";
            this.anzProzesseText.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1356, 666);
            this.Controls.Add(this.anzProzesseText);
            this.Controls.Add(this.auswahlText);
            this.Controls.Add(this.numProzesse);
            this.Controls.Add(this.speicherAnzProzesse);
            this.Controls.Add(this.speicherAuswahl);
            this.Controls.Add(this.auswahlScheduler);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numProzesse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox auswahlScheduler;
        private Button speicherAuswahl;
        private Button speicherAnzProzesse;
        private NumericUpDown numProzesse;
        private Label auswahlText;
        private Label anzProzesseText;
    }
}