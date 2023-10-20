using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Threading;
using System.Threading.Tasks;
public class LaberintoInterfaceCodigo : MonoBehaviour
{
    UIDocument LaberintoInterface;
    Button botonContestar;
    VisualElement cartel;
    VisualElement Puerta;
    Button BotonDer;
    Button BotonIzq;
    private SQLiteDB sqliteDBInstance;
    Label txt_pregunta;
    Label texto_cartel;
    Label txt_respuesta;
    int indice;
    int cantidad_opciones;

    bool correcta;
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
        
    }


    void Start()
    {
        GameObject sqliteDBObject = GameObject.Find("SQLiteDB");
        sqliteDBInstance = sqliteDBObject.GetComponent<SQLiteDB>();
        string[] resultados = sqliteDBInstance.SeleccionarRegistro("pregunta", "id_pregunta", "1");
        List<string[]> opciones = sqliteDBInstance.SeleccionarRegistros("opcion", "id_pregunta", "1");
        cantidad_opciones = opciones.Count;
        txt_pregunta.text = resultados[1];
        indice = 0;
        AgregarOpciones("opcion", "id_pregunta", "1", indice);
    }

    void AgregarOpciones(string nombreTabla, string nombreColumna, string valor, int indice)
    {
        //List<string[]> opciones = sqliteDBInstance.SeleccionarRegistro("opcion", "id_pregunta", "1");
        List<string[]> opciones = sqliteDBInstance.SeleccionarRegistros( nombreTabla, nombreColumna, valor);
        string[] opcion = opciones[indice];
        string inciso = opcion[2];
        string descripcion = opcion[4];
        txt_respuesta.text = descripcion;
        correcta = bool.Parse(opcion[3].ToLower());
        //Debug.Log(correcta);
        //correcta =  int.Parse(opcion[3]);
    }

    void navegarDer(){
        if(indice < cantidad_opciones-1){
            indice++;
            AgregarOpciones("opcion", "id_pregunta", "1", indice);
            Debug.Log("Derecha: "+correcta);
        }
    }

    void navegarIzq(){
        if(indice > 0){
            indice--;
            AgregarOpciones("opcion", "id_pregunta", "1", indice);
            Debug.Log("Izquierda: "+correcta);
    

        }
    }


    void Update()
    {
        
    }

}
