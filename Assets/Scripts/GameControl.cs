using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;
    private static GameObject player1, player2;

    // Cache the scripts here
    private static pathFollow p1Script, p2Script;

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

        // Cache the components once at the start
        if (player1 != null) p1Script = player1.GetComponent<pathFollow>();
        if (player2 != null) p2Script = player2.GetComponent<pathFollow>();

        if (p1Script != null) p1Script.moveAllowed = false;
        if (p2Script != null) p2Script.moveAllowed = false;

        whoWinsTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        // SAFETY CHECK: If the scripts are missing, stop running to avoid the error
        if (p1Script == null || p2Script == null) return;

        // Player 1 logic
        if (p1Script.waypointIndex > player1StartWaypoint + diceSideThrown)
        {
            p1Script.moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = p1Script.waypointIndex - 1;
        }

        // Player 2 logic
        if (p2Script.waypointIndex > player2StartWaypoint + diceSideThrown)
        {
            p2Script.moveAllowed = false;
            player2MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player2StartWaypoint = p2Script.waypointIndex - 1;
        }

        // Win Condition Checks
        CheckWinConditions();
    }

    void CheckWinConditions()
    {
        if (p1Script.waypointIndex == p1Script.waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
            gameOver = true;
        }

        if (p2Script.waypointIndex == p2Script.waypoints.Length)
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
        if (gameOver) return;

        switch (playerToMove) {
            case 1:
                if (p1Script != null) p1Script.moveAllowed = true;
                break;
            case 2:
                if (p2Script != null) p2Script.moveAllowed = true;
                break;
        }
    }
}