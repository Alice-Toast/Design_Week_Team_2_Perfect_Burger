using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 6f;
    public Transform grabPoint;

    //create boundaries for movement
    public float minX = -5f, maxX = 5f;
    public float minZ = -5f, maxZ = 5f;

    // Update is called once per frame
    void Update()
    {
        Move();
    
    }
    //Player Controls 
    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        //keeping player within boundaries
        Vector3 boundaryPosition = transform.position;
        boundaryPosition.x = Mathf.Clamp(boundaryPosition.x, minX, maxX);
        boundaryPosition.z = Mathf.Clamp(boundaryPosition.y, minZ, maxZ);

        transform.position = boundaryPosition;
    }
}
