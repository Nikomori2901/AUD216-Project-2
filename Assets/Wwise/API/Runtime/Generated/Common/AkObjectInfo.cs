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


public class AkObjectInfo : global::System.IDisposable {
  private global::System.IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal AkObjectInfo(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(AkObjectInfo obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  internal virtual void setCPtr(global::System.IntPtr cPtr) {
    Dispose();
    swigCPtr = cPtr;
  }

  ~AkObjectInfo() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkObjectInfo(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public uint objID { set { AkSoundEnginePINVOKE.CSharp_AkObjectInfo_objID_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkObjectInfo_objID_get(swigCPtr); } 
  }

  public uint parentID { set { AkSoundEnginePINVOKE.CSharp_AkObjectInfo_parentID_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkObjectInfo_parentID_get(swigCPtr); } 
  }

  public int iDepth { set { AkSoundEnginePINVOKE.CSharp_AkObjectInfo_iDepth_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkObjectInfo_iDepth_get(swigCPtr); } 
  }

  public void Clear() { AkSoundEnginePINVOKE.CSharp_AkObjectInfo_Clear(swigCPtr); }

  public static int GetSizeOf() { return AkSoundEnginePINVOKE.CSharp_AkObjectInfo_GetSizeOf(); }

  public void Clone(AkObjectInfo other) { AkSoundEnginePINVOKE.CSharp_AkObjectInfo_Clone(swigCPtr, AkObjectInfo.getCPtr(other)); }

  public AkObjectInfo() : this(AkSoundEnginePINVOKE.CSharp_new_AkObjectInfo(), true) {
  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.