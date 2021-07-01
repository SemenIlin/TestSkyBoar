using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public T prefab { get; }
    public bool autoExpand { get; set; }

    public Transform container { get; }

    private List<T> pool;

    public PoolMono(T prefab, int count)
    {
        this.prefab = prefab;
        this.container = null;

        CreatePool(count);
    }

    public PoolMono(T prefab, int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;

        CreatePool(count);
    }

    public bool HasActiveElement()
    {
        foreach (var mono in pool)
        {
            if (mono.gameObject.activeInHierarchy)
            {                
                return true;
            }
        }

        return false;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var mono in pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                mono.gameObject.SetActive(true);
                element = mono;
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
        {
            return element;
        }

        if (autoExpand)
        {
            return CreateObject(true);
        }

        throw new System.Exception($"There is no free element in pool of type {typeof(T)}");
    }

    private void CreatePool(int count)
    {
        this.pool = new List<T>();

        for(int i = 0; i < count; ++i)
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createObject = Object.Instantiate(this.prefab, this.container);
        createObject.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createObject);

        return createObject;
    }

    public void SetAllDisactive()
    {
        foreach (var mono in pool)
        {
            if (mono.gameObject.activeInHierarchy)
            {
                mono.gameObject.SetActive(false);
            }
        }
    }
}
