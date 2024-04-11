using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace MintaZH2
{
    public partial class Form1 : Form
    {
        BindingList<Adat> countryList = new();


        public Form1()
        {
            InitializeComponent();
            adatBindingSource.DataSource = countryList;
            dataGridView1.DataSource = adatBindingSource;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("european_countries (2).csv");
            var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
            var tömb = csv.GetRecords<Adat>();
            foreach (var item in tömb)
            {
                countryList.Add(item);
            }
        }

        private void adatBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            adatBindingSource.RemoveCurrent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditForm ef = new EditForm();

            ef.Adat = adatBindingSource.Current as Adat;
            ef.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var writer = new StreamWriter("countries.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                /*fájlba  írás*/
                csv.WriteRecords(countryList);
            }
        }
    }
}