using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class ARTBLOK
    {
        public ARTBLOK()
        {
            int M = 0;
            string As = " ";
            float A = 0;
            int KMAX = 0;
            float P = 0;
            int I = 0;
            int J = 0;
            int L = 0;
            float XC = 0;
            float YC = 0;
            float X1 = 0;
            float Y1 = 0;
            float X2 = 0;
            float Y2 = 0;
            int NUMCOL = 0;
            int COL = 0;
            int K = 0;

            // REM ***symmetrisch schaakbordpatroon***
            // REM ***met door toeval bepaalde kleuren***
            // REM ***neem SCREEN 9 bij Q(uick)Basic***
            // REM ***naam:ARTBLOK***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-.5,-.3)-(1.5,1.2)
            GW.WINDOW(-.5f, -.3f, 1.5f, 1.2f);
            //    RANDOMIZE 111
            //    M=16  'aantal rijen en kolommen
            M = 16;// 'aantal rijen en kolommen ;
                   //    A=1.3  'grootte blokken
            A = 1.3f;// 'grootte blokken ;
                     //    KMAX=3*M*M : P=A/(2*M)
            KMAX = 3 * M * M;
            P = A / (2 * M);
            //    NUMCOL=8  'aantal kleuren
            NUMCOL = 8;// 'aantal kleuren ;
                       //    GOSUB kleur : K=0
                       // Anders dan in het boek, dat programma werkt niet zoals bedoeld.
                       //    DO WHILE A$<>"X" AND A$<>"x"
            while (As != "X" && As != "x")
            {

                kleur();
                K = 0;
                //    DO WHILE INKEY$="" AND K<KMAX
                while (GW.INKEY() == "" && K < KMAX)
                {
                    //       I=INT(M*RND) : J=INT(M*RND)
                    I = (int)(M * GW.RND());
                    J = (int)(M * GW.RND());
                    //       L=1+INT(100*RND) MOD NUMCOL
                    L = 1 + (int)(100 * GW.RND()) % NUMCOL;
                    //       XC=(I+.5)/M : YC=(J+.5)/M
                    XC = (I + .5f) / (float)M;
                    YC = (J + .5f) / (float)M;
                    //       X1=XC-P : Y1=YC-P : X2=XC+P : Y2=YC+P
                    X1 = XC - P;
                    Y1 = YC - P;
                    X2 = XC + P;
                    Y2 = YC + P;
                    //       LINE (X1,Y1)-(X2,Y2),L,BF
                    GW.LINE(X1, Y1, X2, Y2, L, "BF");
                    //       K=K+1
                    K = K + 1;
                    //    LOOP
                }
                //    LINE (-.04,-.04)-(1.04,1.04),14,B
                GW.LINE(-.04f, -.04f, 1.04f, 1.04f, 14, "B");
                //    LOCATE 1,1 : A$=""
                GW.palettes[GW.fgColor] = GW.fgColor;
                GW.LOCATE(1, 1);
                As = "";
                //    PRINT "toets X for einde, andere toetsen voor kleurvariatie"
                GW.PRINT("toets X for einde, andere toetsen voor kleurvariatie");
                //       GOSUB kleur
                kleur();
                //       A$=INPUT$(1)
                As = GW.INPUTS(1);
                //    LOOP
            }
            // END
            return;
            void kleur()
            {
                //    FOR K=1 TO NUMCOL
                for (K = 1; K <= NUMCOL; K++)
                {
                    //       COL=INT(64*RND)
                    COL = (int)(16 * GW.RND());
                    //       PALETTE K,COL
                    GW.palettes[K] = COL;
                    //    NEXT K
                }
                // RETURN
                // 
            }
        }
    }
}
