using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class SQUAREF
    {
        public SQUAREF()
        {
            float[] A = new float[3 + 1];
            float[] B = new float[3 + 1];
            float[] C = new float[3 + 1];
            float[] D = new float[3 + 1];
            float T = 0;
            int L = 0;
            float PI = 0;
            float X = 0;
            float Y = 0;
            int KMAX = 0;
            int K = 0;
            float R = 0;
            float Z = 0;
            // REM ***fractals in een vierkant***
            // REM ***naam:SQUAREF***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    RANDOMIZE 11 : PI=4*ATN(1)
            GW.RANDOMIZE(11);
            PI = 4 * GW.ATN(1);
            //    WINDOW (-3.2,-2.4)-(3.2,2.4)
            GW.WINDOW(-3.2f, -2.4f, 3.2f, 2.4f);
            //    PRINT "bij elk drietal getallen uit 0,1,2,...,7 behoort een fractal"
            GW.PRINT("bij elk drietal getallen uit 0,1,2,...,7 behoort een fractal");
            //    PRINT : INPUT "eerste getal = ",T1
            GW.PRINT("");
            float T1 = GW.INPUT("eerste getal =  ");
            //    PRINT : INPUT "tweede getal = ",T2
            GW.PRINT("");
            float T2 = GW.INPUT("tweede getal =  ");
            //    PRINT : INPUT "derde  getal = ",T3
            GW.PRINT("");
            float T3 = GW.INPUT("derde  getal =  ");
            //    T=T1 : L=1 : GOSUB selectie
            T = T1;
            L = 1;
            selectie();
            //    T=T2 : L=2 : GOSUB selectie
            T = T2;
            L = 2;
            selectie();
            //    T=T3 : L=3 : GOSUB selectie
            T = T3;
            L = 3;
            selectie();
            //    DIM E(3),F(3)
            float[] E = new float[3 + 1];
            float[] F = new float[3 + 1];
            //    E(1)=1 : F(1)=0 : E(2)=-1
            E[1] = 1;
            F[1] = 0;
            E[2] = -1;
            //    F(2)=0 : E(3)=0 : F(3)=-1
            F[2] = 0;
            E[3] = 0;
            F[3] = -1;
            //    X=0 : Y=0 : KMAX=30000
            X = 0;
            Y = 0;
            KMAX = 30000;
            //    CLS : GOSUB setframe
            GW.CLS();
            setframe();
            //    LOCATE 1,1  : PRINT T1  : LOCATE 1,10 : PRINT T2
            GW.LOCATE(1, 1);
            GW.PRINT(T1.ToString());
            GW.LOCATE(1, 10);
            GW.PRINT(T2.ToString());
            //    LOCATE 1,20 : PRINT T3
            GW.LOCATE(1, 20);
            GW.PRINT(T3.ToString());
            // REM ***hoofdprogramma***
            //    FOR K=1 TO KMAX : R=RND
            for (K = 1; K <= KMAX; K++)
            {
                R = GW.RND();
                //       IF INKEY$<>"" THEN END
                if (GW.INKEY() != "") return;
                //       L=1+INT(3*RND)
                L = 1 + (int)(3 * GW.RND());
                //       Z=X : X=A(L)*X+B(L)*Y+E(L) : Y=C(L)*Z+D(L)*Y+F(L)
                Z = X;
                X = A[L] * X + B[L] * Y + E[L];
                Y = C[L] * Z + D[L] * Y + F[L];
                //       IF K>16 THEN PSET (X,Y)
                if (K > 16)
                {
                    GW.PSET(X, Y);
                }
                //    NEXT K : BEEP

                // END
            }
            return;
            void selectie()
            {
                //    SELECT CASE T
                switch (T)
                {
                    //    CASE 0
                    case 0:
                        //       A(L)=1/2 : B(L)=0 : C(L)=0 : D(L)=1/2
                        A[L] = .5f;
                        B[L] = 0;
                        C[L] = 0;
                        D[L] = .5f;
                        //    CASE 1
                        break;
                    case 1:
                        //       A(L)=0 : B(L)=-1/2 : C(L)=1/2 : D(L)=0
                        A[L] = 0;
                        B[L] = -0.5f;
                        C[L] = .5f;
                        D[L] = 0;
                        //    CASE 2
                        break;
                    case 2:
                        //       A(L)=-1/2 : B(L)=0 : C(L)=0 : D(L)=-1/2
                        A[L] = -0.5f;
                        B[L] = 0;
                        C[L] = 0;
                        D[L] = -0.5f;
                        //    CASE 3
                        break;
                    case 3:
                        //       A(L)=0 : B(L)=1/2 : C(L)=-1/2 : D(L)=0
                        A[L] = 0;
                        B[L] = .5f;
                        C[L] = -0.5f;
                        D[L] = 0;
                        //    CASE 4
                        break;
                    case 4:
                        //       A(L)=-1/2 : B(L)=0 : C(L)=0 : D(L)=1/2
                        A[L] = -0.5f;
                        B[L] = 0;
                        C[L] = 0;
                        D[L] = .5f;
                        //    CASE 5
                        break;
                    case 5:
                        //       A(L)=0 : B(L)=1/2 : C(L)=1/2 : D(L)=0
                        A[L] = 0;
                        B[L] = .5f;
                        C[L] = .5f;
                        D[L] = 0;
                        //    CASE 6
                        break;
                    case 6:
                        //       A(L)=1/2 : B(L)=0 : C(L)=0 : D(L)=-1/2
                        A[L] = .5f;
                        B[L] = 0;
                        C[L] = 0;
                        D[L] = -0.5f;
                        //    CASE 7
                        break;
                    case 7:
                        //       A(L)=0 : B(L)=-1/2 : C(L)=-1/2 : D(L)=0
                        A[L] = 0;
                        B[L] = -0.5f;
                        C[L] = -0.5f;
                        D[L] = 0;
                        //    END SELECT
                        break;
                    default:
                        break;
                }
            }
            // RETURN
            void setframe()
            {
                //    LINE (-2,0)-(0,2),4 : LINE -(2,0),4
                GW.LINE(-2, 0, 0, 2, 4);
                GW.LINE(2, 0, 4);
                //    LINE -(0,-2),4 : LINE -(-2,0),4
                GW.LINE(0, -2, 4);
                GW.LINE(-2, 0, 4);
                //    LINE (-1,-1)-(1,1),4 : LINE (1,-1)-(-1,1),4
                GW.LINE(-1, -1, 1, 1, 4);
                GW.LINE(1, -1, -1, 1, 4);
                // RETURN
                // 
            }
        }
    }
}


