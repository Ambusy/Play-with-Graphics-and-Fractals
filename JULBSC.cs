using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class JULBSC
    {
        public JULBSC()
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
            float T = 0;
            float X = 0;
            float Y = 0;
            string As = "";
            int K = 0;
            float X1 = 0;
            float Y1 = 0;
            // REM ***Julia set van z^2+c, boundary scanning***
            // REM ***naam:JULBSC***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            //    A=-.12 : B=.74
            A = -.12f;
            B = .74f;
            //    DELH=1.3 : DELV=1.3
            DELH = 1.3f;
            DELV = 1.3f;
            //    KMAX=80 : N1=200 : N2=INT(N1*DELV/DELH)
            KMAX = 80;
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
            //    LINE (-N1,-N2)-(N1,N2),9,B
            GW.LINE(-N1, -N2, N1, N2, 9, "B");
            //    FOR I=0 TO N1 : FOR J=-N3 TO N2
            for (I = 0; I <= N1; I++)
            {
                for (J = -N3; J <= N2; J++)
                {
                    //       T=0 : IF GW.INKEY()<>"" THEN END
                    T = 0;
                    if (GW.INKEY() != "")
                    {
                        return;
                    }
                    //       X=(I+.5)*DELH/N1 : Y=(J-.5)*DELV/N2
                    X = (I + .5f) * DELH / N1;
                    Y = (J - .5f) * DELV / N2;
                    //       GOSUB jcycle
                    jcycle();
                    //       X=(I+.5)*DELH/N1 : Y=(J+.5)*DELV/N2
                    X = (I + .5f) * DELH / N1;
                    Y = (J + .5f) * DELV / N2;
                    //       GOSUB jcycle
                    jcycle();
                    //       X=(I-.5)*DELH/N1 : Y=(J+.5)*DELV/N2
                    X = (I - .5f) * DELH / N1;
                    Y = (J + .5f) * DELV / N2;
                    //       GOSUB jcycle
                    jcycle();
                    //       X=(I-.5)*DELH/N1 : Y=(J-.5)*DELV/N2
                    X = (I - .5f) * DELH / N1;
                    Y = (J - .5f) * DELV / N2;
                    //       GOSUB jcycle
                    jcycle();
                    //     =  IF T=0 OR T=4 THEN GOTO repeat
                    if (!(T == 0 || T == 4))
                    {
                        //       PSET (I,J),14 : PSET (-I,-J),14
                        GW.PSET(I, J,14);
                        GW.PSET(-I, -J,14);
                        //       IF B=0 THEN PSET (I,-J),14 : PSET (-I,J),14
                        if (B == 0)
                        {
                            GW.PSET(I, -J,14);
                            GW.PSET(-I, J,14);
                        }
                        // repeat:
                    }
                    //    NEXT J : NEXT I : A$=INPUT$(1)
                }
            }
            GW.LOCATE(24, 1);
            GW.PRINT("Einde: druk op een toets");
            As = GW.INPUTS(1);
            // END
            return;
            // jcycle:
            void jcycle()
            {
                //    FOR K=1 TO KMAX
                for (K = 1; K <= KMAX; K++)
                {
                    //       X1=X*X-Y*Y+A : Y1=2*X*Y+B
                    X1 = X * X - Y * Y + A;
                    Y1 = 2 * X * Y + B;
                    //       IF X1*X1+Y1*Y1>4 THEN
                    if (X1 * X1 + Y1 * Y1 > 4)
                    {
                        //          T=T+1 : EXIT FOR
                        T = T + 1;
                        break;
                        //       END IF
                    }
                    //       X=X1 : Y=Y1
                    X = X1;
                    Y = Y1;
                    //    NEXT K
                }
                // RETURN
            }
        }
    }
}
