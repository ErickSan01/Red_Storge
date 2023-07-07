using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changelvl : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int lvlMap;
    [SerializeField] private int nextLvlMap;
    public GameObject instance;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (instance.CompareTag("Changelvl"))
            {
                DataManager.instance.LVLMap(lvlMap);
            }
            else if (instance.CompareTag("Changelvl"))
            {
                DataManager.instance.LVLMap(nextLvlMap);
                SceneManager.LoadScene(nextLvlMap);
            }

            print("Game Saved");
        }
    }
}
