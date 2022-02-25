using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LearnOpenCV.Models;
using OpenCvSharp;

namespace LearnOpenCV
{
    public partial class frmForm : Form
    {
        public frmForm()
        {
            InitializeComponent();

        }

        private Mat sourceMat;

        private Mat resultMat;

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetEnvironmentVariable("user.dir");
                openFileDialog.Filter = Constants.PICTURE_DIALOG_FILTER;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    sourceMat = Cv2.ImRead(filePath, ImreadModes.Unchanged);
                    resultMat = Cv2.ImRead(filePath, ImreadModes.Unchanged);
                    sourcePic.Image = Image.FromFile(filePath);
                    resultPic.Image = null;
                    
                }
            }
               

  
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            Mat temp = new Mat();
            Cv2.CvtColor(sourceMat, temp, ColorConversionCodes.BGR2GRAY);
            resultPic.Image = Image.FromStream(temp.ToMemoryStream());
        }
    }
}
