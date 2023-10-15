using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCtl : MonoBehaviour
{
    public static LevelCtl Instance;
    public PlayerMovement player;
    
    public List<Enemy> listEnemy;

    public void Awake()
    {
        Instance = this;
    }

    public void CheckWin()
    {
        bool checkWin = true;
        foreach (Enemy enemy in listEnemy)
        {
            if(enemy.gameObject.activeInHierarchy)
            {
                checkWin = false;
                break;
            }
        }

        if (checkWin)
        {
            CanvasCtl.Instance.Win();
        }
    }
}