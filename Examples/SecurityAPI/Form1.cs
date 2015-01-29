using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecurityAPI
{
    public partial class Form1 : Form
    {

        SecurityStuff _securityStuff;

        public Form1()
        {
    
            InitializeComponent();
            _securityStuff = new SecurityStuff();
            SecurityTabPage.Controls.Add(_securityStuff);
            _securityStuff.Dock = DockStyle.Fill;
           
        }
    }
}
