using System.Collections.Generic;
using UnityEngine;

class ArrowObjectPool : MonoBehaviour
{
    public static ArrowObjectPool current;

    public Indicator pooledObject;
    public int pooledAmount = 1;
    public bool willGrow = true;

    List<Indicator> pooledObjects;

    void Awake()
    {
        current = this;
    }

    void Start()
    {
        pooledObjects = new List<Indicator>();

        for (int i = 0; i < pooledAmount; i++)
        {
            Indicator arrow = Instantiate(pooledObject);
            arrow.transform.SetParent(transform, false);
            arrow.Activate(false);
            pooledObjects.Add(arrow);
        }
    }

    public Indicator GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].Active)
            {
                return pooledObjects[i];
            }
        }
        if (willGrow)
        {
            Indicator arrow = Instantiate(pooledObject);
            arrow.transform.SetParent(transform, false);
            arrow.Activate(false);
            pooledObjects.Add(arrow);
            return arrow;
        }
        return null;
    }

    public void DeactivateAllPooledObjects()
    {
        foreach (Indicator arrow in pooledObjects)
        {
            arrow.Activate(false);
        }
    }
}
