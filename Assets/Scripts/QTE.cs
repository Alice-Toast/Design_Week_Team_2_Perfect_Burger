using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QTE : MonoBehaviour
{
    // Start is called before the first frame update
   
    public RectTransform spinner;

    public float rotationSpeed = -180f;

    // -105° to -80° = 255° to 280° in Unity's 0–360 system apparently
    public float successMinAngle = 255f;
    public float successMaxAngle = 280f;

    public TMP_Text feedbackText;

    private bool qteActive = true;

    // Update is called once per frame
    void Update()
    {
        // Keep spinning until the player presses Space
        if (qteActive)
        {
            spinner.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }

        // Check for Space
        if (qteActive && Input.GetKeyDown(KeyCode.Space))
        {
            CheckQTE();
        }
    }
    void CheckQTE()
    {
        qteActive = false;

        float angle = spinner.localEulerAngles.z;

        if (angle >= successMinAngle && angle <= successMaxAngle)
        {
            Debug.Log("QTE SUCCESS!");
            feedbackText.text = "SUCCESS!";
        }
        else
        {
            Debug.Log("QTE FAIL!");
            feedbackText.text = "FAIL!";
        }
    }
}
