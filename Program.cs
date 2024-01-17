using CSGOMultiHack;
using Swed64;

// init swed
Swed swed = new Swed("cs2");

// get client 
IntPtr client = swed.GetModuleBase("client.dll");

// init menu render
Renderer renderer = new Renderer();
renderer.Start().Wait();




// offsets.cs (a2x dumper)
int dwLocalPlayerPawn = 0x16C8F58;
int dwEntityList = 0x17C1950;





// client.dll
int m_pCameraServices = 0x10E0;
int m_iFOV = 0x210;
int m_bIsScoped = 0x13A8;
int m_hPlayerPawn = 0x7EC;
int m_iszPlayerName = 0x640;
int m_entitySpottedState = 0x1638;
int m_bSpotted = 0x8;


// fov changer loop
while (true)
{
    uint desiredFov = (uint)renderer.fov;
    // get pawn
    IntPtr localPlayerPawn = swed.ReadPointer(client, dwLocalPlayerPawn);
    // get camera services
    IntPtr cameraServices = swed.ReadPointer(localPlayerPawn, m_pCameraServices);
    // current fov
    uint currentFov = swed.ReadUInt(cameraServices + m_iFOV);
    // if scoped, dont write
    bool isScoped = swed.ReadBool(localPlayerPawn, m_bIsScoped);

    if (!isScoped && currentFov != desiredFov) 
    {
        swed.WriteUInt(cameraServices + m_iFOV, desiredFov); // write new fov
    }
}

