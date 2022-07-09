using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class VAREN
    {
        public VAREN()
        {
            float D1 = 0;
            float A2 = 0;
            float B2 = 0;
            float C2 = 0;
            float D2 = 0;
            float F2 = 0;
            float A3 = 0;
            float B3 = 0;
            float C3 = 0;
            float D3 = 0;
            float F3 = 0;
            float A4 = 0;
            float B4 = 0;
            float C4 = 0;
            float D4 = 0;
            float F4 = 0;
            float Q1 = 0;
            float Q2 = 0;
            float Q3 = 0;
            int KMAX = 0;
            int K = 0;
            float X = 0;
            float Y = 0;

            float Z = 0;
            // REM ***fractal in de vorm van een varenblad***
            // REM ***data ontleend aan Barnsley's boek***
            // REM ***naam:VAREN***
            //    SCREEN 12 : CLS : RANDOMIZE 11
            GW.CLS();
            GW.RANDOMIZE(11);
            //    WINDOW (-1,-4.5)-(11,4.5)
            GW.WINDOW(-1f, -4.5f, 11f, 4.5f);
            // REM ***coefficienten***
            //    D1=.16
            D1 = .16f;
            //    A2=.85 : B2=.04 : C2=-.04 : D2=.85 : F2=1.6
            A2 = .85f;
            B2 = .04f;
            C2 = -.04f;
            D2 = .85f;
            F2 = 1.6f;
            //    A3=.2 : B3=-.26 : C3=.23 : D3=.22 : F3=1.6
            A3 = .2f;
            B3 = -.26f;
            C3 = .23f;
            D3 = .22f;
            F3 = 1.6f;
            //    A4=-.15 : B4=.28 : C4=.26 : D4=.24 : F4=.44
            A4 = -.15f;
            B4 = .28f;
            C4 = .26f;
            D4 = .24f;
            F4 = .44f;
            // REM ***kansverdeling***
            //    Q1=.01 : Q2=.86 : Q3=.93
            Q1 = .01f;
            Q2 = .76f;
            Q3 = .93f;
            //    KMAX=40000 : K=0 : X=0 : Y=0  'start
            KMAX = 40000;
            K = 0;
            X = 0;
            Y = 0;//  'start ;
                  //    DO WHILE K<KMAX AND INKEY$=""
            while (K < KMAX && GW.INKEY() == "")
            {
                //       R=RND
                float R = GW.RND();
                //       SELECT CASE R
                //       CASE <Q1
               if (R < Q1)
                {
                    //          X=0 : Y=D1*Y
                    X = 0;
                    Y = D1 * Y;
                    //       CASE Q1 TO Q2
                }
                else if (R >= Q1 && R <= Q2)
                {
                    //          Z=X : X=A2*X+B2*Y : Y=C2*Z+D2*Y+F2
                    Z = X;
                    X = A2 * X + B2 * Y;
                    Y = C2 * Z + D2 * Y + F2;
                    //       CASE Q2 TO Q3
                }
                else if (R >= Q2 && R <= Q3)
                {
                    //          Z=X : X=A3*X+B3*Y : Y=C3*Z+D3*Y+F3
                    Z = X;
                    X = A3 * X + B3 * Y;
                    Y = C3 * Z + D3 * Y + F3;
                    //       CASE >Q3
                }
                else if (R > Q3)
                {
                    //          Z=X : X=A4*X+B4*Y : Y=C4*Z+D4*Y+F4
                    Z = X;
                    X = A4 * X + B4 * Y;
                    Y = C4 * Z + D4 * Y + F4;
                    //       END SELECT
                }
                //       PSET (Y,X),10
                GW.PSET(Y, X, 10);
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
