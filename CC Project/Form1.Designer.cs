
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
            this.ParsingTableButton = new System.Windows.Forms.Button();
            this.SymbolTable = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TokenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SymbolTable)).BeginInit();
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
            this.TokenBox.Location = new System.Drawing.Point(510, 63);
            this.TokenBox.Name = "TokenBox";
            this.TokenBox.Size = new System.Drawing.Size(293, 366);
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
            this.Token.Width = 150;
            // 
            // ParsingTableButton
            // 
            this.ParsingTableButton.Location = new System.Drawing.Point(46, 373);
            this.ParsingTableButton.Name = "ParsingTableButton";
            this.ParsingTableButton.Size = new System.Drawing.Size(182, 56);
            this.ParsingTableButton.TabIndex = 4;
            this.ParsingTableButton.Text = "Create Parsing Table";
            this.ParsingTableButton.UseVisualStyleBackColor = true;
            this.ParsingTableButton.Click += new System.EventHandler(this.ParsingTableButton_Click);
            // 
            // SymbolTable
            // 
            this.SymbolTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SymbolTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Value,
            this.Type});
            this.SymbolTable.Location = new System.Drawing.Point(818, 63);
            this.SymbolTable.Name = "SymbolTable";
            this.SymbolTable.Size = new System.Drawing.Size(343, 354);
            this.SymbolTable.TabIndex = 5;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 450);
            this.Controls.Add(this.SymbolTable);
            this.Controls.Add(this.ParsingTableButton);
            this.Controls.Add(this.TokenBox);
            this.Controls.Add(this.SourceCodeBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TokenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SymbolTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox SourceCodeBox;
        private System.Windows.Forms.DataGridView TokenBox;
        private System.Windows.Forms.Button ParsingTableButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token;
        private System.Windows.Forms.DataGridView SymbolTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
    }
}

