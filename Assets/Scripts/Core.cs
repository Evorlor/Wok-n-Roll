using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour {

	private IRecipe mRecipe;
	private bool started = true;

	public float MaxScore = 100.0f;
	private float score = 0.0f;

	// Use this for initialization
	void Start () {
		// TODO: Testing
		mRecipe = new RandomRecipe(3);
    }

	// Update is called once per frame
	void Update () {
		if (started)
		{
			if (Control.GetInstance().GetInput(Action.North))
			{
				Debug.Log("North");
			}

			try
			{
				Debug.Log(mRecipe.NextStep());
			}
			catch { }
		}
	}

	public void SetRecipe(IRecipe recipe)
	{
		mRecipe = recipe;
    }

	public void StartCooking()
	{
		started = true;
    }
}
