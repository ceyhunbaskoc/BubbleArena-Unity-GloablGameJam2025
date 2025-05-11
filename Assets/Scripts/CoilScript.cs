using System.Collections;
using UnityEngine;

public class CoilScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float bounceForce;
    public float duration;
    Vector2 normal;
    private int sayac=0;

    private void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            normal = collision.contacts[0].normal;
            if (sayac == 0)
            {
                sayac++;
                StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(duration);
        rb.AddForce(-normal * bounceForce, ForceMode2D.Impulse);
        sayac = 0;
    }
}
