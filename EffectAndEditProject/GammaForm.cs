using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EffectAndEditProject
{
    public partial class GammaForm : Form
    {
        public GammaForm()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public double RedComponent
        {
            get
            {
                return Convert.ToDouble(Redtxt.Text);
            }
            set { Redtxt.Text = value.ToString(); }
        }

        public double GreenComponent
        {
            get
            {
                return Convert.ToDouble(greentxt.Text);
            }
            set { greentxt.Text = value.ToString(); }
        }

        public double BlueComponent
        {
            get
            {
                return Convert.ToDouble(bluetxt.Text);
            }
            set { bluetxt.Text = value.ToString(); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void GammaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
