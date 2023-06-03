using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Human : MonoBehaviour
{
    public float stoppingDistance = 1f;
    private Renderer render;
    public UnityEngine.AI.NavMeshAgent agent;
    private Camera mainCamera;
    private Material[] materials;
    private Color[] HairColors;
    private Vector3 startDestination;
    private Vector3 endDestination;
    public bool available { get; set; }

    void Awake()
    {
        mainCamera = FindObjectOfType<Camera> ();
    }
    void Start()
    {
        available = true;
        render = GetComponent<Renderer>();
        Material[] materials = render.materials;
        materials[0].color = Random.ColorHSV();
        materials[1].color = Color.Lerp(new Color(46f/255f, 25f/255f, 3f/255f), new Color(235f/255f, 192f/255f, 148f/255f), Random.Range(0f, 1f));
        materials[2].color = Random.ColorHSV();
        materials[3].color = Random.ColorHSV();
        HairColors = new Color[]{
            Color.Lerp(new Color(0f/255f, 0f/255f, 0f/255f), new Color(255f/255f, 255f/255f, 255f/255f), Random.Range(0f, 1f)),
            Color.Lerp(new Color(0f/255f, 0f/255f, 0f/255f), new Color(255f/255f, 119f/255f, 0f/255f), Random.Range(0f, 1f)),
            Color.Lerp(new Color(255f/255f, 217f/255f, 0f/255f), new Color(255f/255f, 236f/255f, 160f/255f), Random.Range(0f, 1f)),
        };
        materials[4].color = HairColors[Random.Range(0, HairColors.Length)];
        GlobalVariables.Humans.Add(this);
    }

    /*void Update()
    {
        setDestination();
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Vector3.Distance(agent.transform.position, hit.point) < stoppingDistance)
            {
                agent.isStopped = true;
            }
        }
    }*/

    /*public void OnMouseDown()
    {
        if (!selected)
        {
            selecting();
        }
            else
            {
                unselecting();
            }
        
    }*/
    
    public void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
    
    
    /*public void unselecting()
    {
        selected = false;
        materials = render.materials;
        foreach (Material material in materials)
        {
            // Restore the original color of the material
            Color originalColor = material.GetColor("_OriginalColor");
            material.color = originalColor;
        }
        GlobalVariables.selectedHumans.Remove(this);
    }

    public void selecting()
    {
        selected = true;
        materials = render.materials;
        foreach (Material material in materials)
        {
            // Store the original color of the material
            material.SetColor("_OriginalColor", material.color);
                
            // Make the material redder
            Color newColor = material.color + new Color(0.2f, 0f, 0f);
            material.color = newColor;
        }
        GlobalVariables.selectedHumans.Add(this);
    }*/
}