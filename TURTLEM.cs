using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class TURTLEM
    {
        public TURTLEM()
        {
            float PI = 0;
            float X = 0;
            float Y = 0;
            float H = 0;
            string AXIOMs = "";
            string PRODs = "";
            string WEGs = "";
            int N = 0;
            int NMAX = 0;
            string Ws = "";
            int I = 0;
            string Ss = "";
            string Qs = "";
            float P = 0;
            float P1 = 0;
            float Q = 0;

            float Q1 = 0;
            // REM ***de lijn van Minkowski***
            // REM ***naam:TURTLEM***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-4,-3)-(4,3) : PI=4*GW.ATN(1)
            GW.WINDOW(-4f, -3f, 4f, 3f);
            PI = 4 * GW.ATN(1);
            //    GW.PRINT( "kies de orde als 1,2,3 of 4"
            GW.PRINT("kies de orde als 1,2,3 of 4");
            //    GW.INPUT( "orde = ",NMAX : CLS
            NMAX = (int)GW.INPUT("orde = ");
            GW.CLS();
            //    IF NMAX=0 OR NMAX>4 THEN BEEP : END
            if (NMAX == 0 || NMAX > 4)
            {
                // BEEP;
                return;
            }
            // REM ***beginpositie en staplengte***
            //    X=-3 : Y=0 : H=6/4^NMAX
            X = -3;
            Y = 0;
            H = 6f / (float)Math.Pow(4, NMAX);

            // REM ***axioma en productieregel***
            //    AXIOM$="F"
            AXIOMs = "F";
            //    PROD$="F-F+F+FF-F-F+F"
            PRODs = "F-F+F+FF-F-F+F";
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
            //    P=1 : Q=0
            P = 1;
            Q = 0;
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
                //    NEXT I
            }
            // END
            return;
            // 
        }
    }
}
