using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que representa el menú principal del juego.
/// </summary>
public class MainMenu : MonoBehaviour
{
    private Animator anim;
    public GameObject pause;
    public GameObject deployMenu;
    private bool settingsIsShow;
    private int currentLvlMap;

    public static MainMenu instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            pause.GetComponent<Animator>().Rebind();
        }
    }

    void Start()
    {
        Time.timeScale = 1;
        anim = pause.GetComponent<Animator>();
        settingsIsShow = false;
        anim.Rebind();
        currentLvlMap = PlayerPrefs.GetInt("LVLMap", 4);
        deployMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Carga la escena del primer mapa del juego.
    /// </summary>
    public void StarGame()
    {
        SceneManager.LoadScene(currentLvlMap);
        Debug.Log("First Map");
    }

    /// <summary>
    /// Cierra la aplicación del juego.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    /// <summary>
    /// Muestra el menú de configuración.
    /// </summary>
    public void ShowSetings()
    {
        settingsIsShow = true;
        if (anim.GetBool("ShowSettings") == true)
        {
            Debug.Log("Anim null");
        }
        anim.SetBool("ShowSettings", settingsIsShow);
        //Debug.Log("SetingsMenuShow");
    }

    /// <summary>
    /// Oculta el menú de configuración.
    /// </summary>
    public void HideSetings()
    {
        settingsIsShow = false;
        anim.SetBool("ShowSettings", false);
        Debug.Log("SetingsMenuHide");
    }

    /// <summary>
    /// Regresa al menú principal del juego.
    /// </summary>
    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Game to MainMenu");
    }

    /// <summary>
    /// Muestra el menú de despliegue.
    /// </summary>
    public void ShowDeplymentMenu()
    {
        deployMenu.SetActive(true);
    }

    /// <summary>
    /// Oculta el menú de despliegue.
    /// </summary>
    public void HideDeploymentMenu()
    {
        deployMenu.SetActive(false);
    }

    /// <summary>
    /// Carga una escena específica del juego.
    /// </summary>
    /// <param name="mapa">El número de la escena a cargar.</param>
    public void CargarEscena(int mapa)
    {
        SceneManager.LoadScene(mapa);
    }

    /// <summary>
    /// Elimina todas las preferencias guardadas del jugador.
    /// </summary>
    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}

