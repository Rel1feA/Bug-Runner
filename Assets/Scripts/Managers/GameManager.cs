using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int levelIndex;

    private void Start()
    {
        //LoadSceneManager.Instance.LoadSceneAsync(levelIndex);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReStartLevel();
        }
    }

    public void ReStartLevel()
    {
        LoadSceneManager.Instance.LoadActiveScene();
    }
}
