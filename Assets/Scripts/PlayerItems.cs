using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public InputProcessor InputProcessor;
    private string CurrentItem;

    private void Start()
    {
        CurrentItem = "Sword";
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
            Debug.Log("Used " + CurrentItem);
        }
    }
}
