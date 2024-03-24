using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modulo2{


    public class Secuencia{

        public static string Secuencia1(string clave){
            Dictionary<string, string> secuencia = new Dictionary<string, string>();
            secuencia.Add("M2P1P","M2P7P");
            secuencia.Add("M2P7P","M2P13P");
            secuencia.Add("M2P13P","M2P17P");
            secuencia.Add("M2P17P","M2P23P");
            secuencia.Add("M2P23P","M2P28P");
            secuencia.Add("M2P28P","FINAL");

            return secuencia[clave];
        }




        //Este método contiene la secuencia 2
        //La cual se usa cuando un pergamino de puente es contestado erronaemnete
        //Tambien se usa cuando se contesta el laberinto o la recuperación
        public static string Secuencia2(string clave){
        Dictionary<string, string> secuencia2 = new Dictionary<string, string>
        {
            {"M2P1P", "M2P2L"},
            {"M2P2L", "M2P3L"},
            {"M2P3L", "M2P4E"},
            {"M2P4E", "M2P5E"},
            {"M2P5E", "M2P6E"},
            {"M2P6E", "M2P7P"},
            {"M2P7P", "M2P8L"},
            {"M2P8L", "M2P9L"},
            {"M2P9L", "M2P10E"},
            {"M2P10E", "M2P11E"},
            {"M2P11E", "M2P12E"},
            {"M2P12E", "M2P13P"},
            {"M2P13P", "M2P14E"},
            {"M2P14E", "M2P15E"},
            {"M2P15E", "M2P16E"},
            {"M2P16E", "M2P17P"},
            {"M2P17P", "M2P18L"},
            {"M2P18L", "M2P19L"},
            {"M2P19L", "M2P20L"},
            {"M2P20L", "M2P21E"},
            {"M2P21E", "M2P22E"},
            {"M2P22E", "M2P23P"},
            {"M2P23P", "M2P24L"},
            {"M2P24L", "M2P25L"},
            {"M2P25L", "M2P26E"},
            {"M2P26E", "M2P27E"},
            {"M2P27E", "M2P28P"},
            {"M2P28P", "M2P29E"},
            {"M2P29E", "M2P30E"},
            {"M2P30E", "FINAL"}
        };
        return secuencia2[clave];
    }
    }
    
}