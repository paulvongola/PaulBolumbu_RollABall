using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Explosion : MonoBehaviour
{
    public Transform explosionPrefab;

    

    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OK");

        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        Instantiate(explosionPrefab, position, rotation);
        /*yield return new WaitForSeconds(5);*/
        Destroy(gameObject);
        /*explosionPrefab.GetComponent<ParticleSystem>().Stop();*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Stop(ParticleSystemStopBehavior stopBehavior = ParticleSystemStopBehavior.StopEmitting)
    {

    }


}
