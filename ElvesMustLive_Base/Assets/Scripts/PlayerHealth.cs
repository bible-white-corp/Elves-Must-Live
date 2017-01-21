using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int health = 30;
    Animator anim;
    bool IsDead;
    Rigidbody body;
    CapsuleCollider caps;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {
        if (IsDead)
        {
            return;
        }
        health -= amount;

        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        IsDead = true;
        anim.SetTrigger("Died");
        GetComponent<Rigidbody>().isKinematic = true;
        // Le joueur va pas mourir toutes les deux minutes, ca devrais pas poser de pb
        Destroy(GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>());
        Destroy(GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>());
        Destroy(gameObject, 4f);
    }
        
}
