using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        List<Reporte> rep = new List<Reporte>();

        int num_alumnos = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void guardar() {
            FileStream stream = new FileStream("Reporte.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var talleres in tall)
            {
                writer.WriteLine(talleres.Codigo);
                writer.WriteLine(talleres.Nombre);
                writer.WriteLine(talleres.Costo);
            }

            writer.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = "Alumnos.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Alumnos alumno = new Alumnos();
                alumno.Dpi = Convert.ToInt32(reader.ReadLine());
                alumno.Nombre = reader.ReadLine();
                alumno.Direccion = reader.ReadLine();

                alum.Add(alumno);
            }

            reader.Close();

            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Dpi";
            comboBox1.DataSource = alum;
            comboBox1.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Talleres taller = new Talleres();
            taller.Codigo = Convert.ToInt32(comboBox1.SelectedValue);
            taller.Nombre = textBox1.Text;
            taller.Costo = Convert.ToInt32(comboBox1.SelectedValue);

            tall.Add(taller);

            guardar();
            num_alumnos++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inscrip.Clear();
            foreach (var alumno in alum)
            {
                foreach (var taller in tall)
                {
                    if (alumno.Dpi == taller.Costo)
                    {
                        Reporte report = new Reporte();
                        report.Nombre = alumno.Nombre;
                        report.Taller = taller.Nombre;

                        rep.Add(report);
                    }
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = rep;
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Reporte> orden = rep.OrderBy(c => c.Taller).ToList();
            dataGridView1.DataSource = orden;
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = $"La cantidad de alumnos inscritos es {num_alumnos}";
        }
    }
}
