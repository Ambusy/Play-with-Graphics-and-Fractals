using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class JULIAPX
    {
        public JULIAPX()
        {
            int I = 0;
            float A = 0;
            float B = 0;
            float DELH = 0;
            float DELV = 0;
            int KMAX = 0;
            int N1 = 0;
            float P = 0;
            int N2 = 0;
            int N3 = 0;
            int J = 0;
            float X = 0;
            float Y = 0;
            int K = 0;
            float X1 = 0;
            float Y1 = 0;
            float S = 0;
            float S1 = 0;
            int SEL;
            int L = 0;
            // REM ***Julia set van z*z+c, zes voorbeelden***
            // REM ***name:JULIAPX***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            // REM ***kleuren***
            //    DIM COL(8) : DATA 0,1,9,2,10,4,12,6,14
            int[] COL = new int[] { 0, 1, 9, 2, 10, 4, 12, 6, 14 };
            //    FOR I=0 TO 8 : READ COL(I) : NEXT I
            //    GW.PRINT( "maak een keuze met een getal uit 1,2,...,6"
            GW.PRINT("maak een keuze met een getal uit 1,2,...,6");
            //    GW.INPUT( "keuze = ",SEL : CLS
            SEL = (int)GW.INPUT("keuze = ");
            GW.CLS();
            //    SELECT CASE SEL
            switch (SEL)
            {
                //       CASE 1
                case 1:
                    //          A=-1.029 : B=.3863 : DELH=2 : DELV=1.2
                    A = -1.029f;
                    B = .3863f;
                    DELH = 2;
                    DELV = 1.2f;
                    //          KMAX=100 : N1=240 : P=1
                    KMAX = 100;
                    N1 = 240;
                    P = 1;
                    //       CASE 2
                    break;
                case 2:
                    //          A=-.75 : B=0 : DELH=1.8 : DELV=1.2
                    A = -.75f;
                    B = 0;
                    DELH = 1.8f;
                    DELV = 1.2f;
                    //          KMAX=50 : N1=240 : P=1
                    KMAX = 50;
                    N1 = 240;
                    P = 1;
                    //       CASE 3
                    break;
                case 3:
                    //          A=-.7454 : B=.1103 : DELH=1.6 : DELV=1
                    A = -.7454f;
                    B = .1103f;
                    DELH = 1.6f;
                    DELV = 1;
                    //          KMAX=200  : N1=200 : P=5
                    KMAX = 200;
                    N1 = 200;
                    P = 5;
                    //       CASE 4
                    break;
                case 4:
                    //          A=-.55 : B=0 : DELH=1.6 : DELV=1.2
                    A = -.55f;
                    B = 0;
                    DELH = 1.6f;
                    DELV = 1.2f;
                    //          KMAX=100 : N1=200 : P=1
                    KMAX = 100;
                    N1 = 200;
                    P = 1;
                    //       CASE 5
                    break;
                case 5: // figuur van Douady
                    //          A=-.1226 : B=.7449 : DELH=1.7 : DELV=1.5
                    A = -.1226f;
                    B = .7449f;
                    DELH = 1.7f;
                    DELV = 1.5f;
                    //          KMAX=100  : N1=180 : P=1
                    KMAX = 100;
                    N1 = 180;
                    P = 1;
                    //       CASE 6
                    break;
                case 6:
                    //          A=.1 : B=.3 : DELH=1.5 : DELV=1.5 : KMAX=50
                    A = .1f;
                    B = .3f;
                    DELH = 1.5f;
                    DELV = 1.5f;
                    KMAX = 50;
                    //          KMAX=100 : N1=160 : P=1
                    KMAX = 100;
                    N1 = 160;
                    P = 1;
                    //       CASE ELSE
                    //    END SELECT
                    break;
                default:
                    break;
            }
            //    N2=INT(N1*DELV/DELH)
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
                        //          IF S>  1000 THEN L=1+INT(K/P) MOD 8 : GOTO graphics
                        //          IF S1<.0001 THEN L=1+INT(K/P) MOD 8 : GOTO graphics
                        if (S > 1000 || S1 < .0001f)
                        {
                            L = 1 + (int)(K / P) % 8;
                            break;
                        }
                        //          X=X1 : Y=Y1
                        X = X1;
                        Y = Y1;
                        //       NEXT K : L=0 moved up
                    }
                    // graphics:
                    //       PSET (I,J),COL(L) : PSET (-I,-J),COL(L)
                    GW.PSETe(I, J, COL[L]);
                    GW.PSETe(-I, -J, COL[L]);
                    //       IF B=0 THEN PSET (I,-J),COL(L) : PSET (-I,J),COL(L)
                    if (B == 0)
                    {
                        GW.PSETe(I, -J, COL[L]);
                        GW.PSETe(-I, J, COL[L]);
                    }
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
