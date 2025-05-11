using System.Collections;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    public GameObject minePrefab;
    public GameObject Fan1,Fan2;
    public float time,fan1,fan2;
    private MineScript mineScript;
    private Rigidbody2D rb;
    void Start()
    {
        
        StartCoroutine(Wait());
        StartCoroutine(EnableFan(Fan1,fan1));
        StartCoroutine(EnableFan(Fan2,fan2));
    }

    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        GameObject newMine=Instantiate(minePrefab,transform.position,Quaternion.Euler(0,0,0));
        mineScript = newMine.GetComponent<MineScript>();
        rb = newMine.GetComponent<Rigidbody2D>();   
        mineScript.explosionForce = 30000;
        rb.gravityScale = 4f;
        StartCoroutine(Wait());
    }
    IEnumerator EnableFan(GameObject Fan,float FanTime)
    {
        yield return new WaitForSeconds(FanTime);
        Fan.SetActive(true);
    }
}
