using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primer_Parcial
{
    public partial class Form1 : Form
    {
        List<Alumnos> alum = new List<Alumnos>();
        List<Talleres> tall = new List<Talleres>();
        List<Inscripciones> inscrip = new List<Inscripciones>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
