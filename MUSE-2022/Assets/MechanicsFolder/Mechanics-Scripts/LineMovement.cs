using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{
    public GameObject verticalOne;
    public GameObject verticalTwo;

    public GameObject horizontalOne;
    public GameObject horizontalTwo;

    public Vector3 hv;

    public float n = 0f;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = n * (verticalOne.transform.position - verticalTwo.transform.position) + verticalTwo.transform.position;

        n += speed;

        if(n <= 0)
        {
            speed = Mathf.Abs(speed);
        }
        if(n >= 1f)
        {
            speed = -Mathf.Abs(speed);
        }
    }
}
