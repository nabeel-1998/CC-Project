
namespace CC_Project
{
    partial class FirstandFollowView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ffsets = new System.Windows.Forms.DataGridView();
            this.NONTERMINALS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIRSTSET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOLLOWSET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ffsets)).BeginInit();
            this.SuspendLayout();
            // 
            // ffsets
            // 
            this.ffsets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ffsets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NONTERMINALS,
            this.FIRSTSET,
            this.FOLLOWSET});
            this.ffsets.Location = new System.Drawing.Point(69, 26);
            this.ffsets.Name = "ffsets";
            this.ffsets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ffsets.Size = new System.Drawing.Size(1143, 401);
            this.ffsets.TabIndex = 0;
           
            // 
            // NONTERMINALS
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NONTERMINALS.DefaultCellStyle = dataGridViewCellStyle1;
            this.NONTERMINALS.HeaderText = "NON TERMINAL";
            this.NONTERMINALS.Name = "NONTERMINALS";
            this.NONTERMINALS.ReadOnly = true;
            // 
            // FIRSTSET
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FIRSTSET.DefaultCellStyle = dataGridViewCellStyle2;
            this.FIRSTSET.HeaderText = "FIRST SET";
            this.FIRSTSET.Name = "FIRSTSET";
            this.FIRSTSET.ReadOnly = true;
            this.FIRSTSET.Width = 500;
            // 
            // FOLLOWSET
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FOLLOWSET.DefaultCellStyle = dataGridViewCellStyle3;
            this.FOLLOWSET.HeaderText = "FOLLOW SET";
            this.FOLLOWSET.Name = "FOLLOWSET";
            this.FOLLOWSET.ReadOnly = true;
            this.FOLLOWSET.Width = 500;
            // 
            // FirstandFollowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 450);
            this.Controls.Add(this.ffsets);
            this.Name = "FirstandFollowView";
            this.Text = "FirstandFollowView";
            this.Load += new System.EventHandler(this.FirstandFollowView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ffsets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ffsets;
        private System.Windows.Forms.DataGridViewTextBoxColumn NONTERMINALS;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIRSTSET;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOLLOWSET;
    }
}