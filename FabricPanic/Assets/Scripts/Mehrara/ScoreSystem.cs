using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public GameObject basket;
    private FabricDrop fabricDrop;
    void Start()
    {
        fabricDrop = basket.GetComponent<FabricDrop>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = fabricDrop.score.ToString();
    }
}
