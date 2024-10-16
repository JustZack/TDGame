using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStabData", menuName = "Resources/Towers/Attacks/Stab")]
public class StabData : AttackData {
    public override GameObject Instantiate() {
        GameObject stab = base.Instantiate();
        StabController sc = stab.AddComponent<StabController>();
        sc.data = this.Copy<StabData>();
        return stab;
    }
}
