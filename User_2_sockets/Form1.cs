﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabOS_11_User_2
{
    public partial class Form1 : Form
    {
        private Socket socket;
        private IPEndPoint ipPoint;
        public Form1()
        {
            InitializeComponent();

            // адрес и порт сервера, к которому будем подключаться
            int port = 8005; // порт сервера
            string address = "127.0.0.1"; // адрес сервера

            try
            {
                ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
                // подключаемся к удаленному хосту
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            InitTimer();

        }

        private Timer timer;
        public void InitTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Interval = 100; // in miliseconds
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetMessage();
        }

        public void GetMessage()
        {
            // получаем ответ
            byte[] data = new byte[256]; // буфер для ответа
            StringBuilder builder = new StringBuilder();
            int bytes = 0; // количество полученных байт

            if (socket.Available == 0)
                return;

            bytes = socket.Receive(data, data.Length, 0);

            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));

            textBox_Chat.Text += "User_1: " + builder.ToString();
            textBox_Chat.Text += System.Environment.NewLine;
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            string message = textBox_Message.Text;

            textBox_Chat.Text += "User_2: " + message;
            textBox_Chat.Text += System.Environment.NewLine;

            byte[] data = Encoding.Unicode.GetBytes(message);
            socket.Send(data);
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            GetMessage();
        }
    }
}
