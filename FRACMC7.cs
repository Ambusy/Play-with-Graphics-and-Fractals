using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class FRACMC7
    {
        public FRACMC7()
        {
            float C = 0;
            int KMAX = 0;
            int K = 0;
            int L = 0;
            float X = 0;
            float Y = 0;

            int COL = 0;
            // REM ***Sierpinski vierkant met verlopende kleuren***
            // REM ***naam:FRACMC7***
            //    SCREEN 12 : CLS : RANDOMIZE 11
            GW.CLS();
            GW.RANDOMIZE(11);
            //    WINDOW (-1.6,-1.2)-(1.6,1.2)
            GW.WINDOW(-1.6f, -1.2f, 1.6f, 1.2f);
            //    C=SQR(1/2)  'contractiefactor
            C = GW.SQR(1 / (float)2);// 'contractiefactor ;
                                     //    DIM E(4),F(4)
            float[] E = new float[4 + 1];
            float[] F = new float[4 + 1];
            //    E(1)=1-C : F(1)=1-C
            E[1] = 1 - C;
            F[1] = 1 - C;
            //    E(2)=1-C : F(2)=-1+C
            E[2] = 1 - C;
            F[2] = -1 + C;
            //    E(3)=-1+C : F(3)=1-C
            E[3] = -1 + C;
            F[3] = 1 - C;
            //    E(4)=-1+C : F(4)=-1+C
            E[4] = -1 + C;
            F[4] = -1 + C;
            //    KMAX=100000 : K=0 : X=1 : Y=0  'start
            KMAX = 100000;
            K = 0;
            X = 1;
            Y = 0;// 'start ;
                  //    DO WHILE K<KMAX AND INKEY$=""
            while (K < KMAX && GW.INKEY() == "")
            {
                //       L=1+INT(4*RND)
                L = 1 + (int)(4 * GW.RND());
                //       X=C*X+E(L) : Y=C*Y+F(L)
                X = C * X + E[L];
                Y = C * Y + F[L];
                //       COL=POINT (X,Y) : COL=COL+1
                COL = GW.POINT(X, Y);
                COL = COL + 1;
                //       PSET (X,Y),COL : PSET (X,-Y),COL
                GW.PSET(X, Y, COL);
                GW.PSET(X, -Y, COL);
                //       PSET (-X,Y),COL : PSET (-X,-Y),COL
                GW.PSET(-X, Y, COL);
                GW.PSET(-X, -Y, COL);
                //       PSET (Y,X),COL : PSET (-Y,X),COL
                GW.PSET(Y, X, COL);
                GW.PSET(-Y, X, COL);
                //       PSET (Y,-X),COL : PSET (-Y,-X),COL
                GW.PSET(Y, -X, COL);
                GW.PSET(-Y, -X, COL);
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
