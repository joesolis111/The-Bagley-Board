using TMPro;
using UnityEngine;

namespace BinaryAdd {
  
  public class Player : MonoBehaviour {

    private AdditionManager _manager;
    [SerializeField]
    private int playerNumber;
    
    
    public void Awake() {
      _manager = GameObject.FindGameObjectWithTag("AdditionManager").GetComponent<AdditionManager>();
    }

    public void ReadAnswer(string answer) {
      _manager.processAnswer(answer, playerNumber);
    }

  }
}