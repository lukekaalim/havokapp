using System;
using System.Collections.Generic;
using System.Linq;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

using LKEngine;
using Havok;
using VRage;
using VRage.Platform.Windows;


namespace HavokTestApp;

public class Game : GameWindow
{
  Scene scene;

  public Game(
    GameWindowSettings gameWindowSettings,
    NativeWindowSettings nativeWindowSettings
  ) : base(gameWindowSettings, nativeWindowSettings) {}

  protected override void OnLoad()
  {
      base.OnLoad();
      var cube3 = LKEngine.Geometry.Cube.GetCubeVertices(0.5f);
      var cube4 = LKEngine.Geometry.Cube.GetCubeVertices(1f);

      var buffer = VertexBuffer.CreateFromVertices(cube3);
      var buffer2 = VertexBuffer.CreateFromVertices(cube4);

      var shader = LKEngine.Shaders.IndexColorShader.CreateProgram();

      var geometry = VertexArray.CreateFromBuffer(buffer, shader.Layout);
      var geometry2 = VertexArray.CreateFromBuffer(buffer2, shader.Layout);

      var graphic = new Graphic(geometry, shader);
      var graphic2 = new Graphic(geometry2, shader);
      scene = new Scene(new List<Graphic>() { graphic, graphic2 });
      //MyVRageWindows.Init("HavokApp", new VRage.Utils.MyLog(), "cooldata", true, true);
      //var myLock = MyVRage.Platform.System.CreateSharedCriticalSection(true);

      //HkBaseSystem.Init(5242880, log => Console.WriteLine(log), true, myLock);

      GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
      GL.Enable(EnableCap.DepthTest);
  }

  readonly Camera camera = new Camera();

  protected override void OnRenderFrame(FrameEventArgs e)
  {
      base.OnRenderFrame(e);
      GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      scene?.Render();
      
      var speed = 0.5;
      var boundInterval = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 1000d * speed;

      var otherSpeed = 0.1;

      var interval = (float)((DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 1000d * otherSpeed) % 1);

      var ocilatingInterval = (Math.Sin(boundInterval * Math.PI) + 1d) / 2d;

      meshMatrix = Matrix4.CreateRotationY(MathHelper.DegreesToRadians((float)((boundInterval * 100d) % 360d))) *
        Matrix4.CreateRotationZ(MathHelper.DegreesToRadians((float)((boundInterval * 50d) % 360d))) *
        Matrix4.CreateRotationX(MathHelper.DegreesToRadians((float)((boundInterval * 25d) % 360d))) *
        Matrix4.CreateTranslation(new Vector3(
          0.5f - (float)ocilatingInterval,
          2,
          0
        ) / 2);

      var graphic = scene.Graphics[0];
      var graphic2 = scene.Graphics[1];

      graphic.SetUniform("ourColor", new Vector4(0, 0.5f, 0, 0));
      graphic2.SetUniform("ourColor", new Vector4(0.5f, 0, 0, 1));

      var meshMatrix2 = Matrix4.Identity;

      var cameraPos = new Vector3(
        (float)Math.Sin((double)interval * Math.PI * 2) * 2,
        2f,
        (float)Math.Cos((double)interval * Math.PI * 2) * 2
      );
      camera.Matrix = Matrix4.LookAt(cameraPos, new Vector3(0, 0, 0),  new Vector3(0, 1, 0));

      graphic.SetMatrixUniform("transform", meshMatrix * camera.ViewMatrix);
      graphic2.SetMatrixUniform("transform", meshMatrix2 * camera.ViewMatrix);

      SwapBuffers();
  }

  Matrix4 meshMatrix = Matrix4.Identity;

  protected override void OnUpdateFrame(FrameEventArgs e)
  {
      base.OnUpdateFrame(e);

      var input = KeyboardState;

      if (input.IsKeyDown(Keys.Escape))
      {
          Close();
      }
  }

  protected override void OnResize(ResizeEventArgs e)
  {
      base.OnResize(e);

      // When the window gets resized, we have to call GL.Viewport to resize OpenGL's viewport to match the new size.
      // If we don't, the NDC will no longer be correct.
      GL.Viewport(0, 0, Size.X, Size.Y);
      float aspect = Size.X / (float)Size.Y;
      camera.ProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(70.0f), aspect, 0.1f, 100.0f);
  }
  protected override void OnMove(WindowPositionEventArgs e)
  {
    base.OnMove(e);
    
    //camera.ProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(70.0f), Size.X / Size.Y, 0.1f, 100.0f);
  }
  protected override void OnUnload()
  {
      GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
      GL.BindVertexArray(0);
      GL.UseProgram(0);

      //boundScene?.Dispose();

      base.OnUnload();
  }
}
