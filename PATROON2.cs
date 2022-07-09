using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Graphics_boek
{
    class PATROON2
    {
        public PATROON2()
        {
            int M = 0;
            float GG = 0;
            int I = 0;
            int J = 0;
            float X = 0;
            float Y = 0;
            string A = "";
            // REM ***symmetrisch blokpatroon bepaald door***
            // REM ***een functie en een groot getal***
            // REM ***naam:PATROON2***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    GOSUB text
            text();
            //    WINDOW (-.5,-.3)-(1.5,1.2)
            GW.WINDOW(-.5f, -.3f, 1.5f, 1.2f);
            //    M=32  'aantal rijen en kolommen
            M = 32;// 'aantal rijen en kolommen ;
            //    GG=1000  'willekeurig groot getal
            GG = 1000; // 'willekeurig groot getal ;
            //    DO
            do
            {
                //       LOCATE 1,1 : PRINT SPACE$(160) : LOCATE 1,1
                GW.LOCATE(1, 1);
                GW.PRINT(GW.SPACE(160));
                GW.LOCATE(1, 1);
                //       PRINT "geef een groot getal tussen 100 en 10000"
                GW.PRINT("geef een groot getal tussen 100 en 10000");
                //       INPUT "getal = ",GG : CLS
                GG = GW.INPUT("getal =  ");
                GW.CLS();
                //       FOR I=0 TO M
                for (I = 0; I <= M; I++)
                {
                    //          LINE (0,I/M)-(1,I/M) : LINE (I/M,0)-(I/M,1)
                    GW.LINE(0, I / (float)M, 1, I / (float)M);
                    GW.LINE(I / (float)M, 0, I / (float)M, 1);
                    //       NEXT I
                }
                //       FOR I=1 TO  M : FOR J=1 TO M
                for (I = 1; I <= M; I++)
                {
                    for (J = 1; J <= M; J++)
                    {
                        //      X = -1 / (2 * M) + I / M : Y = -1 / (2 * M) + J / M
                        X = -1f / (2 * M) + I / (float)M;
                        Y = -1f / (2 * M) + J / (float)M;
                        //      Z = INT(GG * 4 * X * Y * (1 - X) * (1 - Y))
                        int Z = (int)(GG * 4 * X * Y * (1 - X) * (1 - Y));
                        //      IF Z MOD 2 = 0 THEN PAINT(X, Y)
                        if (Z % 2 == 0) GW.PAINT(X, Y,4);
                        //       NEXT J : NEXT I
                    }
                }
                //       LOCATE 1,1 :  PRINT "druk op R voor herhaling"
                GW.LOCATE(1, 1);
                GW.PRINT("druk op R voor herhaling");
                //       PRINT "druk op een andere toets voor einde"
                GW.PRINT("druk op een andere toets voor einde");
                //       A$=INPUT$(1)
                GW.LOCATE(2, 40);
                A = GW.INPUTS(1);
                //    LOOP UNTIL A$<>"R" AND A$<>"r"
            } while (!(A != "R" && A != "r"));
            // END
            GW.LOCATE(1, 1);
            GW.PRINT(" einde programma");
            GW.PRINT(" ");
            return;
            void text()
            {
                string A = "";
                //    LOCATE 1,1
                GW.LOCATE(1, 1);
                //    PRINT "dit programma geeft verschillende blokpatronen"
                GW.PRINT("dit programma geeft verschillende blokpatronen");
                //    PRINT "na keuze van een willekeurig groot getal"
                GW.PRINT("na keuze van een willekeurig groot getal");
                //    LOCATE 4,1 : PRINT "druk op een toets ..."
                GW.LOCATE(4, 1);
                GW.PRINT("druk op een toets ...");
                //    A$=INPUT$(1) : CLS
                A = GW.INKEY();
                GW.CLS();
                // RETURN
                // 
            }

        }

    }
}
