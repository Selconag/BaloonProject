using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    private bool stopCount;
    private void Start()
    {
        GameManager.LevelEnd += UpdateSpawn;
    }

    private void OnDestroy()
    {
        GameManager.LevelEnd -= UpdateSpawn;
    }

    private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<Baloon>().GetBalloonScore() > 0 && !stopCount)
			Player.Instance.InvokeScoreAndType(-1);
		Destroy(collision.gameObject);
	}

    private void UpdateSpawn()
    {
        stopCount = true;
    }
}
