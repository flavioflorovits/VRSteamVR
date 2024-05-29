using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickedUp()
    {
        StopCoroutine(ResetBall()); 
    }
    public void Thrown()
    {
        StartCoroutine(ResetBall());   
    }
    IEnumerator ResetBall()
    {
        yield return new WaitForSeconds(5);

        if (gameObject.CompareTag("BallL"))
        {
            InitBalls.Instance.InitializeBalls(1);   
        }
        else if(gameObject.CompareTag("BallR"))
        {
            InitBalls.Instance.InitializeBalls(2);
        }
        Destroy(gameObject);
    }
}
