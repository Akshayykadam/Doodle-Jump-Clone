using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public TMPro.TMP_Text TopScore;
    // Start is called before the first frame update
    void Start()
    {
        TopScore.text = " Top Score : " + PlayerPrefs.GetFloat("TopScore");
    }

    
}
