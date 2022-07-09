using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class JULIAP
    {
        public JULIAP()
        {
            float A = 0;
            float B = 0;
            float DELH = 0;
            float DELV = 0;
            int KMAX = 0;
            int N1 = 0;
            int N2 = 0;
            int N3 = 0;
            int I = 0;
            int J = 0;
            float X = 0;
            float Y = 0;
            int K = 0;
            float X1 = 0;
            float Y1 = 0;
            float S = 0;
            float S1 = 0;
            int L = 0;
            // REM ***Julia set van z*z+c basisprogramma***
            // REM ***naam:JULIAP***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            //    A=-.55 : B=0  'parameters
            A = -.55f;
            B = 0;// 'parameters ;
//    DELH=1.6 : DELV=1.2 : KMAX=100
   DELH = 1.6f;
            DELV = 1.2f;
            KMAX = 100;
            //    N1=200 : N2=INT(N1*DELV/DELH)
            N1 = 200;
            N2 = (int)(N1 * DELV / DELH);
            //    IF B=0 THEN N3=0 ELSE N3=N2
            if (B == 0)
            {
                N3 = 0;
            }
            else
            {
                N3 = N2;
            }
            //    FOR I=0 TO N1 : FOR J=-N3 TO N2
            for (I = 0; I <= N1; I++)
            {
                for (J = -N3; J <= N2; J++)
                {
                    //       IF GW.INKEY()<>"" THEN END
                    if (GW.INKEY() != "")
                    {
                        return;
                    }
                    //       X=I*DELH/N1 : Y=J*DELV/N2
                    X = I * DELH / N1;
                    Y = J * DELV / N2;
                    //       FOR K=1 TO KMAX
                    L = 0;  
                    for (K = 1; K <= KMAX; K++)
                    {
                        //          X1=X*X-Y*Y+A : Y1=2*X*Y+B
                        X1 = X * X - Y * Y + A;
                        Y1 = 2 * X * Y + B;
                        //          S=X*X+Y*Y : S1=(X-X1)*(X-X1)+(Y-Y1)*(Y-Y1)
                        S = X * X + Y * Y;
                        S1 = (X - X1) * (X - X1) + (Y - Y1) * (Y - Y1);
                        //          IF S>1000 THEN L=1+K MOD 15 : GOTO graphics
                        if (S > 1000)
                        {
                            L = 1 + K % 15;
                            break;
                        }
                        //          IF S1<.0001 THEN L=1+K MOD 15 : GOTO graphics
                        if (S1 < .0001)
                        {
                            L = 1 + K % 15;
                            break;
                        }
                        //          X=X1 : Y=Y1
                        X = X1;
                        Y = Y1;
                        //       NEXT K : L=0
                    }
                    //  L = 0; moved up
                    // graphics:
                    //       PSET (I,J),L : PSET (-I,-J),L
                    GW.PSETe(I, J,L);
                    GW.PSETe(-I, -J,L);
                    //       IF B=0 THEN PSET (I,-J),L : PSET (-I,J),L
                    if (B == 0)
                    {
                        GW.PSETe(I, -J,L);
                        GW.PSETe(-I, J,L);
                    }
                    //    NEXT J : NEXT I
                }
            }
            // END
            return;
            // 
        }
    }
}
