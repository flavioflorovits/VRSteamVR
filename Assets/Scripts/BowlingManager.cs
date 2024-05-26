using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingManager : MonoBehaviour
{
    private static BowlingManager _instance;

    public static BowlingManager Instance { get { return _instance; } }


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
    }

    [SerializeField] private int totalRounds = 3; // Adjust for 3 or 4 rounds
    private int currentRound;
    private int currentFrame;
    private int totalScore = 0;
    private int tempBonus = 0;

    [SerializeField] private List<GameObject> pins; // List to store all pin GameObjects
    [SerializeField] private List<GameObject> downedPins = new List<GameObject>();

    private List<Vector3> pinPosition = new List<Vector3>();
    private List<Quaternion> pinRotation = new List<Quaternion>();

    [SerializeField] AudioSource strike;
    [SerializeField] AudioSource spare;


    private bool firstThrow; // Flag to track if it's the first throw in a frame

    private void Start()
    {
        currentRound = 1;
        currentFrame = 1;
        firstThrow = true;

        foreach (GameObject pin in pins)
        {
            pinPosition.Add(pin.transform.position);
            pinRotation.Add(pin.transform.rotation);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pin"))
        {
            downedPins.Add(other.gameObject);
            Debug.Log("Pin downed");

        }
    }

    public void UpdateScore()
    {
        if (firstThrow && downedPins.Count == 10)
        {
            totalScore += 10;
            tempBonus += 10;
            ResetPins(false);
            firstThrow = true;
            currentFrame++;
            Debug.Log("STRIKE");
            strike.Play();
        }
        else if (!firstThrow && downedPins.Count == 10)
        {
            totalScore += 10;
            tempBonus += 10;
            ResetPins(false);
            currentFrame++;
            firstThrow = true;
            Debug.Log("SPARE");
            spare.Play();
        }
        else
        {
            totalScore += downedPins.Count + tempBonus;
            tempBonus = 0;
            ResetPins(firstThrow);
            firstThrow = !firstThrow;
            currentFrame++;
            Debug.Log("Downed: " + downedPins.Count);
        }

        if (currentFrame > 2 * totalRounds)
        {
            Debug.Log("Total score in round " + currentRound + ":" + totalScore);
            firstThrow = false;
            ResetPins(false);
            tempBonus = 0;
            totalScore = 0;
            currentFrame = 1;
            currentRound++;
        }

    }

    private void ResetPins(bool isFirst)
    {
        if (isFirst)
        {
            foreach (GameObject pin in downedPins)
            {
                pin.SetActive(false);
            }
        }
        else
        {
            downedPins.Clear();

            for (int i = 0; i < pins.Count; i++)
            {
                pins[i].transform.position = pinPosition[i];
                pins[i].transform.rotation = pinRotation[i];
                pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                pins[i].SetActive(true);
            }

        }
    }

}
