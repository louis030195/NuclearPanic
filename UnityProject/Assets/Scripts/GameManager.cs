using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private List<GameObject> inactiveButons = new List<GameObject>();
    private List<GameObject> activeButon = new List<GameObject>();
    public Text textScore;
    public Text endText;
    private int score = 0;
    private bool isPlaying = false;
    private bool canAccelerate = true;
    private int index;
    public int nbMax = 10;
    public float deltaTime = 5;
    private float m_time = 0.0f;
    // Use this for initialization
    void Start () {
        this.endText.gameObject.SetActive(false);
        foreach (GameObject b in GameObject.FindGameObjectsWithTag("Buton"))
        {
            inactiveButons.Add(b);
        }
    }

    // Update is called once per frame
    void Update () {
        setScore();
        if (isPlaying)
        {
            if (activeButon.Count < nbMax)
            {
                m_time += Time.deltaTime;
                if (m_time > deltaTime && inactiveButons.Count != 0)
                {
                    index = Random.Range(0, inactiveButons.Count);
                    inactiveButons[index].GetComponent<ButtonObject>().SetActive();
                    activeButon.Add(inactiveButons[index]);
                    inactiveButons.Remove(inactiveButons[index]);
                    Debug.Log(inactiveButons.Count);
                    m_time = 0.0f;
                    canAccelerate = true;
                }
                if (score % 10 == 0 && deltaTime > 0.5f && score !=0 && canAccelerate == true)
                {
                    Debug.Log("sa accelaire");
                    canAccelerate = false;
                    deltaTime -= 0.5f;
                }
            }
            else
            {
                toggleIsPlaying();
                this.endText.gameObject.SetActive(true);             
            }
        }
        else
        {
            m_time += Time.deltaTime;
            if (m_time > 10)
            {
                toggleIsPlaying();
            }
        }
    }
    
    public void setInactive(GameObject inactB)
    {
        inactiveButons.Add(inactB);
        activeButon.Remove(inactB);
        score += 1;
    }

    public void setScore()
    {
        this.textScore.text = "Score : " + score.ToString();
    }

    public void toggleIsPlaying()
    {
        isPlaying = !isPlaying;
    }

    public void reset()
    {
        score = 0;
        deltaTime = 4f;
    }
}
