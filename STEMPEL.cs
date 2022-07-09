using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class STEMPEL
    {
        public STEMPEL()
        {
            int M = 0;
            int K = 0;
            int L = 0;
            int I = 0;
            int J = 0;
            string As = "";
            int W = 0;
            int S = 0;
            float X = 0;
            float Y = 0;
            float P = 0;
            float Q = 0;
            // REM ***een regelmatig patroon van een enkel stempel***
            // REM ***naam:STEMPEL***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    DIM X(4,6),Y(4,6)
            float[,] XA = new float[4 + 1, 6 + 1];
            float[,] YA = new float[4 + 1, 6 + 1];
            //    M=4  'aantal lijnen van motief
            M = 4;// 'aantal lijnen van motief ;
                  //    MA(1)=3 : MA(2)=3 : MA(3)=4 : MA(4)=6
            int[] MA = new int[5];
            MA[1] = 3;
            MA[2] = 3;
            MA[3] = 4;
            MA[4] = 6;
            int[] DATA = new int[] {
             1,-3,1,-1,3,-1,1,3,1,1,3,1,
             -3,-1,-1,-1,-1,1,-3,1,-1,-3,-1,-2,0,-2,0,2,-1,2,-1,3};
            //       FOR K=1 TO M : FOR L=1 TO MA[K)
            I = 0;
            for (K = 1; K <= M; K++)
            {
                for (L = 1; L <= MA[K]; L++)
                {
                    //    READ X(K,L),Y(K,L)
                    XA[K, L] = DATA[I];
                    I++;
                    YA[K, L] = DATA[I];
                    I++;
                    //    NEXT L : NEXT K
                }
            }
            //    LOCATE 1,1 : PRINT "tegel in normale stand"
            GW.LOCATE(1, 1);
            GW.PRINT("tegel in normale stand");
            //    WINDOW (-8,-6)-(8,6)
            GW.WINDOW(-8f, -6f, 8f, 6f);
            //    FOR I=-3 TO 3 : LINE (I,-3)-(I,3),4 : NEXT I
            for (I = -3; I <= 3; I++)
            {
                GW.LINE(I, -3, I, 3, 4);
            }
            //    FOR J=-3 TO 3 : LINE (-3,J)-(3,J),4 : NEXT J
            for (J = -3; J <= 3; J++)
            {
                GW.LINE(-3, J, 3, J, 4);
            }
            //    FOR K=1 TO M
            for (K = 1; K <= M; K++)
            {
                //       PSET (X(K,1),Y(K,1))
                GW.PSET(XA[K, 1], YA[K, 1]);
                //       FOR L=2 TO MA[K)
                for (L = 2; L <= MA[K]; L++)
                {
                    //          LINE -(X(K,L),Y(K,L))
                    GW.LINE(XA[K, L], YA[K, L]);
                    //       NEXT L
                }
                //    NEXT K : A$=INPUT$(1) : CLS
            }
            As = GW.INPUTS(1);
            GW.CLS();
            //    WINDOW (-18,-16)-(110,80)
            GW.WINDOW(-18f, -16f, 110f, 80f);
            // REM ***een stempel kan 4 standen innemen***
            // REM ***1 = normaal. 2,3,4 na een paar kwartdraaien***
            // REM ***te herhalen patroon is een blokje van vier posities***
            // REM ***geselecteerd door een groepje van 4 getallen***
            //    PRINT "kies achtereenvolgens een getal uit 1,2,3,4"
            GW.PRINT("kies achtereenvolgens een getal uit 1,2,3,4");
            //    PRINT "een goede keus is 3,2,4,1" : PRINT
            GW.PRINT("een goede keus is 3,2,4,1");
            GW.PRINT("");
            int[] SA = new int[4];

            //    INPUT "eerste getal = ",S(0)
            SA[0] = (int)GW.INPUT("eerste getal =  ");
            //    INPUT "tweede getal = ",S(1)
            SA[1] = (int)GW.INPUT("tweede getal =  ");
            //    INPUT "derde getal  = ",S(2)
            SA[2] = (int)GW.INPUT("derde getal  =  ");
            //    INPUT "vierde getal = ",S(3) : CLS
            SA[3] = (int)GW.INPUT("vierde getal =  ");
            GW.CLS();
            //    LINE (-3,-3)-(93,69),,B
            GW.LINE(-3, -3, 93, 69, "B");
            // REM ***hoofdprogramma***
            //    FOR J=0 TO 11 : FOR I=0 TO 15
            for (J = 0; J <= 11; J++)
            {
                for (I = 0; I <= 15; I++)
                {
                    //       X=6*I : Y=6*J
                    X = 6 * I;
                    Y = 6 * J;
                    //       IF J MOD 2 = 0 THEN W=0 ELSE W=2
                    if (J % 2 == 0)
                        W = 0;
                    else
                        W = 2;
                    //       IF I MOD 2 = 1 THEN W=W+1
                    if (I % 2 == 1)
                        W = W + 1;
                    //       S=S(W)
                    S = SA[W];
                    //       IF S=1 OR S=2 THEN P=1 ELSE P=-1
                    if (S == 1 || S == 2)
                        P = 1;
                    else
                        P = -1;
                    //       IF S=1 OR S=4 THEN Q=1 ELSE Q=-1
                    if (S == 1 || S == 4)
                        Q = 1;
                    else
                        Q = -1;
                    //       IF S=1 OR S=3 THEN
                    if (S == 1 || S == 3)
                    {
                        //          FOR K=1 TO M : PSET (X+P*X(K,1),Y+Q*Y(K,1))
                        for (K = 1; K <= M; K++)
                        {
                            GW.PSET(X + P * XA[K, 1], Y + Q * YA[K, 1]);
                            //          FOR L=2 TO MA[K) : LINE -(X+P*X(K,L),Y+Q*Y(K,L))
                            for (L = 2; L <= MA[K]; L++)
                            {
                                GW.LINE(X + P * XA[K, L], Y + Q * YA[K, L]);
                                //          NEXT L : NEXT K
                            }
                        }
                    }
                    else
                    {
                        //          FOR K=1 TO M : PSET (X+P*Y(K,1),Y+Q*X(K,1))
                        for (K = 1; K <= M; K++)
                        {
                            GW.PSET(X + P * YA[K, 1], Y + Q * XA[K, 1]);
                            //          FOR L=2 TO MA[K) : LINE -(X+P*Y(K,L),Y+Q*X(K,L))
                            for (L = 2; L <= MA[K]; L++)
                            {
                                GW.LINE(X + P * YA[K, L], Y + Q * XA[K, L]);
                                //          NEXT L : NEXT K
                            }
                        }
                        //       END IF
                    }
                    //    NEXT I : NEXT J
                }
            }
            // END
            return;
            // 
        }
    }
}
