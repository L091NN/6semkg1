using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace kg2
{
    enum DrawType
    {
        QUADS,
        QUAD_STRIP,
        TEXTURE
    }

    public partial class Form1 : Form
    {
        private int      frame_count;
        private int      current_layer;
        private bool     auto_draw;
        private bool     need_reload;
        private bool     loaded;
        private DrawType draw_type;
        private DateTime next_fps_update;
        private View     view;
        private Bin      bin;

        public Form1()
        {
            InitializeComponent();

            trackBar1.Minimum     = 0x0;
            trackBar2.Minimum     = 0x0;
            trackBar2.Maximum     = 0x7d0;
            trackBar3.Minimum     = 0x0;
            trackBar3.Maximum     = 0x7d0;
            QuadsCheckBox.Checked = true;
            next_fps_update       = DateTime.Now.AddSeconds(1);
            frame_count           = 0x0;
            loaded                = false;
            view                  = new View();
            bin                   = new Bin();
            view.width            = 0x0;
            view.min              = 0x0;
        }


        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();

            if(DialogResult.OK == open_file_dialog.ShowDialog())
            {
                string file_name = open_file_dialog.FileName;

                bin.readBIN(file_name);
                view.SetupView(bin, glControl1.Width, glControl1.Height);
                glControl1.Invalidate();

                trackBar1.Maximum = bin.z - 10;
                loaded            = true;

                if(DrawType.TEXTURE == draw_type)
                {
                    view.GenerateTextureImage(bin, current_layer);
                    view.Load2DTexture();
                    view.DrawTexture(bin);

                    need_reload = false;
                }
            }
        }


        private void Draw()
        {
            if (loaded)
            {
                switch (draw_type)
                {
                    case DrawType.QUADS:
                        view.DrawQuads(bin, current_layer);
                        break;
                    case DrawType.QUAD_STRIP:
                        view.DrawQuadStrips(bin, current_layer);
                        break;
                    case DrawType.TEXTURE:
                        if (need_reload)
                        {
                            view.GenerateTextureImage(bin, current_layer);
                            view.Load2DTexture();
                            need_reload = false;
                        }

                        view.DrawTexture(bin);
                        break;
                }
                glControl1.SwapBuffers();
            }
        }


        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }


        void Application_Idle(object sender, EventArgs e)
        {
            while (glControl1.IsIdle)
            {
                DisplayFPS();
                glControl1.Invalidate();

            }

            if (auto_draw)
            {
                trackBar1.Value++;
                trackBar1.Value %= trackBar1.Maximum;
                current_layer    = trackBar1.Value;

                if (DrawType.TEXTURE == draw_type)
                {
                    need_reload = true;
                }

                Draw();
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Idle += Application_Idle;
        }


        private void DisplayFPS()
        {
            if(DateTime.Now >= next_fps_update)
            {
                this.Text       = string.Format("CT Visualizer (fps = {0})", frame_count);
                next_fps_update = DateTime.Now.AddSeconds(1);
                frame_count     = 0;
            }
            frame_count++;
        }


        private void QuadsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check_box = (CheckBox)sender;

            if (check_box.Checked)
            {
                draw_type                 = DrawType.QUADS;
                TextureCheckBox.Checked   = false;
                QuadStripCheckBox.Checked = false;
            }
            else if (!TextureCheckBox.Checked && !QuadStripCheckBox.Checked)
            {
                check_box.Checked = true;
            }
        }


        private void TextureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check_box = (CheckBox)sender;

            if (check_box.Checked)
            {
                draw_type                 = DrawType.TEXTURE;
                QuadsCheckBox.Checked     = false;
                QuadStripCheckBox.Checked = false;

                Draw();
            }
            else if (!QuadsCheckBox.Checked && !QuadStripCheckBox.Checked)
            {
                check_box.Checked = true;
            }
        }


        private void QuadStripCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check_box = (CheckBox)sender;

            if (check_box.Checked)
            {
                draw_type               = DrawType.QUAD_STRIP;
                TextureCheckBox.Checked = false;
                QuadsCheckBox.Checked   = false;
            }
            else if (!TextureCheckBox.Checked && !QuadsCheckBox.Checked)
            {
                check_box.Checked = true;
            }
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            current_layer = trackBar1.Value;

            if (DrawType.TEXTURE == draw_type)
            {
                need_reload = true;
            }

            Draw();
        }


        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            view.min = trackBar2.Value;

            Console.WriteLine("min: " + view.min.ToString());

            Draw();
        }


        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            view.width = trackBar3.Value;

            Console.WriteLine("width: " + view.width.ToString());

            Draw();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check_box = (CheckBox)sender;

            if (check_box.Checked)
            {
                auto_draw = true;
            }
            else
            {
                auto_draw = false;
            }
        }
    }
}
