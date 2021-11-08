using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public Canvas Hud;
    public Healthbar PlayerHealthbar;

    public void ToggleHud(bool visible)
    {
        Hud.gameObject.SetActive(visible);
    }

    public void ToggleInvincibility(bool invincible)
    {
        //PlayerHealthbar.SetInvincibility(invincible);
    }

    public void ExitToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void TogglePauseMenu()
    {
        bool paused = !gameObject.activeSelf;
        gameObject.SetActive(paused);
        Debug.Log("Toggled pause menu: " + paused);

        PauseEvent.Invoke(!paused);/*
        foreach (MonoBehaviour script in ScriptsToDisableOnPause)
        {
            script.enabled = !paused;
        }*/
    }

    private void Start()
    {
        //gameData = Resources.Load<GameData>("GameData");
    }

    public UnityEvent<bool> PauseEvent;
}
