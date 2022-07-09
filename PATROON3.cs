using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class PATROON3
    {
        public PATROON3()
        {
            int N1 = 0;
            int N2 = 0;
            int M = 0;
            float B = 0;
            float C = 0;
            int L = 0;
            float Z = 0;
            float X = 0;
            float Y = 0;
            float H = 0;
            int COL = 0;
            float D = 0;
            int I = 0;
            int J = 0;
            // REM ***een kruissteekjespatroon***
            // REM ***naam:PATROON3***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            //    N1=40 : N2=30 : M=5
            N1 = 40;
            N2 = 30;
            M = 5;
            //    D=6 : H=3 : B=10 : C=500
            D = 6;
            H = 3;
            B = 10;
            C = 500;
            //    FOR I=0 TO N1 : FOR J=0 TO N2
            for (I = 0; I <= N1; I++)
            {
                for (J = 0; J <= N2; J++)
                {
                    //       IF I/N1>J/N2 THEN L=I*N2 ELSE L=J*N1
                    if (I / (float)N1 > J / (float)N2)
                    {
                        L = I * N2;
                    }
                    else
                    {
                        L = J * N1;
                    }
                    //       COL=9+INT(B*L/(N1*N2)) MOD 7
                    COL = 9 + (int)(B * L / (float)(N1 * N2)) % 7;
                    //       IF I=N1 OR J=N2 THEN COL=15
                    if (I == N1 || J == N2)
                    {
                        COL = 15;
                    }
                    //       X=I/N1 : Y=J/N2
                    X = I / (float)N1;
                    Y = J / (float)N2;
                    //       Z=(1-X*X)*(1-Y*Y)  'functiekeuze
                    Z = (1 - X * X) * (1 - Y * Y);
                    //       IF INT(C*Z) MOD M = 0 THEN GOSUB graphics
                    if ((int)(C * Z) % M == 0)
                    {
                        graphics();
                    }
                    //    NEXT J : NEXT I
                }
            }
            // END
            return;
            void graphics()
            {
                //    X=D*I : Y=-D*J : GOSUB kruis
                X = D * I;
                Y = -D * J;
                kruis();
                //    X=D*I : Y=D*J : GOSUB kruis
                X = D * I;
                Y = D * J;
                kruis();
                //    X=-D*I : Y=-D*J : GOSUB kruis
                X = -D * I;
                Y = -D * J;
                kruis();
                //    X=-D*I : Y=D*J : GOSUB kruis
                X = -D * I;
                Y = D * J;
                kruis();
                // RETURN
            }
            void kruis()
            {
                //    PSET (X-H,Y-H),COL : LINE -(X+H,Y+H),COL
                GW.PSET(X - H, Y - H, COL);
                GW.LINE(X + H, Y + H, COL);
                //    PSET (X-H,Y+H),COL : LINE -(X+H,Y-H),COL
                GW.PSET(X - H, Y + H, COL);
                GW.LINE(X + H, Y - H, COL);
                // RETURN
                // 
            }
        }
    }
}
