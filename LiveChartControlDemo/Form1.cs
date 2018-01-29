using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LiveChartControlDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var data = db.GetTotalOrders();
                ColumnSeries col = new ColumnSeries() { DataLabels = true, Values = new ChartValues<int>(), LabelPoint = point => point.Y.ToString() };
                Axis ax = new Axis() { Separator = new Separator() { Step = 1, IsEnabled = false } };
                ax.Labels = new List<string>();

                foreach (var x in data)
                {
                    col.Values.Add(x.Total.Value);
                    ax.Labels.Add(x.Year.ToString());
                }
                cartesianChart1.Series.Add(col);
                cartesianChart1.AxisX.Add(ax);
                cartesianChart1.AxisY.Add(new Axis {
                    LabelFormatter = value => value.ToString(),
                    Separator = new Separator()
                });


            }

        }
    }
}
