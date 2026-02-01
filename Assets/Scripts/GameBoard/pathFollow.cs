using UnityEngine;

public class pathFollow : MonoBehaviour	{
    public Transform[] waypoints;
    
    [SerializeField]
    private float moveSpeed = 5f;
    public int waypointIndex = 0;
    public bool moveAllowed = false;
    
    private void Start() {
    	transform.position = waypoints[waypointIndex].transform.position;
    }
    
    public void FixedUpdate() {
    	if (moveAllowed)
    	    Move();
    }
    
    private void Move(){
    	transform.position = Vector2.MoveTowards(transform.position, 
    	waypoints[waypointIndex].transform.position,
    	moveSpeed * Time.deltaTime);
    	   	
    	if (transform.position == waypoints[waypointIndex].transform.position){
    	    waypointIndex += 1;
    	    
    	    if (waypointIndex == waypoints.Length){
    	    	waypointIndex = 0;
    	    }
    	}
   
    	
    }
}

