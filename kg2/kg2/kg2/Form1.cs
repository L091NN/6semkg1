using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kg2
{
    public partial class Form1 : Form
    {
        private bool loaded;
        private View view;
        private Bin  bin;

        public Form1()
        {
            InitializeComponent();

            loaded = false;
            view   = new View();
            bin    = new Bin();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();

            if(DialogResult.OK == open_file_dialog.ShowDialog())
            {
                string file_name = open_file_dialog.FileName;

                bin.readBIN(file_name);
                // view.SetupView(bin, glControl1.Width, glControl1.Height);
                loaded = true;
                // glControl1.Invalidate();
            }
        }
    }
}
