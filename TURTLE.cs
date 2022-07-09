using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Graphics_boek
{
    class TURTLE
    {
        public TURTLE()
        {
            float H = 0;
            float X = 0;
            float Y = 0;
            float P = 0;
            float Q = 0;
            float P1 = 0;
            float Q1 = 0;
            string AS = "";
            // REM ***turtlegraphics, stap voor stap***
            // REM ***naam:TURTLE***
            // SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-160,-120)-(160,120)
            GW.WINDOW(-160f, -120f, 160f, 120f);
            //    PRINT "F voorwaarts en tekenen, f voorwaarts niet tekenen"
            GW.PRINT("F voorwaarts en tekenen, f voorwaarts niet tekenen");
            //    PRINT "+ kwartslag linksom, - kwartslag rechtsom, x einde"
            GW.PRINT("+ kwartslag linksom, - kwartslag rechtsom, x einde");
            //    H=4 : X=0 : Y=0 : P=1 : Q=0 : PSET (X,Y)
            H = 4;
            X = 0;
            Y = 0;
            P = 1;
            Q = 0;
            GW.PSET(X, Y);
            //    DO
            do
            {
                //       A$=INPUT$(1)
                GW.LOCATE(3, 1);
                AS = GW.INPUTS(1);
                //       SELECT CASE A$
                switch (AS)
                {
                    //       CASE "F"
                    case "F":
                        //          X=X+H*P : Y=Y+H*Q
                        X = X + H * P;
                        Y = Y + H * Q;
                        //          LINE -(X,Y)
                        GW.LINE(X, Y);
                        Debug.WriteLine(X.ToString() + "  " + Y.ToString());
                        //       CASE "f"
                        break;
                    case "f":
                        //          X=X+H*P : Y=Y+H*Q
                        X = X + H * P;
                        Y = Y + H * Q;
                        //          PSET (X,Y)
                        GW.PSET(X, Y);
                        //       CASE "+"
                        break;
                    case "+":
                        //          P1=Q : Q1=-P
                        P1 = Q;
                        Q1 = -P;
                        //          P=P1 : Q=Q1
                        P = P1;
                        Q = Q1;
                        //       CASE "-"
                        break;
                    case "-":
                        //          P1=-Q : Q1=P
                        P1 = -Q;
                        Q1 = P;
                        //          P=P1 : Q=Q1
                        P = P1;
                        Q = Q1;
                        //       END SELECT
                        break;
                    default:
                        break;
                }
                //    LOOP UNTIL A$="X" OR A$="x"
            } while (!(AS == "X" || AS == "x"));
            // END
            return;
            // 
        }
    }
}
