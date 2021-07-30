using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCMenuScript : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup escMenu;
    [SerializeField]
    private CanvasGroup controlMenu;
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("EXIT");
    }

    public void CloseOpenESCMenu()
    {
        escMenu.alpha = escMenu.alpha > 0 ? 0 : 1;
        escMenu.blocksRaycasts = escMenu.blocksRaycasts == true ? false : true;

        //В ЭТОМ МОЖЕТ БЫТЬ ОШИБКА
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;

    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && controlMenu.alpha == 1)
        {
            controlMenu.alpha = 0;
            controlMenu.blocksRaycasts = false;

            escMenu.alpha = escMenu.alpha > 0 ? 0 : 1;
            escMenu.blocksRaycasts = escMenu.blocksRaycasts == true ? false : true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            CloseOpenESCMenu();
        }
        
    }

    public void OpenCloseControlMenu()
    {
        controlMenu.alpha = controlMenu.alpha == 0 ? 1 : 0;
        controlMenu.blocksRaycasts = controlMenu.blocksRaycasts == false ? true : false;

        escMenu.alpha = escMenu.alpha > 0 ? 0 : 1;
        escMenu.blocksRaycasts = escMenu.blocksRaycasts == true ? false : true;
    }
}
