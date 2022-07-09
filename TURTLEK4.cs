using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class TURTLEK4
    {
        public TURTLEK4()
        {
            int NMAX = 0;
            float A = 0;
            float B = 0;
            float H = 0;
            string AXIOMs = "";
            string PRODs = "";
            string WEGs = "";
            int N = 0;
            string Ws = "";
            int I = 0;
            string Ss = "";
            string Qs = "";
            int IH = 0;
            int IV = 0;
            int COL = 0;
            float X = 0;
            float Y = 0;
            float P1 = 0;
            float P = 0;
            float Q = 0;

            float Q1 = 0;
            // REM ***een wand van fractale tegels***
            // REM ***naam:TURTLEK4***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-22,-20)-(26,16)
            GW.WINDOW(-22f, -20f, 26f, 16f);
            //    NMAX=4 : RANDOMIZE TIMER
            NMAX = 4;
            GW.RANDOMIZE(GW.TIMER());
            //    A=2/GW.SQR(5) : B=1/GW.SQR(5) : H=4*B^NMAX
            A = 2 / GW.SQR(5);
            B = 1 / GW.SQR(5);
            H = 4f * (float)Math.Pow(B, NMAX);

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
            // FOR IH=-4 TO 4 : FOR IV=-3 TO 3
            for (IH = -4; IH <= 4; IH++)
            {
                for (IV = -3; IV <= 3; IV++)
                {
                    //    COL=1+INT(RND*14)
                    COL = 2 + (int)(GW.RND() * 13); // exclude back and blue
                    //    X=4*IH : Y=4*IV
                    X = 4 * IH;
                    Y = 4 * IV;
                    //    GOSUB graphics
                    graphics();
                    //    PAINT (4*IH+1,4*IV-1),COL
                    GW.PAINT(4 * IH + 1, 4 * IV - 1, COL);
                    // NEXT IV : NEXT IH
                }
            }
            // END
            return;
            // graphics:
            void graphics()
            {
                //    P=1 : Q=0
                P = 1;
                Q = 0;
                //    PSET (X,Y),COL
                GW.PSET(X, Y, COL);
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
                            //          LINE -(X,Y),COL
                            GW.LINE(X, Y, 1);// COL); blue
                            //       END SELECT
                            break;
                        default:
                            break;
                    }
                    //    NEXT I
                }
                // RETURN
                // 
                ;
            }
        }
    }
        }
