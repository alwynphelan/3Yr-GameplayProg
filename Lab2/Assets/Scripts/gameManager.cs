using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int playerLives;
    public int EnemiesAlive;
    public int score;

    public Text gameOverText;
    public Text gameWinText;
    public TextMeshProUGUI textMeshPro;

    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        gameOverText.enabled = false;
        gameWinText.enabled = false;
        healthText.enabled = true;
        //initialise the game
    }

    public void gameOver()
    {
        gameOverText.enabled = true;
        Time.timeScale = 0f;
    }

    public void gameWin()
    {
        gameWinText.enabled = true;
        Time.timeScale = 0f;
    }

    public void Scoring()
    {
        score = score + 1;
        textMeshPro.text = "Score:" + score.ToString();
        if (score >= 8) {
            gameWin();
        }
    }

    private void Update()
    {
        healthText.text = "Health: " + playerLives.ToString();
    }

    public void lifeIncrease()
    {
        if (playerLives < 3)
        {
            playerLives += 1;
        }
    }

    public void Death()
    {
        playerLives = playerLives - 1;

        if (playerLives == 0) {
            gameOver();
        }
    }


}
