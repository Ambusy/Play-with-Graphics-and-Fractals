using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class LISSA
    {
        public LISSA() {
            //REM*** Lissajous kromme***
            //REM*** naam:LISSA***
            //   SCREEN 12 : CLS : PI=4*ATN(1)
            float PI = 4 * GW.ATN(1);
            //   WINDOW(-2,-1.5)-(2,1.5)
            GW.WINDOW(-2, -1.5f, 2, 1.5f);
            //   A=4/3  'vormfactor
            float A = 4f / 3f;
            //   M=15  'eerste frequentie
            float M = 4; // 15;
            //   N=22  'tweede frequentie
            float N = 3; // 22;
            //   F=0.5  'faseverschil
            float F = 0; // .5f;
            //   S=N/M : F=2*PI* F : H=.005 : T=0
            float S = N / M;
            F = 2 * PI * F;
            float H = .005f;
            //   DO WHILE INKEY$="" AND T<2*M* PI
            float T = 0;
            while (GW.INKEY() == "" && T < 2 * M * PI)
            {
                //      X= A * SIN(T)
                float X = A * GW.SIN(T);
                //      Y= SIN(S * T + F)
                float Y = GW.SIN(S * T + F);
                //      PSET (X, Y)
                GW.PSET(X,Y);
                //      T = T + H
                T = T + H;
            }
            //   LOOP : BEEP
            //END
        }
    }
}
