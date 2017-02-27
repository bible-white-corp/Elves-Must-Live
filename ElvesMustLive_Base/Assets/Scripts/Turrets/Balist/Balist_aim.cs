using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balist_aim : MonoBehaviour 
{
	public int CrossDamage; //dommage subit par cible touchee
	public GameObject currentTarget; //cible actuelle
	Vector3 LastKnownPosition; //derniere position de la cible pour une eventuelle mise a jour de sa position
	Quaternion LookAtRotation; //rotation en cours de la cible
	Quaternion temp; //variable poubelle utilise comme intermediaire de modification de visee
	public float TurretSpeed; //vitesse de rotation de la tourelle
	Transform Child; //transform de l'enfant de la tourelle pour l'animation de rotation en x;
	float timebeforeshoot; //timer entre 2 tirs
	public float ReloadTime; // temps de rechargement
	public GameObject Carreau; //gameobject du carreau
	Health script; //script de vie des cibles touchees
	bool Engage; //bool de condition pour savoir si la baliste vise actuellement une cible
	public GameObject piercingParticules; //particules jouees quand des cibles sont atteintes

	void Start () 
	{
		LastKnownPosition = Vector3.zero;
		timebeforeshoot = 0f;
		Engage = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentTarget != null) 
		{
			if (currentTarget.transform.position != LastKnownPosition) 
			{ //si la cible a bougee
				LastKnownPosition = currentTarget.transform.position; 
				//on recupere la nouvelle position
				LookAtRotation = Quaternion.LookRotation (LastKnownPosition - transform.position);
				//on regarde le changement de direction
			}
			if (transform.rotation != LookAtRotation) 
			{
				//si la cible a change d'orientation
				temp = transform.rotation;
				temp[1] = LookAtRotation.y;
				//on utilise temp pour pouvoir modifier uniquement le regard de la baliste en y
				transform.rotation = Quaternion.RotateTowards(transform.rotation,temp,TurretSpeed* Time.deltaTime);
				//on cree la rotation progressive en y de la tourelle grace a cette commande
				transform.GetChild (0).rotation = new Quaternion (LookAtRotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);  
				//on modifie l'orientation du crossbow en x
				//il est important que les commandes soient effectuees dans cette ordre pour les chgt d'orientation
			}
			timebeforeshoot += Time.deltaTime;
			//on met a jour le timer entre les tirs
			if (timebeforeshoot > ReloadTime) 
			{
				//si le temps de rechargement est atteint...
				Shoot (transform.GetChild (1));
				//on engage le tir, depuis l'objet vide au niveau de la sortie physique de la baliste
				timebeforeshoot = 0f;
				//et on reinitialise le timer de tirs
			}
		}
			
	}
	void OnTriggerEnter(Collider coll)
	{
		if (Engage == false && coll.tag == "Shootable") 
		{
			//si la baliste n'a pas de cible et qu'un ennemi arrive a sa portee, on engage
			currentTarget = coll.gameObject;
			LastKnownPosition = currentTarget.transform.position;
			script = coll.GetComponent<Health> ();
			Engage = true;
		}
	}
	void OnTriggerStay(Collider coll)
	{
		if (Engage==false && coll.tag == "Shootable") 
		{
			//si la baliste en a fini avec un ennemi et qu'un autre est a portee
			currentTarget = coll.gameObject;
			LastKnownPosition = currentTarget.transform.position;
			script = coll.GetComponent<Health> ();
			Engage = true;
		}
		if (Engage && script.health <= 0) 
		{
			//si la cible est morte, on desengage
			currentTarget = null;
			Engage = false;
		}
	}
	void OnTriggerExit(Collider coll)
	{
		if (coll.gameObject == currentTarget) 
		{
			//si la cible passe hors de portee, on desengage
			currentTarget = null;
			Engage = false;
		}
	}
	void Shoot(Transform hole)
	{
		//on cree le carreau tiré
		GameObject Shoot = Instantiate (Carreau,hole.position,hole.rotation) as GameObject;
		Shoot.GetComponent<Rigidbody> ().AddForce (hole.forward * 1500);
		//on lui attribue une force de mouvement
		Shoot.AddComponent<Collision_Pierce> ();
		//on attribue au carreau le script de collision
		Shoot.GetComponent<Collision_Pierce> ().SetPiercing (piercingParticules);
		//on attribue au script de collision les particules a emettre lors de la collision
		Shoot.GetComponent<Collision_Pierce> ().SetDamage (CrossDamage);
	}
}
