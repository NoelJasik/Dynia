using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterX : MonoBehaviour
{
    [SerializeField]
    float existanceTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, existanceTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
