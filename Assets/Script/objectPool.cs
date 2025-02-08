using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject paratrooperPrefab;
    public  GameObject helicopterPrefab;

    [SerializeField] int gameObjectSize = 10;
    [SerializeField] List<GameObject> bullet;
    [SerializeField] List<GameObject> helicopter;
    [SerializeField] List<GameObject> paraTrooperList;

    void Start()
    {
        bullet = new List<GameObject>();
        helicopter = new List<GameObject>();
        paraTrooperList = new List<GameObject>();

        for (int i = 0; i < gameObjectSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);   // This is for Bullet
            obj.SetActive(false);
            bullet.Add(obj);

            GameObject helicop = Instantiate(helicopterPrefab);  // This is for Helicopter
            helicop.SetActive(false);
            helicopter.Add(helicop);

            GameObject para = Instantiate(paratrooperPrefab);  // This is for paratrooper
            para.SetActive(false);
            paraTrooperList.Add(para);

        }
    }

    public GameObject GetBullet()
    {
        foreach (GameObject obj in bullet)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        GameObject _obj = Instantiate(bulletPrefab);
        _obj.SetActive(false);
        bullet.Add(_obj);
        return _obj;
    }

    public GameObject GetHelicopter()
    {
        foreach (GameObject obj in helicopter)
        {
            if(!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        GameObject _obj = Instantiate(helicopterPrefab);
        _obj.SetActive(false);
        helicopter.Add(_obj);
        return _obj;
    }

    public GameObject GetParatrooper()
    {
        foreach (GameObject obj in paraTrooperList)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        GameObject _obj = Instantiate(paratrooperPrefab);
        _obj.SetActive(false);
        paraTrooperList.Add(_obj);
        return _obj;
    }
}
    