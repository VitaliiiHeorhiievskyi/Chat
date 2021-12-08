using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LabOS_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_GoToChat_Click(object sender, EventArgs e)
        {
            if(radioButton_sockets.Checked)
            {
                Process.Start(@"C:\Users\User\source\repos\LabOS_11_User_1\LabOS_11_User_1\bin\Debug\netcoreapp3.1\LabOS_11_User_1.exe");
                Thread.Sleep(100);
                Process.Start(@"C:\Users\User\source\repos\LabOS_11_User_2\LabOS_11_User_2\bin\Debug\netcoreapp3.1\LabOS_11_User_2.exe");
            }
            else
            {
                Process.Start(@"C:\Users\User\source\repos\LabOS_11_User_1_sockets\LabOS_11_User_1_sockets\bin\Debug\netcoreapp3.1\LabOS_11_User_1_pipes.exe");
                Thread.Sleep(100);
                Process.Start(@"C:\Users\User\source\repos\LabOS_11_User_2_sockets\LabOS_11_User_2_sockets\bin\Debug\netcoreapp3.1\LabOS_11_User_2_pipes.exe");
            }
        }

    }
}
