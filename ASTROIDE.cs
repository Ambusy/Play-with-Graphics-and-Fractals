using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class ASTROIDE
    {
        public ASTROIDE()
        {
            float PI = 0;
            int N = 0, I=0;
            float T = 0;
            // REM ***astroide***
            // REM ***naam:ASTROIDE***
            //    SCREEN 12 : CLS : PI=4*ATN(1)
            GW.CLS();
            PI = 4 * GW.ATN(1);
            //    WINDOW (-1.6,-1.2)-(1.6,1.2)
            GW.WINDOW(-1.6f, -1.2f, 1.2f, 1.2f);
            //    LOCATE 1,1 : INPUT"aantal lijnen tussen 32 en 128 = ",N
            GW.LOCATE(1, 1);
            N=(int)GW.INPUT("aantal lijnen tussen 32 en 128 =  ");
            //    N=2*INT(N/2) : IF N<32 THEN N=64
            N = 2 * (N / 2);
            if (N < 32)
            {
                N = 64;
            }
            //    LOCATE 1,1 : PRINT SPACE$(80)
            GW.LOCATE(1, 1);
            GW.PRINT(GW.SPACE(80));
            //    FOR I=0 TO N-1
            for (I = 0; I <= N - 1; I++)
            {
                //       T=2*PI*I/N
                T = 2 * PI * I / N;
                //       LINE (COS(T),0)-(0,SIN(T))
                GW.LINE(GW.COS(T), 0 , 0, GW.SIN(T));
                //    NEXT I
            }
            // END
        }
        // 
    }
}

