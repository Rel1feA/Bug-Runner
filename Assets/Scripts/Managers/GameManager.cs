using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadSceneManager.Instance.LoadSceneAsync(0);
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
