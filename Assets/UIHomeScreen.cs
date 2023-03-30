using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHomeScreen : MonoBehaviour
{
    [SerializeField] private Button btn_PlayBtnClick;

    private void Awake() {
        btn_PlayBtnClick.onClick.AddListener(OnCLickOnPlayBtnClick);
    }

    private void OnCLickOnPlayBtnClick() {
        this.gameObject.SetActive(false);
        UIManager.instance.screen_UIGamePlayScreen.gameObject.SetActive(true);
        LevelManager.instance.StartGame();
    }
}
