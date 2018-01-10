using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programowanie_uslug_sieciowych_klient
{
    public partial class ShowImage : Form
    {
        private int imageWidth;

        private int imageLength;

        private Graphics g;



        private Pen pencil;

        public ShowImage(Bitmap b)
        {
            InitializeComponent();
            imageView.BackColor = Color.Azure;

            imageView.Height = b.Height;
            imageView.Width = b.Width;

            imageView.Image = b;

            g = Graphics.FromImage(imageView.Image);

            imageView.Refresh();
        }

        public void Draw()
        {
      
           
        }
    }
}
