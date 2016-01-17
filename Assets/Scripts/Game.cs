using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Core.GetInstance().StartCooking();
    }

	// Update is called once per frame
	void Update () {
		Core.GetInstance().Score;
    }
}
