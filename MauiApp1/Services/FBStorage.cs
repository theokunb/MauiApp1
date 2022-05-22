using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class FBStorage
    {
        private FBStorage()
        {
            firebaseStorage = new FirebaseStorage(key);
        }

        private const string key = "testmaui-ae782.appspot.com";
        private FirebaseStorage firebaseStorage;
        private static FBStorage storage = new FBStorage();

        public static FBStorage Storage => storage;

        public async Task<FirebaseStorageTask> PutDocument(string path, FileResult file)
        {
            return firebaseStorage.Child(path).Child(file.FileName).PutAsync(await file.OpenReadAsync());
        }

        public async Task RemoveDocument(string path, string fileName)
        {
            await firebaseStorage.Child(path).Child(fileName).DeleteAsync();
        }
    }
}
