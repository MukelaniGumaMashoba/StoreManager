﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
       
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_Price.Clear();
            textBox_ProName.Clear();
            textBox_Quantity.Clear();
            textBox_Stock.Clear();
        }

        private void button_Insert_Click(object sender, EventArgs e)
        {
            string name = textBox_ProName.Text;
            int quantity = int.Parse(textBox_Quantity.Text);
            double price = double.Parse(textBox_Price.Text);

            BusinessLayerClass insertData = new BusinessLayerClass();
            double stock = insertData.getAmount(price, quantity);

            textBox_Stock.Text = stock.ToString();

            insertData.Inserting(name,quantity,price,stock);



            MessageBox.Show("Ihambile");

            insertData.display();
            
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            BusinessLayerClass updateData = new BusinessLayerClass();

            string name = textBox_ProName.Text;
            int quantity = int.Parse(textBox_Quantity.Text);
            double price = double.Parse(textBox_Price.Text);
            double stock = updateData.getAmount(price, quantity);

            textBox_Stock.Text = stock.ToString();


            updateData.updateValues(name, quantity, price, stock);

            MessageBox.Show("Updated");
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            BusinessLayerClass deleteData = new BusinessLayerClass();

            string name = textBox_ProName.Text;

            deleteData.deleteValues(name);

            MessageBox.Show("Deleted Data");
        }
    }
}
