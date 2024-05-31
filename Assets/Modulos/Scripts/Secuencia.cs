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
            if (modulo == 3){
                secuencia.Add("M3P1P","M3P8P");
                secuencia.Add("M3P8P","M3P12P");
                secuencia.Add("M3P12P","M3P18P");
                secuencia.Add("M3P18P","M3P23P");
                secuencia.Add("M3P23P","M3P28P");
                secuencia.Add("M3P28P","M3P35P");
                secuencia.Add("M3P35P","M3P38D");
            }
            if (modulo == 4){
                secuencia.Add("M4P1FP","M4P6FP");
                secuencia.Add("M4P6FP","M4P11FP");
                secuencia.Add("M4P11FP","M4P16FP");
                secuencia.Add("M4P16FP","M4P22FP");
                secuencia.Add("M4P22FP","M4P27FP");
                secuencia.Add("M4P27FP","FINAL");

            }  
            if (modulo == 5){
                secuencia.Add("M5P1P","M5P7P");
                secuencia.Add("M5P7P","M5P12P");
                secuencia.Add("M5P12P","M5P16P");
                secuencia.Add("M5P16P","M5P20P");
                secuencia.Add("M5P20P","M5P24P");
                secuencia.Add("M5P24P","M5P28D");
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
                if (modulo == 3){
                    secuencia2.Add("M3P1P", "M3P2L");
                    secuencia2.Add("M3P2L", "M3P3L");
                    secuencia2.Add("M3P3L", "M3P4L");
                    secuencia2.Add("M3P4L", "M3P5L");
                    secuencia2.Add("M3P5L", "M3P6E");
                    secuencia2.Add("M3P6E", "M3P7E");
                    secuencia2.Add("M3P7E", "M3P8P");
                    secuencia2.Add("M3P8P", "M3P9L");
                    secuencia2.Add("M3P9L", "M3P10L");
                    secuencia2.Add("M3P10L", "M3P11E");
                    secuencia2.Add("M3P11E", "M3P12P");
                    secuencia2.Add("M3P12P", "M3P13L");
                    secuencia2.Add("M3P13L", "M3P14L");
                    secuencia2.Add("M3P14L", "M3P15L");
                    secuencia2.Add("M3P15L", "M3P16E");
                    secuencia2.Add("M3P16E", "M3P17E");
                    secuencia2.Add("M3P17E", "M3P18P");
                    secuencia2.Add("M3P18P", "M3P19L");
                    secuencia2.Add("M3P19L", "M3P20L");
                    secuencia2.Add("M3P20L", "M3P21E");
                    secuencia2.Add("M3P21E", "M3P22E");
                    secuencia2.Add("M3P22E", "M3P23P");
                    secuencia2.Add("M3P23P", "M3P24L");
                    secuencia2.Add("M3P24L", "M3P25L");
                    secuencia2.Add("M3P25L", "M3P26E");
                    secuencia2.Add("M3P26E", "M3P27E");
                    secuencia2.Add("M3P27E", "M3P28P");
                    secuencia2.Add("M3P28P", "M3P29L");
                    secuencia2.Add("M3P29L", "M3P30L");
                    secuencia2.Add("M3P30L", "M3P31L");
                    secuencia2.Add("M3P31L", "M3P32E");
                    secuencia2.Add("M3P32E", "M3P33E");
                    secuencia2.Add("M3P33E", "M3P34E");
                    secuencia2.Add("M3P34E", "M3P35P");
                    secuencia2.Add("M3P35P", "M3P36L");
                    secuencia2.Add("M3P36L", "M3P37L");
                    secuencia2.Add("M3P37L", "M3P38D");
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
                     secuencia2.Add("M4P31FD", "FINAL");
                 }     


                if (modulo == 5){
                    secuencia2.Add("M5P1P", "M5P2L");
                    secuencia2.Add("M5P2L", "M5P3L");
                    secuencia2.Add("M5P3L", "M5P4L");
                    secuencia2.Add("M5P4L", "M5P5E");
                    secuencia2.Add("M5P5E", "M5P6E");
                    secuencia2.Add("M5P6E", "M5P7P");
                    secuencia2.Add("M5P7P", "M5P8L");
                    secuencia2.Add("M5P8L", "M5P9L");
                    secuencia2.Add("M5P9L", "M5P10E");
                    secuencia2.Add("M5P10E", "M5P11E");
                    secuencia2.Add("M5P11E", "M5P12P");
                    secuencia2.Add("M5P12P", "M5P13L");
                    secuencia2.Add("M5P13L", "M5P14E");
                    secuencia2.Add("M5P14E", "M5P15E");
                    secuencia2.Add("M5P15E", "M5P16P");
                    secuencia2.Add("M5P16P", "M5P17L");
                    secuencia2.Add("M5P17L", "M5P18L");
                    secuencia2.Add("M5P18L", "M5P19E");
                    secuencia2.Add("M5P19E", "M5P20P");
                    secuencia2.Add("M5P20P", "M5P21L");
                    secuencia2.Add("M5P21L", "M5P22E");
                    secuencia2.Add("M5P22E", "M5P23E");
                    secuencia2.Add("M5P23E", "M5P24P");
                    secuencia2.Add("M5P24P", "M5P25L");
                    secuencia2.Add("M5P25L", "M5P26E");
                    secuencia2.Add("M5P26E", "M5P27E");
                    secuencia2.Add("M5P27E", "M5P28D");
                }  
               return secuencia2[clave];
            }
    }
    
}