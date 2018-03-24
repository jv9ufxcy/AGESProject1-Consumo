using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask sumoMask;
    [SerializeField] private float shoveRadius = 1f;
    [SerializeField] private AudioSource bounceAudio;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        // Find all the sumos in an area around the front and push them.
        Collider[] colliders = Physics.OverlapSphere(transform.position, shoveRadius, sumoMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            PlayerController targetPlayer = colliders[i].GetComponent<PlayerController>();
            if (!targetPlayer)
                continue;
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;

            targetPlayer.Knockback(hitDirection);
        }

        bounceAudio.Play();
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag=="Player")
    //    {
    //        Vector3 hitDirection = other.transform.position - transform.position;
    //        hitDirection = hitDirection.normalized;

    //        FindObjectOfType<HealthManager>().HurtPlayer(hitDirection);
    //    }
    //}
}
