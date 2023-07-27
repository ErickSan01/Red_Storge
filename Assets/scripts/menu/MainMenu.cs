using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

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

    public void StarGame()
    {
        SceneManager.LoadScene(currentLvlMap);
        Debug.Log("First Map");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

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
    public void HideSetings()
    {
        settingsIsShow = false;
        anim.SetBool("ShowSettings", false);
        Debug.Log("SetingsMenuHide");
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Game to MainMenu");
    }

    public void ShowDeplymentMenu()
    {
        deployMenu.SetActive(true);
    }

    public void HideDeploymentMenu()
    {
        deployMenu.SetActive(false);
    }

    public void CargarEscena(int mapa)
    {
        SceneManager.LoadScene(mapa);
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}

