using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMSKneeboarder
{

    public partial class PasteClipboardForm : Form
    {
        private Image image;
        public PasteClipboardForm(Image image)
        {
            this.image = image;

            InitializeComponent();
        }

        private void PasteClipboardForm_Load(object sender, EventArgs e)
        {
            CenterPanelRegion();
        }

        private float GetImageRatio()
        {
            float ratio = (float)(Width - 30) / image.Width;
            if ((float)(Height - 120) / image.Height < ratio)
                ratio = (float)(Height - 120) / image.Height;
            return ratio;
        }

        private int RegionWidth { get; set; }
        private int RegionHeight { get; set; }
        private int RegionLeft { get; set; }
        private int RegionTop { get; set; }
        private float kbRatio = 1.6f;
        private void CenterPanelRegion()
        {
            float ratio = GetImageRatio();
            RegionHeight = Convert.ToInt32(image.Height * ratio);
            RegionWidth = Convert.ToInt32(RegionHeight / kbRatio);
            if (RegionWidth > image.Width * ratio)
            {
                RegionWidth = Convert.ToInt32(image.Width * ratio);
                RegionHeight = Convert.ToInt32(RegionWidth * kbRatio);
            }

            RegionLeft = 15 + (Width - 30 - RegionWidth) / 2;
            RegionTop = 15 + (Height - 120 - RegionHeight) / 2;

            Invalidate();
        }

        private void PasteClipboardForm_Paint(object sender, PaintEventArgs e)
        {
            float ratio = GetImageRatio();

            e.Graphics.DrawImage(this.image, 15 + (Width - 30 - image.Width * ratio) / 2, 15 + (Height - 120 - image.Height * ratio) / 2, image.Width * ratio, image.Height * ratio);

            Pen pen = new Pen(Color.Red, 2);
            pen.DashPattern = [4, 2];

            e.Graphics.DrawRectangle(pen, RegionLeft, RegionTop, RegionWidth, RegionHeight);
        }

        private void PasteClipboardForm_Resize(object sender, EventArgs e)
        {
            this.Invalidate();

            CenterPanelRegion();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void panelRegion_Paint(object sender, PaintEventArgs e)
        {
            //Pen pen = new Pen(Color.Red, 2);
            //pen.DashPattern = [4, 2];
            //e.Graphics.Clear(Color.Transparent);
            //e.Graphics.DrawRectangle(pen, 1, 1, panelRegion.Width - 2, panelRegion.Height - 2);
        }

        Nullable<Point> mouseStartLoc = null;
        private void panelRegion_MouseDown(object sender, MouseEventArgs e)
        {
            mouseStartLoc = e.Location;
        }

        private void PasteClipboardForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseStartLoc = e.Location;
        }

        private void PasteClipboardForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseStartLoc = null;
        }

        private void PasteClipboardForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseStartLoc != null)
            {
                float ratio = GetImageRatio();

                RegionLeft += (e.Location.X - mouseStartLoc.Value.X);
                RegionTop += (e.Location.Y - mouseStartLoc.Value.Y);

                RegionLeft = Math.Max(RegionLeft, 15 + Convert.ToInt32((Width - 30 - image.Width * ratio) / 2));
                RegionLeft = Math.Min(RegionLeft, 15 + Convert.ToInt32((Width - 30 - image.Width * ratio) / 2 + image.Width * ratio - RegionWidth));
                RegionTop = Math.Max(RegionTop, 15 + Convert.ToInt32((Height - 120 - image.Height * ratio) / 2));
                RegionTop = Math.Min(RegionTop, 15 + Convert.ToInt32((Height - 120 - image.Height * ratio) / 2 + image.Height * ratio - RegionHeight));

                mouseStartLoc = e.Location;
                Invalidate();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public Bitmap GetResultImage()
        {
            float ratio = GetImageRatio();

            Bitmap bmp = new Bitmap(1280, 2048, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {

                g.DrawImage(image,
                    new Rectangle(0, 0, 1280, 2048),
                    new Rectangle(
                        Convert.ToInt32((RegionLeft - (15 + (Width - 30 - image.Width * ratio) / 2)) / ratio),
                        Convert.ToInt32((RegionTop - (15 + (Height - 120 - image.Height * ratio) / 2)) / ratio),
                        Convert.ToInt32((float)RegionWidth / ratio),
                        Convert.ToInt32((float)RegionHeight / ratio)
                    ),
                    GraphicsUnit.Pixel);
            }
            return bmp;
        }
    }
}
