using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Phoenix;

public class SariskaChatUnity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Token Generation");
        string token = GenerateToken.GetToken("dipak").token;
        Debug.Log(token);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
