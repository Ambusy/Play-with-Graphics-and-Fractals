using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class TURNLINE
    {
        public TURNLINE()
        {
            float A = 0;
            float B = 0;
            float R = 0;
            int N = 0;
            float PI = 0;
            int M = 0;
            int K = 0;
            int L = 0;
            float RK = 0;
            float T1 = 0;
            float T2 = 0;
            float X0 = 0;
            float Y0 = 0;
            float X1 = 0;
            float Y1 = 0;
            // REM ***patroon gevormd door een draaiende lijn***
            // REM ***naam:TURNLINE***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-2,-1.5)-(2,1.5)
            GW.WINDOW(-2f, -1.5f, 1.5f, 1.5f);
            //    A=.4 : B=6 : R=.6 : N=256
            A = .4f;
            B = 6;
            R = .6f;
            N = 256;
            //    PI=4*ATN(1) : M=3
            PI = 4 * GW.ATN(1);
            M = 3;
            //    FOR K=0 TO M-1
            for (K = 0; K <= M - 1; K++)
            {
                //       FOR L=0 TO N-1
                for (L = 0; L <= N - 1; L++)
                {
                    //          RK=R^K : T1=2*L*PI/N : T2=B*L*PI/N
                    RK = (float)Math.Pow(R,K);
                    T1 = 2 * L * PI / N;
                    T2 = B * L * PI / N;
                    //          X0=RK*COS(T1) : Y0=RK*SIN(T1)
                    X0 = RK * GW.COS(T1);
                    Y0 = RK * GW.SIN(T1);
                    //          X1=A*RK*COS(T2) : Y1=A*RK*SIN(T2)
                    X1 = A * RK * GW.COS(T2);
                    Y1 = A * RK * GW.SIN(T2);
                    //          LINE (X0-X1,Y0-Y1)-(X0+X1,Y0+Y1)
                    GW.LINE(X0 - X1, Y0 - Y1,X0 + X1, Y0 + Y1);
                    //       NEXT L
                }
                //    NEXT K
            }
            // END
        }
        // 
    }
}
