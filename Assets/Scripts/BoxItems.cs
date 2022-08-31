using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class BoxItems : Items
{
    private Material mat;
    private float _timeCount;
    private bool _isTrigger;
    private float _i = 0;

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

    protected override void OnTriggerEnter(Collider other) {
        _isTrigger = true;
        TriggerEvent();
    }
}
