using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            if (progressBar1.Value == 100) button1.Text = "DONE";
            if (!backgroundWorker1.CancellationPending) button1.Text = e.ProgressPercentage.ToString();
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

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Erosion();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Dilation();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter1 = new Erosion();
            Filters filter2 = new Dilation();

            image = filter1.processImage(image);
            backgroundWorker1.RunWorkerAsync(filter2);
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter1 = new Dilation();
            Filters filter2 = new Erosion();

            image = filter1.processImage(image);
            backgroundWorker1.RunWorkerAsync(filter2);
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap new_image1 = (Bitmap)image.Clone();
            Bitmap new_image2 = new Bitmap(image.Width, image.Height);
            Filters filter1 = new Erosion();
            Filters filter2 = new Dilation();

            image = filter1.processImage(image);
            image = filter2.processImage(image);

            for (int i = 0; i < image.Width; ++i)
            {
                for(int j = 0; j < image.Height; ++j)
                {
                    Color new_color = Color.FromArgb(filter1.clamp(new_image1.GetPixel(i, j).R - image.GetPixel(i, j).R, 0, 0xff),
                                                     filter1.clamp(new_image1.GetPixel(i, j).G - image.GetPixel(i, j).G, 0, 0xff),
                                                     filter1.clamp(new_image1.GetPixel(i, j).B - image.GetPixel(i, j).B, 0, 0xff));
                    image.SetPixel(i, j, new_color);
                }
            }

            pictureBox1.Image = image;
            pictureBox1.Refresh();
        }

        private void изменитьЯдроToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string width  = Interaction.InputBox("Ширина ядра", "Width", Morphology.x.ToString());
            string height = Interaction.InputBox("Высота ядра", "Height", Morphology.y.ToString());

            bool result;
            int new_width;
            int new_height;

            result = int.TryParse(width, out new_width);
            if (result)
            {
                Morphology.x = new_width;
            }
            result = int.TryParse(height, out new_height);
            if (result)
            {
                Morphology.y = new_height;
            }
        }

        private void медианаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MedianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            button1.Text = "STOP";
        }
    }
}
