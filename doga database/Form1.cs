using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doga_database
{
    
    public partial class Form1 : Form
    {
        databasehandler db;
        pekaruk p;
        public Form1()
        {
            p = new pekaruk();
            db=new databasehandler();
            InitializeComponent();
            db.readall();
            start();
        }
        int index;
        void start()
        {
            button1.Click += (s, e) =>
            {
                p.name = textBox2.Text;
                p.ammount = Convert.ToInt32(textBox3.Text);
                p.price = Convert.ToInt32(textBox4.Text);
                listadd();
                db.write(p);
            };
            button2.Click += (s, e) =>
            {
                db.deleteone(p);
                listBox1.Items.RemoveAt(index);
            };
            listBox1.SelectedIndexChanged += (s, e) =>
            {
                index = listBox1.SelectedIndex;
            };
        }
        public void listadd()
        {
                p.name = textBox2.Text;
                listBox1.Items.Add($" Pékáru neve{textBox2.Text} Mennyiség{textBox3.Text} Ár{textBox4.Text} ");
        }
    }
}
