using UnityEngine;
using UnityEngine.InputSystem;

namespace DiningPhilosophers {
  
  public class Controller : MonoBehaviour {
    [SerializeField]
    private InputActionReference takeLeftForkAction;
    [SerializeField]
    private InputActionReference takeRightForkAction;
    [SerializeField] 
    private InputActionReference changeToPhilosopher1Action;
    [SerializeField]
    private InputActionReference changeTPhilosopher2Action;
    [SerializeField]
    private GameObject _philosopher1;
    [SerializeField]
    private GameObject _philosopher2;
    
    private Philosopher _philosopher1Script;
    private Philosopher _philosopher2Script;
    private bool _isPhilosopher1 = true;

    public void Awake() {
      _philosopher1Script = _philosopher1.GetComponent<Philosopher>();
      _philosopher2Script = _philosopher2.GetComponent<Philosopher>();
    }
    
    private void OnEnable() {
      takeLeftForkAction.action.Enable();
      takeRightForkAction.action.Enable();
      changeToPhilosopher1Action.action.Enable();
      changeTPhilosopher2Action.action.Enable();

      takeLeftForkAction.action.started += TakeLeftFork;
      takeRightForkAction.action.started += TakeRightFork;
      changeToPhilosopher1Action.action.started += ChangeToPhilosopher1;
      changeTPhilosopher2Action.action.started += ChangeToPhilosopher2;
    }

    private void OnDisable() {
      takeLeftForkAction.action.Disable();
      takeRightForkAction.action.Disable();
      changeToPhilosopher1Action.action.Disable();
      changeTPhilosopher2Action.action.Disable();

      takeLeftForkAction.action.started -= TakeLeftFork;
      takeRightForkAction.action.started -= TakeRightFork;
      changeToPhilosopher1Action.action.started -= ChangeToPhilosopher1;
      changeTPhilosopher2Action.action.started -= ChangeToPhilosopher2;
    }

    private void TakeLeftFork(InputAction.CallbackContext context) {
      if (_isPhilosopher1) {
        _philosopher1Script.TakeLeftFork();
      }
      else {
        _philosopher2Script.TakeLeftFork();
      }
    }

    private void TakeRightFork(InputAction.CallbackContext context) {
      if (_isPhilosopher1) {
        _philosopher1Script.TakeRightFork();
      }
      else {
        _philosopher2Script.TakeRightFork();
      }
    }
    
    private void ChangeToPhilosopher1(InputAction.CallbackContext context) {
      _isPhilosopher1 = true;
    }

    private void ChangeToPhilosopher2(InputAction.CallbackContext context) {
      _isPhilosopher1 = false;
    }
  }
}