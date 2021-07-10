
namespace CC_Project
{
    partial class Form1
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
            this.SourceCodeBox = new System.Windows.Forms.RichTextBox();
            this.TokenBox = new System.Windows.Forms.DataGridView();
            this.Lexeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenerateToken = new System.Windows.Forms.Button();
            this.ParsingTableButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TokenBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SourceCodeBox
            // 
            this.SourceCodeBox.Location = new System.Drawing.Point(12, 72);
            this.SourceCodeBox.Name = "SourceCodeBox";
            this.SourceCodeBox.Size = new System.Drawing.Size(421, 275);
            this.SourceCodeBox.TabIndex = 1;
            this.SourceCodeBox.Text = "";
            this.SourceCodeBox.TextChanged += new System.EventHandler(this.SourceCodeBox_TextChanged);
            // 
            // TokenBox
            // 
            this.TokenBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TokenBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lexeme,
            this.Token});
            this.TokenBox.Location = new System.Drawing.Point(473, 72);
            this.TokenBox.Name = "TokenBox";
            this.TokenBox.Size = new System.Drawing.Size(291, 366);
            this.TokenBox.TabIndex = 2;
            // 
            // Lexeme
            // 
            this.Lexeme.HeaderText = "Lexeme";
            this.Lexeme.Name = "Lexeme";
            this.Lexeme.ReadOnly = true;
            // 
            // Token
            // 
            this.Token.HeaderText = "Token";
            this.Token.Name = "Token";
            this.Token.ReadOnly = true;
            // 
            // GenerateToken
            // 
            this.GenerateToken.Location = new System.Drawing.Point(41, 367);
            this.GenerateToken.Name = "GenerateToken";
            this.GenerateToken.Size = new System.Drawing.Size(167, 56);
            this.GenerateToken.TabIndex = 3;
            this.GenerateToken.Text = "Generate Tokens";
            this.GenerateToken.UseVisualStyleBackColor = true;
            this.GenerateToken.Click += new System.EventHandler(this.GenerateToken_Click);
            // 
            // ParsingTableButton
            // 
            this.ParsingTableButton.Location = new System.Drawing.Point(225, 367);
            this.ParsingTableButton.Name = "ParsingTableButton";
            this.ParsingTableButton.Size = new System.Drawing.Size(182, 56);
            this.ParsingTableButton.TabIndex = 4;
            this.ParsingTableButton.Text = "Create Parsing Table";
            this.ParsingTableButton.UseVisualStyleBackColor = true;
            this.ParsingTableButton.Click += new System.EventHandler(this.ParsingTableButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ParsingTableButton);
            this.Controls.Add(this.GenerateToken);
            this.Controls.Add(this.TokenBox);
            this.Controls.Add(this.SourceCodeBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TokenBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox SourceCodeBox;
        private System.Windows.Forms.DataGridView TokenBox;
        private System.Windows.Forms.Button GenerateToken;
        private System.Windows.Forms.Button ParsingTableButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token;
    }
}

