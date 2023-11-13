using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : Singleton<MainMenuManager>   
{
    [SerializeField] public Transform HoderPlayer;
    [SerializeField] protected int ModelIndex;
    [SerializeField] protected int PosGunIndex;
    [SerializeField] protected int GunTypeIndex;

    [SerializeField] public PlayerDataSO playerData;
    [SerializeField] public List<ModelSO> Models = new List<ModelSO>();
    [SerializeField] public List<GunSO> Guns =new List<GunSO>();
    [SerializeField] public List<Transform> ListPrefabsGun = new List<Transform>();

    protected override void Awake()
    {
        base.Awake();
        Init();
    }
    protected void Init()
    {
        if (Models.Count == 0)
        {
            Debug.Log("No see Find Model");
            return;
        }

        if (playerData.modelSO == null)
        {
            ModelIndex = 0;
        }
        else
        {
            ModelIndex = Models.FindIndex(x => x == playerData.modelSO);
        }

        playerData.ListPosGun.Clear();
        playerData.ListGunType.Clear();

        ChangeModel(0);
    }

    public void ChangeModel(int Value)
    {
        ModelIndex += Value;

        if(ModelIndex>= Models.Count)
            ModelIndex=0;
        else if (ModelIndex < 0) 
            ModelIndex= Models.Count-1;

        LoadModel();
        LoadPosGun();
        LoadGunType();

        PosGunIndex = 0;
    } 


    protected void LoadModel()
    {
        playerData.modelSO = Models[ModelIndex];

        foreach (Transform child in HoderPlayer)
        {
            Transform.Destroy(child.gameObject);
        }

        Transform model = Instantiate(Models[ModelIndex].Prefab, HoderPlayer);
        model.localPosition = Vector3.zero; 
    }

    protected void LoadPosGun()
    {
        playerData.ListPosGun.Clear();
        foreach(Vector2 vector2 in Models[ModelIndex].PointGunList)
        {
            playerData.ListPosGun.Add(vector2);
        }
    }

    protected void LoadGunType()
    {
        ListPrefabsGun.Clear();
        playerData.ListGunType.Clear();
        for (int i = 0; i < Models[ModelIndex].PointGunList.Count; i++)
        {
            playerData.ListGunType.Add(Guns[0]);

            Transform newPrefabGun = Instantiate(Guns[0].prefab, HoderPlayer);
            ListPrefabsGun.Add(newPrefabGun);
            newPrefabGun.localPosition = playerData.ListPosGun[i];
        }
    }

    public void ChangeIndexPosGun(int Value)
    {
        PosGunIndex += Value;
        if (PosGunIndex >= Models[ModelIndex].PointGunList.Count)
            PosGunIndex = 0;
        else if (PosGunIndex < 0)
            PosGunIndex = Models[ModelIndex].PointGunList.Count - 1;

        GunTypeIndex = 0;
    }

    public void ChangeGunType(int Value)
    {
        GunTypeIndex += Value;
        if (GunTypeIndex >= Guns.Count)
            GunTypeIndex = 0;
        else if (GunTypeIndex < 0)
            GunTypeIndex = Guns.Count - 1;

        playerData.ListGunType[PosGunIndex] = Guns[GunTypeIndex];
        DestroyAndSpawerGun();
    }

    public void DestroyAndSpawerGun()
    {
        Destroy(ListPrefabsGun[PosGunIndex].gameObject);
        Transform newPrefabGun = Instantiate(Guns[GunTypeIndex].prefab, HoderPlayer);
        newPrefabGun.localPosition = playerData.ListPosGun[PosGunIndex];
        ListPrefabsGun[PosGunIndex] = newPrefabGun;
    }
}
