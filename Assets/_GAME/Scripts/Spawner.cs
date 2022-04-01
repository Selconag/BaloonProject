using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
public class Spawner : MonoBehaviour
{
    //Spawn Region Values
    [SerializeField]
    protected int minXVal, maxXVal, minZVal, maxZVal;
    [Range(0,1f)]
    [Tooltip("Defines how much seconds the spawner wait for next balloon to be spawned.")]
    [SerializeField]
    protected float spawnWaiter = 0.05f;
    //Holds Baloons Spawning List, can be added new ones or extract old ones
    [SerializeField] protected List<GameObject> BaloonList;

    private bool endGame;
    //public static Action SpawningSequence;
    void Start()
    {
        //SpawningSequence = StartSpawningSequence;
        GameManager.LevelEnd += LevelEnd;
        StartCoroutine(StartSpawningSequence());
    }
    /*
     * Note: Balloons will be spawned randomly, in the area with given formula
     * Spawned X Coordinate "Xs" => minXVal < Xs < maxXVal .
     * if minXVal = -5 and maxXVal = 5
     * Xs will be chosen between -5 to 5 coordinates randomly.
     * 
     * Spawned Y Coordinate will always be "Ys = 0" .
     * 
     * Spawned Z Coordinate "Zs" => minZVal < Zs < maxZVal .
     * * if minZVal = -5 and maxZVal = 5
     * Zs will be chosen between -5 to 5 coordinates randomly.
     */
    private IEnumerator StartSpawningSequence()
	{
		while (!endGame)
		{
			if (BaloonList.Count == 0) break;
			else
			{
				Instantiate(BaloonList[Random.Range(0, BaloonList.Count)], new Vector3(Random.Range(minXVal, maxXVal), 0, Random.Range(minZVal, maxZVal)), Quaternion.identity, transform.parent);
			}
			yield return new WaitForSeconds(spawnWaiter);
		}
    }

	private void LevelEnd()
	{
		endGame = true;
	}

	private void OnDestroy()
	{
		GameManager.LevelEnd -= OnDestroy;
	}
}
