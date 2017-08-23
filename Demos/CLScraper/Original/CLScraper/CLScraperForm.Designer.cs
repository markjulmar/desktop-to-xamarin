using System.Windows.Forms;

namespace CLScraper
{
    partial class CLScraperForm
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
            this.searchButton = new System.Windows.Forms.Button();
            this.ResultListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchForTextBox = new System.Windows.Forms.TextBox();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(785, 100);
            this.searchButton.Margin = new System.Windows.Forms.Padding(8);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(183, 64);
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.OnSearchClicked);
            // 
            // ResultListBox
            // 
            this.ResultListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultListBox.FormattingEnabled = true;
            this.ResultListBox.HorizontalScrollbar = true;
            this.ResultListBox.IntegralHeight = false;
            this.ResultListBox.ItemHeight = 36;
            this.ResultListBox.Location = new System.Drawing.Point(0, 201);
            this.ResultListBox.Margin = new System.Windows.Forms.Padding(0);
            this.ResultListBox.Name = "ResultListBox";
            this.ResultListBox.Size = new System.Drawing.Size(992, 511);
            this.ResultListBox.TabIndex = 1;
            this.ResultListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnShowItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "City";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search For";
            // 
            // searchForTextBox
            // 
            this.searchForTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchForTextBox.Location = new System.Drawing.Point(184, 111);
            this.searchForTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchForTextBox.Name = "searchForTextBox";
            this.searchForTextBox.Size = new System.Drawing.Size(574, 41);
            this.searchForTextBox.TabIndex = 5;
            // 
            // cityComboBox
            // 
            this.cityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Items.AddRange(new object[] {
            "Atlanta",
            "Austin",
            "Boston",
            "Chicago",
            "Dallas",
            "Denver",
            "Detroit",
            "Houston",
            "Las Vegas",
            "Los Angeles",
            "Miami",
            "Minneapolis",
            "New York",
            "Orange County",
            "Philidelphia",
            "Phoenix",
            "Portland",
            "Raleigh",
            "Sacramento",
            "San Diego",
            "Seattle",
            "SF Bay",
            "Washington DC"});
            this.cityComboBox.Location = new System.Drawing.Point(112, 32);
            this.cityComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(838, 44);
            this.cityComboBox.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.searchForTextBox);
            this.panel1.Controls.Add(this.cityComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 201);
            this.panel1.TabIndex = 7;
            // 
            // CLScraperForm
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(992, 712);
            this.Controls.Add(this.ResultListBox);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "CLScraperForm";
            this.Text = "Search CraigsList";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListBox ResultListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchForTextBox;
        private System.Windows.Forms.ComboBox cityComboBox;
        private Panel panel1;
    }
}

