using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class TURTLEA
    {
        public TURTLEA()
        {
            int NMAX = 0;
            float PI = 0;
            float X = 0;
            float Y = 0;
            float PHI = 0;
            float H = 0;
            string AXIOMs = "";
            string PROD1s = "";
            string PROD2s = "";
            string WEGs = "";
            int N = 0;
            string Ws = "";
            string Ss = "";
            int I = 0;

            string Qs = "";
            // REM ***Mandelbrot's archipel***
            // REM ***naam:TURTLEA***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-4,-3)-(4,3)
            GW.WINDOW(-4f, -3f, 4f, 3f);
            //    NMAX=2 : PI=4*GW.ATN(1)
            NMAX = 2;
            PI = 4 * GW.ATN(1);
            // REM ***beginpositie en staplengte***
            //    X=-1 : Y=-1 : PHI=0 : H=.06
            X = -1;
            Y = -1;
            PHI = 0;
            H = .06f;
            // REM ***axioma en productieregel***
            //    AXIOM$="F+F+F+F"
            AXIOMs = "F+F+F+F";
            //    PROD1$="F-f+FF-F-FF-Ff-FF+f-FF+F+FF+Ff+FFF"
            PROD1s = "F-f+FF-F-FF-Ff-FF+f-FF+F+FF+Ff+FFF";
            //    PROD2$="ffffff"
            PROD2s = "ffffff";
            // REM ***vorming van woord***
            //    WEG$=AXIOM$
            WEGs = AXIOMs;
            //    FOR N=1 TO NMAX
            for (N = 1; N <= NMAX; N++)
            {
                //       W$=""
                Ws = "";
                //       FOR I=1 TO GW.LEN(WEG$)
                for (I = 1; I <= GW.LEN(WEGs); I++)
                {
                    //          S$=GW.MID(WEG$,I,1)
                    Ss = GW.MID(WEGs, I, 1);
                    //          IF S$="F" THEN Q$=PROD1$
                    if (Ss == "F")
                    {
                        Qs = PROD1s;
                    }
                    //          IF S$="f" THEN Q$=PROD2$
                    if (Ss == "f")
                    {
                        Qs = PROD2s;
                    }
                    //          IF S$="+" OR S$="-" THEN Q$=S$
                    if (Ss == "+" || Ss == "-")
                    {
                        Qs = Ss;
                    }
                    //          W$=W$+Q$
                    Ws = Ws + Qs;
                    //       NEXT I
                }
                //       WEG$=W$
                WEGs = Ws;
                //    NEXT N
            }
            // REM ***graphics***
            //    PSET (X,Y)
            GW.PSET(X, Y);
            //    FOR I=1 TO GW.LEN(WEG$)
            for (I = 1; I <= GW.LEN(WEGs); I++)
            {
                //       S$=GW.MID(WEG$,I,1)
                Ss = GW.MID(WEGs, I, 1);
                //       SELECT CASE S$
                switch (Ss)
                {
                    //       CASE "+"
                    case "+":
                        //          PHI=PHI+PI/2
                        PHI = PHI + PI / 2;
                        //       CASE "-"
                        break;
                    case "-":
                        //          PHI=PHI-PI/2
                        PHI = PHI - PI / 2;
                        //       CASE "F"
                        break;
                    case "F":
                        //          X=X+H*GW.COS(PHI) : Y=Y+H*GW.SIN(PHI)
                        X = X + H * GW.COS(PHI);
                        Y = Y + H * GW.SIN(PHI);
                        //          LINE -(X,Y)
                        GW.LINE(X, Y);
                        //       CASE "f"
                        break;
                    case "f":
                        //          X=X+H*GW.COS(PHI) : Y=Y+H*GW.SIN(PHI)
                        X = X + H * GW.COS(PHI);
                        Y = Y + H * GW.SIN(PHI);
                        //          PSET (X,Y),0
                        GW.PSET(X, Y,0);
                        //       END SELECT
                        break;
                    default:
                        break;
                }
                //    NEXT I
            }
            // END
            return;
            // 
            ;
        }
    }
}
