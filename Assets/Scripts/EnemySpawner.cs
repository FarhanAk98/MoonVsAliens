using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Boss, PausedStuff;
    public Image image;
    public TMP_Text text, text2;
    public GameObject Moon;
    [HideInInspector]
    public static List<GameObject> Types = new List<GameObject>();
    [HideInInspector]
    public static bool BossMode, AlreadyWon, Survival;
    [HideInInspector]
    public static int Limit, Interval, Level, MaxScore;
    [HideInInspector]
    public int li = 0;
    public bool Paused = false;
    GameObject bo;
    bool won = false, lost = false;
    int time = Interval, dTime = 0;
    void Start()
    {
        if (BossMode)
        {
            bo = Instantiate(Boss);
        }
        Time.timeScale = 1.0f;
        PausedStuff.SetActive(false);
        text.text = "";
        image = image.GetComponent<Image>();
        Color tempcolor = image.color;
        tempcolor.a = 0.0f;
        image.color = tempcolor;
        time = Interval;
        Application.targetFrameRate = 144;
    }
    void FixedUpdate()
    {
        if (!Paused)
        {
            if (BossMode)
            {
                if (Moon == null && !won)
                {
                    Finish(false);
                }
                if (bo == null && !lost)
                {
                    Finish(true);
                }
                else
                {
                    text2.text = "Boss Health: " + bo.GetComponent<LifeBoss>().Health.ToString();
                }
            }
            else if (Survival)
            {
                time = (int)Mathf.Lerp(time, -1, 0.125f*Time.deltaTime);
                if (time <= 0)
                {
                    int ind = Random.Range(0, Types.Count);
                    EnemySpawn(Types[ind]);
                    time = Interval;
                }
                if (Moon == null && !won)
                {
                    Finish(false);
                }
                text2.text = "Enemies Killed: " + li.ToString();
            }
            else
            {
                time = (int)Mathf.Lerp(time, -1, 0.125f * Time.deltaTime);
                if (time <= 0 && li < Limit)
                {
                    int ind = Random.Range(0, Types.Count);
                    EnemySpawn(Types[ind]);
                    time = Interval;
                }
                if (Moon == null && !won)
                {
                    Finish(false);
                }
                if (li >= Limit && !lost)
                {
                    Finish(true);
                }
                text2.text = "Enemies: " + (Limit - li).ToString();
            }
        }
        if (Input.GetKeyDown("p"))
        {
            Paused = true;
            PausedStuff.SetActive(true);
            image = image.GetComponent<Image>();
            Color tempcolor = image.color;
            tempcolor.a = 0.2f;
            Time.timeScale = 0.0f;
        }
    }
    void EnemySpawn(GameObject Enemy)
    {
        int hw = Random.Range(1, 3);
        if (hw == 1)
        {
            int h = Random.Range(1, 3);
            if (h == 1)
            {
                Instantiate(Enemy, new Vector3(Random.Range(-38, 38), 24f, 20f), Enemy.transform.rotation);
            }
            else if (h == 2)
            {
                Instantiate(Enemy, new Vector3(Random.Range(-38, 38), -24f, 20f), Enemy.transform.rotation);
            }
        }
        else if (hw == 2)
        {
            int w = Random.Range(1, 3);
            if (w == 1)
            {
                Instantiate(Enemy, new Vector3(44, Random.Range(-18, 18), 20f), Enemy.transform.rotation);
            }
            else if (w == 2)
            {
                Instantiate(Enemy, new Vector3(-44, Random.Range(-18, 18), 20f), Enemy.transform.rotation);
            }
        }
    }
    void Finish(bool Win)
    {
        Color tempcolor = image.color;
        tempcolor.a = 0.2f;
        image.color = tempcolor;
        if (Survival)
        {
            MaxScore = li;
            if (MaxScore > LevelManagement.Score)
            {
                LevelManagement.Score = MaxScore;
            }
            SaveSystem.Save();
        }
        if (Win)
        {
            text.text = "YOU WIN";
            won = true;
            if (!AlreadyWon && LevelManagement.NoDisabled >=0 )
            {
                LevelManagement.NoDisabled = 16 - Level;
            }
            SaveSystem.Save();
        }
        else
        {
            text.text = "YOU LOSE";
            lost = true;
        }
        if (dTime >= 100)
        {
            SceneManager.LoadScene("Levels");
        }
        dTime++;
    }
    public void Resume()
    {
        PausedStuff.SetActive(false);
        image = image.GetComponent<Image>();
        Color tempcolor = image.color;
        tempcolor.a = 0.0f;
        Time.timeScale = 1.0f;
        Paused = false;
    }
    public void Quit()
    {
        if (Survival)
        {
            MaxScore = li;
            if (MaxScore > LevelManagement.Score)
            {
                LevelManagement.Score = MaxScore;
            }
            SaveSystem.Save();
        }
        Paused = false;
        SceneManager.LoadScene("Levels");
    }
}
