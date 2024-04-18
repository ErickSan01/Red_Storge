using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Models;
using UnityEngine.SceneManagement;

namespace Scripts{
        public class SiguienteEscena{
            public static void SiguienteEscenaRedireccion(string clave){
                if(clave.Equals("FINAL")){
                    SceneManager.LoadScene("Mapa");
                }
                //La clave indica la fase en su ultimo caracters.
                string ultimoCaracter = clave[clave.Length-1].ToString();
                if(ultimoCaracter.Equals("P")){
                    SceneManager.LoadScene("Modulo"+clave[1]+"Nivel");
                }else if(ultimoCaracter.Equals("L")){
                    SceneManager.LoadScene("Laberinto");
                }else{
                    SceneManager.LoadScene("Recuperacion");
                }
            }
    }
}
