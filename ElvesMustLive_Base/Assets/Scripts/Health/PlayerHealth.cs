using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

public class PlayerHealth : MonoBehaviour {
    public float health = 30;
    public float maxhealth = 30;
    public GameObject Slider;
    private Slider healthSlider;
	public float sinkspeed = 10f;
    Animator anim;
    public bool IsDead;
    Rigidbody body;
	float TimerbeforeDeath;
	bool IsSinking;

    PlayerControl home;
    
    // Use this for initialization
    void Start ()
	{
        home = GetComponentInParent<PlayerControl>();
        healthSlider = Slider.GetComponent<Slider>();
        anim = home.anim;
		TimerbeforeDeath = 0;
    }

    public float barDisplay;
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(105, 20);
    public Texture2D emptyTex;
    public Texture2D fullTex;
    

    void OnGUI()
    {
        barDisplay = health / maxhealth;
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    // Update is called once per frame
    void Update () 
	{
        if (Input.GetKeyDown(KeyCode.H))
        {
            health = maxhealth;
        }
	}
	void FixedUpdate()
	{
		if (IsSinking)
		{
			TimerbeforeDeath += Time.deltaTime;
			if (TimerbeforeDeath > 2.5f) 
			{
				// c'est le machin qui fait fondre l'ennemi
				transform.Translate (Vector3.down * sinkspeed * Time.deltaTime);
			}
		}
	}

    public void TakeDamage(int amount)
    {
        if (IsDead)
        {
            return;
        }
        health -= amount;
        healthSlider.value = health;

        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        home.camscript.m_Target = null;
		IsSinking = true;
        IsDead = true;
        anim.SetTrigger("Died");
        GetComponent<Rigidbody>().isKinematic = true;
        // A faire qu'une fois donc demande pas tant de ressources...
        Destroy(GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>());
        Destroy(GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>());
        
        Destroy(gameObject, 4f);
    }
        
}
