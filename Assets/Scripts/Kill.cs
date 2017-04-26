using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour {
	public GameObject ArmL,ArmR;

	private Collision Lattach, Rattach;
	private Vector3 ArmLVec,ArmRVec;
	private Vector3 ArmRtoL,ArmRtoOL,ArmRtoOR;
	// Use this for initialization
	void Start () {
		Lattach = ArmL.GetComponent<Attach> ().attach;
		Rattach = ArmR.GetComponent<Attach> ().attach;

	}
	
	// Update is called once per frame
	void Update () {
		Lattach = ArmL.GetComponent<Attach> ().attach;
		Rattach = ArmR.GetComponent<Attach> ().attach;

		Debug.Log (Lattach);
		Debug.Log (Rattach);

		if (Lattach != null && Rattach != null) {
			Debug.Log (Lattach.gameObject.name);
			Debug.Log (Rattach.gameObject.name);
			if (Lattach.gameObject == Rattach.gameObject) {
				Debug.Log ("Yes!!");
				if (ArmL.GetComponent<ArmHasamuFlag> ().bHasamu && ArmR.GetComponent<ArmHasamuFlag> ().bHasamu)
					Lattach.gameObject.SetActive (false);
			} 

			else if(Lattach.gameObject.name == "ArmR" && Rattach.gameObject.name == "ArmL")
			{
				ArmRtoL = ArmL.GetComponent<GetArmHead> ().ArmHead - ArmR.GetComponent<GetArmHead> ().ArmHead;
				ArmRtoOL = Lattach.gameObject.GetComponent<GetArmHead> ().ArmHead - ArmR.GetComponent<GetArmHead> ().ArmHead;
				ArmRtoOR = Rattach.gameObject.GetComponent<GetArmHead> ().ArmHead - ArmR.GetComponent<GetArmHead> ().ArmHead;

				if (Vector3.Cross (ArmRtoL, ArmRtoOL).y <= 0 &&	
					Vector3.Cross (ArmRtoL, ArmRtoOR).y <= 0 &&
					Vector3.Dot(ArmRtoL,ArmRtoOL) > 0 && 
					Vector3.Dot(ArmRtoL,ArmRtoOR) > 0
				) 
				{
					if (ArmL.GetComponent<ArmHasamuFlag> ().bHasamu && ArmR.GetComponent<ArmHasamuFlag> ().bHasamu) {
						Lattach.gameObject.SetActive (false);
						Rattach.gameObject.SetActive (false);
					}
				}
			}
		}
	}

}
