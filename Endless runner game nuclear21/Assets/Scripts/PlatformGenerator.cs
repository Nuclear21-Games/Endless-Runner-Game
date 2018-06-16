using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;

	private float platformWidth;

	public float distancebetweenMin;
	public float distancebetweenMax;

	private int platformSelector;

	public float[] platformWidhts;
	//public GameObject[] thePlatforms;

	public ObjectPooler[] theobjectPools;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float HeightChange;

	private CoinGenerator theCoinGenerator;
	public float randomCoinThreshold;

	// Use this for initialization
	void Start () {
		//platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

		platformWidhts = new float[theobjectPools.Length];

		for (int i = 0; i < theobjectPools.Length; i++)
		{
			platformWidhts[i] = theobjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
		theCoinGenerator = FindObjectOfType<CoinGenerator>();

	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x)
		{
			distanceBetween = Random.Range(distancebetweenMin, distancebetweenMax);

			platformSelector = Random.Range(0, theobjectPools.Length);


			HeightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

			if (HeightChange > maxHeight)
			{
				HeightChange = maxHeight;
			} else if (HeightChange <minHeight)
			{
				HeightChange = minHeight;
			}
 
			transform.position = new Vector3(transform.position.x + (platformWidhts[platformSelector] / 2) + distanceBetween, HeightChange, transform.position.z);

			//Instantiate(/* thePlatform */ thePlatforms[platformSelector], transform.position, transform.rotation);

			GameObject newPlatform = theobjectPools[platformSelector].GetPooledObject();


			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);


			if(Random.Range(0f, 100f) <randomCoinThreshold)

			theCoinGenerator.SpawnCoins (new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z ) );

			transform.position = new Vector3(transform.position.x + (platformWidhts[platformSelector] / 2), transform.position.y, transform.position.z);

		}
		
	}
}
