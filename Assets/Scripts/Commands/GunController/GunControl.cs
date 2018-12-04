using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
	private GunType type;
	private float bulletSpeed, reloadTime, range;
	private int magCap, maxMagCap;
	[SerializeField]private GameObject bulletPrefab;

	void Start () {
		if (gameObject.name.Contains ("Pistol"))
			type = GunType.PISTOL;
		else if (gameObject.name.Contains ("AK47"))
			type = GunType.AK47;
		else if (gameObject.name.Contains ("RPG"))
			type = GunType.RPG;
		else
			type = GunType.PISTOL;
		GunSettings.SetGunSettings (type);
		SetLocalGunDetails ();
	}

	void Update () {
		RotateGun ();
		if (Input.GetMouseButtonDown (0))
			Shoot ();
	}

	private void SetLocalGunDetails(){
		bulletSpeed = Gun.bulletSpeed;
		reloadTime = Gun.reloadTime;
		range = Gun.range;
		magCap = Gun.magCap;
		maxMagCap = Gun.maxMagCap;
	}

	private void Shoot(){
		CreateBullet ();
	}

	private void CreateBullet(){
		GameObject o = Instantiate (bulletPrefab, transform.GetChild (0).position, transform.rotation);
		Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		if (GlobalScr.flipped && dir.x < 0 ) {
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			o.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		}
		if (dir.x < 0 && !GlobalScr.flipped) {
			dir = Vector3.up;
		} else if (dir.x > 0 && GlobalScr.flipped) {
			o.transform.rotation = Quaternion.AngleAxis (90f, Vector3.forward);
			dir = Vector3.up;
		}
		o.GetComponent<Rigidbody2D> ().velocity = dir.normalized * bulletSpeed;
		Destroy (o, 4f);
	}

	private void RotateGun(){
		Vector3 dir;
		float angle = 0;
		if (GlobalScr.flipped){
			dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
			angle = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
			if ((angle * -1)<=90 && (angle * -1)>=0)
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			return;
		}
		dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		if(angle<=90 && angle>=0)
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
