using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Material mat;
    private float timeCount;
    private bool isTrigger;
    private float i;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isTrigger && i <= 1){
             mat.SetFloat("_Dissolve",i);
             i += 0.01f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        isTrigger = true;
        Destroy(gameObject, 2);
    }
    private void OnTriggerStay(Collider other) {
        Debug.Log(other.gameObject.name);
    }
}
