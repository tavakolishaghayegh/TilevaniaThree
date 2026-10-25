using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
  [SerializeField] int PlayerLives=3;
  [SerializeField] int Score=0;
  [SerializeField] TextMeshProUGUI LivesText;
  [SerializeField] TextMeshProUGUI ScoreText;
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
      LivesText.text=PlayerLives.ToString();
      ScoreText.text=Score.ToString();
        
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
  public void AddToScore(int pointsToAdd)
  {
    Score +=pointsToAdd; 
    ScoreText.text=Score.ToString();
    
  }

   void TaleLife()
  {
   PlayerLives-- ;
   int currentSceneIndex= SceneManager.GetActiveScene().buildIndex;
   SceneManager.LoadScene(currentSceneIndex);
   LivesText.text=PlayerLives.ToString();
  }

  void ResetGameSession()
  {
    FindAnyObjectByType<ScenePersist>().ResetScenePersist();
    SceneManager.LoadScene(0);
    Destroy(gameObject);
  }

  

    
   
}
