using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class GROEIM2
    {
        public GROEIM2()
        {
            int K = 0;
            float A = 0;
            float X = 0;
            float Y = 0;
            int N = 0;
            float Z;
            string AS = "";
            // REM ***een model van geremde groei***
            // REM ***naam:GROEIM2***
            // REM ***x''= a x' (1-x*x) ***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    GOSUB text
            text();
            //    FOR K=1 TO 16 : A=1.35+K*.04
            for (K = 1; K <= 16; K++)
            {
                A = 1.35F + K * .04F;
                //       VIEW (200,40)-(600,440),1,15
                //       WINDOW (-1.7,-1.7)-(1.7,1.7)
                GW.WINDOW(-1.7f, -1.7f, 1.7f, 1.7f);
                //       LOCATE 3,1 : PRINT "A =";
                GW.LOCATE(3, 1);
                //       PRINT USING "##.##";A
                GW.PRINT("A = " + A.ToString());
                //       X=.01 : Y=.01  'start
                X = .01F;
                Y = .01F;// 'start ;
                         //       FOR N=1 TO 100+K*K*100
                for (N = 1; N <= 100 + K * K * 100; N++)
                {
                    //          Z=X : X=Y : Y=A*Y*(1-Z*Z)
                    Z = X;
                    X = Y;
                    Y = A * Y * (1 - Z * Z);
                    //          PSET (X,Y)
                    GW.PSET(X, Y);
                    //       NEXT N
                }
                //       BEEP : GOSUB text : A$=INPUT$(1) : CLS
                text();
                AS = GW.INPUTS(1);
                GW.CLS();
                if (AS == "X") return;
                //    NEXT K : SCREEN 0
            }
            // END
            return;
            void text()
            {
                //     LOCATE 22,1 : PRINT "druk op een toets"
                GW.LOCATE(22, 1);
                GW.PRINT("druk op een toets");
                //     LOCATE 23,1 : PRINT "voor vervolg, X voor einde"
                GW.LOCATE(23, 1);
                GW.PRINT("voor vervolg, X voor einde");
                // RETURN
                // 
            }
        }
    }
}
