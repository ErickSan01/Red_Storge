using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using Models;
using UnityEngine.SceneManagement;
using JsonUtils;
using Scripts;

public class InterfaceRecuperacion : MonoBehaviour
{
    //Elemetos de la Interface Gráfica
    UIDocument PergaminoTemplate;
    VisualElement seccion_respuestas; 
    ScrollView scrollView;
    VisualElement respuestas;
    Button contestar;
    Toggle lastSelectedToggle;
    Label preguntaTexto;

    VisualElement container;

    int modulo;

    //Pregunta actual mostrandose en la interface
    Pregunta pregunta;


    void Start()
    {
        ProgresoGeneral progresoGeneral = ProgresoGeneralJson.CargarProgreso();
        modulo = progresoGeneral.moduloActual;
        string json = File.ReadAllText(Application.dataPath+"/Modulos/Modulo"+modulo+"/Documentos/Progreso/Progreso.json");
        ProgresoModulo progreso = JsonUtility.FromJson<ProgresoModulo>(json);
        string clave = progreso.pergaminoActual;
        if(clave == "FINAL"){
            SceneManager.LoadScene("Mapa");
        }


        pregunta = PreguntaJson.CargarPregunta(clave);

        //Colocamos los eleemtos de la pregunta in la interface
        preguntaTexto.text = pregunta.Planteamiento;
        AgregarOpciones(pregunta);

        // Configurar el botón "contestar"
        contestar.SetEnabled(false);
        contestar.clicked += ContestarClicked;
        container.AddToClassList("container5");
    }

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

        container = root.Q<VisualElement>("contenedor");
        
    }


    void AgregarOpciones(Pregunta pregunta)
    {
        List<Opcion> opciones = pregunta.Opciones;
        for (int i = 0; i < opciones.Count; i++)
        {
         string inciso = opciones[i].Inciso;
         string descripcion = opciones[i].OpcionTexto;
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
        Label label = new Label(texto.Trim());
        label.AddToClassList("respuesta_texto");
        
        // Crear cuadro de contención de texto
        VisualElement limiteTexto = new VisualElement();
        limiteTexto.Add(label);

        // Crear el toggle hijo
        Toggle toggle = new Toggle();
        toggle.text = texto;
        toggle.name = "toggle_" + nombre;
        toggle.RegisterValueChangedCallback(OnToggleValueChanged);
        toggle.AddToClassList("texto_invisible");
        // Agregar el toggle al elemento visual
        visualElement.Add(toggle);
        visualElement.Add(limiteTexto);
        

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


    void GuardarRespuesta(DatosRespuesta respuesta){
        string json = JsonUtility.ToJson(respuesta, true);
        ProgresoGeneral progresoGeneral = ProgresoGeneralJson.CargarProgreso();
        int modulo = progresoGeneral.moduloActual;
        File.WriteAllText(Application.dataPath+"/Modulos/Modulo"+modulo+"/Documentos/Respuestas/Respuesta"+respuesta.ClavePregunta+".json", json);

    }
    
    DatosRespuesta ArmarRespuesta(string textoT){
        List<Opcion> Opciones = pregunta.Opciones;
        Opcion opcionCorrecta = new Opcion();
        for(int i = 0; i < Opciones.Count; i++){
            Opcion opcion = Opciones[i];
            if(opcion.OpcionTexto.Equals(textoT)){
                opcionCorrecta = opcion;
            }
        }
        DatosRespuesta respuesta = new DatosRespuesta();
        respuesta.IdEstudiante = 0;
        respuesta.ClavePregunta = pregunta.Clave;
        respuesta.Opcion = opcionCorrecta;
        return respuesta;
    }

    void GuardarProgreso(string clave, bool correcta){

        string siguientePergamino;
       
        //Guardar secuencia
        siguientePergamino = Secuencia.Secuencia2(clave, modulo);
        
        ProgresoJson.ActualizarProgreso(modulo, clave, siguientePergamino);
        SiguienteEscena.SiguienteEscenaRedireccion(siguientePergamino);
    }

    void ContestarClicked()
    {
        if (lastSelectedToggle != null)
        {
            string textoToggle = lastSelectedToggle.text;
            Debug.Log("Respuesta seleccionada: " + textoToggle);
            DatosRespuesta respuesta = ArmarRespuesta(textoToggle);
            Opcion opcion = respuesta.Opcion;

            RespuestaJson.GuardarRespuesta(respuesta, modulo);
            GuardarProgreso(pregunta.Clave, opcion.Correcta);            
        }
    }
 
}






