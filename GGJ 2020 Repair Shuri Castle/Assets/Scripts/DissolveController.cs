using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public bool isDissolving;
    public float dissolveAmount;
    public float dissolveSpeed=1;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        dissolveSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isDissolving = true;
        }

        if (isDissolving) {
            if (dissolveAmount > 0) { 
                dissolveAmount -= Time.deltaTime * dissolveSpeed;
            } else {
                isDissolving = false;
            }
        }

        if (!isDissolving) {
            if (dissolveAmount < 1) {
                dissolveAmount += Time.deltaTime * dissolveSpeed;
            } else {
                isDissolving = true;
            }
        }

        material.SetFloat("_DissolveAmount", dissolveAmount);
    }
}
