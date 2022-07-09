using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class FRACMC5
    {
        public FRACMC5()
        {
            float C = 0;
            float A = 0;
            float B = 0;
            int KMAX = 0;
            int K = 0;
            float X = 0;
            float Y = 0;
            int L = 0;
            // REM ***de zeef van Sierpinski***
            // REM ***naam:FRACMC5***
            //    SCREEN 12 : CLS : RANDOMIZE 11
            GW.CLS();
            GW.RANDOMIZE(11);
            //    WINDOW (-1.4,-1.2)-(1.8,1.2)
            GW.WINDOW(-1.4f, -1.2f, 1.8f, 1.2f);
            //    DIM E(3),F(3)
            float[] E = new float[3 + 1];
            float[] F = new float[3 + 1];
            //    C=.5
            C = .5f;
            //    A=1/2 : B=SQR(3)/2
            A = 1 / (float)2;
            B = GW.SQR(3) / 2;
            //    E(1)=1-C : F(1)=0 : E(2)=A*(C-1)
            E[1] = 1 - C;
            F[1] = 0;
            E[2] = A * (C - 1);
            //    F(2)=-B*(C-1) : E(3)=A*(C-1) : F(3)=B*(C-1)
            F[2] = -B * (C - 1);
            E[3] = A * (C - 1);
            F[3] = B * (C - 1);
            //    KMAX=10000 : K=0 : X=1 : Y=0  
            KMAX = 10000;
            K = 0;
            X = 1;
            Y = 0;
            //    DO WHILE K<KMAX AND INKEY$=""
            while (K < KMAX && GW.INKEY() == "")
            {
                //       L=1+INT(3*RND)
                L = 1 + (int)(3 * GW.RND());
                //       X=C*X+E(L) : Y=C*Y+F(L)
                X = C * X + E[L];
                Y = C * Y + F[L];
                //       PSET (X,Y) : PSET (-A*X-B*Y,B*X-A*Y)
                GW.PSET(X, Y);
                GW.PSET(-A * X - B * Y, B * X - A * Y);
                //       PSET (-A*X+B*Y,-B*X-A*Y) : PSET (X,-Y)
                GW.PSET(-A * X + B * Y, -B * X - A * Y);
                GW.PSET(X, -Y);
                //       PSET (-A*X+B*Y,B*X+A*Y) : PSET (-A*X-B*Y,-B*X+A*Y)
                GW.PSET(-A * X + B * Y, B * X + A * Y);
                GW.PSET(-A * X - B * Y, -B * X + A * Y);
                //       K=K+1
                K = K + 1;
                //    LOOP : BEEP
            }
            // END
            return;
            // 
        }
    }
}
