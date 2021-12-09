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

namespace LabOS_11_User_2_sockets
{
    public partial class Form1 : Form
    {
        private NamedPipeClientStream pipeClient;
        public Form1()
        {
            InitializeComponent();

            pipeClient = new NamedPipeClientStream(".", "Pipe", PipeDirection.InOut);

            // Connect to the pipe or wait until the pipe is available.
            pipeClient.Connect();

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
            if (new FileInfo(@"C:\Users\User\source\repos\LabOS_11_User_1_sockets\LabOS_11_User_1_sockets\pipes.txt").Length == 0)
            {
                return;
            }

            StreamReader sr = new StreamReader(pipeClient);
            
            // Display the read text to the console
            string temp;
            
            while ((temp = sr.ReadLine()) != null)
            {
                textBox_Chat.Text += "User_1: " + temp;

                File.WriteAllText(@"C:\Users\User\source\repos\LabOS_11_User_1_sockets\LabOS_11_User_1_sockets\pipes.txt", string.Empty);

                textBox_Chat.Text += System.Environment.NewLine;

                // pipeClient.WaitForPipeDrain();
                //pipeClient.WaitForPipeDrain();
            }

            if (!pipeClient.IsConnected)
            {
                System.Threading.Thread.Sleep(100);
                pipeClient.Connect();
            }
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter =
               new StreamWriter(@"C:\Users\User\source\repos\LabOS_11_User_1_sockets\LabOS_11_User_1_sockets\pipes_2.txt");

            try
            {
                // Read user input and send that to the client process.

                using (StreamWriter sw = new StreamWriter(pipeClient))
                {
                    sw.AutoFlush = true;
                    streamWriter.WriteLine("Data pushed!");
                    streamWriter.Close();
                    textBox_Chat.Text += "User_2: " + textBox_Message.Text;
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
            
            pipeClient = new NamedPipeClientStream(".", "Pipe", PipeDirection.InOut);
            System.Threading.Thread.Sleep(100);
            pipeClient.Connect();
        }
    }
}
