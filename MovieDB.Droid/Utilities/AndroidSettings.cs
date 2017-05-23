using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MovieDB.Core;
using MovieDB.Core.Models;
using Android.Preferences;
using Newtonsoft.Json;

namespace MovieDB.Droid
{
    public class AndroidSettings : ISettings
    {
        private readonly Context _context;
        private ISharedPreferences _preferences;
        private ISharedPreferencesEditor _editor;

        public AndroidSettings(Context context)
        {
            _context = context;
        }

        public User User
        {
            get { return GetObject<User>("User"); }
            set { Put("User", value); }
        }

        public string Password
        {
            get { return GetString("Password"); }
            set { Put("Password", value); }
        }

        public List<Favorite> Favorites
        {
            get { return GetObject<List<Favorite>>("Favorites"); }
            set { Put("Favorites", value); }
        }

        public void Save()
        {
            //Commit changes and dispose
            if (_editor != null)
            {
                _editor.Commit();
                _editor.Dispose();
                _editor = null;
            }
            if (_preferences != null)
            {
                _preferences.Dispose();
                _preferences = null;
            }
        }

        /// <summary>
        /// Generic method to retrieve object of type T from shared preferences.
        /// Leverages using to make sure the shared prefs are disposed after accessed.
        /// Also deserializes the object from shared prefs
        /// </summary>
        /// <typeparam name="T">generic type</typeparam>
        /// <param name="key">string key</param>
        /// <returns>value of type T</returns>
        private T GetObject<T>(string key)
            where T : class
        {
            //Use a local instance of preferences for "Get"
            using (var preferences = PreferenceManager.GetDefaultSharedPreferences(_context))
            {
                string json = preferences.GetString(key, string.Empty);
                if (string.IsNullOrEmpty(json))
                    return null;
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        /// <summary>
        /// Leverages using to make sure the shared prefs are disposed after accessed.
        /// </summary>
        /// <param name="key">string key</param>
        /// <returns>string value from shared prefs</returns>
        private string GetString(string key)
        {
            //Use a local instance of preferences for "Get"
            using (var preferences = PreferenceManager.GetDefaultSharedPreferences(_context))
            {
                return preferences.GetString(key, string.Empty);
            }
        }

        /// <summary>
        /// Serialize object into the shared prefs for storage.
        /// </summary>
        /// <param name="key">string key</param>
        /// <param name="value">object value to store</param>
        private void Put(string key, object value)
        {
            CheckPreferences();

            _editor.PutString(key, JsonConvert.SerializeObject(value));
            _editor.Commit();
        }

        /// <summary>
        /// Store string value into shared prefs.
        /// </summary>
        /// <param name="key">string key</param>
        /// <param name="value">string value to store</param>
        private void Put(string key, string value)
        {
            CheckPreferences();

            _editor.PutString(key, value);
            _editor.Commit();
        }

        private void CheckPreferences()
        {
            //Create preferences & editor if needed
            if (_preferences == null)
                _preferences = PreferenceManager.GetDefaultSharedPreferences(_context);
            if (_editor == null)
                _editor = _preferences.Edit();
        }
    }
}