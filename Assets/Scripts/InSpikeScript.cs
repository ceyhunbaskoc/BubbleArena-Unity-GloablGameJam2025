using System.Collections;
using UnityEngine;

public class InSpikeScript : MonoBehaviour
{
    public float spikesDuration;
    private Collider2D coll;

    [SerializeField] GameObject destObj;
    private Vector2 destPos;
    private Vector2 currentPos;
    private void Start()
    {
        destPos = destObj.transform.position;
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(spikesDuration);
        currentPos = transform.position;
        transform.position = destPos;
        coll.enabled = !coll.enabled;
        destPos = currentPos;
        StartCoroutine(Wait());


    }
}
