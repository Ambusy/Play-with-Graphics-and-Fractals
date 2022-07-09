using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Graphics_boek
{
    class CYCLO2
    {
        public CYCLO2()
        {
            float PI = 0;
            int N = 0;
            int J = 0;
            int K = 0;
            int L = 0;
            float A = 0;
            int I = 0;
            float T = 0;
            float A1 = 0;
            float B1 = 0;
            float A2 = 0;
            float B2 = 0;
            float P = 0;
            float Q = 0;
            float R = 0;
            int S = 0;
            // REM ***cycloidale  krommen***
            // REM ***naam:CYCLO2***
            //    SCREEN 12 : CLS : PI=4*ATN(1)
            GW.CLS();
            PI = 4 * GW.ATN(1);
            //    N=100  'aantal lijnen
            N = 100; // 'aantal lijnen ;
            float[] U = new float[10];
            float[] V = new float[10];
            //    FOR J=1 TO 3
            for (J = 1; J <= 3; J++)
            {
                //       VIEW (120,40)-(520,440),1,15
                GW.CLS(); // view clears screen?????
                //       WINDOW (-1,-1)-(1,1)
                GW.WINDOW(-1, -1, 1, 1);
                //       SELECT CASE J
                switch (J)
                {
                    //       CASE 1
                    case 1:
                        //          K=1 : L=2 : A=1
                        K = 1;
                        L = 2;
                        A = 1;
                        //       CASE 2
                        break;
                    case 2:
                        //          K=-1 : L=2 : A=.25
                        K = -1;
                        L = 2;
                        A = .25f;
                        //       CASE 3
                        break;
                    case 3:
                        //          K=1 : L=3 : A=.8
                        K = 1;
                        L = 3;
                        A = .8f;
                        //       END SELECT
                        break;
                    default:
                        break;
                }
                // REM ***graphics***
                //    FOR I=1 TO N : T=2*PI*L*I/N
                for (I = 1; I <= N; I++)
                {
                    T = 2 * PI * L * I / N;
                    //       A1=COS(T) : B1=SIN(T)
                    A1 = GW.COS(T);
                    B1 = GW.SIN(T);
                    //       A2=COS(K*T/L+.001) : B2=SIN(K*T/L+.001)
                    A2 = GW.COS(K * T / L + .001F);
                    B2 = GW.SIN(K * T / L + .001F);
                    //       P=B1-B2 : Q=A1-A2 : R=(A1*B2-A2*B1)*A  : S=1
                    P = B1 - B2;
                    Q = A1 - A2;
                    R = (A1 * B2 - A2 * B1) * A;
                    S = 1;
                    //       IF ABS(Q-R)<=ABS(P) THEN U[S]=(Q-R)/P : V[S]=-1 : S=S+1
                    if (GW.ABS(Q - R) <= GW.ABS(P))
                    {
                        U[S] = (Q - R) / P;
                        V[S] = -1;
                        S = S + 1;
                    }
                    //       IF ABS(Q+R)<=ABS(P) THEN U[S]=-(Q+R)/P : V[S]=1 : S=S+1
                    if (GW.ABS(Q + R) <= GW.ABS(P))
                    {
                        U[S] = -(Q + R) / P;
                        V[S] = 1;
                        S = S + 1;
                    }
                    //       IF ABS(P-R)<ABS(Q) THEN U[S]=-1 : V[S]=(P-R)/Q : S=S+1
                    if (GW.ABS(P - R) < GW.ABS(Q))
                    {
                        U[S] = -1;
                        V[S] = (P - R) / Q;
                        S = S + 1;
                    }
                    //       IF ABS(P+R)<ABS(Q) THEN U[S]=1 : V[S]=-(P+R)/Q : S=S+1
                    if (GW.ABS(P + R) < GW.ABS(Q))
                    {
                        U[S] = 1;
                        V[S] = -(P + R) / Q;
                        S = S + 1;
                    }
                    //       LINE (U(1),V(1))-(U(2),V(2))
                    GW.LINE(U[1], V[1], U[2], V[2]);
                    //    NEXT I : GOSUB wacht
                }
                wacht();
                //    NEXT J : BEEP
            }
            // END
            void wacht()
            {
                int A = GW.TIMER();
                while (GW.TIMER() - A < 3)
                {
                    Thread.Sleep(10);
                }
                return;
            }
        }
    }
}
