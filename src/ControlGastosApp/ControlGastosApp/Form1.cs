using ControlGastosApp.Services;
using System;
using System.Linq;

namespace ControlGastosApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadPeriods();
        }
        private void LoadPeriods()
        {
            var service = new PeriodService();

            // Crea/obtiene el periodo actual
            var now = DateTime.Now;
            var current = service.GetOrCreate(now.Year, now.Month);

            // Carga lista de periodos
            var periods = service.GetAll();

            cmbPeriod.DataSource = periods;
            cmbPeriod.DisplayMember = "DisplayName";
            cmbPeriod.ValueMember = "Id";

            // Seleccionar el actual
            var match = periods.FirstOrDefault(p => p.Id == current.Id);
            if (match != null)
                cmbPeriod.SelectedValue = match.Id;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
