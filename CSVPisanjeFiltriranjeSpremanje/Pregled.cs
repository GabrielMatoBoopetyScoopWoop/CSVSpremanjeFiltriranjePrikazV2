using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSVPisanjeFiltriranjeSpremanje
{
    public partial class Pregled : Form
    {
        string Putanja = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "csvTransformer.csv");
        string PutanjaFiltrirano = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "csvTransformerFiltrirano.csv");
        public Pregled()
        {
            InitializeComponent();
        }
        private void UcitajButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want a filtered result? If not click then -No- to get a normal result.", "Filtered or normal?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (File.Exists(PutanjaFiltrirano))
                {
                    using (StreamReader sr = new StreamReader(PutanjaFiltrirano))
                    {
                        TekstKutija.Text = sr.ReadToEnd();
                    }
                }
                else
                {
                    MessageBox.Show("Izradite novi dokument", "Nema dokumenta", MessageBoxButtons.OK);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                if (File.Exists(Putanja))
                {
                    using (StreamReader sr = new StreamReader(Putanja))
                    {
                        TekstKutija.Text = sr.ReadToEnd();
                    }
                }
                else
                {
                    MessageBox.Show("Izradite novi dokument", "Nema dokumenta", MessageBoxButtons.OK);
                }
            }
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FiltrirajButton_Click(object sender, EventArgs e)
        {
            Filtriranje FormFiltriranje = new Filtriranje();
            FormFiltriranje.Show();
        }
    }
}
