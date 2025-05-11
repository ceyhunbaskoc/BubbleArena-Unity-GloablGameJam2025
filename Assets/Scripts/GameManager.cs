using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    TextMeshProUGUI score1, score2;
    public GameObject player1Bubble,player2Bubble,score1text,score2text;
    private BubbleScript bs1,bs2;
    public GameObject pausePanel, levelcomplete;
    public Scene mainMenu;
    [SerializeField] int scoreP1;
    [SerializeField] int scoreP2;

    private void Start()
    {
        bs1= player1Bubble.GetComponent<BubbleScript>();
        bs2 = player2Bubble.GetComponent<BubbleScript>();
        score1=score1text.GetComponent<TextMeshProUGUI>();
        score2 = score2text.GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.HasKey("player1score"))
        {
            scoreP1 = PlayerPrefs.GetInt("player1score");
            scoreP2 = PlayerPrefs.GetInt("player2score");
            score1.text=scoreP1.ToString();
            score2.text = scoreP2.ToString();
        }

    }
    private void Update()
    {
        if(bs1.dead==true||bs2.dead==true)
        {
            StartCoroutine(Wait());
        }

    }

    public void Player1Win()
    {
        scoreP1 += 1;
        RestartGame(); 
    }

    public void Player2Win()
    {
        scoreP2 += 1;
        RestartGame();
    }
    public void RestartGame()
    {
        if(scoreP1==5||scoreP2==5)
        {
            if(levelcomplete.activeSelf==true)
            {
                ResetScores();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
            LevelFinishedPanel();

            }
        }
        else
        {

            PlayerPrefs.SetInt("player1score", scoreP1);
            PlayerPrefs.SetInt("player2score", scoreP2 );
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void LevelFinishedPanel()
    {
        levelcomplete.SetActive(true);
        score1.text = scoreP1.ToString();
        score2.text = scoreP2.ToString();
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        RestartGame ();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        
        
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        

    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
        ResetScores();
        Time.timeScale = 1f;

    }
    public void StartGame()
    {
        ResetScores();
        int random = Random.Range(1,4);

        SceneManager.LoadScene(random);
    }
    public void ResetScores()
    {
        PlayerPrefs.SetInt("player1score", 0);
        PlayerPrefs.SetInt("player2score", 0);
    }
}
