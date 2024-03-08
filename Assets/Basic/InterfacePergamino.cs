using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using Models;


public class InterfacePergamino : MonoBehaviour
{
    UIDocument PergaminoTemplate;
    VisualElement seccion_respuestas; // Elemento padre para las preguntas
    ScrollView scrollView;
    VisualElement respuestas;
    Button contestar;
    Button guardar;
    Toggle lastSelectedToggle;
    Label preguntaTexto;
    Pregunta pregunta;
    //private SQLiteDB sqliteDBInstance;


    void OnEnable()
    {
        PergaminoTemplate = GetComponent<UIDocument>();
        VisualElement root = PergaminoTemplate.rootVisualElement;
        //Asiganmos el boton para contestar
        guardar = root.Q<Button>("guardar");
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
        pregunta = CargarPregunta("M2P1P");
        preguntaTexto.text = pregunta.Planteamiento;
        AgregarOpciones(pregunta);

        // Configurar el botón "contestar"
        contestar.SetEnabled(false);
        contestar.clicked += ContestarClicked;
        guardar.clicked += GuardarDocuemnto;
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


        //List<string[]> opciones = sqliteDBInstance.SeleccionarRegistro("opcion", "id_pregunta", "1");
        /*
        List<string[]> opciones = sqliteDBInstance.SeleccionarRegistros( nombreTabla, nombreColumna, valor);
        for (int i = 0; i < opciones.Count; i++)
        {
         string[] opcion = opciones[i];
         string inciso = opcion[2];
         string descripcion = opcion[4];
         AgregarVisualElement(inciso, descripcion);

        }
        */
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


    void GuardarRespuesta(DatosRespuesta respuesta){
        string json = JsonUtility.ToJson(respuesta, true);
        File.WriteAllText(Application.dataPath+"/Modulos/Modullo2/Documentos/Respuestas/Respuesta"+respuesta.ClavePregunta+".json", json);

    }
    

    Pregunta CargarPregunta(string clave){
        Debug.Log("cargando");
        string json = File.ReadAllText(Application.dataPath+"/Modulos/Modullo2/Documentos/Preguntas/"+clave+".json");
        Pregunta pregunta = JsonUtility.FromJson<Pregunta>(json);
        return pregunta;
    }


    void GuardarDocuemnto(){
        Opcion opcion = new Opcion();
        opcion.Inciso = "A";
        opcion.OpcionTexto = "Opcion A";
        opcion.Correcta = true;
        DatosRespuesta respuesta = new DatosRespuesta();
        respuesta.IdEstudiante = 0;
        respuesta.ClavePregunta = "hola";
        respuesta.Opcion = opcion;
        Debug.Log(respuesta.ClavePregunta);
        GuardarRespuesta(respuesta);
    }

    DatosRespuesta ArmarRespuesta(string textoT){
        Debug.Log("El texto del togle es:"+textoT);
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

    void GuardarProgreso(string clave){
        ProgresoModulo progreso = new ProgresoModulo();
        List<string> pergaminosContestados = new List<string>();
        pergaminosContestados.Add(clave);
        
        progreso.pergaminosContestados = pergaminosContestados;
        Dictionary<string, string> secuencia = new Dictionary<string, string>();
        secuencia.Add("M2P1P","M2P7P");
        secuencia.Add("M2P7P","M2P13P");
        secuencia.Add("M2P13P","M2P17P");
        secuencia.Add("M2P17P","M2P23P");
        secuencia.Add("M2P23P","M2P28P");
        secuencia.Add("M2P28P","FINAL");
        progreso.pergaminoActual = secuencia[clave];
        progreso.secuencia = secuencia;
        string json = JsonUtility.ToJson(progreso, true);
        File.WriteAllText(Application.dataPath+"/Modulos/Modullo2/Documentos/Progreso/Progreso.json", json);
    }

    void ContestarClicked()
    {
        if (lastSelectedToggle != null)
        {
            string textoToggle = lastSelectedToggle.text;
            Debug.Log("Respuesta seleccionada: " + textoToggle);
            DatosRespuesta respuesta = ArmarRespuesta(textoToggle);
            GuardarRespuesta(respuesta);
            GuardarProgreso(pregunta.Clave);
        }
    }
    void Update()
    {
        
    }
}






