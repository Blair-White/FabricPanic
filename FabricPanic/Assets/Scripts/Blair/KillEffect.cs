using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEffect : MonoBehaviour
{
    private float count;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps.GetComponent<ParticleSystem>().Simulate(15);
        ps.GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > 1) Destroy(this.gameObject);
    }


    public void MovePS()
    {

    }
}
