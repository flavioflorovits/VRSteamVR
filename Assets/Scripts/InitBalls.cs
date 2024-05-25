using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBalls : MonoBehaviour
{
    private static InitBalls _instance;

    public static InitBalls Instance { get { return _instance; } }


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

    [SerializeField] private GameObject ballPosL;
    [SerializeField] private GameObject ballPrefabL;
    [SerializeField] private GameObject ballPosR;
    [SerializeField] private GameObject ballPrefabR;

    // Start is called before the first frame update
    void Start()
    {
        InitializeBalls();
    }

    public void InitializeBalls()
    {
        Instantiate(ballPrefabL, ballPosL.transform.position, Quaternion.identity);
        Instantiate(ballPrefabR, ballPosR.transform.position, Quaternion.identity);
    }
}
