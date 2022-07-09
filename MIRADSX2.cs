using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class MIRADSX2
    {
        public MIRADSX2()
        {
            int KMAX = 0;
            int I = 0;
            int L = 0;
            float A = 0;
            float B = 0;
            float C = 0;
            float D = 0;
            float X = 0;
            float Y = 0;
            float W = 0;
            int K = 0;
            float Z = 0;
            float U = 0;

            string AS = "";
            // REM ***chaotische banen in Mira's dynamisch systeem***
            // REM ***naam:MIRADSX2***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            //    DIM COL%(15) : KMAX=50000
            int[] COL = new int[] {0, 2, 10, 10, 4, 4, 12, 12, 12, 14, 14, 14, 15, 15, 15, 15 };
            KMAX = 90000;
            //    DATA 0,2,10,10,4,4,12,12,12,14,14,14,15,15,15,15
            //    FOR I=0 TO 15 : READ COL%(I) : NEXT I
            for (I = 0; I <= 15; I++)
            {
            }
            // REM ***verschillende gevallen***
            //    A=-.48 : B=.93 : C=2-2*A : D=20
            A = -.48f;
            B = .93f;
            C = 2 - 2 * A;
            D = 20;
            //    X=4 : Y=0
            X = 4;
            Y = 0;
            // GOSUB orbit : GOSUB text
            orbit();
            text();
            //    A=.31 : B=1 : C=2-2*A : D=5
            A = .31f;
            B = 1;
            C = 2 - 2 * A;
            D = 5;
            //    X=12 : Y=0
            X = 12;
            Y = 0;
            // GOSUB orbit : GOSUB text
            orbit();
            text();
            //    A=.32 : B=1 : C=2-2*A : D=16
            A = .32f;
            B = 1;
            C = 2 - 2 * A;
            D = 16;
            //    X=-5 : Y=0
            X = -5;
            Y = 0;
            // GOSUB orbit : GOSUB text
            orbit();
            text();
            //    A=-.4 : B=.99 : C=2-2*A : D=20
            A = -.4f;
            B = .99f;
            C = 2 - 2 * A;
            D = 20;
            //    X=4 : Y=0
            X = 4;
            Y = 0;
            // GOSUB orbit : GOSUB text
            orbit();
            text();
            //    A=-.4 : B=1 : C=2-2*A : D=14
            A = -.4f;
            B = 1;
            C = 2 - 2 * A;
            D = 14;
            //    X=4 : Y=0
            X = 4;
            Y = 0;
            // GOSUB orbit : GOSUB text
            orbit();
            text();
            //    A=-.4 : B=1 : C=2-2*A : D=8
            A = -.4f;
            B = 1;
            C = 2 - 2 * A;
            D = 8;
            //    X=20 : Y=0
            X = 20;
            Y = 0;
            // GOSUB orbit : GOSUB text
            orbit();
            text();
            //    A=-.2 : B=1 : C=2-2*A : D=14
            A = -.2f;
            B = 1;
            C = 2 - 2 * A;
            D = 14;
            //    X=10 : Y=0
            X = 10;
            Y = 0;
            // GOSUB orbit
            orbit();
            // LOCATE 1,1 : PRINT "einde programma"
            GW.LOCATE(1, 1);
            GW.PRINT("einde programma");
            // END
            return;
            void orbit()
            {
                //    W=A*X+C*X*X/(1+X*X)
                W = A * X + C * X * X / (1 + X * X);
                //    FOR K=0 TO KMAX
                for (K = 0; K <= KMAX; K++)
                {
                    //       Z=X : X=B*Y+W : U=X*X
                    Z = X;
                    X = B * Y + W;
                    U = X * X;
                    //       W=A*X+C*U/(1+U) : Y=W-Z
                    W = A * X + C * U / (1 + U);
                    Y = W - Z;
                    //       L=POINT(D*X,D*Y)
                    L = GW.POINT(D * X, D * Y);
                    //       L=1+L MOD 15
                    L = 1 + L % 15;
                    //       IF K>100 THEN PSET (D*X,D*Y),COL%(L)
                    if (K > 100)
                    {
                        GW.PSET(D * X, D * Y,  COL[L]);
                    }
                    //       IF INKEY$<>"" THEN EXIT FOR
                    if (GW.INKEY() != "")
                    {
                        break;
                    }
                    //    NEXT K : BEEP
                }
                // RETURN
            }
            void text()
            {
                //    LOCATE 1,1 : PRINT "druk op een toets voor vervolg"
                GW.LOCATE(1, 1);
                GW.PRINT("druk op een toets voor vervolg");
                //    A$=INPUT$(1) : CLS
                AS = GW.INPUTS(1);
                GW.CLS();
                // RETURN
                // 
            }
        }
    }
}
