using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class JULDIST
    {
        public JULDIST()
        {
            float A = 0;
            float B = 0;
            float C = 0;
            float DELH = 0;
            float DELV = 0;
            float DIST = 0;
            int N1 = 0;
            int N2 = 0;
            int I = 0;
            int J = 0;
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
            // REM ***Julia set met de afstandsformule***
            // REM ***naam:JULDIST***
            //    DEFDBL A-D,S-Y
            //     DEFDBL A-D,S - Y;
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            //    A=.111 : B=.666  'parameters julia set
            A = .111f;
            B = .666f;//  'parameters julia set ;
                      //    C=.2  'coefficient afstandsfunctie
            C = .2f;//  'coefficient afstandsfunctie ;
                    //    DELH=1.4 : DELV=1.4
            DELH = 1.4f;
            DELV = 1.4f;
            //    N1=200 : N2=INT(N1*DELV/DELH)
            N1 = 200;
            N2 = (int)(N1 * DELV / DELH);
            //    LINE (-N1,-N2)-(N1,N2),1,B
            GW.LINE(-N1, -N2, N1, N2, 1, "B");
            // REM ***hoofdprogramma***
            //    FOR I=0 TO N1 : FOR J=-N2 TO N2
            for (I = 0; I <= N1; I++)
            {
                for (J = -N2; J <= N2; J++)
                {
                    //       IF I=0 AND J=0 THEN GOTO repeat
                    if (!(I == 0 && J == 0))
                    {
                        //       IF GW.INKEY()<>"" THEN END
                        if (GW.INKEY() != "")
                        {
                            return;
                        }
                        //       X=I*DELH/N1 : Y=J*DELV/N2
                        X = I * DELH / N1;
                        Y = J * DELV / N2;
                        //       U=1 : V=0
                        U = 1;
                        V = 0;
                        //       FOR K=0 TO 200
                        for (K = 0; K <= 200; K++)
                        {
                            //          X1=X*X-Y*Y+A : Y1=2*X*Y+B
                            X1 = X * X - Y * Y + A;
                            Y1 = 2 * X * Y + B;
                            //          U1=2*(U*X-V*Y) : V1=2*(U*Y+V*X)
                            U1 = 2 * (U * X - V * Y);
                            V1 = 2 * (U * Y + V * X);
                            //          S1=X1*X1+Y1*Y1+1E-10 : S2=LOG(S1)
                            S1 = X1 * X1 + Y1 * Y1 + 1E-10f;
                            S2 = GW.LOG(S1);
                            //          S3=GW.SQR(U1*U1+V1*V1+1E-10)
                            S3 = GW.SQR(U1 * U1 + V1 * V1 + 1E-10f);
                            //          IF S1>256 OR S3>256 THEN
                            if (S1 > 256 || S3 > 256)
                            {
                                //             DIST=GW.SQR(S1)*S2/S3
                                DIST = GW.SQR(S1) * S2 / S3;
                                //             IF DIST<C*DELH/N1 THEN
                                if (DIST < C * DELH / N1)
                                {
                                    //                PSET (I,J),14 : PSET (-I,-J),14
                                    GW.PSET(I, J, 14);
                                    GW.PSET(-I, -J, 14);
                                    //             END IF
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
                    }
                    //    NEXT J : NEXT I : A$=INPUT$(1)
                }
            }
            GW.LOCATE(24, 1);
            GW.PRINT("Einde: druk op een toets");
            GW.LOCATE(24, 16);
            As = GW.INPUTS(1);
            // END
            return;
            // 
            ;
        }
    }
}
