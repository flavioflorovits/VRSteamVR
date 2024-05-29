using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR;

public class ScoreHandler : MonoBehaviour
{
    private static ScoreHandler _instance;

    public static ScoreHandler Instance { get { return _instance; } }


    [SerializeField] private TextMeshProUGUI roundText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private bool isEnabled = true;

    [SerializeField] private SteamVR_Action_Boolean triggerBoolean;
    [SerializeField] private SteamVR_Input_Sources handType;

    private List<GameObject> children = new List<GameObject>();

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        triggerBoolean.AddOnStateDownListener(ToggleUi, handType);

    }

    private void Start()
    {
        foreach (Transform tr in gameObject.GetComponentsInChildren<Transform>())
        {
            if ( tr.gameObject != gameObject)
            {
                children.Add(tr.gameObject);
            }
        }
    }

    private void OnDisable()
    {
        triggerBoolean.RemoveAllListeners(handType);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateRound(int round)
    {
        roundText.text = "Round: " + round.ToString();
    }

    private void ToggleUi(SteamVR_Action_Boolean function, SteamVR_Input_Sources fromSource)
    {

        Debug.Log("toggle ui called");
        isEnabled = !isEnabled;

        foreach (GameObject obj in children) 
        {
            obj.SetActive(isEnabled);
        }

    }

}
