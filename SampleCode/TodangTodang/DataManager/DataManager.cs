using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private static string b = "BFF3CBAF81A079729C11A25180C8E8069F8304B05262FC80D22F6D7DED6E7166";
    private static readonly string a = b.Substring(0, 128 / 8);
    private Dictionary<Type, Dictionary<string, ScriptableObject>> _defaultDataBank;

    private bool _isInited = false;

    public bool isInited
    {
        get
        {
            return _isInited;
        }
    }
    private string _playerDataSavePath;
    private string _marketDataSavePath;
    private string _decoStoreDataPath;
    private string _effectsDataPath;
    private string _newsDataPath;

    private const string _playerDataSaveName = "PlayerDataSave.sav";
    private const string _marketDataSaveName = "MarketDataSave.sav";
    private const string _decoStoreDataName = "DecoStoreDataSave.sav";
    private const string _effectsDataName = "EffectSave.sav";
    private const string _newsDataName = "NewsSave.sav";

    public bool isCorrupted { get; private set; } = false;


    #region InitMethods

    private Dictionary<Type, string> _filePathDic;
    private HashSet<Savable> _saveDatas;


    private GameSettingsData gameSettingsData;
    protected void Awake()
    {
        Init();
    }

    public void Init()
    {
        _playerDataSavePath = Path.Combine(Application.persistentDataPath, _playerDataSaveName);
        _marketDataSavePath = Path.Combine(Application.persistentDataPath, _marketDataSaveName);
        _decoStoreDataPath = Path.Combine(Application.persistentDataPath, _decoStoreDataName);
        _effectsDataPath = Path.Combine(Application.persistentDataPath, _effectsDataName);
        _newsDataPath = Path.Combine(Application.persistentDataPath, _newsDataName);
        InitDefaultData();
        _isInited = true;

        _filePathDic = new Dictionary<Type, string>();
        _filePathDic.Add(typeof(PlayerData), _playerDataSavePath);
        _filePathDic.Add(typeof(MarketData), _marketDataSavePath);
        _filePathDic.Add(typeof(DecoStoreData), _decoStoreDataPath);
        _filePathDic.Add(typeof(EffectsData), _effectsDataPath);
        _filePathDic.Add(typeof(NewsSystem), _newsDataPath);

        _saveDatas = new HashSet<Savable>();

    }

    private void InitDefaultData()
    {
        _defaultDataBank = new Dictionary<Type, Dictionary<string, ScriptableObject>>();

        ScriptableObject[] datas = Resources.LoadAll<ScriptableObject>("ScriptableDatas");

        foreach (ScriptableObject scriptableData in datas)
        {
            AddDefaultData(scriptableData);
        }
    }

    private void AddDefaultData(ScriptableObject scriptableData)
    {
        Type type = scriptableData.GetType();

        Dictionary<string, ScriptableObject> dic;

        if (scriptableData is EffectSO)
        {
            Dictionary<string, ScriptableObject> effectDic;
            Type effectType = typeof(EffectSO);
            if (!_defaultDataBank.TryGetValue(effectType, out effectDic))
            {
                effectDic = new Dictionary<string, ScriptableObject>();
                _defaultDataBank.Add(effectType, effectDic);
            }
            effectDic.TryAdd(scriptableData.name, scriptableData);
        }

        if (!_defaultDataBank.TryGetValue(type, out dic))
        {
            dic = new Dictionary<string, ScriptableObject>();
            _defaultDataBank.Add(type, dic);
        }
        dic.TryAdd(scriptableData.name, scriptableData);
    }
    #endregion

    #region UserMethod

    public U GetDefaultData<U>(string name) where U : ScriptableObject
    {
        U result = null;
        if (_defaultDataBank.TryGetValue(typeof(U), out Dictionary<string, ScriptableObject> dic))
        {
            if (dic.TryGetValue(name, out ScriptableObject value))
            {
                result = value as U;
            }
            else
            {
                Debug.Log($"{typeof(U)} : {name}은 Resources에 등록되지 않은 데이터 입니다");
            }
        }
        else
        {
            Debug.Log($"{nameof(U)}로 생성된 저장공간이 없습니다");
        }
        return result;
    }

    public U[] GetDefaultDataArray<U>() where U : ScriptableObject
    {
        U[] result = null;
        if (_defaultDataBank.TryGetValue(typeof(U), out Dictionary<string, ScriptableObject> dic))
        {
            result = new U[dic.Count];
            int i = 0;
            foreach (ScriptableObject value in dic.Values)
            {
                result[i] = value as U;
                ++i;
            }
        }
        else
        {
            Debug.Log($"{nameof(U)}로 생성된 저장공간이 없습니다");
        }

        return result;

    }

    #endregion

    #region SaveAndLoadMethod

    #region SaveAndLoad

    public void RegistSaveData(Savable saveData)
    {
        _saveDatas.Add(saveData);
    }

    public void CancelRegistSaveData(Savable saveData)
    {
        _saveDatas.Remove(saveData);
    }

    public void SaveAllData()
    {
        foreach (Savable data in _saveDatas)
        {
            Type type = data.GetType();
            if (_filePathDic.TryGetValue(type, out string filePath))
            {
                string jsonData = data.GetJsonData();
                Saving(jsonData, filePath);
            }
            else
            {
#if UNITY_EDITOR
                Debug.LogWarning("type에 맞는 filePath가 없습니다. 신경써주세요");
#endif
            }

        }
    }

    public void Load<T>(out T data) where T : Savable, new()
    {
        Type dataType = typeof(T);
        data = null;
        string jsonData = null;
        if (_filePathDic.TryGetValue(dataType, out string filePath) && File.Exists(filePath))
        {
            jsonData = Loading(filePath, out bool needEncrypt);

            if (jsonData == string.Empty || isCorrupted)
            {
                GetDefaultData<T>(dataType, out data);
            }
            else
            {
                data = new T();
                Param param = GetParam<T>();
                data.Init(jsonData, param);

            }
            if (needEncrypt)
            {
                Saving(jsonData, filePath);
            }
        }
        else
        {
#if UNITY_EDITOR
            if (filePath == null)
                Debug.LogWarning("type에 맞는 filePath가 없습니다. 신경써주세요");
#endif
            GetDefaultData<T>(dataType, out data);
        }
    }

    public void LoadSaveData<U>(out U data) where U : SaveData
    {
        data = null;
        Type saveDataType = typeof(U);
        if (_filePathDic.TryGetValue(saveDataType, out string filePath) && File.Exists(filePath))
        {
            string jsonData = Loading(filePath, out bool needEncrypt);

            if (jsonData != string.Empty && !isCorrupted)
            {
                data = JsonUtility.FromJson<U>(jsonData);
            }
            if (needEncrypt)
            {
                Saving(jsonData, filePath);
            }
        }
    }

    private string Loading(string path, out bool needEncrypt)
    {
        string data = string.Empty;
        needEncrypt = false;
        using (StreamReader sr = new StreamReader(path))
        {
            string encrypdata = sr.ReadToEnd();
            // 추후에 버전 체크를 할 수 있게 변형할 수 있음.
            if (encrypdata.StartsWith(Strings.SaveData.SAVE_VERSION))
            {
                string[] strIntegrityCheckSplit = encrypdata.Split("|");
                // 문자열 분리 결과가 3이 아니면 데이터 변조
                if (strIntegrityCheckSplit.Length != 3)
                {
                    isCorrupted = true;
                    Debug.LogWarning("데이터의 이상");
                    return string.Empty;
                }
                else
                {
                    string hashString = $"{strIntegrityCheckSplit[0]}|{strIntegrityCheckSplit[1]}";
                    string sha256Data = GetSha256String(hashString);
                    // 무결성 검사
                    if (strIntegrityCheckSplit[2].CompareTo(sha256Data)== 0)
                    {
                        data = DecryptData(strIntegrityCheckSplit[1]);
                    }
                    else
                    {
                        isCorrupted = true;
                        Debug.LogWarning("데이터의 이상");
                        return string.Empty;
                    }
                }
            }
            // 구 버전 대응
            else if (encrypdata.StartsWith("{"))
            {
                data = encrypdata;
                needEncrypt = true;
            }
            // 위 두개가 해당이 없다면 데이터가 유효하지 않음
            else
            {
                isCorrupted = true;
                Debug.LogWarning("데이터의 이상");
                return string.Empty;
            }

        }

        return data;
    }

    private void Saving(string data, string path)
    {
        using (StreamWriter sr = new StreamWriter(path))
        {
            string encryptingData = EncryptData(data);
            string versionAddedData = $"{Strings.SaveData.SAVE_VERSION}|{encryptingData}";
            string hashString = GetSha256String(versionAddedData);
            sr.Write($"{Strings.SaveData.SAVE_VERSION}|{encryptingData}|{hashString}");
        }
    }

    private string GetSha256String(string data)
    {
        string hashString = string.Empty;
        using (SHA256 sha256 = SHA256.Create())
        {
            StringBuilder sb = new StringBuilder(256);
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
            for (int i = 0; i < bytes.Length; ++i)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            hashString = sb.ToString();
        }

        return hashString;
    }
    
    private void GetDefaultData<T>(Type dataType, out T data) where T : Savable
    {
        data = null;
        if (dataType == typeof(PlayerData))
        {
            data = MakeDefaultPlayerData() as T;
        }
        else if (dataType == typeof(MarketData))
        {
            data = MakeDefaultMarketData() as T;
        }
        else if (dataType == typeof(DecoStoreData))
        {
            data = MakeDefaultDecoStoreData() as T;
        }
        else if (dataType == typeof(NewsSystem))
        {
            data = new NewsSystem() as T;
        }
        else if (dataType == typeof(EffectsData))
        {
            data = new EffectsData() as T;
        }
    }

    private Param GetParam<T>() where T : Savable
    {
        Param data = null;
        Type dataType = typeof(T);
        if (dataType == typeof(MarketData))
        {
            MarketData.MarketDataParam param = new MarketData.MarketDataParam();
            IngredientInfoSO[] ingredientInfoSos = GetDefaultDataArray<IngredientInfoSO>();
            param.IngredientInfoSos = ingredientInfoSos;
            data = param;
        }
        else if (dataType == typeof(DecoStoreData))
        {
            DecoStoreData.DecoStoreDataParam param = new DecoStoreData.DecoStoreDataParam();
            StoreDecorationInfoSO[] storeDecorationInfoSos = GetDefaultDataArray<StoreDecorationInfoSO>();
            param._storeDecoDatas = storeDecorationInfoSos;
            data = param;
        }
        else if (dataType == typeof(EffectsData))
        {
            EffectsData.EffectsDataParam param = new EffectsData.EffectsDataParam();
            param.dataManager = this;
            data = param;
        }

        return data;
    }  

    #endregion

    #region Encrypte Decrypt
    private string EncryptData(string data)
    {
        byte[] plainBytes = Encoding.UTF8.GetBytes(data);

        RijndaelManaged rijndaelManaged = new RijndaelManaged();
        rijndaelManaged.Padding = PaddingMode.PKCS7;
        rijndaelManaged.KeySize = 256;
        rijndaelManaged.BlockSize = 128;

        MemoryStream memoryStream = new MemoryStream();
        ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(Encoding.UTF8.GetBytes(a), Encoding.UTF8.GetBytes(a));
        CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
        cryptoStream.FlushFinalBlock();

        byte[] encryptBytes = memoryStream.ToArray();
        string encryptString = Convert.ToBase64String(encryptBytes);

        cryptoStream.Close();
        memoryStream.Close();
        return encryptString;
    }

    private string DecryptData(string data)
    {
        MemoryStream memoryStream = null;
        CryptoStream cryptoStream = null;
        string plainString = String.Empty;
        
        byte[] encryptBytes = Convert.FromBase64String(data);

        RijndaelManaged rijndaelManaged = new RijndaelManaged();
        rijndaelManaged.Mode = CipherMode.CBC;
        rijndaelManaged.Padding = PaddingMode.PKCS7;
        rijndaelManaged.KeySize = 256;
        rijndaelManaged.BlockSize = 128;

        memoryStream = new MemoryStream(encryptBytes);
        ICryptoTransform decryptor =
            rijndaelManaged.CreateDecryptor(Encoding.UTF8.GetBytes(a), Encoding.UTF8.GetBytes(a));
        cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

        byte[] plainBytes = new byte[encryptBytes.Length];

        int plainCount = cryptoStream.Read(plainBytes, 0, plainBytes.Length);

        plainString = Encoding.UTF8.GetString(plainBytes, 0, plainCount);
        cryptoStream.Close();
        memoryStream.Close();
        
        return plainString;
    }

    #endregion


    #endregion
}


