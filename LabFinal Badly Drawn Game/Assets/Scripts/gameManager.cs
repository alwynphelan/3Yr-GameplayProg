using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject Student;
    public static GameManager instance;

    public TextMeshProUGUI scoreText;
    private int score = 0;
    void Awake()
    {
        instance = this;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void Score()
    {
        score += 1;

        if (score == 10) 
        {
            gameWin();
        }
    }

    private void gameWin()
    {
        SceneManager.LoadScene("winScene");
    }

    public void gameLose()
    {
        SceneManager.LoadScene("loseScene");
    }
}
