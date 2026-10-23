using UnityEngine;

public class GameSession : MonoBehaviour
{
  void Awake()
  {
    int numberGameSessions = FindObjectsByType<GameSession>(FindObjectsInactive.Exclude).Length;
    if(numberGameSessions > 1)
    {
      Destroy(gameObject);
      
    }
    else
    {
      DontDestroyOnLoad(gameObject);
    }
  }
   
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
