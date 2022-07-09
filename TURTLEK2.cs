using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class TURTLEK2
    {
        public TURTLEK2()
        {
            int NMAX = 0;
            float PI = 0;
            float H = 0;
            float X = 0;
            float Y = 0;
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
            int J = 0;
            float P = 0;
            float P1 = 0;
            float Q = 0;

            float Q1 = 0;
            // REM ***sneeuwvlok, eilanden van Von Koch***
            // REM ***naam:TURTLEK2***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-2.4,-1.8)-(2.4,1.8)
            GW.WINDOW(-2.4f, -1.8f, 2.4f, 1.8f);
            //    NMAX=4 : PI=4*GW.ATN(1)
            NMAX = 4;
            PI = 4 * GW.ATN(1);
            // REM ***beginpositie en staplengte***
            //    H=2/3^NMAX : X=-1 : Y=-SQR(3)
            H = 2f / (float)Math.Pow(3, NMAX);
            X = -1;
            Y = -GW.SQR(3);
            // REM ***axioma en productieregel***
            //    AXIOM$="F+F+F+F+F+F"
            AXIOMs = "F+F+F+F+F+F";
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
            //    A=GW.COS(PI/3) : B=GW.SIN(PI/3)
            A = GW.COS(PI / 3f);
            B = GW.SIN(PI / 3f);
            //    FOR J=0 TO 4 : H=.7*H : X=.7*X : Y=.7*Y
            for (J = 0; J <= 4; J++)
            {
                H = .7f * H;
                X = .7f * X;
                Y = .7f * Y;
                //       P=1 : Q=0 : PSET (X,Y)
                P = 1;
                Q = 0;
                GW.PSET(X, Y);
                //       FOR I=1 TO GW.LEN(WEG$)
                for (I = 1; I <= GW.LEN(WEGs); I++)
                {
                    //          S$=GW.MID(WEG$,I,1)
                    Ss = GW.MID(WEGs, I, 1);
                    //          SELECT CASE S$
                    switch (Ss)
                    {
                        //          CASE "+"
                        case "+":
                            //             P1=A*P-B*Q : Q1=B*P+A*Q
                            P1 = A * P - B * Q;
                            Q1 = B * P + A * Q;
                            //             P=P1 : Q=Q1
                            P = P1;
                            Q = Q1;
                            //          CASE "-"
                            break;
                        case "-":
                            //             P1=A*P+B*Q : Q1=-B*P+A*Q
                            P1 = A * P + B * Q;
                            Q1 = -B * P + A * Q;
                            //             P=P1 : Q=Q1
                            P = P1;
                            Q = Q1;
                            //          CASE "F"
                            break;
                        case "F":
                            //             X=X+H*P : Y=Y+H*Q
                            X = X + H * P;
                            Y = Y + H * Q;
                            //             LINE -(X,Y)
                            GW.LINE(X, Y);
                            //          END SELECT
                            break;
                        default:
                            break;
                    }
                    //       NEXT I
                }
                //    NEXT J
            }
            // END
            return;
            // 
        }
    }
}
