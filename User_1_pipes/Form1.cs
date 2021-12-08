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


namespace LabOS_11_User_1
{
    public partial class Form1 : Form
    {
        private int port = 8005;
        private IPEndPoint ipPoint;
        private Socket listenSocket;
        Socket handler;
        private bool flag = false;
        public Form1()
        {
            InitializeComponent();

            // получаем адреса для запуска сокета
            ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // создаем сокет
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // связываем сокет с локальной точкой, по которой будем принимать данные
            listenSocket.Bind(ipPoint);

            // начинаем прослушивание
            listenSocket.Listen(10);
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
            if (flag == false)
                return;

            StringBuilder builder = new StringBuilder();
            int bytes = 0; // количество полученных байтов
            byte[] data = new byte[256]; // буфер для получаемых данных
            
            if (handler.Available == 0)
                return;

            bytes = handler.Receive(data, data.Length, 0);
            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));

            textBox_Chat.Text += "User_2: " + builder.ToString();
            textBox_Chat.Text += System.Environment.NewLine;
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            try
            {
                if (flag == false)
                {
                    handler = listenSocket.Accept();
                    flag = true;
                }    

                byte[] data = new byte[256]; // буфер для получаемых данных

                // отправляем ответ
                string message = textBox_Message.Text;

                textBox_Chat.Text += "User_1: " + message;
                textBox_Chat.Text += System.Environment.NewLine;

                data = Encoding.Unicode.GetBytes(message);
                handler.Send(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetMessage();
        }
    }
}
