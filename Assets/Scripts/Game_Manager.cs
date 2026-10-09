using TMPro;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static int finalScore;
    public StarRating starRating;
    public static Game_Manager instance;

    public Transform bun;
    public int maxPoints = 5;
    public float maxDistance = 0.1f;

    public int score = 0;

    public GameObject endPanel;
    public TMP_Text accuracyText;
    public TMP_Text timeText;
    public TMP_Text scoreText;
    public GameTimer timer;
    int ingredientsPlaced = 0;

    public int winScore = 40;
    public bool gameOver = false;
    public string startScene = "Start";

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(startScene);
        }
    }
    void Awake()
    {
        instance = this;
    }
    
    public void Scoring(Vector3 ingredientPosition)
    {
        Vector2 ingredient = new Vector2(ingredientPosition.x, ingredientPosition.z);
        Vector2 middle = new Vector2(bun.position.x, bun.position.z);
        float distanceFromMiddle = Vector2.Distance(ingredient, middle);

        int points = 0;

        if (distanceFromMiddle < 0.02f) points = 5;
        else if (distanceFromMiddle < 0.05f) points = 3;
        else if (distanceFromMiddle < 0.1f) points = 1;

        score += points;
        ingredientsPlaced++;
        starRating.SetRatingFromScore(score);
        finalScore = score;
    }

    public void TopBunPlaced()
    {
        if (gameOver) return;
        EndGame(score >= winScore);
    }

    public void EndGame(bool fin)
    {
        gameOver = true;

        int accuracy = 0;
        if (ingredientsPlaced > 0)
        {
            accuracy = score * 100 / (ingredientsPlaced * maxPoints);
        }


        float time = timer.GetElapsedTime();
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        accuracyText.text = accuracy + "%";
        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        scoreText.text = score.ToString();

        endPanel.SetActive(true);
    }

}
