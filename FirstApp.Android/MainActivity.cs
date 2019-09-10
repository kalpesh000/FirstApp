using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Plugin.Permissions;
using Firebase.Firestore;
using Firebase;
using Java.Util;

namespace FirstApp.Droid
{
    [Activity(Label = "FirstApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //Firestore Global initialization. 
        //Kalpesh test.

        FirebaseFirestore database;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //Init method which initialzed windows forms maps -E60 T0.45
            Xamarin.FormsMaps.Init(this, savedInstanceState);

            //Init method which request the activity -E62 T7.23
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);

            string dbName = "travel_db.sqlite";
            string folderpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullpath = Path.Combine(folderpath, dbName);

            //This instances needs to be called only onces as this creates database in Firestore. -E:Ufinix Firestore T:17.40
            database = GetDataBase();

            //saveMtd();

            LoadApplication(new App(fullpath));
        }

        public FirebaseFirestore GetDataBase()
        {
            FirebaseFirestore database;

            var options = new FirebaseOptions.Builder()
                .SetProjectId("firstapp-251018")
                .SetApplicationId("firstapp-251018")
                .SetApiKey("AIzaSyD_Kl8ihN6qGGPUdM9LioAsoGme7Xn7REM")
                .SetDatabaseUrl("https://firstapp-251018.firebaseio.com")
                .SetStorageBucket("firstapp-251018.appspot.com")
                .Build();

            var app = FirebaseApp.InitializeApp(this, options);
            database = FirebaseFirestore.GetInstance(app);

            return database;
        }

        public void saveMtd()
        {
            HashMap map = new HashMap();
            map.Put("Name", "Kalpesh..!!!");

            DocumentReference docRef = database.Collection("users").Document();
            docRef.Set(map);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /*
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        */
    }
}