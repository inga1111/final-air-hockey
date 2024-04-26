using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public enum Score
    {
        AiScore, PlayerScore
    }

    public Text AiScoreTxt, PlayerScoreTxt;
    private int aiScore, playerScore;

    public void Increment(Score whichScore)
    {
        if (whichScore == Score.AiScore)
        {
            AiScoreTxt.text = (++aiScore).ToString();
            CheckGameOver();
        }
        else if (whichScore == Score.PlayerScore)
        {
            PlayerScoreTxt.text = (++playerScore).ToString();
            CheckGameOver();
        }
    }

    private void CheckGameOver()
    {
        if (aiScore >= 5 || playerScore >= 5)
        {
            // Add code here to end the game, reset scores, display game over message, etc.
            Debug.Log("Game Over!");
        }
    }
}
