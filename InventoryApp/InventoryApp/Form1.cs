using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace InventoryApp
{
    public partial class Form1 : Form
    {
        BindingList<string> inventoryList = new BindingList<string>();

        public Form1()
        {
            InitializeComponent();

            //List<string> inventoryList = new List<string>(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }
            
        private void button2_Click(object sender, EventArgs e)
        {

            

            inventoryList.Remove(inputBox.Text);
            //listBox1.DataSource = null;
            listBox1.DataSource = inventoryList;
            xmlWrite();
            nodeRemove();
            error();

            

        }
      

        public void button3_Click(object sender, EventArgs e)
        {
                    
                inventoryList.Add(inputBox.Text);        
                //listBox1.DataSource = null;
                listBox1.DataSource = inventoryList;
                xmlWrite();
                error();
                
        }
        public void xmlWrite()
        {
            Stream stream = File.OpenWrite(Environment.CurrentDirectory + "\\File.xml");
            XmlSerializer xmlSer = new XmlSerializer(typeof(BindingList<string>));
            //We are now putting everything together.  We are using the Serialize process to pass our configuration and the list of person.
            xmlSer.Serialize(stream, inventoryList);
            //we need to close our stream
            stream.Close();

            Console.WriteLine(Environment.CurrentDirectory);
        }
        public void nodeRemove()
        {
        XmlDocument inventoryList = new XmlDocument();

        inventoryList.Load(Environment.CurrentDirectory + "\\File.xml");

        XmlNodeList list = inventoryList.SelectNodes("//*[not(string(.))]");
            foreach (XmlNode node in list)
            {
                node.ParentNode.RemoveChild(node);
            }
         inventoryList.Save(Environment.CurrentDirectory + "\\File.xml");
        }

        public void error()
        {
            try
            {

            }
            catch
            {
            }
        }
    }
}
