using UnityEngine;

public static class Gun{
	public static float bulletSpeed;
	public static int magCap;
	public static int maxMagCap;
	public static float reloadTime;
	public static float range;

	public static void SetDetails(float bs,int mc,int mmc, float rt,float r){
		bulletSpeed = bs;
		mc = magCap;
		maxMagCap = mmc;
		reloadTime = rt;
		range = r;
	}

}

public class GunSettings  {

	public static void SetGunSettings(GunType type){
		if (type == GunType.PISTOL)
			Gun.SetDetails (50f, 6, 120, 1f, 0);
		else if (type == GunType.AK47)
			Gun.SetDetails (100f, 30, 300, 2.2f, 0);
		else if (type == GunType.RPG)
			Gun.SetDetails (10f, 1, 10, 2f, 5f);
	}
}
