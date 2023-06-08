using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOverLogic : MonoBehaviour
{
    private static GameObject thisGameObject;
    void Start()
    {
        thisGameObject = gameObject;
        gameObject.SetActive(false);
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button retryButton = root.Q<Button>("RetryButton");
        Button exitButton = root.Q<Button>("ExitButton");
        retryButton.clicked += RestartGame;
        exitButton.clicked += MainMenuLogic.Suicide;
    }

    private void RestartGame()
    {
        throw new NotImplementedException();
    }
    
    public static void DisplayGameOverScreen()
    {
        thisGameObject.SetActive(true);
    }
}
