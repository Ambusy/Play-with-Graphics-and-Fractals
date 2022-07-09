using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class MANDELX3
    {
        public MANDELX3()
        {
            float DELH = 0;
            float DELV = 0;
            int N1 = 0;
            int N2 = 0;
            int I = 0;
            float A = 0;
            int J = 0;
            float B = 0;
            float X = 0;
            float Y = 0;
            int K = 0;
            float S = 0;
            float S2 = 0;
            int L = 0;
            float X2 = 0;
            float Y2 = 0;
            float XR = 0;
            float YR = 0;
            float X1 = 0;
            float Y1 = 0;
            string As = "";
            // REM ***Mandelbrot set van z'=c*(z*z+1/z*z)***
            // REM ***naam:MANDELX3***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    DEFDBL A,B,D,X,Y,S
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            //    DELH=.8 : DELV=.8
            DELH = .8f;
            DELV = .8f;
            //    N1=200 : N2=INT(N1*DELV/DELH)
            N1 = 200;
            N2 = (int)(N1 * DELV / DELH);
            // REM ***hoofdprogramma***
            //    FOR I=0 TO N1 : A=I*DELH/N1
            for (I = 0; I <= N1; I++)
            {
                A = I * DELH / (float)N1;
                //       FOR J=0 TO N2 : B=J*DELV/N2
                for (J = 0; J <= N2; J++)
                {
                    B = J * DELV / (float)N2;
                    //          X=1 : Y=0
                    X = 1;
                    Y = 0;
                    //          FOR K=1 TO 100
                    bool left = false;
                    for (K = 1; K <= 100; K++)
                    {
                        //             S=X*X+Y*Y : S2=S*S+1E-8
                        S = X * X + Y * Y;
                        S2 = S * S + 1E-8f;
                        //             IF S>64 THEN L=1+K MOD 14 : GOTO graphics
                        if (S > 64)
                        {
                            L = 1 + K % 14;
                            left=true;
                            break;
                        }
                        //             X2=X*X-Y*Y : Y2=2*X*Y
                        X2 = X * X - Y * Y;
                        Y2 = 2 * X * Y;
                        //             XR=X2/S2 : YR=-Y2/S2
                        XR = X2 / S2;
                        YR = -Y2 / S2;
                        //             X1=X2+XR : Y1=Y2+YR
                        X1 = X2 + XR;
                        Y1 = Y2 + YR;
                        //             X=A*X1-B*Y1 : Y=A*Y1+B*X1
                        X = A * X1 - B * Y1;
                        Y = A * Y1 + B * X1;
                        //          NEXT K : L=9
                    }
                    if (!left) L = 9;
                    // graphics:
                    //          PSET (I,J),L : PSET (I,-J),L
                    GW.PSETe(I, J,L);
                    GW.PSETe(I, -J,L);
                    //          PSET (-I,J),L : PSET (-I,-J),L
                    GW.PSETe(-I, J,L);
                    GW.PSETe(-I, -J,L);
                    //          IF GW.INKEY()<>"" THEN END
                    if (GW.INKEY() != "")
                    {
                        return;
                    }
                    //       NEXT J
                }
                //    NEXT I : A$=INPUT$(1)
            }
            //As = INPUTs(1);
            // END
            return;
            // 
            ;
        }
    }
}