#region SaveDataClass
[Serializable]
public class PlayerSaveData
{
    public int Star;
    public int Money;
    public int Date;
    public Enums.PlayerDayCycleState DayCycleState;
    public Enums.PlayerEndingState EndingState;
    public List<IngredientInfoData> IngredientDatas;
    public List<RecipeInfoData> RecipeInfoDatas;
    public List<KitchenUtensilInfoData> KitchenUtensilInfoDatas;
    public List<string> StoreDecorationDatas;
    public List<string> NewUnLockedRecipeList;
    public bool isNeedHelp;
    public bool isFirstPlay;
    public bool IsCompleteUpgradeTutorial;
}

[Serializable]
public class MarketSaveData
{
    public List<string> IsSellableStrs;
    public List<bool> IsSellableValues;
    public List<string> IngredientPriceStrs;
    public List<int> IngredientPriceValues;
}

[Serializable]
public class DecoStoreSaveData
{
    public List<StoreDecorationInfoData> StoreDecorationInfoDatas;
}

[Serializable]
public class EffectSaveData : SaveData
{
    public List<string> IngredientEffects;
    public List<string> CustomerEffects;
    public List<int> IngredientEffectRemainDays;
    public List<int> CustomerEffectRemainDays;
    public List<string> EffectQueueSOString;
    public List<int> EffectQueueValue;
}

public class NewsData
{
    public List<bool> completeAchievements;
}

#endregion