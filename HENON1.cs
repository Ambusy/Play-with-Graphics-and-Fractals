using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class HENON1
    {
        public HENON1()
        {
            float A = 0;
            float B = 0;
            int M = 0;
            int N = 0;
            float X = 0;
            float Y = 0;
            int COL = 0;

            float Z = 0;
            // REM ***Henon's kwadratisch systeem***
            // REM ***een aantal toevallig gekozen banen***
            // REM ***naam:HENON1***
            //    SCREEN 12 : CLS : RANDOMIZE 11
            GW.CLS();
            GW.RANDOMIZE(11);
            //    WINDOW (-1.6,-1.2)-(1.6,1.2)
            GW.WINDOW(-1.6f, -1.2f, 1.6f, 1.2f);
            //    A=.24 : B=SQR(1-A*A) : M=0
            A = .24f;
            B = GW.SQR(1 - A * A);
            M = 0;
            //    DO WHILE INKEY$="" AND M<100
            while (GW.INKEY() == "" && M < 100)
            {
                //       X=-1+2*RND : Y=-1+2*RND : COL=1+INT(15*RND)
                X = -1 + 2 * GW.RND();
                Y = -1 + 2 * GW.RND();
                COL = 1 + (int)(15 * GW.RND());
                //       FOR N=1 TO 1000
                for (N = 1; N <= 1000; N++)
                {
                    //          IF ABS(X)<1 AND ABS(Y)<1 THEN PSET (X,Y),COL
                    if (GW.ABS(X) < 1 && GW.ABS(Y) < 1)
                    {
                        GW.PSET(X, Y, COL);
                    }
                    //          Z=X : X=X*A-(Y-X*X)*B
                    Z = X;
                    X = X * A - (Y - X * X) * B;
                    //          Y=Z*B+(Y-Z*Z)*A
                    Y = Z * B + (Y - Z * Z) * A;
                    //          IF ABS(X)+ABS(Y)>10 THEN EXIT FOR
                    if (GW.ABS(X) + GW.ABS(Y) > 10)
                    {
                    }
                    //       NEXT N
                }
                //       M=M+1
                M = M + 1;
                //    LOOP : BEEP
            }
            // END
            GW.LOCATE(1, 1);GW.PRINT("gereed");
            return;
            // 
        }
    }
}
