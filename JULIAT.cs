using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Graphics_boek
{
    class JULIAT
    {
        public JULIAT()
        {
            float EPS = 0;
            float A = 0;
            float B = 0;
            float DELH = 0;
            float DELV = 0;
            int I = 0;
            int N1 = 0;
            int N2 = 0;
            int N3 = 0;
            int J = 0;
            float X = 0;
            float Y = 0;
            int K = 0;
            float S = 0;
            float X2 = 0;
            float Y2 = 0;
            float X4 = 0;
            float Y4 = 0;
            float X8 = 0;
            float Y8 = 0;
            float U = 0;
            float V = 0;
            float D2 = 0;
            float D1 = 0;
            int SEL = 0;
            int L = 0;
            // REM ***julia fractal van z:=z^8+z^4+c ***
            // REM ***name:JULIAT***
            //    SCREEN 12 : CLS : EPS=.00001
            GW.CLS();
            EPS = .00001f;
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            //    GW.PRINT( "maak een keuze uit 1,2,3" : PRINT
            GW.PRINT("maak een keuze uit 1,2,3"  );
            GW.PRINT("");
            //    GW.INPUT( "keuzegetal = ",SEL : CLS
            SEL = (int)GW.INPUT("keuzegetal = ");
            GW.CLS();
            //    SELECT CASE SEL
            switch (SEL)
            {
                //    CASE 1
                case 1:
                    //       A=0 : B=.2 : DELH=.95 : DELV=.95
                    A = 0;
                    B = .2f;
                    DELH = .95f;
                    DELV = .95f;
                    //    CASE 2
                    break;
                case 2:
                    //       A=.3 : B=0 : DELH=.95 : DELV=.95
                    A = .3f;
                    B = 0;
                    DELH = .95f;
                    DELV = .95f;
                    //    CASE 3
                    break;
                case 3:
                    //       A=-.5 : B=0 : DELH=.95 : DELV=.95
                    A = -.5f;
                    B = 0;
                    DELH = .95f;
                    DELV = .95f;
                    //    END SELECT
                    break;
                default:
                    break;
            }
            // REM ***kleuren***
            //    DIM COL(6) : DATA 0,1,9,4,12,2,10
            int[] COL = new int[] { 0, 1, 9, 4, 12, 2, 10 };
            //    FOR I=0 TO 6 : READ COL(I) : NEXT I         
            // REM ***grootte plaatje***
            //    N1=160 : N2=INT(N1*DELV/DELH)
            N1 = 160;
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
            // REM ***hoofdprogramma***
            //    FOR I=0 TO N1 : FOR J=-N3 TO N2
            Debug.WriteLine("10,10 "+ GW.TransformX(10).ToString() + " " + GW.TransformY(10).ToString());
            Debug.WriteLine("11,11 "+ GW.TransformX(11).ToString() + " " + GW.TransformY(11).ToString());
            Debug.WriteLine("12,12 "+ GW.TransformX(12).ToString() + " " + GW.TransformY(12).ToString());
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
                    //       FOR K=1 TO 100
                    L = 0;
                    for (K = 1; K <= 100; K++)
                    {
                        //          S=X*X+Y*Y
                        S = X * X + Y * Y;
                        //          IF S>40 THEN GOTO herhaal
                        if (S > 40)
                        {
                            break;
                        }
                        //          X2=X*X-Y*Y : Y2=2*X*Y
                        X2 = X * X - Y * Y;
                        Y2 = 2 * X * Y;
                        //          X4=X2*X2-Y2*Y2 : Y4=2*X2*Y2
                        X4 = X2 * X2 - Y2 * Y2;
                        Y4 = 2 * X2 * Y2;
                        //          X8=X4*X4-Y4*Y4 : Y8=2*X4*Y4
                        X8 = X4 * X4 - Y4 * Y4;
                        Y8 = 2 * X4 * Y4;
                        //          U=X8+X4+A : V=Y8+Y4+B
                        U = X8 + X4 + A;
                        V = Y8 + Y4 + B;
                        //          D1=ABS(X-U) : D2=ABS(Y-V)
                        D1 = GW.ABS(X - U);
                        D2 = GW.ABS(Y - V);
                        //          IF D1<EPS AND D2<40*EPS THEN L=1+K MOD 6 : GOTO graphics
                        if (D1 < EPS && D2 < 40 * EPS)
                        {
                            L = 1 + K % 6;
                            break;
                        }
                        //          IF D2<EPS AND D1<40*EPS THEN L=1+K MOD 6 : GOTO graphics
                        if (D2 < EPS && D1 < 40 * EPS)
                        {
                            L = 1 + K % 6;
                            break;
                        }
                        //          X=U : Y=V
                        X = U;
                        Y = V;
                        //       NEXT K : L=0 MOVED UP
                    }
                    // graphics:
                    if (S <= 40)
                    {

                        //       PSET (I,-J),COL(L) : PSET (-I,J),COL(L)
                        GW.PSETe(I, -J, COL[L]);
                        GW.PSETe(-I, J, COL[L]);
                        //       IF B=0 THEN PSET (I,J),COL(L) : PSET (-I,-J),COL(L)
                        if (B == 0)
                        {
                            GW.PSETe(I, J, COL[L]);
                            GW.PSETe(-I, -J, COL[L]);
                        }
                     }
                       // herhaal:
                    //    NEXT J : NEXT I
                }
            }
            // END
            return;
            // 
        }
    }
}
