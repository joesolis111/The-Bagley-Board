using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour {
  private Button _mainMenuButton;

  private UIDocument _uidoc;

  public void Awake() {
    _uidoc = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<UIDocument>();

    _mainMenuButton = _uidoc.rootVisualElement.Q<Button>("mainMenuButton");
  }

  public void OnEnable() {
    _mainMenuButton.RegisterCallback<ClickEvent>(LoadScene);
  }

  public void OnDisable() {
    _mainMenuButton.UnregisterCallback<ClickEvent>(LoadScene);
  }

  public void LoadScene(ClickEvent e) {
    SceneManager.LoadScene("MainGame");
  }
}