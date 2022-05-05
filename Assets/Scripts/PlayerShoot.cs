using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{

    public int typeOfBullet = 1;
    [SerializeField] TMP_Text showType;

    [SerializeField] private Transform bulletPos;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ObjectPool.instance.canShoot)
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (typeOfBullet < 3)
            {
                typeOfBullet += 1;
            }
            else
            {
                typeOfBullet = 1;

            }
            showType.text = "Type bullet " + typeOfBullet;

        }
    }

    private void Fire()
    {
        GameObject bullet = ObjectPool.instance.GetBullet(typeOfBullet);
        if (bullet != null)
        {
            bullet.transform.position = bulletPos.position;
            bullet.SetActive(true);
        }
    }
}
