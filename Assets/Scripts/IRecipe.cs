using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IRecipe {
	Action NextStep();
	Action PreStep();
	Action CurrentStep();

	List<int> GetIngredients();
}
