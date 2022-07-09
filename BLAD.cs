using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class BLAD
    {
        public BLAD()
        {
            float A = 0;
            float PHI = 0;
            int KMAX = 0;
            float R1 = 0;
            float R2 = 0;
            float R3 = 0;
            float Q1 = 0;
            float Q2 = 0;
            float C = 0;
            float S = 0;
            float X = 0;
            float Y = 0;
            int K = 0;

            float Z = 0;
            // REM ***fractal in de vorm van een boomblad***
            // REM ***naam:BLAD***
            //    SCREEN 12 : CLS : RANDOMIZE 11
            GW.CLS();
            GW.RANDOMIZE(11);
            //    WINDOW (-1,-.4)-(1,1.1)
            GW.WINDOW(-1f, -.4f, 1f, 1.1f);
            //    A=.2 : PHI=1 : KMAX=30000
            A = .2f;
            PHI = 1;
            KMAX = 30000;
            //    R1=.7 : R2=.4 : R3=.7
            R1 = .7f;
            R2 = .4f;
            R3 = .7f;
            //    Q1=.36 : Q2=1-Q1
            Q1 = .36f;
            Q2 = 1 - Q1;
            //    C=COS(PHI) : S=SIN(PHI)
            C = GW.COS(PHI);
            S = GW.SIN(PHI);
            //    X=0 : Y=1
            X = 0;
            Y = 1;
            //    FOR K=1 TO KMAX
            for (K = 1; K <= KMAX; K++)
            {
                //       IF INKEY$<>"" THEN END
                if (GW.INKEY() != "")
                {
                    return;
                }
                //       R=RND
                float R = GW.RND();
                //       SELECT CASE R
                //          CASE <Q1
                if (R < Q1)
                {
                    //             X=R1*X : Y=R1*Y
                    X = R1 * X;
                    Y = R1 * Y;
                    //          CASE <Q2
                }
                else if (R < Q2)
                {
                    //             X=R2*X : Y=R2*(Y-1)+1
                    X = R2 * X;
                    Y = R2 * (Y - 1) + 1;
                    //          CASE ELSE
                }
                else
                {
                    //             Z=X : X=R3*(C*X-S*Y)
                    Z = X;
                    X = R3 * (C * X - S * Y);
                    //             IF RND<.5 THEN X=-X
                    if (GW.RND() < .5)
                    {
                        X = -X;
                    }
                    //             Y=R3*(S*Z+C*Y)+A
                    Y = R3 * (S * Z + C * Y) + A;
                    //       END SELECT
                }
                //       PSET (X,Y),10 : PSET (-X,Y),10
                GW.PSET(X, Y, 10);
                GW.PSET(-X, Y, 10);
                //    NEXT K : BEEP
            }
            // END
            return;
            // 
        }
    }
}
