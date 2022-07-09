using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class TURTLEK3
    {
        public TURTLEK3()
        {
            int NMAX = 0;
            float PI = 0;
            float A = 0;
            float B = 0;
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
            float P1 = 0;
            float Q = 0;

            float Q1 = 0;
            // REM ***eiland van Von Koch als een tegel***
            // REM ***naam:TURTLEK3***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-2.4,-1.8)-(2.4,1.8)
            GW.WINDOW(-2.4f, -1.8f, 2.4f, 1.8f);
            //    NMAX=4 : PI=4*GW.ATN(1)
            NMAX = 4;
            PI = 4 * GW.ATN(1);
            // REM ***beginpositie en staplengte***
            //    A=2/SQR(5) : B=1/SQR(5)
            A = 2 / GW.SQR(5);
            B = 1 / GW.SQR(5);
            //    X=-1 : Y=1 : H=2*B^NMAX
            X = -1;
            Y = 1;
            H = 2f * (float)Math.Pow(B, NMAX);

            // REM ***axioma en productieregel***
            //    AXIOM$="FRFRFRF"
            AXIOMs = "FRFRFRF";
            //    PROD$="-FLFRF+"
            PRODs = "-FLFRF+";
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
            //    A=2/SQR(5) : B=1/SQR(5)
            A = 2 / GW.SQR(5);
            B = 1 / GW.SQR(5);
            //    P=1 : Q=0
            P = 1;
            Q = 0;
            //    PSET (X,Y),4
            GW.PSET(X, Y,4);
            //    FOR I=1 TO GW.LEN(WEG$)
            for (I = 1; I <= GW.LEN(WEGs); I++)
            {
                //       S$=GW.MID(WEG$,I,1)
                Ss = GW.MID(WEGs, I, 1);
                //       SELECT CASE S$
                switch (Ss)
                {
                    //       CASE "L"
                    case "L":
                        //          P1=-Q : Q1=P
                        P1 = -Q;
                        Q1 = P;
                        //          P=P1 : Q=Q1
                        P = P1;
                        Q = Q1;
                        //       CASE "R"
                        break;
                    case "R":
                        //          P1=Q : Q1=-P
                        P1 = Q;
                        Q1 = -P;
                        //          P=P1 : Q=Q1
                        P = P1;
                        Q = Q1;
                        //       CASE "+"
                        break;
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
                        //          LINE -(X,Y),4
                        GW.LINE(X, Y, 4);
                        //       END SELECT
                        break;
                    default:
                        break;
                }
                //    NEXT I
            }
            //    PAINT (0,0),4
            GW.PAINT(0, 0,4);
            //    LINE (-1,-1)-(1,1),14,B
            GW.LINE(-1, -1, 1, 1, 14, "B");
            // END
            return;
            // 
            ;
        }
    }
}
