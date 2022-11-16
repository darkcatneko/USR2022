using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : MonoBehaviour
{
    Dictionary<string, Queue<GameObject>> Pool = new Dictionary<string, Queue<GameObject>>();

    void AddIfNotContain(string tag)
    {
        if (!Pool.ContainsKey(tag))
        {
            Pool.Add(tag, new Queue<GameObject>());
        }
    }

    public void Prefab(GameObject prefabObj, int prefabCount)
    {
        AddIfNotContain(prefabObj.tag);

        for(int i = 0; i < prefabCount; i++)
        {
            GameObject GenObj = Instantiate(prefabObj);
            GenObj.SetActive(false);
            Pool[prefabObj.tag].Enqueue(GenObj);
        }
    }

    public void Use(GameObject useObj, Vector3 pos, Quaternion rot)
    {
        AddIfNotContain(useObj.tag);

        if (Pool[useObj.tag].Count < 1)
        {
            Instantiate(useObj, pos, rot);
        }
        else
        {
            GameObject usingObj = Pool[useObj.tag].Dequeue();
            usingObj.transform.position = pos;
            usingObj.transform.rotation = rot;
            usingObj.SetActive(true);
        }
    }

    public void Recycle(GameObject recycleObj)
    {
        AddIfNotContain(recycleObj.tag);

        recycleObj.SetActive(false);
        Pool[recycleObj.tag].Enqueue(recycleObj);
    }
}
