using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÜrünStokUygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductsDal _productsDal = new ProductsDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            GetData();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productsDal.Add(new Pruduct
            {
                Name=tbxName.Text,
                Price=Convert.ToDecimal(tbxPrice.Text),
                Stok=Convert.ToInt32(tbxStock.Text),
            });
            GetData();

        }
        

        public void GetData()
        {
            dataGridView1.DataSource = _productsDal.GetAll();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Pruduct pruduct = new Pruduct {

                Name = tbxUpdateName.Text,
                Stok = Convert.ToInt32(tbxUpdateStock.Text),
                Price = Convert.ToDecimal(tbxUpdatePrice.Text),
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)





            };
            _productsDal.Update(pruduct);
            GetData();
            MessageBox.Show("Added ok!");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxUpdateName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxUpdatePrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxUpdateStock.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            _productsDal.Delete(Id);
            GetData();
            MessageBox.Show("Delete Ok!");


        }
    }
}
