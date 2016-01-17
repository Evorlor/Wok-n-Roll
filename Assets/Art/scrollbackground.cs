using UnityEngine;
using System.Collections;

public class scrollbackground : MonoBehaviour {

    private Renderer rendererfriend;

    public float speed = 0f;
    public float xOffset = 0f;
    public GameObject map;
    
    void Awake()
    {
        rendererfriend = GetComponent<Renderer>();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        rendererfriend.material.mainTextureOffset = new Vector2(Time.time * xOffset, Time.time * speed);
        

    }
}
