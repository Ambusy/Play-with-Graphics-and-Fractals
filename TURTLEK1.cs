using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class TURTLEK1
    {
        public TURTLEK1()
        {
            int NMAX = 0;
            float PI = 0;
            float X = 0;
            float Y = 0;
            float PHI = 0;
            float H = 0;
            string AXIOMs = "";
            string PRODs = "";
            string WEGs = "";
            int N = 0;
            string Ws = "";
            string Ss = "";
            int I = 0;
            string Qs = "";
            // REM ***kwadratische variant van de Koch lijn***
            // REM ***naam:TURTLEK1***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-.6,-.3)-(.6,.6)
            GW.WINDOW(-.6f, -.3f, .6f, .6f);
            //    NMAX=4 : PI=4*ATN(1)
            NMAX = 4;
            PI = 4 * GW.ATN(1);
            // REM ***beginpositie en staplengte***
            //    X=-.5 : Y=0 : PHI=0 : H=.0125
            X = -.5f;
            Y = 0;
            PHI = 0;
            H = .0125f;
            // REM ***axioma en productieregel***
            //    AXIOM$="F"
            AXIOMs = "F";
            //    PROD$="F+F-F-F+F"
            PRODs = "F+F-F-F+F";
            // REM ***vorming van woord***
            //    WEG$=AXIOM$
            WEGs = AXIOMs;
            //    FOR N=1 TO NMAX
            for (N = 1; N <= NMAX; N++)
            {
                //       W$=""
                Ws = "";
                //       FOR I=1 TO LEN(WEG$)
                for (I = 1; I <= GW.LEN(WEGs); I++)
                {
                    //          S$=MID$(WEG$,I,1)
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
            //    PSET (X,Y)
            GW.PSET(X, Y);
            //    FOR I=1 TO LEN(WEG$)
            for (I = 1; I <= GW.LEN(WEGs); I++)
            {
                //       S$=MID$(WEG$,I,1)
                Ss = GW.MID(WEGs, I, 1);
                //       SELECT CASE S$
                switch (Ss)
                {
                    //       CASE "+"
                    case "+":
                        //          PHI=PHI+PI/2
                        PHI = PHI + PI / 2F;
                        //       CASE "-"
                        break;
                    case "-":
                        //          PHI=PHI-PI/2
                        PHI = PHI - PI / 2F;
                        //       CASE "F"
                        break;
                    case "F":
                        //          X=X+H*COS(PHI) : Y=Y+H*SIN(PHI)
                        X = X + H * GW.COS(PHI);
                        Y = Y + H * GW.SIN(PHI);
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
            ;
        }
    }
}