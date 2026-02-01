using UnityEngine;
using System.Collections;

public class diceRoll : MonoBehaviour {

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


private void Update() {
    if (Input.GetMouseButtonDown(0)) {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject) {
            Debug.Log("Clicked on the GameObject.");
        }
    }
}



private void OnMouseDown(){
    Debug.Log("The Dice was clicked!");

    if (!GameControl.gameOver && coroutineAllowed)
    {
        Debug.Log("Conditions met: Starting Coroutine...");
        StartCoroutine("RollTheDice"); 
    }
    else
    {
        Debug.Log("Click ignored. GameOver: " + GameControl.gameOver + ", CoroutineAllowed: " + coroutineAllowed);
    }
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
