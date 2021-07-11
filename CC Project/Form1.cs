using System;
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
            FirstandFollowView form = new FirstandFollowView();
            form.Show();

            
        }

        private List<Token> GenerateToken()
        {
            TokenBox.Rows.Clear();
            Tokenizer tokenizer = new Tokenizer(SourceCodeBox.Text);
            var ListOftokens = tokenizer.TryTokenize();
            foreach(var item in ListOftokens)
            {
                TokenBox.Rows.Add(item.Value, item.TokenType);
            }
            return ListOftokens;
        }

        void PopulateSymbolTable(List<Token> list_tokens)
        {
            SymbolTable.Rows.Clear();
            SymbolTable st = new SymbolTable();
            var ListOfSymbols=st.FindAndInsert(list_tokens);
            foreach(var item in ListOfSymbols)
            {
                SymbolTable.Rows.Add(item.Id, item.Value, item.Type);
            }
        }
        private void SourceCodeBox_TextChanged(object sender, EventArgs e)
        {
            var List=GenerateToken();
            PopulateSymbolTable(List);
            CreateCodewithTokens(List);
        }

        void CreateCodewithTokens(List<Token> listoftoken)
        {
            TokenCodeBoc.Text="";
            foreach(var item in listoftoken)
            {
                string potc = "<" + item.TokenType + ">";
                TokenCodeBoc.Text += potc;
            }
        }
    }
}
