using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Graphics_boek
{
    public class GW
    {
        public static Bitmap beeld;
        public static Bitmap schermBeeld;
        private static readonly object screenGraphicsLock = new object();
        public static float winX1 = 0;
        public static float winX2 = 0;
        public static float winY1 = 0;
        public static float winY2 = 0;
        public static int ClWidth;
        public static int ClHeight;
        public static float lastX = 0;
        public static float lastY = 0;
        public static float printX = 1;
        public static float printY = 1;
        public static int fgColor = 7;
        public static int bgColor = 0;
        public static char INKEYv = (char)0x00;
        public static char INKEYt = (char)0x00;
        public static Color[] colors = new Color[16];
        public static int[] palettes = new int[64];

        public static void Init()
        {
            colors[0] = Color.Black;
            colors[1] = Color.Blue;
            colors[2] = Color.Green;
            colors[3] = Color.Cyan;
            colors[4] = Color.Red;
            colors[5] = Color.Magenta;
            colors[6] = Color.Brown;
            colors[7] = Color.WhiteSmoke;
            colors[8] = Color.Gray;
            colors[9] = Color.LightBlue;
            colors[10] = Color.LightGreen;
            colors[11] = Color.LightCyan;
            colors[12] = Color.IndianRed;
            colors[13] = Color.Violet;
            colors[14] = Color.Yellow;
            colors[15] = Color.White;
            for (int c = 0; c < 64; c++) palettes[c] = c % 16;
            GW.ClWidth = GW.beeld.Width;
            GW.ClHeight = GW.beeld.Height;
            printX = 1f / 80f * 640;
            printY = 1f / 25f * 350;
        }
        static int SleepCount = 0;
        public static void Pause() // determines speed of drawing to simulate an 8088
        {
            SleepCount++;
            if (SleepCount > 1000)
            {
                SleepCount = 0;
                Thread.Sleep(1);
            }
        }
        public static float SIN(float X)
        {
            return (float)Math.Sin(X);
        }
        public static float COS(float X)
        {
            return (float)Math.Cos(X);
        }
        public static float ATN(float X)
        {
            return (float)Math.Atan(X);
        }
        public static float SQR(float X)
        {
            return (float)Math.Sqrt(X);
        }
        public static float LOG(float X)
        {
            return (float)Math.Log(X);
        }
        public static float EXP(float X)
        {
            return (float)Math.Exp(X);
        }
        static Random rand = new Random();
        public static void RANDOMIZE(int SEED)
        {
            rand = new Random(SEED);
        }
        public static float RND()
        {
            return (float)rand.Next(32000) / 32000f;
        }
        public static float ABS(float x)
        {
            return (float)Math.Abs(x);
        }
        public static int ABS(int x)
        {
            return (int)Math.Abs(x);
        }
        public static string SPACE(int n)
        {
            return " ".PadRight(n);
        }
        public static int LEN(string n)
        {
            return n.Length;
        }
        public static string MID(string s, int st, int l)
        {
            return s.Substring(st - 1, 1);
        }
        public static Bitmap CopyBitmap(Bitmap source, Rectangle Rect)
        {
            Bitmap bmp = new Bitmap(Rect.Width, Rect.Height);
            lock (screenGraphicsLock)
            {
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(source, 0, 0, Rect, GraphicsUnit.Pixel);
                g.Dispose();
            }
            return bmp;
        }
        public static int TransformX(float x)
        {
            float xx = (x - winX1) / (winX2 - winX1) * ClWidth;
            if (xx < 1) xx = 1;
            if (xx >= ClWidth) xx = ClWidth - 1;
            return (int)xx;
        }
        public static int TransformY(float y)
        {
            float yy = (y - winY1) / (winY2 - winY1) * ClHeight;
            int yi = ClHeight - (int)yy;
            if (yi < 1) yi = 1;
            if (yi >= ClHeight) yi = ClHeight - 1;
            return yi;
        }
        public static void WINDOW(float x1, float y1, float x2, float y2) // Basic: WINDOW((X1,Y1) - (X2,Y2))
        {
            winX1 = x1;
            winY1 = y1;
            winX2 = x2;
            winY2 = y2;
        }
        public static void CLS()
        {
            lock (screenGraphicsLock)
            {
                Graphics g = Graphics.FromImage(beeld);
                SolidBrush brush = new SolidBrush(colors[palettes[bgColor]]);
                g.FillRectangle(brush, 0, 0, beeld.Width, beeld.Height);
                brush.Dispose();
                g.Dispose();
            }
        }
        public static int POINT(float X, float Y)
        {
            Color C;
            lock (screenGraphicsLock)
            {
                C = beeld.GetPixel(TransformX(X), TransformY(Y));
            }
            for (int i = 0; i < 16; i++)
                if (colors[i].R == C.R)
                    if (colors[i].B == C.B)
                        if (colors[i].G == C.G)
                            return i;
            return bgColor;
        }
        static Color initcolor;
        static Color pntcolor;
        static int[] ptX = new int[] { -1,  0,  1,  0 };
        static int[] ptY = new int[] {  0,  1,  0, -1 };
        static Stack<int> st = new Stack<int>(); 
        public static void PAINT(float X, float Y)
        {
            PAINT(X, Y,  fgColor);
        }
        public static void PAINT(float X, float Y, int C)
        {
            int Px = TransformX(X);
            int Py = TransformY(Y);
            pntcolor = colors[C];
            lock (screenGraphicsLock)
            {
               initcolor = beeld.GetPixel(Px, Py);
               beeld.SetPixel(Px, Py, pntcolor);
            }
            st.Push(Px * 10000 + Py);
            while (st.Count > 0)
            {
                    int x = st.Pop();
                    int x1 = x / 10000;
                    int x2 = x - x1 * 10000;
                    PAINTpix(x1, x2);
                }
            }
        static void PAINTpix(int Px, int Py)
        {
            lock (screenGraphicsLock)
            {
                beeld.SetPixel(Px, Py, pntcolor);
                for (int i = 0; i < 4; i++)
                {
                    Color nxtcolor;
                    nxtcolor = beeld.GetPixel(Px + ptX[i], Py + ptY[i]);
                    if (nxtcolor == initcolor)
                        st.Push((Px + ptX[i]) * 10000 + Py + ptY[i]);
                }
            }
        }
        public static void PSET(float X, float Y) // Basic: PSET(X,Y)
        {
            PSET(X, Y, fgColor);
        }
        public static void PSET(float X, float Y, int color) // Basic: PSET(X,Y), color
        {
            lock (screenGraphicsLock)
            {
                beeld.SetPixel(TransformX(X), TransformY(Y), colors[palettes[color]]);
            }
            lastX = X;
            lastY = Y;
            Pause();
        }
        public static void PSETe(float X, float Y) // Basic: PSET(X,Y) colors pixel and neighbours
        {
            PSETe(X, Y, fgColor);
        }
        public static void PSETe(float X, float Y, int color) // Basic: PSET(X,Y), color
        {
            lock (screenGraphicsLock)
            {
                int iX = TransformX(X);
                int iY = TransformY(Y);
                for (int eX = 0; eX < 3; eX++)
                    for (int eY = 0; eY < 2; eY++)
                        beeld.SetPixel(iX+eX, iY+eY, colors[palettes[color]]);
            }
            lastX = X;
            lastY = Y;
            Pause();
        }
        public static void LINE(float X, float Y) // Basic: LINE -(X,Y)
        {
            LINE(lastX, lastY, X, Y, fgColor);
        }
        public static void LINE(float X, float Y, int color) // Basic: LINE -(X,Y), color
        {
            LINE(lastX, lastY, X, Y, color);
        }
        public static void LINE(float fromX, float fromY, float X, float Y) // Basic: LINE (X,Y)-(X,Y)
        {
            LINE(fromX, fromY, X, Y, fgColor);
        }
        public static void LINE(float fromX, float fromY, float X, float Y, int color) // Basic: LINE (X,Y)-(X,Y), color
        {
            LINE(fromX, fromY, X, Y, color, "");
        }
        public static void LINE(float fromX, float fromY, float X, float Y, string area) // Basic: LINE (X,Y)-(X,Y), , "B"
        {
            LINE(fromX, fromY, X, Y, fgColor, area);
        }
        public static void LINE(float fromX, float fromY, float X, float Y, int color, string area) // Basic: LINE (X,Y)-(X,Y), color, "B"
        {
            lock (screenGraphicsLock)
            {
                Graphics g = Graphics.FromImage(beeld);
                Pen pen = new Pen(colors[palettes[color]], 1);
                int x1 = TransformX(fromX);
                int x2 = TransformX(X);
                int y1 = TransformY(fromY);
                int y2 = TransformY(Y);
                if (area == "B")
                {
                    g.DrawLine(pen, x1, y1, x1, y2);
                    g.DrawLine(pen, x1, y2, x2, y2);
                    g.DrawLine(pen, x2, y2, x2, y1);
                    g.DrawLine(pen, x2, y1, x1, y1);
                }
                else if (area == "BF")
                {
                    int x3 = x1;
                    if (x1 > x2) { x1 = x2; x2 = x3; }
                    int y3 = y1;
                    if (y1 > y2) { y1 = y2; y2 = y3; }
                    SolidBrush brush = new SolidBrush(colors[palettes[color]]);
                    g.FillRectangle(brush, x1, y1, x2 - x1, y2 - y1);
                    brush.Dispose();
                }
                else
                    g.DrawLine(pen, x1, y1, x2, y2);
                g.Dispose();
            }
            lastX = X;
            lastY = Y;
            Pause();
        }
        public static string INKEY() // Basic: IF INKEY$=..
        {
            if (INKEYv == (char)0x00)
                return "";
            string ret = "";
            if (GW.INKEYt == (char)0x00)
            {
              ret = INKEYv.ToString();
             }
            else // Fkey
            {
                ret = (char)0x01 + INKEYv.ToString();
            }
            INKEYt = (char)0x00;
            INKEYv = (char)0x00;
            return ret;
        }
        public static int TIMER()
        {
            TimeSpan x = DateTime.Now.TimeOfDay;
            return (int)x.TotalSeconds;
        }
        public static void LOCATE(float y, float x) // Basic: LOCATE X, Y
        {
            lock (screenGraphicsLock)
            {
                printX = x / 80f * beeld.Width;
                printY = (y - 1) / 25f * beeld.Height + 1;
            }
        }
        public static void PRINT(String s) // Basic: PRINT "string"
        {
            lock (screenGraphicsLock)
            {
                Graphics g = Graphics.FromImage(beeld);
                SolidBrush brush = new SolidBrush(colors[palettes[bgColor]]);
                int x = (int)printX;
                int y = (int)printY;
                g.FillRectangle(brush, x, y, beeld.Width, y + 14);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                Font font = new Font("Courier New", 10.0f);
                TextRenderer.DrawText(g, s, font, new Point(x, y), colors[palettes[fgColor]]);
                brush.Dispose();
                g.Dispose();
            }
            printY += 350 / 25f;
            Pause();
        }
        public static float INPUT(String s) // Basic: INPUT "string", var
        {
            float var = 0;
            bool stop = false;
            float sy = printY;
            string res = "";
            string Inkc;
            while (!stop)
            {
                printY = sy;
                PRINT(s + res);
                while ((Inkc = INKEY()) == "") Pause();
                if (Inkc == "\r")
                    stop = true;
                else if (float.TryParse(res + Inkc, out var))
                    res += Inkc;
            }
            return var;
        }
        public static string INPUTS(int len) // Basic: INPUT$(n), var
        {
            bool stop = false;
            float sy = printY;
            string res = "";
            string Inkc;
            while (!stop && res.Length < len)
            {
                printY = sy;
                PRINT(res);
                while ((Inkc = INKEY()) == "") Pause();
                if (Inkc == "\r")
                    stop = true;
                else
                    res += Inkc;
            }
            printY = sy;
            PRINT(res);
            return res;
        }
    }
}
