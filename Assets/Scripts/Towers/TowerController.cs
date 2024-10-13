using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : PlaceableObjectController {
    public TowerData data;
    public List<GameObject> weapons;
    public List<WeaponController> controllers;
    public void sell() {

    }
    public GameObject findNearestEnemy() {
        GameObject nearest = Find.NearestWithTag(this.transform.position, "Enemy", data.range);
        return nearest;
    } 
    private void shiftWeapons() {
        foreach (GameObject weapon in this.weapons) {
            weapon.transform.position = this.transform.position;
            weapon.transform.rotation = this.transform.rotation;
        }
    }
    private void initWeapons() {
        this.weapons = new List<GameObject>();
        this.controllers = new List<WeaponController>();
        foreach (WeaponData wd in data.weapons) {
            GameObject weapon = wd.Instantiate();
            weapon.transform.position = this.transform.position;
            weapon.transform.rotation = this.transform.rotation;

            this.weapons.Add(weapon);
            this.controllers.Add(weapon.GetComponent<WeaponController>());
        }
    }

    public void Start() {
        this.initWeapons();
    }
    public void Update() {
        if (this.isPlaced()) {
            GameObject nearest = this.findNearestEnemy();
            if (nearest != null) {
                foreach (WeaponController wc in this.controllers) {
                    if (wc.CanFire()) wc.FireAt(nearest);
                }
            }
        } else {
            this.shiftWeapons();
        }
    }
}
