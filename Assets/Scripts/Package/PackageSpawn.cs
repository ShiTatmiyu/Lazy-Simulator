using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSpawn : MonoBehaviour
{
    public List<Package> packageList;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform spawnPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (packageList != null)
        {
            for (int i = 0;i < packageList.Count; i++)
            {
                packageList[i].deliveryTime = packageList[i].deliveryTime - 1 * Time.deltaTime;
                Debug.Log(Mathf.RoundToInt(packageList[i].deliveryTime));

                if (packageList[i].deliveryTime <= 0)
                {
                    Instantiate(packageList[i].packageVisual, spawnPosition);
                    packageList.RemoveAt(i);
                }
            }
        }
    }
}

[System.Serializable]
public class Package
{
    public GameObject packageVisual;
    public float deliveryTime;
    public GameObject packageObject;
}
