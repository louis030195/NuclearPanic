using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider))]
public class ButtonController : MonoBehaviour
{
    private Vector3 startingPosition;
    private Renderer myRenderer;
    private TextMesh textMesh;

    public Material inactiveMaterial;
    public Material gazedAtMaterial;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        textMesh = GetComponent<TextMesh>();

        SetGazedAt(false);

    }



    public void SetGazedAt(bool gazedAt)
    {
        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
    }





}

