using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    public Button Play;
    public Button Credits;
    public Button Exit;

    // Start is called before the first frame update
    void Start()
    {
        Play.onClick.AddListener(startGame);
        Credits.onClick.AddListener(startCredits);
        Exit.onClick.AddListener(startExit);
    }

    private void startGame()
    {
        LevelManager.Instance.StartGame();
        SceneManagement.Instance.UnloadScene("MainMenu");
    }

    private void startCredits()
    {
        // TODO: Not implemented
        Debug.Log("Not implemented");
    }

    private void startExit()
    {
        Application.Quit();
    }
}
