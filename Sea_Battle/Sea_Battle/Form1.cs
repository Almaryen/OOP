using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accord.Controls;


namespace Sea_Battle
{
    public partial class Form1 : Form
    {
        Playing_field MyPlayF = new Playing_field();
        Playing_field EnemyPlayF = new Playing_field();
        Playing_field MyBatF = new Playing_field();
        Playing_field EnemyBatF = new Playing_field();

        public Form1()
        {
            InitializeComponent();
            Load_PF(GP1, MyPlayF);
            Load_PF(GP12, MyBatF);
            Load_PF(GP2, EnemyPlayF);
            Load_PF(GP22, EnemyBatF);
        }

        private void Load_PF(DataGridView DG,Playing_field Pf)
        {
            DG.Refresh();
            DG.ColumnHeadersVisible = false;
            DG.RowHeadersVisible = false;
           // GP1.ColumnHeadersHeight = (GP1.Height / 10)-2;
           // GP1.RowHeadersWidth = (GP1.Width / 10)-2;
            ArrayDataView ds = new ArrayDataView(Pf.GamePlay);
            DG.DataSource = ds;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
           MyPlayF.reset();
           MyPlayF.arrangement();
           Load_PF(GP1, MyPlayF);
           Get_color(GP1);

           EnemyPlayF.reset();
           EnemyPlayF.arrangement();
           Load_PF(GP2, EnemyPlayF);
           Get_color(GP2);
        }

        private void Get_color(DataGridView DGV)
        {
            for (int i = 0; i < DGV.Rows.Count; i++)
                for (int j = 0; j < DGV.Rows.Count; j++)
            {
                if (DGV.Rows[i].Cells[j].Value.ToString() == "0")
                {
                   // DGV.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Gray;
                }
                else if (DGV.Rows[i].Cells[j].Value.ToString() == "1")
                {
                    DGV.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Green;
                }
                else if (DGV.Rows[i].Cells[j].Value.ToString() == "2")
                {
                    DGV.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }


   
           
    
    
}
