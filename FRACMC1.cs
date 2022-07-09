using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class FRACMC1
    {
        public FRACMC1()
        {
            int KMAX = 0;
            float A = 0;
            float B = 0;
            float C = 0;
            float D = 0;
            float X = 0;
            float Y = 0;
            int K = 0;
            float R = 0;
            float X1 = 0;
            float Y1 = 0;
            // REM ***iteratief systeem, twee rotaties***
            // REM ***symmetrische versie***
            // REM ***naam:FRACMC1***
            //    SCREEN 12 : CLS : RANDOMIZE 11
            GW.CLS();
            GW.RANDOMIZE(11);
            //    WINDOW (-2.4,-1.2)-(2.4,2.4)
            GW.WINDOW(-2.4f, -1.2f, 2.4f, 2.4f);
            //    KMAX=20000
            KMAX = 20000;
            // REM ***coefficienten***
            //    A=.6 : B=.4 : C=A : D=-B
            A = .6f;
            B = .4f;
            C = A;
            D = -B;
            //    X=1 : Y=0 : K=0  'start
            X = 1;
            Y = 0;
            K = 0;// 'start ;
                  //    DO WHILE K<KMAX AND INKEY$=""
            while (K < KMAX && GW.INKEY() == "")
            {
                //       R=RND
                R = GW.RND();
                //       IF R<.5 THEN
                if (R < .5f)
                {
                    //          X1=A*X-B*Y-1+A : Y1=B*X+A*Y+B  'rotatie (-1,0)
                    X1 = A * X - B * Y - 1 + A;
                    Y1 = B * X + A * Y + B;// 'rotatie (-1,0) ;
                                           //       ELSE
                }
                else
                {
                    //          X1=C*X-D*Y+1-C : Y1=D*X+C*Y-D  'rotatie (1,0)
                    X1 = C * X - D * Y + 1 - C;
                    Y1 = D * X + C * Y - D;// 'rotatie (1,0) ;
                                           //       END IF
                }
                //       X=X1 : Y=Y1
                X = X1;
                Y = Y1;
                //       PSET (X,Y) : PSET (-X,Y)
                GW.PSET(X, Y);
                GW.PSET(-X, Y);
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
