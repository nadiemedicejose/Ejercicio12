﻿namespace Ejercicio12
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Whiteboard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Whiteboard)).BeginInit();
            this.SuspendLayout();
            // 
            // Whiteboard
            // 
            this.Whiteboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Whiteboard.Location = new System.Drawing.Point(0, 0);
            this.Whiteboard.Name = "Whiteboard";
            this.Whiteboard.Size = new System.Drawing.Size(800, 450);
            this.Whiteboard.TabIndex = 0;
            this.Whiteboard.TabStop = false;
            this.Whiteboard.Click += new System.EventHandler(this.Whiteboard_Click);
            this.Whiteboard.Paint += new System.Windows.Forms.PaintEventHandler(this.Whiteboard_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Whiteboard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Whiteboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Whiteboard;
    }
}

