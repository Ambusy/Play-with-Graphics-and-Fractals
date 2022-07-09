using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class STERPQ
    {
        public STERPQ() {
            float PI = 0;
            int K = 0,I=0,J=0;
            int N = 0;
            float P=0, Q=0;
            // REM ***sterveelhoek met enkele diagonalen***
            // REM ***naam:STERPQ***
            //    SCREEN 12 : CLS : PI=4*ATN(1)
            GW.CLS();
            PI = 4 * GW.ATN(1);
            //    DIM X(100),Y(100)
            float[] X = new float[100 + 1];
            float[] Y = new float[100 + 1];
            //    WINDOW (-1.6,-1.2)-(1.6,1.2)
            GW.WINDOW(-2.2f, -1.2f, 2.2f, 1.2f);
            // REM ***input data***
            //    PRINT "kies aantal zijden n, neem n<100"
            GW.PRINT("kies aantal zijden n, neem n<100");
            //    PRINT "een goede keuze is 33"
            GW.PRINT("een goede keuze is 33");
            //    INPUT"aantal zijden = ",N : CLS
            N=(int)GW.INPUT("aantal zijden =  ");
            GW.CLS();
            //    PRINT "alle diagonalen orde p tot aan q worden afgebeeld"
            GW.PRINT("alle diagonalen orde p tot aan q worden afgebeeld");
            //    PRINT "orde 1 is zijde, orde 2 is diagonaal met overslaan"
            GW.PRINT("orde 1 is zijde, orde 2 is diagonaal met overslaan");
            //    PRINT "van een hoekpunt, orde p is overslaan p-1 hoekpunten"
            GW.PRINT("van een hoekpunt, orde p is overslaan p-1 hoekpunten");
            //    PRINT "geef waarden van p en van q, een goede combinatie is"
            GW.PRINT("geef waarden van p en van q, een goede combinatie is");
            //    PRINT "n=33, p=11, q=17" : PRINT : PRINT
            GW.PRINT("n=33, p=11, q=17");
            GW.PRINT("");
            GW.PRINT("");
            //    INPUT"p = ",P : INPUT"q = ",Q : CLS
            P = GW.INPUT("p =  ");
            Q = GW.INPUT("q =  ");
            GW.CLS();
            //    IF P>Q THEN SWAP P,Q
            if (P > Q)
            {
            }
            // REM ***graphics***
            //    FOR K=0 TO N-1
            for (  K = 0; K <= N - 1; K++)
            {
                //       X(K)=COS(2*K*PI/N)
                X[K] = GW.COS(2 * K * PI / N);
                //       Y(K)=SIN(2*K*PI/N)
                Y[K] = GW.SIN(2 * K * PI / N);
                //    NEXT K
            }
            //    FOR I=P TO Q : FOR J=0 TO N-1
            for ( I = (int)P; I <= Q; I++)
            {
                for (  J = 0; J <= N - 1; J++)
                {
                    //       K=(I+J) MOD N
                    K = (I + J) % N;
                    //       LINE (X(J),Y(J))-(X(K),Y(K))
                    GW.LINE(X[J], Y[J], X[K], Y[K]);
                    //    NEXT J : NEXT I
                }
            }
            // END
        }
        // 
    }
}
