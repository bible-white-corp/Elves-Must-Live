using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

    Vector3 desti;
    RaycastHit hit;
	GameObject prerendu;
    //GameObject prospect;
	bool initiatable;
	Color OKcolor;
	Color WRONGColor;
	Material[] materials;
	SphereCollider sphere;
	bool placable;
	PlayerControl script;
	bool NearGround;
	Vector3 temp;
	GameObject tempProspect;
	//Prerenducollision script2;
	float i;

	void Start () 
	{
		script = GetComponentInParent<PlayerControl> ();
		placable = true;
		initiatable = true;
		OKcolor = new Color (0, 255, 0);
		WRONGColor = new Color (255, 0, 0);
		NearGround = true;
	}
	

	void LateUpdate () 
	{
		if (!initiatable) 
		{
			Cast ();
		}
    }

	public void SetObj(GameObject build)
	{
		this.prerendu = build;
	}
	public void SetObjPropect (GameObject prospect)
	{
		if (initiatable) 
		{
			//this.prospect = prospect;
			initiatable = false;
			if (true) 
			{
				tempProspect= Instantiate (prospect,transform.position, new Quaternion(0,0,0,0),transform);
				//script2 = tempProspect.GetComponent<Prerenducollision> ();
				tempProspect.transform.localRotation = Quaternion.Euler (new Vector3 (0, 180, 0));
				i = tempProspect.transform.localRotation.y;

				//materials = prerendu.GetComponentsInChildren<Material>();
			} 
			else 
			{
				//initiatable = true;
				//eventuellement, message d'erreur par la suite
			}
		}
	}

    public void Cast()
    {
		
		if (placable && NearGround) 
		{
			foreach (Renderer rend in gameObject.GetComponentsInChildren<Renderer>()) 
			{
				rend.material.color = OKcolor;
			}
		}
		else 
		{
			foreach (Renderer rend in gameObject.GetComponentsInChildren<Renderer>()) 
			{
				rend.material.color = WRONGColor;
			}
		}
	}

	public void Confirm ()
	{
		if (placable && NearGround )
		{
            // Pour que le master client soit le propriétaire, et pas que les tourelles dépop quand on se déco.
            script.view.RPC("PlaceTurret", PhotonTargets.MasterClient, prerendu.name, gameObject.transform.position, tempProspect.transform.rotation);
			//PhotonNetwork.InstantiateSceneObject(prerendu.name, gameObject.transform.position, tempProspect.transform.rotation,0, new object[] { });
			Destroy (tempProspect);
			initiatable = true;
		} 
		else
		{
			script.TurretBuildFailed ();
		}
	}
	public void IsPlacable(bool placable)
	{
		this.placable = placable;
	}
	public void IsGrounded(bool grounded)
	{
		this.NearGround = grounded;
	}
	public void RightRotate()
	{
		i += 5;
		tempProspect.transform.localRotation = Quaternion.Euler (new Vector3 (0, i, 0));
	}
	public void LeftRotate()
	{
		i -= 5;
		tempProspect.transform.localRotation = Quaternion.Euler (new Vector3 (0, i, 0));
	}
	public void Cancel()
	{
		if (!initiatable)
		{
		Destroy (tempProspect);
		initiatable = true;
		}
	}
}