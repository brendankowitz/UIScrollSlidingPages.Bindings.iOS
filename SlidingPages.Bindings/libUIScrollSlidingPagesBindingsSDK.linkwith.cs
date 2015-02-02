using System;
using ObjCRuntime;

[assembly: LinkWith ("libUIScrollSlidingPagesBindingsSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator64, ForceLoad = true, Frameworks = "Foundation UIKit")]
