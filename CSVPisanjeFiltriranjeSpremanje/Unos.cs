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
using System.Text.RegularExpressions;

namespace CSVPisanjeFiltriranjeSpremanje
{
    public partial class Unos : Form
    {
        string Putanja = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "csvTransformer.csv");
        List<Ucenik> UcenikObj = new List<Ucenik>();
        public Unos()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Putanja))
            {
                using (StreamWriter sw = File.CreateText(Putanja))
                {
                    sw.WriteLine("Ime,Prezime,Email,Razred");
                    foreach (Ucenik ObjektUcenik in UcenikObj)
                    {
                        sw.WriteLine(ObjektUcenik.ime + "," + ObjektUcenik.prezime + "," + ObjektUcenik.email + "," + ObjektUcenik.razred);
                    }
                }
            }
            else
            {
                File.Delete(Putanja);
                using (StreamWriter sw = File.CreateText(Putanja))
                {
                    sw.WriteLine("Ime,Prezime,Email,Razred");
                    foreach (Ucenik ObjektUcenik in UcenikObj)
                    {
                        sw.WriteLine(ObjektUcenik.ime + "," + ObjektUcenik.prezime + "," + ObjektUcenik.email + "," + ObjektUcenik.razred);
                    }
                }
            }
            Close();
        }

        private void UnosButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmailTextBox.Text.Contains('@'))
                {
                    Ucenik ObjektUcenik = new Ucenik(ImeTextBox.Text, PrezimeTextBox.Text, EmailTextBox.Text, RazredComboBox.Text);
                    UcenikObj.Add(ObjektUcenik);
                    ImeTextBox.Clear();
                    PrezimeTextBox.Clear();
                    EmailTextBox.Clear();
                    RazredComboBox.SelectedIndex = -1;
                    MessageBox.Show("Podatci su unoseni", "Uspijeh!", MessageBoxButtons.OK);
                }
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Greška");
            }
        }
    }
}
