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
            url_input = new TextBox();
            button1 = new Button();
            Feedback = new Label();
            SuspendLayout();
            // 
            // url_input
            // 
            url_input.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            url_input.Location = new Point(12, 49);
            url_input.Margin = new Padding(3, 100, 3, 3);
            url_input.Name = "url_input";
            url_input.Size = new Size(834, 23);
            url_input.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(12, 78);
            button1.Name = "button1";
            button1.Size = new Size(834, 23);
            button1.TabIndex = 1;
            button1.Text = "Iniciar Análise";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Feedback
            // 
            Feedback.AutoSize = true;
            Feedback.Location = new Point(12, 113);
            Feedback.Name = "Feedback";
            Feedback.Size = new Size(0, 15);
            Feedback.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 490);
            Controls.Add(Feedback);
            Controls.Add(button1);
            Controls.Add(url_input);
            Name = "Form1";
            Text = "MoonStat";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox url_input;
        private Button button1;
        private Label Feedback;
    }
}
