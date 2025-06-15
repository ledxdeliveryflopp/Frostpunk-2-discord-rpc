// Copyright Epic Games, Inc. All Rights Reserved.

using System;
using System.Linq;

using UnrealBuildTool;

public class Frostpunk2 : ModuleRules
{
	public Frostpunk2(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		CppStandard = CppStandardVersion.Cpp20;
		bUseUnity = false;

		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
				"CoreUObject",
				"ApplicationCore",
				"Engine",
				"InputCore",
				"EnhancedInput",
				"Landscape",
				"SaveSystem",
				"LevelSequence",
				"MovieScene",
				"AkAudio",
				"RuntimeMeshComponent",
				"CommonUI",
				"CinematicCamera",
				"VirtualHeightfieldMesh",
				"HairStrandsCore",
				"MediaAssets",
				"ElbColorThemes",
				"ElbPlayerProfile",
				"PakFile",
				"RawMesh",
				"RHI",
				"HTTP",
				"ElbNewsfeed",
				"ElbSteamDataSuite",
				"DLSSBlueprint",
				"StreamlineDLSSGBlueprint",
				"XeSSBlueprint",
				"Json",
				"StreamlineReflexBlueprint",
                                "Python"
			}
		);

		if (Target.Platform != UnrealTargetPlatform.PS5)
		{
			PublicDependencyModuleNames.AddRange(
				new string[]
				{
					"FFXFSR3Settings"
				}
			);

			PublicIncludePaths.AddRange(
				new string[]
				{
					"FFXFSR3Settings/Public"
				}
			);
		}

		if (Target.Platform.IsInGroup(UnrealPlatformGroup.Windows))
		{
			// Uses DXGI to query GPU hardware
			// This is what will allow us to get GPU usage statistics at runtime
			AddEngineThirdPartyPrivateStaticDependencies(Target, "DX11");
		}

		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				/*"CustomMeshComponent",*/
				"ProceduralMeshComponent",
				//"GeometricObjects",
				"MeshDescription",
				"StaticMeshDescription",
				"MeshConversion",
				"jc_voronoi",
				"Paper2D",
				"Gauntlet",
				"Slate",
				"SlateCore",
				"RenderCore",
				"NiagaraCore",
				"Niagara",
				"DeveloperSettings",
				"JsonUtilities",
				"Json",
				"OnlineSubsystem",
				//"OnlineSubsystemSteam",
				"GameplayTags",
				"GeometryCore",
				"GraphPlotter",
				"ElbCore",
				"ElbGameAnalytics",
				"Analytics",
				"AnalyticsET",
				"EngineSettings",
				"Frostpunk2Shaders",
				"Frostpunk2Flags",
				"ElbPlayFab",
				"ElbTwitchIntegration",
				"PXTwitchIntegration",
				"SynthBenchmark",
				"ElbPlatformExtensionsMain",
				"ElbUgcInstantiator",
				"AssetRegistry",
				"RigVM",
				"ReliefMapping",
				"BinkMediaPlayer", 
                                "Python"
			}
		);



		// add dependency on GamepadUMGPlugin only if we are on windows
		if (Target.Platform != UnrealTargetPlatform.Mac)
		{
			PrivateDependencyModuleNames.AddRange(
				new string[]
				{
					"GamepadUMGPlugin"
				}
			);
            PublicDependencyModuleNames.AddRange(
                new string[]
                {
                    "DLSS"
                }
            );
		}

		const string distributionPlatformKey = "-DistributionPlatform=";
		string distributionPlatformArgument = string.Join(" ", Environment.GetCommandLineArgs()).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault( arg => arg.StartsWith( distributionPlatformKey ), null );
		string distributionPlatform = distributionPlatformArgument?.Substring( distributionPlatformKey.Length );
		
		if(distributionPlatform == "Steam")
		{
			PrivateDependencyModuleNames.Add( "ElbUgcSteamworkshop" );
			PublicDefinitions.Add( "PXSTEAMWORKS" );

			PrivateIncludePaths.Add("ElbUgcSteamworkshop");
		}

		UnrealTargetPlatform[] ModioExcludedPlatforms =
		{
			UnrealTargetPlatform.XSX,
			UnrealTargetPlatform.PS5,
			UnrealTargetPlatform.Mac
		};

		if(!ModioExcludedPlatforms.Contains( Target.Platform ) )
		{
			PrivateDependencyModuleNames.AddRange
			(
				new string[]
				{
					"Modio",
				}
			);

			PublicDefinitions.Add("CAN_USE_MODIO");
		}

		UnrealTargetPlatform[] KeyboardLEDLightingExcludedPlatforms =
		{
			UnrealTargetPlatform.Mac,
			UnrealTargetPlatform.XSX,
			UnrealTargetPlatform.PS5
		};

		if (!KeyboardLEDLightingExcludedPlatforms.Contains(Target.Platform))
		{
			PublicDependencyModuleNames.AddRange
			(
				new string[]
				{
					"ChromaSDKPlugin",
					"LogitechGSDKPlugin"
				}
			);
		}

		PrivateIncludePaths.AddRange(
			new string[]
			{
				"Frostpunk2", 
				"Frostpunk2Shaders"
			}
		);

		if (Target.bBuildEditor)
		{
			PrivateDependencyModuleNames.AddRange(
				new string[]
				{
					"UnrealEd",
					"GeometryFramework",
					"GeometryScriptingCore",
					"GeometryScriptingEditor",

					"StaticMeshEditor"
				}
			);

			PrivateIncludePathModuleNames.AddRange(
				new string[]
				{
					"GeometryFramework",
					"GeometryScriptingCore",
					"GeometryScriptingEditor",

					"StaticMeshEditor"
				}
);
		}

		// Message Log module is not available on Shipping builds so we don't want to add it to Dependencies when building Shipping
		if (Target.Configuration != UnrealTargetConfiguration.Shipping)
		{
			PrivateDependencyModuleNames.AddRange(
				new string[]
				{
					"MessageLog"
				}
			);
		}

		// Uncomment if you are using Slate UI
		// PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

		// Uncomment if you are using online features
		//PrivateDependencyModuleNames.Add("OnlineSubsystem");

		// To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true
	}
}
