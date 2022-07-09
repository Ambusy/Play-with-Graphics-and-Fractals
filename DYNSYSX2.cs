using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class DYNSYSX2
    {
        public DYNSYSX2()
        {
            float A = 0;
            int NMAX = 0;
            float X = 0;
            float Y = 0;
            int N = 0;
            float Z = 0;
            // REM ***een enkele chaotische baan van***
            // REM ***x'=-y+f(x), y'=x+f(x') ***
            // REM ***f(x)=asin x ***
            // REM ***naam:DYNSYSX2***
            //    DEFDBL A,X,Y,Z
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-64,-48)-(64,48)
            GW.WINDOW(-64f, -48f, 64f, 48f);
            // REM ***data***
            //    A=.08 : NMAX=100000
            A = .08f;
            NMAX = 100000;
            //    X=0 : Y=3.14 : N=0
            X = 0;
            Y = 3.14f;
            N = 0;
            // REM ***baan***
            //    DO WHILE N<NMAX AND INKEY$=""
            while (N < NMAX && GW.INKEY()== "" ) {
                //       N=N+1
                N = N + 1;
                //       PSET (X,Y),1+INT(N/1000) MOD 15
                GW.PSETe(X, Y,1 + (int)(N / (float)1000) % 15);
                //       Z=X : X=-Y+A*SIN(X)
                Z = X;
                X = -Y + A * GW.SIN(X);
                //       Y=Z+A*SIN(Y)
                Y = Z + A * GW.SIN(Y);
                //    LOOP : BEEP
            }
            // END
            return;
            // 
        }
    }
}
