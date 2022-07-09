using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class KANT
    {
        public KANT()
        {
            float PI = 0;
            int N = 0;

            // REM ***regelmatige veelhoek met alle diagonalen***
            // REM ***naam:KANT***
            //    SCREEN 12 : CLS : PI=4*ATN(1)
            GW.CLS();
            PI = 4 * GW.ATN(1);
            //    WINDOW (-1.6,-1.2)-(1.6,1.2)
            GW.WINDOW(-2.2f, -1.2f, 2.2f, 1.2f);
            //    N=17 : DIM X(N),Y(N)  'aantal zijden
            N = 17;
            float[] X = new float[N+1];
            float[] Y = new float[N+1];
            //    FOR K=1 TO N
            for (int K = 1; K <= N; K++)
            {
                //       X(K)=COS(2*K*PI/N)
                X[K] = GW.COS(2 * K * PI / N);
                //       Y(K)=SIN(2*K*PI/N)
                Y[K] = GW.SIN(2 * K * PI / N);
                //    NEXT K
            }
            //    FOR I=1 TO N
            for (int I = 1; I <= N; I++)
            {
                //       FOR J=1 TO I-1
                for (int J = 1; J <= I - 1; J++)
                {
                    //          LINE (X(I),Y(I))-(X(J),Y(J))
                    GW.LINE(X[I], Y[I], X[J], Y[J]);
                    //       NEXT J
                }
                //    NEXT I
            }
            // END
        }
        // 
    }
}

