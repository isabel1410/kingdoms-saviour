using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public MonoBehaviour[] ScriptsToDisableOnPause;

    public void Pausea()
    {
        foreach (MonoBehaviour script in ScriptsToDisableOnPause)
        {
            script.enabled = false;
        }
    }

    private void Start()
    {
        System.Threading.Thread.Sleep(1000);
        Pausea();
    }
}
