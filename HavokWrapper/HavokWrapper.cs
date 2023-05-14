using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using Havok.Utils;
using Microsoft.CodeAnalysis;
using VRage.Collections;
using VRage.Library.Collections.Comparers;
using VRage.Library.Threading;
using VRageMath;

namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class IsReadOnlyAttribute : Attribute
	{
	}
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class IsUnmanagedAttribute : Attribute
	{
	}
}
[AttributeUsage(AttributeTargets.Method)]
internal sealed class MonoPInvokeCallbackAttribute : Attribute
{
	public MonoPInvokeCallbackAttribute(Type t)
	{
	}
}
namespace Havok
{
	public enum HkCharacterStateType
	{
		HK_CHARACTER_ON_GROUND,
		HK_CHARACTER_JUMPING,
		HK_CHARACTER_IN_AIR,
		HK_CHARACTER_CLIMBING
	}
	public class HkCharacterProxy : HkReferenceObject
	{
		public bool Jump;

		public bool WantJump;

		public bool AtLadder;

		public float PosX;

		public float PosY;

		public Vector3 Gravity;

		private Vector3 m_up;

		private Vector3 m_forward;

		private HkShape m_shape;

		private HkpShapePhantom m_phantom;

		public Vector3 Position
		{
			get
			{
				return HkCharacterProxy_GetPosition(base.NativeObject);
			}
			set
			{
				HkCharacterProxy_SetPosition(base.NativeObject, value);
			}
		}

		public Vector3 LinearVelocity
		{
			get
			{
				return HkCharacterProxy_GetLinearVelocity(base.NativeObject);
			}
			set
			{
				HkCharacterProxy_SetLinearVelocity(base.NativeObject, value);
			}
		}

		public Vector3 Up
		{
			get
			{
				return m_up;
			}
			set
			{
				m_up = value;
				HkCharacterProxy_SetUp(base.NativeObject, value);
			}
		}

		public Vector3 Forward
		{
			get
			{
				return m_forward;
			}
			set
			{
				m_forward = value;
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkCharacterProxy_Create(IntPtr info);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCharacterProxy_GetPosition(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxy_SetPosition(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern int HkCharacterProxy_GetState(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxy_SetState(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxy_StepSimulation(IntPtr instance, float timeInSec, float posX, float posY, [MarshalAs(UnmanagedType.I1)] bool jump, [MarshalAs(UnmanagedType.I1)] bool wantJump, [MarshalAs(UnmanagedType.I1)] bool atLadder, Vector3 gravity, Vector3 up, Vector3 forward);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCharacterProxy_GetLinearVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxy_SetLinearVelocity(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxy_SetUp(IntPtr instance, Vector3 value);

		public HkCharacterProxy(HkCharacterProxyCinfo characterProxyCinfo)
		{
			m_up = characterProxyCinfo.Up;
			m_forward = characterProxyCinfo.Forward;
			m_phantom = characterProxyCinfo.ShapePhantom;
			m_shape = ((HkSimpleShapePhantom)characterProxyCinfo.ShapePhantom).Shape;
			m_handle = HkCharacterProxy_Create(characterProxyCinfo.NativeObject);
		}

		public HkShape GetShape()
		{
			return m_shape;
		}

		public HkCharacterStateType GetState()
		{
			return (HkCharacterStateType)HkCharacterProxy_GetState(base.NativeObject);
		}

		public void SetState(HkCharacterStateType state)
		{
			HkCharacterProxy_SetState(base.NativeObject, (int)state);
		}

		public void StepSimulation(float timeInSec)
		{
			HkCharacterProxy_StepSimulation(base.NativeObject, timeInSec, PosX, PosY, Jump, WantJump, AtLadder, Gravity, Up, Forward);
			Jump = false;
			m_phantom.SetTransform(Matrix.CreateWorld(Position, Forward, Up));
		}
	}
	public class HkCharacterProxyCinfo : HkReferenceObject
	{
		public Vector3 Forward;

		private HkpShapePhantom m_shapePhantom;

		public Vector3 Position
		{
			get
			{
				return HkCharacterProxyCinfo_GetPosition(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetPosition(base.NativeObject, value);
			}
		}

		public Vector3 Velocity
		{
			get
			{
				return HkCharacterProxyCinfo_GetVelocity(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetVelocity(base.NativeObject, value);
			}
		}

		public float DynamicFriction
		{
			get
			{
				return HkCharacterProxyCinfo_GetDynamicFriction(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetDynamicFriction(base.NativeObject, value);
			}
		}

		public float StaticFriction
		{
			get
			{
				return HkCharacterProxyCinfo_GetStaticFriction(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetStaticFriction(base.NativeObject, value);
			}
		}

		public float KeepContactTolerance
		{
			get
			{
				return HkCharacterProxyCinfo_GetKeepContactTolerance(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetKeepContactTolerance(base.NativeObject, value);
			}
		}

		public Vector3 Up
		{
			get
			{
				return HkCharacterProxyCinfo_GetUp(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetUp(base.NativeObject, value);
			}
		}

		public float ExtraUpStaticFriction
		{
			get
			{
				return HkCharacterProxyCinfo_GetExtraUpStaticFriction(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetExtraUpStaticFriction(base.NativeObject, value);
			}
		}

		public float ExtraDownStaticFriction
		{
			get
			{
				return HkCharacterProxyCinfo_GetExtraDownStaticFriction(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetExtraDownStaticFriction(base.NativeObject, value);
			}
		}

		public HkpShapePhantom ShapePhantom
		{
			get
			{
				return m_shapePhantom;
			}
			set
			{
				HkCharacterProxyCinfo_SetShapePhantom(base.NativeObject, value.NativeObject);
				m_shapePhantom = value;
			}
		}

		public float KeepDistance
		{
			get
			{
				return HkCharacterProxyCinfo_GetKeepDistance(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetKeepDistance(base.NativeObject, value);
			}
		}

		public float ContactAngleSensitivity
		{
			get
			{
				return HkCharacterProxyCinfo_GetContactAngleSensitivity(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetContactAngleSensitivity(base.NativeObject, value);
			}
		}

		public int UserPlanes
		{
			get
			{
				return HkCharacterProxyCinfo_GetUserPlanes(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetUserPlanes(base.NativeObject, value);
			}
		}

		public float MaxCharacterSpeedForSolver
		{
			get
			{
				return HkCharacterProxyCinfo_GetMaxCharacterSpeedForSolver(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetMaxCharacterSpeedForSolver(base.NativeObject, value);
			}
		}

		public float CharacterStrength
		{
			get
			{
				return HkCharacterProxyCinfo_GetCharacterStrength(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetCharacterStrength(base.NativeObject, value);
			}
		}

		public float CharacterMass
		{
			get
			{
				return HkCharacterProxyCinfo_GetCharacterMass(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetCharacterMass(base.NativeObject, value);
			}
		}

		public float MaxSlope
		{
			get
			{
				return HkCharacterProxyCinfo_GetMaxSlope(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetMaxSlope(base.NativeObject, value);
			}
		}

		public float PenetrationRecoverySpeed
		{
			get
			{
				return HkCharacterProxyCinfo_GetPenetrationRecoverySpeed(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetPenetrationRecoverySpeed(base.NativeObject, value);
			}
		}

		public int MaxCastIterations
		{
			get
			{
				return HkCharacterProxyCinfo_GetMaxCastIterations(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetMaxCastIterations(base.NativeObject, value);
			}
		}

		public bool RefreshManifoldInCheckSupport
		{
			get
			{
				return HkCharacterProxyCinfo_GetRefreshManifoldInCheckSupport(base.NativeObject);
			}
			set
			{
				HkCharacterProxyCinfo_SetRefreshManifoldInCheckSupport(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkCharacterProxyCinfo_Create();

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCharacterProxyCinfo_GetPosition(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetPosition(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCharacterProxyCinfo_GetVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetVelocity(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterProxyCinfo_GetDynamicFriction(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetDynamicFriction(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterProxyCinfo_GetStaticFriction(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetStaticFriction(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterProxyCinfo_GetKeepContactTolerance(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetKeepContactTolerance(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCharacterProxyCinfo_GetUp(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetUp(IntPtr instance, Vector3 up);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterProxyCinfo_GetExtraUpStaticFriction(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetExtraUpStaticFriction(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterProxyCinfo_GetExtraDownStaticFriction(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetExtraDownStaticFriction(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetShapePhantom(IntPtr instance, IntPtr value);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkCharacterProxyCinfo_GetShapePhantom(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterProxyCinfo_GetKeepDistance(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetKeepDistance(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterProxyCinfo_GetContactAngleSensitivity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetContactAngleSensitivity(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern int HkCharacterProxyCinfo_GetUserPlanes(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetUserPlanes(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterProxyCinfo_GetMaxCharacterSpeedForSolver(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetMaxCharacterSpeedForSolver(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterProxyCinfo_GetCharacterStrength(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetCharacterStrength(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterProxyCinfo_GetCharacterMass(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetCharacterMass(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterProxyCinfo_GetMaxSlope(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetMaxSlope(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterProxyCinfo_GetPenetrationRecoverySpeed(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetPenetrationRecoverySpeed(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern int HkCharacterProxyCinfo_GetMaxCastIterations(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetMaxCastIterations(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkCharacterProxyCinfo_GetRefreshManifoldInCheckSupport(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterProxyCinfo_SetRefreshManifoldInCheckSupport(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		public HkCharacterProxyCinfo()
		{
			m_handle = HkCharacterProxyCinfo_Create();
		}
	}
	public class HkCharacterRigidBody : HkReferenceObject
	{
		public bool Jump;

		public bool WantJump;

		public bool AtLadder;

		public bool Supported;

		public float PosX;

		public float PosY;

		public float Speed;

		public float Elevate;

		public Vector3 Gravity;

		public Vector3 SupportNormal;

		public Vector3 ElevateVector;

		public Vector3 ElevateUpVector;

		public Vector3 AngularVelocity;

		public Vector3 GroundVelocity;

		public const int FLOATING_OBJECT = 255;

		public const int MANIPULATED_OBJECT = 254;

		public const int CHARACTER_OBJECT = 253;

		public Vector3 InterpolatedVelocity;

		private const float HK_CHARACTER_MOTION_GAIN_0 = 0f;

		private const float HK_CHARACTER_MOTION_GAIN = 1f;

		private float m_jumpHeight;

		private HkShape m_shape;

		private HkShape m_crouchShape;

		private HkRigidBody m_hitRigidBody;

		private int m_supportCacheVersion;

		private List<HkRigidBody> m_supportingRigidBodiesCache = new List<HkRigidBody>();

		public Vector3 Position
		{
			get
			{
				return HkCharacterRigidBody_GetPosition(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBody_SetPosition(base.NativeObject, value);
			}
		}

		public Vector3 LinearVelocity
		{
			get
			{
				return HkCharacterRigidBody_GetLinearVelocity(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBody_SetLinearVelocity(base.NativeObject, value);
			}
		}

		public bool ContactPointCallbackEnabled
		{
			get
			{
				return m_hitRigidBody.ContactSoundCallbackEnabled;
			}
			set
			{
				m_hitRigidBody.ContactSoundCallbackEnabled = value;
			}
		}

		public bool UseSupportInfoQuery
		{
			get
			{
				return HkCharacterRigidBody_GetUseSupportInfoQuery(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBody_SetUseSupportInfoQuery(base.NativeObject, value);
			}
		}

		public Vector3 Forward
		{
			get
			{
				return GetRigidBodyTransform().Forward;
			}
			set
			{
				Matrix world = GetRigidBodyTransform();
				world.Forward = value;
				SetRigidBodyTransform(ref world);
			}
		}

		public Vector3 Up
		{
			get
			{
				return GetRigidBodyTransform().Up;
			}
			set
			{
				Matrix world = GetRigidBodyTransform();
				world.Up = value;
				SetRigidBodyTransform(ref world);
			}
		}

		public float MaxSlope
		{
			get
			{
				return HkCharacterRigidBody_GetMaxSlope(m_handle);
			}
			set
			{
				HkCharacterRigidBody_SetMaxSlope(m_handle, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkCharacterRigidBody_Create(IntPtr characterRigidBodyCinfo, float maxCharacterSpeed);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkCharacterRigidBody_GetCharacterRigidbody(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetWalkingState(IntPtr instance, IntPtr shape, float jumpHeight, float gainSpeed, float maxCharacterSpeed);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetFlyingState(IntPtr instance, IntPtr shape, float maxCharacterSpeed, float maxAcceleration);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetLadderState(IntPtr instance, float maxCharacterSpeed, float maxAcceleration);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetDefaultShape(IntPtr instance, IntPtr shape);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetShapeForCrouch(IntPtr instance, IntPtr shape);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCharacterRigidBody_GetPosition(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetPosition(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern int HkCharacterRigidBody_GetState(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetState(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_StepSimulation(IntPtr instance, float timeInSec, [MarshalAs(UnmanagedType.I1)] bool Jump, [MarshalAs(UnmanagedType.I1)] bool WantJump, [MarshalAs(UnmanagedType.I1)] bool AtLadder, float PosX, float PosY, float Speed, float Elevate, Vector3 Up, Vector3 Forward, Vector3 ElevateVector, Vector3 ElevateUpVector, Vector3 Gravity, float myJumpHeight, out Vector3 AngularVelocity);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_UpdateVelocity(IntPtr instance, float timeInSec, [MarshalAs(UnmanagedType.I1)] bool Supported, Vector3 AngularVelocity, Quaternion DesiredOrientation);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_UpdateSupport(IntPtr instance, float timeInSec);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetRigidBodyTransform(IntPtr instance, Matrix world);

		[DllImport("Havok.dll")]
		private static extern Matrix HkCharacterRigidBody_GetRigidBodyTransform(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCharacterRigidBody_GetLinearVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetLinearVelocity(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_ApplyLinearImpulse(IntPtr instance, Vector3 impulse);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_ApplyAngularImpulse(IntPtr instance, Vector3 impulse);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetSupportDistance(IntPtr instance, float distance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetHardSupportDistance(IntPtr instance, float distance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCharacterRigidBody_GetAngularVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetAngularVelocity(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkCharacterRigidBody_IsSupportedByFloatingObject(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkCharacterRigidBody_IsSupported(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCharacterRigidBody_GetSupportNormal(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCharacterRigidBody_GetGroundVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkCharacterRigidBody_GetUseSupportInfoQuery(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetUseSupportInfoQuery(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetPreviousSupportedState(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool supported);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_ResetSurfaceVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_SetMaxSlope(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterRigidBody_GetMaxSlope(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBody_GetSupportBodies(IntPtr instance, out int size, out int version, out IntPtr list);

		public HkCharacterRigidBody(HkCharacterRigidBodyCinfo characterRigidBodyCinfo, float maxCharacterSpeed, object physicsBody)
		{
			m_handle = HkCharacterRigidBody_Create(characterRigidBodyCinfo.NativeObject, maxCharacterSpeed);
			Up = characterRigidBodyCinfo.Up;
			Forward = Vector3.Forward;
			m_jumpHeight = characterRigidBodyCinfo.JumpHeight;
			m_shape = characterRigidBodyCinfo.Shape;
			m_crouchShape = characterRigidBodyCinfo.CrouchShape;
			IntPtr body = HkCharacterRigidBody_GetCharacterRigidbody(base.NativeObject);
			m_hitRigidBody = new HkRigidBody(body);
			m_hitRigidBody.UserObject = physicsBody;
			SetWalkingState(m_jumpHeight, 1f, maxCharacterSpeed);
		}

		public void SetWalkingState(float jumpHeight, float gainSpeed, float maxCharacterSpeed)
		{
			HkCharacterRigidBody_SetWalkingState(base.NativeObject, m_shape.NativeObject, jumpHeight, gainSpeed, maxCharacterSpeed);
		}

		public void SetFlyingState(float maxCharacterSpeed, float maxAcceleration)
		{
			HkCharacterRigidBody_SetFlyingState(base.NativeObject, m_shape.NativeObject, maxCharacterSpeed, maxAcceleration);
		}

		public void SetLadderState(float maxCharacterSpeed, float maxAcceleration)
		{
			HkCharacterRigidBody_SetLadderState(base.NativeObject, maxCharacterSpeed, maxAcceleration);
			SetFlyingState(maxCharacterSpeed, maxAcceleration);
		}

		public void SetDefaultShape()
		{
			HkCharacterRigidBody_SetDefaultShape(base.NativeObject, m_shape.NativeObject);
		}

		public void SetShapeForCrouch()
		{
			HkCharacterRigidBody_SetShapeForCrouch(base.NativeObject, m_crouchShape.NativeObject);
		}

		public HkShape GetShape()
		{
			return m_shape;
		}

		public HkCharacterStateType GetState()
		{
			return (HkCharacterStateType)HkCharacterRigidBody_GetState(base.NativeObject);
		}

		public void SetState(HkCharacterStateType state)
		{
			HkCharacterRigidBody_SetState(base.NativeObject, (int)state);
		}

		public void EnableFlyingState(bool enable, float maxCharacterSpeed, float maxFlyingSpeed, float maxAcceleration)
		{
			if (enable)
			{
				SetFlyingState(maxFlyingSpeed, maxAcceleration);
			}
			else
			{
				SetWalkingState(m_jumpHeight, 0f, maxCharacterSpeed);
			}
		}

		public void EnableLadderState(bool enable, float maxCharacterSpeed, float maxAcceleration)
		{
			if (enable)
			{
				SetLadderState(maxCharacterSpeed, maxAcceleration);
			}
			else
			{
				SetWalkingState(m_jumpHeight, 1f, maxCharacterSpeed);
			}
			LinearVelocity = Vector3.Zero;
			AngularVelocity = Vector3.Zero;
		}

		public void StepSimulation(float timeInSec)
		{
			HkCharacterRigidBody_StepSimulation(base.NativeObject, timeInSec, Jump, WantJump, AtLadder, PosX, PosY, Speed, Elevate, Up, Forward, ElevateVector, ElevateUpVector, Gravity, m_jumpHeight, out AngularVelocity);
			Supported = HkCharacterRigidBody_IsSupported(base.NativeObject);
			HkCharacterRigidBody_UpdateVelocity(base.NativeObject, timeInSec, Supported, AngularVelocity, Quaternion.CreateFromForwardUp(Forward, Up));
			SupportNormal = HkCharacterRigidBody_GetSupportNormal(base.NativeObject);
			GroundVelocity = HkCharacterRigidBody_GetGroundVelocity(base.NativeObject);
			UpdateSupportEntities();
		}

		public void UpdateSupport(float timeInSec)
		{
			HkCharacterRigidBody_UpdateSupport(base.NativeObject, timeInSec);
			Supported = HkCharacterRigidBody_IsSupported(base.NativeObject);
			SupportNormal = HkCharacterRigidBody_GetSupportNormal(base.NativeObject);
			GroundVelocity = HkCharacterRigidBody_GetGroundVelocity(base.NativeObject);
			UpdateSupportEntities();
		}

		private unsafe void UpdateSupportEntities()
		{
			HkCharacterRigidBody_GetSupportBodies(m_handle, out var size, out var version, out var list);
			if (m_supportCacheVersion == version)
			{
				return;
			}
			m_supportingRigidBodiesCache.Clear();
			void** ptr = (void**)list.ToPointer();
			for (int i = 0; i < size; i++)
			{
				HkRigidBody hkRigidBody = HkRigidBody.Get(new IntPtr(ptr[i]));
				if (hkRigidBody != null)
				{
					m_supportingRigidBodiesCache.Add(hkRigidBody);
				}
			}
			m_supportCacheVersion = version;
		}

		public Matrix GetRigidBodyTransform()
		{
			return HkCharacterRigidBody_GetRigidBodyTransform(base.NativeObject);
		}

		public void SetRigidBodyTransform(ref Matrix world)
		{
			HkCharacterRigidBody_SetRigidBodyTransform(base.NativeObject, world);
		}

		public void ApplyLinearImpulse(Vector3 impulse)
		{
			HkCharacterRigidBody_ApplyLinearImpulse(base.NativeObject, impulse);
		}

		public void ApplyAngularImpulse(Vector3 impulse)
		{
			HkCharacterRigidBody_ApplyAngularImpulse(base.NativeObject, impulse);
		}

		public void SetSupportDistance(float distance)
		{
			HkCharacterRigidBody_SetSupportDistance(base.NativeObject, distance);
		}

		public void SetHardSupportDistance(float distance)
		{
			HkCharacterRigidBody_SetHardSupportDistance(base.NativeObject, distance);
		}

		public HkEntity GetRigidBody()
		{
			return m_hitRigidBody;
		}

		public HkRigidBody GetHitRigidBody()
		{
			return m_hitRigidBody;
		}

		public Vector3 GetAngularVelocity()
		{
			return HkCharacterRigidBody_GetAngularVelocity(base.NativeObject);
		}

		public void SetAngularVelocity(Vector3 value)
		{
			HkCharacterRigidBody_SetAngularVelocity(base.NativeObject, value);
		}

		public void SetCollisionFilterInfo(uint info)
		{
			m_hitRigidBody.SetCollisionFilterInfo(info);
		}

		public bool IsSupportedByFloatingObject()
		{
			return HkCharacterRigidBody_IsSupportedByFloatingObject(base.NativeObject);
		}

		public List<HkRigidBody> GetSupportInfo()
		{
			return m_supportingRigidBodiesCache;
		}

		public void ResetSurfaceVelocity()
		{
			HkCharacterRigidBody_ResetSurfaceVelocity(m_handle);
		}

		public void SetPreviousSupportedState(bool supported)
		{
			HkCharacterRigidBody_SetPreviousSupportedState(m_handle, supported);
		}

		protected override void Dispose(bool disposing)
		{
			if (m_hitRigidBody != null)
			{
				m_hitRigidBody.Dispose();
				m_hitRigidBody = null;
			}
			base.Dispose(disposing);
		}
	}
	public class HkCharacterRigidBodyCinfo : HkReferenceObject
	{
		private HkShape m_crouchShape;

		private float m_jumpHeight;

		public int CollisionFilterInfo
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetCollisionFilterInfo(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetCollisionFilterInfo(base.NativeObject, value);
			}
		}

		public HkShape Shape
		{
			get
			{
				IntPtr shape = HkCharacterRigidBodyCinfo_GetShape(base.NativeObject);
				return new HkShape(shape);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetShape(base.NativeObject, value.NativeObject);
			}
		}

		public HkShape CrouchShape
		{
			get
			{
				return m_crouchShape;
			}
			set
			{
				m_crouchShape = value;
			}
		}

		public Vector3 Position
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetPosition(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetPosition(base.NativeObject, value);
			}
		}

		public Quaternion Rotation
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetRotation(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetRotation(base.NativeObject, value);
			}
		}

		public float Mass
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetMass(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetMass(base.NativeObject, value);
			}
		}

		public float JumpHeight
		{
			get
			{
				return m_jumpHeight;
			}
			set
			{
				m_jumpHeight = value;
			}
		}

		public float Friction
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetFriction(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetFriction(base.NativeObject, value);
			}
		}

		public float MaxLinearVelocity
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetMaxLinearVelocity(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetMaxLinearVelocity(base.NativeObject, value);
			}
		}

		public float AllowedPenetrationDepth
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetAllowedPenetrationDepth(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetAllowedPenetrationDepth(base.NativeObject, value);
			}
		}

		public Vector3 Up
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetUp(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetUp(base.NativeObject, value);
			}
		}

		public float MaxSlope
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetMaxSlope(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetMaxSlope(base.NativeObject, value);
			}
		}

		public float MaxForce
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetMaxForce(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetMaxForce(base.NativeObject, value);
			}
		}

		public float UnweldingHeightOffsetFactor
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetUnweldingHeightOffsetFactor(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetUnweldingHeightOffsetFactor(base.NativeObject, value);
			}
		}

		public float MaxSpeedForSimplexSolver
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetMaxSpeedForSimplexSolver(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetMaxSpeedForSimplexSolver(base.NativeObject, value);
			}
		}

		public float SupportDistance
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetSupportDistance(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetSupportDistance(base.NativeObject, value);
			}
		}

		public float HardSupportDistance
		{
			get
			{
				return HkCharacterRigidBodyCinfo_GetHardSupportDistance(base.NativeObject);
			}
			set
			{
				HkCharacterRigidBodyCinfo_SetHardSupportDistance(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkCharacterRigidBodyCinfo_Create();

		[DllImport("Havok.dll")]
		private static extern int HkCharacterRigidBodyCinfo_GetCollisionFilterInfo(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetCollisionFilterInfo(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkCharacterRigidBodyCinfo_GetShape(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetShape(IntPtr instance, IntPtr value);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCharacterRigidBodyCinfo_GetPosition(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetPosition(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern Quaternion HkCharacterRigidBodyCinfo_GetRotation(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetRotation(IntPtr instance, Quaternion value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterRigidBodyCinfo_GetMass(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetMass(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterRigidBodyCinfo_GetFriction(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetFriction(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterRigidBodyCinfo_GetMaxLinearVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetMaxLinearVelocity(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterRigidBodyCinfo_GetAllowedPenetrationDepth(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetAllowedPenetrationDepth(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCharacterRigidBodyCinfo_GetUp(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetUp(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterRigidBodyCinfo_GetMaxSlope(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetMaxSlope(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterRigidBodyCinfo_GetMaxForce(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetMaxForce(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterRigidBodyCinfo_GetUnweldingHeightOffsetFactor(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetUnweldingHeightOffsetFactor(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterRigidBodyCinfo_GetMaxSpeedForSimplexSolver(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetMaxSpeedForSimplexSolver(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterRigidBodyCinfo_GetSupportDistance(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetSupportDistance(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCharacterRigidBodyCinfo_GetHardSupportDistance(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCharacterRigidBodyCinfo_SetHardSupportDistance(IntPtr instance, float value);

		public HkCharacterRigidBodyCinfo()
		{
			m_handle = HkCharacterRigidBodyCinfo_Create();
			m_jumpHeight = 1f;
		}
	}
	public class HkBallAndSocketConstraintData : HkConstraintData
	{
		[DllImport("Havok.dll")]
		private static extern IntPtr HkBallAndSocketConstraintData_Create();

		[DllImport("Havok.dll")]
		private static extern void HkBallAndSocketConstraintData_SetInBodySpaceInternal(IntPtr instance, Vector3 pivotA, Vector3 pivotB);

		public HkBallAndSocketConstraintData()
		{
			m_handle = HkBallAndSocketConstraintData_Create();
		}

		public void SetInBodySpaceInternal(ref Vector3 pivotA, ref Vector3 pivotB)
		{
			HkBallAndSocketConstraintData_SetInBodySpaceInternal(base.NativeObject, pivotA, pivotB);
		}
	}
	public class HkBreakableConstraintData : HkConstraintData
	{
		public float Threshold
		{
			get
			{
				return HkBreakableConstraintData_GetThreshold(base.NativeObject);
			}
			set
			{
				HkBreakableConstraintData_SetThreshold(base.NativeObject, value);
			}
		}

		public bool RemoveFromWorldOnBrake
		{
			get
			{
				return HkBreakableConstraintData_GetRemoveFromWorldOnBrake(base.NativeObject);
			}
			set
			{
				HkBreakableConstraintData_SetRemoveFromWorldOnBrake(base.NativeObject, value);
			}
		}

		public bool ReapplyVelocityOnBreak
		{
			get
			{
				return HkBreakableConstraintData_GetReapplyVelocityOnBreak(base.NativeObject);
			}
			set
			{
				HkBreakableConstraintData_SetReapplyVelocityOnBreak(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkBreakableConstraintData_Create(IntPtr data);

		[DllImport("Havok.dll")]
		private static extern float HkBreakableConstraintData_GetThreshold(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkBreakableConstraintData_SetThreshold(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkBreakableConstraintData_GetRemoveFromWorldOnBrake(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkBreakableConstraintData_SetRemoveFromWorldOnBrake(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkBreakableConstraintData_GetReapplyVelocityOnBreak(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkBreakableConstraintData_SetReapplyVelocityOnBreak(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkBreakableConstraintData_GetIsBroken(IntPtr instance, IntPtr constraint);

		public HkBreakableConstraintData(HkConstraintData data)
		{
			m_handle = HkBreakableConstraintData_Create(data.NativeObject);
		}

		public bool getIsBroken(HkConstraint constraint)
		{
			return HkBreakableConstraintData_GetIsBroken(base.NativeObject, constraint.NativeObject);
		}
	}
	public class HkCogWheelConstraintData : HkConstraintData
	{
		[DllImport("Havok.dll")]
		private static extern IntPtr HkCogWheelConstraintData_Create();

		[DllImport("Havok.dll")]
		private static extern void HkCogWheelConstraintData_SetInWorldSpace(IntPtr instance, Matrix bodyATransform, Matrix bodyBTransform, Vector3 rotationPivotA, Vector3 rotationAxisA, float radiusA, Vector3 rotationPivotB, Vector3 rotationAxisB, float radiusB);

		[DllImport("Havok.dll")]
		private static extern void HkCogWheelConstraintData_SetInBodySpaceInternal(IntPtr instance, Vector3 rotationPivotAInA, Vector3 rotationAxisAInA, float radiusA, Vector3 rotationPivotBInB, Vector3 rotationAxisBInB, float radiusB);

		public HkCogWheelConstraintData()
		{
			m_handle = HkCogWheelConstraintData_Create();
		}

		public void SetInWorldSpace(Matrix bodyATransform, Matrix bodyBTransform, ref Vector3 rotationPivotA, ref Vector3 rotationAxisA, float radiusA, ref Vector3 rotationPivotB, ref Vector3 rotationAxisB, float radiusB)
		{
			HkCogWheelConstraintData_SetInWorldSpace(base.NativeObject, bodyATransform, bodyBTransform, rotationPivotA, rotationAxisA, radiusA, rotationPivotB, rotationAxisB, radiusB);
		}

		public void SetInBodySpaceInternal(ref Vector3 rotationPivotAInA, ref Vector3 rotationAxisAInA, float radiusA, ref Vector3 rotationPivotBInB, ref Vector3 rotationAxisBInB, float radiusB)
		{
			HkCogWheelConstraintData_SetInBodySpaceInternal(base.NativeObject, rotationAxisAInA, rotationPivotAInA, radiusA, rotationPivotBInB, rotationAxisBInB, radiusB);
		}
	}
	public enum HkSolvingMethod
	{
		MethodStabilized,
		MethodOld
	}
	public enum HkConstraintPriority
	{
		Psi = 1,
		Toi = 3,
		ToiHigher = 4,
		ToiForced = 5
	}
	public delegate void ConstraintCallback(HkConstraint constraint);
	public class HkConstraint : HkReferenceObject
	{
		private delegate void ReadConstraintsCallback(IntPtr constraintList, int constraintCount, IntPtr userData);

		public Action OnAddedToWorldCallback;

		public Action OnRemovedFromWorldCallback;

		private bool m_inWorld;

		private bool m_enabled;

		private bool m_forceDisabled;

		private HkConstraintListener m_listener;

		private HkConstraintData m_constraintData;

		public HkConstraintPriority Priority
		{
			get
			{
				return (HkConstraintPriority)HkConstraint_GetPriority(base.NativeObject);
			}
			set
			{
				HkConstraint_SetPriority(base.NativeObject, (int)value);
			}
		}

		public bool WantRuntime
		{
			get
			{
				return HkConstraint_GetWantRuntime(base.NativeObject);
			}
			set
			{
				HkConstraint_SetWantRuntime(base.NativeObject, value);
			}
		}

		public bool InWorld => HkConstraint_IsInWorld(base.NativeObject);

		public HkRigidBody RigidBodyA => HkRigidBody.Get(HkConstraint_GetRigidBodyA(base.NativeObject));

		public HkRigidBody RigidBodyB => HkRigidBody.Get(HkConstraint_GetRigidBodyB(base.NativeObject));

		public bool Enabled
		{
			get
			{
				return HkConstraint_GetEnabled(base.NativeObject);
			}
			set
			{
				m_enabled = value;
				HkConstraint_SetEnabled(base.NativeObject, !m_forceDisabled && value);
			}
		}

		public bool ForceDisabled
		{
			get
			{
				return m_forceDisabled;
			}
			set
			{
				m_forceDisabled = value;
				HkConstraint_SetEnabled(base.NativeObject, !value && m_enabled);
			}
		}

		public HkConstraintData ConstraintData => m_constraintData;

		public ulong UserData
		{
			get
			{
				return HkConstraint_GetUserData(base.NativeObject);
			}
			set
			{
				HkConstraint_SetUserData(base.NativeObject, value);
			}
		}

		public event ConstraintCallback OnBreakingConstraintCallback;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkConstraint_Create(IntPtr entityA, IntPtr entityB, IntPtr data, int priority);

		[DllImport("Havok.dll")]
		private static extern void HkConstraint_AddConstraintListener(IntPtr instance, IntPtr listener);

		[DllImport("Havok.dll")]
		private static extern void HkConstraint_RemoveConstraintListener(IntPtr instance, IntPtr listener);

		[DllImport("Havok.dll")]
		private static extern void HkConstraint_ReplaceEntity(IntPtr instance, IntPtr oldEntity, IntPtr newEntity);

		[DllImport("Havok.dll")]
		private static extern void HkConstraint_SetVirtualMassInverse(IntPtr instance, Vector4 invMassA, Vector4 invMassB);

		[DllImport("Havok.dll")]
		private static extern int HkConstraint_GetPriority(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkConstraint_SetPriority(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkConstraint_GetWantRuntime(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkConstraint_SetWantRuntime(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkConstraint_IsInWorld(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkConstraint_GetRigidBodyA(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkConstraint_GetRigidBodyB(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkConstraint_GetEnabled(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkConstraint_SetEnabled(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport("Havok.dll")]
		private static extern void HkConstraint_GetPivotsInWorld(IntPtr instance, out Vector3 outPivotA, out Vector3 outPivotB);

		[DllImport("Havok.dll")]
		private static extern ulong HkConstraint_GetUserData(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkConstraint_SetUserData(IntPtr instance, ulong value);

		[DllImport("Havok.dll")]
		private static extern void HkConstraint_AddCenterOfMassModifierAtom(IntPtr instance, Vector3 modifierA, Vector3 modifierB);

		[DllImport("Havok.dll")]
		private static extern void HkConstraint_FindConnectedConstraints(IntPtr rigidBody, ReadConstraintsCallback reader, IntPtr userData);

		public HkConstraint(HkRigidBody entityA, HkRigidBody entityB, HkConstraintData constraintData)
			: this(entityA, entityB, constraintData, HkConstraintPriority.Psi)
		{
		}

		public HkConstraint(HkRigidBody entityA, HkRigidBody entityB, HkConstraintData constraintData, HkConstraintPriority priority)
			: base(HkConstraint_Create(entityA.NativeObject, entityB.NativeObject, constraintData.NativeObject, (int)priority), track: true)
		{
			m_constraintData = constraintData;
			SetCallbacksToListener();
		}

		public void ReplaceEntity(HkRigidBody oldEntity, HkRigidBody newEntity)
		{
			HkConstraint_ReplaceEntity(base.NativeObject, oldEntity.NativeObject, newEntity.NativeObject);
		}

		public void SetVirtualMassInverse(Vector4 invMassA, Vector4 invMassB)
		{
			HkConstraint_SetVirtualMassInverse(base.NativeObject, invMassA, invMassB);
		}

		public void AddCenterOfMassModifierAtom(ref Vector3 modifierA, ref Vector3 modifierB)
		{
			HkConstraint_AddCenterOfMassModifierAtom(base.NativeObject, modifierA, modifierB);
		}

		public void GetPivotsInWorld(out Vector3 pivotA, out Vector3 pivotB)
		{
			HkConstraint_GetPivotsInWorld(base.NativeObject, out pivotA, out pivotB);
		}

		public void FireBreakingConstraintCallback()
		{
			this.OnBreakingConstraintCallback?.Invoke(this);
		}

		internal HkConstraint(IntPtr constraintInstance, HkConstraintData constraintData)
			: base(constraintInstance, track: true)
		{
			HkReferenceObject.HkReferenceObject_AddReference(constraintInstance);
			m_constraintData = constraintData;
			SetCallbacksToListener();
		}

		internal virtual void OnAddedToWorld()
		{
			m_constraintData.OnAddedToWorld(this);
			NotifyAddedToWorld();
			m_inWorld = true;
		}

		internal virtual void OnRemovedFromWorld()
		{
			if (m_inWorld)
			{
				m_constraintData.OnRemovedFromWorld(this);
				NotifyRemovedFromWorld();
				m_inWorld = false;
			}
		}

		public void NotifyAddedToWorld()
		{
			OnAddedToWorldCallback?.Invoke();
		}

		public void NotifyRemovedFromWorld()
		{
			OnRemovedFromWorldCallback?.Invoke();
		}

		protected override void Dispose(bool disposing)
		{
			HkConstraint_RemoveConstraintListener(base.NativeObject, m_listener.NativeObject);
			m_listener.Dispose();
			m_constraintData.Dispose();
			base.Dispose(disposing);
		}

		private void SetCallbacksToListener()
		{
			m_listener = new HkConstraintListener(this);
			HkConstraint_AddConstraintListener(base.NativeObject, m_listener.NativeObject);
		}

		public static void GetAttachedConstraints(HkRigidBody rigidBody, List<HkConstraint> constraintsOut)
		{
			GCHandle value = GCHandle.Alloc(constraintsOut);
			HkConstraint_FindConnectedConstraints(rigidBody.NativeObject, ConstraintReader, GCHandle.ToIntPtr(value));
		}

		[MonoPInvokeCallback(typeof(ReadConstraintsCallback))]
		private unsafe static void ConstraintReader(IntPtr constraintList, int constraintCount, IntPtr userData)
		{
			void** ptr = (void**)constraintList.ToPointer();
			List<HkConstraint> list = (List<HkConstraint>)GCHandle.FromIntPtr(userData).Target;
			for (int i = 0; i < constraintCount; i++)
			{
				if (HkHandle.TryGetHandle<HkConstraint>(new IntPtr(ptr[i]), out var handle))
				{
					list.Add(handle);
				}
			}
		}
	}
	public class HkConstraintData : HkReferenceObject
	{
		public float MaximumLinearImpulse
		{
			get
			{
				return HkConstraintData_GetMaximumLinearImpulse(base.NativeObject);
			}
			set
			{
				HkConstraintData_SetMaximumLinearImpulse(base.NativeObject, value);
			}
		}

		public float MaximumAngularImpulse
		{
			get
			{
				return HkConstraintData_GetMaximumAngularImpulse(base.NativeObject);
			}
			set
			{
				HkConstraintData_SetMaximumAngularImpulse(base.NativeObject, value);
			}
		}

		public float BreachImpulse
		{
			get
			{
				return HkConstraintData_GetBreachImpulse(base.NativeObject);
			}
			set
			{
				HkConstraintData_SetBreachImpulse(base.NativeObject, value);
			}
		}

		public float InertiaStabilizationFactor
		{
			get
			{
				return HkConstraintData_GetInertiaStabilizationFactor(base.NativeObject);
			}
			set
			{
				HkConstraintData_SetInertiaStabilizationFactor(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern float HkConstraintData_GetMaximumLinearImpulse(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkConstraintData_SetMaximumLinearImpulse(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkConstraintData_GetMaximumAngularImpulse(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkConstraintData_SetMaximumAngularImpulse(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkConstraintData_GetBreachImpulse(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkConstraintData_SetBreachImpulse(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkConstraintData_GetInertiaStabilizationFactor(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkConstraintData_SetInertiaStabilizationFactor(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkConstraintData_SetSolvingMethod(IntPtr instance, int method);

		public virtual void OnAddedToWorld(HkConstraint constraint)
		{
		}

		public virtual void OnRemovedFromWorld(HkConstraint constraint)
		{
		}

		public virtual void SetCurrentAngle(float angle)
		{
		}

		public void SetSolvingMethod(HkSolvingMethod method)
		{
			HkConstraintData_SetSolvingMethod(base.NativeObject, (int)method);
		}
	}
	internal class HkConstraintListener : HkHandle
	{
		private delegate void OnAdded(IntPtr listener);

		private delegate void OnRemoved(IntPtr listener);

		private delegate void OnBreaking(IntPtr listener);

		private readonly HkConstraint m_constraint;

		private static readonly OnAdded OnAddedHolder = OnConstraintAdded;

		private static readonly OnRemoved OnRemovedHolder = OnConstraintRemoved;

		private static readonly OnBreaking OnBreakingHolder = OnConstraintBreak;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkConstraintListener_Create();

		[DllImport("Havok.dll")]
		private static extern void HkConstraintListener_Release(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkConstraintListener_SetCallbacks(IntPtr instance, OnAdded onAdded, OnRemoved onRemoved, OnBreaking onBreaking);

		public HkConstraintListener(HkConstraint constraint)
			: base(HkConstraintListener_Create(), track: true)
		{
			m_constraint = constraint;
			HkConstraintListener_SetCallbacks(m_handle, OnAddedHolder, OnRemovedHolder, OnBreakingHolder);
		}

		protected override void Dispose(bool disposing)
		{
			HkConstraintListener_Release(m_handle);
		}

		[MonoPInvokeCallback(typeof(OnAdded))]
		private static void OnConstraintAdded(IntPtr handle)
		{
			if (HkHandle.TryGetHandle<HkConstraintListener>(handle, out var handle2))
			{
				handle2.m_constraint.OnAddedToWorld();
			}
		}

		[MonoPInvokeCallback(typeof(OnRemoved))]
		private static void OnConstraintRemoved(IntPtr handle)
		{
			if (HkHandle.TryGetHandle<HkConstraintListener>(handle, out var handle2))
			{
				handle2.m_constraint.OnRemovedFromWorld();
			}
		}

		[MonoPInvokeCallback(typeof(OnBreaking))]
		private static void OnConstraintBreak(IntPtr handle)
		{
			if (HkHandle.TryGetHandle<HkConstraintListener>(handle, out var handle2))
			{
				handle2.m_constraint.FireBreakingConstraintCallback();
			}
		}
	}
	public class HkConstraintMotor : HkReferenceObject
	{
		internal HkConstraintMotor(IntPtr motor)
		{
			m_handle = motor;
		}
	}
	public class HkCustomWheelConstraintData : HkConstraintData
	{
		public bool LimitsEnabled
		{
			get
			{
				return HkCustomWheelConstraintData_GetLimitsEnabled(base.NativeObject);
			}
			set
			{
				HkCustomWheelConstraintData_SetLimitsEnabled(base.NativeObject, value);
			}
		}

		public float SuspensionMinLimit
		{
			get
			{
				return HkCustomWheelConstraintData_GetSuspensionMinLimit(base.NativeObject);
			}
			set
			{
				HkCustomWheelConstraintData_SetSuspensionMinLimit(base.NativeObject, value);
			}
		}

		public float SuspensionMaxLimit
		{
			get
			{
				return HkCustomWheelConstraintData_GetSuspensionMaxLimit(base.NativeObject);
			}
			set
			{
				HkCustomWheelConstraintData_SetSuspensionMaxLimit(base.NativeObject, value);
			}
		}

		public bool FrictionEnabled
		{
			get
			{
				return HkCustomWheelConstraintData_GetFrictionEnabled(base.NativeObject);
			}
			set
			{
				HkCustomWheelConstraintData_SetFrictionEnabled(base.NativeObject, value);
			}
		}

		public float MaxFrictionTorque
		{
			get
			{
				return HkCustomWheelConstraintData_GetMaxFrictionTorque(base.NativeObject);
			}
			set
			{
				HkCustomWheelConstraintData_SetMaxFrictionTorque(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkCustomWheelConstraintData_Create();

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkCustomWheelConstraintData_GetLimitsEnabled(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCustomWheelConstraintData_SetLimitsEnabled(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport("Havok.dll")]
		private static extern float HkCustomWheelConstraintData_GetSuspensionMinLimit(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCustomWheelConstraintData_SetSuspensionMinLimit(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkCustomWheelConstraintData_GetSuspensionMaxLimit(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCustomWheelConstraintData_SetSuspensionMaxLimit(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkCustomWheelConstraintData_GetFrictionEnabled(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCustomWheelConstraintData_SetFrictionEnabled(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport("Havok.dll")]
		private static extern float HkCustomWheelConstraintData_GetMaxFrictionTorque(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCustomWheelConstraintData_SetMaxFrictionTorque(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkCustomWheelConstraintData_SetInBodySpaceInternal(IntPtr instance, Vector3 pivotA, Vector3 pivotB, Vector3 axleA, Vector3 axleB, Vector3 suspensionAxisB, Vector3 steeringAxisB);

		[DllImport("Havok.dll")]
		private static extern void HkCustomWheelConstraintData_SetSuspensionStrength(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkCustomWheelConstraintData_SetSuspensionDamping(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkCustomWheelConstraintData_SetSteeringAngle(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkCustomWheelConstraintData_SetAngleLimits(IntPtr instance, float min, float max);

		[DllImport("Havok.dll")]
		private static extern float HkCustomWheelConstraintData_GetAngleLimitsMin(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern float HkCustomWheelConstraintData_GetAngleLimitsMax(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCustomWheelConstraintData_DisableLimits(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern float HkCustomWheelConstraintData_GetCurrentAngle(IntPtr constraint);

		[DllImport("Havok.dll")]
		private static extern void HkCustomWheelConstraintData_SetCurrentAngle(IntPtr constraint, float angle);

		public HkCustomWheelConstraintData()
		{
			m_handle = HkCustomWheelConstraintData_Create();
		}

		public void SetInBodySpaceInternal(ref Vector3 pivotA, ref Vector3 pivotB, ref Vector3 axleA, ref Vector3 axleB, ref Vector3 suspensionAxisB, ref Vector3 steeringAxisB)
		{
			HkCustomWheelConstraintData_SetInBodySpaceInternal(base.NativeObject, pivotA, pivotB, axleA, axleB, suspensionAxisB, steeringAxisB);
		}

		public void SetSuspensionStrength(float v)
		{
			HkCustomWheelConstraintData_SetSuspensionStrength(base.NativeObject, v);
		}

		public void SetSuspensionDamping(float v)
		{
			HkCustomWheelConstraintData_SetSuspensionDamping(base.NativeObject, v);
		}

		public void SetSteeringAngle(float v)
		{
			HkCustomWheelConstraintData_SetSteeringAngle(base.NativeObject, v);
		}

		public void SetAngleLimits(float min, float max)
		{
			HkCustomWheelConstraintData_SetAngleLimits(base.NativeObject, min, max);
		}

		public void GetAngleLimits(out float min, out float max)
		{
			min = HkCustomWheelConstraintData_GetAngleLimitsMin(base.NativeObject);
			max = HkCustomWheelConstraintData_GetAngleLimitsMax(base.NativeObject);
		}

		public void DisableLimits()
		{
			HkCustomWheelConstraintData_DisableLimits(base.NativeObject);
		}

		public static float GetCurrentAngle(HkConstraint constraint)
		{
			return HkCustomWheelConstraintData_GetCurrentAngle(constraint.NativeObject);
		}

		public static void SetCurrentAngle(HkConstraint constraint, float value)
		{
			HkCustomWheelConstraintData_SetCurrentAngle(constraint.NativeObject, value);
		}
	}
	public class HkFixedConstraintData : HkConstraintData
	{
		public new bool IsValid => HkFixedConstraintData_IsValid(base.NativeObject);

		public bool OldSolvingMethod
		{
			set
			{
				SetSolvingMethod(value ? HkSolvingMethod.MethodOld : HkSolvingMethod.MethodStabilized);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkFixedConstraintData_Create();

		[DllImport("Havok.dll")]
		private static extern void HkFixedConstraintData_SetInBodySpaceInternal(IntPtr instance, Matrix pivotA, Matrix pivotB);

		[DllImport("Havok.dll")]
		private static extern void HkFixedConstraintData_SetInWorldSpace(IntPtr instance, Matrix bodyATransform, Matrix bodyBTransform, Matrix pivot);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkFixedConstraintData_IsValid(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkFixedConstraintData_SetInertiaStabilizationFactor(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkFixedConstraintData_GetInertiaStabilizationFactor(IntPtr instance, out float outResult);

		[DllImport("Havok.dll")]
		private static extern float HkFixedConstraintData_GetSolverImpulseInLastStep(IntPtr constraint, byte constraintAtom);

		public HkFixedConstraintData()
		{
			m_handle = HkFixedConstraintData_Create();
		}

		public void SetInBodySpaceInternal(ref Matrix pivotA, ref Matrix pivotB)
		{
			HkFixedConstraintData_SetInBodySpaceInternal(base.NativeObject, pivotA, pivotB);
		}

		public void SetInWorldSpace(ref Matrix bodyATransform, ref Matrix bodyBTransform, ref Matrix pivot)
		{
			HkFixedConstraintData_SetInWorldSpace(base.NativeObject, bodyATransform, bodyBTransform, pivot);
		}

		public bool SetInertiaStabilizationFactor(float value)
		{
			return HkFixedConstraintData_SetInertiaStabilizationFactor(base.NativeObject, value);
		}

		public bool GetInertiaStabilizationFactor(out float result)
		{
			return HkFixedConstraintData_GetInertiaStabilizationFactor(base.NativeObject, out result);
		}

		public static float GetSolverImpulseInLastStep(HkConstraint constraint, byte constraintAtom)
		{
			return HkFixedConstraintData_GetSolverImpulseInLastStep(constraint.NativeObject, constraintAtom);
		}
	}
	public class HkHingeConstraintData : HkConstraintData
	{
		[DllImport("Havok.dll")]
		private static extern IntPtr HkHingeConstraintData_Create();

		[DllImport("Havok.dll")]
		private static extern void HkHingeConstraintData_SetInBodySpaceInternal(IntPtr instance, Vector3 pivotA, Vector3 pivotB, Vector3 axisA, Vector3 axisB);

		[DllImport("Havok.dll")]
		private static extern void HkHingeConstraintData_SetInWorldSpace(IntPtr instance, Matrix bodyATransform, Matrix bodyBTransform, Vector3 pivot, Vector3 axis);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkHingeConstraintData_SetInertiaStabilizationFactor(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkHingeConstraintData_GetInertiaStabilizationFactor(IntPtr instance, out float outResult);

		public HkHingeConstraintData()
		{
			m_handle = HkHingeConstraintData_Create();
		}

		public void SetInBodySpaceInternal(ref Vector3 pivotA, ref Vector3 pivotB, ref Vector3 axisA, ref Vector3 axisB)
		{
			HkHingeConstraintData_SetInBodySpaceInternal(base.NativeObject, pivotA, pivotB, axisA, axisB);
		}

		public void SetInWorldSpace(Matrix bodyATransform, Matrix bodyBTransform, ref Vector3 pivot, ref Vector3 axis)
		{
			HkHingeConstraintData_SetInWorldSpace(base.NativeObject, bodyATransform, bodyBTransform, pivot, axis);
		}

		public bool SetInertiaStabilizationFactor(float value)
		{
			return HkHingeConstraintData_SetInertiaStabilizationFactor(base.NativeObject, value);
		}

		public bool GetInertiaStabilizationFactor(out float result)
		{
			return HkHingeConstraintData_GetInertiaStabilizationFactor(base.NativeObject, out result);
		}

		internal HkHingeConstraintData(IntPtr data)
		{
			m_handle = data;
			HkReferenceObject.HkReferenceObject_AddReference(data);
		}
	}
	public class HkLimitedForceConstraintMotor : HkConstraintMotor
	{
		public float MinForce
		{
			get
			{
				return HkLimitedForceConstraintMotor_GetMinForce(base.NativeObject);
			}
			set
			{
				HkLimitedForceConstraintMotor_SetMinForce(base.NativeObject, value);
			}
		}

		public float MaxForce
		{
			get
			{
				return HkLimitedForceConstraintMotor_GetMaxForce(base.NativeObject);
			}
			set
			{
				HkLimitedForceConstraintMotor_SetMaxForce(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern float HkLimitedForceConstraintMotor_GetMinForce(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkLimitedForceConstraintMotor_SetMinForce(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkLimitedForceConstraintMotor_GetMaxForce(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkLimitedForceConstraintMotor_SetMaxForce(IntPtr instance, float value);

		internal HkLimitedForceConstraintMotor(IntPtr motor)
			: base(motor)
		{
		}
	}
	public class HkLimitedHingeConstraintData : HkConstraintData
	{
		private float m_currentAngle;

		private HkConstraintMotor m_motor;

		public HkConstraintMotor Motor
		{
			get
			{
				return m_motor;
			}
			set
			{
				m_motor = value;
				HkLimitedHingeConstraintData_SetMotor(base.NativeObject, value.NativeObject);
			}
		}

		public bool MotorEnabled => HkLimitedHingeConstraintData_IsMotorEnabled(base.NativeObject);

		public float TargetAngle
		{
			get
			{
				return HkLimitedHingeConstraintData_GetTargetAngle(base.NativeObject);
			}
			set
			{
				HkLimitedHingeConstraintData_SetTargetAngle(base.NativeObject, value);
			}
		}

		public float MaxFrictionTorque
		{
			get
			{
				return HkLimitedHingeConstraintData_GetMaxFrictionTorque(base.NativeObject);
			}
			set
			{
				HkLimitedHingeConstraintData_SetMaxFrictionTorque(base.NativeObject, value);
			}
		}

		public float MinAngularLimit
		{
			get
			{
				return HkLimitedHingeConstraintData_GetMinAngularLimit(base.NativeObject);
			}
			set
			{
				HkLimitedHingeConstraintData_SetMinAngularLimit(base.NativeObject, value);
			}
		}

		public float MaxAngularLimit
		{
			get
			{
				return HkLimitedHingeConstraintData_GetMaxAngularLimit(base.NativeObject);
			}
			set
			{
				HkLimitedHingeConstraintData_SetMaxAngularLimit(base.NativeObject, value);
			}
		}

		public Vector3 BodyAPos => HkLimitedHingeConstraintData_GetBodyAPos(base.NativeObject);

		public Vector3 BodyBPos => HkLimitedHingeConstraintData_GetBodyBPos(base.NativeObject);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkLimitedHingeConstraintData_Create();

		[DllImport("Havok.dll")]
		private static extern void HkLimitedHingeConstraintData_SetInBodySpaceInternal(IntPtr instance, Vector3 pivotA, Vector3 pivotB, Vector3 axisA, Vector3 axisB, Vector3 axisAPerp, Vector3 axisBPerp);

		[DllImport("Havok.dll")]
		private static extern void HkLimitedHingeConstraintData_SetInWorldSpace(IntPtr instance, Matrix bodyATransform, Matrix bodyBTransform, Vector3 pivot, Vector3 axis);

		[DllImport("Havok.dll")]
		private static extern void HkLimitedHingeConstraintData_SetMotor(IntPtr instance, IntPtr motor);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkLimitedHingeConstraintData_IsMotorEnabled(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkLimitedHingeConstraintData_SetMotorEnabled(IntPtr instance, IntPtr constraint, [MarshalAs(UnmanagedType.I1)] bool enabled);

		[DllImport("Havok.dll")]
		private static extern float HkLimitedHingeConstraintData_GetTargetAngle(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkLimitedHingeConstraintData_SetTargetAngle(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkLimitedHingeConstraintData_GetMaxFrictionTorque(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkLimitedHingeConstraintData_SetMaxFrictionTorque(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkLimitedHingeConstraintData_GetMinAngularLimit(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkLimitedHingeConstraintData_SetMinAngularLimit(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkLimitedHingeConstraintData_GetMaxAngularLimit(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkLimitedHingeConstraintData_SetMaxAngularLimit(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkLimitedHingeConstraintData_DisableLimits(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkLimitedHingeConstraintData_SetInertiaStabilizationFactor(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkLimitedHingeConstraintData_GetInertiaStabilizationFactor(IntPtr instance, out float outResult);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkLimitedHingeConstraintData_GetBodyAPos(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkLimitedHingeConstraintData_GetBodyBPos(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern byte HkLimitedHingeConstraintData_GetIsInitialized(IntPtr constraint);

		[DllImport("Havok.dll")]
		private static extern void HkLimitedHingeConstraintData_SetIsInitialized(IntPtr constraint, byte isInitialized);

		[DllImport("Havok.dll")]
		private static extern float HkLimitedHingeConstraintData_GetPreviousTargetAngle(IntPtr constraint);

		[DllImport("Havok.dll")]
		private static extern void HkLimitedHingeConstraintData_SetPreviousTargetAngle(IntPtr constraint, float previousTargetAngle);

		[DllImport("Havok.dll")]
		private static extern float HkLimitedHingeConstraintData_GetCurrentAngle(IntPtr constraint);

		[DllImport("Havok.dll")]
		private static extern void HkLimitedHingeConstraintData_SetCurrentAngle(IntPtr constraint, float value);

		public void SetInBodySpaceInternal(ref Vector3 pivotA, ref Vector3 pivotB, ref Vector3 axisA, ref Vector3 axisB, ref Vector3 axisAPerp, ref Vector3 axisBPerp)
		{
			HkLimitedHingeConstraintData_SetInBodySpaceInternal(base.NativeObject, pivotA, pivotB, axisA, axisB, axisAPerp, axisBPerp);
		}

		public HkLimitedHingeConstraintData()
		{
			m_handle = HkLimitedHingeConstraintData_Create();
			m_currentAngle = 0f;
		}

		public void SetMotorEnabled(HkConstraint constraint, bool enabled)
		{
			HkLimitedHingeConstraintData_SetMotorEnabled(base.NativeObject, constraint.NativeObject, enabled);
		}

		public void DisableLimits()
		{
			HkLimitedHingeConstraintData_DisableLimits(base.NativeObject);
		}

		public bool SetInertiaStabilizationFactor(float value)
		{
			return HkLimitedHingeConstraintData_SetInertiaStabilizationFactor(base.NativeObject, value);
		}

		public bool GetInertiaStabilizationFactor(out float result)
		{
			return HkLimitedHingeConstraintData_GetInertiaStabilizationFactor(base.NativeObject, out result);
		}

		public override void OnAddedToWorld(HkConstraint constraint)
		{
			SetCurrentAngle(constraint, m_currentAngle);
		}

		public override void OnRemovedFromWorld(HkConstraint constraint)
		{
			m_currentAngle = GetCurrentAngle(constraint);
		}

		public override void SetCurrentAngle(float angle)
		{
			m_currentAngle = angle;
		}

		public static byte GetIsInitialized(HkConstraint constraint)
		{
			return HkLimitedHingeConstraintData_GetIsInitialized(constraint.NativeObject);
		}

		public static void SetIsInitialized(HkConstraint constraint, byte isInitialized)
		{
			HkLimitedHingeConstraintData_SetIsInitialized(constraint.NativeObject, isInitialized);
		}

		public static float GetPreviousTargetAngle(HkConstraint constraint)
		{
			return HkLimitedHingeConstraintData_GetPreviousTargetAngle(constraint.NativeObject);
		}

		public static void SetPreviousTargetAngle(HkConstraint constraint, float previousTargetAngle)
		{
			HkLimitedHingeConstraintData_SetPreviousTargetAngle(constraint.NativeObject, previousTargetAngle);
		}

		public static float GetCurrentAngle(HkConstraint constraint)
		{
			return HkLimitedHingeConstraintData_GetCurrentAngle(constraint.NativeObject);
		}

		public static void SetCurrentAngle(HkConstraint constraint, float value)
		{
			HkLimitedHingeConstraintData_SetCurrentAngle(constraint.NativeObject, value);
			constraint.ConstraintData.SetCurrentAngle(value);
		}

		internal HkLimitedHingeConstraintData(IntPtr data)
		{
			m_handle = data;
			HkReferenceObject.HkReferenceObject_AddReference(data);
		}
	}
	public class HkMalleableConstraintData : HkConstraintData
	{
		public float Strength
		{
			get
			{
				return HkMalleableConstraintData_GetStrength(base.NativeObject);
			}
			set
			{
				HkMalleableConstraintData_SetStrength(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkMalleableConstraintData_Create(IntPtr data);

		[DllImport("Havok.dll")]
		private static extern float HkMalleableConstraintData_GetStrength(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkMalleableConstraintData_SetStrength(IntPtr instance, float value);

		public void SetData(HkConstraintData data)
		{
			m_handle = HkMalleableConstraintData_Create(data.NativeObject);
		}
	}
	public class HkPrismaticConstraintData : HkConstraintData
	{
		private HkConstraintMotor m_motor;

		public float MaximumLinearLimit
		{
			get
			{
				return HkPrismaticConstraintData_GetMaximumLinearLimit(base.NativeObject);
			}
			set
			{
				HkPrismaticConstraintData_SetMaximumLinearLimit(base.NativeObject, value);
			}
		}

		public float MinimumLinearLimit
		{
			get
			{
				return HkPrismaticConstraintData_GetMinimumLinearLimit(base.NativeObject);
			}
			set
			{
				HkPrismaticConstraintData_SetMinimumLinearLimit(base.NativeObject, value);
			}
		}

		public float MaxFrictionForce
		{
			get
			{
				return HkPrismaticConstraintData_GetMaxFrictionForce(base.NativeObject);
			}
			set
			{
				HkPrismaticConstraintData_SetMaxFrictionForce(base.NativeObject, value);
			}
		}

		public float TargetPosition
		{
			get
			{
				return HkPrismaticConstraintData_GetTargetPosition(base.NativeObject);
			}
			set
			{
				HkPrismaticConstraintData_SetTargetPosition(base.NativeObject, value);
			}
		}

		public HkConstraintMotor Motor
		{
			get
			{
				return m_motor;
			}
			set
			{
				m_motor = value;
				HkPrismaticConstraintData_SetMotor(base.NativeObject, value.NativeObject);
			}
		}

		public bool MotorEnabled => HkPrismaticConstraintData_IsMotorEnabled(base.NativeObject);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkPrismaticConstraintData_Create();

		[DllImport("Havok.dll")]
		private static extern void HkPrismaticConstraintData_SetInWorldSpace(IntPtr instance, Matrix bodyATransform, Matrix bodyBTransform, Vector3 pivot, Vector3 axis);

		[DllImport("Havok.dll")]
		private static extern void HkPrismaticConstraintData_SetInBodySpaceInternal(IntPtr instance, Vector3 bodyA, Vector3 bodyB, Vector3 axisA, Vector3 axisB, Vector3 axisAperp, Vector3 axisBperp);

		[DllImport("Havok.dll")]
		private static extern float HkPrismaticConstraintData_GetMaximumLinearLimit(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkPrismaticConstraintData_SetMaximumLinearLimit(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkPrismaticConstraintData_GetMinimumLinearLimit(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkPrismaticConstraintData_SetMinimumLinearLimit(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkPrismaticConstraintData_GetMaxFrictionForce(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkPrismaticConstraintData_SetMaxFrictionForce(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkPrismaticConstraintData_GetTargetPosition(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkPrismaticConstraintData_SetTargetPosition(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkPrismaticConstraintData_SetMotor(IntPtr instance, IntPtr motor);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkPrismaticConstraintData_IsMotorEnabled(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkPrismaticConstraintData_SetMotorEnabled(IntPtr instance, IntPtr constraint, [MarshalAs(UnmanagedType.I1)] bool enabled);

		[DllImport("Havok.dll")]
		private static extern float HkPrismaticConstraintData_GetCurrentPosition(IntPtr constraint);

		public HkPrismaticConstraintData()
		{
			m_handle = HkPrismaticConstraintData_Create();
		}

		public void SetInWorldSpace(Matrix bodyATransform, Matrix bodyBTransform, ref Vector3 pivot, ref Vector3 axis)
		{
			HkPrismaticConstraintData_SetInWorldSpace(base.NativeObject, bodyATransform, bodyBTransform, pivot, axis);
		}

		public void SetInBodySpaceInternal(ref Vector3 bodyA, ref Vector3 bodyB, ref Vector3 axisA, ref Vector3 axisB, ref Vector3 axisAperp, ref Vector3 axisBperp)
		{
			HkPrismaticConstraintData_SetInBodySpaceInternal(base.NativeObject, bodyA, bodyB, axisA, axisB, axisAperp, axisBperp);
		}

		public void SetMotorEnabled(HkConstraint constraint, bool enabled)
		{
			HkPrismaticConstraintData_SetMotorEnabled(base.NativeObject, constraint.NativeObject, enabled);
		}

		public static float GetCurrentPosition(HkConstraint constraint)
		{
			return HkPrismaticConstraintData_GetCurrentPosition(constraint.NativeObject);
		}
	}
	public class HkRopeConstraintData : HkConstraintData
	{
		public float Strength
		{
			get
			{
				return HkRopeConstraintData_GetStrength(base.NativeObject);
			}
			set
			{
				HkRopeConstraintData_SetStrength(base.NativeObject, value);
			}
		}

		public float LinearLimit
		{
			get
			{
				return HkRopeConstraintData_GetLinearLimit(base.NativeObject);
			}
			set
			{
				HkRopeConstraintData_SetLinearLimit(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkRopeConstraintData_Create();

		[DllImport("Havok.dll")]
		private static extern void HkRopeConstraintData_SetInBodySpaceInternal(IntPtr instance, Vector3 pivotA, Vector3 pivotB);

		[DllImport("Havok.dll")]
		private static extern float HkRopeConstraintData_Update(IntPtr instance, IntPtr constraint);

		[DllImport("Havok.dll")]
		private static extern float HkRopeConstraintData_GetStrength(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRopeConstraintData_SetStrength(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRopeConstraintData_GetLinearLimit(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRopeConstraintData_SetLinearLimit(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkRopeConstraintData_IsValid(IntPtr instance);

		public HkRopeConstraintData()
		{
			m_handle = HkRopeConstraintData_Create();
		}

		public void SetInBodySpaceInternal(ref Vector3 pivotA, ref Vector3 pivotB)
		{
			HkRopeConstraintData_SetInBodySpaceInternal(base.NativeObject, pivotA, pivotB);
		}

		public float Update(HkConstraint constraint)
		{
			return HkRopeConstraintData_Update(base.NativeObject, constraint.NativeObject);
		}
	}
	public class HkVelocityConstraintMotor : HkLimitedForceConstraintMotor
	{
		public float Tau
		{
			get
			{
				return HkVelocityConstraintMotor_GetTau(base.NativeObject);
			}
			set
			{
				HkVelocityConstraintMotor_SetTau(base.NativeObject, value);
			}
		}

		public float VelocityTarget
		{
			get
			{
				return HkVelocityConstraintMotor_GetVelocityTarget(base.NativeObject);
			}
			set
			{
				HkVelocityConstraintMotor_SetVelocityTarget(base.NativeObject, value);
			}
		}

		public bool ConstantRecoveryVelocity
		{
			get
			{
				return HkVelocityConstraintMotor_GetConstantRecoveryVelocity(base.NativeObject);
			}
			set
			{
				HkVelocityConstraintMotor_SetConstantRecoveryVelocity(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkVelocityConstraintMotor_Create(float velocityTarget, float maxForce);

		[DllImport("Havok.dll")]
		private static extern float HkVelocityConstraintMotor_GetTau(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkVelocityConstraintMotor_SetTau(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkVelocityConstraintMotor_GetVelocityTarget(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkVelocityConstraintMotor_SetVelocityTarget(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkVelocityConstraintMotor_GetConstantRecoveryVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkVelocityConstraintMotor_SetConstantRecoveryVelocity(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		public HkVelocityConstraintMotor(float velocityTarget, float maxForce)
			: base(HkVelocityConstraintMotor_Create(velocityTarget, maxForce))
		{
		}
	}
	public class HkWheelConstraintData : HkConstraintData
	{
		[DllImport("Havok.dll")]
		private static extern IntPtr HkWheelConstraintData_Create();

		[DllImport("Havok.dll")]
		private static extern void HkWheelConstraintData_SetInWorldSpace(IntPtr instance, Matrix wheelBody, Matrix chasisBody, Vector3 pivot, Vector3 axle, Vector3 suspensionAxis, Vector3 steeringAxis);

		[DllImport("Havok.dll")]
		private static extern void HkWheelConstraintData_SetInBodySpaceInternal(IntPtr instance, Vector3 pivotA, Vector3 pivotB, Vector3 axleA, Vector3 axleB, Vector3 suspensionAxisB, Vector3 steeringAxisB);

		[DllImport("Havok.dll")]
		private static extern void HkWheelConstraintData_SetSuspensionMinLimit(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkWheelConstraintData_SetSuspensionMaxLimit(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkWheelConstraintData_SetSuspensionStrength(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkWheelConstraintData_SetSuspensionDamping(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkWheelConstraintData_SetSteeringAngle(IntPtr instance, float value);

		public HkWheelConstraintData()
		{
			m_handle = HkWheelConstraintData_Create();
		}

		public void SetInWorldSpace(Matrix wheelBody, Matrix chasisBody, ref Vector3 pivot, ref Vector3 axle, ref Vector3 suspensionAxis, ref Vector3 steeringAxis)
		{
			HkWheelConstraintData_SetInWorldSpace(base.NativeObject, wheelBody, chasisBody, pivot, axle, suspensionAxis, steeringAxis);
		}

		public void SetInBodySpaceInternal(ref Vector3 pivotA, ref Vector3 pivotB, ref Vector3 axleA, ref Vector3 axleB, ref Vector3 suspensionAxisB, ref Vector3 steeringAxisB)
		{
			HkWheelConstraintData_SetInBodySpaceInternal(base.NativeObject, pivotA, pivotB, axleA, axleB, suspensionAxisB, steeringAxisB);
		}

		public void SetSuspensionMinLimit(float value)
		{
			HkWheelConstraintData_SetSuspensionMinLimit(base.NativeObject, value);
		}

		public void SetSuspensionMaxLimit(float value)
		{
			HkWheelConstraintData_SetSuspensionMaxLimit(base.NativeObject, value);
		}

		public void SetSuspensionStrength(float value)
		{
			HkWheelConstraintData_SetSuspensionStrength(base.NativeObject, value);
		}

		public void SetSuspensionDamping(float value)
		{
			HkWheelConstraintData_SetSuspensionDamping(base.NativeObject, value);
		}

		public void SetSteeringAngle(float value)
		{
			HkWheelConstraintData_SetSteeringAngle(base.NativeObject, value);
		}
	}
	internal class Core
	{
		public const string HAVOK_DLL = "Havok.dll";
	}
	public class HkdDecomposeFracture : HkdFracture
	{
		public float ClipZoneWidth
		{
			get
			{
				return HkdDecomposeFracture_GetClipZoneWidth(base.NativeObject);
			}
			set
			{
				HkdDecomposeFracture_SetClipZoneWidth(base.NativeObject, value);
			}
		}

		public float ShiftToSmallerCrossSection
		{
			get
			{
				return HkdDecomposeFracture_GetShiftToSmallerCrossSection(base.NativeObject);
			}
			set
			{
				HkdDecomposeFracture_SetShiftToSmallerCrossSection(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdDecomposeFracture_Create();

		[DllImport("Havok.dll")]
		private static extern float HkdDecomposeFracture_GetClipZoneWidth(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdDecomposeFracture_SetClipZoneWidth(IntPtr instance, float clipZoneWidth);

		[DllImport("Havok.dll")]
		private static extern float HkdDecomposeFracture_GetShiftToSmallerCrossSection(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdDecomposeFracture_SetShiftToSmallerCrossSection(IntPtr instance, float shiftToSmallerCrossSection);

		[DllImport("Havok.dll")]
		private static extern void HkdDecomposeFracture_SetGeometry(IntPtr instance, IntPtr geometry);

		public HkdDecomposeFracture()
			: base(HkdDecomposeFracture_Create())
		{
		}

		public void SetGeometry(HkReferenceObject data)
		{
			HkdDecomposeFracture_SetGeometry(base.NativeObject, data.NativeObject);
		}

		internal HkdDecomposeFracture(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public class HkdFracture : HkReferenceObject
	{
		public enum Type
		{
			Invalid = 0,
			SplitInHalf = 1,
			Wood = 2,
			RandomSplit = 3,
			Slice = 4,
			Pie = 5,
			Voronoi = 6,
			Debris = 7,
			Cutout = 8,
			Decompose = 9,
			Reserved1 = 12,
			Reserved2 = 13,
			NumTypes = 14
		}

		public enum RefitPhysicsType
		{
			None,
			ConvexHull,
			ShrinkToConvexHull
		}

		public const int MaxNumberOfChildNodes = 1024;

		public bool FlattenHierarchy
		{
			get
			{
				return HkdFracture_GetFlattenHierarchy(base.NativeObject);
			}
			set
			{
				HkdFracture_SetFlattenHierarchy(base.NativeObject, value);
			}
		}

		public RefitPhysicsType RefitType
		{
			get
			{
				return (RefitPhysicsType)HkdFracture_GetRefitType(base.NativeObject);
			}
			set
			{
				HkdFracture_SetRefitType(base.NativeObject, (int)value);
			}
		}

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdFracture_GetFlattenHierarchy(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdFracture_SetFlattenHierarchy(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool flattenHierarchy);

		[DllImport("Havok.dll")]
		private static extern int HkdFracture_GetRefitType(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdFracture_SetRefitType(IntPtr instance, int refitType);

		internal HkdFracture(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public class HkdRandomSplitFracture : HkdFracture
	{
		public const int MaxLevels = 4;

		public float RandomRange
		{
			get
			{
				return HkdRandomSplitFracture_GetRandomRange(base.NativeObject);
			}
			set
			{
				HkdRandomSplitFracture_SetRandomRange(base.NativeObject, value);
			}
		}

		public int RandomSeed4
		{
			get
			{
				return HkdRandomSplitFracture_GetRandomSeed(base.NativeObject, 4);
			}
			set
			{
				HkdRandomSplitFracture_SetRandomSeed(base.NativeObject, 4, value);
			}
		}

		public int RandomSeed3
		{
			get
			{
				return HkdRandomSplitFracture_GetRandomSeed(base.NativeObject, 3);
			}
			set
			{
				HkdRandomSplitFracture_SetRandomSeed(base.NativeObject, 3, value);
			}
		}

		public int RandomSeed2
		{
			get
			{
				return HkdRandomSplitFracture_GetRandomSeed(base.NativeObject, 2);
			}
			set
			{
				HkdRandomSplitFracture_SetRandomSeed(base.NativeObject, 2, value);
			}
		}

		public int RandomSeed1
		{
			get
			{
				return HkdRandomSplitFracture_GetRandomSeed(base.NativeObject, 1);
			}
			set
			{
				HkdRandomSplitFracture_SetRandomSeed(base.NativeObject, 1, value);
			}
		}

		public int NumObjectsOnLevel4
		{
			get
			{
				return HkdRandomSplitFracture_GetNumObjectsOnLevel(base.NativeObject, 4);
			}
			set
			{
				HkdRandomSplitFracture_SetNumObjectsOnLevel(base.NativeObject, 4, value);
			}
		}

		public int NumObjectsOnLevel3
		{
			get
			{
				return HkdRandomSplitFracture_GetNumObjectsOnLevel(base.NativeObject, 3);
			}
			set
			{
				HkdRandomSplitFracture_SetNumObjectsOnLevel(base.NativeObject, 3, value);
			}
		}

		public int NumObjectsOnLevel2
		{
			get
			{
				return HkdRandomSplitFracture_GetNumObjectsOnLevel(base.NativeObject, 2);
			}
			set
			{
				HkdRandomSplitFracture_SetNumObjectsOnLevel(base.NativeObject, 2, value);
			}
		}

		public int NumObjectsOnLevel1
		{
			get
			{
				return HkdRandomSplitFracture_GetNumObjectsOnLevel(base.NativeObject, 1);
			}
			set
			{
				HkdRandomSplitFracture_SetNumObjectsOnLevel(base.NativeObject, 1, value);
			}
		}

		public Vector4 SplitGeometryScale
		{
			get
			{
				return HkdRandomSplitFracture_GetSplitGeometryScale(base.NativeObject);
			}
			set
			{
				HkdRandomSplitFracture_SetSplitGeometryScale(base.NativeObject, value);
			}
		}

		public bool SplitLargestVolumesFirst
		{
			get
			{
				return HkdRandomSplitFracture_GetSplitLargestVolumesFirst(base.NativeObject);
			}
			set
			{
				HkdRandomSplitFracture_SetSplitLargestVolumesFirst(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdRandomSplitFracture_Create();

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdRandomSplitFracture_ReCast(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern float HkdRandomSplitFracture_GetRandomRange(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdRandomSplitFracture_SetRandomRange(IntPtr instance, float randomRange);

		[DllImport("Havok.dll")]
		private static extern Vector4 HkdRandomSplitFracture_GetSplitGeometryScale(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdRandomSplitFracture_SetSplitGeometryScale(IntPtr instance, Vector4 splitGeometryScale);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdRandomSplitFracture_GetSplitLargestVolumesFirst(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdRandomSplitFracture_SetSplitLargestVolumesFirst(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool splitLargestVolumesFirst);

		[DllImport("Havok.dll")]
		private static extern int HkdRandomSplitFracture_GetRandomSeed(IntPtr instance, int index);

		[DllImport("Havok.dll")]
		private static extern void HkdRandomSplitFracture_SetRandomSeed(IntPtr instance, int index, int randomSeed);

		[DllImport("Havok.dll")]
		private static extern int HkdRandomSplitFracture_GetNumObjectsOnLevel(IntPtr instance, int index);

		[DllImport("Havok.dll")]
		private static extern void HkdRandomSplitFracture_SetNumObjectsOnLevel(IntPtr instance, int index, int numObjectsOnLevel);

		[DllImport("Havok.dll")]
		private static extern void HkdRandomSplitFracture_SetGeometry(IntPtr instance, IntPtr geometry);

		public HkdRandomSplitFracture()
			: base(HkdRandomSplitFracture_Create())
		{
		}

		public void SetGeometry(HkReferenceObject data)
		{
			HkdRandomSplitFracture_SetGeometry(base.NativeObject, data.NativeObject);
		}

		internal HkdRandomSplitFracture(IntPtr ptr)
			: base(HkdRandomSplitFracture_ReCast(ptr))
		{
		}
	}
	public class HkdVoronoiFracture : HkdFracture
	{
		public int NumIterations
		{
			get
			{
				return HkdVoronoiFracture_GetNumIterations(base.NativeObject);
			}
			set
			{
				HkdVoronoiFracture_SetNumIterations(base.NativeObject, value);
			}
		}

		public int NumSitesToGenerate
		{
			get
			{
				return HkdVoronoiFracture_GetNumSitesToGenerate(base.NativeObject);
			}
			set
			{
				HkdVoronoiFracture_SetNumSitesToGenerate(base.NativeObject, value);
			}
		}

		public int Seed
		{
			get
			{
				return HkdVoronoiFracture_GetSeed(base.NativeObject);
			}
			set
			{
				HkdVoronoiFracture_SetSeed(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdVoronoiFracture_Create();

		[DllImport("Havok.dll")]
		private static extern int HkdVoronoiFracture_GetNumIterations(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdVoronoiFracture_SetNumIterations(IntPtr instance, int numIterations);

		[DllImport("Havok.dll")]
		private static extern int HkdVoronoiFracture_GetNumSitesToGenerate(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdVoronoiFracture_SetNumSitesToGenerate(IntPtr instance, int numSitesToGenerate);

		[DllImport("Havok.dll")]
		private static extern int HkdVoronoiFracture_GetSeed(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdVoronoiFracture_SetSeed(IntPtr instance, int seed);

		[DllImport("Havok.dll")]
		private static extern void HkdVoronoiFracture_SetGeometry(IntPtr instance, IntPtr geometry);

		public HkdVoronoiFracture()
			: base(HkdVoronoiFracture_Create())
		{
		}

		public void SetGeometry(HkReferenceObject data)
		{
			HkdVoronoiFracture_SetGeometry(base.NativeObject, data.NativeObject);
		}

		internal HkdVoronoiFracture(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public class HkdWoodFracture : HkdFracture
	{
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct SplittingData
		{
			public enum Rotation
			{
				AutoRotate,
				NoRotation,
				Rotate90
			}

			public Vector4 SplittingAxis;

			public float NumSubparts;

			public float WidthRange;

			public Vector4 Scale;

			public Vector4 ScaleRange;

			public float SplitGeomShiftRangeY;

			public float SplitGeomShiftRangeZ;

			public float SurfaceNormalShearingRange;

			public float FractureLineShearingRange;

			public float FractureNormalShearingRange;

			public int m_rotateSplitGeom;

			public Rotation RotateSplitGeom
			{
				get
				{
					return (Rotation)m_rotateSplitGeom;
				}
				set
				{
					m_rotateSplitGeom = (int)value;
				}
			}
		}

		public HkReferenceObject SplinterSplittingGeometry
		{
			get
			{
				return new HkGeometry(HkdWoodFracture_GetSplinterSplittingGeometry(base.NativeObject));
			}
			set
			{
				HkdWoodFracture_SetSplinterSplittingGeometry(base.NativeObject, value.NativeObject);
			}
		}

		public HkReferenceObject BoardSplittingGeometry
		{
			get
			{
				return new HkGeometry(HkdWoodFracture_GetBoardSplittingGeometry(base.NativeObject));
			}
			set
			{
				HkdWoodFracture_SetBoardSplittingGeometry(base.NativeObject, value.NativeObject);
			}
		}

		public SplittingData SplinterSplittingData
		{
			get
			{
				return HkdWoodFracture_GetSplinterSplittingData(base.NativeObject);
			}
			set
			{
				HkdWoodFracture_SetSplinterSplittingData(base.NativeObject, value);
			}
		}

		public SplittingData BoardSplittingData
		{
			get
			{
				return HkdWoodFracture_GetBoardSplittingData(base.NativeObject);
			}
			set
			{
				HkdWoodFracture_SetBoardSplittingData(base.NativeObject, value);
			}
		}

		public int RandomSeed
		{
			get
			{
				return HkdWoodFracture_GetRandomSeed(base.NativeObject);
			}
			set
			{
				HkdWoodFracture_SetRandomSeed(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdWoodFracture_Create();

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdWoodFracture_ReCast(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdWoodFracture_GetSplinterSplittingGeometry(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdWoodFracture_SetSplinterSplittingGeometry(IntPtr instance, IntPtr geometry);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdWoodFracture_GetBoardSplittingGeometry(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdWoodFracture_SetBoardSplittingGeometry(IntPtr instance, IntPtr geometry);

		[DllImport("Havok.dll")]
		private static extern SplittingData HkdWoodFracture_GetSplinterSplittingData(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdWoodFracture_SetSplinterSplittingData(IntPtr instance, SplittingData data);

		[DllImport("Havok.dll")]
		private static extern SplittingData HkdWoodFracture_GetBoardSplittingData(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdWoodFracture_SetBoardSplittingData(IntPtr instance, SplittingData data);

		[DllImport("Havok.dll")]
		private static extern int HkdWoodFracture_GetRandomSeed(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdWoodFracture_SetRandomSeed(IntPtr instance, int data);

		public HkdWoodFracture()
			: base(HkdWoodFracture_Create())
		{
		}

		internal HkdWoodFracture(IntPtr ptr)
			: base(HkdWoodFracture_ReCast(ptr))
		{
		}
	}
	public class HkBreakOffPartsUtil : HkHandle
	{
		internal delegate int BreakLogicHandlerDelegate(IntPtr body, IntPtr otherBody, uint shapeKey, IntPtr maxImpulse);

		[return: MarshalAs(UnmanagedType.I1)]
		internal delegate bool BreakPartsHandlerDelegate(IntPtr body, IntPtr breakOffPoints);

		private static readonly BreakLogicHandlerDelegate BreakLogicHandlerCallback = BreakLogicHandler;

		private static readonly BreakPartsHandlerDelegate BreakPartsHandlerCallback = BreakPartsHandler;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkBreakOffPartsUtil_Create(BreakLogicHandlerDelegate breakLogicHandler, BreakPartsHandlerDelegate breakPartsHandler);

		[DllImport("Havok.dll")]
		private static extern void HkBreakOffPartsUtil_Release(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkBreakOffPartsUtil_RemoveKeysFromListShape(IntPtr entity, uint[] shapeKeys, int count);

		[DllImport("Havok.dll")]
		private static extern void HkBreakOffPartsUtil_MarkEntityBreakable(IntPtr instance, IntPtr entity, float maxImpulse);

		[DllImport("Havok.dll")]
		private static extern void HkBreakOffPartsUtil_MarkPieceBreakable(IntPtr instance, IntPtr entity, uint shapeKey, float maxImpulse);

		[DllImport("Havok.dll")]
		private static extern void HkBreakOffPartsUtil_SetMaxConstraintImpulse(IntPtr instance, IntPtr entity, float maxConstraintImpulse);

		[DllImport("Havok.dll")]
		private static extern void HkBreakOffPartsUtil_UnmarkEntityBreakable(IntPtr instance, IntPtr entity);

		[DllImport("Havok.dll")]
		private static extern void HkBreakOffPartsUtil_UnmarkPieceBreakable(IntPtr instance, IntPtr entity, uint shapeKey);

		public HkBreakOffPartsUtil()
			: base(HkBreakOffPartsUtil_Create(BreakLogicHandlerCallback, BreakPartsHandlerCallback))
		{
		}

		[MonoPInvokeCallback(typeof(BreakPartsHandlerDelegate))]
		private static bool BreakPartsHandler(IntPtr body, IntPtr breakOffPoints)
		{
			HkRigidBody hkRigidBody = HkRigidBody.Get(body);
			HkBreakOffPoints breakOffPoints2 = new HkBreakOffPoints(breakOffPoints);
			HkArrayUInt32 brokenKeysOut = new HkArrayUInt32();
			return hkRigidBody.BreakPartsHandler != null && hkRigidBody.BreakPartsHandler(ref breakOffPoints2, ref brokenKeysOut);
		}

		[MonoPInvokeCallback(typeof(BreakLogicHandlerDelegate))]
		private unsafe static int BreakLogicHandler(IntPtr body, IntPtr otherBody, uint shapeKey, IntPtr maxImpulse)
		{
			HkRigidBody hkRigidBody = HkRigidBody.Get(body);
			HkRigidBody otherBody2 = HkRigidBody.Get(otherBody);
			if (hkRigidBody.BreakLogicHandler == null)
			{
				return 0;
			}
			return (int)hkRigidBody.BreakLogicHandler(otherBody2, shapeKey, ref *(float*)maxImpulse.ToPointer());
		}

		public static void RemoveKeysFromListShape(HkEntity entity, uint[] shapeKeys, int count)
		{
			HkBreakOffPartsUtil_RemoveKeysFromListShape(entity.NativeObject, shapeKeys, count);
		}

		public void MarkEntityBreakable(HkEntity entity, float maxImpulse)
		{
			HkBreakOffPartsUtil_MarkEntityBreakable(base.NativeObject, entity.NativeObject, maxImpulse);
		}

		public void MarkPieceBreakable(HkEntity entity, uint shapeKey, float maxImpulse)
		{
			HkBreakOffPartsUtil_MarkPieceBreakable(base.NativeObject, entity.NativeObject, shapeKey, maxImpulse);
		}

		public void SetMaxConstraintImpulse(HkEntity entity, float maxConstraintImpulse)
		{
			HkBreakOffPartsUtil_SetMaxConstraintImpulse(base.NativeObject, entity.NativeObject, maxConstraintImpulse);
		}

		public void UnmarkEntityBreakable(HkEntity entity)
		{
			HkBreakOffPartsUtil_UnmarkEntityBreakable(base.NativeObject, entity.NativeObject);
		}

		public void UnmarkPieceBreakable(HkEntity entity, uint shapeKey)
		{
			HkBreakOffPartsUtil_UnmarkPieceBreakable(base.NativeObject, entity.NativeObject, shapeKey);
		}

		protected override void Dispose(bool A_0)
		{
			HkBreakOffPartsUtil_Release(base.NativeObject);
		}

		internal HkBreakOffPartsUtil(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public struct HkBreakOffPointInfo
	{
		public HkRigidBody CollidingBody;

		public HkContactPoint ContactPoint;

		public HkContactPointProperties ContactPointProperties;

		public Vector3D ContactPosition;

		public uint BrokenShapeKey;

		public bool IsContact;

		public float BreakingImpulse;

		public float ContactPointDirection;
	}
	public struct HkBreakOffPoints
	{
		private struct HkBreakOffPointInternal
		{
			public IntPtr CollidingBody;

			public IntPtr ContactPoint;

			public IntPtr Properties;

			public float BreakingImpulse;

			public float ContactPointDirection;

			public uint BrokenShapeKey;

			public bool IsContact;
		}

		private IntPtr m_handle;

		public unsafe HkBreakOffPointInfo this[int index]
		{
			get
			{
				HkBreakOffPointInternal hkBreakOffPointInternal = default(HkBreakOffPointInternal);
				HkBreakOffPoints_Get(m_handle, index, &hkBreakOffPointInternal);
				HkBreakOffPointInfo result = default(HkBreakOffPointInfo);
				result.CollidingBody = HkRigidBody.Get(hkBreakOffPointInternal.CollidingBody);
				result.BrokenShapeKey = hkBreakOffPointInternal.BrokenShapeKey;
				result.IsContact = hkBreakOffPointInternal.IsContact;
				result.BreakingImpulse = hkBreakOffPointInternal.BreakingImpulse;
				result.ContactPointDirection = hkBreakOffPointInternal.ContactPointDirection;
				result.ContactPoint = new HkContactPoint(hkBreakOffPointInternal.ContactPoint);
				result.ContactPointProperties = new HkContactPointProperties(hkBreakOffPointInternal.Properties);
				return result;
			}
		}

		public int Count => HkBreakOffPoints_Count(m_handle);

		[DllImport("Havok.dll")]
		private static extern int HkBreakOffPoints_Count(IntPtr instance);

		[DllImport("Havok.dll")]
		private unsafe static extern void HkBreakOffPoints_Get(IntPtr instance, int index, void* outPointInfo);

		internal HkBreakOffPoints(IntPtr ptr)
		{
			m_handle = ptr;
		}
	}
	public delegate void BreakableBodyReplaced(ref HkdReplaceBodyEvent replaceBodyEvent);
	public delegate void BreakableBodyAdded(HkdBreakableBody breakableBody);
	public delegate void BeforeBodyControllerOperation(HkdBreakableBody breakableBody);
	public delegate void AfterBodyControllerOperation(HkdBreakableBody breakableBody);
	public class HkdBreakableBody : HkReferenceObject
	{
		internal delegate void CallBodyReplacedEvent(IntPtr replaceBodyEvent);

		internal delegate void CallBreakableBodyEvent(IntPtr breakableBody);

		private IntPtr Listener;

		public HkdBreakableShape BreakableShape
		{
			get
			{
				IntPtr ptr = HkdBreakableBody_GetBreakableShape(base.NativeObject);
				return HkReferenceObject.Get<HkdBreakableShape>(ptr);
			}
			set
			{
				HkdBreakableBody_SetBreakableShape(base.NativeObject, value.NativeObject);
				GetRigidBody().OnReaddedToWorld();
			}
		}

		public event BreakableBodyReplaced BeforeReplaceBody;

		public event BreakableBodyReplaced AfterReplaceBody;

		public event BreakableBodyAdded BodyAddedToWorld;

		public event BeforeBodyControllerOperation BeforeControllerOperation;

		public event AfterBodyControllerOperation AfterControllerOperation;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableBody_Create(IntPtr breakableShape, IntPtr body, IntPtr world, Matrix matrix);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableBody_InitListener(IntPtr instance, CallBodyReplacedEvent beforeReplaceBody, CallBodyReplacedEvent afterReplaceBody, CallBreakableBodyEvent bodyAddedToWorld, CallBreakableBodyEvent beforeControllerOperation, CallBreakableBodyEvent afterControllerOperation);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableBody_GetBreakableShape(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableBody_SetBreakableShape(IntPtr instance, IntPtr breakableShape);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableBody_Clear(IntPtr instance, IntPtr listener);

		[DllImport("Havok.dll")]
		private static extern bool HkdBreakableBody_ConnectToWorld(IntPtr instance, IntPtr world, float distance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableBody_GetRigidBody(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableBody_Initialize(IntPtr bInfo, IntPtr rigidBody);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableBody_RemoveConnection(IntPtr instance, IntPtr connection);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableBody_SetFixedConnectivity(IntPtr instance, IntPtr connectivity);

		public HkdBreakableBody()
			: this(IntPtr.Zero)
		{
			throw new NotImplementedException();
		}

		public override bool IsValid()
		{
			if (m_handle != IntPtr.Zero)
			{
				return base.IsValid();
			}
			return false;
		}

		public HkdBreakableBody(HkdBreakableShape breakableShape, HkRigidBody body, HkdWorld world, Matrix matrix)
			: base(HkdBreakableBody_Create(breakableShape.NativeObject, body.NativeObject, world.NativeObject, matrix))
		{
			throw new NotImplementedException();
		}

		public static HkdBreakableBody Allocate()
		{
			return new HkdBreakableBody(IntPtr.Zero);
		}

		public void Clear()
		{
			GetRigidBody().Clear();
			HkdBreakableBody_Clear(base.NativeObject, Listener);
		}

		public bool ConnectToWorld(HkWorld world, float distance)
		{
			return HkdBreakableBody_ConnectToWorld(base.NativeObject, world.NativeObject, distance);
		}

		public HkRigidBody GetRigidBody()
		{
			IntPtr bodyHandle = HkdBreakableBody_GetRigidBody(base.NativeObject);
			return HkRigidBody.Get(bodyHandle);
		}

		public void Initialize(HkdBreakableBodyInfo bInfo, HkRigidBody rigidBody)
		{
			m_handle = HkdBreakableBody_Initialize(bInfo.NativeObject, rigidBody.NativeObject);
			InitListener();
		}

		public void RemoveConnection(HkdConnection connection)
		{
			HkdBreakableBody_RemoveConnection(base.NativeObject, connection.NativeObject);
		}

		public void SetFixedConnectivity(HkdFixedConnectivity connectivity)
		{
			HkdBreakableBody_SetFixedConnectivity(base.NativeObject, connectivity.NativeObject);
		}

		public void ClearListener()
		{
		}

		public static implicit operator HkRigidBody(HkdBreakableBody body)
		{
			return body.GetRigidBody();
		}

		internal HkdBreakableBody(IntPtr ptr)
			: base(ptr)
		{
			InitListener();
		}

		public void InitListener()
		{
			if (base.NativeObject != IntPtr.Zero)
			{
				Listener = HkdBreakableBody_InitListener(base.NativeObject, delegate(IntPtr ptr)
				{
					HkdReplaceBodyEvent replaceBodyEvent2 = new HkdReplaceBodyEvent(ptr);
					this.BeforeReplaceBody?.Invoke(ref replaceBodyEvent2);
				}, delegate(IntPtr ptr)
				{
					HkdReplaceBodyEvent replaceBodyEvent = new HkdReplaceBodyEvent(ptr);
					this.AfterReplaceBody?.Invoke(ref replaceBodyEvent);
				}, delegate(IntPtr ptr)
				{
					this.BodyAddedToWorld?.Invoke(HkReferenceObject.Get<HkdBreakableBody>(ptr));
				}, delegate(IntPtr ptr)
				{
					this.BeforeControllerOperation?.Invoke(HkReferenceObject.Get<HkdBreakableBody>(ptr));
				}, delegate(IntPtr ptr)
				{
					this.AfterControllerOperation?.Invoke(HkReferenceObject.Get<HkdBreakableBody>(ptr));
				});
			}
		}
	}
	public class HkdBreakableBodyHelper
	{
		internal delegate void ReturnShapeInstanceInfo(IntPtr shapeInstanceInfo);

		private IntPtr NativeObject;

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableBodyHelper_GetChildren(IntPtr instance, ReturnShapeInstanceInfo returnShapeInstanceInfo);

		[DllImport("Havok.dll")]
		private static extern Matrix HkdBreakableBodyHelper_GetRigidBodyMatrix(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkdBreakableBodyHelper_GetShapeCoM(IntPtr instance);

		public HkdBreakableBodyHelper(HkdBreakableBody body)
		{
			NativeObject = body.NativeObject;
		}

		public HkdBreakableBodyHelper(HkdBreakableBodyInfo info)
		{
			NativeObject = info.Body.NativeObject;
		}

		public void GetChildren(List<HkdShapeInstanceInfo> list)
		{
			List<HkdShapeInstanceInfo> results = new List<HkdShapeInstanceInfo>();
			HkdBreakableBodyHelper_GetChildren(NativeObject, delegate(IntPtr info)
			{
				results.Add(new HkdShapeInstanceInfo(info));
			});
			list.AddRange(results);
		}

		public Matrix GetRigidBodyMatrix()
		{
			return HkdBreakableBodyHelper_GetRigidBodyMatrix(NativeObject);
		}

		public Vector3 GetShapeCoM()
		{
			return HkdBreakableBodyHelper_GetShapeCoM(NativeObject);
		}
	}
	public class HkdBreakableBodyInfo : HkHandle
	{
		public HkdBreakableBody Body
		{
			get
			{
				IntPtr ptr = HkdBreakableBodyInfo_GetBody(base.NativeObject);
				return HkReferenceObject.Get<HkdBreakableBody>(ptr);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableBodyInfo_GetBody(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdBreakableBodyInfo_IsFracture(IntPtr instance);

		public bool IsFracture()
		{
			return HkdBreakableBodyInfo_IsFracture(base.NativeObject);
		}

		protected override void Dispose(bool disposing)
		{
		}

		internal HkdBreakableBodyInfo(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public class HkdBreakableShape : HkReferenceObject
	{
		internal delegate void ReturnShapeInstanceInfo(IntPtr shapeInstanceInfo);

		internal delegate void ReturnConnection(IntPtr connection);

		public enum Flags
		{
			FRACTURE_PIECE = 1,
			DONT_CREATE_FRACTURE_PIECE = 2,
			IS_FIXED = 4
		}

		public enum BodyQualityType
		{
			QUALITY_INHERITED,
			QUALITY_FIXED,
			QUALITY_DEBRIS,
			QUALITY_DEBRIS_SIMPLE_TOI,
			QUALITY_MOVING,
			QUALITY_CRITICAL
		}

		public const int PROPERTY_GRID_POSITION = 255;

		public const int PROPERTY_BLOCK_COMPOUND_ID = 256;

		public string ShapeName => HkHandle.MarshalToString(HkdBreakableShape_GetShapeName(base.NativeObject));

		public int MaterialType => HkdBreakableShape_GetMaterialType(base.NativeObject);

		public BodyQualityType MotionQuality
		{
			get
			{
				return (BodyQualityType)HkdBreakableShape_GetMotionQuality(base.NativeObject);
			}
			set
			{
				HkdBreakableShape_SetMotionQuality(base.NativeObject, (int)value);
			}
		}

		public bool HasParent => HkdBreakableShape_GetHasParent(base.NativeObject);

		public string Name
		{
			get
			{
				return HkHandle.MarshalToString(HkdBreakableShape_GetName(base.NativeObject));
			}
			set
			{
				HkdBreakableShape_SetName(base.NativeObject, value);
			}
		}

		public float Volume
		{
			get
			{
				return HkdBreakableShape_GetVolume(base.NativeObject);
			}
			set
			{
				HkdBreakableShape_SetVolume(base.NativeObject, value);
			}
		}

		public uint UserObject
		{
			get
			{
				return HkdBreakableShape_GetUserObject(base.NativeObject);
			}
			set
			{
				HkdBreakableShape_SetUserObject(base.NativeObject, value);
			}
		}

		public Vector3 CoM => HkdBreakableShape_GetCoM(base.NativeObject);

		public IntPtr NativeDebug => base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableShape_Create(IntPtr shape);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableShape_CreateWithMass(IntPtr shape, HkMassProperties massProps);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableShape_GetShapeName(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkdBreakableShape_GetMaterialType(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkdBreakableShape_GetMotionQuality(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetMotionQuality(IntPtr instance, int motionQuality);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdBreakableShape_GetHasParent(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableShape_GetName(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetName(IntPtr instance, string name);

		[DllImport("Havok.dll")]
		private static extern float HkdBreakableShape_GetVolume(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetVolume(IntPtr instance, float volume);

		[DllImport("Havok.dll")]
		private static extern uint HkdBreakableShape_GetUserObject(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetUserObject(IntPtr instance, uint userObject);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkdBreakableShape_GetCoM(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkdBreakableShape_GetReferenceCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetReferenceCount(IntPtr instance, int referenceCount);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_CopyData(IntPtr src, IntPtr dst);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_DisposeSharedMaterial();

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_AddConnection(IntPtr instance, IntPtr connection);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_AddReference(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_AddShape(IntPtr instance, IntPtr shapeInfo);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_AutoConnect(IntPtr instance, IntPtr world);

		[DllImport("Havok.dll")]
		private static extern HkMassProperties HkdBreakableShape_BuildMassProperties(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern float HkdBreakableShape_CalculateGeometryVolume(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_ClearActions(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_ClearConnections(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_ClearConnectionsRecursive(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_ClearHandle(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableShape_Clone(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_ConnectSemiAccurate(IntPtr instance, IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_DisableRefCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_DisableRefCountRecursively(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableShape_GetChild(IntPtr instance, int i);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_GetChildren(IntPtr instance, ReturnShapeInstanceInfo returnShapeInstanceInfo);

		[DllImport("Havok.dll")]
		private static extern int HkdBreakableShape_GetChildrenCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableShape_GetChildShape(IntPtr instance, int i);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_GetConnectionList(IntPtr instance, ReturnConnection returnConnection);

		[DllImport("Havok.dll")]
		private static extern float HkdBreakableShape_GetMass(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableShape_GetParent(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableShape_GetProperty(IntPtr instance, int key);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdBreakableShape_GetShape(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern float HkdBreakableShape_GetStrenght(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkdBreakableShape_GetTotalChildrenCount(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdBreakableShape_HasFixedChildren(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdBreakableShape_HasProperty(IntPtr instance, int key);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_InitIntegrity(IntPtr instance, float position);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdBreakableShape_IsChildOf(IntPtr instance, IntPtr child);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdBreakableShape_IsCompound(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdBreakableShape_IsDescendantOf(IntPtr instance, IntPtr predecessor);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdBreakableShape_IsFixed(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdBreakableShape_IsFracturePiece(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdBreakableShape_IsValid(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_RemoveChild(IntPtr instance, int index);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdBreakableShape_RemoveChildByName(IntPtr instance, string shapeName);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_RemoveConnection(IntPtr instance, IntPtr connection);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_RemoveReference(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_ReplaceChildren(IntPtr instance, int childrenCount, IntPtr[] children);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_ReplaceConnections(IntPtr instance, int count, IntPtr[] connections);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetAsDebris(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetAsDebrisRecursive(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetAsFixed(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetChildrenParent(IntPtr instance, IntPtr parent);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetFlagRecursively(IntPtr instance, int flag);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetHasFixedChildren(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool has);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetMass(IntPtr instance, float mass);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetMassProperties(IntPtr instance, HkMassProperties massProperties);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetMassRecursively(IntPtr instance, float mass);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetMotionQualityRecursively(IntPtr instance, int type);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetProperty(IntPtr instance, int key, IntPtr prop);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetPropertyRecursively(IntPtr instance, int key, IntPtr prop);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetStrenght(IntPtr instance, float treshold);

		[DllImport("Havok.dll")]
		private static extern void HkdBreakableShape_SetStrenghtRecursively(IntPtr instance, float treshold, float relativeSubpieceStrenght);

		public static void CopyData(HkdBreakableShape src, HkdBreakableShape dst)
		{
			HkdBreakableShape_CopyData(src.NativeObject, dst.NativeObject);
		}

		public static void DisposeSharedMaterial()
		{
			HkdBreakableShape_DisposeSharedMaterial();
		}

		public HkdBreakableShape()
		{
			m_handle = IntPtr.Zero;
		}

		public HkdBreakableShape(HkShape shape)
			: base(HkdBreakableShape_Create(shape.NativeObject))
		{
		}

		public HkdBreakableShape(HkShape shape, ref HkMassProperties massProps)
			: base(HkdBreakableShape_CreateWithMass(shape.NativeObject, massProps))
		{
		}

		public void AddConnection(ref HkdConnection connection)
		{
			HkdBreakableShape_AddConnection(base.NativeObject, connection.NativeObject);
		}

		public void AddShape(ref HkdShapeInstanceInfo shapeInfo)
		{
			HkdBreakableShape_AddShape(base.NativeObject, shapeInfo.NativeObject);
		}

		public void AutoConnect(HkWorld world)
		{
			HkdBreakableShape_AutoConnect(base.NativeObject, world.NativeObject);
		}

		public void BuildMassProperties(ref HkMassProperties massProperties)
		{
			massProperties = HkdBreakableShape_BuildMassProperties(base.NativeObject);
		}

		public float CalculateGeometryVolume()
		{
			return HkdBreakableShape_CalculateGeometryVolume(base.NativeObject);
		}

		public void ClearActions()
		{
			HkdBreakableShape_ClearActions(base.NativeObject);
		}

		public void ClearConnections()
		{
			HkdBreakableShape_ClearConnections(base.NativeObject);
		}

		public void ClearConnectionsRecursive()
		{
			HkdBreakableShape_ClearConnectionsRecursive(base.NativeObject);
		}

		public HkdBreakableShape Clone()
		{
			return new HkdBreakableShape(HkdBreakableShape_Clone(base.NativeObject));
		}

		public void ConnectSemiAccurate(HkWorld world)
		{
			HkdBreakableShape_ConnectSemiAccurate(base.NativeObject, world.NativeObject);
		}

		public void DisableRefCount()
		{
			HkdBreakableShape_DisableRefCount(base.NativeObject);
		}

		public void DisableRefCountRecursively()
		{
			HkdBreakableShape_DisableRefCountRecursively(base.NativeObject);
		}

		public HkdShapeInstanceInfo GetChild(int i)
		{
			return new HkdShapeInstanceInfo(HkdBreakableShape_GetChild(base.NativeObject, i));
		}

		public void GetChildren(List<HkdShapeInstanceInfo> list)
		{
			List<HkdShapeInstanceInfo> result = new List<HkdShapeInstanceInfo>();
			HkdBreakableShape_GetChildren(base.NativeObject, delegate(IntPtr info)
			{
				result.Add(new HkdShapeInstanceInfo(info));
			});
			list.AddRange(result);
		}

		public int GetChildrenCount()
		{
			return HkdBreakableShape_GetChildrenCount(base.NativeObject);
		}

		public HkdBreakableShape GetChildShape(int i)
		{
			IntPtr ptr = HkdBreakableShape_GetChildShape(base.NativeObject, i);
			return HkReferenceObject.Get<HkdBreakableShape>(ptr);
		}

		public void GetConnectionList(List<HkdConnection> resultList)
		{
			List<HkdConnection> result = new List<HkdConnection>();
			HkdBreakableShape_GetConnectionList(base.NativeObject, delegate(IntPtr c)
			{
				result.Add(new HkdConnection(c));
			});
			resultList.AddRange(result);
		}

		public float GetMass()
		{
			return HkdBreakableShape_GetMass(base.NativeObject);
		}

		public HkdBreakableShape GetParent()
		{
			IntPtr ptr = HkdBreakableShape_GetParent(base.NativeObject);
			return HkReferenceObject.Get<HkdBreakableShape>(ptr);
		}

		public HkPropertyBase GetProperty(int key)
		{
			return new HkPropertyBase(HkdBreakableShape_GetProperty(base.NativeObject, key));
		}

		public HkShape GetShape()
		{
			IntPtr shape = HkdBreakableShape_GetShape(base.NativeObject);
			return new HkShape(shape);
		}

		public float GetStrenght()
		{
			return HkdBreakableShape_GetStrenght(base.NativeObject);
		}

		public int GetTotalChildrenCount()
		{
			return HkdBreakableShape_GetTotalChildrenCount(base.NativeObject);
		}

		public bool HasFixedChildren()
		{
			return HkdBreakableShape_HasFixedChildren(base.NativeObject);
		}

		public bool HasProperty(int key)
		{
			return HkdBreakableShape_HasProperty(base.NativeObject, key);
		}

		public void InitIntegrity(float position)
		{
			HkdBreakableShape_InitIntegrity(base.NativeObject, position);
		}

		public bool IsChildOf(HkdBreakableShape child)
		{
			return HkdBreakableShape_IsChildOf(base.NativeObject, child.NativeObject);
		}

		public bool IsCompound()
		{
			return HkdBreakableShape_IsCompound(base.NativeObject);
		}

		public bool IsDescendantOf(HkdBreakableShape predecessor)
		{
			return HkdBreakableShape_IsDescendantOf(base.NativeObject, predecessor.NativeObject);
		}

		public bool IsFixed()
		{
			return HkdBreakableShape_IsFixed(base.NativeObject);
		}

		public bool IsFracturePiece()
		{
			return HkdBreakableShape_IsFracturePiece(base.NativeObject);
		}

		public bool CheckValid()
		{
			if (base.NativeObject == IntPtr.Zero)
			{
				return false;
			}
			return HkdBreakableShape_IsValid(base.NativeObject);
		}

		public new bool IsValid()
		{
			return CheckValid();
		}

		public void RemoveChild(int index)
		{
			HkdBreakableShape_RemoveChild(base.NativeObject, index);
		}

		public bool RemoveChild(string shapeName)
		{
			return HkdBreakableShape_RemoveChildByName(base.NativeObject, shapeName);
		}

		public void RemoveConnection(HkdConnection connection)
		{
			HkdBreakableShape_RemoveConnection(base.NativeObject, connection.NativeObject);
		}

		public void ReplaceChildren(List<HkdShapeInstanceInfo> children)
		{
			HkdBreakableShape_ReplaceChildren(base.NativeObject, children.Count, children.Select((HkdShapeInstanceInfo c) => c.NativeObject).ToArray());
		}

		public void ReplaceConnections(Dictionary<Vector3I, List<HkdConnection>> connections, int count)
		{
			List<HkdConnection> list = new List<HkdConnection>(count);
			foreach (KeyValuePair<Vector3I, List<HkdConnection>> connection in connections)
			{
				list.AddRange(connection.Value);
			}
			HkdBreakableShape_ReplaceConnections(base.NativeObject, count, list.Select((HkdConnection c) => c.NativeObject).ToArray());
		}

		public void SetAsDebris()
		{
			HkdBreakableShape_SetAsDebris(base.NativeObject);
		}

		public void SetAsDebrisRecursive()
		{
			HkdBreakableShape_SetAsDebrisRecursive(base.NativeObject);
		}

		public void SetAsFixed()
		{
			HkdBreakableShape_SetAsFixed(base.NativeObject);
		}

		public void SetChildrenParent(HkdBreakableShape parent)
		{
			HkdBreakableShape_SetChildrenParent(base.NativeObject, parent.NativeObject);
		}

		public void SetFlagRecursively(Flags flag)
		{
			HkdBreakableShape_SetFlagRecursively(base.NativeObject, (int)flag);
		}

		public void SetHasFixedChildren(bool has)
		{
			HkdBreakableShape_SetHasFixedChildren(base.NativeObject, has);
		}

		public void SetMass(float mass)
		{
			HkdBreakableShape_SetMass(base.NativeObject, mass);
		}

		public void SetMassProperties(ref HkMassProperties massProperties)
		{
			HkdBreakableShape_SetMassProperties(base.NativeObject, massProperties);
		}

		public void SetMassProperties(HkMassProperties props)
		{
			HkdBreakableShape_SetMassProperties(base.NativeObject, props);
		}

		public void SetMassRecursively(float mass)
		{
			HkdBreakableShape_SetMassRecursively(base.NativeObject, mass);
		}

		public void SetMotionQualityRecursively(BodyQualityType type)
		{
			HkdBreakableShape_SetMotionQualityRecursively(base.NativeObject, (int)type);
		}

		public void SetProperty(int key, HkPropertyBase prop)
		{
			HkdBreakableShape_SetProperty(base.NativeObject, key, prop.NativeObject);
		}

		public void SetPropertyRecursively(int key, HkPropertyBase prop)
		{
			HkdBreakableShape_SetPropertyRecursively(base.NativeObject, key, prop.NativeObject);
		}

		public void SetStrenght(float treshold)
		{
			HkdBreakableShape_SetStrenght(base.NativeObject, treshold);
		}

		public void SetStrenghtRecursively(float treshold, float relativeSubpieceStrenght)
		{
			HkdBreakableShape_SetStrenghtRecursively(base.NativeObject, treshold, relativeSubpieceStrenght);
		}

		public static bool operator ==(HkdBreakableShape a, HkdBreakableShape b)
		{
			return a.NativeObject == b.NativeObject;
		}

		public static bool operator !=(HkdBreakableShape a, HkdBreakableShape b)
		{
			return !(a == b);
		}

		public override bool Equals(object other)
		{
			HkdBreakableShape hkdBreakableShape = other as HkdBreakableShape;
			if (hkdBreakableShape != null)
			{
				return hkdBreakableShape == this;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return m_handle.ToInt32();
		}

		protected override void Dispose(bool disposing)
		{
			HkdBreakableShape_RemoveReference(base.NativeObject);
			m_handle = IntPtr.Zero;
		}

		internal HkdBreakableShape(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public static class BreakableShapeExtentions
	{
		public static bool IsValid(this HkdBreakableShape shape)
		{
			if (shape != null)
			{
				return shape.CheckValid();
			}
			return false;
		}
	}
	public class HkdCompoundBreakableShape : HkReferenceObject
	{
		public readonly HkdBreakableShape Base;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdCompoundBreakableShape_Create(IntPtr oldParent, int childCount, IntPtr[] childShapes);

		[DllImport("Havok.dll")]
		private static extern void HkdCompoundBreakableShape_DisableChild(IntPtr instance, IntPtr child);

		[DllImport("Havok.dll")]
		private static extern void HkdCompoundBreakableShape_RecalcMassPropsFromChildren(IntPtr instance);

		public HkdCompoundBreakableShape(HkdBreakableShape oldParent, List<HkdShapeInstanceInfo> childShapes)
		{
			m_handle = HkdCompoundBreakableShape_Create(oldParent.NativeObject, childShapes.Count, childShapes.Select((HkdShapeInstanceInfo c) => c.NativeObject).ToArray());
			Base = new HkdBreakableShape(m_handle);
		}

		public void DisableChild(HkdBreakableShape child)
		{
			HkdCompoundBreakableShape_DisableChild(base.NativeObject, child.NativeObject);
		}

		public void RecalcMassPropsFromChildren()
		{
			HkdCompoundBreakableShape_RecalcMassPropsFromChildren(base.NativeObject);
		}

		public static implicit operator HkdBreakableShape(HkdCompoundBreakableShape shape)
		{
			return shape.Base;
		}

		public static implicit operator HkdCompoundBreakableShape(HkdBreakableShape shape)
		{
			return new HkdCompoundBreakableShape(shape.NativeObject, shape);
		}

		internal HkdCompoundBreakableShape(IntPtr ptr, HkdBreakableShape shape)
			: base(ptr)
		{
			Base = shape;
		}

		internal HkdCompoundBreakableShape(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public class HkdConnection : HkReferenceObject
	{
		public HkdBreakableShape ShapeB
		{
			get
			{
				IntPtr ptr = HkdConnection_GetShapeB(base.NativeObject);
				HkdBreakableShape hkdBreakableShape = HkReferenceObject.Get<HkdBreakableShape>(ptr);
				return hkdBreakableShape ?? new HkdBreakableShape(ptr);
			}
			set
			{
				HkdConnection_SetShapeB(base.NativeObject, value.NativeObject);
			}
		}

		public HkdBreakableShape ShapeA
		{
			get
			{
				IntPtr ptr = HkdConnection_GetShapeA(base.NativeObject);
				HkdBreakableShape hkdBreakableShape = HkReferenceObject.Get<HkdBreakableShape>(ptr);
				return hkdBreakableShape ?? new HkdBreakableShape(ptr);
			}
			set
			{
				HkdConnection_SetShapeA(base.NativeObject, value.NativeObject);
			}
		}

		public string ShapeBName => HkHandle.MarshalToString(HkdConnection_GetShapeBName(base.NativeObject));

		public string ShapeAName => HkHandle.MarshalToString(HkdConnection_GetShapeAName(base.NativeObject));

		public float ContactArea
		{
			get
			{
				return HkdConnection_GetContactArea(base.NativeObject);
			}
			set
			{
				HkdConnection_SetContactArea(base.NativeObject, value);
			}
		}

		public Vector3 SeparatingNormal
		{
			get
			{
				return HkdConnection_GetSeparatingNormal(base.NativeObject);
			}
			set
			{
				HkdConnection_SetSeparatingNormal(base.NativeObject, value);
			}
		}

		public Vector3 PivotB
		{
			get
			{
				return HkdConnection_GetPivotB(base.NativeObject);
			}
			set
			{
				HkdConnection_SetPivotB(base.NativeObject, value);
			}
		}

		public Vector3 PivotA
		{
			get
			{
				return HkdConnection_GetPivotA(base.NativeObject);
			}
			set
			{
				HkdConnection_SetPivotA(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdConnection_Create();

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdConnection_CreateWithParams(IntPtr shapeA, IntPtr shapeB, Vector3 pivotA, Vector3 pivotB, Vector3 normal, float area);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdConnection_GetShapeB(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdConnection_SetShapeB(IntPtr instance, IntPtr shape);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdConnection_GetShapeA(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdConnection_SetShapeA(IntPtr instance, IntPtr shape);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdConnection_GetShapeBName(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdConnection_GetShapeAName(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern float HkdConnection_GetContactArea(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdConnection_SetContactArea(IntPtr instance, float contactArea);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkdConnection_GetSeparatingNormal(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdConnection_SetSeparatingNormal(IntPtr instance, Vector3 separatingNormal);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkdConnection_GetPivotB(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdConnection_SetPivotB(IntPtr instance, Vector3 pivotB);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkdConnection_GetPivotA(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdConnection_SetPivotA(IntPtr instance, Vector3 pivotA);

		[DllImport("Havok.dll")]
		private static extern void HkdConnection_AddToCommonParent(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdConnection_IsValid(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdConnection_RemoveReference(IntPtr instance);

		public static HkdConnection Create()
		{
			return new HkdConnection(HkdConnection_Create());
		}

		public HkdConnection(HkdBreakableShape shapeA, HkdBreakableShape shapeB, Vector3 pivotA, Vector3 pivotB, Vector3 normal, float area)
		{
			m_handle = HkdConnection_CreateWithParams(shapeA.NativeObject, shapeB.NativeObject, pivotA, pivotB, normal, area);
		}

		public void AddToCommonParent()
		{
			HkdConnection_AddToCommonParent(base.NativeObject);
		}

		public new bool IsValid()
		{
			return HkdConnection_IsValid(base.NativeObject);
		}

		internal HkdConnection(IntPtr ptr)
		{
			m_handle = ptr;
		}
	}
	public class HkdFixedConnectivity : HkReferenceObject
	{
		public class Connection : HkReferenceObject
		{
			public Connection(Vector3 pivot, Vector3 separatingNormal, float contactArea, HkdBreakableShape shape, HkRigidBody targetBody, int shapeKey)
				: base(HkdFixedConnectivity_CreateConnection(pivot, separatingNormal, contactArea, shape.NativeObject, targetBody.NativeObject, shapeKey))
			{
			}

			internal Connection(IntPtr ptr)
				: base(ptr)
			{
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdFixedConnectivity_Create();

		[DllImport("Havok.dll")]
		private static extern void HkdFixedConnectivity_AddConnection(IntPtr instance, IntPtr c);

		[DllImport("Havok.dll")]
		private static extern void HkdFixedConnectivity_RemoveReference(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdFixedConnectivity_CreateConnection(Vector3 pivot, Vector3 separatingNormal, float contactArea, IntPtr shape, IntPtr targetBody, int shapeKey);

		public static HkdFixedConnectivity Create()
		{
			return new HkdFixedConnectivity(HkdFixedConnectivity_Create());
		}

		public void AddConnection(ref Connection c)
		{
			HkdFixedConnectivity_AddConnection(base.NativeObject, c.NativeObject);
		}

		internal HkdFixedConnectivity(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public class HkdFractureImpactDetails : HkHandle
	{
		[Flags]
		public enum Flags
		{
			FLAG_NONE = 0,
			FLAG_DONT_DELAY_OPERATION = 1,
			FLAG_BODY_IS_IN_WORLD = 2,
			FLAG_DONT_RECURSE = 4,
			FLAG_EMBEDDED_BODY = 8,
			FLAG_TRIGGERED_DESTRUCTION = 0x10
		}

		public Flags Flag
		{
			get
			{
				return (Flags)HkdFractureImpactDetails_GetFlag(base.NativeObject);
			}
			set
			{
				HkdFractureImpactDetails_SetFlag(base.NativeObject, (int)value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdFractureImpactDetails_Create();

		[DllImport("Havok.dll")]
		private static extern int HkdFractureImpactDetails_GetFlag(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdFractureImpactDetails_SetFlag(IntPtr instance, int flag);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdFractureImpactDetails_GetBreakingBody(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkdFractureImpactDetails_GetContactPoint(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdFractureImpactDetails_IsValid(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdFractureImpactDetails_RemoveReference(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdFractureImpactDetails_SetBreakingBody(IntPtr instance, IntPtr body);

		[DllImport("Havok.dll")]
		private static extern void HkdFractureImpactDetails_SetBreakingImpulse(IntPtr instance, float v);

		[DllImport("Havok.dll")]
		private static extern void HkdFractureImpactDetails_SetContactPoint(IntPtr instance, Vector3 point);

		[DllImport("Havok.dll")]
		private static extern void HkdFractureImpactDetails_SetDestructionRadius(IntPtr instance, float v);

		[DllImport("Havok.dll")]
		private static extern void HkdFractureImpactDetails_SetOtherBody(IntPtr instance, IntPtr otherBody);

		[DllImport("Havok.dll")]
		private static extern void HkdFractureImpactDetails_SetParticleExpandVelocity(IntPtr instance, float v);

		[DllImport("Havok.dll")]
		private static extern void HkdFractureImpactDetails_SetParticleMass(IntPtr instance, float mass);

		[DllImport("Havok.dll")]
		private static extern void HkdFractureImpactDetails_SetParticlePosition(IntPtr instance, Vector3 pos);

		[DllImport("Havok.dll")]
		private static extern void HkdFractureImpactDetails_SetParticleVelocity(IntPtr instance, Vector3 vel);

		[DllImport("Havok.dll")]
		private static extern void HkdFractureImpactDetails_ZeroCollidingParticleVelocity(IntPtr instance);

		public static HkdFractureImpactDetails Create()
		{
			return new HkdFractureImpactDetails(HkdFractureImpactDetails_Create());
		}

		public HkRigidBody GetBreakingBody()
		{
			IntPtr bodyHandle = HkdFractureImpactDetails_GetBreakingBody(base.NativeObject);
			return HkRigidBody.Get(bodyHandle);
		}

		public Vector3 GetContactPoint()
		{
			return HkdFractureImpactDetails_GetContactPoint(base.NativeObject);
		}

		public bool IsValid()
		{
			return HkdFractureImpactDetails_IsValid(base.NativeObject);
		}

		public void RemoveReference()
		{
			HkdFractureImpactDetails_RemoveReference(base.NativeObject);
			m_handle = IntPtr.Zero;
		}

		public void SetBreakingBody(HkRigidBody body)
		{
			HkdFractureImpactDetails_SetBreakingBody(base.NativeObject, body.NativeObject);
		}

		public void SetBreakingImpulse(float v)
		{
			HkdFractureImpactDetails_SetBreakingImpulse(base.NativeObject, v);
		}

		public void SetContactPoint(Vector3 point)
		{
			HkdFractureImpactDetails_SetContactPoint(base.NativeObject, point);
		}

		public void SetDestructionRadius(float v)
		{
			HkdFractureImpactDetails_SetDestructionRadius(base.NativeObject, v);
		}

		public void SetOtherBody(HkRigidBody otherBody)
		{
			HkdFractureImpactDetails_SetOtherBody(base.NativeObject, otherBody.NativeObject);
		}

		public void SetParticleExpandVelocity(float v)
		{
			HkdFractureImpactDetails_SetParticleExpandVelocity(base.NativeObject, v);
		}

		public void SetParticleMass(float mass)
		{
			HkdFractureImpactDetails_SetParticleMass(base.NativeObject, mass);
		}

		public void SetParticlePosition(Vector3 pos)
		{
			HkdFractureImpactDetails_SetParticlePosition(base.NativeObject, pos);
		}

		public void SetParticleVelocity(Vector3 vel)
		{
			HkdFractureImpactDetails_SetParticleVelocity(base.NativeObject, vel);
		}

		public void ZeroCollidingParticleVelocity()
		{
			HkdFractureImpactDetails_ZeroCollidingParticleVelocity(base.NativeObject);
		}

		protected override void Dispose(bool disposing)
		{
			RemoveReference();
		}

		internal HkdFractureImpactDetails(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public class HkdReplaceBodyEvent : HkHandle
	{
		internal delegate void ReturnBreakableBodyInfo(IntPtr breakableBodyInfo);

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct ConnectionsData
		{
		}

		public HkdBreakableBody OldBody
		{
			get
			{
				IntPtr ptr = HkdReplaceBodyEvent_GetOldBody(base.NativeObject);
				return HkReferenceObject.Get<HkdBreakableBody>(ptr);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdReplaceBodyEvent_GetOldBody(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdReplaceBodyEvent_GetNewBodies(IntPtr instance, ReturnBreakableBodyInfo returnBreakableBodyInfo);

		public void GetNewBodies(List<HkdBreakableBodyInfo> resultList)
		{
			List<HkdBreakableBodyInfo> results = new List<HkdBreakableBodyInfo>();
			HkdReplaceBodyEvent_GetNewBodies(base.NativeObject, delegate(IntPtr info)
			{
				results.Add(new HkdBreakableBodyInfo(info));
			});
			resultList.AddRange(results);
		}

		protected override void Dispose(bool disposing)
		{
		}

		public ConnectionsData GetBrokenConnections()
		{
			throw new NotImplementedException();
		}

		internal HkdReplaceBodyEvent(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public struct HkdShapeInstanceInfo
	{
		internal delegate void ReturnShapeInstanceInfo(IntPtr shapeInstanceInfo);

		public static ushort INVALID_INDEX = ushort.MaxValue;

		private IntPtr m_handle;

		internal IntPtr NativeObject => m_handle;

		public ushort DynamicParent
		{
			get
			{
				return HkdShapeInstanceInfo_GetDynamicParent(NativeObject);
			}
			set
			{
				HkdShapeInstanceInfo_SetDynamicParent(NativeObject, value);
			}
		}

		public HkdBreakableShape Shape
		{
			get
			{
				IntPtr ptr = HkdShapeInstanceInfo_GetShape(NativeObject);
				return HkReferenceObject.Get<HkdBreakableShape>(ptr);
			}
		}

		public string ShapeName => HkHandle.MarshalToString(HkdShapeInstanceInfo_GetShapeName(NativeObject));

		public Vector3 CoM => HkdShapeInstanceInfo_GetCoM(NativeObject);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdShapeInstanceInfo_Create(IntPtr shape, Matrix transform);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdShapeInstanceInfo_CreateWithTranslation(IntPtr shape, Quaternion rotation, Vector3 translation);

		[DllImport("Havok.dll")]
		private static extern void HkdShapeInstanceInfo_Release(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern ushort HkdShapeInstanceInfo_GetDynamicParent(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdShapeInstanceInfo_SetDynamicParent(IntPtr instance, ushort dynamicParent);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdShapeInstanceInfo_GetShape(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdShapeInstanceInfo_GetShapeName(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkdShapeInstanceInfo_GetCoM(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdShapeInstanceInfo_GetChildren(IntPtr instance, ReturnShapeInstanceInfo returnShapeInstanceInfo);

		[DllImport("Havok.dll")]
		private static extern Matrix HkdShapeInstanceInfo_GetTransform(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdShapeInstanceInfo_InstanceOf(IntPtr instance, IntPtr shape);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdShapeInstanceInfo_IsFracturePiece(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdShapeInstanceInfo_IsReferenceValid(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkdShapeInstanceInfo_IsValid(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdShapeInstanceInfo_RemoveReference(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdShapeInstanceInfo_RemoveReferenceFromShape(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkdShapeInstanceInfo_SetTransform(IntPtr instance, Matrix transform);

		public HkdShapeInstanceInfo(HkdBreakableShape shape, Matrix transform)
		{
			m_handle = HkdShapeInstanceInfo_Create(shape.NativeObject, transform);
		}

		public HkdShapeInstanceInfo(HkdBreakableShape shape, Quaternion? rotation, Vector3? translation)
		{
			m_handle = HkdShapeInstanceInfo_CreateWithTranslation(shape.NativeObject, rotation ?? Quaternion.Identity, translation ?? Vector3.Zero);
		}

		public void GetChildren(List<HkdShapeInstanceInfo> list)
		{
			List<HkdShapeInstanceInfo> result = new List<HkdShapeInstanceInfo>();
			HkdShapeInstanceInfo_GetChildren(NativeObject, delegate(IntPtr info)
			{
				result.Add(new HkdShapeInstanceInfo(info));
			});
			list.AddRange(result);
		}

		public Matrix GetTransform()
		{
			return HkdShapeInstanceInfo_GetTransform(NativeObject);
		}

		public bool InstanceOf(HkdBreakableShape shape)
		{
			return HkdShapeInstanceInfo_InstanceOf(NativeObject, shape.NativeObject);
		}

		public bool IsFracturePiece()
		{
			return HkdShapeInstanceInfo_IsFracturePiece(NativeObject);
		}

		public bool IsReferenceValid()
		{
			return HkdShapeInstanceInfo_IsReferenceValid(NativeObject);
		}

		public bool IsValid()
		{
			return HkdShapeInstanceInfo_IsValid(NativeObject);
		}

		public void RemoveReference()
		{
			HkdShapeInstanceInfo_RemoveReference(NativeObject);
			m_handle = IntPtr.Zero;
		}

		public void RemoveReferenceFromShape()
		{
			HkdShapeInstanceInfo_RemoveReferenceFromShape(NativeObject);
		}

		public void SetTransform(ref Matrix m)
		{
			HkdShapeInstanceInfo_SetTransform(NativeObject, m);
		}

		internal HkdShapeInstanceInfo(IntPtr ptr)
		{
			m_handle = ptr;
		}
	}
	public class HkdWorld : HkReferenceObject
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct HkdBreakableBodyFactory
		{
		}

		private readonly HkWorld m_havokWorld;

		public HkWorld HavokWorld => m_havokWorld;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkdWorld_Create(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkdWorld_AddBreakableBody(IntPtr instance, IntPtr breakableBody);

		[DllImport("Havok.dll")]
		private static extern void HkdWorld_RemoveBreakableBodyWithInfo(IntPtr instance, IntPtr breakableBodyInfo);

		[DllImport("Havok.dll")]
		private static extern void HkdWorld_RemoveBreakableBody(IntPtr instance, IntPtr breakableBody);

		[DllImport("Havok.dll")]
		private static extern void HkdWorld_TriggerDestruction(IntPtr instance, IntPtr details);

		[DllImport("Havok.dll")]
		private static extern void HkdWorld_Release(IntPtr instance);

		public HkdWorld(HkWorld world)
			: base(HkdWorld_Create(world.NativeObject))
		{
			m_havokWorld = world;
		}

		public void AddBreakableBody(HkdBreakableBody breakableBody)
		{
			HkdWorld_AddBreakableBody(base.NativeObject, breakableBody.NativeObject);
			m_havokWorld.AddRigidBody(breakableBody.GetRigidBody());
		}

		public void RemoveBreakableBody(HkdBreakableBodyInfo breakableBodyInfo)
		{
			HkdWorld_RemoveBreakableBodyWithInfo(base.NativeObject, breakableBodyInfo.NativeObject);
			m_havokWorld.RemoveRigidBody(breakableBodyInfo.Body.GetRigidBody());
		}

		public void RemoveBreakableBody(HkdBreakableBody breakableBody)
		{
			HkdWorld_RemoveBreakableBody(base.NativeObject, breakableBody.NativeObject);
			m_havokWorld.RemoveRigidBody(breakableBody.GetRigidBody());
		}

		public void TriggerDestruction(ref HkdFractureImpactDetails details)
		{
			HkdWorld_TriggerDestruction(base.NativeObject, details.NativeObject);
		}

		protected override void Dispose(bool disposing)
		{
			HkdWorld_Release(base.NativeObject);
			m_handle = IntPtr.Zero;
		}

		public HkdBreakableBodyFactory GetBreakableBodyFactory()
		{
			throw new NotImplementedException();
		}

		internal HkdWorld(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public class HkAction : HkReferenceObject
	{
		internal HkAction(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public class HkDestructionStorage : HkHandle
	{
		internal delegate void ReturnSectionData(int indexStart, int triCount, IntPtr materialName);

		internal delegate void ReturnIndex(int index);

		internal delegate void ReturnVertex(Vector3 position, Vector3 normal, Vector3 tangent, Vector2 texCoord);

		internal delegate void ReturnString(IntPtr value);

		internal delegate void ReturnBreakableShape(IntPtr shape);

		internal delegate void ReturnByteArray(IntPtr byteArray, int size);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkDestructionStorage_Create(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkDestructionStorage_CleanChildrenShapes(IntPtr instance, IntPtr shape);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkDestructionStorage_CreateGeometry(IntPtr instance, IntPtr meshShape, string shapeName);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkDestructionStorage_MakeShapeFromData(IntPtr instance, int iCount, int[] indices, int vCount, Vector3[] vPositions, Vector3[] vNormals, Vector3[] vTangents, Vector2[] vTexCoords, int sCount, int[] sStarts, int[] sTriCounts, string[] sMatIdxes);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkDestructionStorage_DumpDestructionData(IntPtr instance, int bSize, byte[] buffer);

		[DllImport("Havok.dll")]
		private static extern void HkDestructionStorage_FractureShape(IntPtr instance, IntPtr shape, IntPtr fracture);

		[DllImport("Havok.dll")]
		private static extern bool HkDestructionStorage_GetDataFromShape(IntPtr instance, IntPtr shape, ReturnSectionData returnSectionData, ReturnIndex returnIndex, ReturnVertex returnVertex);

		[DllImport("Havok.dll")]
		private static extern void HkDestructionStorage_GetMaterialsOnRegisteredShapes(IntPtr instance, ReturnString returnString);

		[DllImport("Havok.dll")]
		private static extern void HkDestructionStorage_GetRegisteredMaterials(IntPtr instance, ReturnString returnString);

		[DllImport("Havok.dll")]
		private static extern void HkDestructionStorage_GetRegisteredShapes(IntPtr instance, ReturnString returnString);

		[DllImport("Havok.dll")]
		private static extern void HkDestructionStorage_LoadDestructionDataFromBuffer(IntPtr instance, int bSize, byte[] buffer, ReturnBreakableShape returnBreakableShape);

		[DllImport("Havok.dll")]
		private static extern void HkDestructionStorage_RegisterShape(IntPtr instance, IntPtr shape, string shapeName);

		[DllImport("Havok.dll")]
		private static extern void HkDestructionStorage_RegisterShapeWithGraphics(IntPtr instance, IntPtr mesh, IntPtr shape, string shapeName);

		[DllImport("Havok.dll")]
		private static extern void HkDestructionStorage_SaveDestructionData(IntPtr instance, IntPtr shape, string file);

		[DllImport("Havok.dll")]
		private static extern void HkDestructionStorage_SerializeDestructionData(IntPtr instance, IntPtr world, ReturnByteArray returnByteArray);

		[DllImport("Havok.dll")]
		private static extern void HkDestructionStorage_ReleasePtr(IntPtr instance);

		public HkDestructionStorage(HkdWorld world)
			: base(HkDestructionStorage_Create(world.NativeObject))
		{
		}

		public void CleanChildrenShapes(HkdBreakableShape shape)
		{
			HkDestructionStorage_CleanChildrenShapes(base.NativeObject, shape.NativeObject);
		}

		public HkReferenceObject CreateGeometry(IPhysicsMesh graphicsData, string shapeName)
		{
			IntPtr ptr = HkDestructionStorage_CreateGeometry(base.NativeObject, MakeMeshFromData(graphicsData), shapeName);
			return HkReferenceObject.Get<HkGeometry>(ptr);
		}

		public string DumpDestructionData(byte[] buffer)
		{
			IntPtr ptr = HkDestructionStorage_DumpDestructionData(base.NativeObject, buffer.Length, buffer);
			return HkHandle.MarshalToString(ptr);
		}

		public void FractureShape(HkdBreakableShape shape, HkdFracture fracture)
		{
			HkDestructionStorage_FractureShape(shape.NativeObject, shape.NativeObject, fracture.NativeObject);
		}

		public bool GetDataFromShape(HkdBreakableShape shape, IPhysicsMesh outMesh)
		{
			BoundingBox aabb = BoundingBox.CreateInvalid();
			bool result = HkDestructionStorage_GetDataFromShape(base.NativeObject, shape.NativeObject, delegate(int indexStart, int triCount, IntPtr materialName)
			{
				outMesh.AddSectionData(indexStart, triCount, HkHandle.MarshalToString(materialName));
			}, delegate(int index)
			{
				outMesh.AddIndex(index);
			}, delegate(Vector3 position, Vector3 normal, Vector3 tangent, Vector2 texCoord)
			{
				aabb = aabb.GetIncluded(position);
				outMesh.AddVertex(position, normal, tangent, texCoord);
			});
			outMesh.SetAABB(aabb.Min, aabb.Max);
			return result;
		}

		public bool GetDataFromShapeInstance(HkdShapeInstanceInfo info, IPhysicsMesh outMesh)
		{
			return GetDataFromShape(info.Shape, outMesh);
		}

		public List<string> GetMaterialsOnRegisteredShapes()
		{
			List<string> result = new List<string>();
			HkDestructionStorage_GetMaterialsOnRegisteredShapes(base.NativeObject, delegate(IntPtr ptr)
			{
				result.Add(HkHandle.MarshalToString(ptr));
			});
			return result;
		}

		public List<string> GetRegisteredMaterials()
		{
			List<string> result = new List<string>();
			HkDestructionStorage_GetRegisteredMaterials(base.NativeObject, delegate(IntPtr ptr)
			{
				result.Add(HkHandle.MarshalToString(ptr));
			});
			return result;
		}

		public List<string> GetRegisteredShapes()
		{
			List<string> result = new List<string>();
			HkDestructionStorage_GetRegisteredShapes(base.NativeObject, delegate(IntPtr ptr)
			{
				result.Add(HkHandle.MarshalToString(ptr));
			});
			return result;
		}

		public HkdBreakableShape[] LoadDestructionDataFromBuffer(byte[] buffer)
		{
			List<HkdBreakableShape> result = new List<HkdBreakableShape>();
			HkDestructionStorage_LoadDestructionDataFromBuffer(base.NativeObject, buffer.Length, buffer, delegate(IntPtr ptr)
			{
				result.Add(HkReferenceObject.Get<HkdBreakableShape>(ptr));
			});
			return result.ToArray();
		}

		public void RegisterShape(HkdBreakableShape shape, string shapeName)
		{
			HkDestructionStorage_RegisterShape(base.NativeObject, shape.NativeObject, shapeName);
		}

		public void RegisterShapeWithGraphics(IPhysicsMesh graphicsData, HkdBreakableShape shape, string shapeName)
		{
			HkDestructionStorage_RegisterShapeWithGraphics(base.NativeObject, MakeMeshFromData(graphicsData), shape.NativeObject, shapeName);
		}

		public void SaveDestructionData(HkdBreakableShape shape, string file)
		{
			HkDestructionStorage_SaveDestructionData(base.NativeObject, shape.NativeObject, file);
		}

		public byte[] SerializeDestructionData(HkdWorld world)
		{
			byte[] result = new byte[0];
			HkDestructionStorage_SerializeDestructionData(base.NativeObject, world.NativeObject, delegate(IntPtr ptr, int size)
			{
				result = HkHandle.MarshalToByteArray(ptr, size);
			});
			return result;
		}

		protected override void Dispose(bool disposing)
		{
			HkDestructionStorage_ReleasePtr(base.NativeObject);
			m_handle = IntPtr.Zero;
		}

		private IntPtr MakeMeshFromData(IPhysicsMesh graphicsData)
		{
			int indicesCount = graphicsData.GetIndicesCount();
			List<int> list = new List<int>(indicesCount);
			for (int i = 0; i < indicesCount; i++)
			{
				list.Add(graphicsData.GetIndex(i));
			}
			int verticesCount = graphicsData.GetVerticesCount();
			List<Vector3> list2 = new List<Vector3>(verticesCount);
			List<Vector3> list3 = new List<Vector3>(verticesCount);
			List<Vector3> list4 = new List<Vector3>(verticesCount);
			List<Vector2> list5 = new List<Vector2>(verticesCount);
			for (int j = 0; j < verticesCount; j++)
			{
				Vector3 position = default(Vector3);
				Vector3 normal = default(Vector3);
				Vector3 tangent = default(Vector3);
				Vector2 texCoord = default(Vector2);
				graphicsData.GetVertex(j, ref position, ref normal, ref tangent, ref texCoord);
				list2.Add(position);
				list3.Add(normal);
				list4.Add(tangent);
				list5.Add(texCoord);
			}
			int sectionsCount = graphicsData.GetSectionsCount();
			List<int> list6 = new List<int>(sectionsCount);
			List<int> list7 = new List<int>(sectionsCount);
			List<string> list8 = new List<string>(sectionsCount);
			for (int k = 0; k < sectionsCount; k++)
			{
				int indexStart = 0;
				int triCount = 0;
				string matIdx = string.Empty;
				graphicsData.GetSectionData(k, ref indexStart, ref triCount, ref matIdx);
				list6.Add(indexStart);
				list7.Add(triCount);
				list8.Add(matIdx);
			}
			return HkDestructionStorage_MakeShapeFromData(base.NativeObject, indicesCount, list.ToArray(), verticesCount, list2.ToArray(), list3.ToArray(), list4.ToArray(), list5.ToArray(), sectionsCount, list6.ToArray(), list7.ToArray(), list8.ToArray());
		}

		internal HkDestructionStorage(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public class HkEasePenetrationAction : HkReferenceObject
	{
		public float InitialAdditionalAllowedPenetrationDepth
		{
			get
			{
				return HkEasePenetrationAction_GetInitialAdditionalAllowedPenetrationDepth(base.NativeObject);
			}
			set
			{
				HkEasePenetrationAction_SetInitialAdditionalAllowedPenetrationDepth(base.NativeObject, value);
			}
		}

		public float InitialAllowedPenetrationDepthMultiplier
		{
			get
			{
				return HkEasePenetrationAction_GetInitialAllowedPenetrationDepthMultiplier(base.NativeObject);
			}
			set
			{
				HkEasePenetrationAction_SetInitialAllowedPenetrationDepthMultiplier(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkEasePenetrationAction_Create(IntPtr body, float duration);

		[DllImport("Havok.dll")]
		private static extern float HkEasePenetrationAction_GetInitialAdditionalAllowedPenetrationDepth(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkEasePenetrationAction_SetInitialAdditionalAllowedPenetrationDepth(IntPtr instance, float initialAdditionalAllowedPenetrationDepth);

		[DllImport("Havok.dll")]
		private static extern float HkEasePenetrationAction_GetInitialAllowedPenetrationDepthMultiplier(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkEasePenetrationAction_SetInitialAllowedPenetrationDepthMultiplier(IntPtr instance, float initialAllowedPenetrationDepthMultiplier);

		public HkEasePenetrationAction(HkRigidBody body, float duration)
			: base(HkEasePenetrationAction_Create(body.NativeObject, duration))
		{
		}

		internal HkEasePenetrationAction(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public class HkGeometry : HkReferenceObject
	{
		public struct Triangle
		{
			public int A;

			public int B;

			public int C;

			public int Material;
		}

		public int TriangleCount => HkGeometry_GetTriangleCount(base.NativeObject);

		public int VertexCount => HkGeometry_GetVertexCount(base.NativeObject);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkGeometry_Create();

		[DllImport("Havok.dll")]
		private static extern IntPtr HkGeometry_CreateWithParams(int vCount, Vector3[] vertices, int iCount, int[] indices, int mCount, int[] materials);

		[DllImport("Havok.dll")]
		private static extern void HkGeometry_Destroy(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkGeometry_GetTriangleCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkGeometry_GetVertexCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkGeometry_Append(IntPtr instance, IntPtr geometry, Matrix matrix);

		[DllImport("Havok.dll")]
		private static extern void HkGeometry_GetTriangle(IntPtr instance, int triangleIndex, out Triangle outTriangle);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkGeometry_GetVertex(IntPtr instance, int vertexIndex);

		[DllImport("Havok.dll")]
		private static extern void HkGeometry_SetGeometry(IntPtr instance, int vCount, Vector3[] vertices, int iCount, int[] indices, int mCount, int[] materials);

		public HkGeometry()
		{
			m_handle = HkGeometry_Create();
		}

		internal HkGeometry(IntPtr handle)
		{
			m_handle = handle;
			AddReference();
		}

		public HkGeometry(List<Vector3> vertices, List<int> indices, List<int> materialIndices = null)
		{
			m_handle = HkGeometry_CreateWithParams(vertices.Count, vertices.ToArray(), indices.Count, indices.ToArray(), materialIndices?.Count ?? 0, materialIndices?.ToArray());
		}

		public void Append(HkGeometry geometry, Matrix matrix)
		{
			HkGeometry_Append(base.NativeObject, geometry.NativeObject, matrix);
		}

		public void GetTriangle(int triangleIndex, out int i0, out int i1, out int i2, out int materialIndex)
		{
			HkGeometry_GetTriangle(base.NativeObject, triangleIndex, out var outTriangle);
			i0 = outTriangle.A;
			i1 = outTriangle.B;
			i2 = outTriangle.C;
			materialIndex = outTriangle.Material;
		}

		public Vector3 GetVertex(int vertexIndex)
		{
			return HkGeometry_GetVertex(base.NativeObject, vertexIndex);
		}

		public void SetGeometry(List<Vector3> vertices, List<int> indices, List<int> materialIndices = null)
		{
			HkGeometry_SetGeometry(base.NativeObject, vertices.Count, vertices.ToArray(), indices.Count, indices.ToArray(), materialIndices?.Count ?? 0, materialIndices?.ToArray());
		}
	}
	public struct HkGroupFilter
	{
		private IntPtr m_handle;

		[DllImport("Havok.dll")]
		private static extern uint HkGroupFilter_CalcFilterInfo(int layer, int systemGroup, int subSystemId, int subSystemDontCollideWith);

		[DllImport("Havok.dll")]
		private static extern int HkGroupFilter_GetLayerFromFilterInfo(uint filterInfo);

		[DllImport("Havok.dll")]
		private static extern int HkGroupFilter_getSubSystemDontCollideWithFromFilterInfo(uint filterInfo);

		[DllImport("Havok.dll")]
		private static extern int HkGroupFilter_GetSubSystemIdFromFilterInfo(uint filterInfo);

		[DllImport("Havok.dll")]
		private static extern int HkGroupFilter_GetSystemGroupFromFilterInfo(uint filterInfo);

		[DllImport("Havok.dll")]
		private static extern int HkGroupFilter_SetLayer(uint filterInfo, int newLayer);

		[DllImport("Havok.dll")]
		private static extern void HkGroupFilter_DisableCollisionsBetween(IntPtr instance, int layerA, int layerB);

		[DllImport("Havok.dll")]
		private static extern void HkGroupFilter_DisableCollisionsUsingBitfield(IntPtr instance, uint layerBitsA, uint layerBitsB);

		[DllImport("Havok.dll")]
		private static extern void HkGroupFilter_EnableCollisionsBetween(IntPtr instance, int layerA, int layerB);

		[DllImport("Havok.dll")]
		private static extern void HkGroupFilter_EnableCollisionsUsingBitfield(IntPtr instance, uint layerBitsA, uint layerBitsB);

		[DllImport("Havok.dll")]
		private static extern int HkGroupFilter_GetNewSystemGroup(IntPtr instance);

		public static uint CalcFilterInfo(int layer, int systemGroup, int subSystemId, int subSystemDontCollideWith)
		{
			return HkGroupFilter_CalcFilterInfo(layer, systemGroup, subSystemId, subSystemDontCollideWith);
		}

		public static uint CalcFilterInfo(int layer, int systemGroup)
		{
			return HkGroupFilter_CalcFilterInfo(layer, systemGroup, 0, 0);
		}

		public static int GetLayerFromFilterInfo(uint filterInfo)
		{
			return HkGroupFilter_GetLayerFromFilterInfo(filterInfo);
		}

		public static int getSubSystemDontCollideWithFromFilterInfo(uint filterInfo)
		{
			return HkGroupFilter_getSubSystemDontCollideWithFromFilterInfo(filterInfo);
		}

		public static int GetSubSystemIdFromFilterInfo(uint filterInfo)
		{
			return HkGroupFilter_GetSubSystemIdFromFilterInfo(filterInfo);
		}

		public static int GetSystemGroupFromFilterInfo(uint filterInfo)
		{
			return HkGroupFilter_GetSystemGroupFromFilterInfo(filterInfo);
		}

		public static int SetLayer(uint filterInfo, int newLayer)
		{
			return HkGroupFilter_SetLayer(filterInfo, newLayer);
		}

		public void DisableCollisionsBetween(int layerA, int layerB)
		{
			HkGroupFilter_DisableCollisionsBetween(m_handle, layerA, layerB);
		}

		public void DisableCollisionsUsingBitfield(uint layerBitsA, uint layerBitsB)
		{
			HkGroupFilter_DisableCollisionsUsingBitfield(m_handle, layerBitsA, layerBitsB);
		}

		public void EnableCollisionsBetween(int layerA, int layerB)
		{
			HkGroupFilter_EnableCollisionsBetween(m_handle, layerA, layerB);
		}

		public void EnableCollisionsUsingBitfield(uint layerBitsA, uint layerBitsB)
		{
			HkGroupFilter_EnableCollisionsUsingBitfield(m_handle, layerBitsA, layerBitsB);
		}

		public int GetNewSystemGroup()
		{
			return HkGroupFilter_GetNewSystemGroup(m_handle);
		}

		internal HkGroupFilter(IntPtr ptr)
		{
			m_handle = ptr;
		}
	}
	public struct HkMassElement
	{
		public HkMassProperties Properties;

		public Matrix Tranform;

		public HkMassElement(ref HkMassProperties properties, ref Matrix transform)
		{
			Properties = properties;
			Tranform = transform;
		}
	}
	public class HkInertiaTensorComputer : HkHandle
	{
		[ThreadStatic]
		private static HkInertiaTensorComputer s_inertiaComputer;

		private static HkInertiaTensorComputer Instance
		{
			get
			{
				if (s_inertiaComputer == null)
				{
					s_inertiaComputer = new HkInertiaTensorComputer();
					GC.SuppressFinalize(s_inertiaComputer);
				}
				return s_inertiaComputer;
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkInertiaTensorComputer_Create();

		[DllImport("Havok.dll")]
		private static extern void HkInertiaTensorComputer_CombineMassPropertiesInstance(IntPtr instance, IntPtr massElements, int count, out HkMassProperties returnMassProperties);

		[DllImport("Havok.dll")]
		private static extern void HkInertiaTensorComputer_Release(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkInertiaTensorComputer_ComputeBoxVolumeMassProperties(Vector3 halfExtents, float mass, out HkMassProperties returnMassProperties);

		[DllImport("Havok.dll")]
		private static extern void HkInertiaTensorComputer_ComputeCapsuleVolumeMassProperties(Vector3 startAxis, Vector3 endAxis, float radius, float mass, out HkMassProperties returnMassProperties);

		[DllImport("Havok.dll")]
		private static extern void HkInertiaTensorComputer_ComputeCylinderVolumeMassProperties(Vector3 startAxis, Vector3 endAxis, float radius, float mass, out HkMassProperties returnMassProperties);

		[DllImport("Havok.dll")]
		private static extern void HkInertiaTensorComputer_ComputeSphereVolumeMassProperties(float radius, float mass, out HkMassProperties returnMassProperties);

		public static HkMassProperties ComputeBoxVolumeMassProperties(Vector3 halfExtents, float mass)
		{
			HkInertiaTensorComputer_ComputeBoxVolumeMassProperties(halfExtents, mass, out var returnMassProperties);
			return returnMassProperties;
		}

		public static HkMassProperties ComputeCapsuleVolumeMassProperties(Vector3 startAxis, Vector3 endAxis, float radius, float mass)
		{
			HkInertiaTensorComputer_ComputeCapsuleVolumeMassProperties(startAxis, endAxis, radius, mass, out var returnMassProperties);
			return returnMassProperties;
		}

		public static HkMassProperties ComputeCylinderVolumeMassProperties(Vector3 startAxis, Vector3 endAxis, float radius, float mass)
		{
			HkInertiaTensorComputer_ComputeCylinderVolumeMassProperties(startAxis, endAxis, radius, mass, out var returnMassProperties);
			return returnMassProperties;
		}

		public static HkMassProperties ComputeSphereVolumeMassProperties(float radius, float mass)
		{
			HkInertiaTensorComputer_ComputeSphereVolumeMassProperties(radius, mass, out var returnMassProperties);
			return returnMassProperties;
		}

		public static void CombineMassProperties(Span<HkMassElement> elements, out HkMassProperties massProperties)
		{
			Instance.CombineMassPropertiesInstance(elements, out massProperties);
		}

		public HkInertiaTensorComputer()
			: base(HkInertiaTensorComputer_Create())
		{
		}

		protected sealed override void Dispose(bool disposing)
		{
			HkInertiaTensorComputer_Release(base.NativeObject);
		}

		public unsafe void CombineMassPropertiesInstance(Span<HkMassElement> elements, out HkMassProperties massProperties)
		{
			fixed (HkMassElement* value = elements)
			{
				HkInertiaTensorComputer_CombineMassPropertiesInstance(m_handle, new IntPtr(value), elements.Length, out massProperties);
			}
		}
	}
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HkMassProperties
	{
		public float Volume;

		public float Mass;

		public Vector3 CenterOfMass;

		public Matrix InertiaTensor;

		public HkMassProperties(float volume, float mass, Vector3 centerOfMass, Matrix inertiaTensor)
		{
			Volume = volume;
			Mass = mass;
			CenterOfMass = centerOfMass;
			InertiaTensor = inertiaTensor;
		}
	}
	public class HkMemorySnapshot : HkHandle
	{
		[DllImport("Havok.dll")]
		private static extern void HkMemorySnapshot_Diff(IntPtr a, IntPtr b, out int inA, out int inB);

		public static void Diff(HkMemorySnapshot a, HkMemorySnapshot b, out int inA, out int inB)
		{
			HkMemorySnapshot_Diff(a.NativeObject, b.NativeObject, out inA, out inB);
		}

		public void RemoveReference()
		{
			HkHandle.ReleasePtr(base.NativeObject);
		}

		internal HkMemorySnapshot(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public struct HkPropertyBase
	{
		internal IntPtr NativeObject;

		public int ReferenceCount => HkReferenceObject.HkReferenceObject_ReferenceCount(NativeObject);

		public bool IsValid => NativeObject != IntPtr.Zero;

		public void AddReference()
		{
			HkReferenceObject.HkReferenceObject_AddReference(NativeObject);
		}

		public void RemoveReference()
		{
			HkReferenceObject.HkReferenceObject_RemoveReference(NativeObject);
		}

		internal HkPropertyBase(IntPtr ptr)
		{
			NativeObject = ptr;
		}
	}
	public class HkShapeCutterUtil
	{
		[DllImport("Havok.dll")]
		private static extern bool HkShapeCutterUtil_Cut(IntPtr shape, Vector4 plane, out Vector3 aabbMin, out Vector3 aabbMax);

		public static bool Cut(HkShape shape, Vector4 plane, out Vector3 aabbMin, out Vector3 aabbMax)
		{
			return HkShapeCutterUtil_Cut(shape.NativeObject, plane, out aabbMin, out aabbMax);
		}
	}
	public struct HkSimpleValueProperty
	{
		public HkPropertyBase Base;

		internal IntPtr NativeObject => Base.NativeObject;

		public float ValueFloat
		{
			get
			{
				return HkSimpleValueProperty_GetValueFloat(NativeObject);
			}
			set
			{
				HkSimpleValueProperty_SetValueFloat(NativeObject, value);
			}
		}

		public uint ValueUInt
		{
			get
			{
				return HkSimpleValueProperty_GetValueUInt(NativeObject);
			}
			set
			{
				HkSimpleValueProperty_SetValueUInt(NativeObject, value);
			}
		}

		public int ValueInt
		{
			get
			{
				return HkSimpleValueProperty_GetValueInt(NativeObject);
			}
			set
			{
				HkSimpleValueProperty_SetValueInt(NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkSimpleValueProperty_CreateFloat(float value);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkSimpleValueProperty_CreateUInt(uint value);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkSimpleValueProperty_CreateInt(int value);

		[DllImport("Havok.dll")]
		private static extern float HkSimpleValueProperty_GetValueFloat(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkSimpleValueProperty_SetValueFloat(IntPtr instance, float valueFloat);

		[DllImport("Havok.dll")]
		private static extern uint HkSimpleValueProperty_GetValueUInt(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkSimpleValueProperty_SetValueUInt(IntPtr instance, uint valueUInt);

		[DllImport("Havok.dll")]
		private static extern int HkSimpleValueProperty_GetValueInt(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkSimpleValueProperty_SetValueInt(IntPtr instance, int calueInt);

		public HkSimpleValueProperty(float value)
		{
			Base = new HkPropertyBase(HkSimpleValueProperty_CreateFloat(value));
		}

		public HkSimpleValueProperty(uint value)
		{
			Base = new HkPropertyBase(HkSimpleValueProperty_CreateUInt(value));
		}

		public HkSimpleValueProperty(int value)
		{
			Base = new HkPropertyBase(HkSimpleValueProperty_CreateInt(value));
		}

		public bool IsValid()
		{
			if (Base.IsValid)
			{
				return Base.ReferenceCount > 0;
			}
			return false;
		}

		public void AddReference()
		{
			Base.AddReference();
		}

		public void RemoveReference()
		{
			Base.RemoveReference();
		}

		public static implicit operator HkPropertyBase(HkSimpleValueProperty prop)
		{
			return new HkPropertyBase(prop.NativeObject);
		}

		public static implicit operator HkSimpleValueProperty(HkPropertyBase prop)
		{
			return new HkSimpleValueProperty(prop.NativeObject);
		}

		internal HkSimpleValueProperty(IntPtr ptr)
		{
			Base = new HkPropertyBase(ptr);
		}
	}
	public struct HkVec3IProperty
	{
		public HkPropertyBase Base;

		internal IntPtr NativeObject => Base.NativeObject;

		public Vector3I Value
		{
			get
			{
				return HkVec3IProperty_GetValue(NativeObject);
			}
			set
			{
				HkVec3IProperty_SetValue(NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkVec3IProperty_Create(Vector3I value);

		[DllImport("Havok.dll")]
		private static extern Vector3I HkVec3IProperty_GetValue(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkVec3IProperty_SetValue(IntPtr instance, Vector3I value);

		public HkVec3IProperty(Vector3I value)
		{
			Base = new HkPropertyBase(HkVec3IProperty_Create(value));
		}

		public bool IsValid()
		{
			if (Base.IsValid)
			{
				return Base.ReferenceCount > 0;
			}
			return false;
		}

		public void AddReference()
		{
			Base.AddReference();
		}

		public void RemoveReference()
		{
			Base.RemoveReference();
		}

		public static implicit operator HkPropertyBase(HkVec3IProperty prop)
		{
			return new HkPropertyBase(prop.NativeObject);
		}

		public static implicit operator HkVec3IProperty(HkPropertyBase prop)
		{
			return new HkVec3IProperty(prop.NativeObject);
		}

		internal HkVec3IProperty(IntPtr ptr)
		{
			Base = new HkPropertyBase(ptr);
		}
	}
	public class HkWheelResponseModifierUtil : HkHandle
	{
		public delegate float ReturnFloat();

		private delegate float CalculateModifier(IntPtr handle);

		private readonly ReturnFloat m_softness;

		private readonly ReturnFloat m_acceleration;

		private static readonly CalculateModifier Softness = CalculateSoftnessModifier;

		private static readonly CalculateModifier Acceleration = CalculateAccelerationModifier;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkWheelResponseModifierUtil_Create(IntPtr rigidBody, CalculateModifier softness, CalculateModifier acceleration);

		[DllImport("Havok.dll")]
		private static extern void HkWheelResponseModifierUtil_Release(IntPtr instance);

		public static HkWheelResponseModifierUtil Create(HkRigidBody rigidBody, ReturnFloat softness, ReturnFloat acceleration)
		{
			return new HkWheelResponseModifierUtil(rigidBody, softness, acceleration);
		}

		public HkWheelResponseModifierUtil(HkRigidBody rigidBody, ReturnFloat softness, ReturnFloat acceleration)
			: base(HkWheelResponseModifierUtil_Create(rigidBody.NativeObject, Softness, Acceleration), track: true)
		{
			m_softness = softness;
			m_acceleration = acceleration;
		}

		protected override void Dispose(bool disposing)
		{
		}

		[MonoPInvokeCallback(typeof(CalculateModifier))]
		private static float CalculateSoftnessModifier(IntPtr handle)
		{
			if (HkHandle.TryGetHandle<HkWheelResponseModifierUtil>(handle, out var handle2))
			{
				return handle2.m_softness();
			}
			return 1f;
		}

		[MonoPInvokeCallback(typeof(CalculateModifier))]
		private static float CalculateAccelerationModifier(IntPtr handle)
		{
			if (HkHandle.TryGetHandle<HkWheelResponseModifierUtil>(handle, out var handle2))
			{
				return handle2.m_acceleration();
			}
			return 1f;
		}
	}
	public static class HkAccessControl
	{
		public enum AccessState
		{
			Exclusive,
			SharedRead
		}

		public struct AccessStateToken : IDisposable
		{
			private readonly AccessState m_previousState;

			public AccessStateToken(AccessState newState)
			{
				m_previousState = State;
				State = newState;
			}

			public void Dispose()
			{
				State = m_previousState;
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		internal readonly struct AccessToken : IDisposable
		{
			public AccessToken(AccessType access, bool taken, bool allowDuringSimulation = false)
			{
			}

			public void Dispose()
			{
			}
		}

		internal enum AccessType
		{
			Read,
			Write
		}

		private static readonly Stack<Thread> m_previousOwner = new Stack<Thread>();

		private static Thread m_currentUserThread;

		private static AccessState m_state;

		private static bool m_writing = false;

		private static int m_readCount = 0;

		public static AccessState State
		{
			get
			{
				return m_state;
			}
			set
			{
				_ = m_currentUserThread;
				_ = Thread.CurrentThread;
				if (!m_writing)
				{
					_ = m_readCount;
					_ = 0;
				}
				m_state = value;
			}
		}

		internal static void Init()
		{
			m_currentUserThread = Thread.CurrentThread;
		}

		[Conditional("ACCESS_CHECKING")]
		public static void TakeOwnership()
		{
			if (!m_writing && m_readCount <= 0 && State == AccessState.Exclusive)
			{
				m_previousOwner.Push(m_currentUserThread);
				m_currentUserThread = Thread.CurrentThread;
			}
		}

		[Conditional("ACCESS_CHECKING")]
		public static void ReleaseOwnership()
		{
			if (m_currentUserThread == Thread.CurrentThread && !m_writing && m_readCount <= 0 && State == AccessState.Exclusive && m_previousOwner.Count != 0)
			{
				m_currentUserThread = m_previousOwner.Pop();
			}
		}

		public static AccessStateToken PushState(AccessState newState)
		{
			return new AccessStateToken(newState);
		}

		internal static AccessToken Read()
		{
			return new AccessToken(AccessType.Read, taken: true);
		}

		internal static AccessToken Read(HkEntity entity)
		{
			return new AccessToken(AccessType.Read, entity.InWorldInternal);
		}

		internal static AccessToken Read(HkShape shape)
		{
			if (HkShape.CheckReadOnly(shape))
			{
				return new AccessToken(AccessType.Read, taken: false);
			}
			return new AccessToken(AccessType.Read, HkShape.AnyOwnerInWorld(shape));
		}

		internal static AccessToken Write(bool allowDuringStep = false)
		{
			return new AccessToken(AccessType.Write, taken: true, allowDuringStep);
		}

		internal static AccessToken Write(HkEntity entity, bool allowDuringStep = false)
		{
			return new AccessToken(AccessType.Write, entity.InWorldInternal, allowDuringStep);
		}

		internal static AccessToken Write(HkShape shape, bool allowDuringStep = false)
		{
			HkShape.CheckReadOnly(shape);
			return new AccessToken(AccessType.Write, HkShape.AnyOwnerInWorld(shape), allowDuringStep);
		}

		private static void BeginRead()
		{
		}

		private static void EndRead()
		{
		}

		private static bool BeginWrite(bool allowDuringStep)
		{
			return false;
		}

		private static void EndWrite()
		{
		}
	}
	public delegate void HkActivationHandler();
	public class HkActivationListener : HkHandle
	{
		private delegate void HkActivationHandlerCpp(IntPtr handler);

		private readonly HkActivationHandler m_onActivated;

		private readonly HkActivationHandler m_onDeactivated;

		private static readonly HkActivationHandlerCpp OnActivatedCpp = HandleActivation;

		private static readonly HkActivationHandlerCpp OnDeactivatedCpp = HandleDeactivation;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkActivationListener_Create(HkActivationHandlerCpp onActivate, HkActivationHandlerCpp onDeactivate);

		public HkActivationListener(HkActivationHandler onActivated, HkActivationHandler onDeactivated)
			: base(HkActivationListener_Create(OnActivatedCpp, OnDeactivatedCpp), track: true)
		{
			m_onActivated = onActivated;
			m_onDeactivated = onDeactivated;
		}

		public static implicit operator IntPtr(HkActivationListener obj)
		{
			return obj.m_handle;
		}

		[MonoPInvokeCallback(typeof(HkActivationHandlerCpp))]
		private static void HandleActivation(IntPtr handler)
		{
			if (HkHandle.TryGetHandle<HkActivationListener>(handler, out var handle))
			{
				handle.m_onActivated();
			}
		}

		[MonoPInvokeCallback(typeof(HkActivationHandlerCpp))]
		private static void HandleDeactivation(IntPtr handler)
		{
			if (HkHandle.TryGetHandle<HkActivationListener>(handler, out var handle))
			{
				handle.m_onDeactivated();
			}
		}
	}
	public static class HkBaseSystem
	{
		public delegate void Log(string message);

		private static Log m_logCallback;

		private static Log LogWrapperCallback = WriteLog;

		[ThreadStatic]
		private static bool m_isMainThread;

		[ThreadStatic]
		private static bool m_isThreadInitialized;

		[ThreadStatic]
		private static string m_threadName;

		[ThreadStatic]
		private static IntPtr m_threadRouter;

		public static string GameName => "SpaceEngineers";

		public static string ThreadName => m_threadName;

		public static bool IsMainThread => m_isMainThread;

		public static bool IsThreadInitialized => m_isThreadInitialized;

		public static bool DestructionEnabled => HkBaseSystem_IsDestructionEnabled();

		public static bool IsInitialized { get; private set; }

		public static bool IsSimulating { get; private set; }

		public static bool IsOutOfMemory => HkBaseSystem_IsOutOfMemory();

		[DllImport("Havok.dll")]
		private static extern void HkBaseSystem_Init(int solverMemorySize, Log log, [MarshalAs(UnmanagedType.U1)] bool deepProfiling);

		[DllImport("Havok.dll")]
		private static extern void HkBaseSystem_Quit();

		[DllImport("Havok.dll")]
		private static extern IntPtr HkBaseSystem_InitThread();

		[DllImport("Havok.dll")]
		private static extern void HkBaseSystem_QuitThread(IntPtr threadRouter);

		[DllImport("Havok.dll")]
		private static extern void HkBaseSystem_GetVersionInfo(ref HkManagedIntermediateBuffer.Native buffer);

		[DllImport("Havok.dll")]
		private static extern void HkBaseSystem_GetMemoryStatistics(ref HkManagedIntermediateBuffer.Native buffer);

		[DllImport("Havok.dll")]
		private static extern void HkBaseSystem_EnableAssert(int assertId, [MarshalAs(UnmanagedType.I1)] bool enable);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkBaseSystem_IsEnabled(int assertId);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkBaseSystem_IsDestructionEnabled();

		[DllImport("Havok.dll")]
		private static extern void HkBaseSystem_OnSimulationFrameStarted(long frameNumber);

		[DllImport("Havok.dll")]
		private static extern void HkBaseSystem_OnSimulationFrameFinished();

		[DllImport("Havok.dll")]
		private static extern int HkBaseSystem_GetKeyCodes(out IntPtr keyCodes);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkBaseSystem_IsOutOfMemory();

		[DllImport("Havok.dll")]
		private static extern long HkBaseSystem_GetCurrentMemoryConsumption();

		public static void Init(Action<string> LogCallback, bool deepProfilingEnabled, ISharedCriticalSection hkShapeCriticalSection)
		{
			Init(5242880, LogCallback, deepProfilingEnabled, hkShapeCriticalSection);
		}

		public static void Init(int solverMemorySize, Action<string> LogCallback, bool deepProfiling, ISharedCriticalSection hkShapeCriticalSection)
		{
			Action<string> @object = LogCallback ?? ((Action<string>)delegate
			{
			});
			m_logCallback = @object.Invoke;
			m_logCallback("Physics.Init");
			m_logCallback("Version: " + GetVersionInfo());
			InitThreadInfo(isMain: true, "HavokMainThread");
			HkBaseSystem_Init(solverMemorySize, LogWrapperCallback, deepProfiling);
			HkShape.SharedCriticalSection = hkShapeCriticalSection;
			IsInitialized = true;
			HkAccessControl.Init();
		}

		public static void Quit()
		{
			IsInitialized = false;
			GC.Collect();
			GC.WaitForPendingFinalizers();
			HkVDB.ReleaseResources();
			HkTaskProfiler.ReleaseResources();
			HkBaseSystem_Quit();
			FreeThreadInfo();
			HkShape.ReportOwnership();
		}

		public static void InitThread(string name)
		{
			if (!IsInitialized)
			{
				throw new InvalidOperationException("HkBaseSystem is not initialized.");
			}
			InitThreadInfo(isMain: false, name);
			m_threadRouter = HkBaseSystem_InitThread();
		}

		public static void QuitThread()
		{
			if (!IsInitialized)
			{
				throw new InvalidOperationException("HkBaseSystem is not initialized.");
			}
			if (m_threadRouter != IntPtr.Zero)
			{
				HkBaseSystem_QuitThread(m_threadRouter);
				m_threadRouter = IntPtr.Zero;
			}
			FreeThreadInfo();
		}

		public unsafe static string[] GetKeyCodes()
		{
			IntPtr keyCodes;
			int num = HkBaseSystem_GetKeyCodes(out keyCodes);
			char** ptr = (char**)keyCodes.ToPointer();
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new string(ptr[i]);
			}
			return array;
		}

		public unsafe static string GetVersionInfo()
		{
			Span<byte> span = stackalloc byte[64];
			HkManagedIntermediateBuffer hkManagedIntermediateBuffer = HkManagedIntermediateBuffer.Create(span);
			HkBaseSystem_GetVersionInfo(ref hkManagedIntermediateBuffer.NativeToken);
			string result = Marshal.PtrToStringAnsi(new IntPtr(hkManagedIntermediateBuffer.NativeToken.Buffer));
			hkManagedIntermediateBuffer.Dispose();
			return result;
		}

		public unsafe static void GetMemoryStatistics(StringBuilder output)
		{
			Span<byte> span = stackalloc byte[1024];
			HkManagedIntermediateBuffer hkManagedIntermediateBuffer = HkManagedIntermediateBuffer.Create(span);
			HkBaseSystem_GetMemoryStatistics(ref hkManagedIntermediateBuffer.NativeToken);
			for (byte* ptr = (byte*)hkManagedIntermediateBuffer.NativeToken.Buffer; *ptr != 0; ptr++)
			{
				output.Append((char)(*ptr));
			}
			hkManagedIntermediateBuffer.Dispose();
		}

		public static void EnableAssert(int assertId, bool enable)
		{
			HkBaseSystem_EnableAssert(assertId, enable);
		}

		public static bool IsEnabled(int assertId)
		{
			return HkBaseSystem_IsEnabled(assertId);
		}

		public static HkMemorySnapshot GetMemorySnapshot()
		{
			return null;
		}

		public static long GetCurrentMemoryConsumption()
		{
			return HkBaseSystem_GetCurrentMemoryConsumption();
		}

		[MonoPInvokeCallback(typeof(Log))]
		internal static void WriteLog(string message)
		{
			m_logCallback?.Invoke(message);
		}

		private static void InitThreadInfo(bool isMain, string threadName)
		{
			m_isMainThread = isMain;
			m_isThreadInitialized = true;
			m_threadName = threadName;
		}

		private static void FreeThreadInfo()
		{
			m_isMainThread = (m_isThreadInitialized = false);
			m_threadName = string.Empty;
		}

		public static void OnSimulationFrameStarted(long staticSimulationFrameCounter)
		{
			IsSimulating = true;
			HkBaseSystem_OnSimulationFrameStarted(staticSimulationFrameCounter);
		}

		public static void OnSimulationFrameFinished()
		{
			IsSimulating = false;
			HkBaseSystem_OnSimulationFrameFinished();
		}
	}
	public struct HkCallbackInfo
	{
		public int TypeId;

		public int ObjectId;

		public void Check(HkCallbackInfo other)
		{
			_ = TypeId;
			_ = other.TypeId;
			_ = ObjectId;
			_ = other.ObjectId;
		}
	}
	public static class HkCallbackInfoManager
	{
		private static readonly Dictionary<int, int> m_objectCounters = new Dictionary<int, int>();

		private static readonly Dictionary<Type, int> m_typeIndex = new Dictionary<Type, int>();

		private static int m_lastTypeIndex = 0;

		public static HkCallbackInfo Get<T>()
		{
			HkCallbackInfo result = default(HkCallbackInfo);
			if (m_typeIndex.TryGetValue(typeof(T), out var value))
			{
				result.TypeId = value;
				result.ObjectId = ++m_objectCounters[value];
			}
			else
			{
				result.TypeId = ++m_lastTypeIndex;
				result.ObjectId = 1;
				m_typeIndex.Add(typeof(T), m_lastTypeIndex);
				m_objectCounters.Add(m_lastTypeIndex, 1);
			}
			return result;
		}
	}
	public struct HkCollisionEvent
	{
		public enum CallbackSource
		{
			A,
			B,
			World
		}

		private static readonly int BodyPointersOffset;

		private IntPtr m_handle;

		internal IntPtr NativeObject => m_handle;

		public CallbackSource Source => (CallbackSource)HkCollisionEvent_GetSource(m_handle);

		public unsafe HkRigidBody BodyA
		{
			get
			{
				IntPtr bodyPointers = *GetBodyPointers(m_handle);
				return GetBody(bodyPointers);
			}
		}

		public unsafe HkRigidBody BodyB
		{
			get
			{
				IntPtr rigidBodyPtr = GetBodyPointers(m_handle)[1];
				return GetBody(rigidBodyPtr);
			}
		}

		public int NrContactPoints => HkCollisionEvent_GetContactPointCount(m_handle);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern int HkCollisionEvent_GetSource(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern IntPtr HkCollisionEvent_GetRigidBody(IntPtr instance, int bodyIndex);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern IntPtr HkCollisionEvent_GetBodyA(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern IntPtr HkCollisionEvent_GetBodyB(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool HkCollisionEvent_SetImpulse(IntPtr instance, float impulse);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void HkCollisionEvent_SetImpulseScaling(IntPtr instance, float impulse, float maxAccel);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern int HkCollisionEvent_GetContactPointCount(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void HkCollisionEvent_Disable(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern IntPtr HkCollisionEvent_GetContactPointPropertiesAt(IntPtr instance, int index);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void HkCollisionEvent_GetOffsets(out int bodyPointerOffset);

		static HkCollisionEvent()
		{
			HkCollisionEvent_GetOffsets(out BodyPointersOffset);
		}

		private unsafe static IntPtr* GetBodyPointers(IntPtr @event)
		{
			return (IntPtr*)(@event + BodyPointersOffset).ToPointer();
		}

		public unsafe HkRigidBody GetRigidBody(int bodyIndex)
		{
			IntPtr rigidBodyPtr = GetBodyPointers(m_handle)[bodyIndex];
			return GetBody(rigidBodyPtr);
		}

		internal HkCollisionEvent(IntPtr inHandle)
		{
			m_handle = inHandle;
		}

		private HkRigidBody GetBody(IntPtr rigidBodyPtr)
		{
			return HkRigidBody.Get(rigidBodyPtr);
		}

		public bool SetImpulse(float impulse)
		{
			return HkCollisionEvent_SetImpulse(m_handle, impulse);
		}

		public void SetImpulseScaling(float impulse, float maxAccel)
		{
			HkCollisionEvent_SetImpulseScaling(m_handle, impulse, maxAccel);
		}

		public void Disable()
		{
			HkCollisionEvent_Disable(m_handle);
		}

		public HkContactPointProperties GetContactPointPropertiesAt(int i)
		{
			return new HkContactPointProperties(HkCollisionEvent_GetContactPointPropertiesAt(m_handle, i));
		}
	}
	public sealed class HkConstraintProjectorListener : HkHandle
	{
		[DllImport("Havok.dll")]
		internal static extern IntPtr HkConstraintProjectorListener_Create(IntPtr world);

		[DllImport("Havok.dll")]
		internal static extern void HkConstraintProjectorListener_Release(IntPtr listener);

		public HkConstraintProjectorListener(HkWorld world)
			: base(HkConstraintProjectorListener_Create(world.NativeObject))
		{
		}

		protected override void Dispose(bool disposing)
		{
			HkConstraintProjectorListener_Release(m_handle);
		}
	}
	public delegate void HkCollisionEventHandler(ref HkCollisionEvent collisionEvent);
	public delegate void HkContactPointEventHandler(ref HkContactPointEvent contactEvent);
	public class HkContactListener : HkHandle
	{
		private delegate void CollisionHandler(IntPtr handle, IntPtr collisionEvent);

		private delegate void ContactPointHandler(IntPtr handle, IntPtr contactPointEvent);

		private static readonly ContactPointHandler OnContactCallback = OnContact;

		private static readonly CollisionHandler CollisionAddedCallback = CollisionAdded;

		private static readonly CollisionHandler CollisionRemovedCallback = CollisionRemoved;

		private readonly HkContactPointEventHandler m_onContact;

		private readonly HkCollisionEventHandler m_collisionAddedHandler;

		private readonly HkCollisionEventHandler m_collisionRemovedHandler;

		private int m_callbackLimit;

		public int CallbackLimit
		{
			get
			{
				return m_callbackLimit;
			}
			set
			{
				m_callbackLimit = value;
				HkContactListener_SetCallbackLimit(m_handle, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkContactListener_Create(ContactPointHandler onContact, CollisionHandler collisionAdded, CollisionHandler collisionRemoved, int callbackLimit);

		[DllImport("Havok.dll")]
		private static extern void HkContactListener_SetCallbackLimit(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern void HkContactListener_ResetLimit(IntPtr instance);

		public HkContactListener(HkContactPointEventHandler onContact, HkCollisionEventHandler collisionAdded, HkCollisionEventHandler collisionRemoved, int callbackLimit)
			: base(HkContactListener_Create(OnContactCallback, CollisionAddedCallback, CollisionRemovedCallback, callbackLimit), track: true)
		{
			m_onContact = onContact;
			m_collisionAddedHandler = collisionAdded;
			m_collisionRemovedHandler = collisionRemoved;
		}

		public static implicit operator IntPtr(HkContactListener obj)
		{
			return obj.m_handle;
		}

		public void ResetLimit()
		{
			HkContactListener_ResetLimit(m_handle);
		}

		[MonoPInvokeCallback(typeof(ContactPointHandler))]
		private static void OnContact(IntPtr handle, IntPtr contactPointEvent)
		{
			if (HkHandle.TryGetHandle<HkContactListener>(handle, out var handle2))
			{
				HkContactPointEvent contactEvent = new HkContactPointEvent(contactPointEvent);
				handle2.m_onContact(ref contactEvent);
			}
		}

		[MonoPInvokeCallback(typeof(CollisionHandler))]
		private static void CollisionAdded(IntPtr handle, IntPtr collisionEvent)
		{
			if (HkHandle.TryGetHandle<HkContactListener>(handle, out var handle2))
			{
				HkCollisionEvent collisionEvent2 = new HkCollisionEvent(collisionEvent);
				handle2.m_collisionAddedHandler(ref collisionEvent2);
			}
		}

		[MonoPInvokeCallback(typeof(CollisionHandler))]
		private static void CollisionRemoved(IntPtr handle, IntPtr collisionEvent)
		{
			if (HkHandle.TryGetHandle<HkContactListener>(handle, out var handle2))
			{
				HkCollisionEvent collisionEvent2 = new HkCollisionEvent(collisionEvent);
				handle2.m_collisionRemovedHandler(ref collisionEvent2);
			}
		}
	}
	public struct HkContactPoint
	{
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 32)]
		private struct Layout
		{
			[FieldOffset(0)]
			public Vector3 Position;

			[FieldOffset(16)]
			public Vector3 Normal;

			[FieldOffset(20)]
			public float Distance;

			[FieldOffset(16)]
			public Vector4 NormalAndDistance;
		}

		private IntPtr m_handle;

		internal IntPtr NativeObject => m_handle;

		public unsafe Vector3 Position
		{
			get
			{
				return ((Layout*)m_handle.ToPointer())->Position;
			}
			set
			{
				HkContactPoint_SetPosition(m_handle, value);
			}
		}

		public unsafe Vector4 NormalAndDistance
		{
			get
			{
				return ((Layout*)m_handle.ToPointer())->NormalAndDistance;
			}
			set
			{
				HkContactPoint_SetNormalAndDistance(m_handle, value);
			}
		}

		public unsafe Vector3 Normal
		{
			get
			{
				return ((Layout*)m_handle.ToPointer())->Normal;
			}
			set
			{
				HkContactPoint_SetNormal(m_handle, value);
			}
		}

		public unsafe float Distance
		{
			get
			{
				return ((Layout*)m_handle.ToPointer())->Distance;
			}
			set
			{
				HkContactPoint_SetDistance(m_handle, value);
			}
		}

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern Vector3 HkContactPoint_GetPosition(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPoint_SetPosition(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern Vector4 HkContactPoint_GetNormalAndDistance(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPoint_SetNormalAndDistance(IntPtr instance, Vector4 value);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern Vector3 HkContactPoint_GetNormal(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPoint_SetNormal(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern float HkContactPoint_GetDistance(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPoint_SetDistance(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPoint_Flip(IntPtr instance);

		public void Flip()
		{
			HkContactPoint_Flip(m_handle);
		}

		internal HkContactPoint(IntPtr contactPoint)
		{
			m_handle = contactPoint;
		}
	}
	public struct HkContactPointEvent
	{
		public enum Type
		{
			Toi,
			ExpandManifold,
			Manifold,
			ManifoldAtEndOfStep,
			ManifoldFromSavedContactPoint
		}

		private static readonly int SeparatingVelocityOffset;

		private static readonly int TypeOffset;

		private static readonly int PropertiesOffset;

		private static readonly int ContactPointOffset;

		private static readonly int FiringCallbacksForFullManifoldOffset;

		private static readonly int FirstCallbackForFullManifoldOffset;

		private static readonly int LastCallbackForFullManifoldOffset;

		public readonly HkCollisionEvent Base;

		public readonly HkContactPoint ContactPoint;

		public readonly HkContactPointProperties ContactProperties;

		private IntPtr NativeObject => Base.NativeObject;

		public bool IsToi => GetType(NativeObject) <= Type.Toi;

		public unsafe float SeparatingVelocity
		{
			get
			{
				float* separatingVelocity = GetSeparatingVelocity(NativeObject);
				if (separatingVelocity == null)
				{
					return HkContactPointEvent_GetSeparatingVelocity(NativeObject);
				}
				return *separatingVelocity;
			}
			set
			{
				float* separatingVelocity = GetSeparatingVelocity(NativeObject);
				if (separatingVelocity == null)
				{
					throw new InvalidOperationException("This contact point type does not allow manipulation of the separating velocity.");
				}
				*separatingVelocity = value;
			}
		}

		public float RotateNormal
		{
			get
			{
				CheckType(Type.Toi);
				return HkContactPointEvent_GetRotateNormal(NativeObject);
			}
			set
			{
				CheckType(Type.Toi);
				HkContactPointEvent_SetRotateNormal(NativeObject, value);
			}
		}

		public Type EventType => GetType(NativeObject);

		public bool FiringCallbacksForFullManifold => GetFiringCallbacksForFullManifold(NativeObject);

		public bool FirstCallbackForFullManifold => GetFirstCallbackForFullManifold(NativeObject);

		public bool LastCallbackForFullManifold => GetLastCallbackForFullManifold(NativeObject);

		public ushort ContactPointId => HkContactPointEvent_GetContactPointId(NativeObject);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern IntPtr HkContactPointEvent_GetBase(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkContactPointEvent_IsToi(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern float HkContactPointEvent_GetSeparatingVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPointEvent_SetSeparatingVelocity(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern float HkContactPointEvent_GetRotateNormal(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPointEvent_SetRotateNormal(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern int HkContactPointEvent_GetEventType(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern IntPtr HkContactPointEvent_GetContactPoint(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern IntPtr HkContactPointEvent_GetContactProperties(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkContactPointEvent_GetFiringCallbacksForFullManifold(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkContactPointEvent_GetFirstCallbackForFullManifold(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkContactPointEvent_GetLastCallbackForFullManifold(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern ushort HkContactPointEvent_GetContactPointId(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPointEvent_AccessVelocities(IntPtr instance, int bodyIndex);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPointEvent_UpdateVelocities(IntPtr instance, int bodyIndex);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern uint HkContactPointEvent_GetShapeKey(IntPtr instance, int bodyIdx);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern uint HkContactPointEvent_GetShapeKeyWithShapeID(IntPtr instance, int bodyIdx, int shapeIdx);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void HkContactPointEvent_GetFieldOffsets(out int separatingVelocityOffset, out int typeOffset, out int propertiesOffset, out int contactPointOffset, out int firingCallbacksForFullManifoldOffset, out int firstCallbackForFullManifoldOffset, out int lastCallbackForFullManifoldOffset);

		static HkContactPointEvent()
		{
			HkContactPointEvent_GetFieldOffsets(out SeparatingVelocityOffset, out TypeOffset, out PropertiesOffset, out ContactPointOffset, out FiringCallbacksForFullManifoldOffset, out FirstCallbackForFullManifoldOffset, out LastCallbackForFullManifoldOffset);
		}

		private unsafe static float* GetSeparatingVelocity(IntPtr handle)
		{
			return *(float**)(handle + SeparatingVelocityOffset).ToPointer();
		}

		private unsafe static Type GetType(IntPtr handle)
		{
			return *(Type*)(handle + TypeOffset).ToPointer();
		}

		private unsafe static IntPtr GetProperties(IntPtr handle)
		{
			return *(IntPtr*)(handle + PropertiesOffset).ToPointer();
		}

		private unsafe static IntPtr GetContactPoint(IntPtr handle)
		{
			return *(IntPtr*)(handle + ContactPointOffset).ToPointer();
		}

		private unsafe static bool GetFiringCallbacksForFullManifold(IntPtr handle)
		{
			return *(bool*)(handle + FiringCallbacksForFullManifoldOffset).ToPointer();
		}

		private unsafe static bool GetFirstCallbackForFullManifold(IntPtr handle)
		{
			return *(bool*)(handle + FirstCallbackForFullManifoldOffset).ToPointer();
		}

		private unsafe static bool GetLastCallbackForFullManifold(IntPtr handle)
		{
			return *(bool*)(handle + LastCallbackForFullManifoldOffset).ToPointer();
		}

		public void AccessVelocities(int bodyIndex)
		{
			HkContactPointEvent_AccessVelocities(NativeObject, bodyIndex);
		}

		public void UpdateVelocities(int bodyIndex)
		{
			HkContactPointEvent_UpdateVelocities(NativeObject, bodyIndex);
		}

		public uint GetShapeKey(int bodyIdx)
		{
			return HkContactPointEvent_GetShapeKey(NativeObject, bodyIdx);
		}

		public uint GetShapeKey(int bodyIdx, int shapeIdx)
		{
			return HkContactPointEvent_GetShapeKeyWithShapeID(NativeObject, bodyIdx, shapeIdx);
		}

		internal HkContactPointEvent(IntPtr inHandle)
		{
			Base = new HkCollisionEvent(inHandle);
			ContactPoint = new HkContactPoint(GetContactPoint(inHandle));
			ContactProperties = new HkContactPointProperties(GetProperties(inHandle));
		}

		private void CheckType(Type type)
		{
			if (type != EventType)
			{
				throw new InvalidOperationException("Operation is valid for only for type: " + type);
			}
		}
	}
	public struct HkContactPointProperties
	{
		private static readonly int UserDataOffset;

		private IntPtr m_handle;

		internal IntPtr NativeObject => m_handle;

		public float ImpulseApplied => HkContactPointProperties_GetImpulseApplied(m_handle);

		public float InternalSolverData => HkContactPointProperties_GetInternalSolverData(m_handle);

		public bool WasUsed => HkContactPointProperties_WasUsed(m_handle);

		public float Friction
		{
			get
			{
				return HkContactPointProperties_GetFriction(m_handle);
			}
			set
			{
				HkContactPointProperties_SetFriction(m_handle, value);
			}
		}

		public float Restitution
		{
			get
			{
				return HkContactPointProperties_GetRestitution(m_handle);
			}
			set
			{
				HkContactPointProperties_SetRestitution(m_handle, value);
			}
		}

		public bool IsPotential => HkContactPointProperties_IsPotential(m_handle);

		public float MaxImpulsePerStep
		{
			get
			{
				return HkContactPointProperties_GetMaxImpulsePerStep(m_handle);
			}
			set
			{
				HkContactPointProperties_SetMaxImpulsePerStep(m_handle, value);
			}
		}

		public HkContactUserData UserData
		{
			get
			{
				return GetUserData(m_handle);
			}
			set
			{
				GetUserData(m_handle) = value;
			}
		}

		public float MaxImpulse
		{
			get
			{
				return HkContactPointProperties_GetMaxImpulse(m_handle);
			}
			set
			{
				HkContactPointProperties_SetMaxImpulse(m_handle, value);
			}
		}

		public bool IsDisabled
		{
			get
			{
				return HkContactPointProperties_GetIsDisabled(m_handle);
			}
			set
			{
				HkContactPointProperties_SetIsDisabled(m_handle, value);
			}
		}

		public bool IsNew
		{
			get
			{
				return HkContactPointProperties_GetIsNew(m_handle);
			}
			set
			{
				HkContactPointProperties_SetIsNew(m_handle, value);
			}
		}

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern float HkContactPointProperties_GetImpulseApplied(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern float HkContactPointProperties_GetInternalSolverData(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkContactPointProperties_WasUsed(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern float HkContactPointProperties_GetFriction(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPointProperties_SetFriction(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern float HkContactPointProperties_GetRestitution(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPointProperties_SetRestitution(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkContactPointProperties_IsPotential(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern float HkContactPointProperties_GetMaxImpulsePerStep(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPointProperties_SetMaxImpulsePerStep(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern float HkContactPointProperties_GetMaxImpulse(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPointProperties_SetMaxImpulse(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkContactPointProperties_GetIsDisabled(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPointProperties_SetIsDisabled(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkContactPointProperties_GetIsNew(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPointProperties_SetIsNew(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern uint HkContactPointProperties_GetUserData(IntPtr instance);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		private static extern void HkContactPointProperties_SetUserData(IntPtr instance, uint value);

		[DllImport("Havok.dll")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void HkContactPointProperties_GetFieldOffsets(out int userDataOffset);

		static HkContactPointProperties()
		{
			HkContactPointProperties_GetFieldOffsets(out UserDataOffset);
		}

		private unsafe static ref HkContactUserData GetUserData(IntPtr m_handle)
		{
			return ref *(HkContactUserData*)(m_handle + UserDataOffset).ToPointer();
		}

		internal HkContactPointProperties(IntPtr inHandle)
		{
			m_handle = inHandle;
		}
	}
	public class HkContactSoundListener : HkHandle
	{
		private delegate void ContactSoundHandler(IntPtr handle, IntPtr contactPointEvent);

		private static readonly ContactSoundHandler OnContactCallback = OnContact;

		private readonly HkContactPointEventHandler m_onContact;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkContactSoundListener_Create(ContactSoundHandler onContact);

		public HkContactSoundListener(HkContactPointEventHandler onContact)
			: base(HkContactSoundListener_Create(OnContactCallback), track: true)
		{
			m_onContact = onContact;
		}

		public static implicit operator IntPtr(HkContactSoundListener listener)
		{
			return listener.NativeObject;
		}

		[MonoPInvokeCallback(typeof(ContactSoundHandler))]
		private static void OnContact(IntPtr handle, IntPtr contactPointEvent)
		{
			if (HkHandle.TryGetHandle<HkContactSoundListener>(handle, out var handle2))
			{
				HkContactPointEvent contactEvent = new HkContactPointEvent(contactPointEvent);
				handle2.m_onContact(ref contactEvent);
			}
		}
	}
	public struct HkContactUserData
	{
		private uint m_uint;

		public uint AsUint => m_uint;

		public static HkContactUserData UInt(uint value)
		{
			HkContactUserData result = default(HkContactUserData);
			result.m_uint = value;
			return result;
		}
	}
	public static class HkCrashHunter
	{
		public readonly struct Op
		{
			public readonly OpCode OpCode;

			public readonly string ShapeName;

			public readonly (string Name, string File, int Line) Caller;

			public readonly int Frame;

			public readonly Thread CurrentThread;

			public readonly IntPtr ShapePointer;

			public readonly bool StepInProgress;

			public readonly long TimeStamp;

			public Op(OpCode opCode, int frame, HkShape shape, string shapeName, bool stepInProgress, (string Name, string File, int Line) caller)
			{
				OpCode = opCode;
				Frame = frame;
				ShapePointer = shape.NativeObject;
				ShapeName = shapeName;
				StepInProgress = stepInProgress;
				Caller = caller;
				CurrentThread = Thread.CurrentThread;
				TimeStamp = m_timer.ElapsedTicks;
			}

			public override string ToString()
			{
				return $"{OpCode}, {ShapeName}, {Caller.Name}, {Caller.File}, {Caller.Line}, {Frame}, {TimeStamp}, {CurrentThread.Name}, 0x{ShapePointer.ToInt64():x16}, {StepInProgress}";
			}
		}

		public enum OpCode
		{
			CreateShape,
			UpdateShape,
			SetShape,
			ModifyShapeCollection,
			DestroyRigidBody,
			DestroyShape
		}

		private const int HistoryLength = 2048;

		private static Func<int> m_getFrame = () => 0;

		private static readonly MyQueue<Op> m_operations = new MyQueue<Op>();

		private static readonly Dictionary<IntPtr, string> m_shapeNames = new Dictionary<IntPtr, string>(IntPtrComparer.Instance);

		private static readonly object m_lock = m_operations;

		private static readonly Stopwatch m_timer = Stopwatch.StartNew();

		public static void Init(Func<int> getFrameCallback)
		{
			m_getFrame = getFrameCallback;
		}

		[Conditional("OPERATION_TRACKING")]
		public static void DumpRecord()
		{
			long elapsedTicks = m_timer.ElapsedTicks;
			lock (m_lock)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine($"{Thread.CurrentThread.Name}: Last update frame {m_getFrame()}, current timestamp {elapsedTicks}. Physics coarse operation record follows:");
				stringBuilder.AppendLine("OpCode, ShapeName, CallerMember, CallerFile, CallerLine, Frame, TimeStamp, CurrentThread, ShapePointer, StepInProgress");
				foreach (Op operation in m_operations)
				{
					stringBuilder.AppendLine(operation.ToString());
				}
				HkBaseSystem.WriteLog(stringBuilder.ToString());
			}
		}

		[Conditional("OPERATION_TRACKING")]
		public static void RecordCreate(HkShape shape, string shapeName, [CallerMemberName] string callerMember = null, [CallerFilePath] string callerFile = null, [CallerLineNumber] int callerLine = 0)
		{
			lock (m_lock)
			{
				m_shapeNames[shape.NativeObject] = shapeName;
			}
		}

		[Conditional("OPERATION_TRACKING")]
		public static void RecordOperation(OpCode opCode, HkShape shape, [CallerMemberName] string callerMember = null, [CallerFilePath] string callerFile = null, [CallerLineNumber] int callerLine = 0)
		{
			lock (m_lock)
			{
				while (m_operations.Count >= 2048)
				{
					m_operations.Dequeue();
				}
				if (!m_shapeNames.TryGetValue(shape.NativeObject, out var value))
				{
					value = (m_shapeNames[shape.NativeObject] = shape.ShapeType.ToString());
				}
				m_operations.Enqueue(new Op(opCode, m_getFrame(), shape, value, HkBaseSystem.IsSimulating, (callerMember, callerFile, callerLine)));
			}
		}
	}
	public delegate void HkEntityHandler(HkEntity entity);
	public class HkEntity : HkReferenceObject
	{
		protected struct HkTransform
		{
			public Vector4 RotCol0;

			public Vector4 RotCol1;

			public Vector4 RotCol2;

			public Vector4 Position;

			public unsafe void GetMatrix(out Matrix matrix)
			{
				fixed (HkTransform* ptr = &this)
				{
					matrix = *(Matrix*)ptr;
				}
				matrix.M14 = 0f;
				matrix.M24 = 0f;
				matrix.M34 = 0f;
				matrix.M44 = 1f;
			}

			public void GetMatrix(out MatrixD matrix)
			{
				matrix.M11 = RotCol0.X;
				matrix.M12 = RotCol0.Y;
				matrix.M13 = RotCol0.Z;
				matrix.M21 = RotCol1.X;
				matrix.M22 = RotCol1.Y;
				matrix.M23 = RotCol1.Z;
				matrix.M31 = RotCol2.X;
				matrix.M32 = RotCol2.Y;
				matrix.M33 = RotCol2.Z;
				matrix.M41 = Position.X;
				matrix.M42 = Position.Y;
				matrix.M43 = Position.Z;
				matrix.M14 = 0.0;
				matrix.M24 = 0.0;
				matrix.M34 = 0.0;
				matrix.M44 = 1.0;
			}
		}

		private static readonly int UserDataOffset;

		private static readonly int TransformOffset;

		private static readonly int RotationOffset;

		private static readonly int LinearVelocityOffset;

		private static readonly int AngularVelocityOffset;

		private static readonly int MotionTypeOffset;

		private static readonly int SimulationIslandOffset;

		private static readonly int WorldOffset;

		protected HkActivationListener m_activationListener;

		protected HkContactListener m_contactListener;

		protected HkContactSoundListener m_soundListener;

		private bool m_contactListenerEnabled;

		private bool m_soundListenerEnabled;

		private int m_callbackLimit;

		private object m_userObject;

		private HkEntityListener m_entityListener;

		public bool ContactPointCallbackEnabled
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return m_contactListenerEnabled;
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					if (m_contactListenerEnabled != value)
					{
						m_contactListenerEnabled = value;
						HkEntity_SetContactListener(m_handle, m_contactListener, value);
					}
				}
			}
		}

		public bool ContactSoundCallbackEnabled
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return m_soundListenerEnabled;
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					if (m_soundListenerEnabled != value)
					{
						m_soundListenerEnabled = value;
						HkEntity_SetContactListener(m_handle, m_soundListener, value);
					}
				}
			}
		}

		public HkCollidableQualityType Quality
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return (HkCollidableQualityType)HkEntity_GetQuality(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkEntity_SetQuality(m_handle, (int)value);
				}
			}
		}

		public bool IsFixed
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return GetMotionType(m_handle) == HkMotionType.Fixed;
				}
			}
		}

		public bool IsFixedOrKeyframed
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					HkMotionType motionType = GetMotionType(m_handle);
					return motionType == HkMotionType.Fixed || motionType == HkMotionType.Keyframed;
				}
			}
		}

		public bool InWorld
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return InWorldInternal;
				}
			}
		}

		public bool InWorldInternal => GetWorld(base.NativeObject) != IntPtr.Zero;

		public int ContactPointCallbackDelay
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkEntity_GetContactPointCallbackDelay(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkEntity_SetContactPointCallbackDelay(m_handle, value);
				}
			}
		}

		public int CallbackLimit
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return m_callbackLimit;
				}
			}
			set
			{
				m_callbackLimit = value;
				if (m_contactListener != null)
				{
					m_contactListener.CallbackLimit = value;
				}
			}
		}

		public object UserObject
		{
			get
			{
				return m_userObject;
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					m_userObject = value;
				}
			}
		}

		protected IntPtr UserData
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return GetUserData(m_handle);
				}
			}
			set
			{
				GetUserData(m_handle) = value;
			}
		}

		public Quaternion Rotation
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return GetRotation(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetRotation(m_handle, value);
				}
			}
		}

		public Vector3 Position
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return new Vector3(GetTransform(m_handle).Position);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetPosition(m_handle, value);
				}
			}
		}

		public Vector3 LinearVelocity
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return GetLinearVelocity(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this, allowDuringStep: true))
				{
					HkRigidBody_SetLinearVelocity(m_handle, value);
				}
			}
		}

		public Vector3 LinearVelocityUnsafe
		{
			get
			{
				return GetLinearVelocity(m_handle);
			}
			set
			{
				HkRigidBody_SetLinearVelocity(m_handle, value);
			}
		}

		public Vector3 AngularVelocity
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return GetAngularVelocity(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetAngularVelocity(m_handle, value);
				}
			}
		}

		public bool IsActive
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					HkSimulationIslandRef simulationIsland = GetSimulationIsland();
					return simulationIsland.IsValid && simulationIsland.IsActive();
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					if (value)
					{
						Activate();
					}
					else
					{
						Deactivate();
					}
				}
			}
		}

		public event HkEntityHandler Activated;

		public event HkEntityHandler Deactivated;

		public event HkContactPointEventHandler ContactPointCallback;

		public event HkContactPointEventHandler ContactSoundCallback;

		public event HkCollisionEventHandler CollisionAddedCallback;

		public event HkCollisionEventHandler CollisionRemovedCallback;

		[DllImport("Havok.dll")]
		protected static extern void HkEntity_AddActivationListener(IntPtr instance, IntPtr listener);

		[DllImport("Havok.dll")]
		protected static extern void HkEntity_RemoveActivationListener(IntPtr instance, IntPtr listener);

		[DllImport("Havok.dll")]
		protected static extern void HKEntity_AddEntityListener(IntPtr instance, IntPtr listener);

		[DllImport("Havok.dll")]
		protected static extern void HKEntity_RemoveEntityListener(IntPtr instance, IntPtr listener);

		[DllImport("Havok.dll")]
		protected static extern void HkEntity_SetContactListener(IntPtr instance, IntPtr listener, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport("Havok.dll")]
		private static extern int HkEntity_GetQuality(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkEntity_SetQuality(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkEntity_IsFixed(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkEntity_IsFixedOrKeyframed(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkRigidBody_GetMotionType(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkEntity_GetContactPointCallbackDelay(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkEntity_SetContactPointCallbackDelay(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern void HkEntity_SetProperty(IntPtr instance, int key, float v);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkEntity_HasProperty(IntPtr instance, int key);

		[DllImport("Havok.dll")]
		private static extern void HkEntity_RemoveProperty(IntPtr instance, int key);

		[DllImport("Havok.dll")]
		private static extern Quaternion HkRigidBody_GetRotation(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetRotation(IntPtr instance, Quaternion value);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkRigidBody_GetPosition(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetPosition(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_Activate(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_ActivateAsCriticalOperation(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_Deactivate(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_UpdateMotionType(IntPtr instance, int type);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkRigidBody_GetIsActive(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_RequestDeactivation(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkRigidBody_GetLinearVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetLinearVelocity(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkRigidBody_GetAngularVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetAngularVelocity(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern void HkEntity_GetFieldOffsets(out int userDataOffset, out int transformOffset, out int rotationOffset, out int linearVelocityOffset, out int angularVelocityOffset, out int motionTypeOffset, out int simulationIslandOffset, out int worldOffset);

		static HkEntity()
		{
			HkEntity_GetFieldOffsets(out UserDataOffset, out TransformOffset, out RotationOffset, out LinearVelocityOffset, out AngularVelocityOffset, out MotionTypeOffset, out SimulationIslandOffset, out WorldOffset);
		}

		protected virtual void Init()
		{
			m_activationListener = new HkActivationListener(OnActivated, OnDeactivated);
			m_contactListener = new HkContactListener(OnContact, OnCollisionAdded, OnCollisionRemoved, m_callbackLimit);
			m_soundListener = new HkContactSoundListener(OnSoundContact);
			m_contactListenerEnabled = false;
			m_soundListenerEnabled = false;
		}

		public void SetProperty(int key, float v)
		{
			using (HkAccessControl.Write(this))
			{
				HkEntity_SetProperty(m_handle, key, v);
			}
		}

		public bool HasProperty(int key)
		{
			using (HkAccessControl.Read(this))
			{
				return HkEntity_HasProperty(m_handle, key);
			}
		}

		public void RemoveProperty(int key)
		{
			using (HkAccessControl.Write(this))
			{
				HkEntity_RemoveProperty(m_handle, key);
			}
		}

		internal HkEntity(IntPtr referenceObj)
			: base(referenceObj, track: true)
		{
			Init();
		}

		internal void AddEntityListener(HkEntityListener listener)
		{
			using (HkAccessControl.Write(this))
			{
				m_entityListener = listener;
				HKEntity_AddEntityListener(base.NativeObject, listener.NativeObject);
			}
		}

		internal void RemoveEntityListener(HkEntityListener listener)
		{
			using (HkAccessControl.Write(this))
			{
				HKEntity_RemoveEntityListener(base.NativeObject, listener.NativeObject);
			}
		}

		public void RequestDeactivation()
		{
			using (HkAccessControl.Write(this))
			{
				HkRigidBody_RequestDeactivation(m_handle);
			}
		}

		public void Activate()
		{
			using (HkAccessControl.Write(this))
			{
				HkRigidBody_Activate(m_handle);
			}
		}

		public void ActivateAsCriticalOperation()
		{
			using (HkAccessControl.Write(this))
			{
				HkRigidBody_ActivateAsCriticalOperation(m_handle);
			}
		}

		public void ForceActivate()
		{
			using (HkAccessControl.Write(this))
			{
				Activate();
			}
		}

		public void Deactivate()
		{
			using (HkAccessControl.Write(this))
			{
				HkRigidBody_RequestDeactivation(m_handle);
			}
		}

		public void UpdateMotionType(HkMotionType type)
		{
			using (HkAccessControl.Write(this))
			{
				HkRigidBody_UpdateMotionType(m_handle, (int)type);
			}
		}

		public HkMotionType GetMotionType()
		{
			using (HkAccessControl.Read(this))
			{
				return GetMotionType(m_handle);
			}
		}

		public void GetRigidBodyMatrix(out Matrix matrix)
		{
			using (HkAccessControl.Read(this))
			{
				GetTransform(m_handle).GetMatrix(out matrix);
			}
		}

		public Matrix GetRigidBodyMatrix()
		{
			using (HkAccessControl.Read(this))
			{
				GetTransform(m_handle).GetMatrix(out Matrix matrix);
				return matrix;
			}
		}

		public void GetRigidBodyMatrix(out MatrixD matrix)
		{
			using (HkAccessControl.Read(this))
			{
				GetTransform(m_handle).GetMatrix(out matrix);
			}
		}

		public HkSimulationIslandRef GetSimulationIsland()
		{
			using (HkAccessControl.Read(this))
			{
				return new HkSimulationIslandRef(GetSimulationIsland(m_handle));
			}
		}

		protected override void Dispose(bool disposing)
		{
			using (HkAccessControl.Write(this))
			{
				if (m_entityListener != null)
				{
					RemoveEntityListener(m_entityListener);
				}
				if (m_contactListenerEnabled)
				{
					HkEntity_SetContactListener(m_handle, m_contactListener, value: false);
				}
				if (m_soundListenerEnabled)
				{
					HkEntity_SetContactListener(m_handle, m_soundListener, value: false);
				}
				DeleteAndClear<HkActivationListener>(ref m_activationListener);
				DeleteAndClear<HkContactListener>(ref m_contactListener);
				DeleteAndClear<HkContactSoundListener>(ref m_soundListener);
				base.Dispose(disposing);
			}
			void DeleteAndClear<T>(ref T reference) where T : class, IDisposable
			{
				if (reference != null)
				{
					reference.Dispose();
					reference = null;
				}
			}
		}

		internal void OnActivated()
		{
			this.Activated?.Invoke(this);
		}

		private void OnDeactivated()
		{
			this.Deactivated?.Invoke(this);
		}

		private void OnContact(ref HkContactPointEvent e)
		{
			this.ContactPointCallback?.Invoke(ref e);
		}

		private void OnSoundContact(ref HkContactPointEvent e)
		{
			this.ContactSoundCallback?.Invoke(ref e);
		}

		private void OnCollisionAdded(ref HkCollisionEvent e)
		{
			this.CollisionAddedCallback?.Invoke(ref e);
		}

		private void OnCollisionRemoved(ref HkCollisionEvent e)
		{
			this.CollisionRemovedCallback?.Invoke(ref e);
		}

		internal static bool TryGet(IntPtr bodyHandle, out HkEntity entity)
		{
			return HkHandle.TryGetHandle<HkEntity>(bodyHandle, out entity);
		}

		protected unsafe static ref HkTransform GetTransform(IntPtr entity)
		{
			return ref *(HkTransform*)(entity + TransformOffset).ToPointer();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static ref IntPtr GetUserData(IntPtr handle)
		{
			return ref *(IntPtr*)(handle + UserDataOffset).ToPointer();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static ref Vector3 GetLinearVelocity(IntPtr handle)
		{
			return ref *(Vector3*)(handle + LinearVelocityOffset).ToPointer();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static ref Vector3 GetAngularVelocity(IntPtr handle)
		{
			return ref *(Vector3*)(handle + AngularVelocityOffset).ToPointer();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static ref Quaternion GetRotation(IntPtr handle)
		{
			return ref *(Quaternion*)(handle + RotationOffset).ToPointer();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static ref HkMotionType GetMotionType(IntPtr handle)
		{
			return ref *(HkMotionType*)(handle + MotionTypeOffset).ToPointer();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static ref IntPtr GetSimulationIsland(IntPtr handle)
		{
			return ref *(IntPtr*)(handle + SimulationIslandOffset).ToPointer();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static IntPtr GetWorld(IntPtr handle)
		{
			return *(IntPtr*)(handle + WorldOffset).ToPointer();
		}
	}
	public class HkEntityListener : HkHandle
	{
		private delegate void OnAddCpp(IntPtr listener, IntPtr entity);

		private delegate void OnRemoveCpp(IntPtr listener, IntPtr entity);

		private delegate void OnDeleteCpp(IntPtr listener, IntPtr entity);

		private delegate void OnShapeChangeCpp(IntPtr listener, IntPtr entity);

		private delegate void OnMotionTypeChangeCpp(IntPtr listener, IntPtr entity);

		private static readonly OnAddCpp OnAddCallback = OnAddInternal;

		private static readonly OnRemoveCpp OnRemoveCallback = OnRemoveInternal;

		private static readonly OnDeleteCpp OnDeleteCallback = OnDeleteInternal;

		private static readonly OnShapeChangeCpp OnShapeChangeCallback = OnShapeChangeInternal;

		private static readonly OnMotionTypeChangeCpp OnMotionTypeChangeCallback = OnMotionTypeChangeInternal;

		public event Action<HkEntity> OnAdd;

		public event Action<HkEntity> OnRemove;

		public event Action<HkEntity> OnDelete;

		public event Action<HkEntity> OnShapeChange;

		public event Action<HkEntity> OnMotionTypeChange;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkEntityListener_Create(OnAddCpp onAdd, OnRemoveCpp onRemove, OnDeleteCpp onDelete, OnShapeChangeCpp onShapeChange, OnMotionTypeChangeCpp onMotionTypeChange);

		[DllImport("Havok.dll")]
		private static extern void HkEntityListener_Release(IntPtr entityListener);

		public HkEntityListener()
			: base(HkEntityListener_Create(OnAddCallback, OnRemoveCallback, OnDeleteCallback, OnShapeChangeCallback, OnMotionTypeChangeCallback), track: true)
		{
		}

		public HkEntityListener(Action<HkEntity> onAdd, Action<HkEntity> onRemove, Action<HkEntity> onDelete = null, Action<HkEntity> onShapeChange = null, Action<HkEntity> onMotionTypeChange = null)
			: this()
		{
			OnAdd += onAdd;
			OnRemove += onRemove;
			OnDelete += onDelete;
			OnShapeChange += onShapeChange;
			OnMotionTypeChange += onMotionTypeChange;
		}

		protected override void Dispose(bool disposing)
		{
			HkEntityListener_Release(m_handle);
		}

		[MonoPInvokeCallback(typeof(OnAddCpp))]
		private static void OnAddInternal(IntPtr listenerHandle, IntPtr entityHandle)
		{
			if (HkHandle.TryGetHandle<HkEntityListener>(listenerHandle, out var handle) && HkEntity.TryGet(entityHandle, out var entity))
			{
				handle.OnAdd?.Invoke(entity);
			}
		}

		[MonoPInvokeCallback(typeof(OnRemoveCpp))]
		private static void OnRemoveInternal(IntPtr listenerHandle, IntPtr entityHandle)
		{
			if (HkHandle.TryGetHandle<HkEntityListener>(listenerHandle, out var handle) && HkEntity.TryGet(entityHandle, out var entity))
			{
				handle.OnRemove?.Invoke(entity);
			}
		}

		[MonoPInvokeCallback(typeof(OnDeleteCpp))]
		private static void OnDeleteInternal(IntPtr listenerHandle, IntPtr entityHandle)
		{
			if (HkHandle.TryGetHandle<HkEntityListener>(listenerHandle, out var handle) && HkEntity.TryGet(entityHandle, out var entity))
			{
				handle.OnDelete?.Invoke(entity);
			}
		}

		[MonoPInvokeCallback(typeof(OnShapeChangeCpp))]
		private static void OnShapeChangeInternal(IntPtr listenerHandle, IntPtr entityHandle)
		{
			if (HkHandle.TryGetHandle<HkEntityListener>(listenerHandle, out var handle) && HkEntity.TryGet(entityHandle, out var entity))
			{
				handle.OnShapeChange?.Invoke(entity);
			}
		}

		[MonoPInvokeCallback(typeof(OnMotionTypeChangeCpp))]
		private static void OnMotionTypeChangeInternal(IntPtr listenerHandle, IntPtr entityHandle)
		{
			if (HkHandle.TryGetHandle<HkEntityListener>(listenerHandle, out var handle) && HkEntity.TryGet(entityHandle, out var entity))
			{
				handle.OnMotionTypeChange?.Invoke(entity);
			}
		}
	}
	public abstract class HkHandle : IDisposable
	{
		protected IntPtr m_handle;

		private static readonly ConcurrentDictionary<IntPtr, HkHandle> m_registeredHandles = new ConcurrentDictionary<IntPtr, HkHandle>(IntPtrComparer.Instance);

		public IntPtr NativeObject => m_handle;

		public bool IsDisposed => m_handle == IntPtr.Zero;

		[DllImport("Havok.dll")]
		private static extern void HkGlobal_ReleasePtr(IntPtr ptr);

		[DllImport("Havok.dll")]
		private static extern void HkGlobal_ReleaseString(IntPtr ptr);

		[DllImport("Havok.dll")]
		private static extern void HkGlobal_ReleaseArrayPtr(IntPtr ptr);

		internal static void ReleasePtr(IntPtr ptr)
		{
			HkGlobal_ReleasePtr(ptr);
		}

		protected void ReleaseArrayPtr(ref IntPtr ptr)
		{
			HkGlobal_ReleaseArrayPtr(ptr);
			ptr = IntPtr.Zero;
		}

		[Conditional("DEBUG")]
		protected void CheckDisposed()
		{
			if (IsDisposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
		}

		public void Dispose()
		{
			DisposeInternal(disposing: true);
			GC.SuppressFinalize(this);
		}

		internal static string MarshalToString(IntPtr ptr)
		{
			string result = Marshal.PtrToStringAnsi(ptr);
			HkGlobal_ReleaseString(ptr);
			return result;
		}

		internal static byte[] MarshalToByteArray(IntPtr ptr, int size)
		{
			byte[] array = new byte[size];
			Marshal.Copy(ptr, array, 0, size);
			return array;
		}

		internal static uint[] MarshalToUIntArray(IntPtr ptr, int size)
		{
			int[] array = new int[size];
			Marshal.Copy(ptr, array, 0, size);
			uint[] array2 = new uint[size];
			for (int i = 0; i < size; i++)
			{
				byte[] bytes = BitConverter.GetBytes(array[i]);
				array2[i] = BitConverter.ToUInt32(bytes, 0);
			}
			return array2;
		}

		protected virtual void Dispose(bool disposing)
		{
			ReleasePtr(m_handle);
		}

		private void DisposeInternal(bool disposing)
		{
			if (!IsDisposed)
			{
				Dispose(disposing);
			}
			m_registeredHandles.Remove(m_handle);
			m_handle = IntPtr.Zero;
		}

		public static int GetHandlesAmount()
		{
			return m_registeredHandles.Count();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHandle<THandle>(IntPtr handlePointer, out THandle handle) where THandle : HkHandle
		{
			if (m_registeredHandles.TryGetValue(handlePointer, out var value))
			{
				handle = value as THandle;
				if (handle == null)
				{
					return false;
				}
				return true;
			}
			handle = null;
			return false;
		}

		internal HkHandle()
		{
		}

		internal HkHandle(IntPtr ptr, bool track = false)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new ArgumentException("Reference to unmanaged object must not be null.");
			}
			m_handle = ptr;
			if (track)
			{
				m_registeredHandles.TryAdd(m_handle, this);
			}
		}

		~HkHandle()
		{
			if (HkBaseSystem.IsInitialized && !Environment.HasShutdownStarted)
			{
				_ = IsDisposed;
				HkBaseSystem.InitThread("Finalizer Thread");
				DisposeInternal(disposing: false);
				HkBaseSystem.QuitThread();
			}
		}

		[Conditional("DEBUG")]
		private void NotifyAllocated()
		{
		}

		[Conditional("DEBUG")]
		private void NotifyLost()
		{
		}
	}
	public class TestNativeToManagedMapping
	{
		private sealed class IntPtrComparer : EqualityComparer<IntPtr>
		{
			public static readonly IntPtrComparer Instance = new IntPtrComparer();

			public override bool Equals(IntPtr x, IntPtr y)
			{
				return x == y;
			}

			public override int GetHashCode(IntPtr obj)
			{
				return obj.GetHashCode();
			}
		}

		private class NativeObject
		{
			public string Value;

			public GCHandle Handle;

			public IntPtr NativeHandle => GCHandle.ToIntPtr(Handle);

			public event Action<string> Ping;

			public NativeObject(string value)
			{
				Value = value;
			}

			public static NativeObject MakeWithHandle(string value)
			{
				NativeObject nativeObject = new NativeObject(value);
				nativeObject.Handle = GCHandle.Alloc(nativeObject, GCHandleType.Weak);
				return nativeObject;
			}

			public static NativeObject GetFromHandle(IntPtr handle)
			{
				return (NativeObject)GCHandle.FromIntPtr(handle).Target;
			}

			internal void FirePing()
			{
				this.Ping?.Invoke(Value);
			}
		}

		public const int Count = 100000;

		private Dictionary<IntPtr, NativeObject> m_repository;

		private ConcurrentDictionary<IntPtr, NativeObject> m_concurrentRepository;

		public TestNativeToManagedMapping()
		{
			m_repository = new Dictionary<IntPtr, NativeObject>(IntPtrComparer.Instance) { 
			{
				new IntPtr(195935983),
				new NativeObject("Bad Beef")
			} };
			m_concurrentRepository = new ConcurrentDictionary<IntPtr, NativeObject>(IntPtrComparer.Instance);
			m_concurrentRepository.TryAdd(new IntPtr(195935983), new NativeObject("Bad Beef"));
			for (int i = 0; i < 2000; i++)
			{
				m_repository.Add(new IntPtr(i), new NativeObject("Dummy"));
				m_concurrentRepository.TryAdd(new IntPtr(i), new NativeObject("Dummy"));
			}
		}

		public void Dictionary()
		{
			IntPtr key = new IntPtr(195935983);
			for (int i = 0; i < 100000; i++)
			{
				if (m_repository.TryGetValue(key, out var value))
				{
					value.FirePing();
				}
			}
		}

		public void SynchronizedDictionary()
		{
			IntPtr key = new IntPtr(195935983);
			for (int i = 0; i < 100000; i++)
			{
				lock (m_repository)
				{
					if (m_repository.TryGetValue(key, out var value))
					{
						value.FirePing();
					}
				}
			}
		}

		public void ConcurrentDictionary()
		{
			IntPtr key = new IntPtr(195935983);
			for (int i = 0; i < 100000; i++)
			{
				if (m_concurrentRepository.TryGetValue(key, out var value))
				{
					value.FirePing();
				}
			}
		}

		public void GC_Handle()
		{
			NativeObject nativeObject = NativeObject.MakeWithHandle("Yay");
			IntPtr nativeHandle = nativeObject.NativeHandle;
			for (int i = 0; i < 100000; i++)
			{
				NativeObject.GetFromHandle(nativeHandle).FirePing();
			}
			GC.KeepAlive(nativeObject);
		}
	}
	public class HkJobQueue : HkHandle
	{
		public enum WaitPolicyT
		{
			WAIT_UNTIL_ALL_WORK_COMPLETE,
			WAIT_INDEFINITELY
		}

		private int m_threadCount;

		public int ThreadCount => m_threadCount;

		public WaitPolicyT WaitPolicy
		{
			get
			{
				return HkJobQueue_GetWaitPolicy(m_handle);
			}
			set
			{
				HkJobQueue_SetWaitPolicy(m_handle, value);
			}
		}

		public int MasterThreadFinishingFlags
		{
			get
			{
				return HkJobQueue_GetMasterThreadFinishingFlags(m_handle);
			}
			set
			{
				HkJobQueue_SetMasterThreadFinishingFlags(m_handle, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkJobQueue_Create(ref int outThreadCount);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkJobQueue_CreateWithNumThreads(int threadCount);

		[DllImport("Havok.dll")]
		private static extern void HkJobQueue_Release(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern WaitPolicyT HkJobQueue_GetWaitPolicy(IntPtr jobQueue);

		[DllImport("Havok.dll")]
		private static extern void HkJobQueue_SetWaitPolicy(IntPtr jobQueue, WaitPolicyT value);

		[DllImport("Havok.dll")]
		private static extern int HkJobQueue_GetMasterThreadFinishingFlags(IntPtr jobQueue);

		[DllImport("Havok.dll")]
		private static extern void HkJobQueue_SetMasterThreadFinishingFlags(IntPtr jobQueue, int value);

		[DllImport("Havok.dll")]
		private static extern void HkJobQueue_ProcessAllJobs(IntPtr jobQueue);

		public HkJobQueue()
		{
			m_handle = HkJobQueue_Create(ref m_threadCount);
		}

		public HkJobQueue(int threadCount)
		{
			m_threadCount = threadCount;
			m_handle = HkJobQueue_CreateWithNumThreads(m_threadCount);
		}

		protected override void Dispose(bool disposing)
		{
			HkJobQueue_Release(base.NativeObject);
		}

		public void ProcessAllJobs()
		{
			HkJobQueue_ProcessAllJobs(m_handle);
		}
	}
	public class HkJobThreadPool : HkReferenceObject
	{
		internal delegate void ThreadAction(IntPtr data);

		private readonly int m_threadCount;

		private int m_taskId;

		private static readonly ConcurrentDictionary<int, Action> m_tasks = new ConcurrentDictionary<int, Action>();

		private static readonly ThreadAction m_action = ThreadTaskExecutor;

		public int ThreadCount => m_threadCount;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkJobThreadPool_Create(ref int outThreadCount);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkJobThreadPool_CreateWithNumThreads(int threadCount);

		[DllImport("Havok.dll")]
		internal static extern void HkJobThreadPool_RemoveReference(IntPtr instance);

		[DllImport("Havok.dll")]
		internal static extern void HkJobThreadPool_RunOnEachWorker(IntPtr instance, ThreadAction action, IntPtr data);

		[DllImport("Havok.dll")]
		internal static extern void HkJobThreadPool_ExecuteJobQueue(IntPtr instance, IntPtr jobQueue);

		[DllImport("Havok.dll")]
		internal static extern int HkJobThreadPool_GetThisThreadIndex(IntPtr instance);

		[DllImport("Havok.dll")]
		internal static extern void HkJobThreadPool_WaitForCompletion(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkJobThreadPool_ClearTimerData(IntPtr instance);

		public HkJobThreadPool()
		{
			m_handle = HkJobThreadPool_Create(ref m_threadCount);
			NameWorkers();
		}

		public HkJobThreadPool(int threadCount)
		{
			m_threadCount = threadCount;
			m_handle = HkJobThreadPool_CreateWithNumThreads(m_threadCount);
			NameWorkers();
		}

		private void NameWorkers()
		{
			RunOnEachWorker(delegate
			{
				int thisThreadIndex = GetThisThreadIndex();
				Thread.CurrentThread.Name = "HkThread_" + (thisThreadIndex + 1);
			});
		}

		internal void ClearTimerData()
		{
			HkJobThreadPool_ClearTimerData(m_handle);
		}

		public void RunOnEachWorker(Action task)
		{
			int num = Interlocked.Increment(ref m_taskId);
			m_tasks.TryAdd(num, task);
			HkJobThreadPool_RunOnEachWorker(m_handle, m_action, new IntPtr(num));
			m_tasks.Remove(num);
		}

		[MonoPInvokeCallback(typeof(ThreadAction))]
		private static void ThreadTaskExecutor(IntPtr data)
		{
			if (m_tasks.TryGetValue(data.ToInt32(), out var value))
			{
				value();
			}
		}

		public void ExecuteJobQueue(HkJobQueue jobQueue)
		{
			HkJobThreadPool_ExecuteJobQueue(m_handle, jobQueue.NativeObject);
		}

		public int GetThisThreadIndex()
		{
			return HkJobThreadPool_GetThisThreadIndex(m_handle);
		}

		public void WaitForCompletion()
		{
			HkJobThreadPool_WaitForCompletion(m_handle);
		}
	}
	public struct HkMotion
	{
		private IntPtr m_handle;

		[DllImport("Havok.dll")]
		private static extern void HkMotion_SetWorldMatrix(IntPtr instance, Matrix m);

		[DllImport("Havok.dll")]
		private static extern int HkMotion_GetDeactivationClass(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkMotion_SetDeactivationClass(IntPtr instance, int value);

		public void SetWorldMatrix(Matrix m)
		{
			HkMotion_SetWorldMatrix(m_handle, m);
		}

		public HkSolverDeactivation GetDeactivationClass()
		{
			return (HkSolverDeactivation)HkMotion_GetDeactivationClass(m_handle);
		}

		public void SetDeactivationClass(HkSolverDeactivation v)
		{
			HkMotion_SetDeactivationClass(m_handle, (int)v);
		}

		internal HkMotion(IntPtr motion)
		{
			m_handle = motion;
		}
	}
	public class HkReferenceObject : HkHandle
	{
		private static bool m_collectStacks;

		public static bool CollectStackTraces
		{
			get
			{
				return m_collectStacks;
			}
			set
			{
				m_collectStacks = value;
			}
		}

		public int ReferenceCount => HkReferenceObject_ReferenceCount(m_handle);

		[DllImport("Havok.dll")]
		public static extern void HkReferenceObject_AddReference(IntPtr instance);

		[DllImport("Havok.dll")]
		public static extern void HkReferenceObject_RemoveReference(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool HkReferenceObject_IsValid(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkReferenceObject_DebugRemoveRef(IntPtr instance);

		[DllImport("Havok.dll")]
		public static extern int HkReferenceObject_ReferenceCount(IntPtr instance);

		protected override void Dispose(bool disposing)
		{
			HkReferenceObject_RemoveReference(base.NativeObject);
		}

		public void AddReference()
		{
			HkReferenceObject_AddReference(base.NativeObject);
		}

		public void RemoveReference()
		{
			HkReferenceObject_RemoveReference(base.NativeObject);
		}

		public virtual bool IsValid()
		{
			return HkReferenceObject_IsValid(base.NativeObject);
		}

		public static T Get<T>(IntPtr ptr) where T : HkReferenceObject, new()
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new T
			{
				m_handle = ptr
			};
		}

		public void ClearHandle()
		{
			m_handle = IntPtr.Zero;
			GC.SuppressFinalize(this);
		}

		public void DebugRemoveRef()
		{
			HkReferenceObject_DebugRemoveRef(m_handle);
		}

		public override bool Equals(object other)
		{
			HkReferenceObject hkReferenceObject = (HkReferenceObject)other;
			if (hkReferenceObject != null)
			{
				return hkReferenceObject == this;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return m_handle.GetHashCode();
		}

		public static bool operator ==(HkReferenceObject objectA, HkReferenceObject objectB)
		{
			if ((object)objectA == objectB)
			{
				return true;
			}
			if ((object)objectA == null || (object)objectB == null)
			{
				return false;
			}
			return objectA.m_handle == objectB.m_handle;
		}

		public static bool operator !=(HkReferenceObject objectA, HkReferenceObject objectB)
		{
			return !(objectA == objectB);
		}

		internal HkReferenceObject(IntPtr referenceObj, bool track = false)
			: base(referenceObj, track)
		{
		}

		protected HkReferenceObject()
		{
		}
	}
	public enum HkWorldOperationResult
	{
		Posponed,
		Done
	}
	public enum HkBreakOffLogicResult
	{
		ProcessingError,
		BreakOff,
		DoNotBreakOff,
		UseLimit
	}
	[Flags]
	public enum HkActionType
	{
		EaseAction = 0
	}
	public delegate HkBreakOffLogicResult BreakLogicHandler(HkRigidBody otherBody, uint shapeKey, ref float maxImpulse);
	public delegate bool BreakPartsHandler(ref HkBreakOffPoints breakOffPoints, ref HkArrayUInt32 brokenKeysOut);
	[DebuggerDisplay("{DebugName}")]
	[SuppressUnmanagedCodeSecurity]
	public class HkRigidBody : HkEntity
	{
		public BreakPartsHandler BreakPartsHandler;

		public BreakLogicHandler BreakLogicHandler;

		private HkdBreakableBody m_breakableBody;

		private string m_debugName;

		private int m_layer;

		private Vector3 m_gravity = Vector3.Zero;

		private HkRigidBodyCinfo m_info;

		private IntPtr m_gravityAction = IntPtr.Zero;

		private bool m_listenerAdded;

		public HkResponseModifiers ResponseModifiers
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return (HkResponseModifiers)HkRigidBody_GetResponseModifiers(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetResponseModifiers(m_handle, (int)value);
				}
			}
		}

		public Vector3 Gravity
		{
			get
			{
				if (m_gravityAction != IntPtr.Zero)
				{
					m_gravity = HkRigidBody_GetGravity(m_gravityAction);
				}
				return m_gravity;
			}
			set
			{
				if (m_gravity != value)
				{
					if (m_gravityAction != IntPtr.Zero)
					{
						HkRigidBody_SetGravity(m_gravityAction, value);
					}
					m_gravity = value;
				}
			}
		}

		public bool EnableDeactivation
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetEnableDeactivation(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetEnableDeactivation(m_handle, value);
				}
			}
		}

		public HkMotion Motion
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return new HkMotion(HkRigidBody_GetMotion(m_handle));
				}
			}
		}

		public float Mass
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetMass(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetMass(m_handle, value);
				}
			}
		}

		public Vector3 CenterOfMassLocal
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetCenterOfMassLocal(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetCenterOfMassLocal(m_handle, value);
				}
			}
		}

		public Matrix InertiaTensor
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetInertiaTensor(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetInertiaTensor(m_handle, value);
				}
			}
		}

		public Matrix InverseInertiaTensor
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetInverseInertiaTensor(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetInverseInertiaTensor(m_handle, value);
				}
			}
		}

		public Vector4 DeltaAngle
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetDeltaAngle(m_handle);
				}
			}
		}

		public Vector3 CenterOfMassWorld
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetCenterOfMassWorld(m_handle);
				}
			}
		}

		public float LinearDamping
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetLinearDamping(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetLinearDamping(m_handle, value);
				}
			}
		}

		public float AngularDamping
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetAngularDamping(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetAngularDamping(m_handle, value);
				}
			}
		}

		public float MaxLinearVelocity
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetMaxLinearVelocity(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetMaxLinearVelocity(m_handle, value);
				}
			}
		}

		public float MaxAngularVelocity
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetMaxAngularVelocity(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetMaxAngularVelocity(m_handle, value);
				}
			}
		}

		public float AllowedPenetrationDepth
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetAllowedPenetrationDepth(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetAllowedPenetrationDepth(m_handle, value);
				}
			}
		}

		public float Friction
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetFriction(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetFriction(m_handle, value);
				}
			}
		}

		public float Restitution
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetRestitution(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetRestitution(m_handle, value);
				}
			}
		}

		public int Layer
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return m_layer;
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					m_layer = value;
					HkRigidBody_SetLayer(m_handle, value);
				}
			}
		}

		public HkdBreakableBody BreakableBody
		{
			get
			{
				if (m_breakableBody == null || !m_breakableBody.IsValid())
				{
					m_breakableBody = HkReferenceObject.Get<HkdBreakableBody>(HkRigidBody_GetBreakableBody(m_handle));
				}
				return m_breakableBody;
			}
			set
			{
				m_breakableBody = value;
			}
		}

		public bool MarkedForVelocityRecompute
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkRigidBody_GetMarkedForVelocityRecompute(m_handle);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkRigidBody_SetMarkedForVelocityRecompute(m_handle, value);
				}
			}
		}

		internal string DebugName
		{
			get
			{
				if (m_debugName == null)
				{
					m_debugName = GetNativeObjectName() ?? ("HkRigidBody{" + m_handle.ToString("X16") + "}");
				}
				return m_debugName;
			}
		}

		public bool IsEnvironment { get; set; }

		public int DeactivationCounter0 => HkRigidBody_GetDeactivationCounter0(m_handle);

		public int DeactivationCounter1 => HkRigidBody_GetDeactivationCounter1(m_handle);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkRigidBody_Create(IntPtr bodyInfo);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkRigidBody_CreateWithCustomVelocity(IntPtr bodyInfo);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetNumShapeKeysInContactPointProperties(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern int HkRigidBody_GetResponseModifiers(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetResponseModifiers(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkRigidBody_GetShape(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkRigidBody_SetShape(IntPtr instance, IntPtr shape);

		[DllImport("Havok.dll")]
		private static extern int HkRigidBody_UpdateShape(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Matrix HkRigidBody_PredictRigidBodyMatrix(IntPtr instance, float deltaTime, IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetMassProperties(IntPtr instance, HkMassProperties properties);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetWorldMatrix(IntPtr instance, Matrix m);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetTransform(IntPtr instance, Matrix m);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkRigidBody_GetEnableDeactivation(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetEnableDeactivation(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkRigidBody_GetMarkedForVelocityRecompute(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetMarkedForVelocityRecompute(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkRigidBody_GetMotion(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBody_GetMass(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetMass(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkRigidBody_GetCenterOfMassLocal(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetCenterOfMassLocal(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern Matrix HkRigidBody_GetInertiaTensor(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetInertiaTensor(IntPtr instance, Matrix value);

		[DllImport("Havok.dll")]
		private static extern Matrix HkRigidBody_GetInverseInertiaTensor(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetInverseInertiaTensor(IntPtr instance, Matrix value);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkRigidBody_GetCenterOfMassWorld(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkRigidBody_GetCustomVelocity(IntPtr instance, out Vector3 velocity);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetCustomVelocity(IntPtr instance, Vector3 value, [MarshalAs(UnmanagedType.I1)] bool valid);

		[DllImport("Havok.dll")]
		private static extern Vector4 HkRigidBody_GetDeltaAngle(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBody_GetLinearDamping(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetLinearDamping(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBody_GetAngularDamping(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetAngularDamping(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBody_GetMaxLinearVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetMaxLinearVelocity(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBody_GetMaxAngularVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetMaxAngularVelocity(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBody_GetAllowedPenetrationDepth(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetAllowedPenetrationDepth(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBody_GetFriction(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetFriction(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBody_GetRestitution(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetRestitution(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_ApplyLinearImpulse(IntPtr instance, Vector3 impulse);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_ApplyPointImpulse(IntPtr instance, Vector3 impulse, Vector3 point);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_ApplyAngularImpulse(IntPtr instance, Vector3 impulse);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetLayer(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern uint HkRigidBody_GetCollisionFilterInfo(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetCollisionFilterInfo(IntPtr instance, uint info);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_ApplyForce(IntPtr instance, float time, Vector3 force);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_ApplyForceToPoint(IntPtr instance, float time, Vector3 force, Vector3 point);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_ApplyTorque(IntPtr instance, float time, Vector3 torque);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkRigidBody_GetNativeObjectName(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_RemoveFromWorld(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkRigidBody_HasGravity(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkRigidBody_HasConstraints(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkRigidBody_GetBreakableBody(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkRigidBody_GetGravity(IntPtr gravityAction);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_ReleaseGravity(IntPtr gravityAction);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_SetGravity(IntPtr gravityAction, Vector3 gravity);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkRigidBody_Clone(IntPtr cloneBody);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkRigidBody_FromShape(IntPtr shape);

		[DllImport("Havok.dll")]
		private static extern ulong HkRigidBody_GetGcRoot(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkRigidBody_GetGravityAction(IntPtr instance, IntPtr action, Vector3 gravity);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBody_AddGravityAction(IntPtr instance, IntPtr action);

		[DllImport("Havok.dll")]
		private static extern int HkRigidBody_GetDeactivationCounter0(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkRigidBody_GetDeactivationCounter1(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkRigidBody_HasActions(IntPtr instance, HkActionType actionType);

		public HkRigidBody(HkRigidBodyCinfo rigidBodyInfo)
			: base(HkRigidBody_CreateWithCustomVelocity(rigidBodyInfo.NativeObject))
		{
			m_info = rigidBodyInfo;
			if (rigidBodyInfo.Shape.IsValid)
			{
				HkShape.AddOwner(rigidBodyInfo.Shape, this);
			}
		}

		public ulong GetGcRoot()
		{
			using (HkAccessControl.Read(this))
			{
				return HkRigidBody_GetGcRoot(base.NativeObject);
			}
		}

		public static HkRigidBody Clone(HkRigidBody cloneBody)
		{
			HkRigidBody hkRigidBody = new HkRigidBody(HkRigidBody_Clone(cloneBody.NativeObject));
			hkRigidBody.UserObject = cloneBody.UserObject;
			hkRigidBody.Layer = cloneBody.Layer;
			hkRigidBody.SetCollisionFilterInfo(cloneBody.GetCollisionFilterInfo());
			return hkRigidBody;
		}

		public static HkRigidBody FromShape(HkShape shape)
		{
			HkHandle.TryGetHandle<HkRigidBody>(HkRigidBody_FromShape(shape.NativeObject), out var handle);
			return handle;
		}

		internal static HkRigidBody Get(IntPtr bodyHandle)
		{
			if (bodyHandle == IntPtr.Zero)
			{
				return null;
			}
			HkHandle.TryGetHandle<HkRigidBody>(bodyHandle, out var handle);
			return handle;
		}

		public HkRigidBodyCinfo GetRigidBodyInfo()
		{
			using (HkAccessControl.Read(this))
			{
				return m_info;
			}
		}

		public HkShape GetShape()
		{
			using (HkAccessControl.Read(this))
			{
				return new HkShape(HkRigidBody_GetShape(m_handle));
			}
		}

		public HkWorldOperationResult SetShape(HkShape shape)
		{
			using (HkAccessControl.Write(this))
			{
				HkShape shape2 = GetShape();
				if (shape2.IsValid)
				{
					HkShape.RemoveOwner(shape2, this);
				}
				if (shape.IsValid)
				{
					HkShape.AddOwner(shape, this);
				}
				return (HkWorldOperationResult)HkRigidBody_SetShape(m_handle, shape.NativeObject);
			}
		}

		public HkWorldOperationResult UpdateShape()
		{
			using (HkAccessControl.Write(this))
			{
				return (HkWorldOperationResult)HkRigidBody_UpdateShape(m_handle);
			}
		}

		public Matrix PredictRigidBodyMatrix(float deltaTime, HkWorld world)
		{
			using (HkAccessControl.Read(this))
			{
				return HkRigidBody_PredictRigidBodyMatrix(base.NativeObject, deltaTime, world.NativeObject);
			}
		}

		public Matrix PredictRigidBodyMatrix2(float deltaTime, HkWorld world)
		{
			throw new NotImplementedException();
		}

		public void SetMassProperties(ref HkMassProperties properties)
		{
			using (HkAccessControl.Write(this))
			{
				HkRigidBody_SetMassProperties(m_handle, properties);
			}
		}

		public void SetWorldMatrix(Matrix m)
		{
			using (HkAccessControl.Write(this))
			{
				HkRigidBody_SetWorldMatrix(m_handle, m);
			}
		}

		public void SetTransform(Matrix m)
		{
			using (HkAccessControl.Write(this))
			{
				HkRigidBody_SetTransform(m_handle, m);
			}
		}

		public Vector3 GetVelocityAtPoint(Vector3 worldPos)
		{
			using (HkAccessControl.Read(this))
			{
				return base.LinearVelocity + base.AngularVelocity.Cross(worldPos - CenterOfMassWorld);
			}
		}

		public void ApplyLinearImpulse(Vector3 impulse)
		{
			using (HkAccessControl.Write(this, allowDuringStep: true))
			{
				HkRigidBody_ApplyLinearImpulse(m_handle, impulse);
			}
		}

		public void ApplyPointImpulse(Vector3 impulse, Vector3 point)
		{
			using (HkAccessControl.Write(this, allowDuringStep: true))
			{
				HkRigidBody_ApplyPointImpulse(m_handle, impulse, point);
			}
		}

		public void ApplyAngularImpulse(Vector3 impulse)
		{
			using (HkAccessControl.Write(this, allowDuringStep: true))
			{
				HkRigidBody_ApplyAngularImpulse(m_handle, impulse);
			}
		}

		public void SetCollisionFilterInfo(uint info)
		{
			using (HkAccessControl.Write(this))
			{
				HkRigidBody_SetCollisionFilterInfo(m_handle, info);
			}
		}

		public uint GetCollisionFilterInfo()
		{
			using (HkAccessControl.Read(this))
			{
				return HkRigidBody_GetCollisionFilterInfo(m_handle);
			}
		}

		public void ApplyForce(float time, Vector3 force)
		{
			using (HkAccessControl.Write(this, allowDuringStep: true))
			{
				HkRigidBody_ApplyForce(m_handle, time, force);
			}
		}

		public void ApplyForce(float time, Vector3 force, Vector3 point)
		{
			using (HkAccessControl.Write(this, allowDuringStep: true))
			{
				HkRigidBody_ApplyForceToPoint(m_handle, time, force, point);
			}
		}

		public void ApplyTorque(float time, Vector3 torque)
		{
			using (HkAccessControl.Write(this, allowDuringStep: true))
			{
				HkRigidBody_ApplyTorque(m_handle, time, torque);
			}
		}

		public string GetNativeObjectName()
		{
			using (HkAccessControl.Read(this))
			{
				IntPtr intPtr = HkRigidBody_GetNativeObjectName(m_handle);
				return (intPtr == IntPtr.Zero) ? null : HkHandle.MarshalToString(intPtr);
			}
		}

		public void RemoveFromWorld()
		{
			using (HkAccessControl.Write(this))
			{
				HkRigidBody_RemoveFromWorld(m_handle);
			}
		}

		public void AddGravity()
		{
			using (HkAccessControl.Write(this))
			{
				if (!HkRigidBody_HasGravity(m_handle))
				{
					GetGravityAction();
					HkRigidBody_AddGravityAction(base.NativeObject, m_gravityAction);
				}
			}
		}

		public void OnReaddedToWorld()
		{
			using (HkAccessControl.Write(this))
			{
				AddGravity();
			}
		}

		public bool HasConstraints()
		{
			using (HkAccessControl.Read(this))
			{
				return HkRigidBody_HasConstraints(m_handle);
			}
		}

		public bool HasActions(HkActionType actionType)
		{
			using (HkAccessControl.Read(this))
			{
				return HkRigidBody_HasActions(m_handle, actionType);
			}
		}

		public void SetCustomVelocity(Vector3 velocity, bool valid)
		{
			using (HkAccessControl.Write(this, allowDuringStep: true))
			{
				HkRigidBody_SetCustomVelocity(m_handle, velocity, valid);
			}
		}

		public bool GetCustomVelocity(out Vector3 velocity)
		{
			using (HkAccessControl.Read(this))
			{
				return HkRigidBody_GetCustomVelocity(m_handle, out velocity);
			}
		}

		internal HkRigidBody(IntPtr body)
			: base(body)
		{
			HkReferenceObject.HkReferenceObject_AddReference(m_handle);
		}

		internal void Clear()
		{
			using (HkAccessControl.Write(this))
			{
				if (m_listenerAdded)
				{
					HkEntity.HkEntity_RemoveActivationListener(base.NativeObject, m_activationListener.NativeObject);
					m_activationListener.Dispose();
					m_listenerAdded = false;
				}
				RemoveReference();
			}
		}

		protected override void Dispose(bool disposing)
		{
			using (HkAccessControl.Write(this))
			{
				if (m_gravityAction != IntPtr.Zero)
				{
					HkRigidBody_ReleaseGravity(m_gravityAction);
					m_gravityAction = IntPtr.Zero;
				}
				if (m_listenerAdded)
				{
					HkEntity.HkEntity_RemoveActivationListener(base.NativeObject, m_activationListener.NativeObject);
					m_activationListener.Dispose();
					m_listenerAdded = false;
				}
				m_info?.Dispose();
				HkShape shape = GetShape();
				_ = shape.ReferenceCount;
				_ = 1;
				if (shape.IsValid)
				{
					HkShape.RemoveOwner(shape, this);
				}
				base.Dispose(disposing);
			}
		}

		internal IntPtr GetGravityAction()
		{
			using (HkAccessControl.Read(this))
			{
				m_gravityAction = HkRigidBody_GetGravityAction(base.NativeObject, m_gravityAction, m_gravity);
				return m_gravityAction;
			}
		}

		protected override void Init()
		{
			base.Init();
			HkEntity.HkEntity_AddActivationListener(base.NativeObject, m_activationListener.NativeObject);
			m_listenerAdded = true;
			HkRigidBody_SetNumShapeKeysInContactPointProperties(m_handle, 4);
		}

		public override string ToString()
		{
			return DebugName;
		}
	}
	public enum HkMotionType : byte
	{
		Invalid,
		Dynamic,
		Sphere_Inertia,
		Box_Inertia,
		Keyframed,
		Fixed,
		Thin_Box_Inertia,
		Character
	}
	public enum HkCollidableQualityType
	{
		Invalid = -1,
		Fixed,
		Keyframed,
		Debris,
		DebrisSimpleToi,
		Moving,
		Critical,
		Bullet,
		User,
		Character,
		KeyframedReporting
	}
	public enum HkSolverDeactivation
	{
		Invalid,
		Off,
		Low,
		Medium,
		High,
		Max
	}
	public enum HkResponseType
	{
		Invalid,
		SimpleContact,
		[Obsolete("Deprecated. Instead of using this, you can disable contacts from a hkpContactListener.")]
		Reporting,
		None,
		MaxId
	}
	public enum HkResponseModifiers
	{
		MassScaling = 1,
		CenterOfMassDisplacement = 2,
		SurfaceVelocity = 4,
		ImpulseScaling = 8,
		ViscousSurface = 16,
		AdditionalSizeModifiers = 7
	}
	public class HkRigidBodyCinfo : HkHandle
	{
		public HkResponseType CollisionResponse
		{
			get
			{
				return (HkResponseType)HkRigidBodyCinfo_GetCollisionResponse(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetCollisionResponse(m_handle, (int)value);
			}
		}

		public HkResponseModifiers ResponseModifiers
		{
			get
			{
				return (HkResponseModifiers)HkRigidBodyCinfo_GetResponseModifiers(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetResponseModifiers(m_handle, (int)value);
			}
		}

		public Vector3 Position
		{
			get
			{
				return HkRigidBodyCinfo_GetPosition(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetPosition(m_handle, value);
			}
		}

		public Quaternion Rotation
		{
			get
			{
				return HkRigidBodyCinfo_GetRotation(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetRotation(m_handle, value);
			}
		}

		public Vector3 LinearVelocity
		{
			get
			{
				return HkRigidBodyCinfo_GetLinearVelocity(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetLinearVelocity(m_handle, value);
			}
		}

		public Vector3 AngularVelocity
		{
			get
			{
				return HkRigidBodyCinfo_GetAngularVelocity(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetAngularVelocity(m_handle, value);
			}
		}

		public Vector3 CenterOfMass
		{
			get
			{
				return HkRigidBodyCinfo_GetCenterOfMass(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetCenterOfMass(m_handle, value);
			}
		}

		public float Mass
		{
			get
			{
				return HkRigidBodyCinfo_GetMass(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetMass(m_handle, value);
			}
		}

		public float LinearDamping
		{
			get
			{
				return HkRigidBodyCinfo_GetLinearDamping(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetLinearDamping(m_handle, value);
			}
		}

		public float AngularDamping
		{
			get
			{
				return HkRigidBodyCinfo_GetAngularDamping(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetAngularDamping(m_handle, value);
			}
		}

		public float Friction
		{
			get
			{
				return HkRigidBodyCinfo_GetFriction(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetFriction(m_handle, value);
			}
		}

		public float Restitution
		{
			get
			{
				return HkRigidBodyCinfo_GetRestitution(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetRestitution(m_handle, value);
			}
		}

		public float MaxLinearVelocity
		{
			get
			{
				return HkRigidBodyCinfo_GetMaxLinearVelocity(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetMaxLinearVelocity(m_handle, value);
			}
		}

		public float MaxAngularVelocity
		{
			get
			{
				return HkRigidBodyCinfo_GetMaxAngularVelocity(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetMaxAngularVelocity(m_handle, value);
			}
		}

		public ushort ContactPointCallbackDelay
		{
			get
			{
				return HkRigidBodyCinfo_GetContactPointCallbackDelay(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetContactPointCallbackDelay(m_handle, value);
			}
		}

		public float AllowedPenetrationDepth
		{
			get
			{
				return HkRigidBodyCinfo_GetAllowedPenetrationDepth(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetAllowedPenetrationDepth(m_handle, value);
			}
		}

		public HkMotionType MotionType
		{
			get
			{
				return (HkMotionType)HkRigidBodyCinfo_GetMotionType(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetMotionType(m_handle, (int)value);
			}
		}

		public HkSolverDeactivation SolverDeactivation
		{
			get
			{
				return (HkSolverDeactivation)HkRigidBodyCinfo_GetSolverDeactivation(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetSolverDeactivation(m_handle, (int)value);
			}
		}

		public HkCollidableQualityType QualityType
		{
			get
			{
				return (HkCollidableQualityType)HkRigidBodyCinfo_GetQualityType(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetQualityType(m_handle, (int)value);
			}
		}

		public sbyte AutoRemoveLevel
		{
			get
			{
				return HkRigidBodyCinfo_GetAutoRemoveLevel(m_handle);
			}
			set
			{
				HkRigidBodyCinfo_SetAutoRemoveLevel(m_handle, value);
			}
		}

		public HkShape Shape
		{
			get
			{
				return new HkShape(HkRigidBodyCinfo_GetShape(m_handle));
			}
			set
			{
				HkRigidBodyCinfo_SetShape(m_handle, value.NativeObject);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkRigidBodyCinfo_Create();

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_Release(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkRigidBodyCinfo_GetCollisionResponse(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetCollisionResponse(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern int HkRigidBodyCinfo_GetResponseModifiers(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetResponseModifiers(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkRigidBodyCinfo_GetPosition(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetPosition(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern Quaternion HkRigidBodyCinfo_GetRotation(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetRotation(IntPtr instance, Quaternion value);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkRigidBodyCinfo_GetLinearVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetLinearVelocity(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkRigidBodyCinfo_GetAngularVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetAngularVelocity(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkRigidBodyCinfo_GetCenterOfMass(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetCenterOfMass(IntPtr instance, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBodyCinfo_GetMass(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetMass(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBodyCinfo_GetLinearDamping(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetLinearDamping(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBodyCinfo_GetAngularDamping(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetAngularDamping(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBodyCinfo_GetFriction(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetFriction(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBodyCinfo_GetRestitution(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetRestitution(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBodyCinfo_GetMaxLinearVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetMaxLinearVelocity(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBodyCinfo_GetMaxAngularVelocity(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetMaxAngularVelocity(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern ushort HkRigidBodyCinfo_GetContactPointCallbackDelay(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetContactPointCallbackDelay(IntPtr instance, ushort value);

		[DllImport("Havok.dll")]
		private static extern float HkRigidBodyCinfo_GetAllowedPenetrationDepth(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetAllowedPenetrationDepth(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern int HkRigidBodyCinfo_GetMotionType(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetMotionType(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern int HkRigidBodyCinfo_GetSolverDeactivation(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetSolverDeactivation(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern int HkRigidBodyCinfo_GetQualityType(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetQualityType(IntPtr instance, int value);

		[DllImport("Havok.dll")]
		private static extern sbyte HkRigidBodyCinfo_GetAutoRemoveLevel(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetAutoRemoveLevel(IntPtr instance, sbyte value);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkRigidBodyCinfo_GetShape(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetShape(IntPtr instance, IntPtr value);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_CalculateBoxInertiaTensor(IntPtr instance, Vector3 halfExtents, float mass);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_CalculateSphereInertiaTensor(IntPtr instance, float radius, float mass);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_SetMassProperties(IntPtr instance, HkMassProperties properties);

		[DllImport("Havok.dll")]
		private static extern void HkRigidBodyCinfo_ComputeShapeMass(IntPtr instance, IntPtr shape, float mass);

		public HkRigidBodyCinfo()
		{
			m_handle = HkRigidBodyCinfo_Create();
		}

		public void CalculateBoxInertiaTensor(Vector3 halfExtents, float mass)
		{
			HkRigidBodyCinfo_CalculateBoxInertiaTensor(m_handle, halfExtents, mass);
		}

		public void CalculateSphereInertiaTensor(float radius, float mass)
		{
			HkRigidBodyCinfo_CalculateSphereInertiaTensor(m_handle, radius, mass);
		}

		public void SetMassProperties(HkMassProperties properties)
		{
			HkRigidBodyCinfo_SetMassProperties(m_handle, properties);
		}

		public void ComputeShapeMass(HkShape shape, float mass)
		{
			HkRigidBodyCinfo_ComputeShapeMass(m_handle, shape.NativeObject, mass);
		}

		protected override void Dispose(bool a)
		{
			HkRigidBodyCinfo_Release(base.NativeObject);
		}

		internal HkRigidBodyCinfo(IntPtr info)
		{
			m_handle = info;
		}
	}
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct HkSimulationIslandInfo
	{
		private HkSimulationIslandRef m_handle;

		public BoundingBox AABB;

		public bool IsActive;

		public int EntitiesCount => m_handle.GetEntityCount();

		internal HkSimulationIslandInfo(HkSimulationIslandRef @ref)
		{
			m_handle = @ref;
			IsActive = m_handle.IsActive();
			m_handle.GetBounds(out AABB);
		}

		public HkSimulationIslandInfo(bool isActive, BoundingBox AABB, IntPtr handle)
		{
			m_handle = new HkSimulationIslandRef(handle);
			IsActive = isActive;
			this.AABB = AABB;
		}

		public HkRigidBody GetEntity(int index)
		{
			return m_handle.GetEntity(index);
		}
	}
	public struct HkSimulationIslandRef
	{
		private static readonly int ActiveOffset;

		private static readonly int ActiveBitOffset;

		private readonly IntPtr m_handle;

		public bool IsValid => m_handle != IntPtr.Zero;

		[DllImport("Havok.dll")]
		private static extern int HkSimulationIsland_GetEntityCount(IntPtr island);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkSimulationIsland_GetEntity(IntPtr island, int index);

		[DllImport("Havok.dll")]
		private static extern void HkSimulationIsland_GetBounds(IntPtr island, out BoundingBox bb);

		[DllImport("Havok.dll")]
		private static extern void HkSimulationIsland_GetOffsets(out int activeOffset, out int activeBitFieldOffset);

		static HkSimulationIslandRef()
		{
			HkSimulationIsland_GetOffsets(out ActiveOffset, out ActiveBitOffset);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static bool GetActive(IntPtr handle)
		{
			return ((*(int*)(handle + ActiveOffset).ToPointer() >> ActiveBitOffset) & 3) == 1;
		}

		public HkSimulationIslandRef(IntPtr handle)
		{
			m_handle = handle;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal IntPtr GetHandle()
		{
			return m_handle;
		}

		public HkSimulationIslandInfo GetInfo()
		{
			CheckHandle();
			return new HkSimulationIslandInfo(this);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsActive()
		{
			CheckHandle();
			return GetActive(m_handle);
		}

		public int GetEntityCount()
		{
			CheckHandle();
			return HkSimulationIsland_GetEntityCount(m_handle);
		}

		public HkRigidBody GetEntity(int index)
		{
			CheckHandle();
			IntPtr intPtr = HkSimulationIsland_GetEntity(m_handle, index);
			if (intPtr != IntPtr.Zero)
			{
				return HkRigidBody.Get(intPtr);
			}
			return null;
		}

		public void GetBounds(out BoundingBox bounds)
		{
			CheckHandle();
			HkSimulationIsland_GetBounds(m_handle, out bounds);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CheckHandle()
		{
			if (m_handle == IntPtr.Zero)
			{
				throw new InvalidOperationException("Island handle is null.");
			}
		}
	}
	public enum HkTaskType
	{
		Schedule = 101,
		Execute,
		AwaitTasks,
		Finish,
		HK_JOB_TYPE_DYNAMICS,
		HK_JOB_TYPE_COLLIDE,
		HK_JOB_TYPE_COLLISION_QUERY,
		HK_JOB_TYPE_RAYCAST_QUERY,
		HK_JOB_TYPE_DESTRUCTION,
		HK_JOB_TYPE_CHARACTER_PROXY,
		HK_JOB_TYPE_COLLIDE_STATIC_COMPOUND,
		HK_JOB_TYPE_OTHER
	}
	public static class HkTaskProfiler
	{
		public delegate void TaskStartedFunc(string name, HkTaskType type);

		public delegate void TaskFinishedFunc();

		public delegate void BlockBeginFunc(string name);

		public delegate void BlockEndFunc(long ticks);

		internal unsafe delegate void TaskStartedFuncCpp(char* name, HkTaskType type);

		internal unsafe delegate void BlockBeginFuncCpp(char* name);

		private static readonly ConcurrentDictionary<IntPtr, string> UnmanagedStringCache = new ConcurrentDictionary<IntPtr, string>(IntPtrComparer.Instance);

		private static TaskStartedFunc m_taskStartedFunc;

		private static TaskFinishedFunc m_taskFinishedFunc;

		[ThreadStatic]
		private static BlockBeginFunc m_blockBeginFunc;

		[ThreadStatic]
		private static BlockEndFunc m_blockEndFunc;

		private static TaskStartedFuncCpp m_taskStartedFuncCpp;

		private static TaskFinishedFunc m_taskFinishedFuncCpp;

		private static BlockBeginFuncCpp m_blockBeginFuncCpp;

		private static BlockEndFunc m_blockEndFuncCpp;

		[DllImport("Havok.dll")]
		internal static extern void HkTaskProfiler_Init(TaskStartedFuncCpp onTaskStarted, TaskFinishedFunc onTaskFinished);

		[DllImport("Havok.dll")]
		internal static extern void HkTaskProfiler_ReleaseResources();

		[DllImport("Havok.dll")]
		internal static extern void HkTaskProfiler_HookJobQueue(IntPtr jobQueue);

		[DllImport("Havok.dll")]
		internal static extern void HkTaskProfiler_ReplayTimers(BlockBeginFuncCpp blockBegin, BlockEndFunc blockEnd);

		[DllImport("Havok.dll")]
		internal static extern void HkTaskProfiler_Begin1();

		[DllImport("Havok.dll")]
		internal static extern void HkTaskProfiler_Begin2();

		[DllImport("Havok.dll")]
		internal static extern void HkTaskProfiler_Begin3();

		[DllImport("Havok.dll")]
		internal static extern void HkTaskProfiler_Begin4();

		[DllImport("Havok.dll")]
		internal static extern void HkTaskProfiler_Begin5();

		[DllImport("Havok.dll")]
		internal static extern void HkTaskProfiler_End();

		public unsafe static void Init(TaskStartedFunc onTaskStarted, TaskFinishedFunc onTaskFinished)
		{
			m_taskStartedFunc = onTaskStarted;
			m_taskFinishedFunc = onTaskFinished;
			m_blockBeginFunc = null;
			m_taskStartedFuncCpp = TaskStarted;
			m_taskFinishedFuncCpp = TaskFinished;
			m_blockBeginFuncCpp = BlockBegin;
			m_blockEndFuncCpp = BlockEnd;
			HkTaskProfiler_Init(m_taskStartedFuncCpp, m_taskFinishedFuncCpp);
		}

		public static void ReleaseResources()
		{
			HkTaskProfiler_ReleaseResources();
		}

		public static void HookJobQueue(HkJobQueue jobQueue)
		{
			HkTaskProfiler_HookJobQueue(jobQueue.NativeObject);
		}

		public unsafe static void ReplayTimers(BlockBeginFunc blockBegin, BlockEndFunc blockEnd)
		{
			m_blockBeginFunc = blockBegin;
			m_blockEndFunc = blockEnd;
			HkTaskProfiler_ReplayTimers(m_blockBeginFuncCpp, m_blockEndFuncCpp);
			m_blockBeginFunc = null;
			m_blockEndFunc = null;
		}

		public static void OnTaskStarted(string name, HkTaskType type)
		{
			m_taskStartedFunc?.Invoke(name, type);
		}

		public static void OnTaskFinished()
		{
			m_taskFinishedFunc?.Invoke();
		}

		public static void Begin1()
		{
			HkTaskProfiler_Begin1();
		}

		public static void Begin2()
		{
			HkTaskProfiler_Begin2();
		}

		public static void Begin3()
		{
			HkTaskProfiler_Begin3();
		}

		public static void Begin4()
		{
			HkTaskProfiler_Begin4();
		}

		public static void Begin5()
		{
			HkTaskProfiler_Begin5();
		}

		public static void End()
		{
			HkTaskProfiler_End();
		}

		[MonoPInvokeCallback(typeof(TaskStartedFuncCpp))]
		private unsafe static void TaskStarted(char* name, HkTaskType type)
		{
			OnTaskStarted(GetManagedString(name), type);
		}

		[MonoPInvokeCallback(typeof(TaskFinishedFunc))]
		private static void TaskFinished()
		{
			m_taskFinishedFunc?.Invoke();
		}

		[MonoPInvokeCallback(typeof(BlockBeginFuncCpp))]
		private unsafe static void BlockBegin(char* name)
		{
			m_blockBeginFunc?.Invoke(GetManagedString(name));
		}

		[MonoPInvokeCallback(typeof(BlockEndFunc))]
		private static void BlockEnd(long ticks)
		{
			m_blockEndFunc?.Invoke(ticks);
		}

		private unsafe static string GetManagedString(char* str)
		{
			if (!UnmanagedStringCache.TryGetValue((IntPtr)str, out var value))
			{
				value = Marshal.PtrToStringAnsi((IntPtr)str);
				return UnmanagedStringCache.GetOrAdd((IntPtr)str, value);
			}
			return value;
		}
	}
	public static class HkVDB
	{
		public static int Port
		{
			get
			{
				return HkVDB_GetPort();
			}
			set
			{
				HkVDB_SetPort(value);
			}
		}

		[DllImport("Havok.dll")]
		internal static extern void HkVDB_SyncTimers(IntPtr threadPool);

		[DllImport("Havok.dll")]
		internal static extern void HkVDB_StepVDB(IntPtr world, float timeInSec);

		[DllImport("Havok.dll")]
		internal static extern void HkVDB_Start();

		[DllImport("Havok.dll")]
		internal static extern void HkVDB_ReleaseResources();

		[DllImport("Havok.dll")]
		internal static extern int HkVDB_GetPort();

		[DllImport("Havok.dll")]
		internal static extern void HkVDB_SetPort(int value);

		[DllImport("Havok.dll")]
		internal static extern void HkVDB_UpdateCamera(ref Vector3 from, ref Vector3 to, ref Vector3 up);

		[DllImport("Havok.dll")]
		internal static extern void HkVDB_Capture(string path);

		[DllImport("Havok.dll")]
		internal static extern void HkVDB_EndCapture();

		public static void SyncTimers(HkJobThreadPool threadPool)
		{
			if (threadPool != null)
			{
				HkVDB_SyncTimers(threadPool.NativeObject);
			}
		}

		public static void StepVDB(HkWorld world, float timeInSec)
		{
			HkVDB_StepVDB(world.NativeObject, timeInSec);
		}

		public static void Start()
		{
			HkVDB_Start();
		}

		public static void ReleaseResources()
		{
			HkVDB_ReleaseResources();
		}

		public static void UpdateCamera(ref Vector3 from, ref Vector3 to, ref Vector3 up)
		{
			HkVDB_UpdateCamera(ref from, ref to, ref up);
		}

		public static void Capture(string vdbRecordFile)
		{
			HkVDB_Capture(vdbRecordFile);
		}

		public static void EndCapture()
		{
			HkVDB_EndCapture();
		}
	}
	public struct HkBodyCollision
	{
		public HkRigidBody Body;

		public uint ShapeKey;
	}
	public struct ShapePath
	{
		private unsafe fixed uint m_shapeKeys[8];

		private int m_shapeKeyCount;

		public int Count => m_shapeKeyCount;

		public unsafe uint this[int index] => m_shapeKeys[index];

		public unsafe uint GetShapeKey(int index)
		{
			return m_shapeKeys[index];
		}
	}
	public struct HkShapeCollision
	{
		private unsafe fixed uint m_shapeKeys[8];

		public uint ShapeKeyCount;

		public unsafe uint GetShapeKey(int index)
		{
			return m_shapeKeys[index];
		}
	}
	public struct HkContactPointData
	{
		public Vector3D HitPosition;

		public Vector3 Normal;

		public float DistanceFraction;
	}
	public struct HkHitInfo
	{
		public float HitFraction;

		public Vector3 Position;

		public Vector3 Normal;

		public HkRigidBody Body;

		private ShapePath ShapeKeys;

		public int ShapeKeyCount => ShapeKeys.Count;

		public uint GetShapeKey(int index)
		{
			return ShapeKeys[index];
		}

		internal HkHitInfo(in HkWorld.HitInfo hit)
		{
			HitFraction = hit.Fraction;
			Body = HkRigidBody.Get(hit.Body);
			Normal = hit.Normal;
			Position = hit.Position;
			ShapeKeys = hit.ShapeKeys;
		}

		internal HkHitInfo(float InFraction, Vector3 InPosition, Vector3 InNormal, IntPtr InBody, ShapePath shapeKeys)
		{
			HitFraction = InFraction;
			Position = InPosition;
			Normal = InNormal;
			Body = HkRigidBody.Get(InBody);
			ShapeKeys = shapeKeys;
		}
	}
	public class HkWorld : HkHandle
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct BodyCollision
		{
			public IntPtr Body;

			public uint ShapeKey;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		internal struct HitInfo
		{
			public IntPtr Body;

			public ShapePath ShapeKeys;

			public Vector3 Position;

			public Vector3 Normal;

			public float Fraction;
		}

		public enum SimulationType : byte
		{
			SIMULATION_TYPE_INVALID,
			SIMULATION_TYPE_DISCRETE,
			SIMULATION_TYPE_CONTINUOUS,
			SIMULATION_TYPE_MULTITHREADED
		}

		public enum ContactPointGeneration : byte
		{
			CONTACT_POINT_ACCEPT_ALWAYS,
			CONTACT_POINT_REJECT_DUBIOUS,
			CONTACT_POINT_REJECT_MANY
		}

		public enum BroadPhaseType : byte
		{
			BROADPHASE_TYPE_SAP,
			BROADPHASE_TYPE_TREE,
			BROADPHASE_TYPE_HYBRID
		}

		public enum BroadPhaseBorderBehaviour : byte
		{
			BROADPHASE_BORDER_ASSERT,
			BROADPHASE_BORDER_FIX_ENTITY,
			BROADPHASE_BORDER_REMOVE_ENTITY,
			BROADPHASE_BORDER_DO_NOTHING
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct CInfo
		{
			public Vector3 Gravity;

			public int BroadPhaseQuerySize;

			public float ContactRestingVelocity;

			public BroadPhaseType BroadPhaseType;

			public BroadPhaseBorderBehaviour BroadPhaseBorderBehaviour;

			[MarshalAs(UnmanagedType.I1)]
			public bool MtPostponeAndSortBroadPhaseBorderCallbacks;

			public BoundingBox BroadPhaseWorldAabb;

			public float CollisionTolerance;

			public float ExpectedMaxLinearVelocity;

			public int SizeOfToiEventQueue;

			public float ExpectedMinPsiDeltaTime;

			public int BroadPhaseNumMarkers;

			public ContactPointGeneration ContactPointGeneration;

			[MarshalAs(UnmanagedType.I1)]
			public bool AllowToSkipConfirmedCallbacks;

			public float SolverTau;

			public float SolverDamp;

			public int SolverIterations;

			public int SolverMicrosteps;

			public float MaxConstraintViolation;

			[MarshalAs(UnmanagedType.I1)]
			public bool ForceCoherentConstraintOrderingInSolver;

			public float SnapCollisionToConvexEdgeThreshold;

			public float SnapCollisionToConcaveEdgeThreshold;

			[MarshalAs(UnmanagedType.I1)]
			public bool EnableToiWeldRejection;

			[MarshalAs(UnmanagedType.I1)]
			public bool EnableDeprecatedWelding;

			public float IterativeLinearCastEarlyOutDistance;

			public int IterativeLinearCastMaxIterations;

			public byte DeactivationNumInactiveFramesSelectFlag0;

			public byte DeactivationNumInactiveFramesSelectFlag1;

			public byte DeactivationIntegrateCounter;

			[MarshalAs(UnmanagedType.I1)]
			public bool ShouldActivateOnRigidBodyTransformChange;

			public float DeactivationReferenceDistance;

			public float ToiCollisionResponseRotateNormal;

			[MarshalAs(UnmanagedType.I1)]
			public bool UseCompoundSpuElf;

			public int MaxSectorsPerMidphaseCollideTask;

			public int MaxSectorsPerNarrowphaseCollideTask;

			[MarshalAs(UnmanagedType.I1)]
			public bool ProcessToisMultithreaded;

			public int MaxEntriesPerToiMidphaseCollideTask;

			public int MaxEntriesPerToiNarrowphaseCollideTask;

			public int MaxNumToiCollisionPairsSinglethreaded;

			public float NumToisTillAllowedPenetrationSimplifiedToi;

			public float NumToisTillAllowedPenetrationToi;

			public float NumToisTillAllowedPenetrationToiHigher;

			public float NumToisTillAllowedPenetrationToiForced;

			[MarshalAs(UnmanagedType.I1)]
			public bool EnableDeactivation;

			public SimulationType SimulationType;

			[MarshalAs(UnmanagedType.I1)]
			public bool EnableSimulationIslands;

			public uint MinDesiredIslandSize;

			[MarshalAs(UnmanagedType.I1)]
			public bool ProcessActionsInSingleThread;

			[MarshalAs(UnmanagedType.I1)]
			public bool AllowIntegrationOfIslandsWithoutConstraintsInASeparateJob;

			public float FrameMarkerPsiSnap;

			[MarshalAs(UnmanagedType.I1)]
			public bool FireCollisionCallbacks;

			public static CInfo Create()
			{
				CInfo result = default(CInfo);
				result.Gravity = new Vector3(0f, -9.8f, 0f);
				result.BroadPhaseQuerySize = 1024;
				result.MtPostponeAndSortBroadPhaseBorderCallbacks = false;
				result.CollisionTolerance = 0.1f;
				result.ExpectedMaxLinearVelocity = 200f;
				result.SizeOfToiEventQueue = 250;
				result.ExpectedMinPsiDeltaTime = 1f / 30f;
				result.AllowToSkipConfirmedCallbacks = false;
				result.SolverDamp = 0.6f;
				result.SolverIterations = 4;
				result.SolverMicrosteps = 1;
				result.MaxConstraintViolation = 1.8446726E+19f;
				result.ForceCoherentConstraintOrderingInSolver = false;
				result.SnapCollisionToConvexEdgeThreshold = 0.524f;
				result.SnapCollisionToConcaveEdgeThreshold = 0.698f;
				result.EnableToiWeldRejection = false;
				result.EnableDeprecatedWelding = false;
				result.IterativeLinearCastEarlyOutDistance = 0.01f;
				result.IterativeLinearCastMaxIterations = 20;
				result.DeactivationNumInactiveFramesSelectFlag0 = 0;
				result.DeactivationNumInactiveFramesSelectFlag1 = 0;
				result.DeactivationIntegrateCounter = 0;
				result.ShouldActivateOnRigidBodyTransformChange = true;
				result.DeactivationReferenceDistance = 0.02f;
				result.ToiCollisionResponseRotateNormal = 0.2f;
				result.UseCompoundSpuElf = false;
				result.MaxSectorsPerMidphaseCollideTask = 2;
				result.MaxSectorsPerNarrowphaseCollideTask = 4;
				result.ProcessToisMultithreaded = true;
				result.MaxEntriesPerToiMidphaseCollideTask = -1;
				result.MaxEntriesPerToiNarrowphaseCollideTask = -1;
				result.MaxNumToiCollisionPairsSinglethreaded = 0;
				result.NumToisTillAllowedPenetrationSimplifiedToi = 3f;
				result.NumToisTillAllowedPenetrationToi = 3f;
				result.NumToisTillAllowedPenetrationToiHigher = 4f;
				result.NumToisTillAllowedPenetrationToiForced = 20f;
				result.EnableDeactivation = true;
				result.EnableSimulationIslands = true;
				result.MinDesiredIslandSize = 64u;
				result.ProcessActionsInSingleThread = true;
				result.AllowIntegrationOfIslandsWithoutConstraintsInASeparateJob = false;
				result.FrameMarkerPsiSnap = 0.0001f;
				result.FireCollisionCallbacks = false;
				result.SimulationType = SimulationType.SIMULATION_TYPE_CONTINUOUS;
				result.ContactPointGeneration = ContactPointGeneration.CONTACT_POINT_REJECT_MANY;
				result.BroadPhaseNumMarkers = 0;
				result.BroadPhaseType = BroadPhaseType.BROADPHASE_TYPE_SAP;
				result.BroadPhaseBorderBehaviour = BroadPhaseBorderBehaviour.BROADPHASE_BORDER_ASSERT;
				result.ContactRestingVelocity = 1f;
				return result;
			}
		}

		private delegate void BroadPhaseExitCallback(IntPtr world, IntPtr body);

		public const int DEFAULT_DEBUGGER_PORT = 25001;

		public HkdWorld DestructionWorld;

		private static readonly BroadPhaseExitCallback MaxPositionExceededDelegate = OnMaxPositionExceeded;

		private unsafe static readonly int PenetrationBufferSize = 20 * sizeof(BodyCollision);

		private unsafe static readonly int ShapeShapeBufferSize = 8 * sizeof(HkShapeCollision);

		private unsafe static readonly int RayCastResultBufferSize = 16 * sizeof(HitInfo);

		private unsafe static readonly int SimulationIslandBufferSize = 32 * sizeof(HkSimulationIslandInfo);

		private IntPtr m_filter;

		private IntPtr m_penetrationHits;

		private IntPtr m_addBatch;

		private IntPtr m_removeBatch;

		private bool m_enableMultithreading;

		private int m_addBatchSize;

		private int m_addBatchCount;

		private int m_removeBatchSize;

		private int m_removeBatchCount;

		private Stopwatch m_timer;

		private TimeSpan m_stepDuration;

		private HkJobQueue m_jobQueue;

		private HkJobThreadPool m_threadPool;

		private HkConstraintProjectorListener m_constraintProjectorListener;

		private HkBreakOffPartsUtil m_breakOffUtil;

		private List<HkRigidBody> m_rigidBodies;

		private List<HkRigidBody> m_addBatchRB;

		private List<HkCharacterRigidBody> m_characterRigidBodies;

		private int m_activeBodiesVersion;

		private int m_activeCacheBodiesVersion;

		private List<HkRigidBody> m_activeRigidBodiesCache = new List<HkRigidBody>();

		private HashSet<HkRigidBody> m_activeRigidBodies;

		public bool Multithreading
		{
			get
			{
				using (HkAccessControl.Read())
				{
					return m_enableMultithreading;
				}
			}
			set
			{
				using (HkAccessControl.Write())
				{
					m_enableMultithreading = value;
				}
			}
		}

		public TimeSpan StepDuration
		{
			get
			{
				using (HkAccessControl.Read())
				{
					return m_stepDuration;
				}
			}
		}

		public HkBreakOffPartsUtil BreakOffPartsUtil
		{
			get
			{
				using (HkAccessControl.Read())
				{
					if (m_breakOffUtil == null)
					{
						m_breakOffUtil = new HkBreakOffPartsUtil();
						HkWorld_AddWorldExtension(base.NativeObject, m_breakOffUtil.NativeObject);
					}
					return m_breakOffUtil;
				}
			}
		}

		public HkJobThreadPool ThreadPool
		{
			get
			{
				using (HkAccessControl.Read())
				{
					return m_threadPool;
				}
			}
		}

		public HkJobQueue JobQueue
		{
			get
			{
				using (HkAccessControl.Read())
				{
					return m_jobQueue;
				}
			}
		}

		public List<HkRigidBody> RigidBodies
		{
			get
			{
				using (HkAccessControl.Read())
				{
					return m_rigidBodies;
				}
			}
		}

		public List<HkCharacterRigidBody> CharacterRigidBodies
		{
			get
			{
				using (HkAccessControl.Read())
				{
					return m_characterRigidBodies;
				}
			}
		}

		public HashSetReader<HkRigidBody> ActiveRigidBodies
		{
			get
			{
				using (HkAccessControl.Read())
				{
					return m_activeRigidBodies;
				}
			}
		}

		public Vector3 Gravity
		{
			get
			{
				using (HkAccessControl.Read())
				{
					return HkWorld_GetGravity(base.NativeObject);
				}
			}
			set
			{
				using (HkAccessControl.Write())
				{
					HkWorld_SetGravity(base.NativeObject, value);
				}
			}
		}

		public float DeactivationRotationSqrdA
		{
			get
			{
				using (HkAccessControl.Read())
				{
					return HkWorld_GetDeactivationRotationSqrdA(base.NativeObject);
				}
			}
			set
			{
				using (HkAccessControl.Write())
				{
					HkWorld_SetDeactivationRotationSqrdA(base.NativeObject, value);
				}
			}
		}

		public float DeactivationRotationSqrdB
		{
			get
			{
				using (HkAccessControl.Read())
				{
					return HkWorld_GetDeactivationRotationSqrdB(base.NativeObject);
				}
			}
			set
			{
				using (HkAccessControl.Write())
				{
					HkWorld_SetDeactivationRotationSqrdB(base.NativeObject, value);
				}
			}
		}

		public event HkEntityHandler EntityLeftWorld;

		public event HkEntityHandler OnRigidBodyActivated;

		public event HkEntityHandler OnRigidBodyDeactivated;

		public event HkEntityHandler OnRigidBodyAdded;

		public event HkEntityHandler OnRigidBodyRemoved;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkWorld_Create([MarshalAs(UnmanagedType.I1)] bool enableGlobalGravity, float broadphaseCubeSideLength, float contactRestingVelocity, [MarshalAs(UnmanagedType.I1)] bool enableMultithreading, int solverIterations, BroadPhaseExitCallback broadPhaseCallback);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkWorld_CreateCInfo(ref CInfo cInfo, BroadPhaseExitCallback broadPhaseCallback);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkWorld_CreateBodyPairCollection();

		[DllImport("Havok.dll")]
		private static extern void HkWorld_RegisterWithJobQueue(IntPtr world, IntPtr jobQueue);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_Lock(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_Unlock(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_LockCriticalOperations(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_UnlockCriticalOperations(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_ExecutePendingCriticalOperations(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_StepDeltaTime(IntPtr world, float deltaTime);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_StepMultiThreaded(IntPtr world, IntPtr jobQueue, IntPtr threadPool, float deltaTime);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkWorld_InitMtStep(IntPtr world, IntPtr jobQueue, float deltaTime);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkWorld_FinishMtStep(IntPtr world, IntPtr jobQueue, IntPtr threadPool);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_ExecuteViolatedConstraintProjections(IntPtr world, IntPtr constraintListener, [MarshalAs(UnmanagedType.I1)] bool doProjections);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_ReportRuntimeDataConstraints(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_AddConstraint(IntPtr world, IntPtr constraint);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_RemoveConstraint(IntPtr world, IntPtr constraint);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_AddEntity(IntPtr world, IntPtr entity);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_RemoveEntity(IntPtr world, IntPtr entity);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_AddPhantom(IntPtr world, IntPtr phantom);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_RemovePhantom(IntPtr world, IntPtr phantom);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_AddPhysicsSystem(IntPtr world, IntPtr system);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_RemovePhysicsSystem(IntPtr world, IntPtr system);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_GetPenetrationsShape(IntPtr world, IntPtr bodyCollector, IntPtr shape, Vector3 translation, Quaternion rotation, int filter, ref HkManagedIntermediateBuffer.Native buffer);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_GetPenetrationsBox(IntPtr world, IntPtr bodyCollector, Vector3 halfExtents, Vector3 translation, Quaternion rotation, int filter, ref HkManagedIntermediateBuffer.Native buffer);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_GetPenetrationsShapeShape(IntPtr world, IntPtr bodyCollector, IntPtr shape1, Vector3 translation1, Quaternion rotation1, IntPtr shape2, Vector3 translation2, Quaternion rotation2, ref HkManagedIntermediateBuffer.Native buffer);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkWorld_IsPenetratingShapeShape(IntPtr world, IntPtr shape1, Vector3 translation1, Quaternion rotation1, IntPtr shape2, Vector3 translation2, Quaternion rotation2);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkWorld_IsPenetratingShapeShapeTransform(IntPtr world, IntPtr shape1, Matrix transform1, IntPtr shape2, Matrix transform2);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkWorld_CastShape(IntPtr world, Vector3 to, IntPtr shape, Matrix transform, int filterLayer, float extraPenetration, out float outResult);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkWorld_CastShapeReturnPoint(IntPtr world, Vector3 to, IntPtr shape, Matrix transform, int filterLayer, float extraPenetration, out Vector3 outPosition);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkWorld_CastShapeReturnContact(IntPtr world, Vector3 to, IntPtr shape, Matrix transform, int filterLayer, float extraPenetration, out IntPtr outPoint);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkWorld_CastShapeReturnContactData(IntPtr world, Vector3 to, IntPtr shape, Matrix transform, uint collisionFilterInfo, float extraPenetration, out Vector3 outPosition, out Vector3 outNormal, out float outDistance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkWorld_CastShapeReturnContactBodyData(IntPtr world, Vector3 to, IntPtr shape, Matrix transform, uint collisionFilterInfo, float extraPenetration, out HitInfo hitInfo);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkWorld_CastShapeReturnContactBodyDatas(IntPtr world, Vector3 to, IntPtr shape, Matrix transform, uint collisionFilterInfo, float extraPenetration, ref HkManagedIntermediateBuffer.Native buffer);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_CastRayAll(IntPtr world, Vector3 from, Vector3 to, int raycastFilterLayer, ref HkManagedIntermediateBuffer.Native buffer);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkWorld_CastRayCollisionFilter(IntPtr world, Vector3 from, Vector3 to, uint colllisionFilter, [MarshalAs(UnmanagedType.I1)] bool ignoreConvexShape, out float outConvexRadius, out HitInfo hitInfo);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkWorld_CastRayFilterLayer(IntPtr world, Vector3 from, Vector3 to, int raycastFilterLayer, [MarshalAs(UnmanagedType.I1)] bool useFilter, out HitInfo hitInfo);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_MarkForWrite(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_UnmarkForWrite(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_RefreshCollisionFilterOnEntity(IntPtr world, IntPtr entity);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_RefreshCollisionFilterOnWorld(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_ReintegrateEntity(IntPtr world, IntPtr entity);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_AddAction(IntPtr world, IntPtr action);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_RemoveAction(IntPtr world, IntPtr action);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkWorld_EnsureBatchSizes(IntPtr arr, out int size, int count, int newCount);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_SetBatchBody(IntPtr arr, int index, IntPtr body);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_AddEntityBatch(IntPtr world, IntPtr arr, int count);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_RemoveEntityBatch(IntPtr world, IntPtr arr, int count);

		[DllImport("Havok.dll")]
		private static extern int HkWorld_GetActiveSimulationIslandsCount(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern int HkWorld_GetActiveSimulationIslandEntities(IntPtr world, int islandIndex, out IntPtr entities);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_DeactivateSimulationIslandRigidBodies(IntPtr world, IntPtr rigidBody);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkWorld_IsActiveSimulationIsland(IntPtr world, IntPtr rigidBody);

		[DllImport("Havok.dll")]
		private static extern int HkWorld_GetConstraintCount(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern int HkWorld_GetActionCount(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkWorld_GetFixedBody(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_ReadSimulationIslandInfos(IntPtr world, ref HkManagedIntermediateBuffer.Native buffer);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkWorld_GetGravity(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_SetGravity(IntPtr world, Vector3 value);

		[DllImport("Havok.dll")]
		private static extern float HkWorld_GetDeactivationRotationSqrdA(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_SetDeactivationRotationSqrdA(IntPtr world, float value);

		[DllImport("Havok.dll")]
		private static extern float HkWorld_GetDeactivationRotationSqrdB(IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_SetDeactivationRotationSqrdB(IntPtr world, float value);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_AddWorldExtension(IntPtr world, IntPtr extension);

		[DllImport("Havok.dll")]
		private static extern void HkWorld_Release(IntPtr world, IntPtr filter, IntPtr penetrationHits, IntPtr addBatch, IntPtr removeBatch);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkPhysicsContext_Create();

		[DllImport("Havok.dll")]
		private static extern void HkPhysicsContext_RegisterAllPhysicsProcesses();

		[DllImport("Havok.dll")]
		private static extern void HkPhysicsContext_AddWorld(IntPtr physicsContext, IntPtr world);

		[DllImport("Havok.dll")]
		private static extern void HkPhysicsContext_RemoveWorld(IntPtr physicsContext, IntPtr world);

		[DllImport("Havok.dll")]
		private static extern int HkPhysicsContext_GetNumWorlds(IntPtr physicsContext);

		[DllImport("Havok.dll")]
		private static extern void HkPhysicsContext_SyncTimers(IntPtr physicsContext, IntPtr threadPool);

		[DllImport("Havok.dll")]
		private static extern void HkPhysicsContext_Release(IntPtr physicsContext);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkGroupFilter_Create(IntPtr world);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkGroupFilter_IsCollisionEnabled(IntPtr filter, uint colllinfo1, uint collinfo2);

		[DllImport("Havok.dll")]
		private static extern void HkGroupFilter_DisableCollisionsBetween(IntPtr filter, int layer1, int layer2);

		[DllImport("Havok.dll")]
		private static extern void HkGroupFilter_EnableCollisionsBetween(IntPtr filter, int layer1, int layer2);

		public HkWorld(bool enableGlobalGravity, float broadphaseCubeSideLength, float contactRestingVelocity, bool enableMultithreading, int solverIterations)
			: base(HkWorld_Create(enableGlobalGravity, broadphaseCubeSideLength, contactRestingVelocity, enableMultithreading, solverIterations, MaxPositionExceededDelegate), track: true)
		{
			m_enableMultithreading = enableMultithreading;
			Init();
		}

		public HkWorld(ref CInfo cInfo)
			: base(HkWorld_CreateCInfo(ref cInfo, MaxPositionExceededDelegate), track: true)
		{
			m_enableMultithreading = cInfo.SimulationType == SimulationType.SIMULATION_TYPE_MULTITHREADED;
			Init();
		}

		public void InitMultithreading(HkJobThreadPool threadPool, HkJobQueue jobQueue)
		{
			if (m_enableMultithreading)
			{
				m_threadPool = threadPool;
				m_jobQueue = jobQueue;
				HkWorld_RegisterWithJobQueue(base.NativeObject, m_jobQueue.NativeObject);
			}
		}

		public void Lock()
		{
			HkWorld_Lock(base.NativeObject);
		}

		public void Unlock()
		{
			HkWorld_Unlock(base.NativeObject);
		}

		public void LockCriticalOperations()
		{
			using (HkAccessControl.Write())
			{
				HkWorld_LockCriticalOperations(base.NativeObject);
			}
		}

		public void UnlockCriticalOperations()
		{
			using (HkAccessControl.Write())
			{
				HkWorld_UnlockCriticalOperations(base.NativeObject);
			}
		}

		public void ExecutePendingCriticalOperations()
		{
			using (HkAccessControl.Write(allowDuringStep: true))
			{
				HkWorld_ExecutePendingCriticalOperations(base.NativeObject);
			}
		}

		public void UnlockAndExecutePendingCriticalOperations()
		{
			using (HkAccessControl.Write())
			{
				Unlock();
				ExecutePendingCriticalOperations();
			}
		}

		public void StepSimulation(float deltaTime, bool multiThreaded)
		{
			m_timer.Restart();
			if (m_enableMultithreading && multiThreaded)
			{
				HkWorld_StepMultiThreaded(base.NativeObject, m_jobQueue.NativeObject, m_threadPool.NativeObject, deltaTime);
			}
			else
			{
				HkTaskProfiler.OnTaskStarted("HkStep", HkTaskType.Execute);
				HkWorld_StepDeltaTime(base.NativeObject, deltaTime);
				HkTaskProfiler.OnTaskFinished();
			}
			m_stepDuration = m_timer.Elapsed;
		}

		public bool InitMtStep(HkJobQueue jobQueue, float timeInSec)
		{
			return HkWorld_InitMtStep(m_handle, jobQueue.NativeObject, timeInSec);
		}

		public bool FinishMtStep(HkJobQueue jobQueue, HkJobThreadPool threadPool)
		{
			return HkWorld_FinishMtStep(m_handle, jobQueue.NativeObject, threadPool.NativeObject);
		}

		public void ExecuteViolatedConstraintProjections(bool doProjections)
		{
			if (m_constraintProjectorListener == null)
			{
				return;
			}
			using (HkAccessControl.Write())
			{
				HkWorld_ExecuteViolatedConstraintProjections(m_handle, m_constraintProjectorListener.NativeObject, doProjections);
			}
		}

		public void ReportRuntimeDataConstraints()
		{
			using (HkAccessControl.Write())
			{
				HkWorld_ReportRuntimeDataConstraints(m_handle);
			}
		}

		public void AddConstraint(HkConstraint constraint)
		{
			using (HkAccessControl.Write())
			{
				HkWorld_AddConstraint(base.NativeObject, constraint.NativeObject);
			}
		}

		public bool RemoveConstraint(HkConstraint constraint)
		{
			using (HkAccessControl.Write())
			{
				if (constraint.InWorld)
				{
					constraint.OnRemovedFromWorld();
					HkWorld_RemoveConstraint(base.NativeObject, constraint.NativeObject);
					return true;
				}
			}
			return false;
		}

		public void AddRigidBody(HkRigidBody rigidBody)
		{
			using (HkAccessControl.Write())
			{
				HkWorld_AddEntity(base.NativeObject, rigidBody.NativeObject);
				AddRigidBodyInternal(rigidBody);
			}
		}

		public void RemoveRigidBody(HkRigidBody rigidBody)
		{
			using (HkAccessControl.Write())
			{
				HkWorld_RemoveEntity(base.NativeObject, rigidBody.NativeObject);
				RemoveRigidBodyInternal(rigidBody);
			}
		}

		public void AddRigidBodyBatch(HkRigidBody rigidBody)
		{
			using (HkAccessControl.Write())
			{
				EnsureBatchSizes(m_addBatchCount + 1, m_removeBatchCount);
				HkWorld_SetBatchBody(m_addBatch, m_addBatchCount - 1, rigidBody.NativeObject);
				m_addBatchRB.Add(rigidBody);
			}
		}

		public void RemoveRigidBodyBatch(HkRigidBody rigidBody)
		{
			using (HkAccessControl.Write())
			{
				EnsureBatchSizes(m_addBatchCount, m_removeBatchCount + 1);
				HkWorld_SetBatchBody(m_removeBatch, m_removeBatchCount - 1, rigidBody.NativeObject);
				RemoveRigidBodyInternal(rigidBody);
			}
		}

		public void FinishBatch()
		{
			using (HkAccessControl.Write())
			{
				if (m_addBatchCount > 0)
				{
					Lock();
					HkWorld_AddEntityBatch(base.NativeObject, m_addBatch, m_addBatchCount);
					m_addBatchCount = 0;
					for (int i = 0; i < m_addBatchRB.Count; i++)
					{
						AddRigidBodyInternal(m_addBatchRB[i]);
					}
					m_addBatchRB.Clear();
					Unlock();
				}
				if (m_removeBatchCount > 0)
				{
					Lock();
					HkWorld_RemoveEntityBatch(base.NativeObject, m_removeBatch, m_removeBatchCount);
					m_removeBatchCount = 0;
					Unlock();
				}
			}
		}

		public void EnsureBatchSizes(int newAddCount, int newRemoveCount)
		{
			using (HkAccessControl.Write())
			{
				m_addBatch = HkWorld_EnsureBatchSizes(m_addBatch, out m_addBatchSize, newAddCount, m_addBatchCount);
				m_addBatchCount = newAddCount;
				m_removeBatch = HkWorld_EnsureBatchSizes(m_removeBatch, out m_removeBatchSize, newRemoveCount, m_removeBatchCount);
				m_removeBatchCount = newRemoveCount;
			}
		}

		public void AddPhantom(HkPhantom phantom)
		{
			using (HkAccessControl.Write())
			{
				HkWorld_AddPhantom(base.NativeObject, phantom.NativeObject);
			}
		}

		public void RemovePhantom(HkPhantom phantom)
		{
			using (HkAccessControl.Write())
			{
				HkWorld_RemovePhantom(base.NativeObject, phantom.NativeObject);
			}
		}

		public void AddCharacterRigidBody(HkCharacterRigidBody rigidBody)
		{
			using (HkAccessControl.Write())
			{
				HkWorld_AddEntity(base.NativeObject, rigidBody.GetHitRigidBody().NativeObject);
				m_characterRigidBodies.Add(rigidBody);
			}
		}

		public void RemoveCharacterRigidBody(HkCharacterRigidBody rigidBody)
		{
			using (HkAccessControl.Write())
			{
				HkWorld_RemoveEntity(base.NativeObject, rigidBody.GetHitRigidBody().NativeObject);
				m_characterRigidBodies.Remove(rigidBody);
			}
		}

		public void AddRagdoll(HkRagdoll ragdoll)
		{
			using (HkAccessControl.Write())
			{
				AddPhysicsSystem(ragdoll.PhysicsSystem);
				for (int i = 0; i < ragdoll.RigidBodies.Count; i++)
				{
					m_rigidBodies.Add(ragdoll.RigidBodies[i]);
				}
			}
		}

		public void RemoveRagdoll(HkRagdoll ragdoll)
		{
			using (HkAccessControl.Write())
			{
				for (int i = 0; i < ragdoll.RigidBodies.Count; i++)
				{
					if (ragdoll.RigidBodies[i] != null)
					{
						m_rigidBodies.Remove(ragdoll.RigidBodies[i]);
					}
				}
				if (ragdoll.PhysicsSystem != IntPtr.Zero)
				{
					RemovePhysicsSystem(ragdoll.PhysicsSystem);
				}
			}
		}

		public unsafe void GetPenetrationsShape(HkShape shape, ref Vector3 translation, ref Quaternion rotation, List<HkBodyCollision> results, int filter)
		{
			using (HkAccessControl.Read())
			{
				Lock();
				try
				{
					byte* buffer = stackalloc byte[(int)(uint)PenetrationBufferSize];
					HkManagedIntermediateBuffer hkManagedIntermediateBuffer = new HkManagedIntermediateBuffer(buffer, PenetrationBufferSize);
					HkWorld_GetPenetrationsShape(base.NativeObject, m_penetrationHits, shape.NativeObject, translation, rotation, filter, ref hkManagedIntermediateBuffer.NativeToken);
					Span<BodyCollision> span = hkManagedIntermediateBuffer.AsSpan<BodyCollision>();
					HkBodyCollision item = default(HkBodyCollision);
					for (int i = 0; i < span.Length; i++)
					{
						item.Body = HkRigidBody.Get(span[i].Body);
						item.ShapeKey = span[i].ShapeKey;
						results.Add(item);
					}
					hkManagedIntermediateBuffer.Dispose();
				}
				finally
				{
					Unlock();
				}
			}
		}

		public unsafe void GetPenetrationsBox(ref Vector3 halfExtents, ref Vector3 translation, ref Quaternion rotation, List<HkBodyCollision> results, int filter)
		{
			using (HkAccessControl.Read())
			{
				Lock();
				try
				{
					byte* buffer = stackalloc byte[(int)(uint)PenetrationBufferSize];
					HkManagedIntermediateBuffer hkManagedIntermediateBuffer = new HkManagedIntermediateBuffer(buffer, PenetrationBufferSize);
					HkWorld_GetPenetrationsBox(base.NativeObject, m_penetrationHits, halfExtents, translation, rotation, filter, ref hkManagedIntermediateBuffer.NativeToken);
					Span<BodyCollision> span = hkManagedIntermediateBuffer.AsSpan<BodyCollision>();
					HkBodyCollision item = default(HkBodyCollision);
					for (int i = 0; i < span.Length; i++)
					{
						item.Body = HkRigidBody.Get(span[i].Body);
						item.ShapeKey = span[i].ShapeKey;
						results.Add(item);
					}
					hkManagedIntermediateBuffer.Dispose();
				}
				finally
				{
					Unlock();
				}
			}
		}

		public unsafe void GetPenetrationsShapeShape(HkShape shape1, ref Vector3 translation1, ref Quaternion rotation1, HkShape shape2, ref Vector3 translation2, ref Quaternion rotation2, List<HkShapeCollision> results)
		{
			using (HkAccessControl.Read())
			{
				Lock();
				try
				{
					byte* buffer = stackalloc byte[(int)(uint)ShapeShapeBufferSize];
					HkManagedIntermediateBuffer hkManagedIntermediateBuffer = new HkManagedIntermediateBuffer(buffer, ShapeShapeBufferSize);
					HkWorld_GetPenetrationsShapeShape(base.NativeObject, m_penetrationHits, shape1.NativeObject, translation1, rotation1, shape2.NativeObject, translation2, rotation2, ref hkManagedIntermediateBuffer.NativeToken);
					Span<HkShapeCollision> span = hkManagedIntermediateBuffer.AsSpan<HkShapeCollision>();
					for (int i = 0; i < span.Length; i++)
					{
						results.Add(span[i]);
					}
					hkManagedIntermediateBuffer.Dispose();
				}
				finally
				{
					Unlock();
				}
			}
		}

		public bool IsPenetratingShapeShape(HkShape shape1, ref Vector3 translation1, ref Quaternion rotation1, HkShape shape2, ref Vector3 translation2, ref Quaternion rotation2)
		{
			using (HkAccessControl.Read())
			{
				Lock();
				try
				{
					return HkWorld_IsPenetratingShapeShape(base.NativeObject, shape1.NativeObject, translation1, rotation1, shape2.NativeObject, translation2, rotation2);
				}
				finally
				{
					Unlock();
				}
			}
		}

		public bool IsPenetratingShapeShape(HkShape shape1, ref Matrix transform1, HkShape shape2, ref Matrix transform2)
		{
			using (HkAccessControl.Read())
			{
				Lock();
				try
				{
					return HkWorld_IsPenetratingShapeShapeTransform(base.NativeObject, shape1.NativeObject, transform1, shape2.NativeObject, transform2);
				}
				finally
				{
					Unlock();
				}
			}
		}

		public float? CastShape(Vector3 to, HkShape shape, Matrix transform, int filterLayer)
		{
			using (HkAccessControl.Read())
			{
				return CastShape(to, shape, ref transform, filterLayer, 0.05f);
			}
		}

		public float? CastShape(Vector3 to, HkShape shape, ref Matrix transform, int filterLayer, float extraPenetration)
		{
			using (HkAccessControl.Read())
			{
				if (HkWorld_CastShape(base.NativeObject, to, shape.NativeObject, transform, filterLayer, extraPenetration, out var outResult))
				{
					return outResult;
				}
				return null;
			}
		}

		public Vector3? CastShapeReturnPoint(Vector3 to, HkShape shape, ref Matrix transform, int filterLayer, float extraPenetration)
		{
			using (HkAccessControl.Read())
			{
				if (HkWorld_CastShapeReturnPoint(base.NativeObject, to, shape.NativeObject, transform, filterLayer, extraPenetration, out var outPosition))
				{
					return outPosition;
				}
				return null;
			}
		}

		public HkContactPoint? CastShapeReturnContact(Vector3 to, HkShape shape, ref Matrix transform, int filterLayer, float extraPenetration)
		{
			using (HkAccessControl.Read())
			{
				if (HkWorld_CastShapeReturnContact(base.NativeObject, to, shape.NativeObject, transform, filterLayer, extraPenetration, out var outPoint))
				{
					return new HkContactPoint(outPoint);
				}
				return null;
			}
		}

		public HkContactPointData? CastShapeReturnContactData(Vector3 to, HkShape shape, ref Matrix transform, uint collisionFilterInfo, float extraPenetration)
		{
			using (HkAccessControl.Read())
			{
				if (HkWorld_CastShapeReturnContactData(base.NativeObject, to, shape.NativeObject, transform, collisionFilterInfo, extraPenetration, out var outPosition, out var outNormal, out var outDistance))
				{
					HkContactPointData value = default(HkContactPointData);
					value.HitPosition = outPosition;
					value.Normal = outNormal;
					value.DistanceFraction = outDistance;
					return value;
				}
				return null;
			}
		}

		public HkHitInfo? CastShapeReturnContactBodyData(Vector3 to, HkShape shape, ref Matrix transform, uint collisionFilterInfo, float extraPenetration)
		{
			using (HkAccessControl.Read())
			{
				if (HkWorld_CastShapeReturnContactBodyData(base.NativeObject, to, shape.NativeObject, transform, collisionFilterInfo, extraPenetration, out var hitInfo))
				{
					return new HkHitInfo(in hitInfo);
				}
				return null;
			}
		}

		public unsafe bool CastShapeReturnContactBodyDatas(Vector3 to, HkShape shape, ref Matrix transform, uint collisionFilterInfo, float extraPenetration, List<HkHitInfo?> result)
		{
			using (HkAccessControl.Read())
			{
				byte* buffer = stackalloc byte[(int)(uint)RayCastResultBufferSize];
				HkManagedIntermediateBuffer hkManagedIntermediateBuffer = new HkManagedIntermediateBuffer(buffer, RayCastResultBufferSize);
				bool result2 = HkWorld_CastShapeReturnContactBodyDatas(base.NativeObject, to, shape.NativeObject, transform, collisionFilterInfo, extraPenetration, ref hkManagedIntermediateBuffer.NativeToken);
				Span<HitInfo> span = hkManagedIntermediateBuffer.AsSpan<HitInfo>();
				for (int i = 0; i < span.Length; i++)
				{
					result.Add(new HkHitInfo(in span[i]));
				}
				hkManagedIntermediateBuffer.Dispose();
				return result2;
			}
		}

		public void CastRay(Vector3 from, Vector3 to, List<HkHitInfo> toList)
		{
			CastRay(from, to, toList, 0);
		}

		public unsafe void CastRay(Vector3 from, Vector3 to, List<HkHitInfo> toList, int raycastFilterLayer)
		{
			using (HkAccessControl.Read())
			{
				toList.Clear();
				Lock();
				try
				{
					byte* buffer = stackalloc byte[(int)(uint)RayCastResultBufferSize];
					HkManagedIntermediateBuffer hkManagedIntermediateBuffer = new HkManagedIntermediateBuffer(buffer, RayCastResultBufferSize);
					HkWorld_CastRayAll(base.NativeObject, from, to, raycastFilterLayer, ref hkManagedIntermediateBuffer.NativeToken);
					Span<HitInfo> span = hkManagedIntermediateBuffer.AsSpan<HitInfo>();
					for (int i = 0; i < span.Length; i++)
					{
						toList.Add(new HkHitInfo(in span[i]));
					}
					hkManagedIntermediateBuffer.Dispose();
				}
				finally
				{
					Unlock();
				}
			}
		}

		public HkHitInfo? CastRay(Vector3 from, Vector3 to)
		{
			return CastRay(from, to, 0, useFilter: false);
		}

		public HkHitInfo? CastRay(Vector3 from, Vector3 to, int rayCastFilterLayer)
		{
			return CastRay(from, to, rayCastFilterLayer, useFilter: true);
		}

		private HkHitInfo? CastRay(Vector3 from, Vector3 to, int rayCastFilterLayer, bool useFilter)
		{
			using (HkAccessControl.Read())
			{
				Lock();
				try
				{
					if (HkWorld_CastRayFilterLayer(base.NativeObject, from, to, rayCastFilterLayer, useFilter, out var hitInfo))
					{
						return new HkHitInfo(in hitInfo);
					}
				}
				finally
				{
					Unlock();
				}
				return null;
			}
		}

		public bool CastRay(Vector3 from, Vector3 to, out HkHitInfo info, uint collisionFilter, bool ignoreConvexShape)
		{
			using (HkAccessControl.Read())
			{
				Lock();
				try
				{
					if (HkWorld_CastRayCollisionFilter(base.NativeObject, from, to, collisionFilter, ignoreConvexShape, out var outConvexRadius, out var hitInfo))
					{
						info = new HkHitInfo(in hitInfo);
						if (ignoreConvexShape)
						{
							Vector3 vector = to - from;
							vector.Normalize();
							float num = Vector3.Dot(hitInfo.Normal, -vector);
							info.Position += vector * outConvexRadius * num;
						}
						return true;
					}
				}
				finally
				{
					Unlock();
				}
				info = default(HkHitInfo);
				return false;
			}
		}

		public bool IsCollisionEnabled(uint colllinfo1, uint collinfo2)
		{
			using (HkAccessControl.Read())
			{
				return HkGroupFilter_IsCollisionEnabled(m_filter, colllinfo1, collinfo2);
			}
		}

		public void MarkForWrite()
		{
			HkWorld_MarkForWrite(base.NativeObject);
		}

		public void UnmarkForWrite()
		{
			HkWorld_UnmarkForWrite(base.NativeObject);
		}

		public HkGroupFilter GetCollisionFilter()
		{
			using (HkAccessControl.Read())
			{
				return new HkGroupFilter(m_filter);
			}
		}

		public void DisableCollisionsBetween(int layer1, int layer2)
		{
			HkGroupFilter_DisableCollisionsBetween(m_filter, layer1, layer2);
		}

		public void EnableCollisionsBetween(int layer1, int layer2)
		{
			using (HkAccessControl.Write())
			{
				HkGroupFilter_EnableCollisionsBetween(m_filter, layer1, layer2);
			}
		}

		public void RefreshCollisionFilterOnEntity(HkEntity entity)
		{
			using (HkAccessControl.Write())
			{
				HkWorld_RefreshCollisionFilterOnEntity(base.NativeObject, entity.NativeObject);
			}
		}

		public void RefreshCollisionFilterOnWorld()
		{
			using (HkAccessControl.Write())
			{
				HkWorld_RefreshCollisionFilterOnWorld(base.NativeObject);
			}
		}

		public void ReintegrateCharacter(HkCharacterRigidBody character)
		{
			using (HkAccessControl.Write())
			{
				HkWorld_ReintegrateEntity(base.NativeObject, character.GetHitRigidBody().NativeObject);
			}
		}

		public void ReintegrateEntity(HkEntity entity)
		{
			using (HkAccessControl.Write())
			{
				HkWorld_ReintegrateEntity(base.NativeObject, entity.NativeObject);
			}
		}

		public void AddAction(HkAction action)
		{
			using (HkAccessControl.Write())
			{
				HkWorld_AddAction(base.NativeObject, action.NativeObject);
			}
		}

		public void RemoveAction(HkAction action)
		{
			using (HkAccessControl.Write())
			{
				HkWorld_RemoveAction(base.NativeObject, action.NativeObject);
			}
		}

		public int GetActiveSimulationIslandsCount()
		{
			using (HkAccessControl.Read())
			{
				return HkWorld_GetActiveSimulationIslandsCount(base.NativeObject);
			}
		}

		public unsafe void GetActiveSimulationIslandRigidBodies(int islandIndex, List<HkRigidBody> rigidBodies)
		{
			using (HkAccessControl.Read())
			{
				IntPtr entities;
				int num = HkWorld_GetActiveSimulationIslandEntities(base.NativeObject, islandIndex, out entities);
				void** ptr = (void**)entities.ToPointer();
				for (int i = 0; i < num; i++)
				{
					HkRigidBody hkRigidBody = HkRigidBody.Get(new IntPtr(ptr[i]));
					if (hkRigidBody != null)
					{
						rigidBodies.Add(hkRigidBody);
					}
				}
			}
		}

		public void DeactivateSimulationIslandRigidBodies(HkRigidBody rigidBody)
		{
			using (HkAccessControl.Write())
			{
				HkWorld_DeactivateSimulationIslandRigidBodies(base.NativeObject, rigidBody.NativeObject);
			}
		}

		public bool IsActiveSimulationIsland(HkRigidBody rigidBody)
		{
			using (HkAccessControl.Read())
			{
				return HkWorld_IsActiveSimulationIsland(base.NativeObject, rigidBody.NativeObject);
			}
		}

		public int GetConstraintCount()
		{
			using (HkAccessControl.Read())
			{
				return HkWorld_GetConstraintCount(base.NativeObject);
			}
		}

		public int GetActionCount()
		{
			using (HkAccessControl.Read())
			{
				return HkWorld_GetActionCount(base.NativeObject);
			}
		}

		public HkRigidBody GetFixedBody()
		{
			using (HkAccessControl.Read())
			{
				return HkRigidBody.Get(HkWorld_GetFixedBody(base.NativeObject));
			}
		}

		public void RigidBodyActivated(HkEntity entity)
		{
			m_activeRigidBodies.Add((HkRigidBody)entity);
			m_activeBodiesVersion++;
			this.OnRigidBodyActivated?.Invoke(entity);
		}

		private void RigidBodyDeactivated(HkEntity entity)
		{
			this.OnRigidBodyDeactivated?.Invoke(entity);
			m_activeRigidBodies.Remove((HkRigidBody)entity);
			m_activeBodiesVersion++;
		}

		internal void RaiseEntityLeft(HkEntity entity)
		{
			this.EntityLeftWorld?.Invoke(entity);
		}

		internal void AddRigidBodyInternal(HkRigidBody rigidBody)
		{
			using (HkAccessControl.Write())
			{
				m_rigidBodies.Add(rigidBody);
				rigidBody.Activated += RigidBodyActivated;
				rigidBody.Deactivated += RigidBodyDeactivated;
				this.OnRigidBodyAdded?.Invoke(rigidBody);
				if (rigidBody.IsActive && !rigidBody.IsFixedOrKeyframed)
				{
					rigidBody.OnActivated();
				}
				rigidBody.AddGravity();
			}
		}

		internal void RemoveRigidBodyInternal(HkRigidBody rigidBody)
		{
			using (HkAccessControl.Write())
			{
				rigidBody.Activated -= RigidBodyActivated;
				rigidBody.Deactivated -= RigidBodyDeactivated;
				m_rigidBodies.Remove(rigidBody);
				m_activeRigidBodies.Remove(rigidBody);
				m_activeBodiesVersion++;
				this.OnRigidBodyRemoved?.Invoke(rigidBody);
			}
		}

		internal void AddPhysicsSystem(IntPtr system)
		{
			using (HkAccessControl.Write())
			{
				Lock();
				HkWorld_AddPhysicsSystem(base.NativeObject, system);
				Unlock();
			}
		}

		internal void RemovePhysicsSystem(IntPtr system)
		{
			using (HkAccessControl.Write())
			{
				Lock();
				HkWorld_RemovePhysicsSystem(base.NativeObject, system);
				Unlock();
			}
		}

		public unsafe void ReadSimulationIslandInfos(List<HkSimulationIslandInfo> infoOut)
		{
			using (HkAccessControl.Read())
			{
				byte* buffer = stackalloc byte[(int)(uint)SimulationIslandBufferSize];
				HkManagedIntermediateBuffer hkManagedIntermediateBuffer = new HkManagedIntermediateBuffer(buffer, SimulationIslandBufferSize);
				HkWorld_ReadSimulationIslandInfos(base.NativeObject, ref hkManagedIntermediateBuffer.NativeToken);
				Span<HkSimulationIslandInfo> span = hkManagedIntermediateBuffer.AsSpan<HkSimulationIslandInfo>();
				for (int i = 0; i < span.Length; i++)
				{
					infoOut.Add(span[i]);
				}
				hkManagedIntermediateBuffer.Dispose();
			}
		}

		protected override void Dispose(bool disposing)
		{
			using (HkAccessControl.Write())
			{
				if (m_constraintProjectorListener != null)
				{
					m_constraintProjectorListener.Dispose();
					m_constraintProjectorListener = null;
				}
				m_breakOffUtil?.Dispose();
				HkWorld_Release(base.NativeObject, m_filter, m_penetrationHits, m_addBatch, m_removeBatch);
			}
		}

		private void Init()
		{
			MarkForWrite();
			m_timer = Stopwatch.StartNew();
			m_rigidBodies = new List<HkRigidBody>();
			m_characterRigidBodies = new List<HkCharacterRigidBody>();
			m_activeRigidBodies = new HashSet<HkRigidBody>();
			m_activeBodiesVersion = 0;
			m_addBatchRB = new List<HkRigidBody>();
			m_filter = HkGroupFilter_Create(base.NativeObject);
			m_penetrationHits = HkWorld_CreateBodyPairCollection();
			m_removeBatchSize = 0;
			m_removeBatchCount = 0;
			m_addBatchCount = 0;
			m_addBatchSize = 0;
			m_addBatch = IntPtr.Zero;
			m_removeBatch = IntPtr.Zero;
			EnsureBatchSizes(128, 128);
			m_addBatchCount = 0;
			m_removeBatchCount = 0;
			m_jobQueue = null;
			m_threadPool = null;
			UnmarkForWrite();
		}

		[MonoPInvokeCallback(typeof(BroadPhaseExitCallback))]
		private static void OnMaxPositionExceeded(IntPtr worldHandle, IntPtr body)
		{
			if (HkHandle.TryGetHandle<HkWorld>(worldHandle, out var handle))
			{
				HkRigidBody entity = HkRigidBody.Get(body);
				handle.RaiseEntityLeft(entity);
			}
		}

		public List<HkRigidBody> GetActiveRigidBodiesCache(out int worldVersion, out bool cacheValid)
		{
			using (HkAccessControl.Write())
			{
				worldVersion = m_activeBodiesVersion;
				if (m_activeRigidBodiesCache == null)
				{
					cacheValid = false;
					int count = m_activeRigidBodies.Count;
					int capacity = ((count > 100) ? count : 100);
					m_activeRigidBodiesCache = new List<HkRigidBody>(capacity);
				}
				else
				{
					cacheValid = worldVersion == m_activeCacheBodiesVersion;
				}
				return m_activeRigidBodiesCache;
			}
		}

		public void UpdateActiveRigidBodiesCache(List<HkRigidBody> activeRigidBodyCache, int cacheVersion)
		{
			using (HkAccessControl.Write())
			{
				m_activeCacheBodiesVersion = cacheVersion;
				m_activeRigidBodiesCache = activeRigidBodyCache;
			}
		}
	}
	public abstract class HkPhantom : HkReferenceObject
	{
		protected HkPhantom(IntPtr referenceObj, bool track = false)
			: base(referenceObj, track)
		{
		}
	}
	public class HkpAabbPhantom : HkPhantom
	{
		internal delegate void CollidableAddedD(IntPtr phantomHandle, IntPtr e);

		internal delegate void CollidableRemovedD(IntPtr phantomHandle, IntPtr e);

		public CollidableRemovedDelegate CollidableRemoved;

		public CollidableAddedDelegate CollidableAdded;

		private static readonly CollidableAddedD CollidableAddedDHolder = OnCollidableAddedD;

		private static readonly CollidableRemovedD CollidableRemovedDHolder = OnCollidableRemovedD;

		public BoundingBox Aabb
		{
			get
			{
				HkpAabbPhantom_GetAabb(base.NativeObject, out var min, out var max);
				return new BoundingBox(min, max);
			}
			set
			{
				HkpAabbPhantom_SetAabb(base.NativeObject, value.Min, value.Max);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkpAabbPhantom_Create(Vector3 min, Vector3 max, uint collisionFilterInfo, CollidableAddedD collidableAddedD, CollidableRemovedD collidableRemovedD);

		[DllImport("Havok.dll")]
		private static extern void HkpAabbPhantom_GetAabb(IntPtr instance, out Vector3 min, out Vector3 max);

		[DllImport("Havok.dll")]
		private static extern void HkpAabbPhantom_SetAabb(IntPtr instance, Vector3 min, Vector3 max);

		[DllImport("Havok.dll")]
		private static extern void HkpAabbPhantom_Release(IntPtr instance);

		public HkpAabbPhantom(BoundingBox aabb, uint collisionFilterInfo)
			: base(HkpAabbPhantom_Create(aabb.Min, aabb.Max, collisionFilterInfo, CollidableAddedDHolder, CollidableRemovedDHolder), track: true)
		{
		}

		protected override void Dispose(bool A_0)
		{
			HkpAabbPhantom_Release(base.NativeObject);
		}

		[MonoPInvokeCallback(typeof(CollidableAddedD))]
		private static void OnCollidableAddedD(IntPtr phantomHandle, IntPtr e)
		{
			if (HkHandle.TryGetHandle<HkpAabbPhantom>(phantomHandle, out var handle))
			{
				HkpCollidableAddedEvent e2 = new HkpCollidableAddedEvent(e);
				handle.CollidableAdded?.Invoke(ref e2);
			}
		}

		[MonoPInvokeCallback(typeof(CollidableRemovedD))]
		private static void OnCollidableRemovedD(IntPtr phantomHandle, IntPtr e)
		{
			if (HkHandle.TryGetHandle<HkpAabbPhantom>(phantomHandle, out var handle))
			{
				HkpCollidableRemovedEvent e2 = new HkpCollidableRemovedEvent(e);
				handle.CollidableRemoved?.Invoke(ref e2);
			}
		}
	}
	public delegate void CollidableAddedDelegate(ref HkpCollidableAddedEvent e);
	public delegate void CollidableRemovedDelegate(ref HkpCollidableRemovedEvent e);
	public struct HkpCollidableAddedEvent
	{
		private readonly IntPtr m_handle;

		public HkRigidBody RigidBody
		{
			get
			{
				IntPtr bodyHandle = HkpCollidableAddedEvent_GetRigidBody(m_handle);
				return HkRigidBody.Get(bodyHandle);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkpCollidableAddedEvent_GetRigidBody(IntPtr instance);

		internal HkpCollidableAddedEvent(IntPtr ptr)
		{
			m_handle = ptr;
		}
	}
	public struct HkpCollidableRemovedEvent
	{
		private readonly IntPtr m_handle;

		public HkRigidBody RigidBody
		{
			get
			{
				IntPtr bodyHandle = HkpCollidableRemovedEvent_GetRigidBody(m_handle);
				return HkRigidBody.Get(bodyHandle);
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkpCollidableRemovedEvent_GetRigidBody(IntPtr instance);

		internal HkpCollidableRemovedEvent(IntPtr ptr)
		{
			m_handle = ptr;
		}
	}
	public class HkpShapePhantom : HkPhantom
	{
		[DllImport("Havok.dll")]
		private static extern void HkSimpleShapePhantom_SetTransform(IntPtr instance, Matrix matrix);

		public void SetTransform(Matrix matrix)
		{
			HkSimpleShapePhantom_SetTransform(base.NativeObject, matrix);
		}

		internal HkpShapePhantom(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	public class HkSimpleShapePhantom : HkpShapePhantom
	{
		public HkShape Shape => new HkShape(HkSimpleShapePhantom_GetShape(base.NativeObject));

		[DllImport("Havok.dll")]
		private static extern IntPtr HkSimpleShapePhantom_Create(IntPtr shape);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkSimpleShapePhantom_CreateWithLayer(IntPtr shape, int layer);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkSimpleShapePhantom_GetShape(IntPtr instance);

		public HkSimpleShapePhantom()
			: base(IntPtr.Zero)
		{
		}

		public HkSimpleShapePhantom(HkShape shape)
			: base(HkSimpleShapePhantom_Create(shape.NativeObject))
		{
		}

		public HkSimpleShapePhantom(HkShape shape, int layer)
			: base(HkSimpleShapePhantom_CreateWithLayer(shape.NativeObject, layer))
		{
		}

		internal HkSimpleShapePhantom(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	[DebuggerDisplay("{Name}")]
	public class RagdollBone
	{
		public readonly string Name;

		public int m_rigidBodyIndex;

		public RagdollBone m_parent;

		public List<RagdollBone> m_children;

		public RagdollBone(HkRigidBody rigidBody)
		{
			Name = rigidBody.GetNativeObjectName();
		}
	}
	public class HkRagdoll : IDisposable
	{
		private enum ConstraintDataType
		{
			Ragdoll,
			Hinge,
			LimitedHinge
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct ConstraintInfo
		{
			public IntPtr Constraint;

			public IntPtr ConstraintData;

			public ConstraintDataType DataType;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct BodyInfo
		{
			public IntPtr RigidBody;

			public IntPtr Shape;
		}

		public Action<HkRagdoll> AddedToWorld;

		public Action<HkRagdoll> RemovedFromWorld;

		public Action<HkRagdoll> Deleted;

		public RagdollBone m_ragdollTree;

		public string Name;

		private static int m_instancesCounter;

		private IntPtr m_ragdollPhysicsSystem;

		private HkEntityListener m_entityListener;

		private int m_collisionLayer;

		private int m_systemGroup;

		private int m_firstSubsystemId;

		private Matrix m_worldMatrix;

		private Matrix m_worldMatrixInverted;

		private List<HkShape> m_shapes;

		private List<HkRigidBody> m_rigidBodies;

		private List<HkConstraintData> m_ragdollConstraintsData;

		private List<HkConstraint> m_constraints;

		private List<Matrix> m_rigPoseTransfroms;

		private List<Matrix> m_localTransforms;

		private int[] m_childToParent;

		private List<int> m_palmFootIndices;

		private float m_maxLinearVelocity;

		private float m_maxAngularVelocity;

		private Matrix m_originTransform;

		private bool m_keyframed;

		private bool m_lastBodyAdded;

		private bool m_lastConstraintAdded;

		private int m_bodiesInWorld;

		private int m_constraintsInWorld;

		public float Mass
		{
			get
			{
				float num = 0f;
				for (int i = 0; i < m_rigidBodies.Count; i++)
				{
					num += m_rigidBodies[i].Mass;
				}
				return num;
			}
		}

		public List<HkRigidBody> RigidBodies => m_rigidBodies;

		public bool ConstraintsEnabled
		{
			get
			{
				if (m_constraints == null)
				{
					return false;
				}
				if (m_constraints.Count < 1)
				{
					return false;
				}
				bool flag = true;
				for (int i = 0; i < m_constraints.Count; i++)
				{
					flag = m_constraints[i].Enabled && flag;
				}
				return flag;
			}
		}

		public List<Matrix> RigTransforms => m_rigPoseTransfroms;

		public List<Matrix> LocalTransforms => m_localTransforms;

		public List<HkConstraintData> RagdollConstraintsData => m_ragdollConstraintsData;

		public List<HkConstraint> Constraints => m_constraints;

		public List<HkShape> Shapes => m_shapes;

		public Matrix WorldMatrix => m_worldMatrix;

		public Matrix WorldMatrixInverted => m_worldMatrixInverted;

		public bool IsActive
		{
			get
			{
				return HkPhysicsSystem_IsActive(m_ragdollPhysicsSystem);
			}
			set
			{
				if (value)
				{
					Activate();
				}
				else
				{
					Deactivate();
				}
			}
		}

		public bool InWorld
		{
			get
			{
				if (m_lastBodyAdded)
				{
					return m_lastConstraintAdded;
				}
				return false;
			}
		}

		public int Layer
		{
			get
			{
				return m_collisionLayer;
			}
			set
			{
				m_collisionLayer = value;
				GenerateRigidBodiesCollisionFilters(m_collisionLayer, m_systemGroup, m_firstSubsystemId);
			}
		}

		public bool IsKeyframed => m_keyframed;

		public bool IsSimulationActive
		{
			get
			{
				bool flag = false;
				if (RigidBodies == null)
				{
					return false;
				}
				if (!InWorld)
				{
					return false;
				}
				for (int i = 0; i < RigidBodies.Count; i++)
				{
					flag = flag || RigidBodies[i].IsActive;
				}
				return flag;
			}
		}

		public float MaxLinearVelocity => m_maxLinearVelocity;

		public float MaxAngularVelocity => m_maxAngularVelocity;

		internal IntPtr PhysicsSystem => m_ragdollPhysicsSystem;

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkPhysicsSystem_IsActive(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkPhysicsSystem_SetActive(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport("Havok.dll")]
		private static extern void HkPhysicsSystem_RecreateConstraints(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkPhysicsSystem_GetConstraintDataFromSystem(IntPtr instance, ref HkManagedIntermediateBuffer.Native constraintBuffer);

		[DllImport("Havok.dll", CharSet = CharSet.Ansi)]
		private static extern IntPtr HkPhysicsSystem_GetName(IntPtr instance);

		[DllImport("Havok.dll", CharSet = CharSet.Ansi)]
		private static extern IntPtr HkPhysicsSystem_LoadRagdollFromFile(string fileName);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkPhysicsSystem_LoadRagdollFromBuffer(byte[] buffer, int length);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkPhysicsSystem_InitFromData(IntPtr loadedData, out IntPtr physicsSystem, ref HkManagedIntermediateBuffer.Native bodyBuffer);

		[DllImport("Havok.dll")]
		private static extern uint HkpGroupFilter_CalcFilterInfo(int layer, int systemGroup, int subSystemId, int subSystemDontCollideWith);

		[DllImport("Havok.dll")]
		private static extern uint HkpGroupFilter_CalcFilterInfoFromCurrent(uint currentInfo, int collisionLayer);

		[DllImport("Havok.dll")]
		private static extern void HkpInertiaTensorComputer_OptimizeInertiasOfConstraintTree(IntPtr[] constraints, int size, IntPtr rigidBody);

		[DllImport("Havok.dll")]
		private static extern void HkPhysicsSystem_Release(IntPtr physicsSystem);

		public HkRagdoll()
		{
			m_shapes = new List<HkShape>();
			m_rigidBodies = new List<HkRigidBody>();
			m_ragdollConstraintsData = new List<HkConstraintData>();
			m_constraints = new List<HkConstraint>();
			m_rigPoseTransfroms = new List<Matrix>();
			m_localTransforms = new List<Matrix>();
			m_palmFootIndices = new List<int>();
			m_collisionLayer = 0;
			m_systemGroup = 0;
			m_firstSubsystemId = 0;
			m_worldMatrix = Matrix.Identity;
			m_worldMatrixInverted = Matrix.Identity;
			m_ragdollPhysicsSystem = IntPtr.Zero;
			m_keyframed = false;
			Name = $"Ragdoll({m_instancesCounter})()";
			m_instancesCounter++;
			m_entityListener = new HkEntityListener(OnBodyAddedToWorld, OnBodyRemovedFromWorld);
		}

		public HkRigidBody FindRigidBody(string name)
		{
			return m_rigidBodies.Find((HkRigidBody item) => string.Compare(item.GetNativeObjectName(), name) == 0);
		}

		public int FindRigidBodyIndex(string name)
		{
			return m_rigidBodies.FindIndex((HkRigidBody item) => string.Compare(item.GetNativeObjectName(), name) == 0);
		}

		public void GenerateRigidBodiesCollisionFilters(int ragdollCollisionLayer, int ragdollSystemGroup, int startSubsystemIdsFrom)
		{
			m_collisionLayer = ragdollCollisionLayer;
			m_systemGroup = ragdollSystemGroup;
			m_firstSubsystemId = startSubsystemIdsFrom;
			for (int i = 0; i < m_rigidBodies.Count; i++)
			{
				if (m_rigidBodies[i] != null)
				{
					HkRigidBody hkRigidBody = m_rigidBodies[i];
					int num = m_childToParent[i];
					uint collisionFilterInfo = HkpGroupFilter_CalcFilterInfo(m_collisionLayer, m_systemGroup, i + m_firstSubsystemId, num + m_firstSubsystemId);
					hkRigidBody.Layer = m_collisionLayer;
					hkRigidBody.SetCollisionFilterInfo(collisionFilterInfo);
				}
			}
		}

		public void SetWorldMatrix(Matrix world, bool updateOnlyKeyframed, bool updateVelocities)
		{
			m_worldMatrix = world;
			Matrix.Invert(ref m_worldMatrix, out m_worldMatrixInverted);
			SetTransforms(updateOnlyKeyframed, updateVelocities);
		}

		public void SetWorldMatrix(Matrix world)
		{
			SetWorldMatrix(world, updateOnlyKeyframed: false, updateVelocities: true);
		}

		public void OptimizeInertiasOfConstraintTree()
		{
			IntPtr[] array = new IntPtr[m_constraints.Count];
			for (int i = 0; i < m_constraints.Count; i++)
			{
				array[i] = m_constraints[i].NativeObject;
			}
			HkpInertiaTensorComputer_OptimizeInertiasOfConstraintTree(array, m_constraints.Count, m_rigidBodies[0].NativeObject);
		}

		public Matrix GetRigidBodyLocalTransform(int rigidBodyIndex)
		{
			if (m_rigidBodies[rigidBodyIndex] == null)
			{
				return Matrix.Identity;
			}
			m_rigidBodies[rigidBodyIndex].GetRigidBodyMatrix(out Matrix matrix);
			return matrix * m_worldMatrixInverted;
		}

		public void GetRigidBodyLocalTransform(int rigidBodyIndex, out Matrix transform)
		{
			if (m_rigidBodies[rigidBodyIndex] == null)
			{
				transform = Matrix.Identity;
				return;
			}
			Matrix rigidBodyMatrix = m_rigidBodies[rigidBodyIndex].GetRigidBodyMatrix();
			Matrix matrix = (transform = rigidBodyMatrix * m_worldMatrixInverted);
		}

		public void SetRigidBodyLocalTransform(int rigidBodyIndex, Matrix localTransform)
		{
			m_localTransforms[rigidBodyIndex] = localTransform;
			if (!(m_rigidBodies[rigidBodyIndex] == null))
			{
				Matrix.Multiply(ref localTransform, ref m_worldMatrix, out var result);
				m_rigidBodies[rigidBodyIndex].SetWorldMatrix(result);
			}
		}

		public void UpdateWorldMatrixAfterSimulation()
		{
			if (m_rigidBodies != null && !(m_rigidBodies[0] == null))
			{
				m_rigidBodies[m_ragdollTree.m_rigidBodyIndex].GetRigidBodyMatrix(out Matrix matrix);
				Matrix.Multiply(ref m_originTransform, ref matrix, out m_worldMatrix);
				Matrix.Invert(ref m_worldMatrix, out m_worldMatrixInverted);
			}
		}

		public void Activate()
		{
			for (int i = 0; i < m_rigidBodies.Count; i++)
			{
				if (m_rigidBodies[i] != null)
				{
					m_rigidBodies[i].Activate();
				}
			}
			HkPhysicsSystem_SetActive(m_ragdollPhysicsSystem, value: true);
		}

		public void Deactivate()
		{
			for (int i = 0; i < m_rigidBodies.Count; i++)
			{
				if (m_rigidBodies[i] != null)
				{
					m_rigidBodies[i].RequestDeactivation();
				}
			}
			HkPhysicsSystem_SetActive(m_ragdollPhysicsSystem, value: false);
		}

		public void EnableConstraints()
		{
			for (int i = 0; i < m_constraints.Count; i++)
			{
				if (m_constraints[i] != null)
				{
					m_constraints[i].Enabled = true;
				}
			}
		}

		public void DisableConstraints()
		{
			for (int i = 0; i < m_constraints.Count; i++)
			{
				if (m_constraints[i] != null)
				{
					m_constraints[i].Enabled = false;
				}
			}
		}

		public void SetToKeyframed()
		{
			for (int i = 0; i < m_rigidBodies.Count; i++)
			{
				SetToKeyframed(i);
			}
			m_keyframed = true;
		}

		public void SetToKeyframed(int rigidBodyIndex)
		{
			if (m_rigidBodies[rigidBodyIndex] != null)
			{
				m_rigidBodies[rigidBodyIndex].UpdateMotionType(HkMotionType.Keyframed);
			}
		}

		public void SetToDynamic()
		{
			for (int i = 0; i < m_rigidBodies.Count; i++)
			{
				SetToDynamic(i);
			}
			m_keyframed = false;
		}

		public void SetToDynamic(int rigidBodyIndex)
		{
			if (m_rigidBodies[rigidBodyIndex] != null)
			{
				m_rigidBodies[rigidBodyIndex].UpdateMotionType(HkMotionType.Dynamic);
			}
		}

		public bool LoadRagdollFromFile(string fileName)
		{
			IntPtr intPtr = HkPhysicsSystem_LoadRagdollFromFile(fileName);
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			return InitFromData(intPtr);
		}

		public bool LoadRagdollFromBuffer(byte[] buffer)
		{
			IntPtr intPtr = HkPhysicsSystem_LoadRagdollFromBuffer(buffer, buffer.Length);
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			return InitFromData(intPtr);
		}

		public void SwitchRigidBodyToLayer(int rigidBodyIndex, int collisionLayer)
		{
			if (!(m_rigidBodies[rigidBodyIndex] == null))
			{
				HkRigidBody hkRigidBody = m_rigidBodies[rigidBodyIndex];
				if (!(hkRigidBody == null))
				{
					uint collisionFilterInfo = hkRigidBody.GetCollisionFilterInfo();
					m_rigidBodies[rigidBodyIndex].Layer = collisionLayer;
					uint collisionFilterInfo2 = HkpGroupFilter_CalcFilterInfoFromCurrent(collisionFilterInfo, collisionLayer);
					hkRigidBody.SetCollisionFilterInfo(collisionFilterInfo2);
				}
			}
		}

		public void SwitchToLayer(int collisionLayer)
		{
			for (int i = 0; i < m_rigidBodies.Count; i++)
			{
				SwitchRigidBodyToLayer(i, collisionLayer);
			}
		}

		public bool SetRootBody(string bodyName)
		{
			int num = FindRigidBodyIndex(bodyName);
			if (num < 0 || num >= m_rigidBodies.Count)
			{
				return false;
			}
			m_ragdollTree = new RagdollBone(m_rigidBodies[num]);
			m_ragdollTree.m_rigidBodyIndex = num;
			m_ragdollTree.m_parent = null;
			GenerateTreeRecursion(m_ragdollTree);
			return true;
		}

		public void ResetToRigPose()
		{
			if (RigTransforms == null || RigidBodies == null)
			{
				return;
			}
			m_worldMatrixInverted = (m_worldMatrix = Matrix.Identity);
			for (int i = 0; i < RigidBodies.Count; i++)
			{
				if (RigidBodies[i] != null)
				{
					RigidBodies[i].SetWorldMatrix(RigTransforms[i]);
				}
				m_localTransforms[i] = RigTransforms[i];
			}
		}

		public HkRigidBody GetRootRigidBody()
		{
			if (RigidBodies == null)
			{
				return null;
			}
			if (m_ragdollTree == null)
			{
				return null;
			}
			return RigidBodies[m_ragdollTree.m_rigidBodyIndex];
		}

		public void UpdateLocalTransforms()
		{
			for (int i = 0; i < m_rigidBodies.Count; i++)
			{
				m_localTransforms[i] = GetRigidBodyLocalTransform(i);
			}
		}

		public void ForceDeactivate()
		{
			for (int i = 0; i < m_rigidBodies.Count; i++)
			{
				if (m_rigidBodies[i] != null)
				{
					m_rigidBodies[i].RequestDeactivation();
				}
			}
			HkPhysicsSystem_SetActive(m_ragdollPhysicsSystem, value: false);
		}

		public void ResetVelocities()
		{
			if (RigidBodies == null)
			{
				return;
			}
			for (int i = 0; i < RigidBodies.Count; i++)
			{
				if (RigidBodies[i] != null)
				{
					RigidBodies[i].AngularVelocity = Vector3.Zero;
					RigidBodies[i].LinearVelocity = Vector3.Zero;
				}
			}
		}

		public override string ToString()
		{
			return $"HkRagdoll{Name}";
		}

		public void RecreateConstraints()
		{
			HkPhysicsSystem_RecreateConstraints(m_ragdollPhysicsSystem);
			m_constraints.Clear();
			m_ragdollConstraintsData.Clear();
			GetConstraintDataFromSystem(m_ragdollPhysicsSystem);
		}

		public bool IsRigidBodyPalmOrFoot(int rigidBodyIdx)
		{
			for (int i = 0; i < m_palmFootIndices.Count; i++)
			{
				if (m_palmFootIndices[i] == rigidBodyIdx)
				{
					return true;
				}
			}
			return false;
		}

		public void setupPalmOrFootIndices()
		{
			for (int i = 0; i < m_rigidBodies.Count; i++)
			{
				if (string.Compare("Ragdoll_SE_rig_RPalm001", m_rigidBodies[i].GetNativeObjectName()) == 0)
				{
					m_palmFootIndices.Add(i);
				}
				if (string.Compare("Ragdoll_SE_rig_LPalm001", m_rigidBodies[i].GetNativeObjectName()) == 0)
				{
					m_palmFootIndices.Add(i);
				}
				if (string.Compare("Ragdoll_SE_rig_RFoot001", m_rigidBodies[i].GetNativeObjectName()) == 0)
				{
					m_palmFootIndices.Add(i);
				}
				if (string.Compare("Ragdoll_SE_rig_LFoot001", m_rigidBodies[i].GetNativeObjectName()) == 0)
				{
					m_palmFootIndices.Add(i);
				}
				if (string.Compare("Ragdoll_SE_rig_LForearm001", m_rigidBodies[i].GetNativeObjectName()) == 0)
				{
					m_palmFootIndices.Add(i);
				}
				if (string.Compare("Ragdoll_SE_rig_RForearm001", m_rigidBodies[i].GetNativeObjectName()) == 0)
				{
					m_palmFootIndices.Add(i);
				}
				if (string.Compare("Ragdoll_SE_rig_LCalf001", m_rigidBodies[i].GetNativeObjectName()) == 0)
				{
					m_palmFootIndices.Add(i);
				}
				if (string.Compare("Ragdoll_SE_rig_RCalf001", m_rigidBodies[i].GetNativeObjectName()) == 0)
				{
					m_palmFootIndices.Add(i);
				}
			}
		}

		internal unsafe bool InitFromData(IntPtr resource)
		{
			m_ragdollConstraintsData.Clear();
			m_constraints.Clear();
			m_shapes.Clear();
			m_rigidBodies.Clear();
			m_rigPoseTransfroms.Clear();
			m_localTransforms.Clear();
			m_palmFootIndices.Clear();
			int num = 50 * sizeof(BodyInfo);
			byte* buffer = stackalloc byte[(int)(uint)num];
			HkManagedIntermediateBuffer hkManagedIntermediateBuffer = new HkManagedIntermediateBuffer(buffer, num);
			if (!HkPhysicsSystem_InitFromData(resource, out m_ragdollPhysicsSystem, ref hkManagedIntermediateBuffer.NativeToken))
			{
				return false;
			}
			Span<BodyInfo> span = hkManagedIntermediateBuffer.AsSpan<BodyInfo>();
			for (int i = 0; i < span.Length; i++)
			{
				HkRigidBody hkRigidBody = new HkRigidBody(span[i].RigidBody);
				m_rigidBodies.Add(hkRigidBody);
				hkRigidBody.GetRigidBodyMatrix(out Matrix matrix);
				m_rigPoseTransfroms.Add(matrix);
				m_localTransforms.Add(matrix);
				hkRigidBody.AddEntityListener(m_entityListener);
				if (m_rigidBodies.Count == 1)
				{
					m_maxLinearVelocity = hkRigidBody.MaxLinearVelocity;
					m_maxAngularVelocity = hkRigidBody.MaxAngularVelocity;
				}
				m_shapes.Add(new HkShape(span[i].Shape));
			}
			hkManagedIntermediateBuffer.Dispose();
			GetConstraintDataFromSystem(m_ragdollPhysicsSystem);
			generateRagdollTree();
			m_rigidBodies[m_ragdollTree.m_rigidBodyIndex].GetRigidBodyMatrix(out m_originTransform);
			Matrix.Invert(ref m_originTransform, out m_originTransform);
			m_childToParent = new int[m_rigidBodies.Count];
			GenerateCollisionSubIds(m_ragdollTree);
			Name = $"Ragdoll({m_instancesCounter})({Marshal.PtrToStringAnsi(HkPhysicsSystem_GetName(m_ragdollPhysicsSystem))})";
			return true;
		}

		public void Dispose()
		{
			if (m_constraints != null)
			{
				for (int i = 0; i < m_constraints.Count; i++)
				{
					if (m_constraints[i] != null)
					{
						m_constraints[i].Dispose();
						m_constraints[i] = null;
					}
				}
			}
			m_constraints = null;
			if (m_shapes != null)
			{
				for (int j = 0; j < m_shapes.Count; j++)
				{
					if (m_shapes[j].IsValid)
					{
						m_shapes[j].RemoveReference();
					}
				}
			}
			m_shapes = null;
			if (m_rigidBodies != null)
			{
				for (int k = 0; k < m_rigidBodies.Count; k++)
				{
					if (m_rigidBodies[k] != null)
					{
						m_rigidBodies[k].Dispose();
						m_rigidBodies[k] = null;
					}
				}
			}
			m_rigidBodies = null;
			HkPhysicsSystem_Release(m_ragdollPhysicsSystem);
			m_entityListener.Dispose();
			OnDeleted();
		}

		private int findRootBodyIndex()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>(m_rigidBodies.Count);
			for (int i = 0; i < m_rigidBodies.Count; i++)
			{
				dictionary.Add(i, 0);
			}
			int num = 0;
			int result = 0;
			for (int j = 0; j < m_constraints.Count; j++)
			{
				HkConstraint hkConstraint = m_constraints[j];
				int num2 = m_rigidBodies.IndexOf(hkConstraint.RigidBodyA);
				int num3 = m_rigidBodies.IndexOf(hkConstraint.RigidBodyB);
				dictionary[num3]++;
				dictionary[num2]++;
				if (dictionary[num3] > num)
				{
					num = dictionary[num3];
					result = num3;
				}
				if (dictionary[num2] > num)
				{
					num = dictionary[num2];
					result = num2;
				}
			}
			return result;
		}

		private void generateRagdollTree()
		{
			int num = findRootBodyIndex();
			m_ragdollTree = new RagdollBone(m_rigidBodies[num]);
			m_ragdollTree.m_rigidBodyIndex = num;
			m_ragdollTree.m_parent = null;
			GenerateTreeRecursion(m_ragdollTree);
		}

		private void GenerateTreeRecursion(RagdollBone bone)
		{
			List<int> bodiesAttachedTo = GetBodiesAttachedTo(bone.m_rigidBodyIndex);
			if (bone.m_parent != null && bodiesAttachedTo.Contains(bone.m_parent.m_rigidBodyIndex))
			{
				bodiesAttachedTo.Remove(bone.m_parent.m_rigidBodyIndex);
			}
			bone.m_children = new List<RagdollBone>();
			for (int i = 0; i < bodiesAttachedTo.Count; i++)
			{
				RagdollBone ragdollBone = new RagdollBone(m_rigidBodies[bodiesAttachedTo[i]])
				{
					m_parent = bone,
					m_rigidBodyIndex = bodiesAttachedTo[i]
				};
				bone.m_children.Add(ragdollBone);
				GenerateTreeRecursion(ragdollBone);
			}
		}

		private List<int> GetBodiesAttachedTo(int rigidBodyIndex)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < m_constraints.Count; i++)
			{
				if (m_constraints[i] != null)
				{
					HkConstraint hkConstraint = m_constraints[i];
					int num = m_rigidBodies.IndexOf(hkConstraint.RigidBodyA);
					int num2 = m_rigidBodies.IndexOf(hkConstraint.RigidBodyB);
					if (num == rigidBodyIndex)
					{
						list.Add(num2);
					}
					else if (num2 == rigidBodyIndex)
					{
						list.Add(num);
					}
				}
			}
			return list;
		}

		private void GenerateCollisionSubIds(RagdollBone rootBone)
		{
			int num = 0;
			if (rootBone != null)
			{
				if (rootBone.m_parent != null)
				{
					num = rootBone.m_parent.m_rigidBodyIndex;
				}
				m_childToParent[rootBone.m_rigidBodyIndex] = num;
				for (int i = 0; i < rootBone.m_children.Count; i++)
				{
					GenerateCollisionSubIds(rootBone.m_children[i]);
				}
			}
		}

		private void GetConstraintDataFromSystem(IntPtr m_ragdollPhysicsSystem)
		{
			Span<ConstraintInfo> span = stackalloc ConstraintInfo[50];
			HkManagedIntermediateBuffer hkManagedIntermediateBuffer = HkManagedIntermediateBuffer.Create(span);
			HkPhysicsSystem_GetConstraintDataFromSystem(m_ragdollPhysicsSystem, ref hkManagedIntermediateBuffer.NativeToken);
			Span<ConstraintInfo> span2 = hkManagedIntermediateBuffer.AsSpan<ConstraintInfo>();
			for (int i = 0; i < span2.Length; i++)
			{
				ConstraintDataType dataType = span2[i].DataType;
				IntPtr constraintData = span2[i].ConstraintData;
				IntPtr constraint = span2[i].Constraint;
				HkConstraint hkConstraint;
				switch (dataType)
				{
				default:
					return;
				case ConstraintDataType.Ragdoll:
				{
					HkRagdollConstraintData hkRagdollConstraintData = new HkRagdollConstraintData(constraintData);
					hkRagdollConstraintData.MaxFrictionTorque = 3f;
					m_ragdollConstraintsData.Add(hkRagdollConstraintData);
					hkConstraint = new HkConstraint(constraint, hkRagdollConstraintData);
					break;
				}
				case ConstraintDataType.Hinge:
				{
					HkHingeConstraintData hkHingeConstraintData = new HkHingeConstraintData(constraintData);
					m_ragdollConstraintsData.Add(hkHingeConstraintData);
					hkConstraint = new HkConstraint(constraint, hkHingeConstraintData);
					break;
				}
				case ConstraintDataType.LimitedHinge:
				{
					HkLimitedHingeConstraintData hkLimitedHingeConstraintData = new HkLimitedHingeConstraintData(constraintData);
					hkLimitedHingeConstraintData.MaxFrictionTorque = 3f;
					m_ragdollConstraintsData.Add(hkLimitedHingeConstraintData);
					hkConstraint = new HkConstraint(constraint, hkLimitedHingeConstraintData);
					break;
				}
				}
				HkConstraint hkConstraint2 = hkConstraint;
				hkConstraint2.OnAddedToWorldCallback = (Action)Delegate.Combine(hkConstraint2.OnAddedToWorldCallback, new Action(OnConstraintAddedToWorld));
				HkConstraint hkConstraint3 = hkConstraint;
				hkConstraint3.OnRemovedFromWorldCallback = (Action)Delegate.Combine(hkConstraint3.OnRemovedFromWorldCallback, new Action(OnConstraintRemovedFromWorld));
				m_constraints.Add(hkConstraint);
			}
			hkManagedIntermediateBuffer.Dispose();
		}

		private void OnAddedToWorld()
		{
			AddedToWorld?.Invoke(this);
		}

		private void OnRemovedFromWorld()
		{
			RemovedFromWorld?.Invoke(this);
		}

		private void OnDeleted()
		{
			Deleted?.Invoke(this);
		}

		private void OnBodyAddedToWorld(HkEntity hkEntity)
		{
			m_bodiesInWorld++;
			if (m_bodiesInWorld == m_rigidBodies.Count)
			{
				m_lastBodyAdded = true;
			}
			if (m_lastBodyAdded && m_lastConstraintAdded)
			{
				OnAddedToWorld();
			}
		}

		private void OnBodyRemovedFromWorld(HkEntity hkEntity)
		{
			m_lastBodyAdded = false;
			m_bodiesInWorld--;
			if (m_constraintsInWorld == 0 && m_bodiesInWorld == 0)
			{
				OnRemovedFromWorld();
			}
		}

		private void OnConstraintAddedToWorld()
		{
			m_constraintsInWorld++;
			if (m_constraintsInWorld == m_constraints.Count)
			{
				m_lastConstraintAdded = true;
			}
			if (m_lastBodyAdded && m_lastConstraintAdded)
			{
				OnAddedToWorld();
			}
		}

		private void OnConstraintRemovedFromWorld()
		{
			m_lastConstraintAdded = false;
			m_constraintsInWorld--;
			if (m_constraintsInWorld == 0 && m_bodiesInWorld == 0)
			{
				OnRemovedFromWorld();
			}
		}

		private void SetTransforms(bool updateOnlyKeyframed, bool updateVelocities)
		{
			for (int i = 0; i < m_rigidBodies.Count; i++)
			{
				if (m_rigidBodies[i] != null && (m_rigidBodies[i].IsFixedOrKeyframed || !updateOnlyKeyframed))
				{
					SetRigidBodyLocalTransform(i, m_localTransforms[i]);
					if (updateVelocities)
					{
						Vector3 angularVelocity = m_rigidBodies[i].AngularVelocity;
						Vector3 linearVelocity = m_rigidBodies[i].LinearVelocity;
						m_rigidBodies[i].AngularVelocity = angularVelocity;
						m_rigidBodies[i].LinearVelocity = linearVelocity;
					}
				}
			}
			int rigidBodyIndex = m_ragdollTree.m_rigidBodyIndex;
			Matrix matrix = m_localTransforms[rigidBodyIndex];
			Matrix.Invert(ref matrix, out m_originTransform);
		}
	}
	public class HkRagdollConstraintData : HkConstraintData
	{
		private Vector3 m_twistAxisA;

		private Vector3 m_planeAxisA;

		private Vector3 m_twistAxisB;

		private Vector3 m_planeAxisB;

		private Vector3 m_pivotA;

		private Vector3 m_pivotB;

		public float PlaneMinAngularLimit
		{
			get
			{
				return HkRagdollConstraintData_GetPlaneMinAngularLimit(base.NativeObject);
			}
			set
			{
				HkRagdollConstraintData_SetPlaneMinAngularLimit(base.NativeObject, value);
			}
		}

		public float PlaneMaxAngularLimit
		{
			get
			{
				return HkRagdollConstraintData_GetPlaneMaxAngularLimit(base.NativeObject);
			}
			set
			{
				HkRagdollConstraintData_SetPlaneMaxAngularLimit(base.NativeObject, value);
			}
		}

		public float TwistMinAngularLimit
		{
			get
			{
				return HkRagdollConstraintData_GetTwistMinAngularLimit(base.NativeObject);
			}
			set
			{
				HkRagdollConstraintData_SetTwistMinAngularLimit(base.NativeObject, value);
			}
		}

		public float TwistMaxAngularLimit
		{
			get
			{
				return HkRagdollConstraintData_GetTwistMaxAngularLimit(base.NativeObject);
			}
			set
			{
				HkRagdollConstraintData_SetTwistMaxAngularLimit(base.NativeObject, value);
			}
		}

		public float MaxFrictionTorque
		{
			get
			{
				return HkRagdollConstraintData_GetMaxFrictionTorque(base.NativeObject);
			}
			set
			{
				HkRagdollConstraintData_SetMaxFrictionTorque(base.NativeObject, value);
			}
		}

		[DllImport("Havok.dll")]
		private static extern float HkRagdollConstraintData_GetPlaneMinAngularLimit(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRagdollConstraintData_SetPlaneMinAngularLimit(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRagdollConstraintData_GetPlaneMaxAngularLimit(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRagdollConstraintData_SetPlaneMaxAngularLimit(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRagdollConstraintData_GetTwistMinAngularLimit(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRagdollConstraintData_SetTwistMinAngularLimit(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRagdollConstraintData_GetTwistMaxAngularLimit(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRagdollConstraintData_SetTwistMaxAngularLimit(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkRagdollConstraintData_GetMaxFrictionTorque(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkRagdollConstraintData_SetMaxFrictionTorque(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern void HkRagdollConstraintData_SetInBodySpaceInternal(IntPtr instance, Vector3 pivotA, Vector3 pivotB, Vector3 planeAxisA, Vector3 planeAxisB, Vector3 twistAxisA, Vector3 twistAxisB);

		[DllImport("Havok.dll")]
		private static extern void HkRagdollConstraintData_SetAsymmetricConeAngle(IntPtr instance, float coneMin, float coneMax);

		[DllImport("Havok.dll")]
		private static extern void HkRagdollConstraintData_SetConeLimitStabilization(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool enable);

		public void SetInBodySpaceInternal(Vector3 pivotA, Vector3 pivotB, Vector3 planeAxisA, Vector3 planeAxisB, Vector3 twistAxisA, Vector3 twistAxisB)
		{
			m_pivotA = pivotA;
			m_pivotB = pivotB;
			m_planeAxisA = planeAxisA;
			m_planeAxisB = planeAxisB;
			m_twistAxisA = twistAxisA;
			m_twistAxisB = twistAxisB;
			HkRagdollConstraintData_SetInBodySpaceInternal(base.NativeObject, m_pivotA, m_pivotB, m_planeAxisA, m_planeAxisB, m_twistAxisA, m_twistAxisB);
		}

		public void SetAsymmetricConeAngle(float coneMin, float coneMax)
		{
			HkRagdollConstraintData_SetAsymmetricConeAngle(base.NativeObject, coneMin, coneMax);
		}

		public void SetConeLimitStabilization(bool enable)
		{
			HkRagdollConstraintData_SetConeLimitStabilization(base.NativeObject, enable);
		}

		internal HkRagdollConstraintData(IntPtr data)
		{
			m_handle = data;
			HkReferenceObject.HkReferenceObject_AddReference(m_handle);
		}
	}
	public struct HkBoxShape
	{
		public HkShape Base;

		public Vector3 HalfExtents
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkBoxShape_GetHalfExtents(Base.NativeObject);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkBoxShape_SetHalfExtents(Base.NativeObject, value);
				}
			}
		}

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkBoxShape_Create(Vector3 halfExtents);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkBoxShape_CreateWithConvexRadius(Vector3 halfExtents, float convexRadius);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkBoxShape_GetShapeFromCompoundShape(IntPtr shape, int shapeIndex);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkBoxShape_GetHalfExtents(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkBoxShape_SetHalfExtents(IntPtr instance, Vector3 value);

		public HkBoxShape(Vector3 halfExtents)
		{
			Base = new HkShape(HkBoxShape_Create(halfExtents));
		}

		public HkBoxShape(Vector3 halfExtents, float convexRadius)
		{
			Base = new HkShape(HkBoxShape_CreateWithConvexRadius(halfExtents, convexRadius));
		}

		public HkBoxShape(string fileName, int shapeIndex)
		{
			Base = new HkShape(HkBoxShape_GetShapeFromCompoundShape(HkShape.LoadShapeFromFile(fileName), shapeIndex));
		}

		public static implicit operator HkShape(HkBoxShape shape)
		{
			return shape.Base;
		}

		public static implicit operator HkConvexShape(HkBoxShape shape)
		{
			return new HkConvexShape(shape.NativeObject);
		}

		public static explicit operator HkBoxShape(HkConvexShape shape)
		{
			return new HkBoxShape(shape.NativeObject);
		}

		public static explicit operator HkBoxShape(HkShape shape)
		{
			return new HkBoxShape(shape.NativeObject);
		}

		internal HkBoxShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkBvCompressedMeshShape
	{
		public enum PerPrimitiveDataMode
		{
			PER_PRIMITIVE_DATA_NONE,
			PER_PRIMITIVE_DATA_8_BIT,
			PER_PRIMITIVE_DATA_PALETTE,
			PER_PRIMITIVE_DATA_STRING_PALETTE
		}

		public HkShape Base;

		public bool IsZero => Base.IsZero;

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkBvCompressedMeshShape_CreateWithSimpleMesh(IntPtr simpleMeshShape);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkBvCompressedMeshShape_CreateWithParams(IntPtr geometry, int sCount, IntPtr shapes, int tCount, IntPtr transforms, int weldingType, int dataMode, [MarshalAs(UnmanagedType.I1)] bool isWithConvexRadius, float convexRadius);

		[DllImport("Havok.dll")]
		private unsafe static extern IntPtr HkBvCompressedMeshShape_CreateUnsafe(Vector3* vertices, int verticesCount, int* indices, int indicesCount, byte* materials, int materialsCount, int weldingType, float convexRadius);

		[DllImport("Havok.dll")]
		private static extern void HkBvCompressedMeshShape_GetGeometry(IntPtr instance, IntPtr geometry);

		[DllImport("Havok.dll")]
		private static extern uint HkBvCompressedMeshShape_GetUserData(IntPtr instance, uint shapeKey);

		public HkBvCompressedMeshShape(HkSimpleMeshShape simpleMesh)
		{
			Base = new HkShape(HkBvCompressedMeshShape_CreateWithSimpleMesh(simpleMesh.NativeObject));
		}

		public unsafe HkBvCompressedMeshShape(HkGeometry geometry, Span<HkConvexShape> shapes, Span<Matrix> transforms, PerPrimitiveDataMode materialDataMode, HkWeldingType weldingType)
		{
			fixed (HkConvexShape* value = shapes)
			{
				fixed (Matrix* value2 = transforms)
				{
					Base = new HkShape(HkBvCompressedMeshShape_CreateWithParams(geometry.NativeObject, shapes.Length, new IntPtr(value), transforms.Length, new IntPtr(value2), (int)weldingType, (int)materialDataMode, isWithConvexRadius: false, 0f));
				}
			}
		}

		public unsafe HkBvCompressedMeshShape(HkGeometry geometry, Span<HkConvexShape> shapes, Span<Matrix> transforms, HkWeldingType weldingType, PerPrimitiveDataMode materialDataMode, float? convexRadius)
		{
			fixed (HkConvexShape* value = shapes)
			{
				fixed (Matrix* value2 = transforms)
				{
					Base = new HkShape(HkBvCompressedMeshShape_CreateWithParams(geometry.NativeObject, shapes.Length, new IntPtr(value), transforms.Length, new IntPtr(value2), (int)weldingType, (int)materialDataMode, convexRadius.HasValue, convexRadius ?? 0f));
				}
			}
		}

		public unsafe HkBvCompressedMeshShape(Vector3* vertices, int verticesCount, int* indices, int indicesCount, byte* materials, int materialsCount, HkWeldingType weldingType, float convexRadius)
		{
			Base = new HkShape(HkBvCompressedMeshShape_CreateUnsafe(vertices, verticesCount, indices, indicesCount, materials, materialsCount, (int)weldingType, convexRadius));
		}

		public void GetGeometry(HkGeometry result)
		{
			using (HkAccessControl.Read(this))
			{
				HkBvCompressedMeshShape_GetGeometry(NativeObject, result.NativeObject);
			}
		}

		public HkShapeContainerIterator GetIterator(HkShapeBuffer buffer)
		{
			using (HkAccessControl.Read(this))
			{
				return ((HkShape)this).GetContainerWithBuffer(buffer);
			}
		}

		public uint GetUserData(uint shapeKey)
		{
			using (HkAccessControl.Read(this))
			{
				return HkBvCompressedMeshShape_GetUserData(NativeObject, shapeKey);
			}
		}

		public static implicit operator HkShape(HkBvCompressedMeshShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static explicit operator HkBvCompressedMeshShape(HkShape shape)
		{
			return new HkBvCompressedMeshShape(shape.NativeObject);
		}

		internal HkBvCompressedMeshShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkBvShape
	{
		public HkShape Base;

		public HkShape ChildShape
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					IntPtr shape = HkBvShape_GetChildShape(NativeObject);
					return new HkShape(shape);
				}
			}
		}

		public HkShape BoundingVolumeShape
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					IntPtr shape = HkBvShape_GetBoundingVolumeShape(NativeObject);
					return new HkShape(shape);
				}
			}
		}

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkBvShape_Create(IntPtr boundingVolumeShape, IntPtr childShape);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkBvShape_GetChildShape(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkBvShape_GetBoundingVolumeShape(IntPtr instance);

		public HkBvShape(HkShape boundingVolumeShape, HkShape childShape, HkReferencePolicy policy)
		{
			Base = new HkShape(HkBvShape_Create(boundingVolumeShape.NativeObject, childShape.NativeObject));
			if (policy == HkReferencePolicy.TakeOwnership)
			{
				boundingVolumeShape.RemoveReference();
				childShape.RemoveReference();
			}
		}

		public static implicit operator HkShape(HkBvShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static explicit operator HkBvShape(HkShape shape)
		{
			return new HkBvShape(shape.NativeObject);
		}

		internal HkBvShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkBvTreeShape
	{
		public HkShape Base;

		internal IntPtr NativeObject => Base.NativeObject;

		public HkShapeContainerIterator GetIterator(HkShapeBuffer buffer)
		{
			using (HkAccessControl.Read(this))
			{
				return ((HkShape)this).GetContainerWithBuffer(buffer);
			}
		}

		public static implicit operator HkShape(HkBvTreeShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static explicit operator HkBvTreeShape(HkShape shape)
		{
			return new HkBvTreeShape(shape.NativeObject);
		}

		internal HkBvTreeShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkCapsuleShape
	{
		public HkShape Base;

		public float Radius
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkCapsuleShape_GetRadius(NativeObject);
				}
			}
		}

		public Vector3 VertexB
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkCapsuleShape_GetVertexB(NativeObject);
				}
			}
		}

		public Vector3 VertexA
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkCapsuleShape_GetVertexA(NativeObject);
				}
			}
		}

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkCapsuleShape_Create(Vector3 vertexA, Vector3 vertexB, float radius);

		[DllImport("Havok.dll")]
		private static extern float HkCapsuleShape_GetRadius(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCapsuleShape_GetVertexB(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCapsuleShape_GetVertexA(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCapsuleShape_GetCentre(IntPtr instance);

		public HkCapsuleShape(Vector3 vertexA, Vector3 vertexB, float radius)
		{
			Base = new HkShape(HkCapsuleShape_Create(vertexA, vertexB, radius));
		}

		public Vector3 GetCenter()
		{
			using (HkAccessControl.Read(this))
			{
				return HkCapsuleShape_GetCentre(NativeObject);
			}
		}

		public static implicit operator HkShape(HkCapsuleShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static implicit operator HkConvexShape(HkCapsuleShape shape)
		{
			return new HkConvexShape(shape.NativeObject);
		}

		public static explicit operator HkCapsuleShape(HkConvexShape shape)
		{
			return new HkCapsuleShape(shape.NativeObject);
		}

		public static explicit operator HkCapsuleShape(HkShape shape)
		{
			return new HkCapsuleShape(shape.NativeObject);
		}

		internal HkCapsuleShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkConvexShape
	{
		public static readonly float DefaultConvexRadius = HkConvexShape_GetDefaultConvexRadius();

		public HkShape Base;

		internal IntPtr NativeObject => Base.NativeObject;

		public float ConvexRadius
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkConvexShape_GetConvexRadius(NativeObject);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkConvexShape_SetConvexRadius(NativeObject, value);
				}
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkConvexShape_GetConvexShapeFromCompoundShape(IntPtr shape, int shapeIndex);

		[DllImport("Havok.dll")]
		private static extern float HkConvexShape_GetConvexRadius(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkConvexShape_SetConvexRadius(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern float HkConvexShape_GetDefaultConvexRadius();

		public HkConvexShape(string fileName, int shapeIndex)
		{
			Base = new HkShape(HkConvexShape_GetConvexShapeFromCompoundShape(HkShape.LoadShapeFromFile(fileName), shapeIndex));
		}

		public static implicit operator HkShape(HkConvexShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static explicit operator HkConvexShape(HkShape shape)
		{
			return new HkConvexShape(shape.NativeObject);
		}

		internal HkConvexShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkConvexTransformShape
	{
		public HkShape Base;

		public Matrix Transform
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkConvexTransformShape_GetTransform(NativeObject);
				}
			}
		}

		public HkConvexShape ChildShape
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					IntPtr ptr = HkConvexTransformShape_GetChildShape(NativeObject);
					return new HkConvexShape(ptr);
				}
			}
		}

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkConvexTransformShape_Create(IntPtr childShape, Matrix transform, int refPolicy);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkConvexTransformShape_CreateTranslated(IntPtr childShape, Vector3 translation, Quaternion rotation, Vector3 scale, int refPolicy);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkConvexTransformShape_GetChildShape(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Matrix HkConvexTransformShape_GetTransform(IntPtr instance);

		public HkConvexTransformShape(HkConvexShape childShape, ref Matrix transform, HkReferencePolicy policy)
		{
			Base = new HkShape(HkConvexTransformShape_Create(childShape.NativeObject, transform, (int)policy));
		}

		public HkConvexTransformShape(HkConvexShape childShape, ref Vector3 translation, ref Quaternion rotation, ref Vector3 scale, HkReferencePolicy policy)
		{
			Base = new HkShape(HkConvexTransformShape_CreateTranslated(childShape.NativeObject, translation, rotation, scale, (int)policy));
		}

		public static implicit operator HkShape(HkConvexTransformShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static implicit operator HkConvexShape(HkConvexTransformShape shape)
		{
			return new HkConvexShape(shape.NativeObject);
		}

		public static explicit operator HkConvexTransformShape(HkConvexShape shape)
		{
			return new HkConvexTransformShape(shape.NativeObject);
		}

		public static explicit operator HkConvexTransformShape(HkShape shape)
		{
			return new HkConvexTransformShape(shape.NativeObject);
		}

		internal HkConvexTransformShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkConvexTranslateShape
	{
		public HkShape Base;

		public Vector3 Translation
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkConvexTranslateShape_GetTranslation(NativeObject);
				}
			}
		}

		public HkConvexShape ChildShape
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					IntPtr ptr = HkConvexTranslateShape_GetChildShape(NativeObject);
					return new HkConvexShape(ptr);
				}
			}
		}

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkConvexTranslateShape_CreateWithChild(IntPtr childShape, Vector3 translation, int refPolicy);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkConvexTranslateShape_GetChildShape(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkConvexTranslateShape_GetTranslation(IntPtr instance);

		public HkConvexTranslateShape(HkConvexShape childShape, Vector3 translation, HkReferencePolicy policy)
		{
			Base = new HkShape(HkConvexTranslateShape_CreateWithChild(childShape.NativeObject, translation, (int)policy));
		}

		public static implicit operator HkShape(HkConvexTranslateShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static implicit operator HkConvexShape(HkConvexTranslateShape shape)
		{
			return new HkConvexShape(shape.NativeObject);
		}

		public static explicit operator HkConvexTranslateShape(HkConvexShape shape)
		{
			return new HkConvexTranslateShape(shape.NativeObject);
		}

		public static explicit operator HkConvexTranslateShape(HkShape shape)
		{
			return new HkConvexTranslateShape(shape.NativeObject);
		}

		internal HkConvexTranslateShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkConvexVerticesShape
	{
		public HkShape Base;

		internal IntPtr NativeObject => Base.NativeObject;

		public Vector3 Center
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkConvexVerticesShape_GetCenter(NativeObject);
				}
			}
		}

		public int VertexCount
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkConvexVerticesShape_GetVertexCount(NativeObject);
				}
			}
		}

		public int FaceCount
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkConvexVerticesShape_GetFaceCount(NativeObject);
				}
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkConvexVerticesShape_Create(Vector3[] verts, int count);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkConvexVerticesShape_CreateWithRadius(Vector3[] verts, int count, [MarshalAs(UnmanagedType.I1)] bool shrink, float convexRadius);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkConvexVerticesShape_GetCenter(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkConvexVerticesShape_GetVertexCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkConvexVerticesShape_GetFaceCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private unsafe static extern void HkConvexVerticesShape_GetFaces(IntPtr instance, out int faceIndexCount, out int* faceIndices, out int faceCount, out byte* faceVertexCounts);

		[DllImport("Havok.dll")]
		private unsafe static extern void HkConvexVerticesShape_GetVertices(IntPtr instance, Vector3* vertexBuffer);

		[DllImport("Havok.dll")]
		private static extern void HkConvexVerticesShape_GetGeometry(IntPtr instance, IntPtr geometry, out Vector3 center);

		public HkConvexVerticesShape(Vector3[] verts, int count)
		{
			Base = new HkShape(HkConvexVerticesShape_Create(verts, count));
		}

		public HkConvexVerticesShape(Vector3[] verts, int count, bool shrink, float convexRadius)
		{
			Base = new HkShape(HkConvexVerticesShape_CreateWithRadius(verts, count, shrink, convexRadius));
		}

		public unsafe void GetFaces(out Span<int> faceIndices, out Span<byte> faceVertexCounts)
		{
			using (HkAccessControl.Read(this))
			{
				HkConvexVerticesShape_GetFaces(NativeObject, out var faceIndexCount, out var faceIndices2, out var faceCount, out var faceVertexCounts2);
				faceIndices = new Span<int>(faceIndices2, faceIndexCount);
				faceVertexCounts = new Span<byte>(faceVertexCounts2, faceCount);
			}
		}

		public void GetGeometry(HkGeometry geometry, out Vector3 center)
		{
			using (HkAccessControl.Read(this))
			{
				HkConvexVerticesShape_GetGeometry(NativeObject, geometry.NativeObject, out center);
			}
		}

		public unsafe void GetVertices(out Vector3[] vertices)
		{
			using (HkAccessControl.Read(this))
			{
				vertices = new Vector3[HkConvexVerticesShape_GetVertexCount(NativeObject)];
				fixed (Vector3* vertexBuffer = vertices)
				{
					HkConvexVerticesShape_GetVertices(NativeObject, vertexBuffer);
				}
			}
		}

		public static implicit operator HkShape(HkConvexVerticesShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static implicit operator HkConvexShape(HkConvexVerticesShape shape)
		{
			return new HkConvexShape(shape.NativeObject);
		}

		public static explicit operator HkConvexVerticesShape(HkConvexShape shape)
		{
			return new HkConvexVerticesShape(shape.NativeObject);
		}

		public static explicit operator HkConvexVerticesShape(HkShape shape)
		{
			return new HkConvexVerticesShape(shape.NativeObject);
		}

		internal HkConvexVerticesShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkCylinderShape
	{
		public HkShape Base;

		public float Radius
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkCylinderShape_GetRadius(NativeObject);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkCylinderShape_SetRadius(NativeObject, value);
				}
			}
		}

		public Vector3 VertexB
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkCylinderShape_GetVertexB(NativeObject);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkCylinderShape_SetVertexB(NativeObject, value);
				}
			}
		}

		public Vector3 VertexA
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkCylinderShape_GetVertexA(NativeObject);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkCylinderShape_SetVertexA(NativeObject, value);
				}
			}
		}

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkCylinderShape_Create(Vector3 vertexA, Vector3 vertexB, float cylinderRadius);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkCylinderShape_CreateWithConvexRadius(Vector3 vertexA, Vector3 vertexB, float cylinderRadius, float convexRadius);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCylinderShape_GetVertexB(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkCylinderShape_GetVertexA(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCylinderShape_SetVertexB(IntPtr instance, Vector3 vertex);

		[DllImport("Havok.dll")]
		private static extern void HkCylinderShape_SetVertexA(IntPtr instance, Vector3 vertex);

		[DllImport("Havok.dll")]
		private static extern float HkCylinderShape_GetRadius(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkCylinderShape_SetRadius(IntPtr instance, float radius);

		[DllImport("Havok.dll")]
		private static extern void HkCylinderShape_SetNumberOfVirtualSideSegments(int number);

		public HkCylinderShape(Vector3 vertexA, Vector3 vertexB, float cylinderRadius)
		{
			Base = new HkShape(HkCylinderShape_Create(vertexA, vertexB, cylinderRadius));
		}

		public HkCylinderShape(Vector3 vertexA, Vector3 vertexB, float cylinderRadius, float convexRadius)
		{
			Base = new HkShape(HkCylinderShape_CreateWithConvexRadius(vertexA, vertexB, cylinderRadius, convexRadius));
		}

		public static void SetNumberOfVirtualSideSegments(int number)
		{
			HkCylinderShape_SetNumberOfVirtualSideSegments(number);
		}

		public static implicit operator HkShape(HkCylinderShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static implicit operator HkConvexShape(HkCylinderShape shape)
		{
			return new HkConvexShape(shape.NativeObject);
		}

		public static explicit operator HkCylinderShape(HkConvexShape shape)
		{
			return new HkCylinderShape(shape.NativeObject);
		}

		public static explicit operator HkCylinderShape(HkShape shape)
		{
			return new HkCylinderShape(shape.NativeObject);
		}

		internal HkCylinderShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public delegate void HkDeleteHandler(IntPtr nativeObject);
	public struct HkGridShape
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct RemoveResult
		{
			public Vector3S Min;

			public Vector3S Max;

			public bool Removed;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct ShapeBounds
		{
			public Vector3S Min;

			public Vector3S Max;
		}

		public HkShape Base;

		public HkRigidBody DebugRigidBody
		{
			get
			{
				return HkRigidBody.Get(HkGridShape_GetDebugRigidBody(NativeObject));
			}
			set
			{
				HkGridShape_SetDebugRigidBody(NativeObject, value?.NativeObject ?? IntPtr.Zero);
			}
		}

		public int ShapeCount
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkGridShape_GetShapeCount(NativeObject);
				}
			}
		}

		public bool DebugDraw
		{
			get
			{
				return HkGridShape_GetDebugDraw(NativeObject);
			}
			set
			{
				HkGridShape_SetDebugDraw(NativeObject, value);
			}
		}

		public float CellSize
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkGridShape_GetCellSize(NativeObject);
				}
			}
		}

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkGridShape_Create(float cellSize, int policy);

		[DllImport("Havok.dll")]
		private static extern float HkGridShape_GetCellSize(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkGridShape_GetShapeCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkGridShape_SetDebugRigidBody(IntPtr instance, IntPtr rigidBody);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkGridShape_GetDebugRigidBody(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkGridShape_SetDebugDraw(IntPtr instance, [MarshalAs(UnmanagedType.I1)] bool debugDraw);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkGridShape_GetDebugDraw(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkGridShape_AddShapes(IntPtr instance, IntPtr shapes, uint count, Vector3S min, Vector3S max);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkGridShape_Contains(IntPtr instance, short x, short y, short z);

		[DllImport("Havok.dll")]
		private static extern void HkGridShape_GetShape(IntPtr instance, Vector3I pos, ref HkManagedIntermediateBuffer.Native shapeBuffer);

		[DllImport("Havok.dll")]
		private static extern void HkGridShape_GetShapeInfo(IntPtr instance, int index, out Vector3S min, out Vector3S max, ref HkManagedIntermediateBuffer.Native shapeBuffer);

		[DllImport("Havok.dll")]
		private static extern int HkGridShape_GetShapeInfoCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkGridShape_GetShapeMin(IntPtr instance, uint shapeKey, out Vector3S min);

		[DllImport("Havok.dll")]
		private static extern void HkGridShape_GetShapesInInterval(IntPtr instance, Vector3 min, Vector3 max, ref HkManagedIntermediateBuffer.Native shapeBuffer);

		[DllImport("Havok.dll")]
		private static extern void HkGridShape_GetChildBounds(IntPtr instance, uint shapeKey, out Vector3I min, out Vector3I max);

		[DllImport("Havok.dll")]
		private static extern void HkGridShape_RemoveShapes(IntPtr instance, IntPtr positions, uint count, IntPtr results);

		[DllImport("Havok.dll")]
		private static extern void HkGridShape_GetCellRanges(IntPtr instance, IntPtr positions, uint count, IntPtr results);

		public HkGridShape(float cellSize, HkReferencePolicy policy)
		{
			Base = new HkShape(HkGridShape_Create(cellSize, (int)policy));
		}

		public bool Contains(short x, short y, short z)
		{
			using (HkAccessControl.Read(this))
			{
				return HkGridShape_Contains(NativeObject, x, y, z);
			}
		}

		public HkShapeContainerIterator GetIterator()
		{
			using (HkAccessControl.Read(this))
			{
				return ((HkShape)this).GetContainer();
			}
		}

		public void GetShape(Vector3I pos, List<HkShape> resultList)
		{
			using (HkAccessControl.Read(this))
			{
				Span<HkShape> span = stackalloc HkShape[32];
				HkManagedIntermediateBuffer hkManagedIntermediateBuffer = HkManagedIntermediateBuffer.Create(span);
				HkGridShape_GetShape(NativeObject, pos, ref hkManagedIntermediateBuffer.NativeToken);
				Span<HkShape> span2 = hkManagedIntermediateBuffer.AsSpan<HkShape>();
				for (int i = 0; i < span2.Length; i++)
				{
					resultList.Add(span2[i]);
				}
				hkManagedIntermediateBuffer.Dispose();
			}
		}

		public void GetShapeInfo(int index, out Vector3S min, out Vector3S max, List<HkShape> resultList)
		{
			using (HkAccessControl.Read(this))
			{
				Span<HkShape> span = stackalloc HkShape[32];
				HkManagedIntermediateBuffer hkManagedIntermediateBuffer = HkManagedIntermediateBuffer.Create(span);
				HkGridShape_GetShapeInfo(NativeObject, index, out min, out max, ref hkManagedIntermediateBuffer.NativeToken);
				Span<HkShape> span2 = hkManagedIntermediateBuffer.AsSpan<HkShape>();
				for (int i = 0; i < span2.Length; i++)
				{
					resultList.Add(span2[i]);
				}
				hkManagedIntermediateBuffer.Dispose();
			}
		}

		public int GetShapeInfoCount()
		{
			using (HkAccessControl.Read(this))
			{
				return HkGridShape_GetShapeInfoCount(NativeObject);
			}
		}

		public void GetShapeMin(uint shapeKey, out Vector3S min)
		{
			using (HkAccessControl.Read(this))
			{
				HkGridShape_GetShapeMin(NativeObject, shapeKey, out min);
			}
		}

		public void GetShapesInInterval(Vector3 min, Vector3 max, List<HkShape> resultList)
		{
			using (HkAccessControl.Read(this))
			{
				Span<HkShape> span = stackalloc HkShape[32];
				HkManagedIntermediateBuffer hkManagedIntermediateBuffer = HkManagedIntermediateBuffer.Create(span);
				HkGridShape_GetShapesInInterval(NativeObject, min, max, ref hkManagedIntermediateBuffer.NativeToken);
				Span<HkShape> span2 = hkManagedIntermediateBuffer.AsSpan<HkShape>();
				for (int i = 0; i < span2.Length; i++)
				{
					resultList.Add(span2[i]);
				}
				hkManagedIntermediateBuffer.Dispose();
			}
		}

		public unsafe void AddShapes(Span<HkShape> shapes, Vector3S min, Vector3S max)
		{
			using (HkAccessControl.Write(this))
			{
				fixed (HkShape* value = shapes)
				{
					HkGridShape_AddShapes(NativeObject, new IntPtr(value), (uint)shapes.Length, min, max);
				}
			}
		}

		public unsafe void RemoveShapes(HashSet<Vector3I> positions)
		{
			using (HkAccessControl.Write(this))
			{
				Span<Vector3S> span = default(Span<Vector3S>);
				Span<RemoveResult> span2 = default(Span<RemoveResult>);
				Vector3S[] array = null;
				RemoveResult[] array2 = null;
				if (positions.Count < 64)
				{
					span = stackalloc Vector3S[positions.Count];
					span2 = stackalloc RemoveResult[positions.Count];
				}
				else
				{
					span = (array = ArrayPool<Vector3S>.Shared.Rent(positions.Count));
					span2 = (array2 = ArrayPool<RemoveResult>.Shared.Rent(positions.Count));
				}
				int num = 0;
				foreach (Vector3I position in positions)
				{
					span[num++] = new Vector3S(position);
				}
				try
				{
					fixed (Vector3S* value = span)
					{
						try
						{
							fixed (RemoveResult* value2 = span2)
							{
								HkGridShape_RemoveShapes(NativeObject, new IntPtr(value), (uint)positions.Count, new IntPtr(value2));
							}
						}
						finally
						{
						}
					}
				}
				finally
				{
				}
				if (array != null)
				{
					ArrayPool<Vector3S>.Shared.Return(array);
					ArrayPool<RemoveResult>.Shared.Return(array2);
				}
			}
		}

		public unsafe void CollectCellRanges(HashSet<Vector3I> positions, List<Vector3S> min, List<Vector3S> max)
		{
			using (HkAccessControl.Read(this))
			{
				Span<Vector3S> span = default(Span<Vector3S>);
				Span<ShapeBounds> span2 = default(Span<ShapeBounds>);
				Vector3S[] array = null;
				ShapeBounds[] array2 = null;
				if (positions.Count < 64)
				{
					span = stackalloc Vector3S[positions.Count];
					span2 = stackalloc ShapeBounds[positions.Count];
				}
				else
				{
					span = (array = ArrayPool<Vector3S>.Shared.Rent(positions.Count));
					span2 = (array2 = ArrayPool<ShapeBounds>.Shared.Rent(positions.Count));
				}
				int num = 0;
				foreach (Vector3I position in positions)
				{
					span[num++] = new Vector3S(position);
				}
				try
				{
					fixed (Vector3S* value = span)
					{
						try
						{
							fixed (ShapeBounds* value2 = span2)
							{
								HkGridShape_GetCellRanges(NativeObject, new IntPtr(value), (uint)positions.Count, new IntPtr(value2));
							}
						}
						finally
						{
						}
					}
				}
				finally
				{
				}
				for (num = 0; num < positions.Count; num++)
				{
					min.Add(span2[num].Min);
					max.Add(span2[num].Max);
				}
				if (array != null)
				{
					ArrayPool<Vector3S>.Shared.Return(array);
					ArrayPool<ShapeBounds>.Shared.Return(array2);
				}
			}
		}

		public static implicit operator HkShape(HkGridShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static implicit operator HkBvTreeShape(HkGridShape shape)
		{
			return new HkBvTreeShape(shape.NativeObject);
		}

		public static explicit operator HkGridShape(HkShape shape)
		{
			return new HkGridShape(shape.NativeObject);
		}

		public static explicit operator HkGridShape(HkBvTreeShape shape)
		{
			return new HkGridShape(shape.NativeObject);
		}

		internal HkGridShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}

		public void GetShapeBounds(uint shapeKey, out Vector3I min, out Vector3I max)
		{
			using (HkAccessControl.Read(this))
			{
				HkGridShape_GetChildBounds(NativeObject, shapeKey, out min, out max);
			}
		}
	}
	public struct HkListShape
	{
		public HkShape Base;

		public ushort DisabledChildrenCount
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkListShape_GetDisabledChildrenCount(NativeObject);
				}
			}
		}

		public int TotalChildrenCount
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkListShape_GetTotalChildrenCount(NativeObject);
				}
			}
		}

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkListShape_Create(IntPtr shapes, int count, int refPolicy);

		[DllImport("Havok.dll")]
		private static extern ushort HkListShape_GetDisabledChildrenCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkListShape_GetTotalChildrenCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkListShape_EnableShape(IntPtr instance, uint shapeKey, [MarshalAs(UnmanagedType.I1)] bool isEnable);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkListShape_GetChildByIndex(IntPtr instance, int index);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkListShape_IsChildEnabled(IntPtr instance, uint shapeKey);

		public HkListShape(HkShape[] shapes, HkReferencePolicy policy)
			: this(shapes, shapes.Length, policy)
		{
		}

		public unsafe HkListShape(HkShape[] shapes, int count, HkReferencePolicy policy)
		{
			fixed (HkShape* value = shapes)
			{
				Base = new HkShape(HkListShape_Create(new IntPtr(value), count, (int)policy));
			}
		}

		public static HkListShape Create(HkShape[] shapes, int count, HkReferencePolicy policy)
		{
			return new HkListShape(shapes, count, policy);
		}

		public void DisableShape(uint shapeKey)
		{
			using (HkAccessControl.Write(this))
			{
				HkListShape_EnableShape(NativeObject, shapeKey, isEnable: false);
			}
		}

		public void EnableShape(uint shapeKey)
		{
			using (HkAccessControl.Write(this))
			{
				HkListShape_EnableShape(NativeObject, shapeKey, isEnable: true);
			}
		}

		public HkShape GetChildByIndex(int index)
		{
			using (HkAccessControl.Read(this))
			{
				IntPtr shape = HkListShape_GetChildByIndex(NativeObject, index);
				return new HkShape(shape);
			}
		}

		public HkShapeContainerIterator GetIterator()
		{
			using (HkAccessControl.Read(this))
			{
				return ((HkShape)this).GetContainer();
			}
		}

		public bool IsChildEnabled(uint shapeKey)
		{
			using (HkAccessControl.Read(this))
			{
				return HkListShape_IsChildEnabled(NativeObject, shapeKey);
			}
		}

		public static implicit operator HkShape(HkListShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static implicit operator HkShapeCollection(HkListShape shape)
		{
			return new HkShapeCollection(shape.NativeObject);
		}

		public static explicit operator HkListShape(HkShapeCollection shape)
		{
			return new HkListShape(shape.NativeObject);
		}

		public static explicit operator HkListShape(HkShape shape)
		{
			return new HkListShape(shape.NativeObject);
		}

		internal HkListShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkMoppBvTreeShape
	{
		public HkShape Base;

		internal IntPtr NativeObject => Base.NativeObject;

		public HkShapeCollection ShapeCollection
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					IntPtr ptr = HkMoppBvTreeShape_GetShapeCollection(NativeObject);
					return new HkShapeCollection(ptr);
				}
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkMoppBvTreeShape_Create(IntPtr shapeCollection);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkMoppBvTreeShape_GetShapeCollection(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkMoppBvTreeShape_DisableKeys(IntPtr instance, uint[] keys, int count);

		[DllImport("Havok.dll")]
		private static extern void HkMoppBvTreeShape_QueryAABB(IntPtr instance, Vector3 min, Vector3 max, ref HkManagedIntermediateBuffer.Native shapeKeys);

		[DllImport("Havok.dll")]
		private static extern void HkMoppBvTreeShape_QueryPoint(IntPtr instance, Vector3 point, ref HkManagedIntermediateBuffer.Native shapeKeys);

		public HkMoppBvTreeShape(HkShapeCollection shapeCollection, HkReferencePolicy policy)
		{
			Base = new HkShape(HkMoppBvTreeShape_Create(shapeCollection.NativeObject));
			if (policy == HkReferencePolicy.TakeOwnership)
			{
				shapeCollection.Base.RemoveReference();
			}
		}

		public void DisableKeys(uint[] keys, int count)
		{
			using (HkAccessControl.Write(this))
			{
				HkMoppBvTreeShape_DisableKeys(NativeObject, keys, count);
			}
		}

		public void QueryAABB(Vector3 min, Vector3 max, ICollection<uint> result)
		{
			using (HkAccessControl.Read(this))
			{
				Span<uint> span = stackalloc uint[64];
				HkManagedIntermediateBuffer hkManagedIntermediateBuffer = HkManagedIntermediateBuffer.Create(span);
				HkMoppBvTreeShape_QueryAABB(NativeObject, min, max, ref hkManagedIntermediateBuffer.NativeToken);
				Span<uint> span2 = hkManagedIntermediateBuffer.AsSpan<uint>();
				for (int i = 0; i < span2.Length; i++)
				{
					result.Add(span2[i]);
				}
				hkManagedIntermediateBuffer.Dispose();
			}
		}

		public void QueryPoint(Vector3 point, ICollection<uint> result)
		{
			using (HkAccessControl.Read(this))
			{
				Span<uint> span = stackalloc uint[64];
				HkManagedIntermediateBuffer hkManagedIntermediateBuffer = HkManagedIntermediateBuffer.Create(span);
				HkMoppBvTreeShape_QueryPoint(NativeObject, point, ref hkManagedIntermediateBuffer.NativeToken);
				Span<uint> span2 = hkManagedIntermediateBuffer.AsSpan<uint>();
				for (int i = 0; i < span2.Length; i++)
				{
					result.Add(span2[i]);
				}
				hkManagedIntermediateBuffer.Dispose();
			}
		}

		public static implicit operator HkShape(HkMoppBvTreeShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static explicit operator HkMoppBvTreeShape(HkShape shape)
		{
			return new HkMoppBvTreeShape(shape.NativeObject);
		}

		internal HkMoppBvTreeShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public delegate void HkPhantomHandler(HkPhantomCallbackShape shape, HkRigidBody body);
	public struct HkPhantomCallbackShape
	{
		internal delegate void HkPhantomHandlerCpp(IntPtr shape, IntPtr body);

		private class PhantomCallbackShapeManagedWrapper
		{
			private static readonly ConcurrentDictionary<IntPtr, PhantomCallbackShapeManagedWrapper> Instances = new ConcurrentDictionary<IntPtr, PhantomCallbackShapeManagedWrapper>(IntPtrComparer.Instance);

			private readonly HkPhantomHandler m_enterCallback;

			private readonly HkPhantomHandler m_leaveCallback;

			private readonly HkDeleteHandler m_deleteHandler;

			private readonly HkPhantomHandlerCpp m_phantomEnterCallback;

			private readonly HkPhantomHandlerCpp m_phantomLeaveCallback;

			public readonly IntPtr Handle;

			public PhantomCallbackShapeManagedWrapper(HkPhantomHandler enterCallback, HkPhantomHandler leaveCallback)
			{
				m_enterCallback = enterCallback;
				m_leaveCallback = leaveCallback;
				m_phantomEnterCallback = PhantomEnterCallback;
				m_phantomLeaveCallback = PhantomLeaveCallback;
				m_deleteHandler = DeleteHandler;
				Handle = HkPhantomCallbackShape_Create(m_phantomEnterCallback, m_phantomLeaveCallback, m_deleteHandler);
				Instances.TryAdd(Handle, this);
			}

			[MonoPInvokeCallback(typeof(HkDeleteHandler))]
			private static void DeleteHandler(IntPtr nativeobject)
			{
				Instances.Remove(nativeobject);
			}

			[MonoPInvokeCallback(typeof(HkPhantomHandlerCpp))]
			private static void PhantomEnterCallback(IntPtr shape, IntPtr body)
			{
				if (Instances.TryGetValue(shape, out var value))
				{
					value.m_enterCallback?.Invoke(new HkPhantomCallbackShape(shape), HkRigidBody.Get(body));
				}
			}

			[MonoPInvokeCallback(typeof(HkPhantomHandlerCpp))]
			private static void PhantomLeaveCallback(IntPtr shape, IntPtr body)
			{
				if (Instances.TryGetValue(shape, out var value))
				{
					value.m_leaveCallback?.Invoke(new HkPhantomCallbackShape(shape), HkRigidBody.Get(body));
				}
			}
		}

		public HkShape Base;

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkPhantomCallbackShape_Create(HkPhantomHandlerCpp enterCallback, HkPhantomHandlerCpp leaveCallback, HkDeleteHandler deleteCallback);

		public HkPhantomCallbackShape(HkPhantomHandler enterCallback, HkPhantomHandler leaveCallback)
		{
			Base = new HkShape(new PhantomCallbackShapeManagedWrapper(enterCallback, leaveCallback).Handle);
		}

		public static implicit operator HkShape(HkPhantomCallbackShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static explicit operator HkPhantomCallbackShape(HkShape shape)
		{
			return new HkPhantomCallbackShape(shape.NativeObject);
		}

		internal HkPhantomCallbackShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public enum HkReferencePolicy
	{
		TakeOwnership,
		None
	}
	public enum HkWeldingType
	{
		Anticlockwise = 0,
		Clockwise = 4,
		TwoSided = 5,
		None = 6
	}
	public enum HkShapeType
	{
		Sphere,
		Cylinder,
		Triangle,
		Box,
		Capsule,
		ConvexVertices,
		TriSampledHeightFieldCollection,
		TriSampledHeightFieldBvTree,
		List,
		Mopp,
		ConvexTranslate,
		ConvexTransform,
		SampledHeightField,
		ExtendedMesh,
		Transform,
		CompressedMesh,
		StaticCompound,
		BvCompressedMesh,
		Collection,
		User0,
		User1,
		User2,
		BvTree,
		Convex,
		ConvexPiece,
		MultiSphere,
		ConvexList,
		TriangleCollection,
		HeightField,
		SphereRep,
		Bv,
		Plane,
		PhantomCallback,
		MultiRay,
		Invalid
	}
	public enum HkShapeUserDataFlags
	{
		AdditionalGeometry = 1,
		EnvironmentItem = 2,
		Invalid = -1
	}
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	[DebuggerDisplay("{DebugName}")]
	public struct HkShape
	{
		private sealed class HandleEqualityComparer : IEqualityComparer<HkShape>
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(HkShape x, HkShape y)
			{
				return x.m_handle.ToInt64() == y.m_handle.ToInt64();
			}

			public int GetHashCode(HkShape obj)
			{
				return obj.m_handle.GetHashCode();
			}
		}

		internal const uint HK_INVALID_SHAPE_KEY = uint.MaxValue;

		public const uint InvalidShapeKey = uint.MaxValue;

		[FieldOffset(0)]
		private IntPtr m_handle;

		public static ISharedCriticalSection SharedCriticalSection;

		private static readonly Dictionary<HkShape, (HkRigidBody SingleOwner, HashSet<HkRigidBody> MultipleOwners, bool ReadOnly)> m_owners = new Dictionary<HkShape, (HkRigidBody, HashSet<HkRigidBody>, bool)>(Comparer);

		internal IntPtr NativeObject => m_handle;

		public HkShape Base => this;

		public static HkShape Empty => default(HkShape);

		public bool IsZero => m_handle == IntPtr.Zero;

		public bool IsValid => m_handle != IntPtr.Zero;

		public int ReferenceCount
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					if (IsValid)
					{
						return HkShape_GetReferenceCount(m_handle);
					}
					return 0;
				}
			}
		}

		public HkShapeType ShapeType
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					if (IsValid)
					{
						return (HkShapeType)HkShape_GetShapeType(m_handle);
					}
					return HkShapeType.Invalid;
				}
			}
		}

		public bool IsConvex
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					if (IsValid)
					{
						return HkShape_IsConvex(m_handle);
					}
					return false;
				}
			}
		}

		public float ConvexRadius
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					if (IsValid)
					{
						return HkShape_GetConvexRadius(m_handle);
					}
					return 0f;
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					if (IsValid)
					{
						HkShape_SetConvexRadius(m_handle, value);
					}
				}
			}
		}

		public ulong UserData
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					if (IsValid)
					{
						return HkShape_GetUserData(m_handle);
					}
					return 0uL;
				}
			}
		}

		public string DebugName
		{
			get
			{
				if (!IsValid)
				{
					return "HKShape{Null}";
				}
				return string.Format("Hk{0}{{{1}}}", ShapeType, m_handle.ToString("X16"));
			}
		}

		public static IEqualityComparer<HkShape> Comparer { get; } = new HandleEqualityComparer();


		[DllImport("Havok.dll")]
		private static extern int HkShape_GetReferenceCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkShape_GetShapeType(IntPtr instance);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkShape_IsConvex(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern float HkShape_GetConvexRadius(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkShape_SetConvexRadius(IntPtr instance, float value);

		[DllImport("Havok.dll")]
		private static extern ulong HkShape_GetUserData(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkShape_SetUserData(IntPtr instance, ulong value);

		[DllImport("Havok.dll")]
		private static extern void HkShape_SetRigidBody(IntPtr instance, IntPtr rigidBody);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkShape_IsContainer(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkShape_AddReference(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkShape_RemoveReference(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkShape_DisableRefCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkShape_GetLocalAABB(IntPtr instance, float tolerance, out Vector4 outMin, out Vector4 outMax);

		[DllImport("Havok.dll")]
		private static extern uint HkShape_CastRayCollectSingleHit(IntPtr instance, Vector3 from, Vector3 to);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkShape_LoadShapeFromFile(string filename);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkShape_GetContainer(IntPtr instance);

		public void AddReference()
		{
			HkReferenceObject.HkReferenceObject_AddReference(NativeObject);
		}

		public void RemoveReference()
		{
			if (ReferenceCount <= 1)
			{
				UnloadShape(this);
			}
			HkReferenceObject.HkReferenceObject_RemoveReference(NativeObject);
		}

		public HkShape(IntPtr shape)
		{
			m_handle = shape;
		}

		public static void SetUserData(HkShape shape, ulong userData)
		{
			using (HkAccessControl.Write(shape))
			{
				if (shape.IsValid)
				{
					HkShape_SetUserData(shape.NativeObject, userData);
				}
			}
		}

		public static void SetUserData(HkShape shape, HkRigidBody body)
		{
			using (HkAccessControl.Write(shape))
			{
				if (shape.IsValid)
				{
					HkShape_SetRigidBody(shape.NativeObject, body.NativeObject);
				}
			}
		}

		public void DisableRefCount()
		{
			using (HkAccessControl.Read(this))
			{
				if (IsValid)
				{
					HkShape_DisableRefCount(m_handle);
				}
			}
		}

		public bool IsContainer()
		{
			using (HkAccessControl.Read(this))
			{
				if (IsValid)
				{
					return HkShape_IsContainer(m_handle);
				}
				return false;
			}
		}

		public void GetLocalAABB(float tolerance, out Vector4 min, out Vector4 max)
		{
			using (HkAccessControl.Read(this))
			{
				HkShape_GetLocalAABB(m_handle, tolerance, out min, out max);
			}
		}

		public HkShapeContainerIterator GetContainer()
		{
			using (HkAccessControl.Read(this))
			{
				return new HkShapeContainerIterator(HkShape_GetContainer(m_handle), null);
			}
		}

		public HkShapeContainerIterator GetContainerWithBuffer(HkShapeBuffer buffer)
		{
			using (HkAccessControl.Read(this))
			{
				return new HkShapeContainerIterator(HkShape_GetContainer(m_handle), buffer);
			}
		}

		public uint CastRayCollectSingleHit(ref Vector3 from, ref Vector3 to)
		{
			using (HkAccessControl.Read(this))
			{
				return HkShape_CastRayCollectSingleHit(NativeObject, from, to);
			}
		}

		internal static IntPtr LoadShapeFromFile(string fileName)
		{
			return HkShape_LoadShapeFromFile(fileName);
		}

		public override string ToString()
		{
			return DebugName;
		}

		public static int GetAllTrackingObjectsCount()
		{
			return m_owners.Count;
		}

		public static void FlagShapeAsReadOnly(HkShape shape)
		{
			using (SharedCriticalSection.EnterUnique())
			{
				if (!m_owners.TryGetValue(shape, out var value))
				{
					value.Item3 = true;
					m_owners[shape] = value;
				}
			}
		}

		internal static void UnloadShape(HkShape shape)
		{
			using (SharedCriticalSection.EnterUnique())
			{
				if (m_owners.TryGetValue(shape, out var _))
				{
					m_owners.Remove(shape);
				}
			}
		}

		internal static bool CheckReadOnly(HkShape shape)
		{
			using (SharedCriticalSection.EnterShared())
			{
				if (m_owners.TryGetValue(shape, out var value))
				{
					return value.Item3;
				}
				return false;
			}
		}

		internal static void AddOwner(HkShape shape, HkRigidBody body)
		{
			using (SharedCriticalSection.EnterUnique())
			{
				if (!m_owners.TryGetValue(shape, out var value))
				{
					value.Item1 = body;
					m_owners[shape] = value;
				}
				else if (value.Item1 == null && value.Item2 == null)
				{
					value.Item1 = body;
				}
				else if (value.Item2 == null)
				{
					value.Item2 = new HashSet<HkRigidBody> { value.Item1, body };
					value.Item1 = null;
					m_owners[shape] = value;
				}
				else
				{
					value.Item2.Add(body);
				}
			}
		}

		internal static void RemoveOwner(HkShape shape, HkRigidBody body)
		{
			using (SharedCriticalSection.EnterUnique())
			{
				if (!m_owners.TryGetValue(shape, out var value))
				{
					return;
				}
				if (value.Item1 != null)
				{
					if (value.Item3)
					{
						value.Item1 = null;
					}
					else
					{
						m_owners.Remove(shape);
					}
				}
				else
				{
					if (value.Item2 == null)
					{
						return;
					}
					value.Item2.Remove(body);
					if (value.Item2.Count == 0)
					{
						if (!value.Item3)
						{
							m_owners.Remove(shape);
						}
						else
						{
							value.Item2 = null;
						}
					}
				}
			}
		}

		internal static bool AnyOwnerInWorld(HkShape shape)
		{
			using (SharedCriticalSection.EnterShared())
			{
				if (!m_owners.TryGetValue(shape, out var value))
				{
					return false;
				}
				if (value.Item1 != null)
				{
					return value.Item1.InWorldInternal;
				}
				foreach (HkRigidBody item in value.Item2)
				{
					if (item.InWorldInternal)
					{
						return true;
					}
				}
				return false;
			}
		}

		internal static void ReportOwnership()
		{
			using (SharedCriticalSection.EnterShared())
			{
				foreach (KeyValuePair<HkShape, (HkRigidBody, HashSet<HkRigidBody>, bool)> owner in m_owners)
				{
					LinqExtensions.Deconstruct(owner, out var k, out var v);
					(HkRigidBody, HashSet<HkRigidBody>, bool) tuple = v;
					HkShape hkShape = k;
					var (hkRigidBody, hashSet, flag) = tuple;
					IEnumerable<HkRigidBody> enumerable2;
					if (!(hkRigidBody != null))
					{
						IEnumerable<HkRigidBody> enumerable = hashSet;
						enumerable2 = enumerable;
					}
					else
					{
						enumerable2 = Enumerable.Repeat(hkRigidBody, 1);
					}
					IEnumerable<HkRigidBody> enumerable3 = enumerable2;
					if (enumerable3 != null)
					{
					}
				}
			}
		}
	}
	public struct HkShapeBatch
	{
		private int m_id;

		public int Count => HkShapeBatch_GetCount(m_id);

		[DllImport("Havok.dll")]
		internal static extern int HkShapeBatch_GetCount(int batchId);

		[DllImport("Havok.dll")]
		internal static extern void HkShapeBatch_GetInfo(int batchId, int shapeIndex, out Vector3I outPos);

		[DllImport("Havok.dll")]
		internal static extern void HkShapeBatch_SetResult(int batchId, int shapeIndex, IntPtr shape);

		public HkShapeBatch(int id)
		{
			m_id = id;
		}

		public void GetInfo(int shapeIndex, out Vector3I cell)
		{
			HkShapeBatch_GetInfo(m_id, shapeIndex, out cell);
		}

		public void SetResult(int shapeIndex, HkBvCompressedMeshShape shape)
		{
			HkShapeBatch_SetResult(m_id, shapeIndex, shape.NativeObject);
		}
	}
	public class HkShapeBuffer : HkHandle
	{
		[DllImport("Havok.dll")]
		private static extern IntPtr HkShapeBuffer_Create();

		[DllImport("Havok.dll")]
		private static extern IntPtr HkShapeBuffer_Destroy(IntPtr instance);

		public HkShapeBuffer()
		{
			m_handle = HkShapeBuffer_Create();
		}

		protected override void Dispose(bool disposing)
		{
			HkShapeBuffer_Destroy(m_handle);
		}
	}
	public struct HkShapeCollection
	{
		public HkShape Base;

		internal IntPtr NativeObject => Base.NativeObject;

		public int ShapeCount
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkShapeCollection_GetShapeCount(NativeObject);
				}
			}
		}

		[DllImport("Havok.dll")]
		private static extern int HkShapeCollection_GetShapeCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkShapeCollection_GetShape(IntPtr instance, uint shapeKey);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkShapeCollection_GetShapeWithBuffer(IntPtr instance, uint shapeKey, IntPtr buffer);

		public HkShapeContainerIterator GetIterator(HkShapeBuffer shapeBuffer)
		{
			using (HkAccessControl.Read(this))
			{
				return ((HkShape)this).GetContainerWithBuffer(shapeBuffer);
			}
		}

		public HkShape GetShape(uint shapeKey, HkShapeBuffer buffer)
		{
			using (HkAccessControl.Read(this))
			{
				IntPtr zero = IntPtr.Zero;
				zero = ((buffer != null) ? HkShapeCollection_GetShapeWithBuffer(NativeObject, shapeKey, buffer.NativeObject) : HkShapeCollection_GetShape(NativeObject, shapeKey));
				return new HkShape(zero);
			}
		}

		public static implicit operator HkShape(HkShapeCollection shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static explicit operator HkShapeCollection(HkShape shape)
		{
			return new HkShapeCollection(shape.NativeObject);
		}

		internal HkShapeCollection(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkShapeContainerIterator
	{
		private readonly IntPtr m_handle;

		private uint m_key;

		private HkShapeBuffer m_shapeBuffer;

		public bool IsValid => m_key != uint.MaxValue;

		public uint CurrentShapeKey => m_key;

		public HkShape CurrentValue => new HkShape(HkShapeContainer_CurrentValue(m_handle, m_key, GetShapeBufferReference()));

		[DllImport("Havok.dll")]
		private static extern uint HkShapeContainer_GetFirstKey(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern uint HkShapeContainer_GetNextKey(IntPtr instance, uint key);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkShapeContainer_CurrentValue(IntPtr instance, uint key, IntPtr buffer);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkShapeContainer_GetShape(IntPtr instance, uint key);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkShapeContainer_IsShapeKeyValid(IntPtr instance, uint key);

		public void Next()
		{
			m_key = HkShapeContainer_GetNextKey(m_handle, m_key);
		}

		public HkShape GetShape(uint key)
		{
			return new HkShape(HkShapeContainer_GetShape(m_handle, key));
		}

		internal HkShapeContainerIterator(IntPtr container, HkShapeBuffer shapeBuffer)
		{
			m_handle = container;
			m_shapeBuffer = shapeBuffer;
			m_key = HkShapeContainer_GetFirstKey(m_handle);
		}

		private IntPtr GetShapeBufferReference()
		{
			if (m_shapeBuffer == null)
			{
				return IntPtr.Zero;
			}
			return m_shapeBuffer.NativeObject;
		}

		public bool IsShapeKeyValid(uint shapeKey)
		{
			return HkShapeContainer_IsShapeKeyValid(m_handle, shapeKey);
		}
	}
	public class HkShapeLoader : HkHandle
	{
		internal delegate void ReturnByteArray(IntPtr byteArray, int size);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkShapeLoader_LoadShapesListFromBuffer(int cBuffer, byte[] buffer, ref HkManagedIntermediateBuffer.Native shapeBuffer, [MarshalAs(UnmanagedType.I1)] out bool containsScene, [MarshalAs(UnmanagedType.I1)] out bool containsDestruction);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkShapeLoader_LoadShapesListFromFile(string fileName, ref HkManagedIntermediateBuffer.Native shapeBuffer);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkShapeLoader_SaveShapesListToFile(string fileName, IntPtr listShapes, [MarshalAs(UnmanagedType.I1)] bool xmlFormat);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkShapeLoader_CleanupShapesBuffer(int cBuffer, byte[] buffer, ReturnByteArray returnByteArray);

		public static bool LoadShapesListFromBuffer(byte[] memoryBuffer, List<HkShape> shapes, out bool containsScene, out bool containsDestructionData)
		{
			Span<HkShape> span = stackalloc HkShape[8];
			HkManagedIntermediateBuffer hkManagedIntermediateBuffer = HkManagedIntermediateBuffer.Create(span);
			bool result = HkShapeLoader_LoadShapesListFromBuffer(memoryBuffer.Length, memoryBuffer, ref hkManagedIntermediateBuffer.NativeToken, out containsScene, out containsDestructionData);
			Span<HkShape> span2 = hkManagedIntermediateBuffer.AsSpan<HkShape>();
			for (int i = 0; i < span2.Length; i++)
			{
				shapes.Add(span2[i]);
			}
			hkManagedIntermediateBuffer.Dispose();
			return result;
		}

		public static bool LoadShapesListFromFile(string fileName, List<HkShape> shapes)
		{
			Span<HkShape> span = stackalloc HkShape[8];
			HkManagedIntermediateBuffer hkManagedIntermediateBuffer = HkManagedIntermediateBuffer.Create(span);
			bool result = HkShapeLoader_LoadShapesListFromFile(fileName, ref hkManagedIntermediateBuffer.NativeToken);
			Span<HkShape> span2 = hkManagedIntermediateBuffer.AsSpan<HkShape>();
			for (int i = 0; i < span2.Length; i++)
			{
				shapes.Add(span2[i]);
			}
			hkManagedIntermediateBuffer.Dispose();
			return result;
		}

		public static bool SaveShapesListToFile(string fileName, HkListShape shapes, bool xmlFormat)
		{
			return HkShapeLoader_SaveShapesListToFile(fileName, shapes.NativeObject, xmlFormat);
		}

		public static byte[] CleanupShapesBuffer(byte[] memoryBuffer)
		{
			byte[] result = new byte[0];
			if (!HkShapeLoader_CleanupShapesBuffer(memoryBuffer.Length, memoryBuffer, delegate(IntPtr ptr, int size)
			{
				result = HkHandle.MarshalToByteArray(ptr, size);
			}))
			{
				return null;
			}
			return result;
		}
	}
	public struct HkSimpleMeshShape
	{
		public HkShape Base;

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkSimpleMeshShape_Create(int vCount, Vector3[] vertices, int iCount, int[] indices, int mCount, int[] materials);

		public HkSimpleMeshShape(List<Vector3> vertices, List<int> indices, List<int> materialIndices = null)
		{
			Base = new HkShape(HkSimpleMeshShape_Create(vertices.Count, vertices.ToArray(), indices.Count, indices.ToArray(), materialIndices?.Count ?? 0, materialIndices?.ToArray()));
		}

		public static implicit operator HkShape(HkSimpleMeshShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static implicit operator HkShapeCollection(HkSimpleMeshShape shape)
		{
			return new HkShapeCollection(shape.NativeObject);
		}

		public static explicit operator HkSimpleMeshShape(HkShapeCollection shape)
		{
			return new HkSimpleMeshShape(shape.NativeObject);
		}

		public static explicit operator HkSimpleMeshShape(HkShape shape)
		{
			return new HkSimpleMeshShape(shape.NativeObject);
		}

		internal HkSimpleMeshShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkSmartListShape
	{
		public const int MaxChildren = 128;

		public HkShape Base;

		public int ShapeCount
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkSmartListShape_GetShapeCount(NativeObject);
				}
			}
		}

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkSmartListShape_Create(int dummy);

		[DllImport("Havok.dll")]
		private static extern int HkSmartListShape_GetShapeCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkSmartListShape_AddShape(IntPtr instance, IntPtr shape);

		[DllImport("Havok.dll")]
		private static extern void HkSmartListShape_RemoveShape(IntPtr instance, IntPtr shape);

		[DllImport("Havok.dll")]
		private static extern void HkSmartListShape_Validate(IntPtr instance);

		public HkSmartListShape(int dummy)
		{
			Base = new HkShape(HkSmartListShape_Create(dummy));
		}

		public void AddShape(HkShape shape)
		{
			using (HkAccessControl.Write(this))
			{
				HkSmartListShape_AddShape(NativeObject, shape.NativeObject);
			}
		}

		public HkShapeContainerIterator GetIterator(HkShapeBuffer buffer)
		{
			using (HkAccessControl.Read(this))
			{
				return ((HkShape)this).GetContainerWithBuffer(buffer);
			}
		}

		public void RemoveShape(HkShape shape)
		{
			using (HkAccessControl.Write(this))
			{
				HkSmartListShape_RemoveShape(NativeObject, shape.NativeObject);
			}
		}

		public void Validate()
		{
			using (HkAccessControl.Write(this))
			{
				HkSmartListShape_Validate(NativeObject);
			}
		}

		public static implicit operator HkShape(HkSmartListShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static implicit operator HkBvTreeShape(HkSmartListShape shape)
		{
			return new HkBvTreeShape(shape.NativeObject);
		}

		public static explicit operator HkSmartListShape(HkShape shape)
		{
			return new HkSmartListShape(shape.NativeObject);
		}

		public static explicit operator HkSmartListShape(HkBvTreeShape shape)
		{
			return new HkSmartListShape(shape.NativeObject);
		}

		internal HkSmartListShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkSphereShape
	{
		public HkShape Base;

		public float Radius
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkSphereShape_GetRadius(NativeObject);
				}
			}
			set
			{
				using (HkAccessControl.Write(this))
				{
					HkSphereShape_SetRadius(NativeObject, value);
				}
			}
		}

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkSphereShape_Create(float radius);

		[DllImport("Havok.dll")]
		private static extern float HkSphereShape_GetRadius(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkSphereShape_SetRadius(IntPtr instance, float radius);

		public HkSphereShape(float radius)
		{
			Base = new HkShape(HkSphereShape_Create(radius));
		}

		public static implicit operator HkShape(HkSphereShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static implicit operator HkConvexShape(HkSphereShape shape)
		{
			return new HkConvexShape(shape.NativeObject);
		}

		public static explicit operator HkSphereShape(HkConvexShape shape)
		{
			return new HkSphereShape(shape.NativeObject);
		}

		public static explicit operator HkSphereShape(HkShape shape)
		{
			return new HkSphereShape(shape.NativeObject);
		}

		internal HkSphereShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkStaticCompoundShape
	{
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		internal struct DecomposeShapeKeyResult
		{
			public int instanceId;

			public uint childKey;
		}

		public HkShape Base;

		public int InstanceCount
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkStaticCompoundShape_GetInstanceCount(NativeObject);
				}
			}
		}

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkStaticCompoundShape_Create(int refPolicy);

		[DllImport("Havok.dll")]
		private static extern int HkStaticCompoundShape_GetInstanceCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkStaticCompoundShape_AddInstance(IntPtr instance, IntPtr shape, Matrix transform);

		[DllImport("Havok.dll")]
		private static extern void HkStaticCompoundShape_Bake(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern uint HkStaticCompoundShape_ComposeShapeKey(IntPtr instance, int instanceId, uint shapeKey);

		[DllImport("Havok.dll")]
		private static extern DecomposeShapeKeyResult HkStaticCompoundShape_DecomposeShapeKey(IntPtr instance, uint shapeKey);

		[DllImport("Havok.dll")]
		private static extern void HkStaticCompoundShape_EnableAllShapeKeys(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkStaticCompoundShape_EnableInstance(IntPtr instance, int instanceId, [MarshalAs(UnmanagedType.I1)] bool enable);

		[DllImport("Havok.dll")]
		private static extern void HkStaticCompoundShape_EnableShapeKey(IntPtr instance, uint key, [MarshalAs(UnmanagedType.I1)] bool enable);

		[DllImport("Havok.dll")]
		private static extern uint HkStaticCompoundShape_GetFirstKey(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkStaticCompoundShape_GetInstance(IntPtr instance, int instanceIndex);

		[DllImport("Havok.dll")]
		private static extern Matrix HkStaticCompoundShape_GetInstanceTransform(IntPtr instance, int instanceIndex);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkStaticCompoundShape_IsInstanceEnabled(IntPtr instance, int instanceId);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkStaticCompoundShape_IsShapeKeyEnabled(IntPtr instance, uint key);

		public HkStaticCompoundShape(HkReferencePolicy policy)
		{
			Base = new HkShape(HkStaticCompoundShape_Create((int)policy));
		}

		public int AddInstance(HkShape shape, Matrix transform)
		{
			using (HkAccessControl.Write(this))
			{
				return HkStaticCompoundShape_AddInstance(NativeObject, shape.NativeObject, transform);
			}
		}

		public void Bake()
		{
			HkStaticCompoundShape_Bake(NativeObject);
		}

		public uint ComposeShapeKey(int instanceId, uint shapeKey)
		{
			using (HkAccessControl.Read(this))
			{
				return HkStaticCompoundShape_ComposeShapeKey(NativeObject, instanceId, shapeKey);
			}
		}

		public void DecomposeShapeKey(uint shapeKey, out int instanceId, out uint childKey)
		{
			using (HkAccessControl.Read(this))
			{
				DecomposeShapeKeyResult decomposeShapeKeyResult = HkStaticCompoundShape_DecomposeShapeKey(NativeObject, shapeKey);
				instanceId = decomposeShapeKeyResult.instanceId;
				childKey = decomposeShapeKeyResult.childKey;
			}
		}

		public void EnableAllShapeKeys()
		{
			using (HkAccessControl.Write(this))
			{
				HkStaticCompoundShape_EnableAllShapeKeys(NativeObject);
			}
		}

		public void EnableInstance(int instanceId, bool enable)
		{
			using (HkAccessControl.Write(this))
			{
				HkStaticCompoundShape_EnableInstance(NativeObject, instanceId, enable);
			}
		}

		public void EnableShapeKey(uint key, bool enable)
		{
			using (HkAccessControl.Write(this))
			{
				HkStaticCompoundShape_EnableShapeKey(NativeObject, key, enable);
			}
		}

		public uint GetFirstKey()
		{
			using (HkAccessControl.Read(this))
			{
				return HkStaticCompoundShape_GetFirstKey(NativeObject);
			}
		}

		public HkShape GetInstance(int instanceIndex)
		{
			using (HkAccessControl.Read(this))
			{
				IntPtr shape = HkStaticCompoundShape_GetInstance(NativeObject, instanceIndex);
				return new HkShape(shape);
			}
		}

		public Matrix GetInstanceTransform(int instanceIndex)
		{
			using (HkAccessControl.Read(this))
			{
				return HkStaticCompoundShape_GetInstanceTransform(NativeObject, instanceIndex);
			}
		}

		public HkShapeContainerIterator GetIterator()
		{
			using (HkAccessControl.Read(this))
			{
				return ((HkShape)this).GetContainer();
			}
		}

		public bool IsInstanceEnabled(int instanceId)
		{
			using (HkAccessControl.Read(this))
			{
				return HkStaticCompoundShape_IsInstanceEnabled(NativeObject, instanceId);
			}
		}

		public bool IsShapeKeyEnabled(uint key)
		{
			using (HkAccessControl.Read(this))
			{
				return HkStaticCompoundShape_IsShapeKeyEnabled(NativeObject, key);
			}
		}

		public static implicit operator HkShape(HkStaticCompoundShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static explicit operator HkStaticCompoundShape(HkShape shape)
		{
			return new HkStaticCompoundShape(shape.NativeObject);
		}

		internal HkStaticCompoundShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkTransformShape
	{
		public HkShape Base;

		internal IntPtr NativeObject => Base.NativeObject;

		public Matrix Transform
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkTransformShape_GetTransform(NativeObject);
				}
			}
		}

		public HkShape ChildShape
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					IntPtr shape = HkTransformShape_GetChildShape(NativeObject);
					return new HkShape(shape);
				}
			}
		}

		[DllImport("Havok.dll")]
		private static extern IntPtr HkTransformShape_Create(IntPtr childShape, Matrix transform);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkTransformShape_CreateWithTranslation(IntPtr childShape, Vector3 translation, Quaternion rotation);

		[DllImport("Havok.dll")]
		private static extern Matrix HkTransformShape_GetTransform(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkTransformShape_GetChildShape(IntPtr instance);

		public HkTransformShape(HkShape childShape, ref Matrix transform)
		{
			Base = new HkShape(HkTransformShape_Create(childShape.NativeObject, transform));
		}

		public HkTransformShape(HkShape childShape, ref Vector3 translation, ref Quaternion rotation)
		{
			Base = new HkShape(HkTransformShape_CreateWithTranslation(childShape.NativeObject, translation, rotation));
		}

		public static implicit operator HkShape(HkTransformShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static explicit operator HkTransformShape(HkShape shape)
		{
			return new HkTransformShape(shape.NativeObject);
		}

		internal HkTransformShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkTriangleShape
	{
		public HkShape Base;

		internal IntPtr NativeObject => Base.NativeObject;

		public Vector3 Extrusion
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkTriangleShape_GetExtrusion(NativeObject);
				}
			}
		}

		public Vector3 Pt2
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkTriangleShape_GetPt2(NativeObject);
				}
			}
		}

		public Vector3 Pt1
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkTriangleShape_GetPt1(NativeObject);
				}
			}
		}

		public Vector3 Pt0
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkTriangleShape_GetPt0(NativeObject);
				}
			}
		}

		[DllImport("Havok.dll")]
		private static extern Vector3 HkTriangleShape_GetExtrusion(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkTriangleShape_GetPt2(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkTriangleShape_GetPt1(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern Vector3 HkTriangleShape_GetPt0(IntPtr instance);

		public static implicit operator HkShape(HkTriangleShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static implicit operator HkConvexShape(HkTriangleShape shape)
		{
			return new HkConvexShape(shape.NativeObject);
		}

		public static explicit operator HkTriangleShape(HkConvexShape shape)
		{
			return new HkTriangleShape(shape.NativeObject);
		}

		public static explicit operator HkTriangleShape(HkShape shape)
		{
			return new HkTriangleShape(shape.NativeObject);
		}

		internal HkTriangleShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}
	}
	public struct HkUniformGridShapeArgs
	{
		public Vector3I CellsCount;

		public float CellSize;

		public float CellOffset;

		public float CellExpand;
	}
	public delegate void RequestShapeBlockingDelegate(HkShapeBatch batch);
	public struct HkUniformGridShape
	{
		internal delegate void NativeBatchRequestCallback(IntPtr instance, int batchId);

		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		internal struct HkUniformGridShapeArgsPOD
		{
			public int CellsCount_X;

			public int CellsCount_Y;

			public int CellsCount_Z;

			public float CellSize;

			public float CellOffset;

			public float CellExpand;

			public static implicit operator HkUniformGridShapeArgsPOD(HkUniformGridShapeArgs args)
			{
				HkUniformGridShapeArgsPOD result = default(HkUniformGridShapeArgsPOD);
				result.CellsCount_X = args.CellsCount.X;
				result.CellsCount_Y = args.CellsCount.Y;
				result.CellsCount_Z = args.CellsCount.Z;
				result.CellSize = args.CellSize;
				result.CellOffset = args.CellOffset;
				result.CellExpand = args.CellExpand;
				return result;
			}
		}

		private class UniformGridShapeWrapper
		{
			private static readonly ConcurrentDictionary<IntPtr, UniformGridShapeWrapper> Instances = new ConcurrentDictionary<IntPtr, UniformGridShapeWrapper>(IntPtrComparer.Instance);

			public readonly IntPtr NativeObject;

			private RequestShapeBlockingDelegate m_managedBatchRequestHandler;

			private static readonly HkDeleteHandler DeleteHandlerCallback = DeleteHandler;

			private static readonly NativeBatchRequestCallback BlockingRequestHandlerCallback = BlockingRequestHandler;

			public UniformGridShapeWrapper(HkUniformGridShapeArgsPOD argsPod)
			{
				NativeObject = HkUniformGridShape_Create(argsPod);
				HkUniformGridShape_SetDeleteHandler(NativeObject, DeleteHandlerCallback);
				Instances.TryAdd(NativeObject, this);
			}

			public static UniformGridShapeWrapper Get(IntPtr nativeReference)
			{
				if (Instances.TryGetValue(nativeReference, out var value))
				{
					return value;
				}
				return null;
			}

			public void SetBatchRequestHandler(RequestShapeBlockingDelegate handler)
			{
				m_managedBatchRequestHandler = handler;
				if (handler == null)
				{
					HkUniformGridShape_RemoveShapeRequestHandler(NativeObject);
				}
				else
				{
					HkUniformGridShape_SetShapeRequestHandler(NativeObject, BlockingRequestHandlerCallback);
				}
			}

			[MonoPInvokeCallback(typeof(NativeBatchRequestCallback))]
			private static void BlockingRequestHandler(IntPtr instanceHandle, int batchId)
			{
				if (Instances.TryGetValue(instanceHandle, out var value))
				{
					HkShapeBatch batch = new HkShapeBatch(batchId);
					HkShape shape = new HkShape(value.NativeObject);
					using (HkAccessControl.Read(shape))
					{
						value.m_managedBatchRequestHandler?.Invoke(batch);
					}
				}
			}

			[MonoPInvokeCallback(typeof(HkDeleteHandler))]
			private static void DeleteHandler(IntPtr nativeObject)
			{
				Instances.Remove(nativeObject);
			}
		}

		public HkShape Base;

		public int ShapeCount
		{
			get
			{
				using (HkAccessControl.Read(this))
				{
					return HkUniformGridShape_GetShapeCount(NativeObject);
				}
			}
		}

		internal IntPtr NativeObject => Base.NativeObject;

		[DllImport("Havok.dll")]
		private static extern IntPtr HkUniformGridShape_Create(HkUniformGridShapeArgsPOD argsPod);

		[DllImport("Havok.dll")]
		private static extern int HkUniformGridShape_GetShapeCount(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkUniformGridShape_DiscardLargeData(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkUniformGridShape_GetHitsAndClear(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern int HkUniformGridShape_GetHitCellsInRange(IntPtr instance, Vector3 min, Vector3 max, int bufferSize, IntPtr buffer);

		[DllImport("Havok.dll")]
		private static extern int HkUniformGridShape_GetMissingCellsInRange(IntPtr instance, Vector3 min, Vector3 max, int bufferSize, IntPtr buffer);

		[DllImport("Havok.dll")]
		private static extern int HkUniformGridShape_InvalidateRange(IntPtr instance, Vector3 min, Vector3 max, int bufferSize, IntPtr buffer);

		[DllImport("Havok.dll")]
		private static extern void HkUniformGridShape_InvalidateRangeImmediate(IntPtr instance, Vector3I minChanged, Vector3I maxChanged);

		[DllImport("Havok.dll")]
		private static extern void HkUniformGridShape_RemoveChild(IntPtr instance, int x, int y, int z);

		[DllImport("Havok.dll")]
		private static extern void HkUniformGridShape_SetChild(IntPtr instance, int x, int y, int z, IntPtr shape, int refPolicy);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkUniformGridShape_GetChild(IntPtr instance, int x, int y, int z);

		[DllImport("Havok.dll")]
		private static extern void HkUniformGridShape_SetDeleteHandler(IntPtr instance, HkDeleteHandler handler);

		[DllImport("Havok.dll")]
		private static extern void HkUniformGridShape_RemoveShapeRequestHandler(IntPtr instance);

		[DllImport("Havok.dll")]
		private static extern void HkUniformGridShape_SetShapeRequestHandler(IntPtr instance, NativeBatchRequestCallback blockingCallback);

		[DllImport("Havok.dll")]
		private static extern void HkUniformGridShape_EnableExtendedCache(IntPtr instance);

		public HkUniformGridShape(HkUniformGridShapeArgs args)
		{
			Base = new HkShape(new UniformGridShapeWrapper(args).NativeObject);
		}

		public void DiscardLargeData()
		{
			using (HkAccessControl.Write(this))
			{
				HkUniformGridShape_DiscardLargeData(NativeObject);
			}
		}

		public unsafe int GetHitCellsInRange(Vector3 min, Vector3 max, Vector3I[] outBuffer)
		{
			using (HkAccessControl.Read(this))
			{
				fixed (Vector3I* value = outBuffer)
				{
					return HkUniformGridShape_GetHitCellsInRange(NativeObject, min, max, outBuffer.Length, new IntPtr(value));
				}
			}
		}

		public int GetHitsAndClear()
		{
			using (HkAccessControl.Write(this))
			{
				return HkUniformGridShape_GetHitsAndClear(NativeObject);
			}
		}

		public unsafe int GetMissingCellsInRange(ref Vector3I min, ref Vector3I max, Vector3I[] outBuffer)
		{
			using (HkAccessControl.Read(this))
			{
				fixed (Vector3I* value = outBuffer)
				{
					return HkUniformGridShape_GetMissingCellsInRange(NativeObject, min, max, outBuffer.Length, new IntPtr(value));
				}
			}
		}

		public unsafe int InvalidateRange(ref Vector3I minChanged, ref Vector3I maxChanged, Vector3I[] outBuffer)
		{
			using (HkAccessControl.Write(this))
			{
				fixed (Vector3I* value = outBuffer)
				{
					return HkUniformGridShape_InvalidateRange(NativeObject, minChanged, maxChanged, outBuffer.Length, new IntPtr(value));
				}
			}
		}

		public void InvalidateRangeImmediate(ref Vector3I minChanged, ref Vector3I maxChanged)
		{
			using (HkAccessControl.Write(this))
			{
				HkUniformGridShape_InvalidateRangeImmediate(NativeObject, minChanged, maxChanged);
			}
		}

		public void RemoveChild(int x, int y, int z)
		{
			using (HkAccessControl.Write(this))
			{
				HkUniformGridShape_RemoveChild(NativeObject, x, y, z);
			}
		}

		public void SetChild(int x, int y, int z, HkBvCompressedMeshShape shape, HkReferencePolicy refPolicy)
		{
			using (HkAccessControl.Write(this))
			{
				HkUniformGridShape_SetChild(NativeObject, x, y, z, (shape.NativeObject == IntPtr.Zero) ? IntPtr.Zero : shape.NativeObject, (int)refPolicy);
			}
		}

		public bool GetChild(int x, int y, int z, out HkBvCompressedMeshShape shape)
		{
			using (HkAccessControl.Read(this))
			{
				IntPtr intPtr = HkUniformGridShape_GetChild(NativeObject, x, y, z);
				shape = new HkBvCompressedMeshShape(intPtr);
				return intPtr != IntPtr.Zero;
			}
		}

		public void SetShapeRequestHandler(RequestShapeBlockingDelegate callback)
		{
			using (HkAccessControl.Write(this))
			{
				UniformGridShapeWrapper.Get(NativeObject)?.SetBatchRequestHandler(callback);
			}
		}

		public static implicit operator HkShape(HkUniformGridShape shape)
		{
			return new HkShape(shape.NativeObject);
		}

		public static implicit operator HkBvTreeShape(HkUniformGridShape shape)
		{
			return new HkBvTreeShape(shape.NativeObject);
		}

		public static explicit operator HkUniformGridShape(HkBvTreeShape shape)
		{
			return new HkUniformGridShape(shape.NativeObject);
		}

		public static explicit operator HkUniformGridShape(HkShape shape)
		{
			return new HkUniformGridShape(shape.NativeObject);
		}

		internal HkUniformGridShape(IntPtr ptr)
		{
			Base = new HkShape(ptr);
		}

		public void EnableExtendedCache()
		{
			HkUniformGridShape_EnableExtendedCache(NativeObject);
		}
	}
	public class HkArrayUInt32
	{
		private uint[] m_array;

		public uint this[int index]
		{
			get
			{
				return m_array[index];
			}
			set
			{
				m_array[index] = value;
			}
		}

		public int Length => m_array.Length;

		public HkArrayUInt32()
		{
		}

		public HkArrayUInt32(uint[] inArray)
		{
			m_array = inArray;
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public void PushBack(uint value)
		{
			throw new NotImplementedException();
		}
	}
	public static class HkConstraintStabilizationUtil
	{
		[DllImport("Havok.dll")]
		private static extern int HkConstraintStabilizationUtil_StabilizeRagdollInertias(IntPtr physicsSystem, float stabilizationAmount, float solverStabilizationAmount);

		public static void ComputeBallSocketInertiaStabilizationFactors(HkConstraint constraint, float stabilizationAmount, ref float inertiaScaleOutA, ref float inertiaScaleOutB)
		{
			throw new NotImplementedException();
		}

		public static int StabilizeRagdollInertias(HkRagdoll ragdoll, float stabilizationAmount, float solverStabilizationAmount)
		{
			return HkConstraintStabilizationUtil_StabilizeRagdollInertias(ragdoll.PhysicsSystem, stabilizationAmount, solverStabilizationAmount);
		}

		public static int StabilizeRigidBodyInertia(HkRigidBody rigidBody, List<HkConstraint> constraints, float stabilizationAmount, float solverStabilizationAmount)
		{
			throw new NotImplementedException();
		}

		public static int StabilizeRigidBodyInertia(HkRigidBody rigidBody, float stabilizationAmount, float solverStabilizationAmount)
		{
			throw new NotImplementedException();
		}
	}
	public static class HkDestructionUtils
	{
		internal delegate void ReturnBreakableShape(IntPtr shape);

		[DllImport("Havok.dll")]
		private static extern void HkDestructionUtils_FindAllBreakableShapesIntersectingSphere(IntPtr destructionWorld, IntPtr breakableBody, Quaternion breakableBodyRotation, Vector3 breakableBodyPosition, Vector3 position, float radius, ReturnBreakableShape returnBreakableShape);

		public static void FindAllBreakableShapesIntersectingSphere(HkdWorld destructionWorld, HkdBreakableBody breakableBody, Quaternion breakableBodyRotation, Vector3 breakableBodyPosition, Vector3 position, float radius, List<HkdBreakableShape> shapesIntersectingSphere)
		{
			List<HkdBreakableShape> results = new List<HkdBreakableShape>();
			HkDestructionUtils_FindAllBreakableShapesIntersectingSphere(destructionWorld.NativeObject, breakableBody.NativeObject, breakableBodyRotation, breakableBodyPosition, position, radius, delegate(IntPtr ptr)
			{
				results.Add(HkReferenceObject.Get<HkdBreakableShape>(ptr));
			});
			shapesIntersectingSphere.AddRange(results);
		}
	}
	public static class HkKeyFrameUtility
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct HkKeyFrameInfo
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct HkAccelerationInfo
		{
		}

		[DllImport("Havok.dll")]
		private static extern void HkKeyFrameUtility_ApplyHardKeyFrame(Vector4 nextPosition, Quaternion nextOrientation, float invDeltaTime, IntPtr body);

		public static void ApplyHardKeyFrame(ref Vector4 nextPosition, ref Quaternion nextOrientation, float invDeltaTime, HkRigidBody body)
		{
			HkKeyFrameUtility_ApplyHardKeyFrame(nextPosition, nextOrientation, invDeltaTime, body.NativeObject);
		}

		public static void ApplyHardKeyFrameAsynchronously(ref Vector4 nextPosition, ref Quaternion nextOrientation, float invDeltaTime, HkRigidBody body)
		{
			throw new NotImplementedException();
		}

		public static void ApplySoftKeyFrame(HkKeyFrameInfo keyFrameInfo, HkAccelerationInfo accelInfo, float deltaTime, float invDeltaTime, HkRigidBody body)
		{
			throw new NotImplementedException();
		}
	}
	public class HkMassChangerUtil
	{
		private IntPtr m_handle;

		public bool IsValid => HkMassChangerUtil_IsValid(m_handle);

		[DllImport("Havok.dll")]
		private static extern IntPtr HkMassChangerUtil_Create(IntPtr body, int otherBodyLayerMask, float invMassScale, float invMassScaleOtherBody);

		[DllImport("Havok.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool HkMassChangerUtil_IsValid(IntPtr listener);

		[DllImport("Havok.dll")]
		private static extern void HkMassChangerUtil_Remove(IntPtr listener);

		public static HkMassChangerUtil Create(HkRigidBody body, int otherBodyLayerMask, float invMassScale, float invMassScaleOtherBody)
		{
			return new HkMassChangerUtil(HkMassChangerUtil_Create(body.NativeObject, otherBodyLayerMask, invMassScale, invMassScaleOtherBody));
		}

		public static int CreateFilterMask(int[] filters)
		{
			int num = 0;
			for (int i = 0; i < filters.Length; i++)
			{
				num |= 1 << filters[i];
			}
			return num;
		}

		public void Remove()
		{
			HkMassChangerUtil_Remove(m_handle);
		}

		internal HkMassChangerUtil(IntPtr ptr)
		{
			m_handle = ptr;
		}
	}
	public static class HkUtils
	{
		[DllImport("Havok.dll")]
		private static extern float HkUtils_CalculateSeparatingVelocity(IntPtr body1, IntPtr body2, IntPtr contactPoint);

		[DllImport("Havok.dll")]
		private static extern void HkUtils_SetSoftContact(IntPtr bodyA, IntPtr bodyB, float softness, float maxVel);

		public static float CalculateSeparatingVelocity(HkRigidBody body1, HkRigidBody body2, ref HkContactPoint contactPoint)
		{
			return HkUtils_CalculateSeparatingVelocity(body1.NativeObject, body2.NativeObject, contactPoint.NativeObject);
		}

		public static void ChangeCoM(HkRigidBody bodyA, HkRigidBody bodyB, ref Vector3 displacementA, ref Vector3 displacementB)
		{
			throw new NotImplementedException();
		}

		public static void SetSoftContact(HkRigidBody bodyA, HkRigidBody bodyB, float softness, float maxVel)
		{
			HkUtils_SetSoftContact(bodyA.NativeObject, bodyB?.NativeObject ?? IntPtr.Zero, softness, maxVel);
		}
	}
}
namespace Havok.Utils
{
	internal struct HkManagedIntermediateBuffer : IDisposable
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct Native
		{
			public unsafe void* Buffer;

			public int BufferCapacity;

			public int ElementSize;

			public bool IsBufferUnmanaged;

			public unsafe Native(void* buffer, int capacity, int size, bool bufferIsUnmanaged)
			{
				ElementSize = size;
				Buffer = buffer;
				BufferCapacity = capacity;
				IsBufferUnmanaged = bufferIsUnmanaged;
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct LifetimeTracker
		{
			public LifetimeTracker(bool _)
			{
			}

			public void Clear()
			{
			}
		}

		public Native NativeToken;

		private LifetimeTracker m_tracker;

		public unsafe HkManagedIntermediateBuffer(void* buffer, int capacity, int size = 0, bool bufferIsUnmanaged = false)
		{
			m_tracker = new LifetimeTracker(_: false);
			NativeToken = new Native(buffer, capacity, size, bufferIsUnmanaged);
		}

		public unsafe static HkManagedIntermediateBuffer Create<T>(Span<T> span, int size = 0, bool bufferIsUnmanaged = false) where T : unmanaged
		{
			fixed (T* buffer = span)
			{
				return new HkManagedIntermediateBuffer(buffer, span.Length * sizeof(T), size, bufferIsUnmanaged);
			}
		}

		public unsafe Span<T> AsSpan<T>() where T : unmanaged
		{
			if (NativeToken.ElementSize % sizeof(T) != 0)
			{
				throw new ArgumentException("the size of this buffer does not divide evenly to a number of elements for the provided type. Check the size of your objects.");
			}
			int length = NativeToken.ElementSize / sizeof(T);
			return new Span<T>(NativeToken.Buffer, length);
		}

		public unsafe void Dispose()
		{
			if (NativeToken.IsBufferUnmanaged)
			{
				HkIntermediateBuffer_ReleaseUnmanaged(new IntPtr(NativeToken.Buffer));
			}
			m_tracker.Clear();
		}

		[DllImport("Havok.dll")]
		private static extern void HkIntermediateBuffer_ReleaseUnmanaged(IntPtr memory);
	}
}
