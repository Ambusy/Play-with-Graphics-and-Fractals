using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class JULFILL
    {
        public JULFILL()
        {
            float A = 0;
            float B = 0;
            int KMAX = 0;
            float DELH = 0;
            float DELV = 0;
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
            // REM ***gevulde julia set van z*z+c ***
            // REM ***naam:JULFILL***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-320,-240)-(319,239) these window parameters cause the filling to omit pixels on a larger screen
            GW.WINDOW(-320f, -240f, 319f, 239f);
            //    A=-.8 : B=.15  'parameters
            A = -.8f;
            B = .15f; 
                     //    KMAX=200 : DELH=1.6 : DELV=1
            KMAX = 200;
            DELH = 1.6f;
            DELV = 1;
            //    N1=250 : N2=INT(N1*DELV/DELH)
            N1 = 250;
            N2 = (int)(N1 * DELV / DELH);
            //    LINE (-N1,-N2)-(N1,N2),4,B
            GW.LINE(-N1, -N2, N1, N2, 4, "BF");
            //    IF B=0 THEN N3=0 ELSE N3=-N2
            if (B == 0)
            {
                N3 = 0;
            }
            else
            {
                N3 = -N2;
            }
            //    FOR I=0 TO N1 : FOR J=N3 TO N2
            for (I = 0; I <= N1; I++)
            {
                for (J = N3; J <= N2; J++)
                {
                    //       IF GW.INKEY()<>"" THEN END
                    if (GW.INKEY() != "") return;
                    //       X=I*DELH/N1 : Y=J*DELV/N2
                    X = I * DELH / N1;
                    Y = J * DELV / N2;
                    //       FOR K=1 TO KMAX
                    S = 0;
                    for (K = 1; K <= KMAX && S <= 1000; K++)
                    {
                        //          X1=X*X-Y*Y+A : Y1=2*X*Y+B : S=X*X+Y*Y
                        S = X * X + Y * Y;
                        //          IF S>1000 THEN GOTO repeat
                        if (S <= 1000) // > 1000: function goes towards infinite
                        {
                            X1 = X * X - Y * Y + A;
                            Y1 = 2 * X * Y + B;
                            //          X=X1 : Y=Y1
                            X = X1;
                            Y = Y1;
                        }
                        //       NEXT K
                    }
                    if (S <= 1000)
                    {
                        //       PSET (I,J) : PSET (-I,-J)
                        GW.PSET(I, J);
                        GW.PSET(-I, -J);
                        //       IF B=0 THEN PSET (I,-J) : PSET (-I,J)
                        if (B == 0)
                        {
                            GW.PSET(I, -J);
                            GW.PSET(-I, J);
                        }
                    }
                    // repeat:
                    //    NEXT J : NEXT I
                }
            }
            // END
            return;
            // 
            ;
        }
    }
}
