using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;

    private static GameObject player1, player2;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gameOver = false;

    void Start () {

        whoWinsTextShadow = GameObject.Find("whoWinsText");
        player1MoveText = GameObject.Find("player1MoveText");
        player2MoveText = GameObject.Find("player2MoveText");

        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");

        player1.GetComponent<pathFollow>().moveAllowed = false;
        player2.GetComponent<pathFollow>().moveAllowed = false;

        whoWinsTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (gameOver) return;
        
        // Player 1 Logic
        if (player1.GetComponent<pathFollow>().waypointIndex > 
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<pathFollow>().moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<pathFollow>().waypointIndex - 1;
        }

        // Player 2 Logic
        if (player2.GetComponent<pathFollow>().waypointIndex > 
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<pathFollow>().moveAllowed = false;
            player2MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<pathFollow>().waypointIndex - 1;
        }

        // Win Condition Player 1
        if (player1.GetComponent<pathFollow>().waypointIndex == 
            player1.GetComponent<pathFollow>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
            gameOver = true;
        }

        // Win Condition Player 2
        if (player2.GetComponent<pathFollow>().waypointIndex == 
            player2.GetComponent<pathFollow>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
            gameOver = true;
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) {
            case 1:
                player1.GetComponent<pathFollow>().moveAllowed = true;
                break;

            case 2:
                player2.GetComponent<pathFollow>().moveAllowed = true;
                break;
        }
    }
}