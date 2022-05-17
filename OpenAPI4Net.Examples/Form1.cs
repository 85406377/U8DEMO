using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenAPI4Net;

namespace OpenAPI4Net.Examples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenAPI4Net.Examples.Vendor api= new OpenAPI4Net.Examples.Vendor();
            this.label1.Text=api.ToString();
            //SaleorderApi api = new SaleorderApi();
        }
    }
}
