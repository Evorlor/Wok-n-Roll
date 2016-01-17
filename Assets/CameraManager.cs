using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public Camera[] cameras;
    public float delayToSwitch = 10.0f;

    int currentCamera = 0;


    void Start()
    {

        StartCoroutine("ChangeCameras");
    }

    private IEnumerator ChangeCameras()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayToSwitch);
            cameras[currentCamera].enabled = false;
            currentCamera = (currentCamera + 1) % cameras.Length;
            cameras[currentCamera].enabled = true;
        }
    }
}
