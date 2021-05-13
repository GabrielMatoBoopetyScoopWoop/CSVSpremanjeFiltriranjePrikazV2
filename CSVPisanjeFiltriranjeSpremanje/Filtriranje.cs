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
    public partial class Filtriranje : Form
    {
        string Putanja = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "csvTransformer.csv");
        string PutanjaFiltrirano = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "csvTransformerFiltrirano.csv");
        public Filtriranje()
        {
            InitializeComponent();
        }

        private void ZavrsiButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FiltrirajButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(Putanja))
            {
                using (StreamReader sr = new StreamReader(Putanja))
                {
                    string line;
                    using (StreamWriter sw = new StreamWriter(PutanjaFiltrirano))
                    {
                        sw.WriteLine("Ime,Prezime,Email,Razred");
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (
                                sr.ReadLine().Contains(ImeTextBox.Text) ||
                                sr.ReadLine().Contains(PrezimeTextBox.Text) ||
                                sr.ReadLine().Contains(EmailTextBox.Text) ||
                                sr.ReadLine().Contains(RazredComboBox.Text)
                               )
                            {
                                sw.WriteLine(sr.ReadLine());
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Izradite novi dokument", "Nema dokumenta", MessageBoxButtons.OK);
            }
        }
    }
}
