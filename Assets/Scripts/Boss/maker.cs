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

		void Start ()
		{
				StartCoroutine (MakeBall ());
		}
		
		//ボールを生成するメソッド
		IEnumerator MakeBall ()
		{
				while (true) {
						yield return new WaitForSeconds (pace);
						//InstantiateをgetBallに書き換え
						//Instantiate (ball, gameObject.transform.position, Quaternion.identity);
						if(goball){
							ObjectPool.instance.getBall ();
						}
						
				}
		}

		void Update()
		{
			if (Input.GetMouseButton(0)){
				goball = true;
			}else{
				goball = false;
			}
		}
}
