﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlExample
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private static UserControl1 _instance;
        public static UserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl1();
                return _instance;
            }
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
