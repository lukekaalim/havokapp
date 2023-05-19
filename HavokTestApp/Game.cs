using System;
using System.Collections.Generic;
using System.Linq;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

using HavokTestApp.Engine;

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

      var tl = new Vector3(0, 0, 0);
      var tr = new Vector3(0, 1, 0);
      var bl = new Vector3(1, 0, 0);
      var br = new Vector3(1, 1, 0);

      var plane = new Vector3[] {
        tl, tr, bl,
        
        bl, tr, br,
      }.Select(v => (v * 0.5f) + new Vector3(-0.25f, -0.25f, 0)).ToArray();
      var forward = new Vector3(0, 0, -0.25f);

      Vector3[] RotateVectors(Vector3[] vectors, Matrix4 rotation) {
        return vectors.Select(v => {
          return new Vector3(
            new Vector4((v + forward), 0) * rotation
          );
        }).ToArray();
      }
      var cube2 = new Vector3[][] {
        RotateVectors(plane, Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0))),
        RotateVectors(plane, Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90))),
        RotateVectors(plane, Matrix4.CreateRotationX(MathHelper.DegreesToRadians(180))),
        RotateVectors(plane, Matrix4.CreateRotationX(MathHelper.DegreesToRadians(270))),

        RotateVectors(plane, Matrix4.CreateRotationY(MathHelper.DegreesToRadians(90))),
        RotateVectors(plane, Matrix4.CreateRotationY(MathHelper.DegreesToRadians(270))),
      }.SelectMany(vs => vs).ToArray();

      var cube = new Vector3[4 * plane.Length].Select((_, index) => {
        var vertexIndex = index % plane.Length;
        int planeIndex = index / plane.Length;
        var rotation = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(planeIndex * 90));
        var v4 = new Vector4((plane[vertexIndex] + forward), 0) * rotation;
        return new Vector3(v4);
      }).ToArray();

      var fragmentShader = """
      #version 330

      out vec4 outputColor;

      uniform vec4 ourColor;
      in vec3 indexColor;

      void main()
      {
          outputColor = vec4(indexColor, 1.0);
      }
      """;

      var vertexShader = """
      #version 330 core

      in vec3 aPosition;

      uniform mat4 transform;
      out vec3 indexColor;

      void main(void)
      {
        gl_Position = vec4(aPosition, 1.0f) * transform;
        
        float r, g, b;
        int index = gl_VertexID * 10;
        r = (index % 256) / 255.0f;
        g = ((index / 256) % 256) / 255.0f;
        b = ((index / (256 * 256)) % 256) / 255.0f;
        indexColor = vec3(r, g, b);
      }
      """;
      var shader = ShaderProgram.CreateFromSouceCode(fragmentShader, vertexShader);
      var buffer = VertexBuffer.CreateFromVertices(cube2);
      var geometry = VertexArray.CreateFromBuffer(buffer, cube2.Length * 3, ShaderProgram.Layout.Calculate(shader));

      var graphic = new Graphic(geometry, shader);
      var graphic2 = new Graphic(geometry, shader);
      scene = new Scene(new List<Graphic>() { graphic, graphic2 });

      GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
      GL.Enable(EnableCap.DepthTest);
  }

  protected override void OnRenderFrame(FrameEventArgs e)
  {
      base.OnRenderFrame(e);
      GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      scene?.Render();
      
      var speed = 0.5;
      var boundInterval = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 1000d * speed;
      var ocilatingInterval = (Math.Sin(boundInterval * Math.PI) + 1d) / 2d;
      var color = new Vector4(
        (float)ocilatingInterval,
        0f,
        1f - (float)ocilatingInterval,
        1f
      );
      meshMatrix = //Matrix4.CreateRotationZ(MathHelper.DegreesToRadians((float)ocilatingInterval * 360))
        //*
        Matrix4.CreateRotationY(MathHelper.DegreesToRadians((float)((boundInterval * 100d) % 360d))) *
        Matrix4.CreateRotationZ(MathHelper.DegreesToRadians((float)((boundInterval * 50d) % 360d))) *
        Matrix4.CreateRotationX(MathHelper.DegreesToRadians((float)((boundInterval * 25d) % 360d))) *
        Matrix4.CreateTranslation(new Vector3(
          0.5f - (float)ocilatingInterval,
          0,
          0
        ) / 2);
      //Console.WriteLine((float)((boundInterval * 100d) % 360d));

      var graphic = scene.Graphics[0];
      var graphic2 = scene.Graphics[1];

      //graphic.SetUniform("ourColor", new Vector4(1, 1, 1, 0));
      var meshMatrix2 = 
        Matrix4.CreateRotationY(MathHelper.DegreesToRadians((float)((boundInterval * 80) % 360d))) *
        Matrix4.CreateRotationX(MathHelper.DegreesToRadians((float)((boundInterval * 10) % 360d))) *
        Matrix4.CreateRotationZ(MathHelper.DegreesToRadians((float)((boundInterval * 5) % 360d))) *
        Matrix4.CreateTranslation(new Vector3(
          0,
          0.5f - (float)ocilatingInterval,
          0
        ) / 2);
      graphic.SetMatrixUniform("transform", meshMatrix);
      graphic2.SetMatrixUniform("transform", meshMatrix2);

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
      //GL.Viewport(0, 0, Size.X, Size.Y);
  }
  protected override void OnMove(WindowPositionEventArgs e)
  {
    base.OnMove(e);

    //GL.Viewport(0, 0, Size.X, Size.Y);
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
