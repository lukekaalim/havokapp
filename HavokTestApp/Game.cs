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

using Sandbox.Engine.Physics;
using Sandbox.Game;
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
      indexColorShader = LKEngine.Shaders.IndexColorShader.CreateProgram();
      var cube3 = LKEngine.Geometry.Cube.GetCubeVertices(0.5f);
      var cube4 = LKEngine.Geometry.Cube.GetCubeVertices(1f);

      var beegCube = LKEngine.Geometry.Cube.GetCubeVertices(1f);

      var buffer = VertexBuffer.CreateFromVertices(cube3);
      var buffer2 = VertexBuffer.CreateFromVertices(cube4);
      var buffer3 = VertexBuffer.CreateFromVertices(beegCube);


      var shader = LKEngine.Shaders.IndexColorShader.CreateProgram();

      var geometry = VertexArray.CreateFromBuffer(buffer, shader.Layout);
      var geometry2 = VertexArray.CreateFromBuffer(buffer2, shader.Layout);
      var geometry3 = VertexArray.CreateFromBuffer(buffer3, shader.Layout);

      var graphic = new Graphic(geometry, shader);
      var graphic2 = new Graphic(geometry2, shader);
      var graphic3 = new Graphic(geometry3, shader);
      
      graphic3.SetUniform("ourColor", new Vector4(0f, 0, 1f, 1));
      scene = new Scene(new List<Graphic>() { graphic3 });
      //MyVRageWindows.Init("HavokApp", new VRage.Utils.MyLog(), "cooldata", true, true);
      //var myLock = MyVRage.Platform.System.CreateSharedCriticalSection(true);

      MyVRageWindows.Init("HavokTest", new VRage.Utils.MyLog(), "cool_path", true, true);
      var myLock = MyVRage.Platform.System.CreateSharedCriticalSection(spinLock: true);

      HkBaseSystem.Init(16777216, message => Console.WriteLine(message), true, myLock);
      string[] keyCodes = HkBaseSystem.GetKeyCodes();
      foreach (string text in keyCodes)
      {
        if (!string.IsNullOrWhiteSpace(text))
        {
          Console.WriteLine("HkCode: " + text);
        }
      }

      HkVDB.Port = 25001;
      HkVDB.Start();
      HkBaseSystem.EnableAssert(-668493307, enable: true);
      HkBaseSystem.EnableAssert(952495168, enable: true);
      HkBaseSystem.EnableAssert(1501626980, enable: true);
      HkBaseSystem.EnableAssert(-258736554, enable: true);
      HkBaseSystem.EnableAssert(524771844, enable: true);
      HkBaseSystem.EnableAssert(1081361407, enable: true);
      HkBaseSystem.EnableAssert(-1383504214, enable: true);
      HkBaseSystem.EnableAssert(-265005969, enable: true);
      HkBaseSystem.EnableAssert(1976984315, enable: true);
      HkBaseSystem.EnableAssert(-252450131, enable: true);
      HkBaseSystem.EnableAssert(-1400416854, enable: true);

      var worldInfo = HkWorld.CInfo.Create();
      worldInfo.SimulationType = HkWorld.SimulationType.SIMULATION_TYPE_DISCRETE;
      //worldInfo.EnableDeactivation = false;
      worldInfo.Gravity = new VRageMath.Vector3(0f, -.08f, 0);
      //worldInfo.EnableSimulationIslands = false;
      world = new HkWorld(true, 100f, 5f, false, 4);
      //world.Gravity = VRageMath.Vector3.Zero;

      Console.WriteLine(HkBaseSystem.GetVersionInfo());
      
      
      //world.OnRigidBodyActivated += (a) => Console.WriteLine("ACTIVEATED");

      //world.Gravity = new VRageMath.Vector3(0, 0.1f, 0);

      var rigidbodyInfo = new HkRigidBodyCinfo() {
        Position = new VRageMath.Vector3(0, -5f, 0),
        Rotation = VRageMath.Quaternion.Identity,
        LinearVelocity = new VRageMath.Vector3(0f, 0.01f, 0f),
        AngularVelocity = new VRageMath.Vector3(1f, 0f, 0f),

        CenterOfMass = new VRageMath.Vector3(0, 0, 0),
        //SolverDeactivation = HkSolverDeactivation.Off,
        //MaxLinearVelocity = 1000f,
        LinearDamping = 0.5f,
        AngularDamping = 0.5f,
        MotionType = HkMotionType.Fixed,
        Restitution = 0.5f,
        Friction = 2f,
        QualityType = HkCollidableQualityType.Fixed,
        Mass = 10f,
        Shape = new HkBoxShape(new VRageMath.Vector3(5f, .5f, 5f))
      };

      rigidbody = new HkRigidBody(rigidbodyInfo);
      //rigidbody.GetRigidBodyMatrix(out VRageMath.Matrix matrix);
      
      //var r2 = new HkRigidBody(rigidbodyInfo);
      world.AddRigidBody(rigidbody);
      //world.AddRigidBody(r2);
      rigidbody.Activate();
      //rigidbody.EnableDeactivation = false;
      //rigidbody.AddGravity();

      jobs = new HkJobQueue();

      

      //rigidbody.Gravity = new VRageMath.Vector3(0f, 0.01f, 0f);
      //rigidbody.AddGravity();

      GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
      GL.Enable(EnableCap.DepthTest);
  }
  HkRigidBody rigidbody;
  HkWorld world;
  HkJobQueue jobs;

  long count = 0;

  event Action OnRender;

  ShaderProgram indexColorShader;
  void AddBody() {
    var vertices = LKEngine.Geometry.Cube.GetCubeVertices(1f);
    var buffer = VertexBuffer.CreateFromVertices(vertices);
    var geometry = VertexArray.CreateFromBuffer(buffer, indexColorShader.Layout);
    var graphic = new Graphic(geometry, indexColorShader);
    var rigidbody = new HkRigidBody(new HkRigidBodyCinfo() {
      //LinearVelocity = new VRageMath.Vector3(0f, -2.5f, 0f),
      //AngularVelocity = new VRageMath.Vector3(0f, 0f, 0f),

      Position = new VRageMath.Vector3(0, 2f, 0),
      Rotation = VRageMath.Quaternion.Identity,
      //LinearDamping = 0.5f,
      //AngularDamping = 0.5f,
      MotionType = HkMotionType.Dynamic,
      //Restitution = 0.5f,
      //Friction = 1f,
      Mass = 10f,
      Shape = new HkBoxShape(new VRageMath.Vector3(0.5f, 0.5f, 0.5f))
    });
    scene.Graphics.Add(graphic);
    graphic.SetUniform("ourColor", new Vector4((float)Random.Shared.NextDouble(), (float)Random.Shared.NextDouble(), (float)Random.Shared.NextDouble() ,0));
    world.AddRigidBody(rigidbody);
    rigidbody.Activate();
    rigidbody.ApplyForce(5f, new VRageMath.Vector3((Random.Shared.NextDouble() * 10) - 5, -10, (Random.Shared.NextDouble() * 10) - 5));
    rigidbody.EnableDeactivation = false;

    OnRender += () => {
      var pos = rigidbody.Position;
      var quat = rigidbody.Rotation;
      var meshMatrix = Matrix4.CreateFromQuaternion(new Quaternion(quat.X, quat.Y, quat.Z, quat.W))
        * Matrix4.CreateTranslation(pos.X, pos.Y, pos.Z);

      graphic.SetMatrixUniform("transform", meshMatrix * camera.ViewMatrix);
    };
  }

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
      HkBaseSystem.OnSimulationFrameStarted(count++);
	    world.ExecutePendingCriticalOperations();
      world.UnmarkForWrite();
      world.StepSimulation(1.0f / 60.0f / 20f, false);
      world.MarkForWrite();

      var islands = new List<HkSimulationIslandInfo>();
      world.ReadSimulationIslandInfos(islands);
      
      //var bd = rigidbody.GetBody();
      //var pos = rigidbody.Position;
      //var quat = rigidbody.Rotation;
      //var v = rigidbody.Position;
      //v.Add(new VRageMath.Vector3(0, 0.01f, 0));
      //rigidbody.Position = VRageMath.Vector3.Zero;
      //rigidbody.ApplyForce(1, new VRageMath.Vector3(0, 1f, 0));
      //rigidbody.MarkedForVelocityRecompute = true;

      HkBaseSystem.OnSimulationFrameFinished();
      //Console.WriteLine(pos);


      //meshMatrix = Matrix4.CreateFromQuaternion(new Quaternion(quat.X, quat.Y, quat.Z, quat.W)) * Matrix4.CreateTranslation(pos.X, pos.Y, pos.Z);

      //var graphic = scene.Graphics[0];
     // var graphic2 = scene.Graphics[1];

      //graphic.SetUniform("ourColor", new Vector4(0, 0.5f, 0, 0));
      //graphic2.SetUniform("ourColor", new Vector4(0.5f, 0, 0, 1));

      var meshMatrix2 = Matrix4.Identity;

      var cameraPos = new Vector3(
        (float)Math.Sin((double)interval * Math.PI * 2) * 10,
        10f,
        (float)Math.Cos((double)interval * Math.PI * 2) * 10
      );
      camera.Matrix = Matrix4.LookAt(cameraPos, new Vector3(0, 0, 0),  new Vector3(0, 1, 0));

      //graphic.SetMatrixUniform("transform", meshMatrix * camera.ViewMatrix);
      //graphic2.SetMatrixUniform("transform", meshMatrix2 * camera.ViewMatrix);
      
      scene.Graphics[0].SetMatrixUniform("transform", Matrix4.CreateScale(10, 1f, 10) * Matrix4.CreateTranslation(0, -5f, 0) * camera.ViewMatrix);

      
      HkVDB.StepVDB(world, (1.0f / 60.0f / 10f));

      OnRender.InvokeIfNotNull();

      SwapBuffers();
  }
  Camera camera = new Camera();

  Matrix4 meshMatrix = Matrix4.Identity;

  protected override void OnUpdateFrame(FrameEventArgs e)
  {
      base.OnUpdateFrame(e);

      var input = KeyboardState;

      if (input.IsKeyDown(Keys.Escape))
      {
          Close();
      }
      if (input.IsKeyDown(Keys.Space))
      {
        AddBody();
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
