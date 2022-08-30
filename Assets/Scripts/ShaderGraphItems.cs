using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShaderGraphItems : MonoBehaviour
{
    private Material mat;
    private float timeCount;
    private bool isTrigger;
    private float i = 0;

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
                GameManager.Instance.UpdateDestroyItem();
            }
            i += 0.01f;
        }
    }

    public void OnTriggerEnter(Collider other) {
        isTrigger = true;
    }
}
