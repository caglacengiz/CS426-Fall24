using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    public int state;
    public bool door1Lock;
    public bool door2Lock;
    // Start is called before the first frame update
    void Start()
    {
        state=0;
        door1Lock=true;
        door2Lock=false;
    }

    // Update is called once per frame
}
