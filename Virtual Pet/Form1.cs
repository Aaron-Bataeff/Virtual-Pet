using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using VirtualPet.Models;

namespace VirtualPet
{
    public partial class Form1 : Form
    {
        private PictureBox picPet;

        private Label lblName;
        private Label lblMood;
        private Label lblStage;
        private Label lblHunger;
        private Label lblEnergy;
        private Label lblHappiness;

        private Button btnFeed;
        private Button btnPlay;
        private Button btnSleep;

        private Pet pet;

        public Form1()
        {
            InitializeComponent();

            string petName = Interaction.InputBox(
                "What would you like to name your pet?",
                "Name Your Pet",
                "Octo");

            if (string.IsNullOrWhiteSpace(petName))
            {
                petName = "Octo";
            }

            pet = new Pet(petName);

            BuildInterface();
        }

        private void BuildInterface()
        {
            Text = "Octopus Pet";

            Width = 600;
            Height = 750;

            Font = new Font("Segoe UI", 10);

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

            lblName = new Label
            {
                Left = 100,
                Top = 340,
                Width = 400,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            };

            lblMood = new Label
            {
                Left = 100,
                Top = 380,
                Width = 400,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblStage = new Label
            {
                Left = 100,
                Top = 410,
                Width = 400,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblHunger = new Label
            {
                Left = 100,
                Top = 460,
                Width = 400,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblEnergy = new Label
            {
                Left = 100,
                Top = 490,
                Width = 400,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblHappiness = new Label
            {
                Left = 100,
                Top = 520,
                Width = 400,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(lblName);
            Controls.Add(lblMood);
            Controls.Add(lblStage);
            Controls.Add(lblHunger);
            Controls.Add(lblEnergy);
            Controls.Add(lblHappiness);

            btnFeed = new Button
            {
                Text = "Feed",
                Width = 120,
                Height = 40,
                Left = 70,
                Top = 590
            };

            btnPlay = new Button
            {
                Text = "Play",
                Width = 120,
                Height = 40,
                Left = 230,
                Top = 590
            };

            btnSleep = new Button
            {
                Text = "Sleep",
                Width = 120,
                Height = 40,
                Left = 390,
                Top = 590
            };

            btnFeed.Click += BtnFeed_Click;
            btnPlay.Click += BtnPlay_Click;
            btnSleep.Click += BtnSleep_Click;

            Controls.Add(btnFeed);
            Controls.Add(btnPlay);
            Controls.Add(btnSleep);

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lblName.Text = pet.Name;

            lblMood.Text = $"Mood: {pet.GetMood()}";
            lblStage.Text = $"Stage: {pet.GetStage()}";

            lblHunger.Text = $"Hunger: {pet.Hunger}";
            lblEnergy.Text = $"Energy: {pet.Energy}";
            lblHappiness.Text = $"Happiness: {pet.Happiness}";

            if (picPet.Image != null)
            {
                picPet.Image.Dispose();
            }

            picPet.Image = Image.FromFile(
                $"Images/{pet.GetStage()} {pet.GetMood()}.png");
        }

        private void BtnFeed_Click(object? sender, EventArgs e)
        {
            pet.Feed();
            UpdateDisplay();
        }

        private void BtnPlay_Click(object? sender, EventArgs e)
        {
            pet.Play();
            UpdateDisplay();
        }

        private void BtnSleep_Click(object? sender, EventArgs e)
        {
            pet.Sleep();
            UpdateDisplay();
        }
    }
}