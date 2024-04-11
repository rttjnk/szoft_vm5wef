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
    }
}