﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Task_4
{
    public partial class MainForm : Form
    {
        int ws, hs;
        Bitmap bmp;
        Scene scene1, scene2, scene3, scene4;
        DrawAll draw;
        Graphics g;
        Thread threadDraw;
        Thread threadTroll_1, threadTroll_2, threadTroll_3, threadTroll_4;
        volatile bool isClose = false;


        private void Add_btn_Click(object sender, EventArgs e)
        {

        }

        private void GO1()
        {
            while (!isClose)
            {
                scene1.Set(ws); 
                Thread.Sleep(100);
            }
        }

        private void GO2()
        {
            while (!isClose)
            {
                scene2.Set(ws);
                Thread.Sleep(100);
            }
        }
        private void GO3()
        {
            while (!isClose)
            {
                scene3.Set(ws);
                Thread.Sleep(100);
            }
        }
        private void GO4()
        {
            while (!isClose)
            {
                scene4.Set(ws);
                Thread.Sleep(100);
            }
        }
        private void Draw()
        {
            while (!isClose)
            {
                bmp = new Bitmap(ws, hs);
                draw.Set(bmp, g);
                MainPB.Image = bmp;
                Thread.Sleep(10);
                bmp.Dispose(); 
            }
            
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            
            threadTroll_1 = new Thread(GO1);
            threadTroll_1.IsBackground = true;  
            threadTroll_1.Start();
            
            threadTroll_2 = new Thread(GO2);
            threadTroll_2.IsBackground = true;
            threadTroll_2.Start();

            threadTroll_3 = new Thread(GO3);
            threadTroll_3.IsBackground = true;
            threadTroll_3.Start();

            threadTroll_4 = new Thread(GO4);
            threadTroll_4.IsBackground = true;
            threadTroll_4.Start();

            threadDraw = new Thread(Draw);
            threadDraw.IsBackground = true;
            threadDraw.Start();
        }



        public MainForm()
        {
            InitializeComponent();
            ws = MainPB.Width;
            hs = MainPB.Height;
            bmp = new Bitmap(ws, hs);

            scene1 = new Scene(ws, 1);
            scene2 = new Scene(ws, 5);
            scene3 = new Scene(ws, 10);
            scene4 = new Scene(ws, 15);

            draw = new DrawAll(scene1, scene2, scene3, scene4);
        }
    }
}
