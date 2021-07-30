using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseLog : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup winLog;
    public void ShowWinLog()
    {
        winLog.alpha = winLog.alpha == 0 ? 1 : 0;
        winLog.blocksRaycasts = winLog.blocksRaycasts == false ? true : false;
    }

}
