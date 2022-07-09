using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class FRACMC4
    {
        public FRACMC4()
        {
            int KMAX = 0;
            float A = 0;
            float B = 0;
            float C = 0;
            float D = 0;
            float DET1 = 0;
            float DET2 = 0;
            float Q = 0;
            float X = 0;
            float Y = 0;
            int K = 0;
            float R = 0;
            float X1 = 0;
            float Y1 = 0;
            // REM ***iteratief systeem, twee spiegelingen***
            // REM ***naam:FRACMC4***
            //    SCREEN 12 : CLS : RANDOMIZE 11
            GW.CLS();
            GW.RANDOMIZE(11);
            //    WINDOW (-1.6,-1.2)-(1.6,1.2)
            GW.WINDOW(-1.6f, -1.2f, 1.6f, 1.2f);
            //    KMAX=40000
            KMAX = 40000;
            // REM ***coefficienten***
            //    A=.5 : B=.5 : C=.6667 : D=0
            A = .5f;
            B = .5f;
            C = .6667f;
            D = 0;
            //    DET1=A*A+B*B : DET2=C*C+D*D
            DET1 = A * A + B * B;
            DET2 = C * C + D * D;
            //    Q=DET1/(DET1+DET2)
            Q = DET1 / (DET1 + DET2);
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
                    //          X1=A*X+B*Y-1+A : Y1=B*X-A*Y+B  'spiegeling L
                    X1 = A * X + B * Y - 1 + A;
                    Y1 = B * X - A * Y + B;//  'spiegeling L ;
                                           //       ELSE
                }
                else
                {
                    //          X1=C*X+D*Y+1-C : Y1=D*X-C*Y-D  'spiegeling R
                    X1 = C * X + D * Y + 1 - C;
                    Y1 = D * X - C * Y - D;//  'spiegeling R ;
                                           //       END IF
                }
                //       X=X1 : Y=Y1
                X = X1;
                Y = Y1;
                //       PSET (X,Y),10
                GW.PSET(X, Y, 10);
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
