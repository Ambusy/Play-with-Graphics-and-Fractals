using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class TURTLES
    {
        public TURTLES()
        {
            int NMAX = 0;
            float PI = 0;
            float X = 0;
            float Y = 0;
            float H = 0;
            string AXIOMs = "";
            string PRODs = "";
            string WEGs = "";
            int N = 0;
            string Ws = "";
            int I = 0;
            string Ss = "";
            string Qs = "";
            float P = 0;
            float Q = 0;
            float P1 = 0;
            float Q1 = 0;

            string As = "";
            // REM ***vierkant van Sierpinski***
            // REM ***naam:TURTLES***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-4,-3)-(4,3)
            GW.WINDOW(-4f, -3f, 4f, 3f);
            //    NMAX=3 : PI=4*GW.ATN(1)
            NMAX = 3;
            PI = 4 * GW.ATN(1);
            // REM ***beginpositie en staplengte***
            //    X=-1.5 : Y=-1.5 : H=.12
            X = -1.5f;
            Y = -1.5f;
            H = .12f;
            // REM ***axioma en productieregel***
            //    AXIOM$="F+F+F+F"
            AXIOMs = "F+F+F+F";
            //    PROD$="FF+F+F+F+FF"
            PRODs = "FF+F+F+F+FF";
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
                    //          IF S$="F" THEN Q$=PROD$ ELSE Q$=S$
                    if (Ss == "F")
                    {
                        Qs = PRODs;
                    }
                    else
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
            //    PSET (X,Y) : P=1 : Q=0
            GW.PSET(X, Y);
            P = 1;
            Q = 0;
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
                        //          P1=-Q : Q1=P
                        P1 = -Q;
                        Q1 = P;
                        //          P=P1 : Q=Q1
                        P = P1;
                        Q = Q1;
                        //       CASE "-"
                        break;
                    case "-":
                        //          P1=Q : Q1=-P
                        P1 = Q;
                        Q1 = -P;
                        //          P=P1 : Q=Q1
                        P = P1;
                        Q = Q1;
                        //       CASE "F"
                        break;
                    case "F":
                        //          X=X+H*P : Y=Y+H*Q
                        X = X + H * P;
                        Y = Y + H * Q;
                        //          LINE -(X,Y)
                        GW.LINE(X, Y);
                        //       END SELECT
                        break;
                    default:
                        break;
                }
                //    NEXT I : A$=INPUT$(1)
            }
            As = GW.INPUTS(1);
            // END
            return;
        }
    }
}
