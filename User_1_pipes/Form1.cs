using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabOS_11_User_1_sockets
{
    public partial class Form1 : Form
    {
        private NamedPipeServerStream pipeServer;
        public Form1()
        {
            InitializeComponent();

            pipeServer =
                new NamedPipeServerStream("Pipe", PipeDirection.InOut, 1, PipeTransmissionMode.Byte);

            // Wait  for a client to connect
            pipeServer.WaitForConnection();

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
            if (new FileInfo(@"C:\Users\User\source\repos\LabOS_11_User_1_sockets\LabOS_11_User_1_sockets\pipes_2.txt").Length == 0)
            {
                return;
            }

            StreamReader sr = new StreamReader(pipeServer);

            // Display the read text to the console
            string temp;

            if((temp = sr?.ReadLine()) != null)
            {
                textBox_Chat.Text += "User_2: " + temp;

                File.WriteAllText(@"C:\Users\User\source\repos\LabOS_11_User_1_sockets\LabOS_11_User_1_sockets\pipes_2.txt", string.Empty);

                textBox_Chat.Text += System.Environment.NewLine;

                sr.Close();

                pipeServer =
                new NamedPipeServerStream("Pipe", PipeDirection.InOut, 1, PipeTransmissionMode.Byte);
                pipeServer.WaitForConnection();
            }
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter =
               new StreamWriter(@"C:\Users\User\source\repos\LabOS_11_User_1_sockets\LabOS_11_User_1_sockets\pipes.txt");

            try
            {
                // Read user input and send that to the client process.

                using (StreamWriter sw = new StreamWriter(pipeServer))
                {
                    sw.AutoFlush = true;
                    streamWriter.WriteLine("Data pushed!");
                    streamWriter.Close();
                    textBox_Chat.Text += "User_1: " + textBox_Message.Text;
                    textBox_Chat.Text += System.Environment.NewLine;
                    sw.WriteLine(textBox_Message.Text);
                }
            }
            // Catch the IOException that is raised if the pipe is broken
            // or disconnected.
            catch (IOException ex)
            {
                Console.WriteLine("ERROR: {0}", ex.Message);
            }
            pipeServer = new NamedPipeServerStream("Pipe", PipeDirection.InOut, 1, PipeTransmissionMode.Byte);
            pipeServer.WaitForConnection();
        }
    }
}
