using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private bool selected;
    private Renderer render;
    public UnityEngine.AI.NavMeshAgent agent;
    private Camera mainCamera;
    void Awake()
    {
        mainCamera = FindObjectOfType<Camera> ();
    }
    void Start()
    {
        selected = false;
        render = GetComponent<Renderer>();
        Material[] materials = render.materials;
    }

    void Update()
    {
        if (HumansControllerUI.setDestination && selected)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }

    public void OnMouseDown()
    {
        if (HumansControllerUI.selectHumans)
        {
            if (!selected)
            {
                selected = true;
                Material[] materials = render.materials;
                foreach (Material material in materials)
                {
                    // Store the original color of the material
                    material.SetColor("_OriginalColor", material.color);
                
                    // Make the material redder
                    Color newColor = material.color + new Color(0.2f, 0f, 0f);
                    material.color = newColor;
                }
                GlobalVariables.selectedHumans.Add(this);
            }
            else
            {
                selected = false;
                Material[] materials = render.materials;
                foreach (Material material in materials)
                {
                    // Restore the original color of the material
                    Color originalColor = material.GetColor("_OriginalColor");
                    material.color = originalColor;
                }
                GlobalVariables.selectedHumans.Remove(this);
            }
        }
    }



}