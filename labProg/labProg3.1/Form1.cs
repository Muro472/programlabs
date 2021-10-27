using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (Context context = new Context())
            {
                dataGridView1.DataSource = context.Products.ToList<Products>();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (Context context = new Context())
            {
                dataGridView1.DataSource = context.Products
                    .Where( elem => elem.type == "prodovol")
                    .ToList<Products>();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (Context context = new Context())
            {
                dataGridView1.DataSource = context.Products
                    .OrderByDescending(elem => elem.price)
                    .Take(1)
                    .ToList<Products>();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (Context context = new Context())
            {
                var listAboba = context.Products.ToList<Products>().GroupBy(elem => elem.type);
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Add("colum1", null);
                dataGridView1.Columns.Add("colum2", null);
                foreach (var group in listAboba)
                {
                    dataGridView1.Rows.Add(group.Key, group.Count());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (Context context = new Context())
            {
                context.Products
                    .ToList<Products>()
                    .ForEach(elem => elem.price += 13);
                dataGridView1.DataSource = context.Products.ToList<Products>();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (Context context = new Context())
            {
                dataGridView1.DataSource = context.Products
                    .OrderBy(elem => elem.price)
                    .Skip(1)
                    .ToList<Products>();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (Context context = new Context())
            {
                MessageBox.Show(context.Products
                    .All(elem => elem.price >= 1).ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (Context context = new Context())
            {
                MessageBox.Show(context.Products
                    .Any(elem => elem.price >= 1).ToString());
            }
        }
    }
}
