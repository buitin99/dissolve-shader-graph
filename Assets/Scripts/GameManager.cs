using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // public UnityEvent onDestroyItem;
    public Text currentScore;
    private static GameManager _instance = null;
    private int _score = 0;
    public static GameManager Instance {
        get {
            if(_instance == null) 
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                if(_instance == null) {
                    GameObject gameMaganer = new GameObject("GameManager");
                    _instance = gameMaganer.AddComponent<GameManager>();

                    DontDestroyOnLoad(gameMaganer);
                }
            }
            return _instance;
        }
    }


    void Awake() {
        if(_instance == null)
        {
            _instance = this;
			DontDestroyOnLoad(this.gameObject);
		}else
		{
			Destroy(gameObject);
		}

        Items.onTrigger += UpdateDestroyItem;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDestroyItem(int score)
    {
        if (currentScore != null)
        {
            this._score += score;
            currentScore.text = "Score: " + _score; 
        }
        // onDestroyItem?.Invoke();      
    }
}
