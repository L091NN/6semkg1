namespace kg3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boxSizeBar = new System.Windows.Forms.TrackBar();
            this.boxXBar = new System.Windows.Forms.TrackBar();
            this.boxYBar = new System.Windows.Forms.TrackBar();
            this.boxZBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.boxColorBar = new System.Windows.Forms.TrackBar();
            this.reflectionBar = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.refractionBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.boxSizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxXBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxYBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxZBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxColorBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflectionBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refractionBar)).BeginInit();
            this.SuspendLayout();
            // 
            // boxSizeBar
            // 
            this.boxSizeBar.Location = new System.Drawing.Point(682, 78);
            this.boxSizeBar.Name = "boxSizeBar";
            this.boxSizeBar.Size = new System.Drawing.Size(513, 45);
            this.boxSizeBar.TabIndex = 0;
            this.boxSizeBar.Scroll += new System.EventHandler(this.boxSizeBar_Scroll);
            // 
            // boxXBar
            // 
            this.boxXBar.Location = new System.Drawing.Point(682, 196);
            this.boxXBar.Name = "boxXBar";
            this.boxXBar.Size = new System.Drawing.Size(513, 45);
            this.boxXBar.TabIndex = 1;
            this.boxXBar.Scroll += new System.EventHandler(this.boxXBar_Scroll);
            // 
            // boxYBar
            // 
            this.boxYBar.Location = new System.Drawing.Point(682, 247);
            this.boxYBar.Name = "boxYBar";
            this.boxYBar.Size = new System.Drawing.Size(513, 45);
            this.boxYBar.TabIndex = 2;
            this.boxYBar.Scroll += new System.EventHandler(this.boxYBar_Scroll);
            // 
            // boxZBar
            // 
            this.boxZBar.Location = new System.Drawing.Point(682, 298);
            this.boxZBar.Name = "boxZBar";
            this.boxZBar.Size = new System.Drawing.Size(513, 45);
            this.boxZBar.TabIndex = 3;
            this.boxZBar.Scroll += new System.EventHandler(this.boxZBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(935, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Размер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(935, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Позиция";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(662, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Z:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(662, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(664, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(935, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Цвет";
            // 
            // boxColorBar
            // 
            this.boxColorBar.Location = new System.Drawing.Point(682, 404);
            this.boxColorBar.Name = "boxColorBar";
            this.boxColorBar.Size = new System.Drawing.Size(513, 45);
            this.boxColorBar.TabIndex = 10;
            this.boxColorBar.Scroll += new System.EventHandler(this.boxColorBar_Scroll);
            // 
            // reflectionBar
            // 
            this.reflectionBar.Location = new System.Drawing.Point(682, 490);
            this.reflectionBar.Name = "reflectionBar";
            this.reflectionBar.Size = new System.Drawing.Size(513, 45);
            this.reflectionBar.TabIndex = 11;
            this.reflectionBar.Scroll += new System.EventHandler(this.reflectionBar_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(885, 452);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Коэффициент отражения";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(885, 538);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Коэффициент преломления";
            // 
            // refractionBar
            // 
            this.refractionBar.Location = new System.Drawing.Point(682, 566);
            this.refractionBar.Name = "refractionBar";
            this.refractionBar.Size = new System.Drawing.Size(513, 45);
            this.refractionBar.TabIndex = 14;
            this.refractionBar.Scroll += new System.EventHandler(this.refractionBar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 706);
            this.Controls.Add(this.refractionBar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.reflectionBar);
            this.Controls.Add(this.boxColorBar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxZBar);
            this.Controls.Add(this.boxYBar);
            this.Controls.Add(this.boxXBar);
            this.Controls.Add(this.boxSizeBar);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.boxSizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxXBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxYBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxZBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxColorBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflectionBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refractionBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar boxSizeBar;
        private System.Windows.Forms.TrackBar boxXBar;
        private System.Windows.Forms.TrackBar boxYBar;
        private System.Windows.Forms.TrackBar boxZBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar boxColorBar;
        private System.Windows.Forms.TrackBar reflectionBar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar refractionBar;
    }
}

