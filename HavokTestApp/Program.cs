// See https://aka.ms/new-console-template for more information
using HavokTestApp;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
﻿using OpenTK.Mathematics;


var nativeWindowSettings = new NativeWindowSettings()
{
    Size = new Vector2i(800, 600),
    Title = "LearnOpenTK - Creating a Window",
    // This is needed to run on macos
    Flags = ContextFlags.ForwardCompatible,
};

using (var window = new Game(GameWindowSettings.Default, nativeWindowSettings))
{
    window.Run();
}