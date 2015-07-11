using UnityEngine;
using System.Collections;

public class Flip : MonoBehaviour
{
	int number;

	void Start ()
	{
		number = (int)((transform.position.x / 2) + 5*(transform.position.y / 3));
	}

	void OnMouseDown()
	{
		Cards.count++;

		if(Cards.count == 1)
		{
			Cards.card1 = number;
		}
		else
		{
			Cards.card2 = number;
		}

		Destroy (gameObject);
	}
}
