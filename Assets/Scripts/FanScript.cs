using UnityEngine;

public class FanScript : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D col;
    public float FanForce;
    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject!= null)
        {
            rb=collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 direction = transform.up;

            float distance = direction.magnitude;

            float force = Mathf.Lerp(FanForce, 0, distance / col.size.y);
            print("force uygulaniyor");
            rb.AddForce(direction * force);
        }
    }
}
