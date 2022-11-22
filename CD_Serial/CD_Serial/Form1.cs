using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CD_Serial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Current_Directory = System.IO.Directory.GetCurrentDirectory();
            Current_Directory = Current_Directory + "\\" + "Save.pbt";
        }
        public int Count;
        private string Current_Directory;
        private void button1_Click(object sender, EventArgs e)
        {
            FileExists_Process();
            FileStream FFs = new FileStream(Current_Directory, FileMode.Open);
            BinaryWriter Bw = new BinaryWriter(FFs);

            Count = Convert.ToInt32(textBox1.Text);

            Bw.Write(Count);

            Bw.Close();
            FFs.Close();
            MessageBox.Show("발행 완료");
        }

        private void FileExists_Process()
        {
            DirectoryInfo di = new DirectoryInfo(Current_Directory);
            if (di.Exists == false)
            {
                System.IO.FileStream FFs = new System.IO.FileStream(Current_Directory, FileMode.Create);
                FFs.Close();
            }
        }
             
    }
}
