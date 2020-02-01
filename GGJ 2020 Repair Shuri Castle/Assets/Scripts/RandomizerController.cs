using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerController : MonoBehaviour
{
    //public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(MyCoroutine());

    }

    IEnumerator MyCoroutine() {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        foreach (var obj in GetComponentsInChildren(typeof(Renderer))) {
            obj.transform.localPosition = new Vector3(Random.Range(0, 40), 2, Random.Range(0, 20));
        }

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
