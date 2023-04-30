using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    public delegate void ScoreTypeDelegate(int score,BaloonTypes baloonType);
    public delegate void ScoreDelegate(int score);
    public event ScoreTypeDelegate scoreTypeEvent;
    public event ScoreDelegate scoreEvent;
    private static Player m_Instance;

	private void Awake() => m_Instance = this;
	public static Player Instance => m_Instance;

    //void Update()
    //   {
    //       if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
    //	{
    //           RaycastHit hit;
    //           Ray ray = this.gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

    //		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
    //           {
    //               Transform objectHit = hit.transform;
    //               InvokeScoreAndType(objectHit.GetComponent<Baloon>().GetBalloonScore(), objectHit.GetComponent<Baloon>().GetBalloonType());
    //               Destroy(objectHit.gameObject);
    //           }
    //       }
    //   }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                Ray ray = this.gameObject.GetComponent<Camera>().ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Transform objectHit = hit.transform;
                    InvokeScoreAndType(objectHit.GetComponent<Baloon>().GetBalloonScore(), objectHit.GetComponent<Baloon>().GetBalloonType());
                    Destroy(objectHit.gameObject);
                }
            }
        }
    }

    public void InvokeScoreAndType(int score)
	{
        scoreEvent.Invoke(score);
    }

    public void InvokeScoreAndType(int score, BaloonTypes type)
	{
        scoreTypeEvent.Invoke(score,type);
    }
}
