using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawners : MonoBehaviour
{

    public GameObject[] items;
    public Transform[] positionItems;
    public Transform ground;
    public Transform positionObject;
    public float SpawnItemTime = 5;
    private float time = 0;
    private int itemCount = 0;
    private int itemIndex;
    private int positionIndex;
    private float sizeYGround;

    // Start is called before the first frame update

    private void Awake() {
        GameManager.Instance.onDestroyItem.AddListener(() => itemCount -= 1 );
    }
    void Start()
    {
        // sizeYGround =  ground.GetComponent<BoxCollider>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= SpawnItemTime) 
        {
            SpawnItem();
            time = 0;
        } 
    }

    private void SpawnItem() {
        if(itemCount <  positionItems.Length) {
            itemIndex = Random.Range(0,items.Length);
            int countLoop = 0;
            //so luong con 
            while(positionItems[positionIndex].childCount >= 1 || countLoop <=  positionItems.Length ) {
                positionIndex = Random.Range(0,positionItems.Length);
                countLoop++; 
            }

            GameObject itemSpawn = Instantiate(items[itemIndex], positionItems[positionIndex]);
            itemSpawn.transform.SetParent(positionItems[positionIndex]);
            itemCount++;
            Debug.Log(itemCount);
            // var itemSpawn = Instantiate(items[itemIndex], new Vector3(xPos, ground.position.y + sizeYGround + 0.3f, zPos), Quaternion.identity);
        }
    }
}
