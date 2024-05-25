using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutter : MonoBehaviour
{

    [SerializeField] private GameObject ballPosL;
    [SerializeField] private GameObject ballPrefabL;
    [SerializeField] private GameObject ballPosR;
    [SerializeField] private GameObject ballPrefabR;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BallL"))
        {
            Destroy(other.gameObject);
            Instantiate(ballPrefabL, ballPosL.transform.position, Quaternion.identity);
        }
        else if (other.CompareTag("BallR"))
        {
            Destroy(other.gameObject);
            Instantiate(ballPrefabR, ballPosR.transform.position, Quaternion.identity);
        }
    }

}
