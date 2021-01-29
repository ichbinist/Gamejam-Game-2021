using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class LevelManager : Singleton<LevelManager>
{
    [HideInInspector]
    public UnityEvent OnLevelStart = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnLevelFinish = new UnityEvent();


    [HideInInspector]
    public bool isLevelStarted;

    public void StartLevel()
    {
        if (isLevelStarted)
            return;
        OnLevelStart.Invoke();
        isLevelStarted = true;
    }

    public void StartGame()
    {
        SceneManagement.Instance.LoadScene(SceneManager.GetSceneByBuildIndex(2).name);
    }

    public void FinishLevel()
    {
        if (!isLevelStarted)
            return;
        OnLevelFinish.Invoke();
        isLevelStarted = false;
    }
}