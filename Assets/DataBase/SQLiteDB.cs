using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System;

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
        Debug.Log("Hola");

        //Query("INSERT INTO fase (nombre) VALUES ('Jonny');");
        //Query("INSERT INTO pregunta (planteamiento,id_modulo,Id_fase) VALUES ('pregunta ejemplo 2',1,1);");
        //Query("INSERT INTO opcion (id_pregunta, inciso, descripcion) VALUES (1,'B', 'OPCION B');");
        string[] pregunta = SelectFromPregunta("1");
        Debug.Log("Pregunta: "+pregunta[1]);
        string[][] respuestas = SelectOpcion("1");
        //string[] respuesta = respuestas[0];
        //Debug.Log("Respuesta: "+respuesta[2]);


        //Query("SELECT * FROM fase;");
        //string[,] results = SelectFromFase("SELECT * FROM fase;");
    }

    private void CreateTables()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                string sqlcreation="";
                string rutaArchivo = "D:/Servicio/Red_Storge/Assets/DataBase/sqlUnity.sql"; 
                string[] lineas = File.ReadAllLines(rutaArchivo);
                sqlcreation = string.Join("", lineas);
                command.CommandText = sqlcreation;
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void Query(string q)
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


    public string[] SelectFromPregunta(String idPregunta)
    {
        String q = "SELECT * FROM pregunta WHERE ID_PREGUNTA ="+idPregunta+";";
        string[] pregunta = new string[4];
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = q;
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if(idPregunta.Equals(reader["ID_PREGUNTA"]+"")){
                            pregunta[0] = reader["ID_PREGUNTA"]+"";
                            pregunta[1] = reader["PLANTEAMIENTO"].ToString()+"";
                            pregunta[2] = reader["ID_MODULO"].ToString()+"";
                            pregunta[3] = reader["ID_FASE"].ToString()+"";
                            //Debug.Log("ID_Pregunta: " + reader["ID_PREGUNTA"] + " Descripcion : " + reader["PLANTEAMIENTO"]);
                        }
                        //Debug.Log("ID_Pregunta: " + reader["ID_PREGUNTA"] + " Descripcion : " + reader["PLANTEAMIENTO"]);
                        
                        //Debug.Log("ID_FASE: " + reader["ID_FASE"] + " Nombre : " + reader["NOMBRE"]);
                    }
                }
            }
            connection.Close();
            return pregunta;
        }
    }

    public string[][] SelectOpcion(String idPregunta){
        String q = "SELECT * FROM opcion WHERE ID_PREGUNTA ="+idPregunta+";";
        string[][] respuestas = new string[7][];
        int inciso = 0;
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = q;
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        if(idPregunta.Equals(reader["ID_PREGUNTA"]+"")){
                            string[] respuesta = new string[5];
                            /*
                            respuesta[0] = reader[0]+"";
                            respuesta[1] = reader[0]+"";
                            respuesta[2] = reader[0]+"";
                            respuesta[3] = reader[0]+"";
                            /*
                            respuesta[0] = reader["ID_OPCION"]+"";
                            respuesta[1] = reader["ID_RESPUESTA"]+"";
                            respuesta[2] = reader["INCISO"]+"";
                            respuesta[3] = reader["DESCRIPCION"]+"";
                            */
                            respuestas[inciso] = respuesta;
                            Debug.Log("ID_Pregunta: " + reader["ID_PREGUNTA"] + " Descripcion : " + reader["DESCRIPCION"]);
                        }
                    }
                }
            }

        }
        return respuestas;

    }
}
