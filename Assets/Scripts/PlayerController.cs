using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 6f;
    public Transform grabPoint;

    //create boundaries for movement
    public float minX = -5f, maxX = 5f;
    public float minZ = -5f, maxZ = 5f;

    Ingredients hold;

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hold == null) Grab();
            else Drop();
        }
    
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
        boundaryPosition.z = Mathf.Clamp(boundaryPosition.z, minZ, maxZ);

        transform.position = boundaryPosition;
    }

    void Grab()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Ingredients ingredient = hit.collider.GetComponent<Ingredients>();

            if (ingredient != null)
            {
                hold = ingredient;
                hold.Grab(grabPoint);
            }
        }
    }

    void Drop()
    {
        hold.Drop();
        hold = null;
    }
}
