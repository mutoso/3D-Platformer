using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3((100 * Time.deltaTime) % 360, 0, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Player>().Score++;
        Destroy(gameObject);
    }
}
