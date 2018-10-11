using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    public PlayerWeapon weapon;

    private const string PLAYER_TAG = "Player";
	
	void Start ()
    {
		if(cam == null)
        {
            Debug.LogError("No camera reference!");
            this.enabled = false;
        }
	}
	
	
	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}


    [Client]
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask))
        {
            Debug.Log("You hit: " + hit.collider.name);
            if(hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShoot(hit.collider.name);
            }
        }
    }

    [Command]
    void CmdPlayerShoot(string ID)
    {
        Debug.Log(ID + " has been shoot");
    }
}
