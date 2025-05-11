using System.Collections;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    public float explosionRadius;
    public float explosionForce;
    public GameObject explosionParticle;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("de�di");
        if(!collision.gameObject.CompareTag("Ground")&&!collision.gameObject.CompareTag("Mine"))
        {
            Explosion();
            
            explosionParticle.SetActive(true);
            StartCoroutine(Wait());   
            
        }
    }

    void Explosion()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        print(colliders.Length);

        for(int i = 0; i < colliders.Length; i++)
        {
            print("colliderlar belirleniyor...");
            Collider2D nearbyObject = colliders[i];

            Rigidbody2D rbNear=nearbyObject.GetComponent<Rigidbody2D>();
            if (rbNear != null)
            {
                Vector2 direction = rbNear.position - (Vector2)transform.position;

                float distance = direction.magnitude;

                direction.Normalize();

                float force = Mathf.Lerp(explosionForce, 0, distance / explosionRadius);
                
                rbNear.AddForce(direction * force);
            }

        }
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
