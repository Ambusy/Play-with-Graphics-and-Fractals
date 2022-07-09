using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class PATROON4
    {
        public PATROON4()
        {
            int N = 0;
            int I = 0;
            int J = 0;
            float C = 0;
            float X = 0;
            float Y = 0;
            float Z = 0;
            int W = 0;
            int[] COL = new int[] { 0, 1, 9, 4, 12, 2, 14 };
            int L;
            float P1 = 0;
            float P2 = 0;
            float Q1 = 0;
            float Q2 = 0;

            // REM ***een vierkant patroon met kleurenblokjes***
            // REM ***naam:PATROON4***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            // REM ***kleurencode***
            //    DIM COL(6) : N=32
            N = 32;
            //    DATA 1,9,4,12,2,14
            //    FOR I=1 TO 6 : READ COL(I) : NEXT I
            for (I = 1; I <= 6; I++)
            {
            }
            //    INPUT "geef een getal van drie cijfers ";C : CLS
            C = GW.INPUT("geef een getal van drie cijfers ");
            GW.CLS();
            //    LINE (-5*N-5,-5*N-5)-(5*N+5,5*N+5),,B
            GW.LINE(-5 * N - 5, -5 * N - 5, 5 * N + 5, 5 * N + 5, "B");
            //    FOR I=0 TO N : FOR J=0 TO N
            for (I = 0; I <= N; I++)
            {
                for (J = 0; J <= N; J++)
                {
                    //       P1=5*I : P2=-5*I : Q1=5*J : Q2=-5*J
                    P1 = 5 * I;
                    P2 = -5 * I;
                    Q1 = 5 * J;
                    Q2 = -5 * J;
                    //       X=I/N : Y=J/N
                    X = I / (float)N;
                    Y = J / (float)N;
                    //       Z=(1-X*X)*(1-Y*Y)  'functiekeuze
                    Z = (1 - X * X) * (1 - Y * Y);// 'functiekeuze ;
                                                  //       L=1+INT(C*Z) MOD 6 : GOSUB graphics
                    L = 1 + (int)(C * Z) % 6;
                    graphics();
                    //    NEXT J : NEXT I
                }
            }
            // END
            return;
            void graphics()
            {
                //    W=COL(L)
                W = COL[L];
                //    LINE (P1-2,Q1-2)-(P1+2,Q1+2),W,BF
                GW.LINE(P1 - 2, Q1 - 2, P1 + 2, Q1 + 2, W, "BF");
                //    LINE (P1-2,Q2-2)-(P1+2,Q2+2),W,BF
                GW.LINE(P1 - 2, Q2 - 2, P1 + 2, Q2 + 2, W, "BF");
                //    LINE (P2-2,Q1-2)-(P2+2,Q1+2),W,BF
                GW.LINE(P2 - 2, Q1 - 2, P2 + 2, Q1 + 2, W, "BF");
                //    LINE (P2-2,Q2-2)-(P2+2,Q2+2),W,BF
                GW.LINE(P2 - 2, Q2 - 2, P2 + 2, Q2 + 2, W, "BF");
                // RETURN
                return;
                // 
            }
        }
    }
}
