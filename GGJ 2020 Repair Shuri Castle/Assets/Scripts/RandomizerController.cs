using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rondomizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in GetComponentsInChildren(typeof(Renderer)))
        {
            obj.transform.localPosition = new Vector3(Random.Range(0, 10), 2, Random.Range(0, 10));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
