using UnityEngine;
using System.Collections;

public class Cards : MonoBehaviour
{
	public GameObject[] cards = new GameObject[20];
	public GameObject backCard;
	public static int[,] place = new int[20, 2];
	int x = 0, y = 0, countCards = 0;

	public static int count = 0;
	public static int card1, card2;

	void Start ()
	{
		for(int i = 0; i < 20; i++)
		{
			place[i, 0] = i;
			place[i, 1] = 0;  //face down

			Instantiate(backCard, new Vector3(x, y, 0), Quaternion.identity);
			
			x = x + 2;
			if(x > 8)
			{
				x = 0;
				y = y + 3;
			}
		}

		Make ();
		PlaceCards ();
	}

	void Update ()
	{
		//if card is "Mix Up"
		if(count == 1 && (place[card1, 0] == 0 || place[card1, 0] == 1))
		{
			place[card1, 1] = 1;
			Make();
			PlaceCards();
			StartCoroutine(WaitASec(1.0F));
			count = 0;
		}
		else if(count == 2)
		{
			//if cards match
			if(cards[place[card1, 0]].name == cards[place[card2, 0]].name)
			{
				place[card1, 1] = 1;
				place[card2, 1] = 1;

				StartCoroutine(WaitASec(1.0F));
			}
			//if card is "Mix Up"
			else if(place[card2, 0] == 0 || place[card2, 0] == 1)
			{
				place[card1, 1] = 1;
				place[card2, 1] = 1;
				Make();
				PlaceCards();
				place[card1, 1] = 0;
				StartCoroutine(WaitASec(1.0F));
			}
			else
			{
				StartCoroutine(WaitASec(1.0F));
			}

			count = 0;
		}

		Check ();
	}

	void Make()
	{
		int num = Random.Range (10, 21); //10 to 20
		int a, b, temp;

		for(int i = 0; i < num; i++)
		{
			a = Random.Range(0, 20);

			b = Random.Range(0, 20);

			while(place[a, 1] == 1)
			{
				a = Random.Range(0, 20);
			}

			while(a == b || place[b, 1] == 1)
			{
				b = Random.Range(0, 20);
			}

			temp = place[a, 0];
			place[a, 0] = place[b, 0];
			place[b, 0] = temp;
		}
	}

	void PlaceCards()
	{
		x = 0;
		y = 0;

		for(int i = 0; i < 20; i++)
		{
			if(place[i, 1] != 1)  //matched
			{
				cards[place[i, 0]].transform.position = new Vector2(x, y);
			}

			x = x + 2;
			if(x > 8)
			{
				x = 0;
				y = y + 3;
			}
		}
	}

	IEnumerator WaitASec(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);

		if(place[card1, 1] == 0)
		{
			Instantiate(backCard, new Vector3(2 * (card1 % 5), 3 * (card1 / 5), 0), Quaternion.identity);

			if(place[card2, 1] == 0)
			{
				Instantiate(backCard, new Vector3(2 * (card2 % 5), 3 * (card2 / 5), 0), Quaternion.identity);
			}
			else
			{
				cards[place[card2, 0]].transform.position = new Vector2(-5, -5);
			}
		}
		else
		{
			cards[place[card1, 0]].transform.position = new Vector2(-5, -5);

			if(place[card2, 1] == 1)
			{
				cards[place[card2, 0]].transform.position = new Vector2(-5, -5);
			}
		}
	}

	void Check()
	{
		for(int i = 0; i < 20; i++)
		{
			if(place[i, 1] == 1 || place[i, 0] == 0 || place[i, 0] == 1)
			{
				countCards++;
			}
		}

		if(countCards == 20)
		{
			Application.LoadLevel("MatchCard");
		}

		countCards = 0;
	}
}
