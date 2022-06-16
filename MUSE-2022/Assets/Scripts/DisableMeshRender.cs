using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMeshRender : MonoBehaviour
{
    void Awake()
    {
        MeshRenderer _mesh = this.gameObject.GetComponent<MeshRenderer>();
        _mesh.enabled = false;
    }
}
