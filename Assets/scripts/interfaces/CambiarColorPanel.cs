using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/// <summary>
/// Clase que controla el cambio de color de un panel según la opción seleccionada en un Dropdown.
/// </summary>
public class CambiarColorPanel : MonoBehaviour
{
    public Dropdown dropdown;
    public Image panel;
    private SQLiteDB sqliteDBInstance;
    public TextMeshProUGUI nombre;
    public TextMeshProUGUI edad;
    public TextMeshProUGUI color;

    void Start()
    {
        GameObject sqliteDBObject = GameObject.Find("SQLiteDB");
        sqliteDBInstance = sqliteDBObject.GetComponent<SQLiteDB>();  
        //string[] resultados = sqliteDBInstance.SeleccionarRegistro("estudiante", "ID_USUARIO", "1");
        //Debug.Log(resultados[5]);
        string[] resultados2 = sqliteDBInstance.SeleccionarRegistro("usuario", "ID_USUARIO", "1");
        /*if (resultados2.Length > 1)
        {
            string datoEnPosicion2 = resultados2[1];
            Debug.Log(datoEnPosicion2);
        }
        else
        {
            Debug.LogError("El arreglo resultados2 no tiene al menos 2 elementos.");
        }*/
        CambiarNombre("Pepe");
        CambiarEdad("12");
        CambiarColor("Azul Claro");
    }

    /// <summary>
    /// Cambia el color del panel según la opción seleccionada en el Dropdown.
    /// </summary>
    /// <param name="valor">La opción seleccionada en el Dropdown.</param>
    void CambiarColor(string valor)
    {
        // Obtener la opción seleccionada
        Debug.Log("Cambiao");
        string opcionSeleccionada = valor;
        
        if (color != null)
        {
            color.text = "Color favorito: "+valor;
        }
        else
        {
            Debug.LogError("No se ha asignado el objeto Text al color.");
        }

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

    /// <summary>
    /// Cambia el nombre mostrado en el TextMeshProUGUI de nombre.
    /// </summary>
    /// <param name="valor">El nuevo nombre.</param>
    void CambiarNombre(string valor){
        if (nombre != null)
        {
            nombre.text = "Nombre: "+valor;
        }
        else
        {
            Debug.LogError("No se ha asignado el objeto Text al nombre.");
        }
    }

    /// <summary>
    /// Cambia la edad mostrada en el TextMeshProUGUI de edad.
    /// </summary>
    /// <param name="valor">La nueva edad.</param>
    void CambiarEdad(string valor){
        if (edad != null)
        {
            edad.text = "Edad: "+valor;
        }
        else
        {
            Debug.LogError("No se ha asignado el objeto Text a la edad.");
        }
    }
}