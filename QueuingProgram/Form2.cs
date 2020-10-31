using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueuingProgram
{
    public partial class CashierWindowQueue : Form
    {
        Timer timer;
        CustomerView Customer;

        public CashierWindowQueue()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1 * 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            Customer = new CustomerView();
            Customer.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();
            foreach (Object obj in CashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                Customer.labelupdate();
                CashierClass.CashierQueue.Dequeue();
                DisplayCashierQueue(CashierClass.CashierQueue);
            }
            catch
            {
                MessageBox.Show("No more Customer!");
            }
        }
    }
}