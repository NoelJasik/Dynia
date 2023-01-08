using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    [SerializeField]
    Transform player;
    [SerializeField]
    float distanceToDeactivate = 100;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        pooledObjects = new List<GameObject>();
        // Starts from 1 to avoid adding the parent object as a pooled object
        for(int i = 1; i < allChildren.Length; i++)
        {
            pooledObjects.Add(allChildren[i].gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in pooledObjects)
        {
                if (Vector3.Distance(item.transform.position, player.position) > distanceToDeactivate)
                {
                    item.SetActive(false);
                } else
                {
                    item.SetActive(true);
                }
        }
    }
}
