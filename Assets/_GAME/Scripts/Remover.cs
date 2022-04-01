using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<Baloon>().GetBalloonScore() > 0)
			Player.Instance.InvokeScoreAndType(-1);
		Destroy(collision.gameObject);
	}
}
