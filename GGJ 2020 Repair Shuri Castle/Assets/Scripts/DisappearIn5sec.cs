using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearIn5sec : MonoBehaviour
{    
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine() {
        yield return new WaitForSeconds(10);
 
        foreach (var obj in GetComponentsInChildren(typeof(Renderer))) {
            obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, -1000);
        }
    }
}
