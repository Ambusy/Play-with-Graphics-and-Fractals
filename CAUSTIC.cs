using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class CAUSTIC
    {
        public CAUSTIC()
        {
            int N = 0;
            int J = 0;
            float S = 0;
            int K = 0;
            float B = 0;
            float A = 0;
            float C = 0;
            float U1 = 0;
            float U2 = 0;
            float V = 0;
            float T = 0;
            // REM ***brandkromme gevormd door een holle spiegel***
            // REM ***naam:CAUSTIC***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    VIEW SCREEN (0,80)-(639,400)
            //    WINDOW (-2.5,-1.5)-(1.5,1.5)
            GW.WINDOW(-2.5f, -1.5f, 1.5f, 1.5f);
            //    N=20  'aantal stralen
            N = 20;// 'aantal stralen ;
                   // REM ***spiegel***
                   //    PSET (COS(.78),-SIN(.78))
            GW.PSET(GW.COS(.78f), -GW.SIN(.78f));
            //    FOR J=-50 TO 50 : S=.78*J/50
            for (J = -50; J <= 50; J++)
            {
                S = .78f * J / 50;
                //       LINE -(COS(S),SIN(S))
                GW.LINE(GW.COS(S), GW.SIN(S));
                //    NEXT J
            }
            //    FOR K=1 TO N
            for (K = 1; K <= N; K++)
            {
                //        B=(2*K-N-1)*.695/(N-1)
                B = (2 * K - N - 1) * .695f / (N - 1);
                //        A=SQR(1-B*B) : C=2*A*B /(1-2*B*B)
                A = GW.SQR(1 - B * B);
                C = 2 * A * B / (1 - 2 * B * B);
                //        U1=A-(B-1.5)/C : U2=A-(B+1.5)/C : V=B-(A+2)*C
                U1 = A - (B - 1.5f) / C;
                U2 = A - (B + 1.5f) / C;
                V = B - (A + 2) * C;
                //        LINE (-2,B)-(A,B),14 'ingaande straal
                GW.LINE(-2, B, A, B, 14);// 'ingaande straal );
                                         // REM ***spiegeling***
                                         //        IF V>1.5 THEN
                if (V > 1.5)
                {
                    //           LINE -(U1,1.5),14
                    GW.LINE(U1, 1.5f, 14);
                    //        ELSEIF V<-1.5 THEN
                }
                else if (V < -1.5)
                {
                    //           LINE -(U2,-1.5),14
                    GW.LINE(U2, -1.5f, 14);
                    //        ELSE
                }
                else
                {
                    //           LINE -(-2,V),14
                    GW.LINE(-2, V, 14);
                    //        END IF
                }
                //        T=TIMER : DO : LOOP WHILE TIMER-T<1
                T = GW.TIMER();
                while (GW.TIMER() - T < 1)
                {

                }
            }
            //    NEXT K : BEEP
        }
        // END
    }
}
// 
    