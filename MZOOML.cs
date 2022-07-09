using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Graphics_boek
{
    class MZOOML
    {
        public MZOOML()
        {
            float XM = 0;
            float YM = 0;
            int NFIXED = 0;
            int NBEGIN = 0;
            bool F2 = false;
            bool F7 = false;
            bool F10 = false;
            float XA = 0;
            float YA = 0;
            float XB = 0;
            float YB = 0;
            float ACT = 0;
            float BCT = 0;
            int KP = 0;
            float FP1 = 0;
            float FP2 = 0;
            float FP3 = 0;
            int JP = 0;
            float YP = 0;
            int IP = 0;
            float XP = 0;
            float A = 0;
            float B = 0;
            float U = 0;
            float V = 0;
            int COL = 0;
            float X = 0;
            float Y = 0;
            int K = 0;
            float Z = 0;
            float S = 0;
            string As = "";
            float AC = 0;
            float DELH = 0;
            float DELV = 0;
            int NMAX = 0;
            int CS = 0;
            int I = 0;
            float XAN = 0;
            float XBN = 0;
            float YAN = 0;
            float YBN = 0;
            float BC = 0;
            float DF = 0;
            float newframe = 0;
            int J = 0;
            // REM ***Mandelbrot zooming tiling version ***
            // REM ***name:MZOOML***
            //   SCREEN 12 : CLS
            GW.CLS();
            //   DEFDBL A,B,D,S-Z : DEFINT C,F,I-N
            //   DIM CU(40),CD(40),CL(35),CR(35)
            int[] CU = new int[40 + 1];
            int[] CD = new int[40 + 1];
            int[] CL = new int[35 + 1];
            int[] CR = new int[35 + 1];
            //   XM=384 : YM=256 : NFIXED=50 : NBEGIN=50
            XM = 384;
            YM = 256;
            NFIXED = 50;
            NBEGIN = 50;
            //   GOSUB startdata : CLS
            startdata();
            GW.CLS();
            //   IF A$="X" OR A$="x" THEN END
            if (As == "X" || As == "x")
            {
                return;
            }
            //   DO
            do
            {
                //     F2=0 : F7=0 : F10=0  'switches for text, detail and end
                F2 = false;
                F7 = false;
                F10 = false;//  'switches for text, detail and end ;
                            //     XA=128 : YA=32 : XB=640 : YB=480 : ACT=AC : BCT=BC
                XA = 128;
                YA = 32;
                XB = 640;
                YB = 480;
                ACT = AC;
                BCT = BC;
                //     VIEW SCREEN (128,32)-(638,478),,15
                //                              VIEW SCREEN(128,32)-(638, 478),,15;
                //     GOSUB textonoff : GOSUB printdata
                textonoff();
                printdata();
                //     FOR KP=0 TO 5
                for (KP = 0; KP <= 5; KP++)
                {
                    //       FP1=16*2^KP-1 : FP2=14*2^KP-1 : FP3=2^(5-KP)
                    FP1 = 16 * (int)Math.Pow(2f , (float)KP) - 1;
                    FP2 = 14 * (int)Math.Pow(2f, (float)KP) - 1;
                    FP3 = (int)Math.Pow(2f, 5f - (float)KP);
                    //       FOR JP=0 TO FP2 :  YP=32+JP*FP3
                    for (JP = 0; JP <= FP2; JP++)
                    {
                        YP = 32 + JP * FP3;
                        //    FOR IP=0 TO FP1 :  XP=128+IP*FP3
                        for (IP = 0; IP <= FP1; IP++)
                        {
                            XP = 128 + IP * FP3;
                            // REM ***calculation of pixelvalue***
                            //      A=ACT+(XP-XM)*DELH/256 : B=BCT-(YP-YM)*DELV/224
                            A = ACT + (XP - XM) * DELH / 256f;
                            B = BCT - (YP - YM) * DELV / 224f;
                            //      U=4*(A*A+B*B) : V=U-2*A+1/4 : COL=0
                            U = 4 * (A * A + B * B);
                            V = U - 2 * A + 1 / 4f;
                            COL = 0;
                            //      IF U+8*A+15/4>0 AND V-GW.SQR(V)+2*A-1/2>0 THEN
                            if (U + 8 * A + 15 / 4f > 0 && V - GW.SQR(V) + 2 * A - 1 / 2f > 0)
                            {
                                //        X=A : Y=B
                                X = A;
                                Y = B;
                                //        FOR K=1 TO NMAX
                                for (K = 1; K <= NMAX; K++)
                                {
                                    //          Z=X : X=X*X-Y*Y+A : Y=2*Z*Y+B
                                    Z = X;
                                    X = X * X - Y * Y + A;
                                    Y = 2 * Z * Y + B;
                                    //          S=X*X+Y*Y : IF S>128 THEN EXIT FOR
                                    S = X * X + Y * Y;
                                    if (S > 128)
                                    {
                                        break;
                                    }
                                    //        NEXT K
                                }
                                //        IF K<INT(NMAX/2) THEN COL=1+K MOD 15
                                if (K < (int)(NMAX / 2f))
                                {
                                    COL = 1 + K % 15;
                                }
                                //      END IF
                            }
                            //      IF KP=5 THEN
                            if (KP == 5)
                            {
                                //        PSET (XP,YP),COL  'print pixel
                                GW.PSET(XP, YP, COL);//  'print pixel ;
                                                     //      ELSE
                            }
                            else
                            {
                                //        LINE (XP,YP)-(XP+FP3-1,YP+FP3-1),COL,BF
                                GW.LINE(XP, YP, XP + FP3 - 1, YP + FP3 - 1, COL, "BF");
                                //      END IF
                            }
                            //      A$=GW.INKEY()
                            As = GW.INKEY();
                            //Debug.WriteLine("inkey: " + As);
                            //      IF GW.LEN(A$)>1 THEN
                            if (GW.LEN(As) > 0)
                            {
                                //             GOSUB keycontrol
                                keycontrol();
                                //             IF F7 THEN EXIT FOR
                                if (F7)
                                {
                                    break;
                                }
                                //           END IF
                            }
                            //    NEXT IP : IF F7 THEN EXIT FOR
                        }
                        if (F7)
                        {
                            break;
                        }
                        //       NEXT JP : IF F7 THEN EXIT FOR
                    }
                    if (F7)
                    {
                        break;
                    }
                    //       LINE (129,32)-(130,479),15,BF
                    GW.LINE(129, 32, 130, 479, 15, "BF");
                    //     NEXT KP
                }
                //     IF F7=0 THEN
                if (!F7)
                {
                    //       DO : A$=GW.INKEY()
                    do
                    {
                        As = GW.INKEY();
                        //       IF GW.LEN(A$)>1 THEN GOSUB keycontrol
                        if (GW.LEN(As) > 1)
                        {
                            keycontrol();
                        }
                        //       LOOP UNTIL F7
                    } while (!F7);
                }
                //     END IF
            } while (!F10);
            //   LOOP UNTIL F10

            //   SCREEN 0 : GW.PRINT( "Press any key";        
            GW.PRINT("Press any key");
            // END
            return;
            // startdata:
            void startdata()
            {
                //   GW.PRINT( "Mandelbrot Set"
                GW.PRINT("Mandelbrot Set");
                //   GW.PRINT( "=============="
                GW.PRINT("==============");
                //   GW.PRINT( "Give the X coordinate centre (default value -.75): ";
                GW.PRINT("Give the X coordinate centre (default value -.75)");
                //   GW.INPUT( "X=",AC : PRINT
                AC = GW.INPUT("X=");
                GW.PRINT("");
                //   GW.PRINT( "     the Y coordinate centre (default value 0): ";
                GW.PRINT("     the Y coordinate centre (default value 0)");
                //   GW.INPUT( "   Y=",BC : PRINT
                BC = GW.INPUT("   Y=");
                GW.PRINT("");
                //   GW.PRINT( "     halfwidth D (default value 1.6): ";TAB(52);
                GW.PRINT("     halfwidth D (default value 1.6)");
                //   GW.INPUT( "D=",DELH
                DELH = GW.INPUT("D=");
                //   IF AC=0 AND BC=0 AND DELH=0 THEN AC=-.75 : DELH=1.6
                if (AC == 0 && BC == 0 && DELH == 0)
                {
                    AC = -.75f;
                    DELH = 1.6f;
                }
                //   DELV=7*DELH/8
                DELV = 7 * DELH / 8f;
                //   NMAX=INT(LOG(2/DELH)*NBEGIN)
                NMAX = (int)(GW.LOG(2 / DELH) * NBEGIN);
                //   IF NMAX<NBEGIN THEN NMAX=NBEGIN
                if (NMAX < NBEGIN)
                {
                    NMAX = NBEGIN;
                }
                //   PRINT : PRINT "Press 'X' to eXit the program"
                GW.PRINT("");
                GW.PRINT("Press 'X' to eXit the program");
                //   PRINT "Press any key to start the program"
                GW.PRINT("Press any key to start the program");
                //   DO : A$=GW.INKEY() : LOOP UNTIL A$<>""
                As = GW.INKEY();

                // RETURN
                return;
            }
            // keycontrol:
            void keycontrol()
            {
                string aa = As;
                //   CS=ASC(MID(A$,2,1))
                CS = (char)As[1];
                       //   SELECT CASE CS
                switch (CS)
                {
                    //     CASE 60 : GOSUB textonoff                          'F2
                    case 60:
                        textonoff();//                          'F2();
                                    //     CASE 61,62 : GOSUB newmax                          'F3,F4
                        break;
                    case 61:
                    case 62:
                        newmax();// 'F3,F4();
                                 //     CASE 63,64 : GOSUB zoom                            'F5,F6
                        break;
                    case 63:
                    case 64:
                        zoom();// 'F5,F6();
                               //     CASE 65 : F7=1 : GOSUB newdata                     'F7
                        break;
                    case 65:
                        F7 = true;
                        newdata();// 'F7();
                                  //     CASE 67 : RUN                                      'F9
                        break;
                    case 67:
                        ;// RUN 'F9 ;
                         //     CASE 68 : F7=1 : F10=1                             'F10
                        break;
                    case 68:
                        F7 = true;
                        F10 = true;//                             'F10 ;
                                   //     CASE 72,75,77,80 : GOSUB moveframe                 'arrows
                        break;
                    case 72:
                    case 75:
                    case 77:
                    case 80:
                        moveframe();// 'arrows();
                                    //   END SELECT
                        break;
                    default:
                        break;
                }
                // RETURN
                return;
            }
            // textonoff:
            void textonoff()
            {
                int F2V = 0; if (F2) F2V = 1;
                //    F2=(F2+1) MOD 2
                F2V = (F2V + 1) % 2;
                F2 = (F2V == 1);
                //    FOR I=1 TO 24 : LOCATE I,1 : PRINT SPACE$(14); : NEXT I
                for (I = 1; I <= 24; I++)
                {
                    GW.LOCATE(I, 1);
                    GW.PRINT(GW.SPACE(14));
                }
                //    LOCATE 1,1 : PRINT SPACE$(80)
                GW.LOCATE(1, 1);
                GW.PRINT(GW.SPACE(80));
                //    IF F2 THEN GOSUB printdata : GOSUB helptext
                if (F2)
                {
                    printdata();
                    helptext();
                }
                //    LOCATE 1,1
                GW.LOCATE(1, 1);
                // RETURN
                return;
            }
            // printdata:
            void printdata()
            {
                //    LOCATE 1,1 : GW.PRINT( "Current DATA"
                GW.LOCATE(1, 1);
                GW.PRINT("Current DATA");
                //    LOCATE 1,20 : GW.PRINT( "AC = "; : PRINT AC
                GW.LOCATE(1, 20);
                GW.PRINT("AC = " + AC.ToString());
                //    LOCATE 1,50 : GW.PRINT( "BC = "; : PRINT BC
                GW.LOCATE(1, 40);
                GW.PRINT("BC = " + BC.ToString());
                //    LOCATE 3,1 :  GW.PRINT( "D = "; : PRINT USING"##.###^^^^";DELH
                GW.LOCATE(1, 60);
                GW.PRINT("D = " + DELH.ToString());
                //    DELV=7*DELH/8 : PRINT
                DELV = 7 * DELH / 8f;
                GW.PRINT("");
                //    LOCATE 5,1 : GW.PRINT( "MAX=";NMAX
                GW.LOCATE(2, 1);
                GW.PRINT("MAX=" + NMAX.ToString());
                // RETURN
                return;
            }
            // helptext:
            void helptext()
            {
                //    LOCATE 7,1 : GW.PRINT( "Keys:" : PRINT
                //GW.LOCATE(3, 1);
                GW.PRINT("Keys ");
                //    GW.PRINT( "F2 text on/off"
                GW.PRINT("F2 text on/off");
                //    GW.PRINT( "F3 MAX up"
                GW.PRINT("F3 MAX up");
                //    GW.PRINT( "F4 MAX down"
                GW.PRINT("F4 MAX down");
                //    GW.PRINT( "F5 zoom IN"
                GW.PRINT("F5 zoom IN");
                //    GW.PRINT( "F6 zoom OUT" : PRINT
                GW.PRINT("F6 zoom OUT");
                //    GW.PRINT( "zoom and" : GW.PRINT( "use arrows" : PRINT
                GW.PRINT("Arrow move left, right, up, down");
                //    GW.PRINT( "F7 show detail" : PRINT
                GW.PRINT("F7 show detail");
                //    GW.PRINT( "F9 restart" : PRINT
                //    GW.PRINT( "F10 end"
                GW.PRINT("F10 end");
                // RETURN
                return;
            }
            // zoom:
            void zoom()
            {
                //   IF CS=63 THEN
                if (CS == 63)
                {
                    //     XAN=XA+8 : XBN=XB-8 : YAN=YA+7 : YBN=YB-7
                    XAN = XA + 8;
                    XBN = XB - 8;
                    YAN = YA + 7;
                    YBN = YB - 7;
                    //     IF XBN-XAN<12 THEN XAN=XA : XBN=XB : YAN=YA : YBN=YB
                    if (XBN - XAN < 12)
                    {
                        XAN = XA;
                        XBN = XB;
                        YAN = YA;
                        YBN = YB;
                    }
                    //   END IF
                }
                //   IF CS=64 THEN XAN=XA-8 : XBN=XB+8 : YAN=YA-7 : YBN=YB+7
                if (CS == 64)
                {
                    XAN = XA - 8;
                    XBN = XB + 8;
                    YAN = YA - 7;
                    YBN = YB + 7;
                }
                //   GOSUB pixelcontrol
                pixelcontrol();
                // RETURN
                return;
            }
            // newdata:
            void newdata()
            {
                //   IF newframe=0 THEN RETURN
                if (newframe == 0)
                {
                    return;
                }
                //   AC=ACT+((XA+XB)/2-XM)*DELH/256
                AC = ACT + ((XA + XB) / 2 - XM) * DELH / 256;
                //   BC=BCT-((YA+YB)/2-YM)*DELV/224
                BC = BCT - ((YA + YB) / 2 - YM) * DELV / 224;
                //   DELH=DELH*(XB-XA)/512 : DELV=7*DELH/8
                DELH = DELH * (XB - XA) / 512;
                DELV = 7 * DELH / 8;
            } 
              // newmax:
            void newmax()
            {
                //   IF CS=61 THEN DF=1.1 ELSE DF=1/1.1
                if (CS == 61)
                {
                    DF = 1.1f;
                }
                else
                {
                    DF = 1 / 1.1f;
                }
                //   NBEGIN=INT(DF*NBEGIN)
                NBEGIN = (int)(DF * NBEGIN);
                //   NMAX=INT(LOG(2/DELH)*NBEGIN)
                NMAX = (int)(GW.LOG(2 / DELH) * NBEGIN);
                //   IF NMAX>5000 THEN
                if (NMAX > 5000)
                {
                    //     NMAX=5000
                    NMAX = 5000;
                    //     DO
                    do
                    {
                        //       NBEGIN=INT(NBEGIN/1.1)
                        NBEGIN = (int)(NBEGIN / 1.1f);
                        //     LOOP UNTIL INT(LOG(2/DELH)*NBEGIN)<=5000
                    } while (!((int)(GW.LOG(2 / DELH) * NBEGIN) <= 5000));
                    //   END IF
                }
                //   IF NMAX<NFIXED THEN
                if (NMAX < NFIXED)
                {
                    //     NMAX=NFIXED
                    NMAX = NFIXED;
                    //     DO
                    do
                    {
                        //       NBEGIN=INT(NBEGIN*1.1)
                        NBEGIN = (int)(NBEGIN * 1.1);
                        //     LOOP UNTIL INT(LOG(2/DELH)*NBEGIN)>=NFIXED
                    } while (!((int)(GW.LOG(2 / DELH) * NBEGIN) >= NFIXED));
                    //   END IF
                }
                //   GOSUB printdata
                printdata();
                //   newframe=0
                newframe = 0;
                // RETURN
                return;
            }
            // moveframe:
            void moveframe()
            {
                //   IF CS=72 THEN XAN=XA : XBN=XB : YAN=YA-7 : YBN=YB-7
                if (CS == 72)
                {
                    XAN = XA;
                    XBN = XB;
                    YAN = YA - 7;
                    YBN = YB - 7;
                }
                //   IF CS=75 THEN XAN=XA-8 : XBN=XB-8 : YAN=YA : YBN=YB
                if (CS == 75)
                {
                    XAN = XA - 8;
                    XBN = XB - 8;
                    YAN = YA;
                    YBN = YB;
                }
                //   IF CS=77 THEN XAN=XA+8 : XBN=XB+8 : YAN=YA : YBN=YB
                if (CS == 77)
                {
                    XAN = XA + 8;
                    XBN = XB + 8;
                    YAN = YA;
                    YBN = YB;
                }
                //   IF CS=80 THEN XAN=XA : XBN=XB : YAN=YA+7 : YBN=YB+7
                if (CS == 80)
                {
                    XAN = XA;
                    XBN = XB;
                    YAN = YA + 7;
                    YBN = YB + 7;
                }
                //   GOSUB pixelcontrol
                pixelcontrol();
                // RETURN
                return;
            }
            // pixelcontrol:
            void pixelcontrol()
            {
                //   FOR I=0 TO 40 : X=((40-I)*XA+I*XB)/40  'restore old frame
                for (I = 0; I <= 40; I++)
                {
                    X = ((40 - I) * XA + I * XB) / 40f; //  'restore old frame ;
                                                        //     PSET (X,YA),CU(I) : PSET (X,YB),CD(I)
                    GW.PSET(X, YA, CU[I]);
                    GW.PSET(X, YB, CD[I]);
                    //   NEXT I
                }
                //   FOR J=1 TO 35 : Y=((35-J)*YA+J*YB)/35
                for (J = 1; J <= 35; J++)
                {
                    Y = ((35 - J) * YA + J * YB) / 35f;
                    //     PSET (XA,Y),CL(J) : PSET (XB,Y),CR(J)
                    GW.PSET(XA, Y, CL[J]);
                    GW.PSET(XB, Y, CR[J]);
                    //   NEXT J
                }
                //   FOR I=0 TO 40 : X=((40-I)*XAN+I*XBN)/40  'save new frame
                for (I = 0; I <= 40; I++)
                {
                    X = ((40 - I) * XAN + I * XBN) / 40f; //  'save new frame ;
                                                          //     CU(I)=POINT (X,YAN) : CD(I)=POINT (X,YBN)
                    CU[I] = GW.POINT(X, YAN);
                    CD[I] = GW.POINT(X, YBN);
                    //   NEXT I
                }
                //   FOR J=1 TO 35 : Y=((35-J)*YAN+J*YBN)/35
                for (J = 1; J <= 35; J++)
                {
                    Y = ((35 - J) * YAN + J * YBN) / 35f;
                    //     CL(J)=POINT (XAN,Y) : CR(J)=POINT (XBN,Y)
                    CL[J] = GW.POINT(XAN, Y);
                    CR[J] = GW.POINT(XBN, Y);
                    //   NEXT J
                }
                //   XA=XAN : YA=YAN : XB=XBN : YB=YBN
                XA = XAN;
                YA = YAN;
                XB = XBN;
                YB = YBN;
                //   newframe=1  'set new frame
                newframe = 1;//  'set new frame ;
                             //   FOR I=0 TO 40 : X=((40-I)*XA+I*XB)/40
                for (I = 0; I <= 40; I++)
                {
                    X = ((40 - I) * XA + I * XB) / 40F;
                    //     PSET (X,YA),15 : PSET (X,YB),15
                    GW.PSET(X, YA, 15);
                    GW.PSET(X, YB, 15);
                    //   NEXT I
                }
                //   FOR J=1 TO 35 : Y=((35-J)*YA+J*YB)/35
                for (J = 1; J <= 35; J++)
                {
                    Y = ((35 - J) * YA + J * YB) / 35F;
                    //     PSET (XA,Y),15 : PSET (XB,Y),15
                    GW.PSET(XA, Y, 15);
                    GW.PSET(XB, Y, 15);
                    //   NEXT J
                }
                // RETURN
                return;
            }

        }
    }
}
