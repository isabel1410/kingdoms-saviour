using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public InputProcessor InputProcessor;
    private string CurrentItem;
    private Timer timer;

    private void Start()
    {
        CurrentItem = "Sword";
        timer = new Timer(500);
        timer.Elapsed += OnTimerElapsed;
    }

    // Update is called once per frame
    private void Update()
    {
        ProcessUse();
    }

    private void ProcessUse()
    {
        if (InputProcessor.Used)
        {
            if (timer.Enabled == false)
            {
                timer.Enabled = true;
                timer.Start();
                Debug.Log("Used " + CurrentItem);
            }
        }
    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        timer.Stop();
        timer.Enabled = false;
    }
}
