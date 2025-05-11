using System.Collections;
using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class CameraNoiseScript : MonoBehaviour
{
    public GameObject camera;
    CinemachineBasicMultiChannelPerlin cm;
    public NoiseSettings shake;
    void Start()
    {
        cm=camera.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mine"))
        {
            cm.NoiseProfile = shake;
            StartCoroutine(ResetCameraShake());
        }
    }
    private IEnumerator ResetCameraShake()
    {
        
        yield return new WaitForSeconds(0.5f);

        
        cm.NoiseProfile = null;
    }
}
