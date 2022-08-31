using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomSpawners : MonoBehaviour
{

    public GameObject[] items;
    public Transform[] positionItems;
    public Transform ground;
    public Transform positionObject;
    public float SpawnItemTime = 5;
    private float _time = 0;
    private int _itemCount = 0;
    private int _itemIndex;
    private int _positionIndex;
    private float _sizeYGround;

    
    private void Awake() {
        ShaderGraphItems.onDestroyItem += (score) => _itemCount -= 1 ;
        TronItems.onDestroyTronItem += (score) => _itemCount -=1 ;
    }

    // Start is called before the first frame update
    void Start()
    {
        // sizeYGround =  ground.GetComponent<BoxCollider>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if(_time >= SpawnItemTime) 
        {
            SpawnItem();
            _time = 0;
        } 
    }

    private void SpawnItem() {
        if(_itemCount <  positionItems.Length) {
            _itemIndex = Random.Range(0,items.Length);
            int countLoop = 0;
            //so luong con 
            while(positionItems[_positionIndex].childCount >= 1 || countLoop <=  positionItems.Length ) {
                _positionIndex = Random.Range(0,positionItems.Length);
                countLoop++; 
            }

            GameObject itemSpawn = Instantiate(items[_itemIndex], positionItems[_positionIndex]);
            itemSpawn.transform.SetParent(positionItems[_positionIndex]);
            _itemCount++;
            // var itemSpawn = Instantiate(items[itemIndex], new Vector3(xPos, ground.position.y + sizeYGround + 0.3f, zPos), Quaternion.identity);
        }
    }
}
