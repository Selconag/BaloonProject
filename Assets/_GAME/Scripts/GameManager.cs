using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	public static Action LevelEnd;

	[SerializeField] protected Text endText;
	[SerializeField] protected Text scoreText;
	[SerializeField] protected Text baloonsText;
	[SerializeField] protected List<GameObject> levels;

	private int playerScore = 0;
	private int activeLevelCount = 0;
	private GameObject activeLevel;
	private Dictionary<BaloonTypes, int> baloonCounts;
	
	private static GameManager m_Instance;
	private void Awake() => m_Instance = this;
	public static GameManager Instance => m_Instance;

	void Start()
	{
		Player.Instance.scoreTypeEvent += RecordToDictionary;
		Player.Instance.scoreEvent += UpdateScore;
	}

	private void RecordToDictionary(int score, BaloonTypes type)
	{
		//If Baloon Dictionary has any entries, enter here.
		if(baloonCounts.Count > 0)
		{
			//Check if Baloon Dictionary has type entry.
			if (baloonCounts.ContainsKey(type))
			{
				baloonCounts[type]++;
			}
			//If not, add a new entry
			else
			{
				baloonCounts.Add(type, 1);
			}
		}
		//If Baloon Dictionary will has its first enrty, enter here.
		else
		{
			baloonCounts.Add(type, 1);
		}
		UpdateScore(score);
	}

	private void UpdateScore(int score)
	{
		playerScore += score;
		if (playerScore < 0)
			EndLevel(false);
		else if (playerScore >= 50)
			EndLevel(true);
	}

	private void Update()
	{
		scoreText.text = "Skor:" + playerScore.ToString();
	}

	//Called whenever game starts.
	public void SpawnLevel()
	{
		baloonCounts = new Dictionary<BaloonTypes, int>();
		if (levels.Count < 2)
			activeLevel = Instantiate(levels[0]);
		else
			activeLevel = Instantiate(levels[activeLevelCount]);
	}

	//Called when player clicked the restart game button.
	public void RestartLevel()
	{
		SpawnLevel();
		MenuManager.Instance.LevelEndPanel(false);
	}

	//Called when game ends with a certain win or lose condition.
	private void EndLevel(bool win)
	{
		LevelEnd.Invoke();
		//Stop the game
		Destroy(activeLevel);
		activeLevel = null;
		activeLevelCount++;
		MenuManager.Instance.LevelEndPanel();
		GenerateEndText(win);
	}

	//Generates what will be shown when level ends.
	private void GenerateEndText(bool win)
	{
		if (win)
		{
			endText.text = "Tebrikler, Oyunu Kazandýnýz!" +
				"\nFinal Skorunuz:" + playerScore.ToString();
		}
		else
		{
			endText.text = "Maalesef kaybettiniz." +
				"\nFinal Skorunuz:" + playerScore.ToString();
		}
		baloonsText.text = "Yok Ettiðiniz Balonlar:";
		foreach (KeyValuePair<BaloonTypes, int> kvp in baloonCounts)
		{
			baloonsText.text += "\n" + kvp.Key.ToString() + ": " + kvp.Value.ToString();
		}
		baloonCounts = null;
		playerScore = 0;
	}

	private void OnDestroy()
	{
		Player.Instance.scoreTypeEvent -= RecordToDictionary;
		Player.Instance.scoreEvent -= UpdateScore;
	}
}
