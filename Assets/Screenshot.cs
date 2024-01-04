using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    [SerializeField]
    private ActionMessage msg;



    // Screenshot process
    public void ScreenshotAction()
    {
        StartCoroutine("CaptureScreen");
    }

    // Get the DICM path
    private string GetAndroidExternalStoragePath()
    {
        if (Application.platform != RuntimePlatform.Android)
            return Application.persistentDataPath;

        var jc = new AndroidJavaClass("android.os.Environment");
        var path = jc.CallStatic<AndroidJavaObject>("getExternalStoragePublicDirectory",
            jc.GetStatic<string>("DIRECTORY_DCIM"))
            .Call<string>("getAbsolutePath");
        return path;
    }

    IEnumerator CaptureScreen()
    {
        // Find the Canvas and disable it first
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;

        // Wait for screen rendering
        yield return new WaitForEndOfFrame();

        // Set the file name
        string currentTime = System.DateTime.Now.ToString("dd-mm-yyy-HH-mm-ss");
        string filename = "demo_s_" + currentTime + ".png";
        string path = GetAndroidExternalStoragePath() + "/myCharacter";

        // check the folder is exist or not
        if (!System.IO.Directory.Exists(path))
            System.IO.Directory.CreateDirectory(path);

         /*       // save the file
                ScreenCapture.CaptureScreenshot(path + "/" + filename);
                yield return new WaitForEndOfFrame();*/

        // screenshot by Texture2D method
        Texture2D image = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        image.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        image.Apply();

        File.WriteAllBytes(path + "/" + filename, image.EncodeToPNG());

        Destroy(image);

        // Turn on the Canvas
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;

        // Display the success message
        msg.SetMessage("Picture saved in: " + path + "/" + filename);
    }
}
