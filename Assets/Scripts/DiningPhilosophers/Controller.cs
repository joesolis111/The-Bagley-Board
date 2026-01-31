using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace DiningPhilosophers {
  public class Controller : MonoBehaviour {
    [SerializeField]
    private InputActionReference takeLeftForkAction;
    [SerializeField]
    private InputActionReference _takeRightForkAction;

    private void OnEnable() {
      takeLeftForkAction.action.Enable();
      _takeRightForkAction.action.Enable();

      takeLeftForkAction.action.started += TakeLeftFork;
      _takeRightForkAction.action.started += TakeRightFork;
    }

    private void OnDisable() {
      takeLeftForkAction.action.Disable();
      _takeRightForkAction.action.Disable();

      takeLeftForkAction.action.started -= TakeLeftFork;
      _takeRightForkAction.action.started -= TakeRightFork;
    }

    private void TakeLeftFork(InputAction.CallbackContext context) { }

    private void TakeRightFork(InputAction.CallbackContext context) { }
  }
}