using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    SkinnedMeshRenderer meshRenderer;
    //MeshRenderer meshRenderer;
    Material normalMaterial;
    public Material RadarMaterial;
    public Transform playerTransform;
    bool radarActive = false;
    private Image radar;

    void Start()
    {
       radar = GameObject.FindGameObjectWithTag("Radar Button").GetComponent<Image>();

        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        normalMaterial = meshRenderer.material;
    
    }

    void Update()
    {
       
        
      

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (radarActive == false)
            {
                meshRenderer.material = RadarMaterial;
                radarActive = true;
                Debug.Log("Radar Activated");
                radar.color = new Color(1f, 1f, 1f, 1f);
           
            }
            else if (radarActive == true)
            {
                meshRenderer.material = normalMaterial;
                radarActive = false;
                Debug.Log("Radar Deactivated");
                radar.color = new Color(1f, 1f, 1f, 1 * 0.5f);

            }
            
        }
        
    }
}
