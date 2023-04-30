using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
	[SerializeField] protected GameObject menuPanel;
	[SerializeField] protected GameObject gamePanel;
	[SerializeField] protected GameObject levelEndPanel;

	private static MenuManager m_Instance;

	private void Awake() => m_Instance = this;
	public static MenuManager Instance => m_Instance;

	private void Start()
	{
		GameManager.LevelEnd += LevelEndPanel;
	}

    private void OnDestroy()
    {
        GameManager.LevelEnd -= LevelEndPanel;
    }

    public void StartTheGame()
	{
		menuPanel.SetActive(false);
		gamePanel.SetActive(true);
		GameManager.Instance.SpawnLevel();
	}

	public void LevelEndPanel()
	{
		levelEndPanel.SetActive(true);
		gamePanel.SetActive(false);
	}

	public void LevelEndPanel(bool panelState)
	{
		levelEndPanel.SetActive(panelState);
		gamePanel.SetActive(!panelState);
	}

	public void ReturnToMainMenu()
	{
		levelEndPanel.SetActive(false);
		gamePanel.SetActive(false);
		menuPanel.SetActive(true);
	}

	public void CloseTheGame()
	{
		Application.Quit();
	}
}
