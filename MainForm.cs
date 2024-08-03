using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.Design;

/*@Author: St Cyr Lee J. Vandersar
 * ID: 10879
 * #dev: Devoir 4 C# forms
 */


namespace Devoir4
{
    public partial class MainForm : Form
    {
        private Maze maze;
        private string fileName;

        public MainForm()
        {
            InitializeComponent();
            
        }

        private void loadMazeButton_Click(object sender, EventArgs e)
        {
            errorMessage.Text = load.Text = solve.Text = "";
            loadMazePBX.Image = solveMazePBX.Image =  null;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = openFileDialog.FileName; // Stocker le nom du fichier
                    maze = new Maze(fileName);
                    if (maze != null)
                    {
                        string tempImagePath = Path.GetTempFileName(); // Crée un fichier temporaire pour enregistrer l'image
                        maze.OutputImage(tempImagePath); // Enregistre l'image du labyrinthe
                        loadMazePBX.Image = Image.FromFile(tempImagePath); // Charge et affiche l'image dans le PictureBox
                    }
                    load.Text = "Maze successfully load";
                }
                catch (Exception ex)
                {
                    errorMessage.Text = "Error: " + ex.Message;
                }
            }
        }

        private void solveMazeButton_Click(object sender, EventArgs e)
        {
            if (maze != null)
            {
                try
                {
                    maze.Solve();

                    string tempImagePath = Path.GetTempFileName(); // Crée un fichier temporaire pour enregistrer l'image
                    maze.OutputImage(tempImagePath, showExplored: true); // Enregistre l' image du labyrinthe et affiche les carrés exploré
                    solveMazePBX.Image = Image.FromFile(tempImagePath); // Charge et affiche l'image dans le PictureBox

                    // Enregistrement de l'image
                    string imagePath = Path.ChangeExtension(fileName, ".png");

                    solveMazePBX.Image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);

                    errorMessage.ForeColor = Color.Green;
                    solve.Text = "States Explored: " + maze.NumExplored  + $"\nImage saved as " + imagePath;
                }
                catch (Exception ex)
                {
                    errorMessage.Text = "Error solving maze: " + ex.Message;
                }
            }
            else
            {
                errorMessage.Text = "Please load a maze first";
            }
        }

    }
}
