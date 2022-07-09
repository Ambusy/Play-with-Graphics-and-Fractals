using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Graphics_boek
{
    public partial class Form1 : Form
    {
        static void DrawModule()
        {
            //TSTP p = new TSTP();
            //chapter 2
            // KATTEN pgm = new KATTEN();
            // CIRKELB pgm = new CIRKELB();
            // FOURIER pgm = new FOURIER();
            // LISSA pgm = new LISSA();
            // LISSAX pgm = new LISSAX();
            // LISSAV pgm = new LISSAV();
            //chapter 3
            // WEB pgm = new WEB();
            // KANT pgm = new KANT();
            // STERPQ pgm = new STERPQ();
            // ASTROIDE pgm = new ASTROIDE();
            // CYCLO1 pgm = new CYCLO1();
            // CYCLO2 pgm = new CYCLO2();
            // TURNLINE pgm = new TURNLINE();
            // WERVEL pgm = new WERVEL();
            // OMHUL pgm = new OMHUL();
            // CAUSTIC pgm = new CAUSTIC();
            // KALEIDO pgm = new KALEIDO();
            //chapter 4
            // PATROON1 pgm = new PATROON1();
            // PATROON2 pgm = new PATROON2();
            // PATROON3 pgm = new PATROON3();
            // PATROON4 pgm = new PATROON4();
            // ARTBLOK pgm = new ARTBLOK();
            // STEMPEL pgm = new STEMPEL();
            // TRUCHET pgm = new TRUCHET();
            //chapter 5
            // FRACMC1 pgm = new FRACMC1();
            // FRACMC2 pgm = new FRACMC2();
            // FRACMC3 pgm = new FRACMC3();
            // FRACMC4 pgm = new FRACMC4();
            // FRACMC5 pgm = new FRACMC5();
            // FRACMC6 pgm = new FRACMC6();
            // FRACMC7 pgm = new FRACMC7();
            // BLAD pgm = new BLAD();
            // VAREN pgm = new VAREN();
            // SQUAREF pgm = new SQUAREF();
            //chapter 6
            // GROEIM1 pgm = new GROEIM1();
            // GROEIM2 pgm = new GROEIM2();
            // HENON1 pgm = new HENON1();
            // HENON2 pgm = new HENON2();
            // DYNSYSX1 pgm = new DYNSYSX1();
            // DYNSYSX2 pgm = new DYNSYSX2();
            // MIRADSX1 pgm = new MIRADSX1();
            // MIRADSX2 pgm = new MIRADSX2();
            //CHAPTER 8
            // TURTLE pgm = new TURTLE();
            // TURTLEK pgm = new TURTLEK();
            // TURTLEK1 pgm = new TURTLEK1();
            // TURTLEK2 pgm = new TURTLEK2();
            // TURTLEM pgm = new TURTLEM();
            // TURTLEK3 pgm = new TURTLEK3();
            // TURTLEK4 pgm = new TURTLEK4();
            // TURTLES pgm = new TURTLES();
            // TURTLEA pgm = new TURTLEA();
            //CHAPTER 9
            // JULIAMC pgm = new JULIAMC();
            // JULFILL pgm = new JULFILL();
            // JULFILLX pgm = new JULFILLX();
            // JULBSC pgm = new JULBSC();
            // JULDIST pgm = new JULDIST();
            // JULIAP pgm = new JULIAP();
            // JULIAPX pgm = new JULIAPX();
            // JULIAT pgm = new JULIAT();
            //CHAPTER 10
            // MANDELX1 pgm = new MANDELX1();
             MANDIST pgm = new MANDIST();
            // MANDELX2 pgm = new MANDELX2();
            //MANDELX3 pgm = new MANDELX3();            
            // MZOOML pgm = new MZOOML();
        }
        public Form1()
        {
            InitializeComponent();
        }
            ThreadStart moduleThread;
            Thread drawModuleThread;
        void Form1_Load(object sender, EventArgs e)
        {
            GW.winX2 = ClientRectangle.Width;
            GW.winY2 = ClientRectangle.Height;
            GW.beeld = new Bitmap(ClientRectangle.Width, ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GW.schermBeeld = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GW.Init();
            moduleThread = new ThreadStart(DrawModule);
            drawModuleThread = new Thread(moduleThread);
            drawModuleThread.Start();
            timer1.Enabled = true;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int i = (int)e.KeyValue;
            if (i >= 112 && i <= 123) // F1 to F12
            {
                i -= 53; // GWBasic values for F1 to F12
                GW.INKEYt = (char)0x01; // Fkey
                byte[] intBytes = BitConverter.GetBytes(i);
                GW.INKEYv = (char)intBytes[0];
            }
            else if (i >= 37 && i <= 40) // arrows
            {
                if (i == 37) i = 75;
                else if (i == 38) i = 80;
                else if (i == 39) i = 77;
                else if (i == 40) i = 72;
                // GWBasic values for arrows
                GW.INKEYt = (char)0x01; // arrow
                byte[] intBytes = BitConverter.GetBytes(i);
                GW.INKEYv = (char)intBytes[0];
            }
            else
            {
                GW.INKEYt = (char)0x00; //normal key, Keypress will supply the value
            }
            e.Handled = true;
        }
        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            GW.INKEYt = (char)0x00; //normal key
            GW.INKEYv = e.KeyChar;
            e.Handled = true;
        }         
        void Timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Width>0 && pictureBox1.Height > 0) {
            GW.schermBeeld = GW.CopyBitmap(GW.beeld, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            pictureBox1.Image = GW.schermBeeld;
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
