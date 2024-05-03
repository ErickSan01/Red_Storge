using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Models;
using System.IO;

public class Menu_Medallas_Script : MonoBehaviour
{
    UIDocument menuMedallas;

    void OnEnable()
    {
        menuMedallas = GetComponent<UIDocument>();

        VisualElement root = menuMedallas.rootVisualElement;

        VisualElement medallaMod1 = root.Q<VisualElement>("medallaMod1");
        VisualElement medallaMod2 = root.Q<VisualElement>("medallaMod2");
        VisualElement medallaMod3 = root.Q<VisualElement>("medallaMod3");
        VisualElement medallaMod4 = root.Q<VisualElement>("medallaMod4");
        VisualElement medallaMod5 = root.Q<VisualElement>("medallaMod5");

        Color color_medalla1_og = medallaMod1.style.backgroundColor.value;
        Color color_medalla2_og = medallaMod2.style.backgroundColor.value;
        Color color_medalla3_og = medallaMod3.style.backgroundColor.value;
        Color color_medalla4_og = medallaMod4.style.backgroundColor.value;
        Color color_medalla5_og = medallaMod5.style.backgroundColor.value;

        string json = File.ReadAllText(Application.dataPath+"/Modulos/Modullo2/Documentos/Progreso/ProgresoModulos.json");
        ProgresoModulosCompletados modulosCompletados = JsonUtility.FromJson<ProgresoModulosCompletados>(json);

        asignarColor("Modulo1", medallaMod1, modulosCompletados);
        asignarColor("Modulo2", medallaMod2, modulosCompletados);
        asignarColor("Modulo3", medallaMod3, modulosCompletados);
        asignarColor("Modulo4", medallaMod4, modulosCompletados);
        asignarColor("Modulo5", medallaMod5, modulosCompletados);

    }

    void asignarColor(string modulo, VisualElement medallaMod, ProgresoModulosCompletados modulosCompletados)
    {
        //checar si el modulo ha sido terminado, si ya fue terminado, no cambiar color
        //si aun no ha sido terminado cambiar color a blanco y negro

        Color nuevoColor = new Color(0.3f, 0.3f, 0.3f);
        Debug.Log(string.Join("\n", modulosCompletados.getModulos()));
        if(!modulosCompletados.getModulos().Contains(modulo)){
            medallaMod.style.unityBackgroundImageTintColor = nuevoColor;
            medallaMod.style.backgroundColor = nuevoColor;

        }
    }
}

