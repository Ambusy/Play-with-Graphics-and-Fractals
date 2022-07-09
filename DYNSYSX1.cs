using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class DYNSYSX1
    {
        public DYNSYSX1()
        {
            float PI = 0;
            float A = 0;
            float B = 0;
            int J = 0;
            float X = 0;
            float Y = 0;
            int K = 0;
            float Z = 0;
            // REM ***dynamisch systeem volgens Peitgen, explosie***
            // REM ***x'=2x-y-af(x), y'=x met***
            // REM ***f(x)=x voor x<=0 ***
            // REM ***f(x)=(pi-b)*x/b voor x>0 en x<b ***
            // REM ***f(x)=pi-b voor x>=b ***
            // REM ***naam:DYNSYSX1***
            //    SCREEN 12 : CLS : PI=4*ATN(1)
            GW.CLS();
            PI = 4 * GW.ATN(1);
            //    DIM X(4),P(4),COL(4)
            float[] XA = new float[4 + 1];
            float[] P = new float[4 + 1];
            int[] COL = new int[4 + 1];
            //    WINDOW (-1.4,-1.2)-(.6,.6)
            GW.WINDOW(-1.4f, -1.2f, .6f, .6f);
            // REM ***data***
            //    A=.37 : B=.4
            A = .37f;
            B = .4f;
            //    X(1)=.05 : P(1)=3000 : X(2)=.1 : P(2)=8000
            XA[1] = .05f;
            P[1] = 3000;
            XA[2] = .1f;
            P[2] = 8000;
            //    X(3)=.16 : P(3)=10000 : X(4)=.21 : P(4)=12000
            XA[3] = .16f;
            P[3] = 10000;
            XA[4] = .21f;
            P[4] = 12000;
            //    COL(1)=9 : COL(2)=10 : COL(3)=12 : COL(4)=14
            COL[1] = 9;
            COL[2] = 10;
            COL[3] = 12;
            COL[4] = 14;
            // REM ***vier banen***
            //    FOR J=1 TO 4
            for (J = 1; J <= 4; J++)
            {
                //       X=X(J) : Y=X
                X = XA[J];
                Y = X;
                //       FOR K=0 TO P(J)
                for (K = 0; K <= P[J]; K++)
                {
                    //          Z=X : X=2*X-Y-A*FNS(X) : Y=Z
                    Z = X;
                    X = 2 * X - Y - A * FNS(X);
                    Y = Z;
                    //          PSET (X,Y),COL(J)
                    GW.PSET(X, Y, COL[J]);
                    //          IF INKEY$<>"" THEN END
                    if (GW.INKEY() != "")
                    {
                        return;
                    }
                    //       NEXT K
                }
                //    NEXT J : BEEP
            }
            // END
            return;
            // 
            float FNS(float X)
            {
                //    IF X<=0 THEN FNS=X
                if (X <= 0)
                {
                    return X;
                }
                //    IF X>0 AND X<B THEN FNS=(PI/B-1)*X
                if (X > 0 && X < B)
                {
                    return (PI / B - 1) * X;
                }
                //    IF X>=B THEN FNS=PI-X
                if (X >= B)
                {
                    return PI - X;
                }
                return 0;
                // END DEF
            }
        }
    }
}
