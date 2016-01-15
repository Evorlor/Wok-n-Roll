using UnityEngine;

public class Test : MonoBehaviour {
	void Update () {
        if (Input.GetButton(InputNames.North))
        {
            Debug.Log("north");
        }
        if (Input.GetButton(InputNames.Northeast))
        {
            Debug.Log("northeast");
        }
	}
}
