using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maker : MonoBehaviour
{
    //玉のprefab
		public GameObject ball;
		//射出の
		public float pace;
		private bool goball = false;
		public float speed; 

		void OnEnable()
		{
				StartCoroutine (MakeBall ());
		}
		
	  IEnumerator MakeBall ()
		{
				while (true) {
						yield return new WaitForSeconds (pace);
						if(goball)
						{
							ObjectPool.instance.getBall ();
						}
				}
		}

		void Update()
		{
			if (Input.GetMouseButton(0)){
				goball = true;
				//ObjectPool.getBall();
			}else{
				goball = false;
			}
		}
}
