using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class TURTLEK
    {
        public TURTLEK()
        {
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
            float A = 0;
            float B = 0;
            float P = 0;
            float Q = 0;
            float P1 = 0;
            float Q1 = 0;
            string As = "";
            // REM ***de lijn van Von Koch***
            // REM ***naam:TURTLEK***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-4,-3)-(4,3)
            GW.WINDOW(-4f, -3f, 4f, 3f);
            // herhaal:
            do
            {
                //    CLS : GW.INPUT "ordegetal (keuze uit 0,1,...,8) = ",NMAX
                GW.CLS();
                int NMAX = Math.Min(8, Math.Max(0, (int)GW.INPUT("ordegetal (keuze uit 0,1,...,5) = ")));
                //    PI=4*ATN(1) : CLS
                PI = 4 * GW.ATN(1);
                GW.CLS();
                // REM ***beginpositie en staplengte***
                //    X=-3 : Y=-.5 : H=6/3^NMAX
                X = -3;
                Y = -.5F;
                H = 6f / (float)Math.Pow (3 , NMAX);
                // REM ***axioma en productieregel***
                //    AXIOM$="F"
                AXIOMs = "F";
                //    PROD$="F+F--F+F"
                PRODs = "F+F--F+F";
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
                //    A=COS(PI/3) : B=SIN(PI/3)
                A = GW.COS(PI / 3);
                B = GW.SIN(PI / 3);
                //    P=1 : Q=0 : PSET (X,Y)
                P = 1;
                Q = 0;
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
                            //          P1=A*P-B*Q : Q1=B*P+A*Q
                            P1 = A * P - B * Q;
                            Q1 = B * P + A * Q;
                            //          P=P1 : Q=Q1
                            P = P1;
                            Q = Q1;
                            //       CASE "-"
                            break;
                        case "-":
                            //          P1=A*P+B*Q : Q1=-B*P+A*Q
                            P1 = A * P + B * Q;
                            Q1 = -B * P + A * Q;
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
                //    LOCATE 1,1 : GW.PRINT "toets R voor herhaling programma"
                GW.LOCATE(1, 1);
                GW.PRINT("toets R voor herhaling programma");
                //    A$=INPUT$(1)
                As = GW.INPUTS(1);
                //    IF A$="r" OR A$="R" THEN GOTO herhaal
            } while (As == "r" || As == "R");

            // END
            return;
            // 
            ;
        }
    }
}
