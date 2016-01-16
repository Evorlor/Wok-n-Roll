using UnityEngine;

public class Test : MonoBehaviour {
	void Update ()
    {
        if (Input.GetButton(InputNames.North))
        {
            Debug.Log("North");
        }
        else if (Input.GetButton(InputNames.Northeast))
        {
            Debug.Log("Northeast");
        }
        else if (Input.GetButton(InputNames.East))
        {
            Debug.Log("East");
        }
        else if (Input.GetButton(InputNames.Southeast))
        {
            Debug.Log("Southeast");
        }
        else if (Input.GetButton(InputNames.South))
        {
            Debug.Log("South");
        }
        else if (Input.GetButton(InputNames.Southwest))
        {
            Debug.Log("Southwest");
        }
        else if (Input.GetButton(InputNames.West))
        {
            Debug.Log("West");
        }
        else if (Input.GetButton(InputNames.Northwest))
        {
            Debug.Log("Northwest");
        }
        else if (!Input.GetButton(InputNames.Jump))
        {
            Debug.Log("Jump");
        }
    }
}
