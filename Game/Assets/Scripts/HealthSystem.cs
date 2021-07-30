using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    static public int health = 5;
    public static int numOfHearths = 5;

    public Image[] hearths;
    public Sprite fullHearth;
    public Sprite emptyHearth;

    public void Update()
    {
        if (health > numOfHearths)
        {
            health = numOfHearths;
        }

        for (int i = 0; i < hearths.Length; i++)
        {
            if (i < health)
            {
                hearths[i].sprite = fullHearth;
            }
            else
            {
                hearths[i].sprite = emptyHearth;
            }

            if (i < numOfHearths)
            {
                hearths[i].enabled = true;
            }
            else
            {
                hearths[i].enabled = false;
            }
        }
        if(health == 0)
        {
            Invoke("DiedMethod", 1.5f);
        }
    }

    public void DiedMethod()
    {
        SceneManager.LoadScene(0);
    }
}
