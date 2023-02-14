using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;

//Endereço do blob na azure que criou-se na azure
var blobServiceClient = new BlobServiceClient(
    new Uri("https://aula1402blobthiago.blob.core.windows.net"), 
    new DefaultAzureCredential());

//Cria o container no Azure

string containerName = "aulainfnet1402container8";

// Cria o blob
BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);

// crie uma pasta chamada adata
string localPath = "data";
Directory.CreateDirectory(localPath);
//nome do arquivo txt
//string fileName = "quickstart" + Guid.NewGuid().ToString() + ".txt";
string fileName = "teste.txt";

// caminho dele
string localFilePath = Path.Combine(localPath, fileName);

//Espere até a criação do arquivo
//await File.WriteAllTextAsync(localPath, "BOM DIA TURMA");

//Cria dentro do blob
BlobClient blobClient = containerClient.GetBlobClient(fileName);

// Upload do arquivo

Console.WriteLine("UPLOADING....");

await blobClient.UploadAsync(localFilePath, true);

//Fazer o dopwnload do blob

Console.WriteLine("Efetuando o download do arquivo");

string downloadFilePath = localFilePath.Replace(".txt", "Download.txt");

await blobClient.DownloadToAsync(downloadFilePath);

Console.WriteLine("Ended....");
Console.ReadLine();

