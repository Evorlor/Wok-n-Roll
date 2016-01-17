using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private Canvas canvas;

	// Use this for initialization
	void Start () {
		canvas = FindObjectOfType<Canvas>();

	}

	// Update is called once per frame
	void Update () {
		// TODO: Update the score
		//Core.GetInstance().Score;
	}
}
