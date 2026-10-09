using UnityEngine;

public class Ingredients : MonoBehaviour
{
    Rigidbody rb;
    bool dropped = false;
    bool stuck = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Grab(Transform grabPoint)
    {
        rb.isKinematic = true;
        transform.SetParent(grabPoint);
        transform.localPosition = Vector3.zero;
    }


    public void Drop()
    {
        transform.SetParent(null);
        rb.isKinematic = false;
        dropped = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!dropped || stuck) return;
        bool landOnBun = collision.gameObject.CompareTag("Bun");
        Ingredients other = collision.gameObject.GetComponent<Ingredients>();
        bool landOnIngredients = other != null && other.stuck;

        if (landOnBun || landOnIngredients)
        {
            stuck = true;
            rb.isKinematic = true;
        }
    }
}
