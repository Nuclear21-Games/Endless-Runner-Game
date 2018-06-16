using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

	public ObjectPooler coinPool;

	public float distanceBetweenCoins;


	public void SpawnCoins (Vector3 startposition)
	{
		GameObject Coin1 = coinPool.GetPooledObject();
		Coin1.transform.position = startposition;
		Coin1.SetActive(true);

		GameObject Coin2 = coinPool.GetPooledObject();
		Coin2.transform.position = new Vector3(startposition.x - distanceBetweenCoins, startposition.y, startposition.z);
		Coin2.SetActive(true);


		GameObject Coin3 = coinPool.GetPooledObject();
		Coin3.transform.position = new Vector3(startposition.x + distanceBetweenCoins, startposition.y, startposition.z);
		Coin3.SetActive(true);



	}


}
