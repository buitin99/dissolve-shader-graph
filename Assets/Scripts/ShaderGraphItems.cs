using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ShaderGraphItems : MonoBehaviour
{
    public int score;
    private Material mat;
    private float timeCount;
    private bool isTrigger;
    private float i = 0;
    public static event Action<int> onDestroyItem;


    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isTrigger){
            if(i <= 1) {
                mat.SetFloat("_Dissolve",i);
            }
            if(i > 1) {
                Destroy(gameObject);
            }
            i += 0.01f;
        }
    }

    public void OnTriggerEnter(Collider other) {
        isTrigger = true;
    }

    private void OnDestroy() {
        onDestroyItem?.Invoke(score);
    }
}
