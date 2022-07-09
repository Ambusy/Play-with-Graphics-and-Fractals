using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics_boek
{
    class OMHUL
    {
        public OMHUL()
        {
            int F = 0;
            float A = 0;
            float T0 = 0;
            float H = 0;
            float C = 0;
            float T = 0;
            float X0 = 0;
            float Y0 = 0;
            float X1 = 0;
            float Y1 = 0;
            float X2 = 0;
            float Y2 = 0;
            // REM ***doorlopende omhullende***
            // REM ***naam:OMHUL***
            //    SCREEN 12 : CLS
            GW.CLS();
            //    WINDOW (-320,-240)-(319,239)
            GW.WINDOW(-320f, -240f, 319f, 239f);
            //    DEFDBL A-T : DEFINT X,Y
            //    F=200 : A=1.35 : T0=2
            F = 200;
            A = 1.35f;
            T0 = 2;
            //    H=.01 : C=.5 : T=0
            H = .01f;
            C = .5f;
            T = 0;
            int CL = 100;
            //    DO WHILE T<100 AND INKEY$=""
            while (T < 100 && GW.INKEY() == "" ) {
                //       X0=F*SIN(T-T0) : Y0=F*SIN(A*(T-T0)+C)
                X0 = F * GW.SIN(T - T0);
                Y0 = F * GW.SIN(A * (T - T0) + C);
                //       X1=F*SIN(T) : Y1=F*SIN(A*T+C)
                X1 = F * GW.SIN(T);
                Y1 = F * GW.SIN(A * T + C);
                //       X2=F*SIN(T+T0) : Y2=F*SIN(A*(T+T0)+C)
                X2 = F * GW.SIN(T + T0);
                Y2 = F * GW.SIN(A * (T + T0) + C);
                //       LINE (X0,Y0)-(X1,Y1),0
                GW.LINE(X0, Y0, X1, Y1, 0);
                //       LINE (X1,Y1)-(X2,Y2)
                CL++;
                if (CL > 1599) CL = 100;
                GW.LINE(X1, Y1, X2, Y2, CL/100);
                //       T=T+H
                T = T + H;
                //    LOOP
            }
            // END
        }
        // 
    }
}
