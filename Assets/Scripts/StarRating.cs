using UnityEngine;
using UnityEngine.UI;

public class StarRating : MonoBehaviour
{
    public Image starImage;

    public Sprite stars0;
    public Sprite stars1;
    public Sprite stars2;
    public Sprite stars3;
    public Sprite stars4;
    public Sprite stars5;

    // these are just placeholders for the score, you can adjust them as needed c:
    public void SetRatingFromScore(int score)
    {
        int rating;

        if (score >= 40)
        {
            rating = 5;
        }
        else if (score >= 35)
        {
            rating = 4;
        }
        else if (score >= 30)
        {
            rating = 3;
        }
        else if (score >= 20)
        {
            rating = 2;
        }
        else if (score >= 10)
        {
            rating = 1;
        }
        else
        {
            rating = 0;
        }

        SetStarImage(rating);
    }

    void SetStarImage(int rating)
    {
        switch (rating)
        {
            case 0:
                starImage.sprite = stars0;
                break;

            case 1:
                starImage.sprite = stars1;
                break;

            case 2:
                starImage.sprite = stars2;
                break;

            case 3:
                starImage.sprite = stars3;
                break;

            case 4:
                starImage.sprite = stars4;
                break;

            case 5:
                starImage.sprite = stars5;
                break;
        }
    }
}