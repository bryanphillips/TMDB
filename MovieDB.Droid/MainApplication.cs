﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using MovieDB.Core;

namespace MovieDB.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer) { }

        public override void OnCreate()
        {
            base.OnCreate();

            //Initalize singletons and default utilities.
            Startup.Initialize(logger: () => new AndroidLogger(), settings: () => new AndroidSettings(this));
        }
    }
}