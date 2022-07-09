using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class MANDELX2
    {
        public MANDELX2()
        {
            float PI = 0;
            int I = 0;
            float DELH = 0;
            float DELV = 0;
            int N1 = 0;
            int N2 = 0;
            int J = 0;
            float A = 0;
            float B = 0;
            float X = 0;
            float Y = 0;
            int K = 0;
            int L = 0;
            float U = 0;
            float V = 0;
            float CH = 0;
            float SH = 0;
            float SS = 0;
            float CS = 0;
            float X1 = 0;
            float Y1 = 0;

            string As = "";
            // REM ***Mandelbrot set van c+pi*GW.SIN(z) ***
            // REM ***naam:MANDELX2***
            //    DEFDBL A-Z
            //    SCREEN 12 : CLS : PI=4*GW.ATN(1)
            GW.CLS();
            PI = 4 * GW.ATN(1);
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            // REM ***kleuren***
            //    DIM COL(8) : DATA 0,1,9,2,10,4,12,14,6
            int[] COL = new int[] { 0, 1, 9, 2, 10, 4, 12, 14, 6 };
            //    FOR I=0 TO 8 : READ COL(I) : NEXT I
            //    DELH=PI : DELV=.75*PI  'grootte Mset
            DELH = PI;
            DELV = .75f * PI;//  'grootte Mset ;
                             //    N1=240 : N2=INT(N1*DELV/DELH)
            N1 = 240;
            N2 = (int)(N1 * DELV / DELH);
            //    FOR I=0 TO N1 : FOR J=0 TO N2
            for (I = 0; I <= N1; I++)
            {
                for (J = 0; J <= N2; J++)
                {
                    //       IF GW.INKEY()<>"" THEN END
                    if (GW.INKEY() != "")
                    {
                        return;
                    }
                    //       A=DELH*I/N1 : B=DELV*J/N2
                    A = DELH * I / (float)N1;
                    B = DELV * J / (float)N2;
                    //       X=PI/2 : Y=0
                    X = PI / 2f;
                    Y = 0;
                    //       FOR K=1 TO 64
                    bool left = false;
                    for (K = 1; K <= 64 && !left; K++)
                    {
                        //          IF ABS(Y)>12 THEN L=1+K MOD 8 : GOTO graphics
                        if (GW.ABS(Y) > 12)
                        {
                            L = 1 + K % 8;
                            // GOTO graphics;
                            left = true;
                        }
                        if (!left)
                        {

                            //          U=EXP(Y) : V=1/U : CH=(U+V)/2 : SH=(U-V)/2
                            U = GW.EXP(Y);
                            V = 1 / U;
                            CH = (U + V) / 2f;
                            SH = (U - V) / 2f;
                            //          SS=GW.SIN(X) : CS=GW.COS(X)
                            SS = GW.SIN(X);
                            CS = GW.COS(X);
                            //          X1=A+PI*SS*CH : Y1=B+PI*CS*SH
                            X1 = A + PI * SS * CH;
                            Y1 = B + PI * CS * SH;
                            //          DIST=ABS(X-X1)+ABS(Y-Y1)
                            float DIST = GW.ABS(X - X1) + GW.ABS(Y - Y1);
                            //          IF DIST<.001 THEN L=3 : GOTO graphics
                            if (DIST < .001)
                            {
                                L = 3;
                                //GOTO graphics;
                                left = true;
                            }
                        }
                        if (!left)
                        {
                            //          X=X1 : Y=Y1
                            X = X1;
                            Y = Y1;
                            //       NEXT K : L=3
                        }
                    }
                    if (!left)
                    {
                        L = 3;
                    }
                    // graphics:
                    //       PSET (I,J),COL(L) : PSET (I,-J),COL(L)
                    GW.PSETe(I, J, COL[L]);
                    GW.PSETe(I, -J, COL[L]);
                    //       PSET (-I,J),COL(L) : PSET (-I,-J),COL(L)
                    GW.PSETe(-I, J, COL[L]);
                    GW.PSETe(-I, -J, COL[L]);
                    //    NEXT J : NEXT I : A$=INPUT$(1)
                }
            }
            //As = GW.INPUTS(1);
            // END
            return;
            // 
            ;
        }
    }
}
