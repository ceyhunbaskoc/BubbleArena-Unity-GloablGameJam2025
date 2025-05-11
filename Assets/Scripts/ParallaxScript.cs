using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    private float lenght, startPos;
    public GameObject camera;
    public float parallaxEffect;
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void Update()
    {
        
        float distance = (camera.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos+distance,transform.position.y,transform.position.z);

        
    }
}
