using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class LISSAV
    {
        public LISSAV()
        {
            float A = 0;
            float B = 0;
            float S = 0;
            float T = 0;
            float H = 0;
            float X = 0;
            float Y = 0;
            // REM ***Lissajous-achtige krommen***
            // REM ***name:LISSAV***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-2,-1.5)-(2,1.5)
            GW.WINDOW(-2, -1.5f, 2f, 1.5f);
            //    A=1 : B=.5 : S=2.45  'parameters
            A = 1;
            B = .5f;
            S = 2.45f; //  'parameters 
            //    T=0 : H=.01
            T = 0;
            H = .01f;
            //    LINE (-A-B-.1,-1.1)-(A+B+.1,1.1),,B
            GW.LINE(-A - B - .1F, -1.1F, A + B + .1F, 1.1F ,"B");
            //    PRINT "druk op een willekeurige toets voor einde programma"
            GW.PRINT("druk op een willekeurige toets voor einde programma");
            //    DO WHILE INKEY$="" AND T<315
            while (GW.INKEY() == "" && T<315 ) {
                //       X=A*COS(T)+B*COS(S*T)
                X = A * GW.COS(T) + B * GW.COS(S * T);
                //       Y=SIN(T)
                Y = GW.SIN(T);
                //       IF T=0 THEN PSET (X,Y) ELSE LINE -(X,Y)
                if (T == 0)
                    GW.PSET(X, Y);
                else
                    GW.LINE(X, Y);
                //       T=T+H
                T = T + H;
                //    LOOP
            }
            //    LOCATE 1,1 : PRINT SPACE$(80)
            GW.LOCATE(1, 1);
                GW.PRINT(GW.SPACE(80));
                // END
        }
    }
}
