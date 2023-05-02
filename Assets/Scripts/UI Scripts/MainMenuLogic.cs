using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuLogic : MonoBehaviour
{
    private void OnEnable() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button playButton = root.Q<Button>("PlayButton");
        Button exitButton = root.Q<Button>("ExitButton");
     
        playButton.clicked += StartGame;
        exitButton.clicked += ExitGame;
    }
    
    private void StartGame() {
        SceneManager.LoadScene("GameScene");
    }
    
    private void ExitGame() {
        Application.Quit(0);
    }
}
