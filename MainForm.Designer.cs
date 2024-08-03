using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Devoir4
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loadMazePBX = new PictureBox();
            solveMazeButton = new Button();
            loadMazeButton = new Button();
            errorMessage = new Label();
            solveMazePBX = new PictureBox();
            load = new Label();
            solve = new Label();
            ((System.ComponentModel.ISupportInitialize)loadMazePBX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)solveMazePBX).BeginInit();
            SuspendLayout();
            // 
            // loadMazeButton
            // 
            loadMazeButton.Location = new Point(12, 12);
            loadMazeButton.Name = "loadMazeButton";
            loadMazeButton.Size = new Size(149, 40);
            loadMazeButton.TabIndex = 0;
            loadMazeButton.Text = "Load Maze";
            loadMazeButton.UseVisualStyleBackColor = true;
            loadMazeButton.Click += loadMazeButton_Click;
            // 
            // solveMazeButton
            // 
            solveMazeButton.Location = new Point(764, 12);
            solveMazeButton.Name = "solveMazeButton";
            solveMazeButton.Size = new Size(183, 40);
            solveMazeButton.TabIndex = 1;
            solveMazeButton.Text = "Solve and Save Maze";
            solveMazeButton.UseVisualStyleBackColor = true;
            solveMazeButton.Click += solveMazeButton_Click;
            // 
            // loadMazePBX
            // 
            loadMazePBX.Location = new Point(12, 111);
            loadMazePBX.Name = "loadMazePBX";
            loadMazePBX.Size = new Size(700, 605);
            loadMazePBX.TabIndex = 2;
            loadMazePBX.TabStop = false;
            // 
            // solveMazePBX
            // 
            solveMazePBX.Location = new Point(764, 111);
            solveMazePBX.Name = "solveMazePBX";
            solveMazePBX.Size = new Size(700, 605);
            solveMazePBX.TabIndex = 3;
            solveMazePBX.TabStop = false;
            // 
            // errorMessage
            // 
            errorMessage.AutoSize = true;
            errorMessage.ForeColor = Color.Red;
            errorMessage.Location = new Point(12, 733);
            errorMessage.Name = "errorMessage";
            errorMessage.Size = new Size(0, 20);
            errorMessage.TabIndex = 4;
            // 
            // load
            // 
            load.AutoSize = true;
            load.ForeColor = Color.Green;
            load.Location = new Point(12, 64);
            load.Name = "load";
            load.Size = new Size(0, 20);
            load.TabIndex = 5;
            // 
            // solve
            // 
            solve.AutoSize = true;
            solve.ForeColor = Color.Green;
            solve.Location = new Point(764, 64);
            solve.Name = "solve";
            solve.Size = new Size(0, 20);
            solve.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 756);
            Controls.Add(solve);
            Controls.Add(load);
            Controls.Add(solveMazePBX);
            Controls.Add(errorMessage);
            Controls.Add(loadMazeButton);
            Controls.Add(solveMazeButton);
            Controls.Add(loadMazePBX);
            Name = "MainForm";
            Text = "Devoir4(St Cyr)";
            ((System.ComponentModel.ISupportInitialize)loadMazePBX).EndInit();
            ((System.ComponentModel.ISupportInitialize)solveMazePBX).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox solveMazePBX;
        private PictureBox loadMazePBX;
        private Button solveMazeButton;
        private Button loadMazeButton;
        private Label errorMessage;
        private Label load;
        private Label solve;
    }
}
