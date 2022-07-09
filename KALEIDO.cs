using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class KALEIDO
    {
        public KALEIDO()
        {
            int I = 0;
            float X1 = 0;
            float Y1 = 0;
            float X2 = 0;
            float Y2 = 0;
            int COL = 0;
            int J = 0;
            // REM ***een kaleidoscoop van gekleurde lijnen***
            // REM ***naam:KALEIDO***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    VIEW SCREEN (40,30)-(600,450),0,15
            //    RANDOMIZE 111
            //    WINDOW (-1,-1)-(1,1)
            GW.WINDOW(-1f, -1f, 1f, 1f);
            //    LOCATE 1,7 : PRINT "start/stop het programma door";
            GW.LOCATE(1, 7);
            GW.PRINT("start/stop het programma door");
            //    PRINT " het drukken van een willekeurige toets"
            GW.PRINT(" het drukken van een willekeurige toets");
            //    A$=INPUT$(1) : LOCATE 1,1 : PRINT SPACE$(80)
            while (GW.INKEY() == "") { }
            GW.LOCATE(1, 1);
            GW.PRINT(GW.SPACE(80));
            //    DIM X1(10),Y1(10),X2(10),Y2(10)
            float[] X1A = new float[10 + 1];
            float[] Y1A = new float[10 + 1];
            float[] X2A = new float[10 + 1];
            float[] Y2A = new float[10 + 1];
            //    FOR I=1 TO 10
            for (I = 1; I <= 10; I++)
            {
                //       X1(I)=2*RND-1 : Y1(I)=2*RND-1
                X1A[I] = 2 * GW.RND() - 1;
                Y1A[I] = 2 * GW.RND() - 1;
                //       X2(I)=2*RND-1 : Y2(I)=2*RND-1
                X2A[I] = 2 * GW.RND() - 1;
                Y2A[I] = 2 * GW.RND() - 1;
                //       X1=X1(I) : Y1=Y1(I) : X2=X2(I) : Y2=Y2(I)
                X1 = X1A[I];
                Y1 = Y1A[I];
                X2 = X2A[I];
                Y2 = Y2A[I];
                //       COL=1+INT(14*RND)
                COL = 1 + (int)(14 * GW.RND());
                //       GOSUB graphics
                graphics(X1, Y1, X2, Y2, COL);
                //    NEXT I
            }
            //    DO WHILE INKEY$=""
            while (GW.INKEY() == "")
            {
                //       FOR J=1 TO 10
                for (J = 1; J <= 10; J++)
                {
                    //          X1=X1(J) : Y1=Y1(J) : X2=X2(J) : Y2=Y2(J) : COL=0
                    X1 = X1A[J];
                    Y1 = Y1A[J];
                    X2 = X2A[J];
                    Y2 = Y2A[J];
                    COL = 0;
                    //          GOSUB graphics
                    graphics(X1, Y1, X2, Y2, COL);
                    //          X1(J)=2*RND-1 : Y1(J)=2*RND-1
                    X1A[J] = 2 * GW.RND() - 1;
                    Y1A[J] = 2 * GW.RND() - 1;
                    //          X2(J)=2*RND-1 : Y2(J)=2*RND-1
                    X2A[J] = 2 * GW.RND() - 1;
                    Y2A[J] = 2 * GW.RND() - 1;
                    //          X1=X1(J) : Y1=Y1(J) : X2=X2(J) : Y2=Y2(J)
                    X1 = X1A[J];
                    Y1 = Y1A[J];
                    X2 = X2A[J];
                    Y2 = Y2A[J];
                    //          COL=1+INT(14*RND)
                    COL = 1 + (int)(14 * GW.RND());
                    //          GOSUB graphics
                    graphics(X1, Y1, X2, Y2, COL);
                    //       NEXT J
                }
                //    LOOP
            }
            // END
            void graphics(float X1, float Y1, float X2, float Y2, int COL)
            {
                //    LINE (X1,Y1)-(X2,Y2),COL
                GW.LINE(X1, Y1, X2, Y2, COL);
                //    LINE (X1,-Y1)-(X2,-Y2),COL
                GW.LINE(X1, -Y1, X2, -Y2, COL);
                //    LINE (-X1,Y1)-(-X2,Y2),COL
                GW.LINE(-X1, Y1, -X2, Y2, COL);
                //    LINE (-X1,-Y1)-(-X2,-Y2),COL
                GW.LINE(-X1, -Y1, -X2, -Y2, COL);
                //    LINE (Y1,X1)-(Y2,X2),COL
                GW.LINE(Y1, X1, Y2, X2, COL);
                //    LINE (Y1,-X1)-(Y2,-X2),COL
                GW.LINE(Y1, -X1, Y2, -X2, COL);
                //    LINE (-Y1,X1)-(-Y2,X2),COL
                GW.LINE(-Y1, X1, -Y2, X2, COL);
                //    LINE (-Y1,-X1)-(-Y2,-X2),COL
                GW.LINE(-Y1, -X1, -Y2, -X2, COL);
                // RETURN
                return;
                // 
            }
        }
    }
}


