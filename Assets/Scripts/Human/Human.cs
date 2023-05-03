using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private bool selected;
    private Transform destination;
    private Renderer renderer;
    public UnityEngine.AI.NavMeshAgent agent;
    private Camera mainCamera;
    void Awake()
    {
        mainCamera = FindObjectOfType<Camera> ();
    }
    void Start()
    {
        selected = false;
        renderer = GetComponent<Renderer>();
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
                renderer.material.color = Color.red;
                GlobalVariables.selectedHumans.Add(this);
            } else if (selected)
            {
                selected = false;
                renderer.material.color = Color.white;
                GlobalVariables.selectedHumans.Remove(this);
            }
        }
    }
}