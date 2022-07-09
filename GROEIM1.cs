using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class GROEIM1
    {
        public GROEIM1()
        {
            float A = 0;
            int KMAX = 0;
            float X = 0;
            float Y = 0;
            int K = 0;
            float Z;
            int L = 0;
            // REM ***een model van geremde groei***
            // REM ***naam:GROEIM1***
            // REM ***x''= a x' (1-x*x) ***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-2,-1.5)-(2,1.5)
            GW.WINDOW(-2f, -1.5f, 2f, 1.5f);
            //    A=1.95 : KMAX=400000
            A = 1.95f;
            KMAX = 400000;
            //    X=.1 : Y=.1
            X = .1f;
            Y = .1f;
            //    FOR K=1 TO KMAX
            for (K = 1; K <= KMAX; K++)
            {
                //       IF INKEY$<>"" THEN END
                if (GW.INKEY() != "")
                {
                    return;
                }
                //       Z=X : X=Y : Y=A*Y*(1-Z*Z)
                Z = X;
                X = Y;
                Y = A * Y * (1 - Z * Z);
                //       L=POINT (X,Y)
                L = GW.POINT(X, Y);
                //       IF L<15 THEN L=L+1 ELSE L=1
                if (L < 15)
                {
                    L = L + 1;
                }
                else
                {
                    L = 1;
                }
                //       PSET (X,Y),L
                GW.PSET(X, Y, L);
                //    NEXT K : BEEP
                // END
            }
                return;
                // 
        }
    }
}
