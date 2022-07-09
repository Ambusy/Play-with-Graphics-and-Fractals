using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class WEB
    {
        public WEB()
        {
            int N = 0;
            int C = 0;
            float X1 = 0;
            float X2 = 0;
            float Y1 = 0;
            float Y2 = 0;
            // REM ***netwerk van lijnen***
            // REM ***naam:WEB***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-.2,-1.2)-(1.2,1.2)
            GW.WINDOW(-.2f, -1.2f, 1.2f, 1.2f);
            //    N=16
            N = 16;
            //    FOR I=0 TO N
            for (int I = 0; I <= N; I++)
            {
                //       FOR J=0 TO N
                for (int J = 0; J <= N; J++)
                {
                    //          C=ABS(I-J)
                    C = GW.ABS(I - J);
                    //          X1=I/N : Y1=1 : X2=J/N : Y2=-1
                    X1 = I / (float)N;
                    Y1 = 1;
                    X2 = J / (float)N;
                    Y2 = -1;
                    //          IF C MOD 2 = 1 THEN LINE (X1,Y1)-(X2,Y2),C
                    if (C % 2 == 1)
                        GW.LINE(X1, Y1, X2, Y2, C);
                    //       NEXT J
                }
                //    NEXT I
            }
            // END
        }
        // 
    }
}

