using ficha5_HolidayWebService.HolidayService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ficha5_HolidayWebService {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            nudYear.Value = DateTime.Now.Year;
        }

        private void btGet_Click(object sender, EventArgs e) {
            int year = (int)nudYear.Value;
            HolidaySoapClient client = new HolidaySoapClient();
            Holiday[] feriados = client.GetAllHolidays(year);

            lbHolidays.Items.Clear();
            foreach (var item in feriados) {
                string name;
                switch (item.Type) {
                    case HolidayType.Municipal:
                        name = $"{item.Name} ({item.Municipality.Name})";
                        break;
                    case HolidayType.National:
                    case HolidayType.Regional:
                    case HolidayType.Religious:
                    case HolidayType.Optional:
                    default:
                        name = item.Name;
                        break;
                }
                lbHolidays.Items.Add($"{item.Date.ToShortDateString()} : {name} : {item.Description}");
            }

            client.Close();

        }
    }
}
