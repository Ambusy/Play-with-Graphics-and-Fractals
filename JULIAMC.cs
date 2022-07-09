using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class JULIAMC
    {
        public JULIAMC()
        {
            float A = 0;
            float B = 0;
            int KMAX = 0;
            int K = 0;
            float X = 0;
            float Y = 0;
            float X1 = 0;
            float Y1 = 0;
            float R = 0;
            // REM ***Julia set van z*z+c, Monte Carlo methode***
            // REM ***naam:JULIAMC***
            //    SCREEN 12 : CLS : RANDOMIZE 11
            GW.CLS();
            GW.RANDOMIZE(11);
            //    WINDOW (-2,-1.5)-(2,1.5)
            GW.WINDOW(-2f, -1.5f, 2f, 1.5f);
            //    A=-1 : B=0  'parameters Julia set
            A = -1;
            B = 0;// 'parameters Julia set ;
                  //    KMAX = 40000 : K=0 : X=RND : Y=RND
            KMAX = 40000;
            K = 0;
            X = GW.RND();
            Y = GW.RND();
            //    DO WHILE K<KMAX AND GW.INKEY()"=""
            while (K < KMAX && GW.INKEY() == "")
            {
                //       X1=(X-A)/2 : Y1=(Y-B)/2 : R=GW.SQR(X1*X1+Y1*Y1)
                X1 = (X - A) / 2f;
                Y1 = (Y - B) / 2f;
                R = GW.SQR(X1 * X1 + Y1 * Y1);
                //       IF RND<.5 THEN
                if (GW.RND() < .5)
                {
                    //          X=GW.SQR(R+X1) : Y=GW.SQR(R-X1)
                    X = GW.SQR(R + X1);
                    Y = GW.SQR(R - X1);
                    //          IF Y1<0 THEN Y=-Y
                    if (Y1 < 0)
                    {
                        Y = -Y;
                    }
                    //       ELSE
                }
                else
                {
                    Y = -Y;
                    //          X=-GW.SQR(R+X1) : Y=-GW.SQR(R-X1)
                    X = -GW.SQR(R + X1);
                    Y = -GW.SQR(R - X1);
                    //          IF Y1<0 THEN Y=-Y
                    if (Y1 < 0)
                    {
                        Y = -Y;
                    }
                    //       END IF
                }
                //       IF K>10 THEN PSET (X,Y) : PSET (-X,-Y)
                if (K > 10)
                {
                    GW.PSET(X, Y);
                    GW.PSET(-X, -Y);
                }
                //       IF K>10 AND B=0 THEN PSET (X,-Y) : PSET (-X,Y)
                if (K > 10 && B == 0  ) {
                    GW.PSET(X, -Y);
                    GW.PSET(-X, Y);
                }
                //       K=K+1
                K = K + 1;
                //    LOOP
            }
            // END
            return;
            // 
            ;
        }
    }
}
