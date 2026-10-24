using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
  [SerializeField] int PlayerLives=3;
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
  public void ProcessPlayerDeath()
  {
    if(PlayerLives > 1)
    {
      TaleLife();
    }
    else
    {
      ResetGameSession();
    }
  }

   void TaleLife()
  {
   PlayerLives-- ;
   int currentSceneIndex= SceneManager.GetActiveScene().buildIndex;
   SceneManager.LoadScene(currentSceneIndex);
  }

  void ResetGameSession()
  {
    SceneManager.LoadScene(0);
    Destroy(gameObject);
  }

  void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
