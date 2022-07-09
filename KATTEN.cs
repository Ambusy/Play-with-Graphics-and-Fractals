namespace Graphics_boek
{
    public class KATTEN
    {
        public KATTEN()
        {

            // REM ***een tegelwand van katten op de wijze van Escher***
            // REM ***naam:KATTEN***
            //    SCREEN 12 : CLS
            //    WINDOW (6,6)-(114,87)
            GW.WINDOW(6, 6, 114, 87);
            //    DIM X(7,13),Y(7,13),M(7)
            // REM ***relatieve coordinaten kattenmotief***
            //    M(1)=13 : M(2)=7 : M(3)=7 : M(4)=6
            //    M(5)=2 : M(6)=2 : M(7)=5
            int[] m = new int[] { 13, 7, 7, 6, 2, 2, 5 };
            //    DATA 0,0,-1,4,0,8,0,12,3,9,9,9,12
            //    DATA 12,12,8,11,4,12,0,9,-3,3,-3,0,0
            //    DATA 2,2,1.5,3,2.5,4,3.5,4,4,3.5,4,2,2,2
            //    DATA 8,2,8,3.5,8.5,4,9.5,4,10.5,3,10,2,8,2
            //    DATA 2,1,10,1,6,.6,6,-.5,6,.6,2,1,3,4,3,2.5,9,4,9,2.5
            //    DATA 2.5,-.5,4,-1.5,6,-1,8,-1.5,9.5,-.5
            //    FOR I=1 TO 7 : FOR J=1 TO M(I)
            //       READ X(I,J),Y(I,J)
            //    NEXT J : NEXT I
            float[] xy = new float[]
            {
                0,0, -1,4, 0,8, 0,12, 3,9, 9,9, 12,
                12, 12,8, 11,4, 12,0, 9,-3, 3,-3, 0,0,
                2,2, 1.5f,3, 2.5f,4, 3.5f,4, 4,3.5f,  4,2, 2,2,
                8,2, 8,3.5f, 8.5f,4, 9.5f,4, 10.5f,3, 10,2, 8,2,
                2,1, 10,1, 6,0.6f, 6,-0.5f, 6,0.6f, 2,1, 3,4, 3,2.5f, 9,4, 9,2.5f,
                2.5f,-0.5f, 4,-1.5f, 6,-1, 8,-1.5f, 9.5f, -0.5f
            };
            //    FOR I=1 TO 6
            for (int i = 1; i <= 6; i++)
            {
                //       FOR J=1 TO 8
                for (int j = 1; j <= 8; j++)
                {
                    int cx = 0;
                    //          FOR K=1 TO 7
                    for (int k = 1; k <= 7; k++)
                    {
                        //             PSET (12*J+X(K,1),12*I+Y(K,1))
                        GW.PSET(12 * j + xy[cx], 12 * i + xy[cx + 1]);
                        cx += 2;
                        //             FOR L=2 TO M(K)
                        for (int l = 2; l <= m[k - 1]; l++)
                        {
                            //                LINE -(12*J+X(K,L),12*I+Y(K,L))
                            GW.LINE(12 * j + xy[cx], 12 * i + xy[cx + 1]);
                            cx += 2;
                            //             NEXT L
                        }
                        //          NEXT K
                    }
                    //       NEXT J
                }
                //    NEXT I
            }
            // END            
        }
    }
}
