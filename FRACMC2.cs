using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class FRACMC2
    {
        public FRACMC2()
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
            float U = 0;
            float V = 0;
            // REM ***iteratief systeem, twee rotaties***
            // REM ***naam:FRACMC2***
            //    SCREEN 12 : CLS : RANDOMIZE 11
            GW.CLS();
            GW.RANDOMIZE(11);
            //    WINDOW (-2.4,-1.2)-(1.6,1.8)
            GW.WINDOW(-2.4f, -1.2f, 1.6f, 1.8f);
            //    KMAX=60000
            KMAX = 60000;
            // REM ***coefficienten***
            //    A=.6 : B=.45 : C=.5 : D=0
            A = .6f;
            B = .45f;
            C = .5f;
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
                    //          U=A*X-B*Y-1+A : V=B*X+A*Y+B  'rotatie L
                    U = A * X - B * Y - 1 + A;
                    V = B * X + A * Y + B;//  'rotatie L ;
                                          //       ELSE
                }
                else
                {
                    //          U=C*X-D*Y+1-C : V=D*X+C*Y-D  'rotatie R
                    U = C * X - D * Y + 1 - C;
                    V = D * X + C * Y - D;// 'rotatie R ;
                                          //       END IF
                }
                //       X=U : Y=V
                X = U;
                Y = V;
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
