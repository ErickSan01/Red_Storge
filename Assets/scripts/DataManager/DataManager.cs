using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager instance;
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }else if(instance != null)
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

    public void MusicData(float value){
        PlayerPrefs.SetFloat("MusicVolume",value);
        
    }

    public void SFXData(float value){
        PlayerPrefs.SetFloat("SFXVolume",value);
    }

    public void LVLMap(int lvl){
        PlayerPrefs.SetInt("LVLMap",lvl);
    }

    public void DialogEnvIndex(int index){
        PlayerPrefs.SetInt("DialogEnvIndex",index);
    }
}
