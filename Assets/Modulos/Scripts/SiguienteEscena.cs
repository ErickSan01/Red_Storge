using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Models;
using UnityEngine.SceneManagement;

namespace Scripts{
    /// <summary>
    /// Clase que contiene métodos para redireccionar a la siguiente escena.
    /// </summary>
    public class SiguienteEscena{
        /// <summary>
        /// Método para redireccionar a la siguiente escena según la clave proporcionada.
        /// </summary>
        /// <param name="clave">La clave que indica la fase de la siguiente escena.</param>
        public static void SiguienteEscenaRedireccion(string clave){
            if(clave.Equals("FINAL")){
                SceneManager.LoadScene("Mapa");
            }
            //La clave indica la fase en su último carácter.
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
