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
            char[] arr = SourceCodeBox.Text.ToCharArray();
            foreach(char item in arr)
            {
                TokenBox.Rows.Add(item, item);
            }
        }
    }
}