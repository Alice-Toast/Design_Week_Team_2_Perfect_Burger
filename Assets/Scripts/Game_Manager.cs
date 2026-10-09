using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    public Transform bun;
    public int maxPoints = 5;
    public float maxDistance = 0.1f;

    public int score = 0;

    // Update is called once per frame
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
    }

}
