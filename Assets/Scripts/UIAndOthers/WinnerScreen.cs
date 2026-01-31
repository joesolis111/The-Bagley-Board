using System;
using UIAndOthers;
using UnityEngine;

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
   }
}
