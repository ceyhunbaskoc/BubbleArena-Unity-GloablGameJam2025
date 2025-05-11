using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public bool dead = false;
    private SpriteRenderer sr;
    private Collider2D collider;
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("saw")|| collision.gameObject.CompareTag("spikes"))
        {
            dead = true;
            sr.enabled = false;
            collider.enabled = false;
            
        }
    }
}
