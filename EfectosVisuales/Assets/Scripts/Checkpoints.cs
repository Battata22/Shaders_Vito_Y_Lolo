using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkpoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] float dead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -dead)
        {
            player.transform.position = vectorPoint;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        vectorPoint = player.transform.position;
        if (other.gameObject.layer != 9)
        {
            Destroy(other.gameObject);
        }
       
    }
}
