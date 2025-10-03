using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDebug : MonoBehaviour
{
    public GasAnalyzerScreen f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
            f.SwitchEnabledStatus();

    }
}
