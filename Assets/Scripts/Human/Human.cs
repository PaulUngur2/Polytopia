using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public static int idHuman = 0;
    public int id;
    public bool housingStatus;

    private void Awake()
    {
        mainCamera = FindObjectOfType<Camera> ();
    }
    
    
    private void Start()
    {
        available = true;
        id = ++idHuman;
        housingStatus = false;
        
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
        
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent = agent == null ? gameObject.AddComponent<UnityEngine.AI.NavMeshAgent>() : agent;
        agent.stoppingDistance = stoppingDistance;
        
        GlobalVariables.humans.Add(this);
    }
    
    
    public void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
}