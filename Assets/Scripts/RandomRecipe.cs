using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RandomRecipe : IRecipe
{
	private List<Control.INPUT> steps;
	private int mNumSteps;
	private int currentStep = 0;

	public RandomRecipe(int numSteps)
	{
		steps = new List<Control.INPUT>();
		mNumSteps = numSteps;
        ranGen();
    }

	private void ranGen()
	{
		for (int i = 0; i < mNumSteps; i++)
		{
			steps.Add((Control.INPUT)UnityEngine.Random.Range((int)Control.INPUT.BEGIN, (int)Control.INPUT.SIZE));
		}
	}

	public Control.INPUT NextStep()
	{
		if (++currentStep >= mNumSteps)
		{
			// Throw
			currentStep--;

			throw new InvalidOperationException();
        }
		return steps[currentStep];
    }

	public Control.INPUT PreStep()
	{
		if (--currentStep < 0)
		{
			// Throw
			currentStep = 0;

			throw new InvalidOperationException();
		}
		return steps[currentStep];
	}

	public Control.INPUT CurrentStep()
	{
		return steps[currentStep];
    }

	// TODO: Plate extension
	public List<int> GetIngredients()
	{
		return null;
	}
}
