using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mini_Game_Maze
{
    public class CActorMaze
    {
        public int X, Y, W, H;
    }

    public class CActorShalby
    {
        public int X, Y;
        public List<Bitmap> im;
        public int iFrame;
    }

    public class CActorDoor
    {
        public int X, Y;
        public Bitmap im;
    }

    public class CActorBoo1
    {
        public int X, Y;
        public Bitmap im;
    }

    public class CActorBoo2
    {
        public int X, Y;
        public List<Bitmap> im;
        public int iFrame;
    }

    public class CActorPause
    {
        public int X, Y;
        public List<Bitmap> im;
        public int iFrame;
    }
    public class CActorSe7lya
    {
        public int X, Y;
        public List<Bitmap> im;
        public int iFrame;
        public int dx, dy;
    }

    public class CActorG
    {
        public int X, Y;
        public List<Bitmap> im;
        public int iFrame;
        public int dx;
    }

    public class CActor3nkbot
    {
        public int X, Y;
        public List<Bitmap> im;
        public int iFrame;
        public int dx, dy;
    }
    public class CActorEnergyTank
    {
        public int X, Y;
        public Bitmap im;
    }

    public class CActorLogo
    {
        public int X, Y;
        public Bitmap im;
    }

    public class CActorHalaG
    {
        public int X, Y;
        public Bitmap im;
    }

    public class CActorGameOver
    {
        public int X, Y;
        public Bitmap im1;
        public Bitmap im2;
    }
    public class CActorWinner
    {
        public int X, Y;
        public Bitmap im1;
        public Bitmap im2;
    }

    public partial class Form1 : Form
    {
        Bitmap off;
        Timer t = new Timer();
        int CountTick = 0;
        int Pause = 0;
        int HalaG = 0;
        Random RR = new Random();
        int N;
        int GameOverW = 0;
        int WinnerW = 0;
        int HalaGW = 0;
        int Life = 1;
        int FlagBoo = 0;
        int Score = 0;
        List<CActorMaze> LMaze = new List<CActorMaze>();
        List<CActorShalby> LShalby = new List<CActorShalby>();
        List<CActorDoor> LDoor = new List<CActorDoor>();
        List<CActorBoo1> LBoo1 = new List<CActorBoo1>();
        List<CActorSe7lya> LSe7lya = new List<CActorSe7lya>();
        List<CActor3nkbot> L3nkbot = new List<CActor3nkbot>();
        List<CActorGameOver> LGameOver = new List<CActorGameOver>();
        List<CActorWinner> LWinner = new List<CActorWinner>();
        List<CActorBoo2> LBoo2 = new List<CActorBoo2>();
        List<CActorEnergyTank> LEnergy = new List<CActorEnergyTank>();
        List<CActorLogo> LLogo = new List<CActorLogo>();
        List<CActorPause> LPause = new List<CActorPause>();
        List<CActorG> LG = new List<CActorG>();
        List<CActorHalaG> LHalaG = new List<CActorHalaG>();
        int CountG;
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.Load += new EventHandler(Form1_Load);
            this.Paint += new PaintEventHandler(Form1_Paint);
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 50;
            t.Start();
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (e.X >= LPause[0].X && e.X <= LPause[0].X + LPause[0].im[0].Width
                    && e.Y >= LPause[0].Y && e.Y <= LPause[0].Y + LPause[0].im[0].Height)
                {
                    Pause++;
                    if (Pause == 1)
                    {
                        LPause[0].iFrame = 1;
                    }
                    if (Pause == 2)
                    {
                        LPause[0].iFrame = 0;
                        Pause = 0;
                    }
                }
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            int i;
            if (HalaG == 0)
            {
                if (Pause == 0)
                {
                    //////////////////////////////////////////////////////////////////////
                    if (LSe7lya[0].dx == 1 && LSe7lya[0].dy == 0)
                    {
                        LSe7lya[0].X += 3;
                        if (LSe7lya[0].X + LSe7lya[0].im[0].Width >= LMaze[7].X)
                        {
                            LSe7lya[0].dx = -1;
                            LSe7lya[0].iFrame = 1;
                        }
                    }
                    if (LSe7lya[0].dx == -1 && LSe7lya[0].dy == 0)
                    {
                        LSe7lya[0].X -= 3;
                        if (LSe7lya[0].X - 15 <= LMaze[0].X)
                        {
                            LSe7lya[0].dx = 0;
                            LSe7lya[0].dy = 1;
                        }
                    }
                    if (LSe7lya[0].dx == 0 && LSe7lya[0].dy == 1)
                    {
                        LSe7lya[0].Y += 3;
                        if (LSe7lya[0].Y + LSe7lya[0].im[0].Height >= LMaze[1].Y)
                        {
                            LSe7lya[0].dy = -1;
                        }
                    }

                    if (LSe7lya[0].dx == 0 && LSe7lya[0].dy == -1)
                    {
                        LSe7lya[0].Y -= 3;
                        if (LSe7lya[0].Y - 5 <= LMaze[0].Y)
                        {
                            LSe7lya[0].dx = 1;
                            LSe7lya[0].dy = 0;
                            LSe7lya[0].iFrame = 0;
                        }
                    }
                    //////////////////////////////////////////////////////Se7lya Movement/////////////////////////////
                    if (L3nkbot[0].dx == 1 && L3nkbot[0].dy == 0)
                    {
                        L3nkbot[0].X += 5;
                        if (L3nkbot[0].X + L3nkbot[0].im[0].Width >= LMaze[18].X)
                        {
                            L3nkbot[0].dy = 1;
                            L3nkbot[0].dx = 0;
                        }
                    }
                    if (L3nkbot[0].dx == -1 && L3nkbot[0].dy == 0)
                    {
                        L3nkbot[0].X -= 5;
                        if (L3nkbot[0].X <= LMaze[10].X + LMaze[10].W)
                        {
                            L3nkbot[0].dx = 1;
                            L3nkbot[0].iFrame = 0;
                        }
                    }

                    if (L3nkbot[0].dx == 0 && L3nkbot[0].dy == 1)
                    {
                        L3nkbot[0].Y += 5;
                        if (L3nkbot[0].Y + L3nkbot[0].im[0].Height >= LMaze[1].Y)
                        {
                            L3nkbot[0].dy = -1;
                        }
                    }
                    if (L3nkbot[0].dx == 0 && L3nkbot[0].dy == -1)
                    {
                        L3nkbot[0].Y -= 5;
                        if (L3nkbot[0].Y <= LMaze[17].Y)
                        {
                            L3nkbot[0].dy = 1;
                        }
                    }
                    if (L3nkbot[0].dx == 0 &&
                        L3nkbot[0].Y >= this.ClientSize.Height / 2 - 50 &&
                        L3nkbot[0].Y <= this.ClientSize.Height / 2 - 45 &&
                        L3nkbot[0].X + L3nkbot[0].im[0].Width >= LMaze[18].X)
                    {
                        N = RR.Next(3);
                        if (N == 0)
                        {
                            L3nkbot[0].dx = -1;
                            L3nkbot[0].dy = 0;
                            L3nkbot[0].iFrame = 1;
                        }
                        if (N == 1)
                        {
                            L3nkbot[0].dx = 0;
                            L3nkbot[0].dy = 1;
                        }
                        if (N == 1)
                        {
                            L3nkbot[0].dx = 0;
                            L3nkbot[0].dy = -1;
                        }
                    }
                    //////////////////////////////////////////////3ankbot Movement////////////////////////////////////
                    if (LG[0].dx == 1)
                    {
                        LG[0].X += 4;
                        if (LG[0].X >= 1100)
                        {
                            LG[0].dx = -1;
                            LG[0].iFrame = 1;
                        }
                    }
                    if (LG[0].dx == -1)
                    {
                        LG[0].X -= 4;
                        if (LG[0].X <= LMaze[7].X + LMaze[7].W)
                        {
                            LG[0].dx = 1;
                            LG[0].iFrame = 0;
                        }
                    }
                    //////////////////////////////////////////////////G Movement//////////////////////////////////////
                    if (LShalby[0].X + 50 >= LSe7lya[0].X && LShalby[0].X + 50 <= LSe7lya[0].X + LSe7lya[0].im[0].Width
                        && LShalby[0].Y + 10 >= LSe7lya[0].Y && LShalby[0].Y <= LSe7lya[0].Y + LSe7lya[0].im[0].Height)
                    {
                        CActorGameOver pnn = new CActorGameOver();
                        pnn.X = 200;
                        pnn.Y = 160;
                        pnn.im1 = new Bitmap("Game Over 1.png");
                        pnn.im2 = new Bitmap("gameOver.png");
                        LGameOver.Add(pnn);
                        Pause = 1;
                        Life = 0;
                    }
                    if (LShalby[0].X + 50 >= L3nkbot[0].X && LShalby[0].X + 50 <= L3nkbot[0].X + L3nkbot[0].im[0].Width
                        && LShalby[0].Y + 10 >= L3nkbot[0].Y && LShalby[0].Y <= L3nkbot[0].Y + L3nkbot[0].im[0].Height)
                    {
                        CActorGameOver pnn = new CActorGameOver();
                        pnn.X = 200;
                        pnn.Y = 160;
                        pnn.im1 = new Bitmap("Game Over 1.png");
                        pnn.im2 = new Bitmap("gameOver.png");
                        LGameOver.Add(pnn);
                        Pause = 1;
                        Life = 0;
                    }
                    /////////////////////////////////////////////// Shalby by5sr///////////////////////////////////////
                    for (i = 0; i < LBoo1.Count; i++)
                    {
                        if (LShalby[0].X + LShalby[0].im[0].Width - 20 >= LBoo1[i].X && LShalby[0].X <= LBoo1[i].X + LBoo1[i].im.Width
                            && LShalby[0].Y + 10 >= LBoo1[i].Y && LShalby[0].Y <= LBoo1[i].Y + LBoo1[i].im.Height)
                        {
                            LBoo1.Remove(LBoo1[i]);
                            LBoo2[0].iFrame = 1;
                            FlagBoo = 1;
                        }
                    }
                    //////////////////////////////////////////////////Shalby bya5od boo//////////////////////////////
                    if (LShalby[0].X + LShalby[0].im[0].Width + 20 >= LDoor[0].X && LDoor[0].X <= LDoor[0].X + LDoor[0].im.Width
                            && LShalby[0].Y + 20 >= LDoor[0].Y && LDoor[0].Y <= LDoor[0].Y + LDoor[0].im.Height && FlagBoo == 1)
                    {
                        CActorWinner pnn = new CActorWinner();
                        pnn.X = 230;
                        pnn.Y = 80;
                        pnn.im1 = new Bitmap("Win.png");
                        pnn.im2 = new Bitmap("winner.png");
                        LWinner.Add(pnn);
                        WinnerW = 1;
                        Pause = 1;
                    }
                    //////////////////////////////////////////////////Shalby byksb///////////////////////////////////////
                    if (LShalby[0].X + 50 >= LG[0].X && LShalby[0].X + 50 <= LG[0].X + LG[0].im[0].Width
                        && LShalby[0].Y + 10 >= LG[0].Y && LShalby[0].Y <= LG[0].Y + LG[0].im[0].Height && FlagBoo == 1)
                    {
                        HalaG = 1;
                        CActorHalaG pnn = new CActorHalaG();
                        pnn.X = 0;
                        pnn.Y = 0;
                        pnn.im = new Bitmap("7ala G.jpg");
                        LHalaG.Add(pnn);
                    }
                    //////////////////////////////////////////////////Hala G/////////////////////////////////////////////
                    for (i = 0; i < LEnergy.Count; i++)
                    {
                        if (LShalby[0].X + 40 >= LEnergy[i].X && LShalby[0].X + 100 <= LEnergy[i].X + LEnergy[i].im.Width
                            && LShalby[0].Y + 40 >= LEnergy[i].Y && LShalby[0].Y + 50 <= LEnergy[i].Y + LEnergy[i].im.Height)
                        {
                            LEnergy.Remove(LEnergy[i]);
                            Score += 20;
                        }
                    }
                    ////////////////////////////////////////////////////Energy Tank hit/////////////////////////
                    for (i = 0; i < LLogo.Count; i++)
                    {
                        if (LShalby[0].X >= LLogo[i].X && LShalby[0].X <= LLogo[i].X + LLogo[i].im.Width
                            && LShalby[0].Y + 40 >= LLogo[i].Y && LShalby[0].Y + 50 <= LLogo[i].Y + LLogo[i].im.Height)
                        {
                            N = RR.Next(4);
                            if (N == 0)
                            {
                                LLogo[i].X = 285;
                                LLogo[i].Y = 210;
                            }
                            if (N == 1)
                            {
                                LLogo[i].X = 230;
                                LLogo[i].Y = this.ClientSize.Height / 2 + 50;
                            }
                            if (N == 2)
                            {
                                LLogo[i].X = 730;
                                LLogo[i].Y = 60;
                            }
                            if (N == 3)
                            {
                                LLogo[i].X = 1190;
                                LLogo[i].Y = 580;
                            }
                            Score += 100;
                        }
                    }
                    /////////////////////////////////////////////////Logo Hit/////////////////////////////////////
                }
                else
                {
                    if (Life == 0)
                    {
                        if (GameOverW < LGameOver[0].im1.Width)
                        {
                            GameOverW += 20;
                        }
                    }
                    if (WinnerW > 0)
                    {
                        if (WinnerW < LWinner[0].im1.Width)
                        {
                            WinnerW += 20;
                        }
                    }
                }
            }
            if (HalaG == 1)
            {
                if (HalaGW < LHalaG[0].im.Width)
                {
                    HalaGW += 20;
                }
            }
            CountTick++;
            DrawDubb();
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            int i;
            CActorMaze pnn = new CActorMaze();
            pnn.X = 100;
            pnn.Y = 50; 
            pnn.W = this.ClientSize.Width-2;
            pnn.H = 5;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = 100;
            pnn.Y = this.ClientSize.Height-50;
            pnn.W = this.ClientSize.Width - 2;
            pnn.H = 5;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = this.ClientSize.Width - 7;
            pnn.Y = 50;
            pnn.W = 5;
            pnn.H = this.ClientSize.Height - 95;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = 100;
            pnn.Y = 50;
            pnn.W = 5;
            pnn.H = (this.ClientSize.Height / 2) - 130;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = 0;
            pnn.Y = (this.ClientSize.Height / 2) - 85;
            pnn.W = 100;
            pnn.H = 5;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = 100;
            pnn.Y = (this.ClientSize.Height / 2) + 75;
            pnn.W = 5;
            pnn.H = (this.ClientSize.Height) / 2 - 120;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = 0;
            pnn.Y = (this.ClientSize.Height / 2) + 75;
            pnn.W = 100;
            pnn.H = 5;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = this.ClientSize.Width / 2;
            pnn.Y = 50;
            pnn.W = 30;
            pnn.H = 100;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = this.ClientSize.Width / 4;
            pnn.Y = this.ClientSize.Height - 150;
            pnn.W = 30;
            pnn.H = 100;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = ((this.ClientSize.Width / 4) * 3) - 30;
            pnn.Y = this.ClientSize.Height - 150;
            pnn.W = 30;
            pnn.H = 100;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = this.ClientSize.Width / 2 - 130;
            pnn.Y = this.ClientSize.Height / 2 - 80;
            pnn.W = 280;
            pnn.H = 180;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = this.ClientSize.Width / 2 - 125;
            pnn.Y = this.ClientSize.Height / 2 - 75;
            pnn.W = 270;
            pnn.H = 170;
            LMaze.Add(pnn);

            pnn = new CActorMaze();
            pnn.X = 250;
            pnn.Y = 200;
            pnn.W = 30;
            pnn.H = 200;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = 280;
            pnn.Y = 280;
            pnn.W = 70;
            pnn.H = 30;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = this.ClientSize.Width / 2 - 200;
            pnn.Y = 150;
            pnn.W = 30;
            pnn.H = 100;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = 413;
            pnn.Y = 150;
            pnn.W = 70;
            pnn.H = 30;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = 900;
            pnn.Y = 170;
            pnn.W = 160;
            pnn.H = 100;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = 1200;
            pnn.Y = 160;
            pnn.W = 159;
            pnn.H = 30;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = 1200;
            pnn.Y = 300;
            pnn.W = 30;
            pnn.H = 90;
            LMaze.Add(pnn);

            pnn = new CActorMaze();
            pnn.X = 553;
            pnn.Y = 470;
            pnn.W = 280;
            pnn.H = 30;
            LMaze.Add(pnn);
            pnn = new CActorMaze();
            pnn.X = 670;
            pnn.Y = 500;
            pnn.W = 30;
            pnn.H = 50;
            LMaze.Add(pnn);
            ////////////////////////////////////////////////////Maze Creation//////////////////////////////////
            CActorShalby pnn1 = new CActorShalby();
            pnn1.X = 10;
            pnn1.Y = this.ClientSize.Height / 2 - 50;
            pnn1.im = new List<Bitmap>();
            for (i = 0; i < 2; i++)
            {
                Bitmap bb = new Bitmap("Shalby "+(i + 1) + ".png");
                pnn1.im.Add(bb);
            }
            pnn1.iFrame = 0;
            LShalby.Add(pnn1);
            ////////////////////////////////////////Shalby creation////////////////////////////////////
            CActorDoor pnn2 = new CActorDoor();
            pnn2.X = this.ClientSize.Width - 105;
            pnn2.Y = this.ClientSize.Height - 210;
            pnn2.im = new Bitmap("door.bmp");
            pnn2.im.MakeTransparent(pnn2.im.GetPixel(0, 0));
            LDoor.Add(pnn2);
            ///////////////////////////////////////Door Creation////////////////////////////////////
            CActorBoo1 pnn3 = new CActorBoo1();
            pnn3.X = this.ClientSize.Width - 80;
            pnn3.Y = 58;
            pnn3.im = new Bitmap("boo 1.png");
            pnn3.im.MakeTransparent(pnn3.im.GetPixel(0, 0));
            LBoo1.Add(pnn3);
            /////////////////////////////////////Boo 1 creation/////////////////////////////////////////
            CActorSe7lya pnn4 = new CActorSe7lya();
            pnn4.X = 110;
            pnn4.Y = 53;
            pnn4.im = new List<Bitmap>();
            for (i = 0; i < 2; i++)
            {
                Bitmap bb = new Bitmap("Se7lya " + (i + 1) + ".png");
                pnn4.im.Add(bb);
            }
            pnn4.iFrame = 0;
            pnn4.dx = 1;
            pnn4.dy = 0;
            LSe7lya.Add(pnn4);
            //////////////////////////////////Se7lya Creation///////////////////////////////////////
            CActor3nkbot pnn5 = new CActor3nkbot();
            pnn5.X = 820;
            pnn5.Y = this.ClientSize.Height / 2 - 50;
            pnn5.im = new List<Bitmap>();
            for (i = 0; i < 2; i++)
            {
                Bitmap bb = new Bitmap("3ankbot " + (i + 1) + ".png");
                pnn5.im.Add(bb);
            }
            pnn5.iFrame = 0;
            pnn5.dx = 1;
            pnn5.dy = 0;
            L3nkbot.Add(pnn5);
            ///////////////////////////////////////////3ankbot Creation///////////////////////////////////////
            CActorBoo2 pnn6 = new CActorBoo2();
            pnn6.X = 30;
            pnn6.Y = 150;
            pnn6.im = new List<Bitmap>();
            for (i = 1; i < 3; i++)
            {
                Bitmap bb = new Bitmap("boo " + (i + 1) + ".png");
                pnn6.im.Add(bb);
            }
            pnn6.iFrame = 0;
            LBoo2.Add(pnn6);
            /////////////////////////////////////////////////////boo 2 creation//////////////////////////////////////

            CActorEnergyTank pnn7;
            int tmpx = 550;
            for (i = 0; i < 3; i++)
            {
                pnn7 = new CActorEnergyTank();
                pnn7.X = tmpx;
                pnn7.Y = 160;
                pnn7.im = new Bitmap("Energy Tank.png");
                LEnergy.Add(pnn7);
                tmpx += 80;
            }
            tmpx = 380;
            for (i = 0; i < 5; i++)
            {
                pnn7 = new CActorEnergyTank();
                pnn7.X = tmpx;
                pnn7.Y = 550;
                pnn7.im = new Bitmap("Energy Tank.png");
                LEnergy.Add(pnn7);
                tmpx += 120;
            }
            pnn7 = new CActorEnergyTank();
            pnn7.X = 265;
            pnn7.Y = 285;
            pnn7.im = new Bitmap("Energy Tank.png");
            LEnergy.Add(pnn7);
            pnn7 = new CActorEnergyTank();
            pnn7.X = 200;
            pnn7.Y = 550;
            pnn7.im = new Bitmap("Energy Tank.png");
            LEnergy.Add(pnn7);
            pnn7 = new CActorEnergyTank();
            pnn7.X = 250;
            pnn7.Y = 550;
            pnn7.im = new Bitmap("Energy Tank.png");
            LEnergy.Add(pnn7);
            pnn7 = new CActorEnergyTank();
            pnn7.X = 265;
            pnn7.Y = 285;
            pnn7.im = new Bitmap("Energy Tank.png");
            LEnergy.Add(pnn7);

            pnn7 = new CActorEnergyTank();
            pnn7.X = this.ClientSize.Width - 120;
            pnn7.Y = 210;
            pnn7.im = new Bitmap("Energy Tank.png");
            LEnergy.Add(pnn7);
            pnn7 = new CActorEnergyTank();
            pnn7.X = this.ClientSize.Width - 120;
            pnn7.Y = 340;
            pnn7.im = new Bitmap("Energy Tank.png");
            LEnergy.Add(pnn7);
            ////////////////////////////////////////////////////////Energy Tank creation////////////////////////////////
            N = RR.Next(4);
            CActorLogo pnn8 = new CActorLogo();
            if (N == 0)
            {
                pnn8.X = 285;
                pnn8.Y = 210;
                pnn8.im = new Bitmap("Logo.png");
                pnn8.im.MakeTransparent(pnn8.im.GetPixel(0, 0));
                LLogo.Add(pnn8);
            }
            if (N == 1)
            {
                pnn8.X = 230;
                pnn8.Y = this.ClientSize.Height / 2 + 50;
                pnn8.im = new Bitmap("Logo.png");
                pnn8.im.MakeTransparent(pnn8.im.GetPixel(0, 0));
                LLogo.Add(pnn8);
            }
            if (N == 2)
            {
                pnn8.X = 730;
                pnn8.Y = 60;
                pnn8.im = new Bitmap("Logo.png");
                pnn8.im.MakeTransparent(pnn8.im.GetPixel(0, 0));
                LLogo.Add(pnn8);
            }
            if (N == 3)
            {
                pnn8.X = 1190;
                pnn8.Y = 580;
                pnn8.im = new Bitmap("Logo.png");
                pnn8.im.MakeTransparent(pnn8.im.GetPixel(0, 0));
                LLogo.Add(pnn8);
            }
            //////////////////////////////////////////////////////////////Logo Creation//////////////////////////////////
            CActorPause pnn9 = new CActorPause();
            pnn9.X = 35;
            pnn9.Y = 75;
            pnn9.im = new List<Bitmap>();
            for (i = 0; i < 2; i++)
            {
                Bitmap bb = new Bitmap("pause " + (i + 1) + ".png");
                pnn9.im.Add(bb);
            }
            pnn9.iFrame = 0;
            LPause.Add(pnn9);
            ////////////////////////////////////////////////////////////Pause////////////////////////////////
            CActorG pnn10 = new CActorG();
            pnn10.X = 700;
            pnn10.Y = 53;
            pnn10.im = new List<Bitmap>();
            for (i = 0; i < 2; i++)
            {
                Bitmap bb = new Bitmap("G" + (i + 1) + ".png");
                pnn10.im.Add(bb);
            }
            pnn10.iFrame = 0;
            pnn10.dx = 1;
            LG.Add(pnn10);
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int j = -1;
            int i;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (HalaG == 0)
                    {
                        if (Pause == 0)
                        {
                            for (i = 0; i < LMaze.Count; i++)
                            {
                                if (LMaze[i].X <= LShalby[0].X)
                                {
                                    if ((LShalby[0].X + LShalby[0].im[0].Width - 3 >= LMaze[i].X
                                        && LShalby[0].X <= (LMaze[i].X + LMaze[i].W)
                                        && LShalby[0].Y >= LMaze[i].Y
                                        && LShalby[0].Y <= (LMaze[i].Y + LMaze[i].H)))
                                    {
                                        j = i;
                                        break;
                                    }
                                }
                            }
                            if (j == -1)
                            {
                                LShalby[0].X -= 5;
                            }
                            LShalby[0].iFrame = 1;
                        }
                    }
                    break;
                case Keys.Right:
                    if (HalaG == 0)
                    {
                        if (Pause == 0)
                        {
                            for (i = 0; i < LMaze.Count; i++)
                            {
                                if (LMaze[i].X >= LShalby[0].X)
                                {
                                    if ((LShalby[0].X + LShalby[0].im[0].Width + 3 >= LMaze[i].X
                                        && LShalby[0].X <= (LMaze[i].X + LMaze[i].W)
                                        && LShalby[0].Y >= LMaze[i].Y
                                        && LShalby[0].Y <= (LMaze[i].Y + LMaze[i].H)))
                                    {
                                        j = i;
                                        break;
                                    }
                                }
                            }
                            if (j == -1)
                            {
                                LShalby[0].X += 5;
                            }
                            LShalby[0].iFrame = 0;
                        }
                    }
                    break;
                case Keys.Up:
                    if (HalaG == 0)
                    {
                        if (Pause == 0)
                        {
                            for (i = 0; i < LMaze.Count; i++)
                            {
                                if (LMaze[i].Y <= LShalby[0].Y)
                                {
                                    if (LShalby[0].X >= LMaze[i].X
                                        && LShalby[0].X <= (LMaze[i].X + LMaze[i].W)
                                        && LShalby[0].Y >= LMaze[i].Y
                                        && LShalby[0].Y <= (LMaze[i].Y + LMaze[i].H))
                                    {
                                        //LShalby[0].Y -= 5;
                                        j = i;
                                        break;
                                    }
                                }
                            }
                            if (j == -1)
                            {
                                LShalby[0].Y -= 5;
                            }

                            //LShalby[0].iFrame = 2;
                        }
                    }
                    break;
                case Keys.Down:
                    if (HalaG == 0)
                    {
                        if (Pause == 0)
                        {
                            for (i = 0; i < LMaze.Count; i++)
                            {
                                if (LMaze[i].Y >= LShalby[0].Y)
                                {
                                    if (LShalby[0].X >= LMaze[i].X
                                        && LShalby[0].X <= (LMaze[i].X + LMaze[i].W)
                                        && LShalby[0].Y + LShalby[0].im[0].Height >= LMaze[i].Y
                                        && LShalby[0].Y + LShalby[0].im[0].Height <= (LMaze[i].Y + LMaze[i].H))
                                    {
                                        //LShalby[0].Y += 5;
                                        j = i;
                                        break;
                                    }
                                }
                            }
                            if (j == -1)
                            {
                                LShalby[0].Y += 5;
                            }
                            //LShalby[0].iFrame = 2;
                        }
                    }
                    break;
                case Keys.Space:
                    if (HalaG == 1)
                    {
                        t.Start();
                        FlagBoo = 0;
                        HalaG = 0;
                        LHalaG.Remove(LHalaG[0]);
                        LShalby[0].X = 10;
                        LShalby[0].Y = this.ClientSize.Height / 2 - 50;
                        LBoo2[0].iFrame = 0;
                        LShalby[0].iFrame = 0;
                        CActorBoo1 pnn3 = new CActorBoo1();
                        pnn3.X = this.ClientSize.Width - 80;
                        pnn3.Y = 58;
                        pnn3.im = new Bitmap("boo 1.png");
                        pnn3.im.MakeTransparent(pnn3.im.GetPixel(0, 0));
                        LBoo1.Add(pnn3);
                        HalaGW = 0;
                    }
                    break;
            }
        }

        void DrawScene(Graphics g2)
        {
            g2.Clear(Color.Black);
            int i;
            Font Fnt;
            SolidBrush Brsh;
            if (HalaG == 0)
            {
                Pen P = new Pen(Color.Blue , 2);
                for (i = 0; i < LMaze.Count; i++)
                {
                    g2.DrawRectangle(P, LMaze[i].X, LMaze[i].Y, LMaze[i].W, LMaze[i].H);
                    /*Fnt = new Font("System", 15);
                    Brsh = new SolidBrush(Color.Red);
                    g2.DrawString("" + i ,Fnt, Brsh, LMaze[i].X , LMaze[i].Y - 20);*/
                }
                int j = LShalby[0].iFrame;
                g2.DrawImage(LShalby[0].im[j], LShalby[0].X, LShalby[0].Y);
                g2.DrawImage(LDoor[0].im, LDoor[0].X, LDoor[0].Y);
                for (i = 0; i < LBoo1.Count; i++)
                {
                    g2.DrawImage(LBoo1[i].im, LBoo1[i].X, LBoo1[i].Y);
                }
                j = LSe7lya[0].iFrame;
                g2.DrawImage(LSe7lya[0].im[j], LSe7lya[0].X, LSe7lya[0].Y);

                j = LG[0].iFrame;
                g2.DrawImage(LG[0].im[j], LG[0].X, LG[0].Y);

                j = L3nkbot[0].iFrame;
                g2.DrawImage(L3nkbot[0].im[j], L3nkbot[0].X, L3nkbot[0].Y);

                j = LBoo2[0].iFrame;
                g2.DrawImage(LBoo2[0].im[j], LBoo2[0].X, LBoo2[0].Y);

                j = LPause[0].iFrame;
                g2.DrawImage(LPause[0].im[j], LPause[0].X, LPause[0].Y);

                for (i = 0; i < LEnergy.Count; i++)
                {
                    g2.DrawImage(LEnergy[i].im, LEnergy[i].X, LEnergy[i].Y);
                }
                for (i = 0; i < LLogo.Count; i++)
                {
                    g2.DrawImage(LLogo[i].im, LLogo[i].X, LLogo[i].Y);
                }

                Fnt = new Font("Bernard MT Condensed", 20);
                Brsh = new SolidBrush(Color.Gold);
                g2.DrawString("Score: " + Score, Fnt, Brsh, 10, 15);

                Rectangle rcD, rcS;
                for (i = 0; i < LGameOver.Count; i++)
                {
                    rcD = new Rectangle(LGameOver[i].X, LGameOver[i].Y, GameOverW, LGameOver[i].im1.Height);
                    rcS = new Rectangle(0, 0, GameOverW, LGameOver[0].im1.Height);
                    g2.DrawImage(LGameOver[0].im1, rcD, rcS, GraphicsUnit.Pixel);

                    rcD = new Rectangle(LGameOver[i].X + 180, LGameOver[i].Y + 280, GameOverW, LGameOver[i].im2.Height);
                    rcS = new Rectangle(0, 0, GameOverW, LGameOver[i].im2.Height);
                    g2.DrawImage(LGameOver[i].im2, rcD, rcS, GraphicsUnit.Pixel);
                }
                for (i = 0; i < LWinner.Count; i++)
                {
                    rcD = new Rectangle(LWinner[i].X, LWinner[i].Y, WinnerW, LWinner[i].im1.Height);
                    rcS = new Rectangle(0, 0, WinnerW, LWinner[0].im1.Height);
                    g2.DrawImage(LWinner[0].im1, rcD, rcS, GraphicsUnit.Pixel);

                    rcD = new Rectangle(LWinner[i].X + 150, LWinner[i].Y + 260, WinnerW, LWinner[i].im2.Height);
                    rcS = new Rectangle(0, 0, WinnerW, LWinner[i].im2.Height);
                    g2.DrawImage(LWinner[i].im2, rcD, rcS, GraphicsUnit.Pixel);
                }
            }
            else
            {
                Rectangle rcD, rcS;
                for (i = 0; i < LHalaG.Count; i++)
                {
                    rcD = new Rectangle(LHalaG[i].X, LHalaG[i].Y, HalaGW, LHalaG[i].im.Height);
                    rcS = new Rectangle(0, 0, HalaGW, LHalaG[0].im.Height);
                    g2.DrawImage(LHalaG[0].im, rcD, rcS, GraphicsUnit.Pixel);
                }
            }
        }

        void DrawDubb()
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            Graphics g = this.CreateGraphics();
            g.DrawImage(off, 0, 0);
        }
    }
}
