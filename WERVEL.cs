using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class WERVEL
    {
        public WERVEL()
        {
            float PI = 0;
            float B = 0;
            float A = 0;
            float C = 0;
            int K = 0;
            float T = 0;
            int N = 0;
            int L = 0;
            int M = 0;
            float P;
            float Z = 0;

            // REM ***een draaiende en krimpende veelhoek***
            // REM ***naam:WERVEL***
            //    SCREEN 12 : CLS : PI=4*ATN(1)
            GW.CLS();
            PI = 4 * GW.ATN(1);
            //    WINDOW (-1.6,-1.2)-(1.6,1.2)
            GW.WINDOW(-1.6f, -1.2f, 1.6f, 1.2f);
            //    INPUT "aantal zijden van veelhoek= ",P
            P = GW.INPUT("aantal zijden van veelhoek=  ");
            //    CLS : DIM X(P),Y(P)
            GW.CLS();
            float[] X = new float[(int)P + 1];
            float[] Y = new float[(int)P + 1];
            //    B=.05  'rotatiehoek in radialen
            B = .05f; //  'rotatiehoek in radialen ;
            //    A=PI*(1-2/P) : C=SIN(A)/(SIN(B)+SIN(A+B))
            A = PI * (1 - 2 / P);
            C = GW.SIN(A) / (GW.SIN(B) + GW.SIN(A + B));
            //    FOR K=0 TO P : T=(2*K+1)*PI/P
            for (K = 0; K <= P; K++)
            {
                T = (2 * K + 1) * PI / P;
                //       X(K)=SIN(T) : Y(K)=COS(T)
                X[K] = GW.SIN(T);
                Y[K] = GW.COS(T);
                //    NEXT K
            }
            //    FOR N=1 TO 64  : PSET (X(0),Y(0))
            for (N = 1; N <= 64; N++)
            {
                GW.PSET(X[0], Y[0]);
                //       FOR L=1 TO P : LINE -(X(L),Y(L))
                for (L = 1; L <= P; L++)
                {
                    GW.LINE(X[L], Y[L]);
                    //       NEXT L
                }
                //       FOR M=0 TO P : Z=X(M)
                for (M = 0; M <= P; M++)
                {
                    Z = X[M];
                    //          X(M)=(X(M)*COS(B)-Y(M)*SIN(B))*C
                    X[M] = (X[M] * GW.COS(B) - Y[M] * GW.SIN(B)) * C;
                    //          Y(M)=(Z*SIN(B)+Y(M)*COS(B))*C
                    Y[M] = (Z * GW.SIN(B) + Y[M] * GW.COS(B)) * C;
                    //       NEXT M
                }
                //    NEXT N
            }
            // END
        }
        // 
    }
}
