using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Graphics_boek
{
    class PATROON1
    {
        public PATROON1()
        {
            int N = 0;
            int I = 0;
            int J = 0;
            float X = 0;
            float C = 0;
            float Y = 0;
            float Z = 0;
            // REM ***een vierkant patroon***
            // REM ***naam:PATROON1***
            //    SCREEN 12 : CLS : N=50
            GW.CLS();
            N = 50;
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            //    INPUT "geef een getal van drie cijfers ";C : CLS
            C = GW.INPUT("geef een getal van drie cijfers ");
            GW.CLS();
            //    FOR I=-N TO N : FOR J=-N TO N
            for (I = -N; I <= N; I++)
            {
                for (J = -N; J <= N; J++)
                {
                    //       IF INKEY$<>"" THEN END
                    if (GW.INKEY() != "") return;

                    //       X=I/N : Y=J/N
                    X = (float)I / (float)N;
                    Y = (float)J / (float)N;
                    //       Z=(1-X*X)*(1-Y*Y)  'functiekeuze
                    Z = (1 - X * X) * (1 - Y * Y);
                    //       IF INT(C*Z) MOD 2 = 0 THEN PSET (3*I,-3*J)
                    if ((int)(C * Z) % 2 == 0)
                    {
                        GW.PSETe(3 * I, -3 * J);
                    }
                    //    NEXT J : NEXT I
                }
            }
            //    LINE (-3*N-10,-3*N-10)-(3*N+10,3*N+10),,B
            GW.LINE(-3 * N - 10, -3 * N - 10, 3 * N + 10, 3 * N + 10, "B");
            // END
        }
        // 
    }
}

