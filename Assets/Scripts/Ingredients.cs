using UnityEngine;

public class Ingredients : MonoBehaviour
{
    Rigidbody rb;
    bool dropped = false;
    public bool stuck = false;
    public bool isPatty;
    public bool isTopBun;

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
            if (isTopBun) Game_Manager.instance.TopBunPlaced();
            Game_Manager.instance.Scoring(transform.position);
            rb.isKinematic = true;

            if (landOnBun) transform.SetParent(collision.transform);
            else transform.SetParent(other.transform.parent);
        }
    }
}
