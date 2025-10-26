using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private void Start()
    {
        GetControl<Button>("StartBTN").onClick.AddListener(() => { GameManager.Instance.LoadLevel(1); });
        GetControl<Button>("QuitBTN").onClick.AddListener(() => { GameManager.Instance.QuitGame(); });
    }
}
