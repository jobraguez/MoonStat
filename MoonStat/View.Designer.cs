namespace MoonStat
{
    partial class View
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
        private System.Windows.Forms.TextBox inputURL;
        private System.Windows.Forms.Button botaoIniciarAnalise;
        private System.Windows.Forms.RichTextBox resultadosTextBox;
        private System.Windows.Forms.Label progressoDaAnalise;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxThemes;
        private System.Windows.Forms.Label labelTheme;
        private void InitializeComponent()
        {
            this.inputURL = new System.Windows.Forms.TextBox();
            this.botaoIniciarAnalise = new System.Windows.Forms.Button();
            this.resultadosTextBox = new System.Windows.Forms.RichTextBox();
            this.progressoDaAnalise = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxThemes = new System.Windows.Forms.ComboBox();
            this.labelTheme = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // inputURL
            // 
            this.inputURL.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.inputURL.Location = new System.Drawing.Point(12, 100);
            this.inputURL.Margin = new System.Windows.Forms.Padding(3, 100, 3, 3);
            this.inputURL.Name = "inputURL";
            this.inputURL.Size = new System.Drawing.Size(822, 23);
            this.inputURL.TabIndex = 0;

            // 
            // botaoIniciarAnalise
            // 
            this.botaoIniciarAnalise.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.botaoIniciarAnalise.Location = new System.Drawing.Point(178, 150);
            this.botaoIniciarAnalise.Name = "botaoIniciarAnalise";
            this.botaoIniciarAnalise.Size = new System.Drawing.Size(656, 24);
            this.botaoIniciarAnalise.TabIndex = 1;
            this.botaoIniciarAnalise.Text = "Iniciar Análise";
            this.botaoIniciarAnalise.UseVisualStyleBackColor = true;
            this.botaoIniciarAnalise.Click += new System.EventHandler(this.iniciarAnalise_Click);

            // 
            // resultadosTextBox
            // 
            this.resultadosTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.resultadosTextBox.Location = new System.Drawing.Point(12, 210);
            this.resultadosTextBox.Name = "resultadosTextBox";
            this.resultadosTextBox.Size = new System.Drawing.Size(822, 345);
            this.resultadosTextBox.TabIndex = 3;
            this.resultadosTextBox.Text = "";

            // 
            // progressoDaAnalise
            // 
            this.progressoDaAnalise.AutoSize = true;
            this.progressoDaAnalise.Location = new System.Drawing.Point(12, 180);
            this.progressoDaAnalise.MaximumSize = new System.Drawing.Size(600, 0);
            this.progressoDaAnalise.Name = "progressoDaAnalise";
            this.progressoDaAnalise.Size = new System.Drawing.Size(16, 15);
            this.progressoDaAnalise.TabIndex = 4;
            this.progressoDaAnalise.Text = "...";

            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] { "Chrome", "Firefox", "Edge" });
            this.comboBox1.Location = new System.Drawing.Point(12, 150);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 23);
            this.comboBox1.TabIndex = 5;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Driver";

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "URL";

            // 
            // comboBoxThemes
            // 
            this.comboBoxThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThemes.FormattingEnabled = true;
            this.comboBoxThemes.Items.AddRange(new object[] { "Light", "Dark" });
            this.comboBoxThemes.Location = new System.Drawing.Point(12, 50);
            this.comboBoxThemes.Name = "comboBoxThemes";
            this.comboBoxThemes.Size = new System.Drawing.Size(160, 23);
            this.comboBoxThemes.TabIndex = 8;
            this.comboBoxThemes.SelectedIndexChanged += new System.EventHandler(this.ComboBoxThemes_SelectedIndexChanged);

            // 
            // labelTheme
            // 
            this.labelTheme.AutoSize = true;
            this.labelTheme.Location = new System.Drawing.Point(12, 32);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(43, 15);
            this.labelTheme.TabIndex = 9;
            this.labelTheme.Text = "Theme";

            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 578);
            this.Controls.Add(this.labelTheme);
            this.Controls.Add(this.comboBoxThemes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.progressoDaAnalise);
            this.Controls.Add(this.resultadosTextBox);
            this.Controls.Add(this.botaoIniciarAnalise);
            this.Controls.Add(this.inputURL);
            this.Name = "View";
            this.Text = "MoonStat";
            this.Load += new System.EventHandler(this.View_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

    }
}
