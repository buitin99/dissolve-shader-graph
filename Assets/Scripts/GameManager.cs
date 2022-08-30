using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public UnityEvent onDestroyItem;
    public static GameManager Instance {
        get {
            if(instance == null) 
            {
                instance = GameObject.FindObjectOfType<GameManager>();
                if(instance == null) {
                    GameObject gameMaganer = new GameObject("GameManager");
                    instance = gameMaganer.AddComponent<GameManager>();

                    DontDestroyOnLoad(gameMaganer);
                }
            }
            return instance;
        }
    }


    void Awake() {
        if(instance == null)
        {
            instance = this;
			DontDestroyOnLoad(this.gameObject);
		}else
		{
			Destroy(gameObject);
		}
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDestroyItem()
    {
      onDestroyItem?.Invoke();      
    }
}
