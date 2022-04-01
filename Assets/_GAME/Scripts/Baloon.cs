using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Baloon : MonoBehaviour
{
	[SerializeField] protected BaloonProperties properties;
	private void Start()
	{

		if(properties != null)
		{
			gameObject.GetComponent<Renderer>().sharedMaterial = properties.Material;
			TextMeshPro[] texts = gameObject.GetComponentsInChildren<TextMeshPro>();
			foreach (TextMeshPro tmp in texts)
			{
				if(properties.Score > 0)
					tmp.text = "+" + properties.Score.ToString();
				else if(properties.Score < 0)
					tmp.text = properties.Score.ToString();
				else
					tmp.text = properties.Score.ToString();
			}
		}
	}

	void Update()
	{
		transform.Translate(0, properties.VerticalSpeed * Time.deltaTime, 0);	
	}

	public int GetBalloonScore()
	{
		return properties.Score;
	}

	public BaloonTypes GetBalloonType()
	{
		return properties.BaloonType;
	}
}
