namespace Graphics_boek
{
    class FOURIER
    {
        public FOURIER()
        {
            // REM ***grafiek van een trigonometrische reeks***
            // REM ***naam:FOURIER***
            //    SCREEN 12 : CLS : PI=4*ATN(1)
            float PI = 4 * GW.ATN(1);
            //    WINDOW (-8,-3)-(8,3)
            GW.WINDOW(-8, -3, 8, 3);
            //    M=8 : DIM X(M)
            int M = 8;
            float[] B = new float[M + 1];
            //    FOR I=1 TO M
            for (int I = 1; I <= M; I++)
            {
                //       B(I)=1/I
                B[I] = 1f / I;
                //    NEXT I
            }
            //    JMAX=1000  'aantal punten
            int JMAX = 1000;  //aantal punten
            //    LINE (-2*PI,0)-(2*PI,0)
            GW.LINE(-2 * PI, 0, 2 * PI, 0);
            //    FOR J=0 TO JMAX
            for (int J = 0; J <= JMAX; J++)
            {
                //       X=-2*PI+4*PI*J/JMAX
                float X = -2 * PI + 4 * PI * J / JMAX;
                //       S=0
                float S = 0;
                //       FOR K=1 TO M
                for (int K = 0; K <= M; K++)
                {

                    //          S=S+B(K)*SIN(K*X)
                    S += B[K] * GW.SIN(K * X);
                    //       NEXT K
                }
                //       IF J=0 THEN PSET (X,S) ELSE LINE -(X,S)
                if (J == 0)
                    GW.PSET(X, S);
                else
                    GW.LINE(X, S);
                //    NEXT J
            }
            // END            

        }
    }
}
