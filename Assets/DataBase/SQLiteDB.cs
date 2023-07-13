using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System;
using System.Collections.Generic;
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
}
