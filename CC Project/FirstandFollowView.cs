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
    public partial class FirstandFollowView : Form
    {
        public FirstandFollowView()
        {
            InitializeComponent();
        }

        private async void FirstandFollowView_Load(object sender, EventArgs e)
        {
            FirstandFollowSet sets = new FirstandFollowSet();
            
            List<Sets> list =await sets.findfinalfirstset(); 

            foreach (var item in list)
            {
               

                string firstset = string.Join(", ", item.FirstSet);
                string followset = string.Join(", ", item.FollowSet);
                string FirstSetToDisplay = "{ " +firstset+" }";
                string FollowSetToDisplay = "{ " +followset+" }";
                ffsets.Rows.Add(item.NonTerminal, FirstSetToDisplay, FollowSetToDisplay);
            }

        }

    
    }
}
