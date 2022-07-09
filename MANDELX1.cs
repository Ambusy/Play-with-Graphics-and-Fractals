using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Graphics_boek
{
    class MANDELX1
    {
        public MANDELX1()
        {
            /*
             *         window(-320, -240, 319, 239)
        n2 = Int(n1 * DelV / DelH)
        REM ***hoofdprogramma***
        For I = -n1 To n1
            A = AC + I * DelH / n1
            For J = 0 To n2
                B = J * DelV / n2
                U = 4 * (A * A + B * B)
                V = U - 2 * A + 1 / 4
                'If U + 8 * A + 15 / 4 < 0 Then L = 0 : K = 4 : GoTo repeat
                'If V - Math.Sqrt(V) + 2 * A - 1 / 2 < 0 Then L = 0 : K = 4 : GoTo repeat
                X = A
                Y = B
                k = 0
                Do
                    Z = X
                    X = X * X - Y * Y + A
                    Y = 2 * Z * Y + B
                    S = X * X + Y * Y
                    k = k + 1
                Loop Until S > 100 Or k = 50
                If k < 40 Then L = 1 + k Mod 8 Else L = 0
                'repeat:
                If K > 3 Then
                    pset(I, J, L)
                    pset(I, -J, L)
                End If
            Next J
        Next I
             */
            float DELH = 0;
            float DELV = 0;
            float AC = 0;
            int N1 = 0;
            int N2 = 0;
            int I = 0;
            float A = 0;
            int J = 0;
            float B = 0;
            float U = 0;
            float V = 0;
            int L = 0;
            float X = 0;
            float Y = 0;
            int K = 0;
            float Z = 0;
            float S = 0;
            // REM ***totaalbeeld van de kwadratische Mandelbrot set***
            // REM ***naam:MANDELX1***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            //    DELH=1.6 : DELV=1.34 : AC=-.65
            DELH = 1.6f;
            DELV = 1.34f;
            AC = -.65f;
            //    N1=260 : N2=INT(N1*DELV/DELH)
            N1 = 240;
            N2 = (int)(N1 * DELV / DELH);
            // REM ***kleuren***
            //    DIM COL(8) : DATA 0,1,9,2,10,4,12,6,14
            int[] COL = new int[] { 0, 1, 9, 2, 10, 4, 12, 6, 14 };
            //    FOR I=0 TO 8 : READ COL(I) : NEXT I
            // REM ***hoofdprogramma***
            //    LINE (N1+1,N2+1)-(-N1-1,-N2-1),4,B
            GW.LINE(N1 + 1, N2 + 1, -N1 - 1, -N2 - 1, 4, "B");
            //    FOR I=-N1 TO N1 : A=AC+I*DELH/N1
            for (I = -N1; I <= N1; I++)
            {
                A = AC + I * DELH / N1;
                //       FOR J=0 TO N2 : B=J*DELV/N2
                for (J = 0; J <= N2; J++)
                {
                    B = J * DELV / N2;
                    //          U=4*(A*A+B*B) : V=U-2*A+1/4
                    U = 4 * (A * A + B * B);
                    V = U - 2 * A + 1f / 4f;
                    //          IF U+8*A+15/4<0 THEN L=0 : GOTO repeat
                    //          IF V-GW.SQR(V)+2*A-1/2<0 THEN L=0 : GOTO repeat
                    if ((U + 8 * A + 15 / 4f < 0)
                    || (V - GW.SQR(V) + 2 * A - 1 / 2f < 0))
                    {
                        L = 0;
                    }
                    else
                    {

                        //          X=A : Y=B : K=0
                        X = A;
                        Y = B;
                        K = 0;
                        //          DO
                        do
                        {
                            //             Z=X : X=X*X-Y*Y+A : Y=2*Z*Y+B
                            Z = X;
                            X = X * X - Y * Y + A;
                            Y = 2 * Z * Y + B;
                            //             S=X*X+Y*Y : K=K+1
                            S = X * X + Y * Y;
                            K = K + 1;
                            //          LOOP UNTIL S>100 OR K=50
                        } while (!(S > 100 || K == 50));
                        //          IF K<40 THEN L=1+K MOD 8 ELSE L=0
                        if (K < 40)
                        {
                            L = 1 + K % 8;
                        }
                        else
                        {
                            L = 0;
                        }
                        //          IF K>3 THEN
                        if (K > 3)
                        {
                            //             PSET (I,J),COL(L) : PSET (I,-J),COL(L)
                            GW.PSETe(I, J, COL[L]);
                            GW.PSETe(I, -J, COL[L]);
                            //          END IF
                        }
                    }
                    // repeat:
                    //          IF GW.INKEY()<>"" THEN END
                    if (GW.INKEY() != "")
                    {
                        return;
                    }
                    //       NEXT J
                }
                //    NEXT I : A$=INPUT$(1)
            }
            //As=INPUTS(1);
            // END
            return;
            // 
        }
    }
}
