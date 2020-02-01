using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public bool isDissolving;
    public float dissolveAmount;
    public float dissolveSpeed;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isDissolving = true;
        }

        if (isDissolving && dissolveAmount > 0) {
            dissolveAmount -= Time.deltaTime * dissolveSpeed;
        }

        if (!isDissolving && dissolveAmount < 1) {
            dissolveAmount += Time.deltaTime * dissolveSpeed;
        }

        material.SetFloat("_DissolveAmount", dissolveAmount);
    }
}
