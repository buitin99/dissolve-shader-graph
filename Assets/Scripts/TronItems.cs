using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TronItems : MonoBehaviour
{
    public int score;
    public static event Action<int> onDestroyTronItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }

    public void OnDestroy()
    {
        onDestroyTronItem?.Invoke(score);
    }
}
