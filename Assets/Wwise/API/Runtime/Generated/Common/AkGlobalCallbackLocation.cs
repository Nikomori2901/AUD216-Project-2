#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (https://www.swig.org).
// Version 4.1.1
//
// Do not make changes to this file unless you know what you are doing - modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public enum AkGlobalCallbackLocation {
  AkGlobalCallbackLocation_Register = (1 << 0),
  AkGlobalCallbackLocation_Begin = (1 << 1),
  AkGlobalCallbackLocation_PreProcessMessageQueueForRender = (1 << 2),
  AkGlobalCallbackLocation_PostMessagesProcessed = (1 << 3),
  AkGlobalCallbackLocation_BeginRender = (1 << 4),
  AkGlobalCallbackLocation_EndRender = (1 << 5),
  AkGlobalCallbackLocation_End = (1 << 6),
  AkGlobalCallbackLocation_Term = (1 << 7),
  AkGlobalCallbackLocation_Monitor = (1 << 8),
  AkGlobalCallbackLocation_MonitorRecap = (1 << 9),
  AkGlobalCallbackLocation_Init = (1 << 10),
  AkGlobalCallbackLocation_Suspend = (1 << 11),
  AkGlobalCallbackLocation_WakeupFromSuspend = (1 << 12),
  AkGlobalCallbackLocation_Num = 13
}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.