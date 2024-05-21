using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnClick();
    }

    void OnClick () {
        if (!CameraInputs.instance.onFire) {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10000f, layerMask)) {
            hit.collider.gameObject.GetComponent<BuildingSlot>().SpawnNextHouse();
        }

        CameraInputs.instance.onFire = false;    
    }
}
