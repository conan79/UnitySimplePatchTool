﻿using SimplePatchToolCore;
using System.IO;
using UnityEngine;

namespace SimplePatchToolUnity
{
	public class SPTUtils : MonoBehaviour
	{
		public static SPTUtils Instance { get; private set; }

		public delegate void OnUpdateEventHandler();
		public event OnUpdateEventHandler OnUpdate;

		public static string SelfPatcherDirectory { get { return Path.Combine( Path.GetDirectoryName( PatchUtils.GetCurrentExecutablePath() ), PatchParameters.SELF_PATCHER_DIRECTORY ); } }
		public static string SelfPatcherExecutablePath
		{
			get
			{
#if UNITY_STANDALONE_WIN
				return Path.Combine( SelfPatcherDirectory, "SelfPatcher.exe" );
#elif UNITY_STANDALONE_OSX
				return Path.Combine( SelfPatcherDirectory, "TODO" );
#elif UNITY_STANDALONE_LINUX
				return Path.Combine( SelfPatcherDirectory, "TODO" );
#else
				return null;
#endif
			}
		}

		[RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
		private static void Initialize()
		{
			Instance = new GameObject( "PatcherUtils" ).AddComponent<SPTUtils>();
			DontDestroyOnLoad( Instance.gameObject );
		}

		private void Update()
		{
			if( OnUpdate != null )
				OnUpdate();
		}
	}
}