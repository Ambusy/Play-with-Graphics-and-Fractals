namespace Graphics_boek
{
    class CIRKELB
    {
        public CIRKELB()
        {
            // REM ***samengestelde cirkelbeweging***
            // REM ***naam:CIRKELB***
            //    SCREEN 12 : CLS
            //    WINDOW (-3.2,-2.4)-(3.2,2.4)
            GW.WINDOW(-3.2f, -2.4f, 3.2f, 2.4f);
            //    A=11/7 : R=.6 : H=.02
            float A = 11f / 7f;
            float R = .6f;
            float H = .02f;
            //    LOCATE 1,1 : PRINT"druk op een toets voor einde programma"
            GW.LOCATE(1, 1);
            GW.PRINT("druk op een toets voor einde programma");
            float T = 0;
            //    DO
            while (GW.INKEY() == "")
            {
                //       X=COS(T) : Y=SIN(T)
                float X = GW.COS(T);
                float Y = GW.SIN(T);
                //       X1=X+R*COS(A*T) : Y1=Y+R*SIN(A*T)
                float X1 = X + R * GW.COS(A * T);
                float y1 = Y + R * GW.SIN(A * T);
                //       PSET (X1,Y1),14
                GW.PSET(X1, y1, 14);
                //       T=T+H
                T += H;
                // REM ***vertragingslus***
                //       FOR I=1 TO 100 : LOCATE 1,1 : PRINT "" : NEXT I
                GW.Pause();
            }
            //    LOOP UNTIL INKEY$<>""
            // END
            GW.LOCATE(1, 25);
            GW.PRINT(" einde programma");
        }
    }
}
