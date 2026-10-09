using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource uiClick;
    public AudioSource stepSound;
    public AudioSource completeSound;
    public float clickTimer = 0f;
    public float clickTimerMax = 1f;
    public bool hasClicked = false;
    public float stepTimer = 0f;
    public float stepTimerMax = 1f;
    public bool hasStepped = false;
    public float completeTimer = 0f;
    public float completeTimerMax = 1f;
    public bool hasCompleted = false;
    private void Update()
    {
        if (hasClicked)
        {
            clickTimer += Time.deltaTime;
            if (clickTimer >= clickTimerMax)
            {
                hasClicked = false;
                clickTimer = 0f;
                uiClick.gameObject.SetActive(false);
            }
        }
        if (hasStepped)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepTimerMax)
            {
                hasStepped = false;
                stepTimer = 0f;
                stepSound.gameObject.SetActive(false);
            }
        }
        if (hasCompleted)
        {
            completeTimer += Time.deltaTime;
            if (completeTimer >= completeTimerMax)
            {
                hasCompleted = false;
                completeTimer = 0f;
                completeSound.gameObject.SetActive(false);
            }
        }
    }

    public void makeClick()
    {
        if (!hasClicked)
        {
            uiClick.gameObject.SetActive(true);
            hasClicked = true;
        }
    }

    public void makeStep()
    {
        if (!hasStepped)
        {
            stepSound.gameObject.SetActive(true);
            hasStepped = true;
        }
    }

    public void makeComplete()
    {
        if (!hasCompleted)
        {
            completeSound.gameObject.SetActive(true);
            hasCompleted = true;
        }
    }
}
