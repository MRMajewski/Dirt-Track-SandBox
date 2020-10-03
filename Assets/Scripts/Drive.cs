using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{

    public Rigidbody tire;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            tire.AddTorque(new Vector3(1, 0, 0) * speed);
        }
    }

    private void OnMouseDown()
    {
        tire.AddTorque(new Vector3(0, 1, 0) * speed);
    }
}
