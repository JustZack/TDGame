using UnityEngine;


public abstract class PrefabableObject : BaseObject {
    public GameObject prefab;
    public float prefabAngleOffset;
    public float size;
    public override GameObject Instantiate() {
        GameObject instance = Instantiate(this.prefab);
        instance.transform.localScale *= this.size;
        //instance.AddComponent<ShowForwardVector>();
        return instance;
    }
}
