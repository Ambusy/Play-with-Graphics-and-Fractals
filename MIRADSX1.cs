using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class MIRADSX1
    {
        public MIRADSX1()
        {
            float A = 0;
            float X = 0;
            float Y = 0;
            int P = 0;
            float C = 0;
            int KMAX = 0;
            float W = 0;
            int K = 0;
            float Z = 0;
            float U = 0;
            string AS = "";
            // REM ***Mira's dynamisch systeem***
            // REM ***in een drietal gevallen worden banen afgebeeld***
            // REM ***naam:MIRADSX1***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-40,-30)-(40,30) : A=.3
            GW.WINDOW(-40f, -30f, 40f, 30f);
            A = .3f;
            //    X=7 : Y=0 : P=2 : GOSUB orbit
            X = 7;
            Y = 0;
            P = 2;
            orbit();
            //    X=-12 : Y=0 : P=2 : GOSUB orbit
            X = -12;
            Y = 0;
            P = 2;
            orbit();
            //    X=-21 : Y=0 : P=2 : GOSUB orbit
            X = -21;
            Y = 0;
            P = 2;
            orbit();
            //    BEEP : GOSUB text
            text();
            //    CLS : A=-.05
            GW.CLS();
            A = -.05f;
            //    X=9.8 : Y=0 : P=1 : GOSUB orbit
            X = 9.8f;
            Y = 0;
            P = 1;
            orbit();
            //    X=20 : Y=0 : P=4 : GOSUB orbit
            X = 20;
            Y = 0;
            P = 4;
            orbit();
            //    X=15 : Y=0 : P=2 : GOSUB orbit
            X = 15;
            Y = 0;
            P = 2;
            orbit();
            //    X=2 : Y=0 : P=4 : GOSUB orbit
            X = 2;
            Y = 0;
            P = 4;
            orbit();
            //    X=18 : Y=0 : P=2 : GOSUB orbit
            X = 18;
            Y = 0;
            P = 2;
            orbit();
            //    X=25 : Y=0 : P=6 : GOSUB orbit
            X = 25;
            Y = 0;
            P = 6;
            orbit();
            //    X=7.5: Y=0 : P=4 : GOSUB orbit
            X = 7.5f;
            Y = 0;
            P = 4;
            orbit();
            //    GOSUB text
            text();
            //    WINDOW (-32,-24)-(32,24)
            GW.WINDOW(-32f, -24f, 32f, 24f);
            //    CLS : A=.18
            GW.CLS();
            A = .18f;
            //    X=8 : Y=0 : P=2 : GOSUB orbit
            X = 8;
            Y = 0;
            P = 2;
            orbit();
            //    X=20 : Y=0 : P=2 : GOSUB orbit
            X = 20;
            Y = 0;
            P = 2;
            orbit();
            //    X=15 : Y=0 : P=6 : GOSUB orbit
            X = 15;
            Y = 0;
            P = 6;
            orbit();
            //    X=5.3 : Y=0 : P=2 : GOSUB orbit
            X = 5.3f;
            Y = 0;
            P = 2;
            orbit();
            //    X=9 : Y=0 : P=2 : GOSUB orbit
            X = 9;
            Y = 0;
            P = 2;
            orbit();
            //    LOCATE 1,1 : PRINT "einde programma"
            GW.LOCATE(1, 1);
            GW.PRINT("einde programma");
            // END
            return;
            void orbit()
            {
                //    C=2-2*A : KMAX=1000*P
                C = 2 - 2 * A;
                KMAX = 1000 * P;
                //    W=A*X+C*X*X/(1+X*X)
                W = A * X + C * X * X / (1 + X * X);
                //    FOR K=0 TO KMAX
                for (K = 0; K <= KMAX; K++)
                {
                    //       PSET (X,Y)
                    GW.PSET(X, Y);
                    //       Z=X : X=Y+W : U=X*X
                    Z = X;
                    X = Y + W;
                    U = X * X;
                    //       W=A*X+C*U/(1+U) : Y=W-Z
                    W = A * X + C * U / (1 + U);
                    Y = W - Z;
                    //    NEXT K
                }
                // RETURN
            }
            void text()
            {
                //    LOCATE 1,1 : PRINT "druk op een toets"
                GW.LOCATE(1, 1);
                GW.PRINT("druk op een toets");
                //    A$=INPUT$(1)
                AS = GW.INPUTS(1);
                // RETURN
                // 
            }
        }
    }
}
