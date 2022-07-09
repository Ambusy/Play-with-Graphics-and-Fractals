using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class HENON2
    {
        public HENON2()
        {
            float A = 0;
            float B = 0;
            float X0 = 0;
            float Y0 = 0;
            float H1 = 0;
            float H2 = 0;
            float X = 0;
            float Y = 0;
            int N = 0;
            float U = 0;
            float V = 0;
            // REM ***een enkele chaotische baan***
            // REM ***naam:HENON2***
            //    DEFDBL A,B,H,U-Y : DEFLNG N
            //    SCREEN 12 : CLS
            GW.CLS();
            //    A=.24 : B=SQR(1-A*A)  'parameters
            A = .24f;
            B = GW.SQR(1 - A * A);// 'parameters ;
// REM ***beginpunt en window***
//    X0=.575 : Y0=.16 : H1=.08 : H2=.06
            X0 = .575f;
            Y0 = .16f;
            H1 = .08f;
            H2 = .06f;
            //    WINDOW (X0-H1,Y0-H2)-(X0+H1,Y0+H2)
            GW.WINDOW(X0 - H1, Y0 - H2, X0 + H1, Y0 + H2);
            // REM ***hoofdlus***
            //    X=X0 : Y=Y0 : N=0
            X = X0;
            Y = Y0;
            N = 0;
            //    DO WHILE INKEY$="" AND N<250000
            while (GW.INKEY()== "" &&  N<250000 ) {
                //       IF ABS(X-X0)<.8*H1 AND ABS(Y-Y0)<.8*H2 THEN PSET (X,Y),14
                if (GW.ABS(X - X0) < .8 * H1 && GW.ABS(Y-Y0)< .8 * H2  ) {
                    GW.PSET(X, Y,14);
                }
                //       U=X : V=Y-X*X
                U = X;
                V = Y - X * X;
                //       X=A*X-B*V : Y=B*U+A*V
                X = A * X - B * V;
                Y = B * U + A * V;
                //       N=N+1
                N = N + 1;
                //    LOOP : BEEP
            }
            GW.LOCATE(1, 1); GW.PRINT("gereed");
            // END
            return;
            // 
        }
    }
}
