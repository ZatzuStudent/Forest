using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EforFlora : MonoBehaviour
{
    public GameObject targetObject;
    public float visibilityRange = 5f;


    private void Start()
    {
        targetObject.SetActive(false);
    }

    private void Update()
    {
    GameObject player  = GameObject.FindGameObjectWithTag("Player");
    float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance > visibilityRange)
            {
                targetObject.SetActive(false);
            }
            else
            {
                targetObject.SetActive(true);
            }
        }
    }