//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using Amazon;
//using Amazon.Runtime;
//using Amazon.CognitoIdentity;
//using Amazon.CognitoIdentity.Model;
//using Amazon.CognitoSync;
//using Amazon.CognitoSync.SyncManager;

//public class SyncClient : MonoBehaviour
//{
//    public GameObject hostLobbyUI;
//    string name;
//    Dataset playerInfo;
//    CognitoSyncManager syncManager;
//    CognitoAWSCredentials credentials;

//    void Start()
//    {
//        //AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;
//        UnityInitializer.AttachToGameObject(this.gameObject);
//        AWSConfigs.LoggingConfig.LogTo = LoggingOptions.UnityLogger;
//        credentials = new CognitoAWSCredentials("us-east-2:ebdb31c8-2b8d-4c3f-ab64-a5306cfb4bc0", RegionEndpoint.USEast2);
//        syncManager = new CognitoSyncManager(credentials, RegionEndpoint.USEast2);
//        playerInfo = syncManager.OpenOrCreateDataset("playerInfo");
//    }

//    public void ChangeName(string newName)
//    {
//        name = newName;
//        playerInfo.Put("username", newName);
//    }

//    public void Synchronize()
//    {
//        playerInfo.SynchronizeOnConnectivity();
//    }
//}
