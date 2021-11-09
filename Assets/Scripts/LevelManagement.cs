using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    public TMP_Text text;
    public GameObject Enemy1, Enemy2, Enemy3, Enemy4, Boss;
    public List<GameObject> Buttons;
    public static int NoDisabled = 0, Score;
    void Start()
    {
        Data d = SaveSystem.Load();
        NoDisabled = 17 - d.Levels;
        Score = d.Score;
        Time.timeScale = 1.0f;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        for (int i=(17-NoDisabled); i<=16; i++)
        {
            Buttons[i].GetComponent<Button>().interactable = false;
        }
        if (Score > 0)
        {
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
        text.text = "Max Score: " + Score.ToString();
        EnemySpawner.Types.Clear();
    }
    public void PlayLevel(int l)
    {
        if (l<=16 && Buttons[l].GetComponent<Button>().interactable)
        {
            EnemySpawner.AlreadyWon = true;
        }
        else
        {
            EnemySpawner.AlreadyWon = false;
        }
        if (l == 1)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy1);
            EnemySpawner.Limit = 7;
            EnemySpawner.Interval = 200;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 2)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy2);
            EnemySpawner.Limit = 7;
            EnemySpawner.Interval = 100;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 3)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy1);
            EnemySpawner.Types.Add(Enemy2);
            EnemySpawner.Limit = 14;
            EnemySpawner.Interval = 70;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 4)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy1);
            EnemySpawner.Types.Add(Enemy2);
            EnemySpawner.Limit = 18;
            EnemySpawner.Interval = 50;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 5)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy2);
            EnemySpawner.Limit = 25;
            EnemySpawner.Interval = 30;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 6)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy3);
            EnemySpawner.Limit = 10;
            EnemySpawner.Interval = 100;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 7)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy3);
            EnemySpawner.Types.Add(Enemy1);
            EnemySpawner.Limit = 15;
            EnemySpawner.Interval = 70;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 8)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy3);
            EnemySpawner.Types.Add(Enemy2);
            EnemySpawner.Limit = 18;
            EnemySpawner.Interval = 70;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 9)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy3);
            EnemySpawner.Types.Add(Enemy2);
            EnemySpawner.Types.Add(Enemy1);
            EnemySpawner.Limit = 23;
            EnemySpawner.Interval = 80;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 10)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy4);
            EnemySpawner.Limit = 15;
            EnemySpawner.Interval = 230;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 11)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy4);
            EnemySpawner.Types.Add(Enemy2);
            EnemySpawner.Limit = 20;
            EnemySpawner.Interval = 230;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 12)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy4);
            EnemySpawner.Types.Add(Enemy3);
            EnemySpawner.Limit = 20;
            EnemySpawner.Interval = 180;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 13)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy4);
            EnemySpawner.Types.Add(Enemy2);
            EnemySpawner.Types.Add(Enemy1);
            EnemySpawner.Limit = 30;
            EnemySpawner.Interval = 175;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 14)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy4);
            EnemySpawner.Types.Add(Enemy3);
            EnemySpawner.Types.Add(Enemy2);
            EnemySpawner.Limit = 30;
            EnemySpawner.Interval = 150;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 15)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy4);
            EnemySpawner.Types.Add(Enemy3);
            EnemySpawner.Types.Add(Enemy2);
            EnemySpawner.Types.Add(Enemy1);
            EnemySpawner.Limit = 35;
            EnemySpawner.Interval = 150;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = false;
        }
        else if (l == 16)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.BossMode = true;
            EnemySpawner.Survival = false;
        }
        else if (l == 17)
        {
            EnemySpawner.Types.Clear();
            EnemySpawner.Types.Add(Enemy4);
            EnemySpawner.Types.Add(Enemy3);
            EnemySpawner.Types.Add(Enemy2);
            EnemySpawner.Types.Add(Enemy1);
            EnemySpawner.Interval = 150;
            EnemySpawner.BossMode = false;
            EnemySpawner.Survival = true;
        }
        SceneManager.LoadScene("Game");
        EnemySpawner.Level = l;
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Delete()
    {
        SaveSystem.Delete();
        SceneManager.LoadScene("Menu");
    }
}
