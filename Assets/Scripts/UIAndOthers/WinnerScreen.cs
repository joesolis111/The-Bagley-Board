using System.Collections;
using UIAndOthers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerScreen : MonoBehaviour {
   [SerializeField]
   private Sprite _spritePlayer1;
   [SerializeField]
   private Sprite _spritePlayer2;

   private int winnerPlayer;
   public void Awake() {
      winnerPlayer = StaticWinner.Winner;
      
      var winnerGameObject =  GameObject.FindWithTag("Winner");
      winnerGameObject.GetComponent<SpriteRenderer>().sprite = winnerPlayer == 1 ? _spritePlayer1 : _spritePlayer2;

      StartCoroutine(ReturnToMainGame());
   }

   public IEnumerator ReturnToMainGame() {
      yield return new WaitForSeconds(15);
      SceneManager.LoadScene("MainGame");
   }
}
