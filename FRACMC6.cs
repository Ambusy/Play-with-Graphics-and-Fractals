using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class FRACMC6
    {
        public FRACMC6()
        {
            float C = 0;
            float A = 0;
            float B = 0;
            int KMAX = 0;
            int K = 0;
            int L = 0;
            float X = 0;
            float Y = 0;

            int COL = 0;
            // REM ***de zeef van Sierpinski met verlopende kleuren***
            // REM ***naam:FRACMC6***
            //    SCREEN 12 : CLS : RANDOMIZE 11
            GW.CLS();
            GW.RANDOMIZE(11);
            //    WINDOW (-1.44,-1.08)-(1.44,1.08)
            GW.WINDOW(-1.44f, -1.08f, 1.44f, 1.08f);
            //    DIM E(3),F(3)
            float[] E = new float[3 + 1];
            float[] F = new float[3 + 1];
            //    C=.7  'contractie factor
            C = .7f;//  'contractie factor ;
                    //    A=1/2 : B=SQR(3)/2
            A = .5f;
            B = GW.SQR(3) / 2;
            //    E(1)=1-C : F(1)=0 : E(2)=A*(C-1)
            E[1] = 1 - C;
            F[1] = 0;
            E[2] = A * (C - 1);
            //    F(2)=-B*(C-1) : E(3)=A*(C-1) : F(3)=B*(C-1)
            F[2] = -B * (C - 1);
            E[3] = A * (C - 1);
            F[3] = B * (C - 1);
            //    KMAX=100000 : K=0 : X=1 : Y=0  'start
            KMAX = 100000;
            K = 0;
            X = 1;
            Y = 0;// 'start ;
                  //    DO WHILE K<KMAX AND INKEY$=""
            while (K < KMAX && GW.INKEY() == "")
            {
                //       L=1+INT(3*RND)
                L = 1 + (int)(3 * GW.RND());
                //       X=C*X+E(L) : Y=C*Y+F(L)
                X = C * X + E[L];
                Y = C * Y + F[L];
                //       COL=POINT (X,Y) : COL=COL+1
                COL = GW.POINT(X, Y);
                COL = COL + 1;
                //       PSET (X,Y),COL : PSET(X,-Y),COL
                GW.PSET(X, Y, COL);
                //       PSET (-A*X-B*Y,B*X-A*Y),COL
                GW.PSET(-A * X - B * Y, B * X - A * Y, COL);
                //       PSET (-A*X+B*Y,-B*X-A*Y),COL
                GW.PSET(-A * X + B * Y, -B * X - A * Y, COL);
                //       PSET (-A*X+B*Y,B*X+A*Y),COL
                GW.PSET(-A * X + B * Y, B * X + A * Y, COL);
                //       PSET (-A*X-B*Y,-B*X+A*Y),COL
                GW.PSET(-A * X - B * Y, -B * X + A * Y, COL);
                //       K=K+1
                K = K + 1;
                //    LOOP : BEEP
            }
            GW.LOCATE(1, 1);
            GW.PRINT("Einde");

            // END
            return;
            // 
        }
    }
}
