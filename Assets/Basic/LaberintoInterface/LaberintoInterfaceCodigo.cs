using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using JsonUtils;
using Models;
using System.IO;
using Scripts;
/// <summary>
/// Clase que representa el código de la interfaz del laberinto.
/// </summary>
public class LaberintoInterfaceCodigo : MonoBehaviour
{
    // Instancias de la Interface Gráfica.
    UIDocument LaberintoInterface;
    Button botonContestar;
    VisualElement cartel;
    VisualElement Puerta;
    Button BotonDer;
    Button BotonIzq;
    Label txt_pregunta;
    Label texto_cartel;
    Label txt_respuesta;
    //Indice de la opción actual en la pnatall
    int indice;
    //Cantidad de opciones de la pregunta
    int cantidad_opciones;
    //Pregunta que se muestra en la pantalla
    Pregunta pregunta;
    //Opción 
    Opcion opcionGlobal;
    //Saber si la opción en turno es correcta
    bool correcta;

    //Modulo actual
    int modulo;

    /// <summary>
    /// Método que se ejecuta al iniciar el objeto.
    /// </summary>
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
        cantidad_opciones = pregunta.Opciones.Count;
        txt_pregunta.text = pregunta.Planteamiento;
        indice = 0;
        AgregarOpciones(pregunta.Opciones);
    }

    /// <summary>
    /// Método que se ejecuta al habilitar el objeto.
    /// </summary>
    void OnEnable()
    {
        LaberintoInterface = GetComponent<UIDocument>();
        VisualElement root = LaberintoInterface.rootVisualElement;
        cartel = root.Q<VisualElement>("cartel");
        cartel.visible = false;
        BotonDer = root.Q<Button>("boton_der");
        BotonIzq = root.Q<Button>("BotonIzq");
        botonContestar = root.Q<Button>("BotonContestar");
        txt_pregunta = root.Q<Label>("Texto_pregunta");
        txt_respuesta = root.Q<Label>("Texto_respuesta");
        texto_cartel = root.Q<Label>("texto_cartel");
        Puerta = root.Q<VisualElement>("Puerta");
        botonContestar.clicked += ContestarClicked;
        BotonDer.clicked += navegarDer;
        BotonIzq.clicked += navegarIzq;
        correcta = false;
        texto_cartel.text = "";
    }

    /// <summary>
    /// Método para agregar las opciones en pantalla.
    /// </summary>
    /// <param name="Opciones">Lista de opciones de la pregunta.</param>
    void AgregarOpciones(List<Opcion> Opciones)
    {
        Opcion opcion = Opciones[indice];
        string inciso = opcion.Inciso;
        string descripcion = opcion.OpcionTexto;
        txt_respuesta.text = descripcion;
        correcta = opcion.Correcta;
    }

    /// <summary>
    /// Método para navegar hacia la derecha.
    /// </summary>
    void navegarDer()
    {
        if(indice < cantidad_opciones-1){
            indice++;
            opcionGlobal = pregunta.Opciones[indice];
            AgregarOpciones(pregunta.Opciones);
            Debug.Log("Derecha: "+correcta);
        }
    }

    /// <summary>
    /// Método para navegar hacia la izquierda.
    /// </summary>
    void navegarIzq()
    {
        if(indice > 0){
            indice--;
            opcionGlobal = pregunta.Opciones[indice];
            AgregarOpciones(pregunta.Opciones);
            Debug.Log("Izquierda: "+correcta);
        }
    }

    /// <summary>
    /// Método que se ejecuta al hacer clic en el botón de contestar.
    /// </summary>
    private async void ContestarClicked()
    {
        if(correcta == false){
            cartel.visible = true;
            texto_cartel.text = "Incorrecto";
            cartel.AddToClassList("cartelIncorrecto");
            await Task.Delay(1000);
            cartel.visible = false;
        }else{
            cartel.visible = true;
            texto_cartel.text = "Correcto";
            cartel.RemoveFromClassList("cartelIncorrecto");
            cartel.AddToClassList("cartelCorrecto");
            await Task.Delay(1000);
            cartel.visible = false;
            Puerta.RemoveFromClassList("puertaCerrada");
            await Task.Delay(2000);
            Puerta.AddToClassList("puertaCerrada");
        }
        //Guardamos la respuesta 
        DatosRespuesta respuesta = new DatosRespuesta();
        respuesta.IdEstudiante = 0;
        respuesta.ClavePregunta = pregunta.Clave;
        respuesta.Opcion = opcionGlobal;
        RespuestaJson.GuardarRespuesta(respuesta, modulo);

        //Actualizamos progreso 
        string siguientePreguntaClave = Secuencia.Secuencia2(pregunta.Clave, modulo);
        ProgresoJson.ActualizarProgreso(pregunta.Modulo, pregunta.Clave, siguientePreguntaClave);

        //Redirijimos al jugador
        SiguienteEscena.SiguienteEscenaRedireccion(siguientePreguntaClave);
    }
}
