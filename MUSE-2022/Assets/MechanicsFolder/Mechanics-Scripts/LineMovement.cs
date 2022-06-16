using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{
    public GameObject _verticalOne;
    public GameObject _verticalTwo;

    public GameObject _horizontalOne;
    public GameObject _horizontalTwo;

    public Vector3 _hv;

    public float _n = 0f;
    public float _speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _n * (_verticalOne.transform.position - _verticalTwo.transform.position) + _verticalTwo.transform.position;

        _n += _speed;

        if(_n <= 0)
        {
            _speed = Mathf.Abs(_speed);
        }
        if(_n >= 1f)
        {
            _speed = -Mathf.Abs(_speed);
        }
    }
}
