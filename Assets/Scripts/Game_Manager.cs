using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject[] burgerParts = new GameObject[11];
    bool DropPart = false;
    public int currentPart = 0;
    public float speed = 1;
    float currentTimer = 0;
    public float[] dropTimes = new float[11];
    bool gameFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (DropPart)
        {
            burgerParts[currentPart].transform.position = burgerParts[currentPart].transform.position + Vector3.down * speed * Time.deltaTime; // this drops the burger down for a set amount of time we couldn't use an animator as that changed the x and z position of the burger
            currentTimer += Time.deltaTime;
            if (currentTimer > dropTimes[currentPart])
            { // when the timer is reached, stop dropping the part and prime the next part to be dropped
                DropPart = false;
                currentPart++; // goes to the next part.
                currentTimer = 0f;
                if (currentPart > 10)
                {
                    gameFinished = true;
                }
                

            }
        }
    }
    
    public void DropBurgerPart()
    {
        DropPart = true; //when this function starts it initiates the next piece dropping
    }
}
