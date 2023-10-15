using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCtl : MonoBehaviour
{
    public static CanvasCtl Instance;
    public GameObject winPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void Win()
    {
        winPanel.SetActive(true);
    }
}