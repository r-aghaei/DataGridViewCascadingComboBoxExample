using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewCascadingComboBoxExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BindingList<Category> Categories;
        BindingList<Product> Products;
        BindingList<OrderItem> OrderItems;
        private void Form1_Load(object sender, EventArgs e)
        {
            Categories = new BindingList<Category>(Repository.GetCategories());
            Products = new BindingList<Product>(Repository.GetProducts());
            OrderItems = new BindingList<OrderItem>(Repository.GetOrderItems());

            var categoryIdComboBoxColumn = new DataGridViewComboBoxColumn();
            categoryIdComboBoxColumn.Name = "categoryIdComboBoxColumn";
            categoryIdComboBoxColumn.DataPropertyName = "CategoryId";
            categoryIdComboBoxColumn.DataSource = Categories;
            categoryIdComboBoxColumn.ValueMember = "Id";
            categoryIdComboBoxColumn.DisplayMember = "Name";
            categoryIdComboBoxColumn.HeaderText = "Category";

            var productIdComboBoxColumn = new DataGridViewComboBoxColumn();
            productIdComboBoxColumn.Name = "productIdComboBoxColumn";
            productIdComboBoxColumn.DataPropertyName = "ProductId";
            productIdComboBoxColumn.DataSource = Products;
            productIdComboBoxColumn.ValueMember = "Id";
            productIdComboBoxColumn.DisplayMember = "Name";
            productIdComboBoxColumn.HeaderText = "Product";

            var quantityTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityTextBoxColumn.Name = "quantityTextBoxColumn";
            quantityTextBoxColumn.DataPropertyName = "Quantity";
            quantityTextBoxColumn.HeaderText = "Quantity";

            this.dataGridView1.Columns.AddRange(categoryIdComboBoxColumn, productIdComboBoxColumn, quantityTextBoxColumn);
            this.dataGridView1.DataSource = OrderItems;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                var c = (DataGridViewComboBoxEditingControl)e.Control;
                var value = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value;
                if (value != null)
                    c.DataSource = Products.Where(x => x.CategoryId == (int?)value).ToList();
                else
                    c.DataSource = null;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                this.dataGridView1.Rows[e.RowIndex].Cells[1].Value = null;
        }
    }
}
