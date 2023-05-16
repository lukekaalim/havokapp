using System;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

using HavokTestApp.Engine;

namespace HavokTestApp;

public class Game : GameWindow
{
  Scene.Binding boundScene;

  public Game(
    GameWindowSettings gameWindowSettings,
    NativeWindowSettings nativeWindowSettings
  ) : base(gameWindowSettings, nativeWindowSettings) {}

  protected override void OnLoad()
  {
      base.OnLoad();

      var vertices = new Vector3[] {
        new Vector3(-0.5f, -0.5f, 0.0f),
        new Vector3(0.5f, -0.5f, 0.0f),
        new Vector3(0.0f,  0.5f, 0.0f),
      };

      var fragmentShader = new Shader("""
      #version 330

      out vec4 outputColor;

      uniform vec4 ourColor;

      void main()
      {
          outputColor = ourColor;
      }
      """, ShaderType.FragmentShader);
      var vertexShader = new Shader("""
      #version 330 core

      in vec3 aPosition;

      uniform mat4 transform;

      void main(void)
      {
        gl_Position = vec4(aPosition, 1.0f) * transform;
      }
      """, ShaderType.VertexShader);
      var program = new ShaderProgram(vertexShader, fragmentShader);

      var mesh = new Mesh(vertices, program);
      var scene = new Scene(new [] { mesh });
      boundScene = scene.Bind();

      boundScene?.Meshes[0].SetMatrixUniform("transform", ref meshMatrix);

      GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
  }

  protected override void OnRenderFrame(FrameEventArgs e)
  {
      base.OnRenderFrame(e);
      GL.Clear(ClearBufferMask.ColorBufferBit);
      boundScene?.Render();
      var speed = 0.5;
      var boundInterval = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 1000d * speed;
      var ocilatingInterval = (Math.Sin(boundInterval * Math.PI) + 1d) / 2d;
      var color = new Vector4(
        (float)ocilatingInterval,
        0f,
        1f - (float)ocilatingInterval,
        1f
      );
      meshMatrix = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians((float)ocilatingInterval * 360));
      boundScene?.Meshes[0].SetUniform("ourColor", color);
      boundScene?.Meshes[0].SetMatrixUniform("transform", ref meshMatrix);
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
  }
  protected override void OnUnload()
  {
      GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
      GL.BindVertexArray(0);
      GL.UseProgram(0);

      boundScene?.Dispose();

      base.OnUnload();
  }
}
