using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace APLGrayscale
{

    public partial class Form1 : Form
    {

        public float[] R = null;
        public float[] RCopy = null;
        public float[] G = null;
        public float[] B = null;
        public float[] H = null;
        public float[] lowerBoundary = null;
        public float[] upperBoundary = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            string fileName = dialog.FileName;
            if (System.IO.File.Exists(fileName))
            {
                try
                {

                    Bitmap image = new Bitmap(fileName);

                    float height = image.Height;

                    float width = image.Width;

                    if (width % 8 != 0)
                    {
                        width = (width - width % 8);
                    }

                    if (height % 8 != 0)
                    {
                        height = (height - height % 8);
                    }

                    R = new float[(int)(width * height)];
                    RCopy = new float[(int)(width * height)];
                    G = new float[(int)(width * height)];
                    B = new float[(int)(width * height)];

                    int i = 0;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color pixelColor = image.GetPixel(x, y);
                            R[i] = pixelColor.R;
                            RCopy[i] = pixelColor.R;
                            G[i] = pixelColor.G;
                            B[i] = pixelColor.B;
                            i++;
                        }
                    }

                    // Display the image in the picture box
                    pictureBox1.Image = image;

                    FileInfo fileInfo = new FileInfo(dialog.FileName);
                    // Display the file name, size, and creation time in the labels
                    label1.Text = "File name: " + fileInfo.Name;
                    label2.Text = "File size: " + fileInfo.Length + " bytes";
                    label3.Text = "Creation time: " + fileInfo.CreationTime;
                }
                catch (Exception ex)
                {
                    // Display an error message if the file is not a valid image
                    MessageBox.Show("Error loading image file: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Display an error message if the file does not exist
                MessageBox.Show("File not found: " + fileName, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void save_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("No image to save.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            saveFileDialog1.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();
            string fileName = saveFileDialog1.FileName;
            ImageFormat format = ImageFormat.Png;
            string extension = Path.GetExtension(fileName);
            if (extension == ".jpg" || extension == ".jpeg")
            {
                format = ImageFormat.Jpeg;
            }
            else if (extension == ".png")
            {
                format = ImageFormat.Png;
            }
            try
            {
                pictureBox2.Image.Save(fileName, format);
            }
            catch (Exception ex)
            {
                // Display an error message if there was an issue saving the file
                MessageBox.Show("Error saving image file: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grayscale_Click(object sender, EventArgs e)
        {

            if (radioButton2.Checked)
            {
                if (pictureBox1.Image != null)
                {
                    Bitmap image = new Bitmap(pictureBox1.Image);

                    float height = image.Height;

                    float width = image.Width;

                    if (width % 8 != 0)
                    {
                        width = (width - width % 8);
                    }

                    if (height % 8 != 0)
                    {
                        height = (height - height % 8);
                    }

                    int i = 0;
                    long totalTimeCS = 0;
                    //for (int tmp = 0; tmp < 100; tmp++)
                    //{
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // Convert the pixel to grayscale
                            double gray = (0.3 * (byte)R[i] + 0.59 * (byte)G[i] + 0.11 * (byte)B[i]);
                            image.SetPixel(x, y, Color.FromArgb((int)gray, (int)gray, (int)gray));
                            i++;
                        }
                    }
                    stopwatch.Stop();
                    totalTimeCS += stopwatch.ElapsedMilliseconds;
                    //}
                    //totalTimeCS = totalTimeCS / 100;
                    label5.Text = "C#: " + totalTimeCS + " milliseconds";

                    pictureBox2.Image = image;
                }
                else
                {
                    MessageBox.Show("No image to turn into grayscale.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (radioButton1.Checked)
            {

                AsmProxy asm = new AsmProxy();
                Bitmap image = new Bitmap(pictureBox1.Image);

                float height = image.Height;

                float width = image.Width;

                if (width % 8 != 0)
                {
                    width = (width - width % 8);
                }

                if (height % 8 != 0)
                {
                    height = (height - height % 8);
                }

                float[] inBMP = new float[(int)width * (int)height];
                float[] outBMP = new float[(int)width * (int)height];

                for (int i = 0; i < width * height; i++)
                    inBMP[i] = new float();
                for (int y = 0; y < height; y++)
                    for (int x = 0; x < (int)width; x++)
                    {
                        System.Drawing.Color bmpColor = image.GetPixel(x, y);

                        inBMP[y * (int)width + x] = new float();

                    }
                unsafe
                {
                    fixed (float* RAddr = this.R)
                    {
                        fixed (float* GAddr = this.G)
                        {
                            fixed (float* BAddr = this.B)
                            {

                                long totalTimeAsm = 0;
                                //for (int i = 0; i < 100; i++)
                                //{
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                asm.Conversion(RAddr, GAddr, BAddr, (int)height * (int)width);
                                stopwatch.Stop();
                                totalTimeAsm += stopwatch.ElapsedMilliseconds;
                                //}
                                //totalTimeAsm = totalTimeAsm / 100;
                                label4.Text = "ASM: " + totalTimeAsm + " milliseconds";

                            }
                        }

                    }
                }
                for (int y = 0; y < height; y++)
                    for (int x = 0; x < width; x++)
                    {
                        image.SetPixel(x, y, System.Drawing.Color.FromArgb((int)R[y * (int)width + x], (int)R[y * (int)width + x], (int)R[y * (int)width + x]));

                    }
                pictureBox2.Image = image;
            }
            else
            {
                MessageBox.Show("Please select what language you want to use for the conversion", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void RED_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                printTest("RED");
            }
            else if (radioButton1.Checked)
            {
                printASM("RED");
            }
            else
            {
                MessageBox.Show("Please select what language you want to use for the conversion", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ORANGE_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                printTest("ORANGE");
            }
            else if (radioButton1.Checked)
            {
                printASM("ORANGE");
            }
            else
            {
                MessageBox.Show("Please select what language you want to use for the conversion", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void YELLOW_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                printTest("YELLOW");
            }
            else if (radioButton1.Checked)
            {
                printASM("YELLOW");
            }
            else
            {
                MessageBox.Show("Please select what language you want to use for the conversion", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void GREEN_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                printTest("GREEN");
            }
            else if (radioButton1.Checked)
            {
                printASM("GREEN");
            }
            else
            {
                MessageBox.Show("Please select what language you want to use for the conversion", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void BLUE_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                printTest("BLUE");
            }
            else if (radioButton1.Checked)
            {
                printASM("BLUE");
            }
            else
            {
                MessageBox.Show("Please select what language you want to use for the conversion", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void PURPLE_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                printTest("PURPLE");
            }
            else if (radioButton1.Checked)
            {
                printASM("PURPLE");
            }
            else
            {
                MessageBox.Show("Please select what language you want to use for the conversion", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void PINK_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                printTest("PINK");
            }
            else if (radioButton1.Checked)
            {
                printASM("PINK");
            }
            else
            {
                MessageBox.Show("Please select what language you want to use for the conversion", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        public void print(string col)
        {
            if (pictureBox1.Image != null)
            {
                int i = 0;
                Bitmap image = new Bitmap(pictureBox1.Image);

                float height = image.Height;

                float width = image.Width;

                if (width % 8 != 0)
                {
                    width = (width - width % 8);
                }

                if (height % 8 != 0)
                {
                    height = (height - height % 8);
                }

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Grayscale grayscale = new Grayscale();
                        Grayscale.HSV hsv = new Grayscale.HSV();
                        hsv = Grayscale.RGBToHSV((byte)R[i], (byte)G[i], (byte)B[i]);

                        if (grayscale.isVisible(grayscale.chooseColor(col), hsv))
                        {
                            image.SetPixel(x, y, Color.FromArgb((byte)R[i], (byte)G[i], (byte)B[i]));
                        }
                        else
                        {
                            double gray = (0.3 * (byte)R[i] + 0.59 * (byte)G[i] + 0.11 * (byte)B[i]);
                            image.SetPixel(x, y, Color.FromArgb((int)gray, (int)gray, (int)gray));
                        }
                        i++;
                    }
                }
                pictureBox2.Image = image;
            }
            else
            {
                MessageBox.Show("No image to turn extract color from.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void printASM(string col)
        {
            Bitmap colorImage = null;
            Bitmap grayImage = null;
            
            if (pictureBox1.Image != null)
            {
                int i = 0;

                colorImage = new Bitmap(pictureBox1.Image);
                grayImage = new Bitmap(pictureBox2.Image);

                float height = grayImage.Height;

                float width = grayImage.Width;

                if (width % 8 != 0)
                {
                    width = (width - width % 8);
                }

                if (height % 8 != 0)
                {
                    height = (height - height % 8);
                }

                Grayscale grayscale = new Grayscale();
                Grayscale.HSV hsv = new Grayscale.HSV();

                Grayscale.SelectColor color = grayscale.chooseColor(col);

                this.lowerBoundary = new float[(int)height * (int)width];
                this.upperBoundary = new float[(int)height * (int)width];

                for (int j = 0; j < (int)height * (int)width; j++)
                {
                    this.lowerBoundary[j] = color.LowerBoundary;
                    this.upperBoundary[j] = color.UpperBoundary;
                }

                //Console.WriteLine("OLD H:");

                H = new float[(int)height * (int)width];
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        hsv = Grayscale.RGBToHSV((byte)this.RCopy[i], (byte)this.G[i], (byte)this.B[i]);
                        
                        H[i] = (float)hsv.H;
                        //Console.WriteLine(H[i]);
                        i++;
                    }
                }

                long totalTimeAsm = 0;

                Stopwatch stopwatch = Stopwatch.StartNew();

                unsafe
                {
                    AsmProxy asm = new AsmProxy();

                    fixed (float* HAddr = this.H)
                    {
                        fixed (float* LAddr = this.lowerBoundary)
                        {
                            fixed (float* UAddr = this.upperBoundary)
                            {

                                
                                asm.Visibility(HAddr, LAddr, UAddr, (int)height * (int)width);
                                

                            }
                        }

                    }
                }

                i = 0;

                //Console.WriteLine("New H:");

                for (int y = 0; y < height; y++)
                    for (int x = 0; x < width; x++)
                    {
                        if (H[i] != 0)
                            H[i] = 255;
                        //Console.WriteLine(i + ": " + H[i]);
                        byte alpha = (byte)H[i];
                        colorImage.SetPixel(x, y, Color.FromArgb(alpha, (byte)RCopy[i], (byte)G[i], (byte)B[i]));
                        i++;
                    }
                stopwatch.Stop();
                totalTimeAsm += stopwatch.ElapsedMilliseconds;

                label4.Text = "Isolation ASM: " + totalTimeAsm + " milliseconds";
                Graphics overlay = Graphics.FromImage(grayImage); //this is used to draw onto another image
                overlay.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                overlay.DrawImage(colorImage, 0, 0, width, height);
                overlay.Dispose(); //to save memory we get rid of overlay
                pictureBox2.Image = grayImage;
            }
            else
            {
                MessageBox.Show("No image to turn extract color from.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void printTest(string col)
        {
            if (pictureBox2.Image != null)
            {
                int i = 0;
                Bitmap colorImage = new Bitmap(pictureBox1.Image);
                Bitmap grayImage = new Bitmap(pictureBox2.Image);

                float height = grayImage.Height;

                float width = grayImage.Width;

                if (width % 8 != 0)
                {
                    width = (width - width % 8);
                }

                if (height % 8 != 0)
                {
                    height = (height - height % 8);
                }
                
                Grayscale grayscale = new Grayscale();
                Grayscale.HSV hsv = new Grayscale.HSV();

                long totalTimeCS = 0;
                Stopwatch stopwatch = Stopwatch.StartNew();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        hsv = Grayscale.RGBToHSV((byte)RCopy[i], (byte)G[i], (byte)B[i]);


                        if (grayscale.isVisible(grayscale.chooseColor(col), hsv))
                        {
                            colorImage.SetPixel(x, y, Color.FromArgb(255, (byte)RCopy[i], (byte)G[i], (byte)B[i]));
                        }
                        else
                        {
                            colorImage.SetPixel(x, y, Color.FromArgb(0, (byte)RCopy[i], (byte)G[i], (byte)B[i]));
                        }

                        i++;
                    }
                }
                stopwatch.Stop();
                totalTimeCS = stopwatch.ElapsedMilliseconds;
                label5.Text = "Isolation C#: " + totalTimeCS + " milliseconds";

                Graphics overlay = Graphics.FromImage(grayImage); //this is used to draw onto another image
                overlay.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                overlay.DrawImage(colorImage, 0, 0, width, height);
                overlay.Dispose(); //to save memory we get rid of overlay
                pictureBox2.Image = grayImage;
            }
            else
            {
                MessageBox.Show("No image to turn extract color from.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

    }
}
public struct Pixel
{
    public float r;
    public float g;
    public float b;
    public float a;
    public Pixel(float _r, float _g, float _b, float _a)
    {
        r = _r;
        g = _g;
        b = _b;
        a = _a;
    }
}

public unsafe class AsmProxy
{
    [DllImport("APL_Grayscale_asm.dll")]
    private static unsafe extern float ConvertToGrayscale(float* R, float* G, float* B, int size);

    [DllImport("APL_Grayscale_asm.dll")]
    private static unsafe extern float IsVisible(float* A, float* lowerBoundary, float* upperBoundary, int size);

    public float Conversion(float* R, float* G, float* B, int size)
    {
        return ConvertToGrayscale(R, G, B, size);
    }

    public float Visibility(float *A, float *lowerBoundary, float *upperBoundary, int size)
    {
        return IsVisible(A, lowerBoundary, upperBoundary, size);
    }

}