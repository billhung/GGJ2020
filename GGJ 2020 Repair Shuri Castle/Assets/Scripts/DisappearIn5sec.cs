using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearIn5sec : MonoBehaviour
{    
    //private Renderer gameObj;
    //private GameObject gameObj;

    void Start()
    {
        StartCoroutine(MyCoroutine());
        //gameObj = this.GetComponent<Renderer>();
        //gameObj = this.GetComponent<GameObject>();
    }

    IEnumerator MyCoroutine() {
        yield return new WaitForSeconds(10);
        //gameObj.GetComponent<Renderer>().enabled = false;
        //gameObj.SetActive(false);

        //gameObj.transform.localPosition = new Vector3(0, -1000, 0);

        foreach (var obj in GetComponentsInChildren(typeof(Renderer))) {
            obj.transform.localPosition = new Vector3(0, -1000, 0);
        }
    }
}
