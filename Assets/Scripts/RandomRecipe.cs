using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RandomRecipe : IRecipe
{
	private List<Action> steps;
	private int mNumSteps;
	private int currentStep = 0;

	public RandomRecipe(int numSteps)
	{
		steps = new List<Action>();
		mNumSteps = numSteps;
        ranGen();
    }

	private void ranGen()
	{
		for (int i = 0; i < mNumSteps; i++)
		{
			steps.Add((Action)UnityEngine.Random.Range((int)Action.Jump, (int)Action.Jump));
		}
	}

	public Action NextStep()
	{
		if (++currentStep >= mNumSteps)
		{
			// Throw
			currentStep--;

			throw new InvalidOperationException();
        }
		return steps[currentStep];
    }

	public Action PreStep()
	{
		if (--currentStep < 0)
		{
			// Throw
			currentStep = 0;

			throw new InvalidOperationException();
		}
		return steps[currentStep];
	}

	public Action CurrentStep()
	{
		return steps[currentStep];
    }

	// TODO: Plate extension
	public List<int> GetIngredients()
	{
		return null;
	}
}
