using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class JULFILLX
    {
        public JULFILLX()
        {
            float A = 0;
            float B = 0;
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
            float S1 = 0;
            int SEL = 0;
            // REM ***gevulde julia set van z:=z^2+c ***
            // REM ***naam:JULFILLX***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            //    GW.PRINT( "maak een keuze met een getal uit 1,2,...,8"
            GW.PRINT("maak een keuze met een getal uit 1,2,...,8" );
            //    GW.INPUT( "getal = ",SEL : CLS
            SEL = (int)GW.INPUT("getal = ");
            GW.CLS();
            //    SELECT CASE SEL
            switch (SEL)
            {
                //       CASE 1
                case 1:
                    //          A=-1.275 : B=0 : DELH=1.8 : DELV=.8 : N1=240
                    A = -1.275f;
                    B = 0;
                    DELH = 1.8f;
                    DELV = .8f;
                    N1 = 240;
                    //       CASE 2
                    break;
                case 2:
                    //          A=-1 : B=0 : DELH=1.7 : DELV=1 : N1=240
                    A = -1;
                    B = 0;
                    DELH = 1.7f;
                    DELV = 1;
                    N1 = 240;
                    //       CASE 3
                    break;
                case 3:
                    //          A=-.75 : B=0 : DELH=1.6 : DELV=1.1 : N1=200
                    A = -.75f;
                    B = 0;
                    DELH = 1.6f;
                    DELV = 1.1f;
                    N1 = 200;
                    //       CASE 4
                    break;
                case 4:
                    //          A=.25 : B=0 : DELH=1 : DELV=1.3 : N1=120
                    A = .25f;
                    B = 0;
                    DELH = 1;
                    DELV = 1.3f;
                    N1 = 120;
                    //       CASE 5
                    break;
                case 5:
                    //          A=-.3905 : B=.5868 : DELH=1.5 : DELV=1.2 : N1=200
                    A = -.3905f;
                    B = .5868f;
                    DELH = 1.5f;
                    DELV = 1.2f;
                    N1 = 200;
                    //       CASE 6
                    break;
                case 6:
                    //          A=-.1226 : B=.7449 : DELH=1.4 : DELV=1.2 : N1=160
                    A = -.1226f;
                    B = .7449f;
                    DELH = 1.4f;
                    DELV = 1.2f;
                    N1 = 160;
                    //       CASE 7
                    break;
                case 7:
                    //          A=-.11 : B=.67 : DELH=1.4 : DELV=1.3 : N1=160
                    A = -.11f;
                    B = .67f;
                    DELH = 1.4f;
                    DELV = 1.3f;
                    N1 = 160;
                    //       CASE 8
                    break;
                case 8:
                    //          A=.3 : B=.04 : DELH=1.3 : DELV=1.3 : N1=160
                    A = .3f;
                    B = .04f;
                    DELH = 1.3f;
                    DELV = 1.3f;
                    N1 = 160;
                    //       CASE ELSE
                    break;
                default:
                    //          END
                    return;
                    //    END SELECT

            }
            //    N2=INT(N1*DELV/DELH)
            N2 = (int)(N1 * DELV / DELH);
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
                    if (GW.INKEY() != "")
                    {
                        return;
                    }
                    //       X=I*DELH/N1 : Y=J*DELV/N2
                    X = I * DELH / N1;
                    Y = J * DELV / N2;
                    //       FOR K=1 TO 100
                    S = 0;
                    for (K = 1; K <= 100 && S <= 1000; K++)
                    {
                        //          X1=X*X-Y*Y+A : Y1=2*X*Y+B
                        X1 = X * X - Y * Y + A;
                        Y1 = 2 * X * Y + B;
                        //          S=X*X+Y*Y : S1=(X-X1)*(X-X1)+(Y-Y1)*(Y-Y1)
                        S = X * X + Y * Y;
                        S1 = (X - X1) * (X - X1) + (Y - Y1) * (Y - Y1);
                        //          IF S>1000 THEN GOTO repeat
                        if (S <= 1000) // > 1000: function goes towards infinite
                        {
                            //          IF S1<.0001 THEN EXIT FOR
                            if (S1 < .0001) // result has been reached approximated value
                            {
                                break;
                            }
                            //          X=X1 : Y=Y1
                            X = X1;
                            Y = Y1;
                        }
                        //       NEXT K
                    }
                    //       PSET (I,J) : PSET (-I,-J)
                    if (S <= 1000)
                    {

                        GW.PSET(I, J);
                        GW.PSET(-I, -J);
                        //       IF B=0 THEN PSET (I,-J) : PSET (-I,J)
                        if (B == 0)
                        {
                            GW.PSET(I, -J);
                            GW.PSET(-I, J);
                        }
                        // repeat:
                    }
                    //    NEXT J : NEXT I : A$=INPUT$(1)
                }
            }
             // END
            return;
        }
    }
}
