using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class MainMenuLogic : MonoBehaviour
{
    [Range(0, 1)] public float turnAngle = 0.2f;
    public Volume postProcessingVolume;
    public List<GameObject> otherUIs;
    private GameObject thisUI;
    private Camera mainCamera;
    private Camera menuCamera;
    private DepthOfField dof;
    private float initialFocusDistance;

    private void OnEnable()
    {
        // Disable the other UIs and find the current one
        foreach (GameObject uiObject in otherUIs)
        {
            uiObject.SetActive(false);
        }

        thisUI = GameObject.Find("MainMenuUI");

        // Find the two cameras and assign them
        Camera[] cameras = Camera.allCameras;
        if (cameras[0].name.Equals("Main Camera"))
        {
            mainCamera = cameras[0];
            menuCamera = cameras[1];
        }
        else
        {
            mainCamera = cameras[1];
            menuCamera = cameras[0];
        }

        mainCamera.enabled = false;
        menuCamera.enabled = true;

        // TODO Find the volume instead of assigning it in the editor
        // and modify it to add blur 
        postProcessingVolume.profile.TryGet(out dof);
        initialFocusDistance = dof.focusDistance.value;
        dof.focusDistance.value = 5;

        // Find the UI elements and initialize them
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button playButton = root.Q<Button>("PlayButton");
        Button exitButton = root.Q<Button>("ExitButton");
        playButton.clicked += StartGame;
        exitButton.clicked += Suicide;
    }

    private void FixedUpdate()
    {
        menuCamera.transform.RotateAround(new Vector3(20, 0, 0), Vector3.up, turnAngle);
    }

    private void StartGame()
    {
        // SceneManager.LoadScene("GameScene");
        menuCamera.enabled = false;
        mainCamera.enabled = true;
        thisUI.SetActive(false);
        GlobalVariables.currentTime = 12;
        foreach (GameObject uiObject in otherUIs)
        {
            uiObject.SetActive(true);
        }

        dof.focusDistance.value = initialFocusDistance;
    }

    public static void Suicide()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(0);
        #endif
        // Environment.Exit(0);
    }
}