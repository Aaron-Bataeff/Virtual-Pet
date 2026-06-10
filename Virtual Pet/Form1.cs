using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using VirtualPet.Models;

namespace VirtualPet
{
    public partial class Form1 : Form
    {
        private PictureBox picPet = null!;

        private Label lblName = null!;
        private Label lblMood = null!;
        private Label lblStage = null!;
        private Label lblAge = null!;

        private Label lblHunger = null!;
        private Label lblEnergy = null!;
        private Label lblHappiness = null!;

        private Button btnFeed = null!;
        private Button btnPlay = null!;
        private Button btnSleep = null!;

        private System.Windows.Forms.Timer petTimer = null!;

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

            petTimer = new System.Windows.Forms.Timer();
            petTimer.Interval = 10000;
            petTimer.Tick += PetTimer_Tick;
            petTimer.Start();

            BuildInterface();
        }

        private void BuildInterface()
        {
            Text = "Octopus Pet";

            Width = 550;
            Height = 700;

            Font = new Font("Segoe UI", 10);

            picPet = new PictureBox
            {
                Width = 300,
                Height = 300,
                Left = 120,
                Top = 20,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            Controls.Add(picPet);

            lblName = new Label
            {
                Left = 75,
                Top = 340,
                Width = 400,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            };

            lblMood = new Label
            {
                Left = 75,
                Top = 375,
                Width = 400,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblStage = new Label
            {
                Left = 75,
                Top = 405,
                Width = 400,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblAge = new Label
            {
                Left = 75,
                Top = 435,
                Width = 400,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblHunger = new Label
            {
                Left = 75,
                Top = 485,
                Width = 400,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblEnergy = new Label
            {
                Left = 75,
                Top = 515,
                Width = 400,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblHappiness = new Label
            {
                Left = 75,
                Top = 545,
                Width = 400,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(lblName);
            Controls.Add(lblMood);
            Controls.Add(lblStage);
            Controls.Add(lblAge);
            Controls.Add(lblHunger);
            Controls.Add(lblEnergy);
            Controls.Add(lblHappiness);

            btnFeed = new Button
            {
                Text = "Feed",
                Width = 120,
                Height = 40,
                Left = 40,
                Top = 600
            };

            btnPlay = new Button
            {
                Text = "Play",
                Width = 120,
                Height = 40,
                Left = 205,
                Top = 600
            };

            btnSleep = new Button
            {
                Text = "Sleep",
                Width = 120,
                Height = 40,
                Left = 370,
                Top = 600
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
            lblAge.Text = $"Age: {pet.Age}";

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

        private void PetTimer_Tick(object? sender, EventArgs e)
        {
            pet.Hunger = Math.Min(100, pet.Hunger + 5);

            pet.Energy = Math.Max(0, pet.Energy - 2);

            pet.Age++;

            UpdateDisplay();
        }
    }
}