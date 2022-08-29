using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawners : MonoBehaviour
{

    public GameObject[] items;

    private int itemCount;
    private int itemIndex;
    private int xPos;
    private int zPos;
    private float sizeYGround;
    public Transform ground;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ItemsDrop());
        sizeYGround =  ground.GetComponent<BoxCollider>().size.y;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ItemsDrop()
    {
        while(itemCount < 20)
        {
            xPos = Random.Range(-70,-50);
            zPos = Random.Range(-35,-15);
            itemIndex = Random.Range(0,1);
            var itemSpawn = Instantiate(items[itemIndex], new Vector3(xPos, ground.position.y + sizeYGround + 0.3f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(5f);
            itemCount++;
        }
    }
}
