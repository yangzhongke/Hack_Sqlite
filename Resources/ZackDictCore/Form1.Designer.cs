namespace ZackDictCore
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
            txtWord = new TextBox();
            btnSearch = new Button();
            txtResult = new TextBox();
            SuspendLayout();
            // 
            // txtWord
            // 
            txtWord.Location = new Point(12, 12);
            txtWord.Name = "txtWord";
            txtWord.Size = new Size(318, 31);
            txtWord.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(336, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(63, 34);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "查";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(12, 57);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(554, 236);
            txtResult.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 307);
            Controls.Add(txtResult);
            Controls.Add(btnSearch);
            Controls.Add(txtWord);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtWord;
        private Button btnSearch;
        private TextBox txtResult;
    }
}
