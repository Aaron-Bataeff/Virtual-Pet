using System;
using System.Drawing;
using System.Windows.Forms;
using VirtualPet.Models;

namespace VirtualPet
{
    public partial class Form1 : Form
    {
        private PictureBox picPet;

        private Label lblMood;
        private Label lblStage;

        private Pet pet;

        public Form1()
        {
            InitializeComponent();

            pet = new Pet("Octo");

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

            lblMood = new Label
            {
                Left = 20,
                Top = 340,
                Width = 200
            };

            lblStage = new Label
            {
                Left = 20,
                Top = 370,
                Width = 200
            };

            Controls.Add(lblMood);
            Controls.Add(lblStage);

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lblMood.Text = $"Mood: {pet.GetMood()}";
            lblStage.Text = $"Stage: {pet.GetStage()}";

            if (picPet.Image != null)
            {
                picPet.Image.Dispose();
            }

            picPet.Image = Image.FromFile(
                $"Images/{pet.GetStage()} {pet.GetMood()}.png");
        }
    }
}