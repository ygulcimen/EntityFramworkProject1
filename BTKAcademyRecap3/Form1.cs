﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTKAcademyRecap3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListProducts();
            ListCategories();
            

        }

        private void ListProducts()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                dgwProduct.DataSource = context.Products.ToList();
            }
        }
        private void ListCategories()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                cbxCategory.DataSource = context.Categories.ToList();
                cbxCategory.DisplayMember = "CategoryName";
                cbxCategory.ValueMember = "CategoryId";
            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch (Exception)
            {

                
            }
            

        }
        private void ListProductsByCategory(int categoryid)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p => p.CategoryId == categoryid).ToList();
            }
        }
        private void ListProductsByProductName(string key)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p => p.ProductName.ToLower().Contains(tbxSearch.Text)).ToList();
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            ListProductsByProductName(tbxSearch.Text.ToLower());
        }
    }
}
