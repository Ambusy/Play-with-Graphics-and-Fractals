using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class TRUCHET
    {
        public TRUCHET()
        {
            int N = 0;
            float P = 0;
            int I = 0;
            int J = 0;
            float X0 = 0;
            float Y0 = 0;
            float X = 0;
            float Y = 0;
            float R = 0;
            float PI = 0;
            float T = 0;
            float U = 0;
            float V = 0;
            // REM ***een moderne tegelvloer volgens Truchet***
            // REM ***naam:TRUCHET***
            //    SCREEN 12 : CLS : PI=4*ATN(1)
            GW.CLS();
            PI = 4 * GW.ATN(1);
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            GW.RANDOMIZE(222);
            //    R=10 : N=10 : P=2*N*R
            R = 10;
            N = 10;
            P = 2 * N * R;
            //    LINE (-P,-P)-(P,P),,B
            GW.LINE(-P, -P, P, P, "B");
            //    FOR I=-N TO N-1 : FOR J=-N TO N-1
            for (I = -N; I <= N - 1; I++)
            {
                for (J = -N; J <= N - 1; J++)
                {
                    //       IF INKEY$<>"" THEN END
                    if (GW.INKEY() != "") return;
                    //       X0=2*R*I+R : Y0=2*R*J+R
                    X0 = 2 * R * I + R;
                    Y0 = 2 * R * J + R;
                    //       IF RND<.5 THEN GOSUB aaa ELSE GOSUB bbb
                    if (GW.RND() < .5)
                        aaa();
                    else
                        bbb();
                }
                //    NEXT J : NEXT I
            }
            //    FOR I=-N TO N : FOR J=-N TO N
            for (I = -N; I <= N; I++)
            {
                for (J = -N; J <= N; J++)
                {
                    //       IF (I+J) MOD 2 = 0 THEN GOTO repeat
                    if ((I + J) % 2 != 0)
                    {
                        //       X=2*R*I : Y=2*R*J
                        X = 2 * R * I;
                        Y = 2 * R * J;
                        //       IF I=-N THEN X=X+1
                        if (I == -N) X = X + 1;
                        //       IF I=N THEN X=X-1
                        if (I == N) X = X - 1;
                        //       IF J=-N THEN Y=Y+1
                        if (J == -N) Y = Y + 1;
                        //       IF J=N THEN Y=Y-1
                        if (J == N) Y = Y - 1;
                        //       PAINT (X,Y)
                        GW.PAINT(X, Y);
                        // repeat:
                    }
                    //    NEXT J : NEXT I
                }
            }

            // END
            return;
            void aaa()
            {
                //    X=X0-R : Y=Y0-R
                X = X0 - R;
                Y = Y0 - R;
                //    FOR K=0 TO 9
                for (int K = 0; K <= 9; K++)
                {
                    //       T=K*10*PI/180
                    T = K * 10 * PI / 180;
                    //       U=X+R*COS(T) : V=Y+R*SIN(T)
                    U = X + R * GW.COS(T);
                    V = Y + R * GW.SIN(T);
                    //       IF K=0 THEN PSET (U,V) ELSE LINE -(U,V)
                    if (K == 0)
                    {
                        GW.PSET(U, V);
                    }
                    else
                    {
                        GW.LINE(U, V);
                    }
                    //    NEXT K
                }
                //    X=X0+R : Y=Y0+R
                X = X0 + R;
                Y = Y0 + R;
                //    FOR K=0 TO 9
                for (int K = 0; K <= 9; K++)
                {
                    //       T=(180+K*10)*PI/180
                    T = (180 + K * 10) * PI / 180;
                    //       U=X+R*COS(T) : V=Y+R*SIN(T)
                    U = X + R * GW.COS(T);
                    V = Y + R * GW.SIN(T);
                    //       IF K=0 THEN PSET (U,V) ELSE LINE -(U,V)
                    if (K == 0)
                    {
                        GW.PSET(U, V);
                    }
                    else
                        GW.LINE(U, V);
                    //    NEXT K
                }
                // RETURN
            }

            void bbb()
            {
                //    X=X0+R : Y=Y0-R
                X = X0 + R;
                Y = Y0 - R;
                //    FOR K=0 TO 9
                for (int K = 0; K <= 9; K++)
                {
                    //       T=(90+K*10)*PI/180
                    T = (90 + K * 10) * PI / 180;
                    //       U=X+R*COS(T) : V=Y+R*SIN(T)
                    U = X + R * GW.COS(T);
                    V = Y + R * GW.SIN(T);
                    //       IF K=0 THEN PSET (U,V) ELSE LINE -(U,V)
                    if (K == 0)
                    {
                        GW.PSET(U, V);
                    }
                    else
                        GW.LINE(U, V);
                    //    NEXT K
                }
                //    X=X0-R : Y=Y0+R
                X = X0 - R;
                Y = Y0 + R;
                //    FOR K=0 TO 9
                for (int K = 0; K <= 9; K++)
                {
                    //       T=(270+K*10)*PI/180
                    T = (270 + K * 10) * PI / 180;
                    //       U=X+R*COS(T) : V=Y+R*SIN(T)
                    U = X + R * GW.COS(T);
                    V = Y + R * GW.SIN(T);
                    //       IF K=0 THEN PSET (U,V) ELSE LINE -(U,V)
                    if (K == 0)
                    {
                        GW.PSET(U, V);
                    }
                    else
                        GW.LINE(U, V);
                    //    NEXT K
                }
                // RETURN
                // 
            }
        }
    }
}

