using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryForEB;



namespace ElectronicBookkeeping_AK___2
{
    public partial class ElectronicBookkeeping : Form
    {
        public ElectronicBookkeeping()
        {
            InitializeComponent();
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void ElectronicBookkeeping_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Account[] accMass = new Account[14];

            accMass[0] = new Account("1-Envelope 09");
            accMass[1] = new Account("2-Envelope 10");
            accMass[2] = new Account("3-Envelope 11");
            accMass[3] = new Account("4-Envelope 12");
            accMass[4] = new Account("5-Envelope 01");
            accMass[5] = new Account("6-Envelope 02");
            accMass[6] = new Account("7-Envelope 03");
            accMass[7] = new Account("8-Envelope 04");
            accMass[8] = new Account("9-Envelope 05");
            accMass[9] = new Account("10-Envelope 06");

            accMass[10] = new Account("Bank Card");
            accMass[11] = new Account("11-Envelope");
            accMass[12] = new Account("Purse");
            accMass[13] = new Account("Cache");

            Account.WriteToFile(accMass);

            //Thing th1 = new Thing(comboBox6.Text, comboBox6.Text, Convert.ToDouble(comboBox6.Text));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        
    }
}
