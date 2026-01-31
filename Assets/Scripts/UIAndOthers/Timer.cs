using System.Collections;
using TMPro;
using UIAndOthers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

  [SerializeField]
  private int waitingTime;
  
  [SerializeField]
  private TextMeshProUGUI player1Score;
  [SerializeField]
  private TextMeshProUGUI player2Score;

  [SerializeField]
  private int scoreIndex;
  
  public void Awake() {
    StartCoroutine(ReturnToMainGame());
  }

  private IEnumerator ReturnToMainGame() {
    yield return new WaitForSeconds(waitingTime);
    
    int player1Scor = int.Parse(player1Score.text.Substring(scoreIndex));
    int player2Scor = int.Parse(player2Score.text.Substring(scoreIndex));
    
    StaticWinner.Winner = player1Scor > player2Scor ? 1 : 2;
    
    SceneManager.LoadScene("WinnerScreen");
  }
}