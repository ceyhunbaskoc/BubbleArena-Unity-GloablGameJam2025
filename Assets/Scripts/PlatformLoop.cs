using Unity.VisualScripting;
using UnityEngine;

public class PlatformLoop : MonoBehaviour
{
    public Vector2 sinir1, sinir2;
    private Vector2 currentTarget;
    public float MovementSpeed;
    void Start()
    {
        currentTarget = sinir2;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, MovementSpeed * Time.fixedDeltaTime);
        if (Vector2.Distance(transform.position,sinir2)<0.1f)
        {
            currentTarget=sinir1;
        }
        if (Vector2.Distance(transform.position,sinir1)<0.1f)
        {
            currentTarget=sinir2;
        }
    }
}
