using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] Text highScore;
    [SerializeField] Text scorePoints;
    [SerializeField] Text scoreList;
    [SerializeField] InputField playerName;
    [SerializeField] Button addScoreButton;
    int playerScore = 0;

    string[] scores = new string[3];
    int[] points = new int[3];

    void Start()
    {
        playerName.text = "AAA";
        scores[0] = "AAA";
        scores[1] = "BBB";
        scores[2] = "CCC";

        points[0] = 0;
        points[1] = 0;
        points[2] = 0;
    }

    void Update()
    {
        scoreList.text = ScoreAsText();
    }

    public void setScoreScreen(int playerPoints)
    {
        bool isBestScore = false;
        playerScore = playerPoints;
        scorePoints.text = playerScore.ToString();

        foreach (int p in points)
        {
            if(playerPoints > p)
            {
                isBestScore = true;
            } 
        }

        if(isBestScore)
        {
            playerName.gameObject.SetActive(true);
            addScoreButton.gameObject.SetActive(true);
            highScore.text = "High Score";
        } 
        else
        {
            playerName.gameObject.SetActive(false);
            addScoreButton.gameObject.SetActive(false);
            highScore.text = "Your Score";
        }
    }

    public void setBestScore()
    {
        string tempName0 = playerName.text;
        int tempScore0 = playerScore;

        string tempName1 = "";
        int tempScore1 = 0;
        int i = 0;

        foreach (int p in points)
        {
            if(tempScore0 > p)
            {
                tempName1 = scores[i];
                tempScore1 = points[i];

                scores[i] = tempName0;
                points[i] = tempScore0;

                tempName0 = tempName1;
                tempScore0 = tempScore1;
            }
            i++;
        }

        playerName.gameObject.SetActive(false);
        addScoreButton.gameObject.SetActive(false);
    }

    private string ScoreAsText()
    {
        int i = 0;
        string text = "";

        foreach (string s in scores)
        {
            string dots = new string('.', 37 - s.Length - points[i].ToString().Length);
            text += s.ToUpper() + dots + points[i] + "\n";
            i++;
        }
        return text;
    }
}
