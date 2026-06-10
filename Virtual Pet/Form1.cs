using System;
using System.Drawing;
using System.Windows.Forms;

namespace VirtualPet
{
    public partial class Form1 : Form
    {
        private PictureBox picPet;

        public Form1()
        {
            InitializeComponent();

            BuildInterface();
        }

        private void BuildInterface()
        {
            Text = "Virtual Pet";

            Width = 600;
            Height = 800;

            picPet = new PictureBox
            {
                Width = 300,
                Height = 300,
                Left = 140,
                Top = 20,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            Controls.Add(picPet);

            // Temporary test image
            picPet.Image = Image.FromFile("Images/baby happy.png");
        }
    }
}