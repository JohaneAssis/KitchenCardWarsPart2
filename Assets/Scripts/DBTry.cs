using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DBTry : MonoBehaviour
{
    /*
    void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://unity3d.com/"))
        {
            yield return request.Send();

            if (request.isNetworkError) // Error
            {
                Debug.Log(request.error);
            }
            else // Success
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }
    */

    /*
    void Start()
    {
        //A correct website page.
        StartCoroutine(GetRequest("https://unity3d.com/"));

        //A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            //Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            string[] info;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                //Here is where we mess with the info
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                info = webRequest.downloadHandler.text.Split('<');
                for (int i = 0; i < info.Length - 1; i++)
                {
                    
                    if(info[i].Contains("Google"))
                    {
                        Debug.Log(info[i]);
                    }
                }
            }
        }
    }
    */

    public Text messageText, getText, currentUploadInfo, valueText;
    string usernameValue;
    //doing it the ugly way
    public Text xpBox, progressBox, dmg1Box, dmg2Box, dmg3Box, dmg4Box, dmg5Box, shd1Box, shd2Box, shd3Box, 
        shd4Box, shd5Box, hth1Box, hth2Box, hth3Box, hthNShd1Box, hthNShd2Box, hthNShd3Box, hthNShd4Box, 
        hthNShd5Box, hthNShd6Box, hthStl1Box, hthStl2Box, hthStl3Box, hthStl4Box, hthStl5Box, shdStl1Box,
shdStl2Box, shdStl3Box, shdStl4Box, shdStl5Box, reverseBox, eng1Box, eng2Box, multX2Box, multX3Box, multX4Box;

    readonly string getURL = "http://localhost/Get.php"; //add the php get file to the end of this
    readonly string postURL = "http://localhost/Post.php"; //add the php post file to the end of this

    void Start()
    {
        messageText.text = "Start";
        ButtonUpload();
    }

    public void ButtonUpload()
    {
        StartCoroutine(GetRequest());
    }

    IEnumerator GetRequest()
    {
        UnityWebRequest www = UnityWebRequest.Get(getURL);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            //here we could pull all of the info from the GET.php file and 
            //put it into the messageText.text and the getText.txt
            messageText.text = www.downloadHandler.text;
            getText.text = www.downloadHandler.text;
        }
    }

    void SplitAndPlaceText()
    {
        string[] linesInBox = getText.text.Split('\n');
        usernameValue = linesInBox[0];
        xpBox.text = linesInBox[1]; progressBox.text = linesInBox[2]; dmg1Box.text = linesInBox[3]; dmg2Box.text = linesInBox[4];
        dmg3Box.text = linesInBox[5]; dmg4Box.text = linesInBox[6]; dmg5Box.text = linesInBox[7]; shd1Box.text = linesInBox[8]; 
        shd2Box.text = linesInBox[9]; shd3Box.text = linesInBox[10]; shd4Box.text = linesInBox[11]; shd5Box.text = linesInBox[12]; 
        hth1Box.text = linesInBox[13]; hth2Box.text = linesInBox[14]; hth3Box.text = linesInBox[15]; hthNShd1Box.text = linesInBox[16]; 
        hthNShd2Box.text = linesInBox[17]; hthNShd3Box.text = linesInBox[18]; hthNShd4Box.text = linesInBox[19]; 
        hthNShd5Box.text = linesInBox[20]; hthNShd6Box.text = linesInBox[21]; hthStl1Box.text = linesInBox[22]; hthStl2Box.text = linesInBox[23]; 
        hthStl3Box.text = linesInBox[24]; hthStl4Box.text = linesInBox[25]; hthStl5Box.text = linesInBox[26]; shdStl1Box.text = linesInBox[27]; 
        shdStl2Box.text = linesInBox[28]; shdStl3Box.text = linesInBox[29]; shdStl4Box.text = linesInBox[30]; shdStl5Box.text = linesInBox[31]; 
        reverseBox.text = linesInBox[32]; eng1Box.text = linesInBox[33]; eng2Box.text = linesInBox[34]; multX2Box.text = linesInBox[35];
        multX3Box.text = linesInBox[36]; multX4Box.text = linesInBox[37];
    }

    IEnumerator PostRequest()
    {
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        //curUpload has to be the name of card or value, case matters
        wwwForm.Add(new MultipartFormDataSection("xpKey", xpBox.text));
        wwwForm.Add(new MultipartFormDataSection("progressKey", progressBox.text));
        wwwForm.Add(new MultipartFormDataSection("Dmg1Key", dmg1Box.text));
        wwwForm.Add(new MultipartFormDataSection("Dmg2Key", dmg2Box.text));
        wwwForm.Add(new MultipartFormDataSection("Dmg3Key", dmg3Box.text));
        wwwForm.Add(new MultipartFormDataSection("Dmg4Key", dmg4Box.text));
        wwwForm.Add(new MultipartFormDataSection("Dmg5Key", dmg5Box.text));
        wwwForm.Add(new MultipartFormDataSection("Shd1Key", shd1Box.text));
        wwwForm.Add(new MultipartFormDataSection("Shd2Key", shd2Box.text));
        wwwForm.Add(new MultipartFormDataSection("Shd3Key", shd3Box.text));
        wwwForm.Add(new MultipartFormDataSection("Shd4Key", shd4Box.text));
        wwwForm.Add(new MultipartFormDataSection("Shd5Key", shd5Box.text));
        wwwForm.Add(new MultipartFormDataSection("Hth1Key", hth1Box.text));
        wwwForm.Add(new MultipartFormDataSection("Hth2Key", hth2Box.text));
        wwwForm.Add(new MultipartFormDataSection("Hth3Key", hth3Box.text));
        wwwForm.Add(new MultipartFormDataSection("HthNShd1Key", hthNShd1Box.text));
        wwwForm.Add(new MultipartFormDataSection("HthNShd2Key", hthNShd2Box.text));
        wwwForm.Add(new MultipartFormDataSection("HthNShd3Key", hthNShd3Box.text));
        wwwForm.Add(new MultipartFormDataSection("HthNShd4Key", hthNShd4Box.text));
        wwwForm.Add(new MultipartFormDataSection("HthNShd5Key", hthNShd5Box.text));
        wwwForm.Add(new MultipartFormDataSection("HthNShd6Key", hthNShd6Box.text));
        wwwForm.Add(new MultipartFormDataSection("HthStl1Key", hthStl1Box.text));
        wwwForm.Add(new MultipartFormDataSection("HthStl2Key", hthStl2Box.text));
        wwwForm.Add(new MultipartFormDataSection("HthStl3Key", hthStl3Box.text));
        wwwForm.Add(new MultipartFormDataSection("HthStl4Key", hthStl4Box.text));
        wwwForm.Add(new MultipartFormDataSection("HthStl5Key", hthStl5Box.text));
        wwwForm.Add(new MultipartFormDataSection("ShdStl1Key", shdStl1Box.text));
        wwwForm.Add(new MultipartFormDataSection("ShdStl2Key", shdStl2Box.text));
        wwwForm.Add(new MultipartFormDataSection("ShdStl3Key", shdStl3Box.text));
        wwwForm.Add(new MultipartFormDataSection("ShdStl4Key", shdStl4Box.text));
        wwwForm.Add(new MultipartFormDataSection("ShdStl5Key", shdStl5Box.text));
        wwwForm.Add(new MultipartFormDataSection("ReverseKey", reverseBox.text));
        wwwForm.Add(new MultipartFormDataSection("Eng1Key", eng1Box.text));
        wwwForm.Add(new MultipartFormDataSection("Eng2Key", eng2Box.text));
        wwwForm.Add(new MultipartFormDataSection("MultX2Key", multX2Box.text));
        wwwForm.Add(new MultipartFormDataSection("MultX3Key", multX3Box.text));
        wwwForm.Add(new MultipartFormDataSection("MultX4Key", multX4Box.text));
        UnityWebRequest www = UnityWebRequest.Post(postURL, wwwForm);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            messageText.text = www.downloadHandler.text;
            
        }
    }

    public void OnButtonSend()
    {
        if(currentUploadInfo.text == string.Empty)
        {
            messageText.text = "Empty";
        }
        else
        {
            messageText.text = "Sending";
            //this is to manually send the updated info
            StartCoroutine(PostRequest());
            SplitAndPlaceText();
        }
    }
    
}