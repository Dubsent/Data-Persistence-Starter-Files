using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBestScore : MonoBehaviour
{
    public Text bestScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance.LoadHighScore();

        if (MainManager.Instance != null)
        {
            if (MainManager.Instance.highScore != 0)
            {
                DisplayHighScore();
            } 
            else
            {
                DisplayName();
            }
        }
        else
        {
            bestScoreText.text = "Hello, set a high score!";
        }

    }

    void DisplayHighScore()
    {
        bestScoreText.text = "Best Score - " + MainManager.Instance.highScoreName + " - " + MainManager.Instance.highScore;
    }

    void DisplayName()
    {
        bestScoreText.text = "Highscore is not set. You can be the first!";
    }
    
}
