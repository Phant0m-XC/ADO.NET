using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace DZ4
{
    public partial class Form1 : Form
    {
        private string sellerXml = "seller.xml";
        private string buyerXml = "buyer.xml";
        private string productXml = "product.xml";
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            //////SELLER
            try
            {
                if (File.Exists(sellerXml))
                {
                    XDocument seller = XDocument.Load(sellerXml);
                    loadSeller(seller);
                }
                else
                    File.Create(sellerXml).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка структуры " + sellerXml, MessageBoxButtons.OK);
            }

            //////BUYER
            try
            {
                if (File.Exists(buyerXml))
                {
                    XDocument buyer = XDocument.Load(buyerXml);
                    loadBuyer(buyer);
                }
                else
                    File.Create(buyerXml).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка структуры " + buyerXml, MessageBoxButtons.OK);
            }

            //////PRODUCT
            try
            {
                if (File.Exists(productXml))
                {
                    XDocument product = XDocument.Load(productXml);
                    loadProduct(product);
                }
                else
                    File.Create(productXml).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка структуры " + productXml, MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName, lastName;
            Form2 form2 = new Form2();
            DialogResult result = form2.ShowDialog(out firstName, out lastName);
            if (result == DialogResult.OK)
                listBox1.Items.Add(string.Format(firstName + "_" + lastName));
        }

        private void loadSeller(XDocument seller)
        {
            var result = from s in seller.Descendants()
                         select s;
            foreach (var item in result)
                if (item.Name == "Seller")
                    listBox1.Items.Add(item.FirstAttribute.Value);
        }
        private void loadBuyer(XDocument buyer)
        {
            var result = from s in buyer.Descendants()
                         select s;
            foreach (var item in result)
                if (item.Name == "Buyer")
                    listBox2.Items.Add(item.FirstAttribute.Value);
        }
        private void loadProduct(XDocument product)
        {
            var result = from s in product.Descendants()
                         select s;
            foreach (var item in result)
                if (item.Name == "Product")
                    listBox3.Items.Add(item.FirstAttribute.Value);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            XDocument seller = new XDocument(new XElement("Sellers"));
            foreach (var node in listBox1.Items)
                seller.Root.Add(new XElement("Seller", new XAttribute("FIO", node.ToString())));
            seller.Save(sellerXml);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            XDocument buyer = new XDocument(new XElement("Buyers"));
            foreach (var node in listBox2.Items)
                buyer.Root.Add(new XElement("Buyer", new XAttribute("FIO", node.ToString())));
            buyer.Save(buyerXml);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            XDocument product = new XDocument(new XElement("Products"));
            foreach (var node in listBox3.Items)
                product.Root.Add(new XElement("Product", new XAttribute("Name", node.ToString())));
            product.Save(productXml);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string firstName, lastName;
            Form2 form2 = new Form2();
            DialogResult result = form2.ShowDialog(out firstName, out lastName);
            if (result == DialogResult.OK)
                listBox2.Items.Add(string.Format(firstName + "_" + lastName));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string firm, model;
            Form3 form3 = new Form3();
            DialogResult result = form3.ShowDialog(out firm, out model);
            if (result == DialogResult.OK)
                listBox3.Items.Add(string.Format(firm + "_" + model));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && listBox2.SelectedItem != null && listBox3.SelectedItem != null)
            {
                ListViewItem item = new ListViewItem(DateTime.Now.ToString());
                item.SubItems.Add(listBox1.SelectedItem.ToString());
                item.SubItems.Add(listBox2.SelectedItem.ToString());
                item.SubItems.Add(listBox3.SelectedItem.ToString());
                listView1.Items.Add(item);
            }
            else
                MessageBox.Show("Кто-то не выбран :)", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.Items != null)
            {
                XDocument doc = new XDocument(new XElement("Receipt"));
                Regex reg = new Regex(":");
                string path;
                foreach (var item in listView1.Items)
                {
                    path = reg.Replace(((ListViewItem)item).Text, "_");
                    File.Create($"{path}.xml").Close();
                    doc.Root.Add(new XElement("Data", new XAttribute("Data", ((ListViewItem)item).Text)));
                    doc.Root.Add(new XElement("Seller", new XAttribute("Seller", ((ListViewItem)item).SubItems[1].Text)));
                    doc.Root.Add(new XElement("Buyer", new XAttribute("Buyer", ((ListViewItem)item).SubItems[2].Text)));
                    doc.Root.Add(new XElement("Product", new XAttribute("Product", ((ListViewItem)item).SubItems[3].Text)));
                    doc.Save($"{path}.xml");
                }
                listView1.Items.Clear();
            }
        }
    }
}
