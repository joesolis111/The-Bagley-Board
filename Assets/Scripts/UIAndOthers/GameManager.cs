using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class GameManager : MonoBehaviour {
  
  public void Awake() {
    StartCoroutine(StartGame());
  }

  public IEnumerator StartGame() {
    yield return new WaitForSeconds(7);
    
    Random random = new Random();

    int rng = random.Next(0,1);

    if (rng == 0) {
      SceneManager.LoadScene("DiningPhilosophers");
    } else {
      SceneManager.LoadScene("BinaryAddition");
    }
  }
  
}