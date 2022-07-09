using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class FRACMC3
    {
        public FRACMC3()
        {
            int KMAX = 0;
            float A = 0;
            float B = 0;
            float C = 0;
            float D = 0;
            float F1 = 0;
            float F2 = 0;
            float Q = 0;
            float X = 0;
            float Y = 0;
            int K = 0;
            float R = 0;
            float X1 = 0;
            float Y1 = 0;
            // REM ***iteratief systeem, twee rotaties***
            // REM ***naam:FRACMC3***
            //    SCREEN 12 : CLS : RANDOMIZE 11
            GW.CLS();
            GW.RANDOMIZE(11);
            //    WINDOW (-3.5,-2.1)-(2.1,2.1)
            GW.WINDOW(-3.5f, -2.1f, 2.1f, 2.1f);
            //    KMAX=20000
            KMAX = 20000;
            // REM ***coefficienten***
            //    A=.65 : B=.65 : C=.1 : D=-.1
            A = .65f;
            B = .65f;
            C = .1f;
            D = -.1f;
            //    F1=SQR(A*A+B*B) : F2=SQR(C*C+D*D)
            F1 = GW.SQR(A * A + B * B);
            F2 = GW.SQR(C * C + D * D);
            //    Q=F1/(F1+F2)
            Q = F1 / (F1 + F2);
            //    X=1 : Y=0  : K=0  'start
            X = 1;
            Y = 0;
            K = 0;// 'start ;
                  //    DO WHILE K<KMAX AND INKEY$=""
            while (K < KMAX && GW.INKEY() == "")
            {
                //       R=RND
                R = GW.RND();
                //       IF R<Q THEN
                if (R < Q)
                {
                    //          X1=A*X-B*Y-1+A : Y1=B*X+A*Y+B  'rotatie L
                    X1 = A * X - B * Y - 1 + A;
                    Y1 = B * X + A * Y + B;// 'rotatie L ;
                                           //       ELSE
                }
                else
                {
                    //          X1=C*X-D*Y+1-C : Y1=D*X+C*Y-D  'rotatie R
                    X1 = C * X - D * Y + 1 - C;
                    Y1 = D * X + C * Y - D;// 'rotatie R ;
                                           //       END IF
                }
                //       X=X1 : Y=Y1
                X = X1;
                Y = Y1;
                //       PSET (X,Y)
                GW.PSET(X, Y);
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
