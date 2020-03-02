using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kg1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void гауссToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void серыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScale();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void собельПоХToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilterX();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void собельПоУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilterY();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sepia();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void увеличитьЯркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new IncreaseBrightness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void уменьшитьЯркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new DecreaseBrightness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void повыситьРезкостьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Filters filter = new Sharpen();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayWorld();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void нормализацияЯркостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NormalizeBrightness filter = new NormalizeBrightness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сдвигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Shift();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Rotate();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волны1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Waves1();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волны2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Waves2();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
