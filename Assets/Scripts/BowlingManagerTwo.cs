using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingManagerTwo : MonoBehaviour
{

    [SerializeField] private BowlingManager bowlingManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BallG") || other.CompareTag("BallR") || other.CompareTag("BallL"))
        {
            StartCoroutine(waitScore());
        }
    }

    IEnumerator waitScore()
    {
        yield return new WaitForSeconds(5);
        bowlingManager.UpdateScore();
    }

}
