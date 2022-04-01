using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<Baloon>().GetBalloonScore() > 0) 
			Player.Instance.InvokeScoreAndType(-1);
		Destroy(other.gameObject);
	}
}
