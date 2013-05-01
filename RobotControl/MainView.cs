﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace RobotControl
{
    public partial class MainView : Form
    {
        Map map = new Map(32, 32, 500, 500);

        public MainView()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void MainView_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            map.Update(canvas);
        }

        private void newRobotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateRobotDialog createDialog = new CreateRobotDialog();
            createDialog.map = map;
            createDialog.ShowDialog();
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog foo = new SaveFileDialog();
                foo.ShowDialog();
                map.bgMap.Save(foo.FileName, ImageFormat.Png);
            }
            catch
            {
                
            }
        }
    }
}
