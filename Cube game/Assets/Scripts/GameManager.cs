using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public int score = 0;
    private int HighScore, Zen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI ZenText;
    public GameObject playButton;
    public GameObject SkinButton;
    public GameObject SettingButton;
    public GameObject ExitButton;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject PanelText;
    public GameObject ST;
    public GameObject HT;
    public GameObject ZenT;
    public GameObject SkinPanel;
    public GameObject SettingPanel;
    public GameObject BS2;
    public GameObject US1;
    public GameObject UST1;
    public GameObject US2;
    public GameObject UST2;
    public GameObject RT;

    // Start is called before the first frame update
    void Start()
    {
        //reset
        /*PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("Zen", 0);
        PlayerPrefs.SetInt("BS2", 0);
        PlayerPrefs.SetInt("US2", 0);
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("Zen");
        PlayerPrefs.DeleteKey("BS2");
        PlayerPrefs.DeleteKey("US2");*/

        HighScore = PlayerPrefs.GetInt("HighScore");
        HighScoreText.text = "High Score: " + HighScore;
        Zen = PlayerPrefs.GetInt("Zen");
        ZenText.text = "Zen: " + Zen;
        if (PlayerPrefs.GetInt("BS2") == 1)
        {
            BS2.SetActive(false);
        }
        else
            PlayerPrefs.SetInt("US1", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("US1") == 1)
        {
            US1.SetActive(false);
            UST1.SetActive(true);
            US2.SetActive(true);
            UST2.SetActive(false);
            if (PlayerPrefs.GetInt("BS2") == 0)
            {
                BS2.SetActive(true);
                US2.SetActive(false);
                UST2.SetActive(false);
            }
        }
        if(PlayerPrefs.GetInt("US2") == 1)
        {
            US1.SetActive(true);
            UST1.SetActive(false);
            US2.SetActive(false);
            UST2.SetActive(true);
        }
    }
    IEnumerator SpawnObstacle()
    {
        while(true)
        {
            float waitTime = Random.Range(0.5f, 2f);
            int UOD = Random.Range(1, 3);

            yield return new WaitForSeconds(waitTime);

            if(UOD == 1)
            {
                Instantiate(obstacle, spawnPoint1.position, Quaternion.identity);
            }
            else
            {
                Instantiate(obstacle, spawnPoint2.position, Quaternion.identity);
            }
        }
    }
    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("Zen", PlayerPrefs.GetInt("Zen") + 1);
    }
    public void GameStart()
    {
        playButton.SetActive(false);
        SkinButton.SetActive(false);
        SettingButton.SetActive(false);
        ExitButton.SetActive(false);
        PanelText.SetActive(false);
        ST.SetActive(true);
        HT.SetActive(false);
        ZenT.SetActive(false);
        if (PlayerPrefs.GetInt("US1") == 1)
            Player1.SetActive(true);
        else if (PlayerPrefs.GetInt("US2") == 1)
            Player2.SetActive(true);
        PlayerPrefs.SetInt("SpeedUp", -10);
        PlayerPrefs.SetInt("StopSpeedUp", 0);
        StartCoroutine("SpawnObstacle");
        InvokeRepeating("ScoreUp", 2f, 1f);
    }
    public void OpenSkinPanel()
    {
        SkinPanel.SetActive(true);
    }
    public void BuySkin2()
    {
        if (PlayerPrefs.GetInt("Zen") >= 100)
        {
            BS2.SetActive(false);
            US2.SetActive(false);
            UST2.SetActive(true);
            US1.SetActive(true);
            UST1.SetActive(false);
            PlayerPrefs.SetInt("BS2", 1);
            PlayerPrefs.SetInt("Zen", PlayerPrefs.GetInt("Zen") - 100);
        }
        else
        {
            RT.SetActive(true);
            Invoke("delay", 2f);
        }
    }
    public void UseSkin1()
    {
        PlayerPrefs.SetInt("US1", 1);
        PlayerPrefs.SetInt("US2", 0);
    }
    public void UseSkin2()
    {
        PlayerPrefs.SetInt("US2", 1);
        PlayerPrefs.SetInt("US1", 0);
    }
    public void CloseSkinPanel()
    {
        SkinPanel.SetActive(false);
    }
    public void OpenSetting()
    {
        SettingPanel.SetActive(true);
    }
    public void CloseSetting()
    {
        SettingPanel.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void delay()
    {
        RT.SetActive(false);
    }
}