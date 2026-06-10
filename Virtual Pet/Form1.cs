using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using VirtualPet.Models;
using VirtualPet.Services;

namespace VirtualPet
{
    public partial class Form1 : Form
    {
        private PictureBox picPet = null!;

        private Label lblTitle = null!;
        private Label lblName = null!;
        private Label lblMood = null!;
        private Label lblStage = null!;
        private Label lblAge = null!;

        private Label lblHunger = null!;
        private Label lblEnergy = null!;
        private Label lblHappiness = null!;

        private ProgressBar pbHunger = null!;
        private ProgressBar pbEnergy = null!;
        private ProgressBar pbHappiness = null!;

        private GroupBox grpStats = null!;

        private Button btnFeed = null!;
        private Button btnPlay = null!;
        private Button btnSleep = null!;
        private Button btnSave = null!;
        private Button btnLoad = null!;

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

            Width = 600;
            Height = 820;
            StartPosition = FormStartPosition.CenterScreen;

            Font = new Font("Segoe UI", 10);

            lblTitle = new Label
            {
                Text = "OCTOPUS PET",
                Left = 100,
                Top = 10,
                Width = 380,
                Height = 40,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(lblTitle);

            picPet = new PictureBox
            {
                Width = 300,
                Height = 300,
                Left = 140,
                Top = 60,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            Controls.Add(picPet);

            lblName = new Label
            {
                Left = 100,
                Top = 375,
                Width = 380,
                Height = 35,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(lblName);

            grpStats = new GroupBox
            {
                Text = "Pet Status",
                Left = 75,
                Top = 420,
                Width = 450,
                Height = 220
            };

            lblMood = new Label
            {
                Left = 20,
                Top = 30,
                Width = 400
            };

            lblStage = new Label
            {
                Left = 20,
                Top = 55,
                Width = 400
            };

            lblAge = new Label
            {
                Left = 20,
                Top = 80,
                Width = 400
            };

            lblHunger = new Label
            {
                Left = 20,
                Top = 115,
                Width = 90
            };

            pbHunger = new ProgressBar
            {
                Left = 120,
                Top = 115,
                Width = 280,
                Height = 20,
                Maximum = 100
            };

            lblEnergy = new Label
            {
                Left = 20,
                Top = 145,
                Width = 90
            };

            pbEnergy = new ProgressBar
            {
                Left = 120,
                Top = 145,
                Width = 280,
                Height = 20,
                Maximum = 100
            };

            lblHappiness = new Label
            {
                Left = 20,
                Top = 175,
                Width = 90
            };

            pbHappiness = new ProgressBar
            {
                Left = 120,
                Top = 175,
                Width = 280,
                Height = 20,
                Maximum = 100
            };

            grpStats.Controls.Add(lblMood);
            grpStats.Controls.Add(lblStage);
            grpStats.Controls.Add(lblAge);
            grpStats.Controls.Add(lblHunger);
            grpStats.Controls.Add(pbHunger);
            grpStats.Controls.Add(lblEnergy);
            grpStats.Controls.Add(pbEnergy);
            grpStats.Controls.Add(lblHappiness);
            grpStats.Controls.Add(pbHappiness);

            Controls.Add(grpStats);

            btnFeed = new Button
            {
                Text = "Feed",
                Width = 120,
                Height = 40,
                Left = 40,
                Top = 670
            };

            btnPlay = new Button
            {
                Text = "Play",
                Width = 120,
                Height = 40,
                Left = 235,
                Top = 670
            };

            btnSleep = new Button
            {
                Text = "Sleep",
                Width = 120,
                Height = 40,
                Left = 430,
                Top = 670
            };

            btnSave = new Button
            {
                Text = "Save",
                Width = 120,
                Height = 35,
                Left = 140,
                Top = 730
            };

            btnLoad = new Button
            {
                Text = "Load",
                Width = 120,
                Height = 35,
                Left = 320,
                Top = 730
            };

            btnFeed.Click += BtnFeed_Click;
            btnPlay.Click += BtnPlay_Click;
            btnSleep.Click += BtnSleep_Click;
            btnSave.Click += BtnSave_Click;
            btnLoad.Click += BtnLoad_Click;

            Controls.Add(btnFeed);
            Controls.Add(btnPlay);
            Controls.Add(btnSleep);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lblName.Text = pet.Name;

            lblMood.Text = $"Feeling: {pet.GetMood()}";
            lblStage.Text = $"Stage: {pet.GetStage()}";
            lblAge.Text = $"Age: {pet.Age}";

            lblHunger.Text = $"Hunger ({pet.Hunger})";
            lblEnergy.Text = $"Energy ({pet.Energy})";
            lblHappiness.Text = $"Happy ({pet.Happiness})";

            pbHunger.Value = pet.Hunger;
            pbEnergy.Value = pet.Energy;
            pbHappiness.Value = pet.Happiness;

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

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            SaveService.Save(pet);
            MessageBox.Show("Pet saved!");
        }

        private void BtnLoad_Click(object? sender, EventArgs e)
        {
            Pet? loadedPet = SaveService.Load();

            if (loadedPet != null)
            {
                pet = loadedPet;
                UpdateDisplay();

                MessageBox.Show("Pet loaded!");
            }
        }

        private void PetTimer_Tick(object? sender, EventArgs e)
        {
            pet.Hunger = Math.Min(100, pet.Hunger + 5);
            pet.Energy = Math.Max(0, pet.Energy - 2);
            pet.Happiness = Math.Max(0, pet.Happiness - 1);

            if (pet.Hunger >= 80)
            {
                pet.Happiness = Math.Max(0, pet.Happiness - 3);
            }

            if (pet.Energy <= 20)
            {
                pet.Happiness = Math.Max(0, pet.Happiness - 2);
            }

            pet.Age++;

            UpdateDisplay();
        }
    }
}
