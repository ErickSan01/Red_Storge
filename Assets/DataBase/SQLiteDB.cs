using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System;
using System.Collections.Generic;

using System.Collections;

public class SQLiteDB : MonoBehaviour
{
    public static SQLiteDB instance;
    private string dbName = "URI=file:RedStorgeDB.db";
    private void Awake()
    {
        instance=this;
    }
    void Start()
    {

        CreateTables();
        Debug.Log("Hola desde la BD");
        //Query("INSERT INTO modulo (nombre) VALUES ('Modulo 1');");
        //Query("Drop table pregunta;");
        //Query("Drop table opcion;");
        //Query("INSERT INTO pregunta (planteamiento,id_modulo,Id_fase) VALUES ('pregunta ejemplo BD',1,1);");
        //Query("INSERT INTO opcion (id_pregunta, inciso, correcta, descripcion) VALUES (1,'a',true,'opcion A ejemplo BD')");
        //Query("INSERT INTO opcion (id_pregunta, inciso, correcta, descripcion) VALUES (1,'b',false,'opcion B ejemplo BD')");
        //Query("INSERT INTO opcion (id_pregunta, inciso, correcta, descripcion) VALUES (1,'c',false,'opcion C ejemplo BD')");
        string[][] matris = ParseFile("D:/Servicio/Red_Storge/Assets/DataBase/archivo.txt");
        string[] pregunta = matris[0];
        registrarPreguntaEnBD(pregunta);





    }

    private void CreateTables()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                string sqlcreation="";
                string rutaArchivo = "Assets/DataBase/sqlUnity.sql"; 
                string[] lineas = File.ReadAllLines(rutaArchivo);
                sqlcreation = string.Join("", lineas);
                command.CommandText = sqlcreation;
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    private void Query(string q)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = q;
                using (IDataReader reader = command.ExecuteReader())
                {

                }
            }
            connection.Close();
        }
    }


    //Seleccionar de tabla todos los registros. 
    public List<string[]> SeleccionarTabla(string nombreTabla)
    {
        string query = "SELECT * FROM " + nombreTabla;
        List<string[]> registros = new List<string[]>();
        using (var connection = new SqliteConnection(dbName))
        {
           connection.Open();
           using (var command = new SqliteCommand(query, connection))
           {
              using (var reader = command.ExecuteReader())
              {
                int columnCount = reader.FieldCount;

                while (reader.Read())
                {
                    string[] registro = new string[columnCount];

                    for (int i = 0; i < columnCount; i++)
                    {
                        registro[i] = reader[i].ToString();
                    }

                    registros.Add(registro);
                }
            }
        }
    }
    return registros;
    }

    //Seleccionar un registro especifico
    public string[] SeleccionarRegistro(string nombreTabla, string nombreColumna, string valor)
    {
    string query = $"SELECT * FROM {nombreTabla} WHERE {nombreColumna} = @valor";
    string[] registro = null;

    using (var connection = new SqliteConnection(dbName))
    {
        connection.Open();
        using (var command = new SqliteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@valor", valor);

            using (var reader = command.ExecuteReader())
            {
                int columnCount = reader.FieldCount;

                if (reader.Read())
                {
                    registro = new string[columnCount];

                    for (int i = 0; i < columnCount; i++)
                    {
                        registro[i] = reader[i].ToString();
                    }
                }
            }
        }
    }

        return registro;
    }

    //Todos los registros coincidentes
    public List<string[]> SeleccionarRegistros(string nombreTabla, string nombreColumna, string valor)
    {
    string query = $"SELECT * FROM {nombreTabla} WHERE {nombreColumna} = @valor";
    List<string[]> registros = new List<string[]>();

    using (var connection = new SqliteConnection(dbName))
    {
        connection.Open();

        using (var command = new SqliteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@valor", valor);

            using (var reader = command.ExecuteReader())
            {
                int columnCount = reader.FieldCount;

                while (reader.Read())
                {
                    string[] registro = new string[columnCount];

                    for (int i = 0; i < columnCount; i++)
                    {
                        registro[i] = reader[i].ToString();
                    }

                    registros.Add(registro);
                }
            }
        }
    }
    return registros;
    }

    public string[][] ParseFile(string filePath)
    {
        List<string[]> matrix = new List<string[]>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Trim('(', ')').Split(new string[] { "//" }, StringSplitOptions.RemoveEmptyEntries);
                matrix.Add(parts);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer el archivo: " + ex.Message);
        }
        return matrix.ToArray();
    }

     public string[] decifrarCodigoPregunta(string codigo){
        string[] datos = new string[2];
        datos[0] = codigo[1].ToString();
         switch (codigo[5])
        {
            case 'P':
                datos[1] = "1";
                break;
            case 'R':
                datos[1] = "2";
                break;
            case 'S':
                datos[1] = "3";
                break;
            default:
                break;
        }
        return datos;


    }
    public void registrarPreguntaEnBD(string [] pregunta){
        string codigo = pregunta[0];
        string plantemaiento = pregunta[1];
        string[] datos = decifrarCodigoPregunta(codigo);
        string modulo = datos[0];
        string fase = datos[1];
        string mc = pregunta[2];
        string consulta= "INSERT INTO pregunta (PLANTEAMIENTO, ID_MODULO, ID_FASE, ID_MATERIAL_CONSULTA) VALUES ("+
        "'"+plantemaiento+"'"+","+
        modulo+","+
        fase+","+
        mc+")";
        Debug.Log(consulta);
        Query(consulta); 


    }
}
