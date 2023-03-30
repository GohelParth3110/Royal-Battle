using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public UIGamePlayScreen screen_UIGamePlayScreen;
    public UIHomeScreen screen_UIHomeScreen;
    public UIGameOverScreen screen_UIGameOverScreen;

    private void Awake() {
        instance = this;
    }
}
