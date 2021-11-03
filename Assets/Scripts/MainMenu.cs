using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private GameData gameData;

    private void Start()
    {
        gameData = Resources.Load<GameData>("GameData");
    }


    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level01");
    }

    public void ExitGame()
    {
        Application.Quit(0);
    }
}
