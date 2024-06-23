using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que gestiona los datos del juego.
/// </summary>
public class DataManager : MonoBehaviour
{
    /// <summary>
    /// Instancia única del DataManager.
    /// </summary>
    public static DataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Guarda el valor del volumen de la música en PlayerPrefs.
    /// </summary>
    /// <param name="value">Valor del volumen de la música.</param>
    public void MusicData(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    /// <summary>
    /// Guarda el valor del volumen de los efectos de sonido en PlayerPrefs.
    /// </summary>
    /// <param name="value">Valor del volumen de los efectos de sonido.</param>
    public void SFXData(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    /// <summary>
    /// Guarda el nivel del mapa en PlayerPrefs.
    /// </summary>
    /// <param name="lvl">Nivel del mapa.</param>
    public void LVLMap(int lvl)
    {
        PlayerPrefs.SetInt("LVLMap", lvl);
    }

    /// <summary>
    /// Guarda el índice del entorno del diálogo en PlayerPrefs.
    /// </summary>
    /// <param name="index">Índice del entorno del diálogo.</param>
    public void DialogEnvIndex(int index)
    {
        PlayerPrefs.SetInt("DialogEnvIndex", index);
    }
}
