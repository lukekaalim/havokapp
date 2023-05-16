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

var gameWindowSettings = new GameWindowSettings
{
  //RenderFrequency = 10
};

using (var window = new Game(gameWindowSettings, nativeWindowSettings))
{
    window.Run();
}