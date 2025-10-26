using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private void Start()
    {
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
        StartCoroutine(IReStartLevel());
    }

    public IEnumerator IReStartLevel()
    {
        UIManager.Instance.ShowPanel<BlackPanel>("BlackPanel", E_UI_Layer.System);
        yield return new WaitForSeconds(1);
        LoadSceneManager.Instance.LoadActiveScene();
        PoolManager.Instance.Clear();
        UIManager.Instance.GetPanel<BlackPanel>("BlackPanel").MoveOut();
        yield return new WaitForSeconds(0.7f);
        UIManager.Instance.HidePanel("BlackPanel");
    }

    public void LoadLevel(int index)
    {
        PoolManager.Instance.Clear();
        LoadSceneManager.Instance.LoadSceneAsync(index);
    }

    public void QuitGame()
    {
        PoolManager.Instance.Clear();
        Application.Quit();
    }
}
