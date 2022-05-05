using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> poolListType1 = new List<GameObject>();
    private List<GameObject> poolListType2 = new List<GameObject>();
    private List<GameObject> poolListType3 = new List<GameObject>();

    List<List<GameObject>> ListOfList = new List<List<GameObject>>();

    private int amountPool = 10;

    public bool canShoot;

    [SerializeField] private GameObject bullet1;
    [SerializeField] private GameObject bullet2;
    [SerializeField] private GameObject bullet3;

    GameObject colObj;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        canShoot = true;
        ListOfList.Add(poolListType1);
        ListOfList.Add(poolListType2);
        ListOfList.Add(poolListType3);

        for (int i = 0; i < amountPool; i++)
        {
            GameObject bull1 = Instantiate(bullet1);
            bull1.SetActive(false);
            poolListType1.Add(bull1);

            GameObject bull2 = Instantiate(bullet2);
            bull2.SetActive(false);
            poolListType2.Add(bull2);

            GameObject bull3 = Instantiate(bullet3);
            bull3.SetActive(false);
            poolListType3.Add(bull3);
        }
    }

    public void DisableBullets()
    {
        for (int i = 0; i < ListOfList.Count; i++)
        {
            List<GameObject> curList = ListOfList[i];

            for (int k = 0; k < curList.Count; k++)
            {
                curList[k].gameObject.SetActive(false);
            }
        }
    }

    public void EnableShoot(GameObject col)
    {
        colObj = col;
        StartCoroutine(OnShoot());
    }
    public IEnumerator OnShoot()
    {
        yield return new WaitForSeconds(1f);
        colObj.GetComponent<BoxCollider>().enabled = true;
        canShoot = true;
    }


    public GameObject GetBullet(int type)
    {
        Debug.Log("llego: " + type);
        type = type - 1;
        List<GameObject> curList = ListOfList[type];

        if (canShoot)
        {
            for (int i = 0; i < curList.Count; i++)
            {
                if (!curList[i].activeInHierarchy)
                {
                    return curList[i];
                }
            }
        }
        return null;
    }

}
