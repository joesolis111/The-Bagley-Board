using UnityEngine;

namespace DiningPhilosophers {
  public class Philosopher : MonoBehaviour {

    [SerializeField]
    private GameObject firstFork;
    [SerializeField]
    private GameObject secondFork;
    
    private Fork _leftForkScript;
    private Fork _rightForkScript;

    public void Awake() {
      _leftForkScript = firstFork.GetComponent<Fork>();
      _rightForkScript = secondFork.GetComponent<Fork>();
    }
    
    public void TakeLeftFork() {
      _leftForkScript.TakeFork();
    }

    public void TakeRightFork() {
      _rightForkScript.TakeFork();
    }

  }
}