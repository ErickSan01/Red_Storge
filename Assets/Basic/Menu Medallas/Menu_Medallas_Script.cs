using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Models;
using System.IO;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que controla el comportamiento del menú de medallas.
/// </summary>
public class Menu_Medallas_Script : MonoBehaviour
{
    UIDocument menuMedallas;
    Button botonAtras;

    /// <summary>
    /// Método que se ejecuta al habilitar el objeto.
    /// </summary>
    void OnEnable()
    {
        menuMedallas = GetComponent<UIDocument>();

        VisualElement root = menuMedallas.rootVisualElement;
        botonAtras = root.Q<Button>("boton-atras");

        VisualElement medallaMod1 = root.Q<VisualElement>("medallaMod1");
        VisualElement medallaMod2 = root.Q<VisualElement>("medallaMod2");
        VisualElement medallaMod3 = root.Q<VisualElement>("medallaMod3");
        VisualElement medallaMod4 = root.Q<VisualElement>("medallaMod4");
        VisualElement medallaMod5 = root.Q<VisualElement>("medallaMod5");

        string json = File.ReadAllText(Application.dataPath+"/Modulos/General/Documentos/ProgresoGeneral/Progreso.json");
        ProgresoGeneral modulosCompletados = JsonUtility.FromJson<ProgresoGeneral>(json);

        asignarColor(1, medallaMod1, modulosCompletados);
        asignarColor(2, medallaMod2, modulosCompletados);
        asignarColor(3, medallaMod3, modulosCompletados);
        asignarColor(4, medallaMod4, modulosCompletados);
        asignarColor(5, medallaMod5, modulosCompletados);

        botonAtras.clicked += OnBtnAtrasClick;
    }

    /// <summary>
    /// Método que asigna el color a una medalla según si el módulo ha sido completado o no.
    /// </summary>
    /// <param name="modulo">Número del módulo.</param>
    /// <param name="medallaMod">Elemento visual de la medalla.</param>
    /// <param name="modulosCompletados">Objeto que contiene los módulos completados.</param>
    void asignarColor(int modulo, VisualElement medallaMod, ProgresoGeneral modulosCompletados)
    {
        //checar si el modulo ha sido terminado, si ya fue terminado, no cambiar color
        //si aun no ha sido terminado cambiar color a blanco y negro

        Color nuevoColor = new Color(0.3f, 0.3f, 0.3f);
        Debug.Log(string.Join("\n", modulosCompletados.getModulos()));
        Debug.Log(modulosCompletados.getModulos().Contains(modulo));
        if(!modulosCompletados.getModulos().Contains(modulo)){
            medallaMod.style.unityBackgroundImageTintColor = nuevoColor;
            medallaMod.style.backgroundColor = nuevoColor;
        }
    }

    /// <summary>
    /// Método que se ejecuta al hacer clic en el botón de regresar.
    /// </summary>
    void OnBtnAtrasClick(){
        SceneManager.LoadScene("MenuPrincipal");
    }
}

