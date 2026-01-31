using UnityEngine;

namespace BinaryAdd {
  public class Player : MonoBehaviour {
    [SerializeField]
    private int playerNumber;

    private AdditionManager _manager;


    public void Awake() {
      _manager = GameObject.FindGameObjectWithTag("AdditionManager").GetComponent<AdditionManager>();
    }

    public void ReadAnswer(string answer) {
      _manager.processAnswer(answer, playerNumber);
    }
  }
}