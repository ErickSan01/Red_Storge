using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    //Para acceder desde donde sea
    public static UIController Instance;
    public Transform MainCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null){
            GameObject.Destroy(this.gameObject);
            return;
        }
        
        Instance = this;
    }
    //Instacionar POPup
    public Popup CreatePopUp() {
        GameObject popUpGO = Instantiate(Resources.Load("UI/Popup") as GameObject);
        return popUpGO.GetComponent<Popup>();
    }
}
