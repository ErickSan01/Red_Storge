using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class InterfacePergamino : MonoBehaviour
{
    UIDocument PergaminoTemplate;
    VisualElement seccion_respuestas; // Elemento padre para las preguntas
    ScrollView scrollView;
    VisualElement respuestas;
    Button contestar;
    Toggle lastSelectedToggle;
    Label preguntaTexto;
    private SQLiteDB sqliteDBInstance;


    void OnEnable()
    {
        PergaminoTemplate = GetComponent<UIDocument>();
        VisualElement root = PergaminoTemplate.rootVisualElement;
        //Asiganmos el boton para contestar
        contestar = root.Q<Button>("contestar");
        seccion_respuestas = root.Q<VisualElement>("seccion_respuestas"); 
        preguntaTexto = root.Q<Label>("pregunta_texto");
        preguntaTexto.text = "Pregunta prueba";
        
        // Crear el ScrollView vertical
        scrollView = new ScrollView();
        scrollView.name = "scrollView";
        scrollView.AddToClassList("full_size");
        seccion_respuestas.Add(scrollView);
        // Espacio de las opciones
        respuestas = new VisualElement();
        respuestas.name = "respuestas";
        respuestas.AddToClassList("full_size");
        scrollView.Add(respuestas);
        
    }

    void Start()
    {
        GameObject sqliteDBObject = GameObject.Find("SQLiteDB");
        sqliteDBInstance = sqliteDBObject.GetComponent<SQLiteDB>();
        string[] resultados = sqliteDBInstance.SeleccionarRegistro("fase", "id_fase", "5");
        preguntaTexto.text = resultados[1];
        AgregarOpciones("opcion", "id_pregunta", "1");

        

        // Configurar el botón "contestar"
        contestar.SetEnabled(false);
        contestar.clicked += ContestarClicked;
    }

    void AgregarOpciones(string nombreTabla, string nombreColumna, string valor)
    {
        //List<string[]> opciones = sqliteDBInstance.SeleccionarRegistro("opcion", "id_pregunta", "1");
        List<string[]> opciones = sqliteDBInstance.SeleccionarRegistros( nombreTabla, nombreColumna, valor);
        for (int i = 0; i < opciones.Count; i++)
        {
         string[] opcion = opciones[i];
         string inciso = opcion[2];
         string descripcion = opcion[4];
         AgregarVisualElement(inciso, descripcion);

        }
    }

    void AgregarVisualElement(string nombre, string texto)
    {
        // Crear el elemento visual con la clase de estilos ".respuesta"
        VisualElement visualElement = new VisualElement();
        visualElement.name = nombre;
        visualElement.AddToClassList("respuesta");

        // Crear el label hijo con el texto especificado
        Label label = new Label(texto);
        label.AddToClassList("respuesta_texto");
        

        // Crear el toggle hijo
        Toggle toggle = new Toggle();
        toggle.text = texto;
        toggle.name = "toggle_" + nombre;
        toggle.RegisterValueChangedCallback(OnToggleValueChanged);
        toggle.AddToClassList("texto_invisible");
        // Agregar el toggle al elemento visual
        visualElement.Add(toggle);
        visualElement.Add(label);

        // Agregar el elemento visual al elemento padre "respuestas"
        respuestas.Add(visualElement);
    }

    void OnToggleValueChanged(ChangeEvent<bool> evt)
    {
        Toggle toggle = (Toggle)evt.target;
        if (toggle.value)
        {
            // Desactivar el último toggle seleccionado
            if (lastSelectedToggle != null && lastSelectedToggle != toggle)
            {
                lastSelectedToggle.value = false;
            }

            // Guardar el nuevo toggle seleccionado
            lastSelectedToggle = toggle;
        }
        else
        {
            // Si el toggle se desmarca, se establece como último toggle seleccionado a nulo
            if (lastSelectedToggle == toggle)
            {
                lastSelectedToggle = null;
            }
        }

        // Habilitar o deshabilitar el botón "contestar" según si hay un toggle seleccionado o no
        contestar.SetEnabled(lastSelectedToggle != null);
    }

    void ContestarClicked()
    {
        if (lastSelectedToggle != null)
        {
            string textoToggle = lastSelectedToggle.text;
            Debug.Log("Respuesta seleccionada: " + textoToggle);
        }
    }
    void Update()
    {
        
    }
}






