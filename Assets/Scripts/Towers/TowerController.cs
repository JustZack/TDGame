using System.Collections.Generic;
using UnityEngine;

public class TowerController : PlaceableObjectController {
    public TowerData data;
    public List<GameObject> weapons;
    public List<WeaponController> controllers;
    public void sell() {

    }
    public GameObject findNearestEnemy() {
        GameObject nearest = Find.NearestWithTag(this.transform.position, Tags.Enemy, data.range);
        return nearest;
    } 
    private void setWeaponTransform(GameObject weapon) {
        //weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, this.transform.rotation.z));
        weapon.transform.position = this.transform.position + new Vector3(0, 0, -1);
    }
    private void shiftWeapons() {
        foreach (GameObject weapon in this.weapons) this.setWeaponTransform(weapon);
    }
    private void initWeapons() {
        this.weapons = new List<GameObject>();
        this.controllers = new List<WeaponController>();
        foreach (WeaponData wd in data.weapons) {
            GameObject weapon = wd.Instantiate();
            this.setWeaponTransform(weapon);
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
                    if (wc.CanAttack()) wc.Attack(nearest);
                    else wc.LookAt(nearest);
                }
            }
        } else {
            this.shiftWeapons();
        }
    }
}
