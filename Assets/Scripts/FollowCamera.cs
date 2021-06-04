using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;

        temp.y = playerTransform.position.y;


        transform.position = temp;
    }

    void LateUpdate()
    {
        

    }
}
