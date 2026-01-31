using UnityEngine;
using System.Collections;

public class diceRoll : MonoBehaviour{

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;
    private GameControl gameControl;

    private void Start() {
        rend = GetComponent<SpriteRenderer>();
        //"Resources/board/dice/"
        diceSides = Resources.LoadAll<Sprite>("board/dice/");
        
        if (diceSides.Length > 0)
            rend.sprite = diceSides[5];

        gameControl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
    }


    private void OnMouseDown(){
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice"); 
    }

    private IEnumerator RollTheDice(){
        coroutineAllowed = false;
        int randomDiceSide = 0;

        for (int i = 0; i <= 20; i++){
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;
        
        if (whosTurn == 1){
            GameControl.MovePlayer(1);
        } else if (whosTurn == -1){
            GameControl.MovePlayer(2);
        }

        whosTurn *= -1;
        coroutineAllowed = true;
    }
}
