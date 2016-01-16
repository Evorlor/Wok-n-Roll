using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RandomRecipe : IRecipe
{
    private List<Action> steps;
    private int mNumSteps;
    private int currentStep = 0;

    public RandomRecipe()
    {
        steps = new List<Action>();
        mNumSteps = InstructionManager.Instance.GetActiveInstructions().Length;
        ranGen();
    }

    private void ranGen()
    {
        var activeInstructions = InstructionManager.Instance.GetActiveInstructions();
        for (int i = 0; i < mNumSteps; i++)
        {
            steps.Add(activeInstructions[i].action);
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
        InstructionManager.Instance.NextInstruction();
        return steps[currentStep];
    }

    //Will not work with animations
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
