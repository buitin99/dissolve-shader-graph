using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ShaderGraphItems : MonoBehaviour
{
    public int score;
    private Material mat;
    private float _timeCount;
    private bool _isTrigger;
    private float _i = 0;
    public static event Action<int> onDestroyItem;


    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_isTrigger){
            if(_i <= 1) {
                mat.SetFloat("_Dissolve",_i);
            }
            if(_i > 1) {
                Destroy(gameObject);
            }
            _i += 0.01f;
        }
    }

    public void OnTriggerEnter(Collider other) {
        _isTrigger = true;
        onDestroyItem?.Invoke(score);
    }

    private void OnDestroy() {
    }
}
