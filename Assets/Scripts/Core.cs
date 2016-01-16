using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

		if (Control.GetInstance().GetInput(Control.INPUT.North))
		{
			Debug.Log("North");
		}
	}
}
