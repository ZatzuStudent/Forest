using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialScript : MonoBehaviour
{
    public GameObject targetObject;
    public float visibilityRange = 5f;


    private void Start()
    {

    }

    private void Update()
    {
    GameObject player  = GameObject.FindGameObjectWithTag("Player");
    float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance <= visibilityRange)
            {
                targetObject.SetActive(true);
            }
            else
            {
                targetObject.SetActive(false);
            }
        }
    }