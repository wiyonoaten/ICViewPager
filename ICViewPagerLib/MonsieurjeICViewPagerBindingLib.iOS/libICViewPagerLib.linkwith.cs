using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libICViewPagerLib.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
