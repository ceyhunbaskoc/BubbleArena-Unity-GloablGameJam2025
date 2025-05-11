using Unity.Cinemachine;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float minLens,maxLens,RadiusTotal,cameraMinY;
    float distance, maxDistance;
    Vector2 middlePoint;
    public GameObject Player1, Player2;
    CinemachineCamera cam;
    float inverse,targetLens;
    CircleCollider2D collider1, collider2;
    void Start()
    {
        collider1=Player1.GetComponent<CircleCollider2D>();
        collider2 = Player2.GetComponent<CircleCollider2D>();
        cam= GetComponent<CinemachineCamera>();
        RadiusTotal = (collider1.radius * Player1.transform.localScale.x) + (collider2.radius * Player2.transform.localScale.x);
        maxDistance = Vector2.Distance(Player1.transform.position, Player2.transform.position);
    }

    
    void Update()
    {
        
        middlePoint = (Player1.transform.position+Player2.transform.position)/2;

        if(transform.position.y<=cameraMinY)
        {
            transform.position = new Vector3(middlePoint.x, cameraMinY, -10f);
        }
        else
        {
            transform.position = new Vector3(middlePoint.x, middlePoint.y, -10f);
        }

        distance = Vector2.Distance(Player1.transform.position,Player2.transform.position);
        inverse = Mathf.InverseLerp(RadiusTotal,maxDistance,distance);
        targetLens = Mathf.Lerp(minLens,maxLens,inverse);

        cam.Lens.OrthographicSize = targetLens;
    }
}
