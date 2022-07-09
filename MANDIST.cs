using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class MANDIST
    {
        public MANDIST()
        {
            float AC = 0;
            float BC = 0;
            float DELH = 0;
            float DELV = 0;
            int N1 = 0;
            int N2 = 0;
            int KMAX = 0;
            int I = 0;
            int J = 0;
            float A = 0;
            float B = 0;
            float X = 0;
            float Y = 0;
            float U = 0;
            float V = 0;
            int K = 0;
            float X1 = 0;
            float Y1 = 0;
            float U1 = 0;
            float V1 = 0;
            float S1 = 0;
            float S2 = 0;
            float S3 = 0;

            string As = "";
            // REM ***Detail van Mandelbrot set met afstandsformule***
            // REM ***naam:MANDIST***
            //    DEFDBL A-D,U-Z
            //    DEFINT I-P
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            // REM ***data of Mset***
            //    AC=-.16 : BC=1.03  'coordinaten centrum detail
            AC = -.16f; // originele waarde
            AC = 0f;// 0.01 kleiner: beeld gaat 1/6e naar links
            BC = 1.03f; // originele waarde   
            BC = 0f;// 0.01 kleiner: beeld schuift omhoog kwart scherm. 0 = midden
                       //    DELH=.025 : DELV=.75*DELH  'grootte detail
            DELH = .025f; // originele waarde
            DELH = 1.5f; // 0.01 minder maakt beeld dubbel zo groot
            DELV = .75f * DELH;//  'grootte detail ;
                               //    N1=200 : N2=INT(.75*N1)  'grootte schermbeeld
            N1 = 200;
            N2 = (int)(.75f * N1);//  'grootte schermbeeld ;
                                  //    CLS : KMAX=200
            GW.CLS();
            KMAX = 200;
            // REM ***main loop***
            //    FOR I=-N1 TO N1 : FOR J=-N2 TO N2
            for (I = -N1; I <= N1; I++)
            {
                for (J = -N2; J <= N2; J++)
                {
                    //       A=AC+I*DELH/N1 : B=BC+J*DELV/N2
                    A = AC + I * DELH / N1;
                    B = BC + J * DELV / N2;
                    //       X=A : Y=B : U=1 : V=0
                    X = A;
                    Y = B;
                    U = 1;
                    V = 0;
                    //       IF GW.INKEY()<>"" THEN END
                    if (GW.INKEY() != "")
                    {
                        return;
                    }
                    //       FOR K=0 TO KMAX
                    for (K = 0; K <= KMAX; K++)
                    {
                        //          X1=X*X-Y*Y+A : Y1=2*X*Y+B
                        X1 = X * X - Y * Y + A;
                        Y1 = 2 * X * Y + B;
                        //          U1=2*(U*X-V*Y)+1 : V1=2*(U*Y+V*X)
                        U1 = 2 * (U * X - V * Y) + 1;
                        V1 = 2 * (U * Y + V * X);
                        //          S1=X1*X1+Y1*Y1+1E-8
                        S1 = X1 * X1 + Y1 * Y1 + 1E-8f;
                        //          IF S1>128 THEN
                        if (S1 > 128)
                        {
                            //             S2=LOG(S1) : S3=GW.SQR(U1*U1+V1*V1)
                            S2 = GW.LOG(S1);
                            S3 = GW.SQR(U1 * U1 + V1 * V1);
                            //             DIST=GW.SQR(S1)*S2/S3
                            float DIST = GW.SQR(S1) * S2 / S3;
                            //             IF DIST<.4*DELH/N1 THEN PSET(I,J),14
                            if (DIST < .4 * DELH / (float)N1)
                            {
                                GW.PSET(I, J, 14);
                            }
                            //             GOTO repeat
                            break;
                            //          END IF
                        }
                        //             X=X1 : Y=Y1 : U=U1 : V=V1
                        X = X1;
                        Y = Y1;
                        U = U1;
                        V = V1;
                        //       NEXT K
                    }
                    // repeat:
                    //    NEXT J : NEXT I : A$=INPUT$(1)
                }
            }
            GW.LOCATE(1, 1);GW.PRINT("klaar");
            //As = INPUTs(1);
            // END
            return;
            // 

        }
    }
}
