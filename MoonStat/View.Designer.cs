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
        private void InitializeComponent()
        {
            inputURL = new TextBox();
            botaoIniciarAnalise = new Button();
            resultadosTextBox = new RichTextBox();
            progressoDaAnalise = new Label();
            SuspendLayout();
            // 
            // inputURL
            // 
            inputURL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            inputURL.Location = new Point(12, 49);
            inputURL.Margin = new Padding(3, 100, 3, 3);
            inputURL.Name = "inputURL";
            inputURL.Size = new Size(822, 23);
            inputURL.TabIndex = 0;
            // 
            // botaoIniciarAnalise
            // 
            botaoIniciarAnalise.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            botaoIniciarAnalise.Location = new Point(12, 78);
            botaoIniciarAnalise.Name = "botaoIniciarAnalise";
            botaoIniciarAnalise.Size = new Size(822, 23);
            botaoIniciarAnalise.TabIndex = 1;
            botaoIniciarAnalise.Text = "Iniciar Análise";
            botaoIniciarAnalise.UseVisualStyleBackColor = true;
            botaoIniciarAnalise.Click += iniciarAnalise_Click;
            // 
            // resultadosTextBox
            // 
            resultadosTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultadosTextBox.Location = new Point(12, 147);
            resultadosTextBox.Name = "resultadosTextBox";
            resultadosTextBox.Size = new Size(822, 408);
            resultadosTextBox.TabIndex = 3;
            resultadosTextBox.Text = "";
            // 
            // progressoDaAnalise
            // 
            progressoDaAnalise.AutoSize = true;
            progressoDaAnalise.Location = new Point(12, 104);
            progressoDaAnalise.MaximumSize = new Size(600, 0);
            progressoDaAnalise.Name = "progressoDaAnalise";
            progressoDaAnalise.Size = new Size(16, 15);
            progressoDaAnalise.TabIndex = 4;
            progressoDaAnalise.Text = "...";
            // 
            // View
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 578);
            Controls.Add(progressoDaAnalise);
            Controls.Add(resultadosTextBox);
            Controls.Add(botaoIniciarAnalise);
            Controls.Add(inputURL);
            Name = "View";
            Text = "MoonStat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputURL;
        private Button botaoIniciarAnalise;
        private RichTextBox resultadosTextBox;
        private Label progressoDaAnalise;
    }
}
