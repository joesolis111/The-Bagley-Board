using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour {
  
  [SerializeField]
  private InputActionReference pauseAction;
  private Button unPauseButton;
  private Button mainMenuButton;
  
  private VisualElement root;
  private UIDocument _uiDocument;
  
  public void Awake() {
    _uiDocument = GetComponent<UIDocument>();
    
    root = _uiDocument.rootVisualElement.Q<VisualElement>("Box");
    
    root.visible = false;
    
    unPauseButton = _uiDocument.rootVisualElement.Q<Button>("unpause");
    mainMenuButton = _uiDocument.rootVisualElement.Q<Button>("mainMenu");
  }

  public void OnEnable() {
    pauseAction.action.Enable();

    pauseAction.action.performed += Pause;
    unPauseButton.RegisterCallback<ClickEvent>(UnPause);
    mainMenuButton.RegisterCallback<ClickEvent>(ReturnToMainMenu);
  }

  public void OnDisable() {
    pauseAction.action.Disable();
    
    pauseAction.action.performed -= Pause;
    unPauseButton.UnregisterCallback<ClickEvent>(UnPause);
    mainMenuButton.UnregisterCallback<ClickEvent>(ReturnToMainMenu);
  }

  public void ReturnToMainMenu(ClickEvent e) {
    SceneManager.LoadScene("MainMenu");
  }

  public void UnPause(ClickEvent e) {
    root.visible = false;
  }

  public void Pause(InputAction.CallbackContext context) {
    root.visible = true;
  }
}