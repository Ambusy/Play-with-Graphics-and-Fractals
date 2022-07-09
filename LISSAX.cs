using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Graphics_boek
{
    class LISSAX
    {
        float PI = 0;
        float H = 0;
        float AMPL1 = 0;
        float AMPL2 = 0;
        int M = 0;
        int N = 0;
        float FASE = 0;
        float FREQ = 0;
        float T = 0;
        float X = 0;
        float Y = 0;
        float A = 0;
        public LISSAX()
        {
            // REM ***figuur van Lissajous***
            // REM ***naam:LISSAX***
            //    SCREEN 12 : CLS : PI=4*ATN(1)
            GW.CLS();
            PI = 4 * GW.ATN(1);
            //    WINDOW (-2.4,-1.8)-(2.4,1.8)
            GW.WINDOW(-2.4F, -1.8F, 1.8F, 1.8F);
            //    H=PI/400 : AMPL1=1.6 : AMPL2=1.2
            H = PI / 400f;
            AMPL1 = 1.6F;
            AMPL2 = 1.2F;
            //    FOR J=1 TO 3
            for (int J = 1; J <= 3; J++)
            {
                //       SELECT CASE J
                switch (J)
                {
                    //          CASE 1
                    case 1:
                        //             M=3 : N=4 : FASE=0
                        M = 3;
                        N = 4;
                        FASE = 0;
                        //          CASE 2
                        break;
                    case 2:
                        //             M=8 : N=13 : FASE=.5
                        M = 8;
                        N = 13;
                        FASE = .5F;
                        //          CASE 3
                        break;
                    case 3:
                        //             M=34 : N=55 : FASE=.25
                        M = 34;
                        N = 55;
                        FASE = .25F;
                        //          END SELECT
                        break;
                    default:
                        break;
                }
                //       FREQ=M/N : FASE=FASE*2*PI
                FREQ = M / (float)N;
                FASE = FASE * 2 * PI;
                //       LOCATE 2,15 : PRINT "M = ";M
                GW.LOCATE(2, 1);
                GW.PRINT("M = " + M);
                //       LOCATE 2,30 : PRINT "N = ";N
                GW.LOCATE(2, 30);
                GW.PRINT("N = " + N);
                //       LINE (-1.1*AMPL1,-1.1*AMPL2)-(1.1*AMPL1,1.1*AMPL2),,B
                GW.LINE(-1.1F * AMPL1, -1.1F * AMPL2, 1.1F * AMPL1, 1.1F * AMPL2, "B");
                //       PSET (0,AMPL2*SIN(FASE))
                GW.PSET(0, AMPL2 * GW.SIN(FASE));
                //       FOR K=0 TO 800*N : T=K*H
                for (int K = 0; K <= 800 * N; K++)
                {
                    T = K * H;
                    //          X=AMPL1*SIN(FREQ*T) : Y=AMPL2*SIN(T+FASE)
                    X = AMPL1 * GW.SIN(FREQ * T);
                    Y = AMPL2 * GW.SIN(T + FASE);
                    //          LINE -(X,Y)
                    GW.LINE(X, Y);
                    //       NEXT K : GOSUB wacht
                }
                wacht();
                //       IF J<3 THEN CLS
                if (J < 3)
                    GW.CLS();
                //    NEXT J
            }
            //    LOCATE 2,45 : PRINT "einde programma"
            GW.LOCATE(2, 45);
            GW.PRINT("einde programma");
            // END
            void wacht()
            {
                A = GW.TIMER();
                while (GW.TIMER() - A < 3)
                {
                    Thread.Sleep(10);
                }
                return;
            }
        }
    }
}

