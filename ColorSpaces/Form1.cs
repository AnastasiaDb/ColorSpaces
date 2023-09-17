using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ColorSpaces
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                System.Drawing.Image selectedImage = System.Drawing.Image.FromFile(selectedImagePath);

                // Отображаем выбранное изображение в PictureBox
                pictureBox1.Image = selectedImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                MessageBox.Show("Выберите картинку!");
            else DrawTask1();
        }

        private void DrawTask1()
        {
            Bitmap originalImage = new Bitmap(pictureBox1.Image);

            // Создаем новый Bitmap для grayscale изображения
            Bitmap newImage1 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Bitmap newImage2 = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    Color pixel = originalImage.GetPixel(i, j);
                    int newColor = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);
                    Color newPixel = Color.FromArgb(newColor, newColor, newColor);
                    newImage1.SetPixel(i, j, newPixel);

                }

            }

            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    Color pixel = originalImage.GetPixel(i, j);
                    int newColor = (int)(0.2126 * pixel.R + 0.7152 * pixel.G + 0.0722 * pixel.B);
                    Color newPixel = Color.FromArgb(newColor,newColor,newColor);
                    newImage2.SetPixel(i, j, newPixel);

                }

            }

            pictureBox2.Image= newImage1;
            pictureBox3.Image= newImage2;
        }

    }
}
