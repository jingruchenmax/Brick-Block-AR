using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlaygroundSetting : MonoBehaviour
{
    BoxCollider boxCollider;
    
    bool boxColliderEnable = false;
    // Start is called before the first frame update
public void toggleBoxCollider()
    {
        boxColliderEnable = !boxColliderEnable;
        boxCollider.enabled = boxColliderEnable;
    }

    // Update is called once per frame
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
}
