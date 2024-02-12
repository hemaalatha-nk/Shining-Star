using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveStar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0,0,0) - transform.position;
        direction.Normalize(); // Normalize to move in the correct direction

        //transform.Translate(direction * speed * Time.deltaTime);
        gameObject.transform.Translate(direction * 0.01f * Time.deltaTime);

    }
}
