﻿using System.Collections;
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

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        SceneManagement.Instance.LoadScene("TestLevel");
    }

    public void FinishLevel()
    {
        if (!isLevelStarted)
            return;
        OnLevelFinish.Invoke();
        isLevelStarted = false;
    }
}