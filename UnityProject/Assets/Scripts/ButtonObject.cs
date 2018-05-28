using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : MonoBehaviour {
    bool status;
    public Material activMat;
    public Material inactivMat;
    private Renderer myRenderer;
    // Use this for initialization
    void Start () {
        status = false;
        myRenderer = GetComponent<Renderer>();
        myRenderer.material = activMat;
    }
	
	// Update is called once per frame
	void Update () {
		if (status){
            myRenderer.material = activMat;
        }
        else{
            myRenderer.material = inactivMat;
        }
	}

    public void SetActive()
    {
        if (!status)
        {
            status = true;
        }
    }

    public void setInactive()
    {
        if (status)
        {
            status = false;
            GameObject.Find("GameManager").GetComponent<GameManager>().setInactive(this.gameObject);
        }
    }

    public void sayCoucou()
    {
        Debug.Log("coucou");
    }
}
