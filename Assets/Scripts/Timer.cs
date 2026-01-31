using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

  [SerializeField]
  private int waitingTime;
  public void Awake() {
    StartCoroutine(ReturnToMainGame());
  }

  private IEnumerator ReturnToMainGame() {
    yield return new WaitForSeconds(waitingTime);
    SceneManager.LoadScene("MainGame");
  }
}