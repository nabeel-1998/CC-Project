﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ParsingTableButton_Click(object sender, EventArgs e)
        {

        }

        private void GenerateToken_Click(object sender, EventArgs e)
        {
            TokenBox.Rows.Clear();
            Tokenizer tokenizer = new Tokenizer(SourceCodeBox.Text);
            var ListOftokens = tokenizer.TryTokenize();
            foreach(var item in ListOftokens)
            {
                TokenBox.Rows.Add(item.Value, item.TokenType);
            }
        }

        private void SourceCodeBox_TextChanged(object sender, EventArgs e)
        {
            GenerateToken.PerformClick();
        }
    }
}
