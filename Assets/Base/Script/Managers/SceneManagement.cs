using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneManagement : Singleton<SceneManagement>
{
    [HideInInspector]
    public UnityEvent OnSceneLoaded = new UnityEvent();

    private void Start()
    {
        LoadMenuScene();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(AsyncSceneLoadıng(sceneName));
    }

    private IEnumerator AsyncSceneLoadıng(string sceneName) {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone) //Wait Until Scene Loaded
        {
            yield return null;
        }
        var scene = SceneManager.GetSceneByName(sceneName);
        if (scene.name.Contains("Level"))
        {
            OnSceneLoaded.Invoke();
            LevelManager.Instance.StartLevel();
        }
    }

    public void LoadMenuScene()
    {
        StartCoroutine(LoadMenuSceneCo());
    }

    private IEnumerator LoadMenuSceneCo()
    {
        yield return SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);

    }

    public void UnloadScene(string sceneName)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(0));
        Scene scene = SceneManager.GetSceneByName(sceneName);
        StartCoroutine(UnloadSceneCo(scene));
    }

    IEnumerator UnloadSceneCo(Scene scene)
    {
        yield return SceneManager.UnloadSceneAsync(scene.buildIndex);
    }
}
