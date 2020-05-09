using System.Collections.Generic;
using UnityEngine;

public class BoxObjectPool : MonoBehaviour
{
    public static BoxObjectPool current;

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
            Indicator box = Instantiate(pooledObject);
            box.transform.SetParent(transform, false);
            box.Activate(false);
            pooledObjects.Add(box);
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
            Indicator box = Instantiate(pooledObject);
            box.transform.SetParent(transform, false);
            box.Activate(false);
            pooledObjects.Add(box);
            return box;
        }
        return null;
    }

    public void DeactivateAllPooledObjects()
    {
        foreach (Indicator box in pooledObjects)
        {
            box.Activate(false);
        }
    }
}
