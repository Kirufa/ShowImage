using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace ShowPicture
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            colors = new Color[3];
            colors[0] = Color.FromArgb(176, 210, 237);
            colors[1] = Color.FromArgb(83, 109, 127);
            colors[2] = Color.FromArgb(46, 74, 97);


            
            backcolor = Color.FromArgb(33, 42, 58);

           

            showPictureBox.Size = this.Size;
            showPictureBox.Location = Point.Empty;

            transparentColor = Color.LightGray;
            BackColor = transparentColor;
            TransparencyKey = transparentColor;

            isDown = false;
            point = Point.Empty;

            path = string.Empty;

            pictures = new List<string>();
            extensions = new List<string>(new string[] { ".jpg", ".jpeg", ".png", ".bmp", ".tiff", ".tif" });

            count = 0;
            Opacity = 0.75;
           
        }

        private Color[] colors;
        private Color backcolor;
        private bool isDown;
        private Point point;
        private string path;
        private List<string> pictures;
        private List<string> extensions;
        private Bitmap nowPicuture;
        private int count;
        private Color transparentColor;
       
        
        private void DrawBorder(Graphics g, Size border)
        {
            Bitmap back = TempClass.Bitmap;

            const int shift = 3;
            int bw = border.Width - 1;
            int bh = border.Height - 1;



            for (int i = 0; i != colors.Length; ++i)
            {
                using (Pen pen = new Pen(colors[i], 1))
                {
                    g.DrawLine(pen, new Point(i, shift), new Point(i, bh - shift));
                    g.DrawLine(pen, new Point(shift, bh - i), new Point(bw - shift, bh - i));
                    g.DrawLine(pen, new Point(bw - i, bh - shift), new Point(bw - i, shift));
                    g.DrawLine(pen, new Point(bw - shift, i), new Point(shift, i));
                }
            }
                     
            g.DrawImage(back, Point.Empty);            
            
            back.RotateFlip(RotateFlipType.Rotate90FlipNone);
            g.DrawImage(back, new Point(border.Width - back.Width, 0));

            back.RotateFlip(RotateFlipType.Rotate90FlipNone);
            g.DrawImage(back, new Point(border.Width - back.Width, border.Height - back.Height));

            back.RotateFlip(RotateFlipType.Rotate90FlipNone);
            g.DrawImage(back, new Point(0, border.Height - back.Height));

            back.RotateFlip(RotateFlipType.Rotate90FlipNone);           
        }

        private void showPictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox picBox = sender as PictureBox;

          
            if (nowPicuture == null)
                e.Graphics.Clear(backcolor);           

            DrawBorder(e.Graphics, e.ClipRectangle.Size);

        }

        private void showPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                rigntCtMS.Show((Control)sender, e.Location);
            
        }

        private void showPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
                this.Location = Point.Subtract(Cursor.Position, new Size(point));
        }

        private void showPictureBox_MouseLeave(object sender, EventArgs e)
        {
            isDown = false;
        }

        private void showPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void showPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            point.X = Cursor.Position.X - this.Location.X;
            point.Y = Cursor.Position.Y - this.Location.Y;

        }

        private void showPictureBox_SizeChanged(object sender, EventArgs e)
        {
            this.Size = showPictureBox.Size;
           
        
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            showPictureBox_SizeChanged(null, null);

           

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void moveToCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.FromControl(this).Bounds.Width - this.Width) / 2, this.Location.Y);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if( fbd.ShowDialog() == DialogResult.OK &&
                !string.IsNullOrEmpty( fbd.SelectedPath) &&
                Directory.Exists(fbd.SelectedPath))
            {
                showTimer.Stop();
                count = 0;
                pictures.Clear();

                path = fbd.SelectedPath;

                string[] tempFiles = Directory.GetFiles(path);

                foreach(string file in tempFiles)
                {
                    string extension = Path.GetExtension(file);

                    if (extensions.Contains(extension))
                        pictures.Add(file);
                }

                showTimer.Start();
            }
        }

        private void showTimer_Tick(object sender, EventArgs e)
        {
            GetNextPicrure();
            showPictureBox.Image = nowPicuture;
        }
        private void GetNextPicrure()
        {

            if (nowPicuture != null)
                nowPicuture.Dispose();            

            try
            {
                nowPicuture = new Bitmap(pictures[count]);
            }
            catch
            {
                nowPicuture = null;                
            }



            if (count < pictures.Count)
                count++;
            else
                count = 0;
        }

        private void toolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            ToolStripTextBox textBox = sender as ToolStripTextBox;
            float number;

            if (float.TryParse(textBox.Text, out number) &&
                number >= 0 &&
                number <= 1)
            {
                if (number < 0.2)
                    this.Opacity = 0.2;
                else
                    this.Opacity = number;
            }

        }

        //private Bitmap errorImage
        //{
        //    get
        //    {
        //        Bitmap bmp = new Bitmap(200, 200);
        //        using (Graphics g = Graphics.FromImage(bmp))
        //        {
        //            g.Clear(Color.White);
        //            g.DrawLine(Pens.Red, new Point(0, 0), new Point(bmp.Width - 1, bmp.Height - 1));
        //            g.DrawLine(Pens.Red, new Point(bmp.Width - 1, 0), new Point(0, bmp.Height - 1));
        //        }
        //
        //        return bmp;
        //    }
        //}
    }

    public class TempClass
    {
        public byte[] BmpArray;

        [XmlIgnore]
        private static string bmpString =
            "<?xml version=\"1.0\"?>" + Environment.NewLine +
            "<TempClass xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
            "<BmpArray>iVBORw0KGgoAAAANSUhEUgAAAAsAAAALCAYAAACprHcmAAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwAAADsABataJCQAAABl0RVh0" +
            "U29mdHdhcmUAcGFpbnQubmV0IDQuMC4xMK0KCsAAAAC7SURBVChTY7h8+fJ/ZHzl+bf/R+99+r/16rv/Gy69RcFwxU/e//i/+cLL/zXds/+HZVX+94" +
            "ov+B+QWf0/OLcejsGKQQoX777w3yM07b9fesV/K9/4//oukf91nCL+63rE/9fzSgRjsOK528/9D4zL+w8EDPgwA8iNIKtBJqJLomMGkGeC08rAVqNL" +
            "omMGkK9BngG5EV0SHTOAggTka5Bn0CXRMVgxKFhAvkaXRMdwxaCgQZdExyQo/s8AAPDCW1uiL4bpAAAAAElFTkSuQmCC</BmpArray>" + Environment.NewLine +
            "</TempClass>";

        [XmlIgnore]
        public static Bitmap Bitmap
        {
            get
            {
                if (savedBmp == null)
                {
                    TempClass tmp;

                    XmlSerializer xs = new XmlSerializer(typeof(TempClass));

                    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(TempClass.bmpString)))
                        tmp = (TempClass)xs.Deserialize(ms);

                    using (MemoryStream ms = new MemoryStream(tmp.BmpArray))
                        savedBmp = new Bitmap(ms);
                }

                return savedBmp;
            }

        }

        private static Bitmap savedBmp;
    }
}
