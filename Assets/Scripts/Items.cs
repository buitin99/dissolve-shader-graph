using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public static event Action<int> onTrigger;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        TriggerEvent();
    }

    protected void TriggerEvent()
    {
        onTrigger?.Invoke(score);
        
    }

}
