using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    //[SerializeField]
    //private GameObject textClose;
    // Start is called before the first frame update
    void Start()
    {
        //textClose.GetComponent<Text>();
        //Invoke("showText", 10);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(0);
        }
    }

}
