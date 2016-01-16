using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IRecipe {
	Control.INPUT NextStep();
	Control.INPUT PreStep();
	Control.INPUT CurrentStep();

	List<int> GetIngredients();
}
