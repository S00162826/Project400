using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class Test : MonoBehaviour {

    public GameObject loggedInUI;
    public GameObject notLoggedInUI;
    public GameObject hostUserbnameUI;
    public GameObject Friend;

    void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallBack);
        }

        ShowUI();
    }

    void InitCallBack()
    {
        Debug.Log("Facebook has been initialized");
    }

    public void LogIn()
    {
        if (!FB.IsLoggedIn)
        {
            FB.LogInWithReadPermissions( new List<string> { "user_friends" }, LoginCallBack);
        }
    }

    void LoginCallBack(ILoginResult result)
    {
        if (result.Error == null)
        {
            Debug.Log("Facebook has logged in");
            ShowUI();
        }
        else
        {
            Debug.Log("Error during log in" + result.Error);
        }
    }

    void ShowUI()
    {
        if (FB.IsLoggedIn)
        {
            loggedInUI.SetActive(true);
            notLoggedInUI.SetActive(false);
            FB.API("me/picture?width=100&height=100", HttpMethod.GET, PictureCallBack);
            FB.API("me/?fields=first_name", HttpMethod.GET, NameCallBack);            
            FB.API("me/friends", HttpMethod.GET, FriendCallBack);

        }
        else
        {
            loggedInUI.SetActive(false);
            notLoggedInUI.SetActive(true);
        }
    }

    void PictureCallBack(IGraphResult result)
    {
        Texture2D image = result.Texture;
        loggedInUI.transform.Find("ProfilePicture").GetComponent<Image>().sprite =
            Sprite.Create(image, new Rect(0, 0, 100, 100),new Vector2(0.5f,0.5f));
    }

    void NameCallBack(IGraphResult result)
    {
        IDictionary<string, object> profile = result.ResultDictionary;
        loggedInUI.transform.Find("name").GetComponent<Text>().text = "" +
            profile["first_name"];
    }

    void FriendCallBack(IGraphResult result)
    {
        IDictionary<string, object> data = result.ResultDictionary;
        List<object> friends = (List<object>)data["data"];
        foreach (object obj in friends)
        {
            Dictionary<string, object> dictio = (Dictionary<string, object>)obj;
            CreateFriend(dictio["name"].ToString(), dictio["id"].ToString());
        }
    }

    void CreateFriend(string name, string id)
    {
        GameObject myFriend = Instantiate(Friend);
        Transform parent = loggedInUI.transform.Find("ListContainer").Find("FriendList");
        myFriend.transform.SetParent(parent);
        myFriend.GetComponentInChildren<Text>().text = name;
        FB.API(id + "/picture?width=100&height=100", HttpMethod.GET,
            delegate (IGraphResult result)
            {
                myFriend.GetComponentInChildren<Image>().sprite =
           Sprite.Create(result.Texture, new Rect(0, 0, 100, 100), new Vector2(0.5f, 0.5f));
            });
    }

    public void LogOut()
    {
        FB.LogOut();
        ShowUI();
    }

    public void Host()
    {
        loggedInUI.SetActive(false);
        hostUserbnameUI.SetActive(true);
    }

    public void Share()
    {
        FB.ShareLink(new System.Uri("https://niallsproject400.blogspot.com/"),
            "message","description",new System.Uri("imageURL"));
    }

    public void Invite()
    {
        FB.AppRequest(message: "Check this out", title: "Kart Racer 2019");
    }
}
