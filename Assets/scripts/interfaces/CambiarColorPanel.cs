using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CambiarColorPanel : MonoBehaviour
{
    public Dropdown dropdown;
    public Image panel;

    void Start()
    {
        // Configurar las opciones del Dropdown
        List<string> opciones = new List<string> { "Blanco", "Rojo", "Anaranjado", "Amarillo", "Verde Limón", "Verde Claro", "Azul Claro", "Morado", "Azul Turquesa", "Rosa", "Gris", "Negro" };
        dropdown.AddOptions(opciones);

        // Suscribir la función al evento de cambio del Dropdown
        dropdown.onValueChanged.AddListener(delegate {
            CambiarColorPanelSegunOpcion(dropdown);
        });
    }

    void CambiarColorPanelSegunOpcion(Dropdown dropdown)
    {
        // Obtener la opción seleccionada
        string opcionSeleccionada = dropdown.options[dropdown.value].text;

        // Cambiar el color del panel según la opción seleccionada
        switch (opcionSeleccionada)
        {
            case "Blanco":
                panel.color = Color.white;
                break;
            case "Rojo":
                panel.color = Color.red;
                break;
            case "Anaranjado":
                panel.color = new Color(1f, 0.5f, 0f);
                break;
            case "Amarillo":
                panel.color = Color.yellow;
                break;
            case "Verde Limón":
                panel.color = new Color(0.5f, 1f, 0f);
                break;
            case "Verde Claro":
                panel.color = new Color(0.5f, 1f, 0.5f);
                break;
            case "Azul Claro":
                panel.color = new Color(0f, 0.5f, 1f);
                break;
            case "Morado":
                panel.color = new Color(0.5f, 0f, 0.5f);
                break;
            case "Azul Turquesa":
                panel.color = new Color(0f, 1f, 1f);
                break;
            case "Rosa":
                panel.color = new Color(1f, 0.5f, 0.5f);
                break;
            case "Gris":
                panel.color = Color.gray;
                break;
            case "Negro":
                panel.color = Color.black;
                break;
            // Agregar más casos según sea necesario
        }
    }
}