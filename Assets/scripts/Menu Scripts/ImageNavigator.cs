using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class ImageNavigator : MonoBehaviour
{
    public RawImage imageDisplay;
    public List<Texture2D> images = new List<Texture2D>(); // List to hold the loaded images
    private int currentIndex = 0; // Index of the currently displayed image
    public string FolderName;

    void Start()
    {
        LoadImagesFromFolder(FolderName); // Replace "Textures" with your folder name
        ShowCurrentImage();
    }

    void LoadImagesFromFolder(string folderName)
    {
        string path = Path.Combine(Application.dataPath, folderName);
        string[] imagePaths = Directory.GetFiles(path, "*.png"); // Change "*.png" to match your image format

        foreach (string imagePath in imagePaths)
        {
            byte[] imageData = File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageData);
            images.Add(texture);
        }
    }

    void ShowCurrentImage()
    {
        if (images.Count > 0)
        {
            imageDisplay.texture = images[currentIndex];
        }
    }

    public void NextImage()
    {
        currentIndex = (currentIndex + 1) % images.Count;
        ShowCurrentImage();
    }

    public void PreviousImage()
    {
        currentIndex = (currentIndex - 1 + images.Count) % images.Count;
        ShowCurrentImage();
    }
}
