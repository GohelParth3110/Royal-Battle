using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGameOverScreen : MonoBehaviour
{
    [SerializeField] private Button btn_Replay;

    private void Awake() {
        btn_Replay.onClick.AddListener(OnclickOn_RePlayBtnClick);
    }

    private void OnclickOn_RePlayBtnClick() {
        SceneManager.LoadScene(0);
    }
}
