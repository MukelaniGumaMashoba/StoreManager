using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class BusinessLayerClass
    {
        DataLayerClass show = new DataLayerClass();
        public void Inserting(string name, int quantity, double price, double stock)
        {
            // adding data in the database
            show.connectDataBase(name, quantity, price, stock);
        }
        public double getAmount(double price,double quantity)
        {
            // ngithola i amount ye stock value
            double amount = price * quantity;
            return amount;
        }
        public void updateValues(string name, int quantity, double price, double stock)
        {
            // ngi update ama values of the stock you...
            show.update(name, quantity, price, stock);
        }
        public void deleteValues(string name)
        {
            // just enter name of product and press delete izobe isingasekho nje fast 
            show.delete(name);
        }
        /*public void display()
        {
            show.displayingData();
        }*/
    }
}
