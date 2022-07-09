using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class CYCLO1
    {
        public CYCLO1()
        {
            float PI = 0;
            float EPS = 0;
            int K = 0;
            int L = 0;
            float A = 0;
            int N = 0;
            int J = 0;
            float T = 0;
            float A1 = 0;
            float B1 = 0;
            float A2 = 0;
            float B2 = 0;
            float P = 0;
            float Q = 0;
            float R = 0;
            int S = 0;
            // REM ***cycloidale kromme***
            // REM ***naam:CYCLO1***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    PI=4*ATN(1) : EPS=.0001
            PI = 4 * GW.ATN(1);
            EPS = .0001f;
            //    WINDOW (-1.6,-1.2)-(1.6,1.2)
            GW.WINDOW(-1.6f, -1.2f, 1.2f, 1.2f);
            //       K=1 : L=3 : A=.8 : N=80
            K = 1;
            L = 3;
            A = .8f;
            N = 80;
            float[] U = new float[N+1];
            float[] V = new float[N+1];
            //    LINE (-1,-1)-(1,1),,B
            GW.LINE(-1, -1 , 1, 1 ,"B");
            //    FOR J=0 TO N : T=2*PI*L*J/N
            for (J = 0; J <= N; J++)
            {
                T = 2 * PI * L * J / N;
                //       A1=COS(T) : B1=SIN(T)
                A1 = GW.COS(T);
                B1 = GW.SIN(T);
                //       A2=COS(K*T/L) : B2=SIN(K*T/L+EPS)
                A2 = GW.COS(K * T / L);
                B2 =GW.SIN(K * T / L + EPS);
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
                //    NEXT J
            }
            // END
        }
        // 
    }
}

