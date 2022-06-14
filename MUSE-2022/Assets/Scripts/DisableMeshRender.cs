using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMeshRender : MonoBehaviour
{
    void Awake()
    {
        MeshRenderer mesh = this.gameObject.GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }
}
