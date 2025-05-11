using System.Collections;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    public float rotateSpeed;
    public float time;
    private int sayac = 0;
    void Start()
    {
        StartCoroutine(Wait());
    }
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, rotateSpeed);
        if(sayac==0)
        {
            StartCoroutine(Wait());
            sayac++;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        rotateSpeed *= -1;
        sayac = 0;
    }
}
