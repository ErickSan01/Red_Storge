using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{


    public class Secuencia{

        public static string Secuencia1(string clave, int modulo){
            Dictionary<string, string> secuencia = new Dictionary<string, string>();
            if (modulo == 2){
                secuencia.Add("M2P1P","M2P7P");
                secuencia.Add("M2P7P","M2P13P");
                secuencia.Add("M2P13P","M2P17P");
                secuencia.Add("M2P17P","M2P23P");
                secuencia.Add("M2P23P","M2P28P");
                secuencia.Add("M2P28P","FINAL");
            }
            if (modulo == 4){
                secuencia.Add("M4P1FP","M4P6FP");
                secuencia.Add("M4P6FP","M4P11FP");
                secuencia.Add("M4P11FP","M4P16FP");
                secuencia.Add("M4P16FP","M4P22FP");
                secuencia.Add("M4P22FP","M4P27FP");
                secuencia.Add("M4P27FP","M4P31FD");

            }            
            

            return secuencia[clave];
        }




        //Este método contiene la secuencia 2
        //La cual se usa cuando un pergamino de puente es contestado erronaemnete
        //Tambien se usa cuando se contesta el laberinto o la recuperación
               public static string Secuencia2(string clave, int modulo){
               Dictionary<string, string> secuencia2 = new Dictionary<string, string>();
                if (modulo == 2){
                     secuencia2.Add("M2P1P", "M2P2L");
                     secuencia2.Add("M2P2L", "M2P3L");
                     secuencia2.Add("M2P3L", "M2P4E");
                     secuencia2.Add("M2P4E", "M2P5E");
                     secuencia2.Add("M2P5E", "M2P6E");
                     secuencia2.Add("M2P6E", "M2P7P");
                     secuencia2.Add("M2P7P", "M2P8L");
                     secuencia2.Add("M2P8L", "M2P9L");
                     secuencia2.Add("M2P9L", "M2P10E");
                     secuencia2.Add("M2P10E", "M2P11E");
                     secuencia2.Add("M2P11E", "M2P12E");
                     secuencia2.Add("M2P12E", "M2P13P");
                     secuencia2.Add("M2P13P", "M2P14E");
                     secuencia2.Add("M2P14E", "M2P15E");
                     secuencia2.Add("M2P15E", "M2P16E");
                     secuencia2.Add("M2P16E", "M2P17P");
                     secuencia2.Add("M2P17P", "M2P18L");
                     secuencia2.Add("M2P18L", "M2P19L");
                     secuencia2.Add("M2P19L", "M2P20L");
                     secuencia2.Add("M2P20L", "M2P21E");
                     secuencia2.Add("M2P21E", "M2P22E");
                     secuencia2.Add("M2P22E", "M2P23P");
                     secuencia2.Add("M2P23P", "M2P24L");
                     secuencia2.Add("M2P24L", "M2P25L");
                     secuencia2.Add("M2P25L", "M2P26E");
                     secuencia2.Add("M2P26E", "M2P27E");
                     secuencia2.Add("M2P27E", "M2P28P");
                     secuencia2.Add("M2P28P", "M2P29E");
                     secuencia2.Add("M2P29E", "M2P30E");
                     secuencia2.Add("M2P30E", "FINAL");
                 }

                if (modulo == 4){
                     secuencia2.Add("M4P1FP", "M4P2FL");
                     secuencia2.Add("M4P2FL", "M4P3FL");
                     secuencia2.Add("M4P3FL", "M4P4FE");
                     secuencia2.Add("M4P4FE", "M4P5FE");
                     secuencia2.Add("M4P5FE", "M4P6FP");
                     secuencia2.Add("M4P6FP", "M4P7FL");
                     secuencia2.Add("M4P7FL", "M4P8FL");
                     secuencia2.Add("M4P8FL", "M4P9FE");
                     secuencia2.Add("M4P9FE", "M4P10FE");
                     secuencia2.Add("M4P10FE", "M4P11FP");
                     secuencia2.Add("M4P11FP", "M4P12FL");
                     secuencia2.Add("M4P12FL", "M4P13FL");
                     secuencia2.Add("M4P13FL", "M4P14FE");
                     secuencia2.Add("M4P14FE", "M4P15FE");
                     secuencia2.Add("M4P15FE", "M4P16FP");
                     secuencia2.Add("M4P16FP", "M4P17FL");
                     secuencia2.Add("M4P17FL", "M4P18FL");
                     secuencia2.Add("M4P18FL", "M4P19FE");
                     secuencia2.Add("M4P19FE", "M4P20FE");
                     secuencia2.Add("M4P20FE", "M4P21FE");
                     secuencia2.Add("M4P21FE", "M4P22FP");
                     secuencia2.Add("M4P22FP", "M4P23FL");
                     secuencia2.Add("M4P23FL", "M4P24FL");
                     secuencia2.Add("M4P24FL", "M4P25FE");
                     secuencia2.Add("M4P25FE", "M4P26FE");
                     secuencia2.Add("M4P26FE", "M4P27FP");
                     secuencia2.Add("M4P27FP", "M4P28FL");
                     secuencia2.Add("M4P28FL", "M4P29FE");
                     secuencia2.Add("M4P29FE", "M4P30FE");
                     secuencia2.Add("M4P30FE", "M4P31FD");
                 }           
               return secuencia2[clave];
            }
    }
    
}