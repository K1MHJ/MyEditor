#pragma once
#ifdef WINDOW_LIBRARY_EXPORTS
#define WINDOW_LIBRARY_API __declspec(dllexport)
#else
#define WINDOW_LIBRARY_API __declspec(dllimport)
#endif

extern "C" WINDOW_LIBRARY_API HWND __cdecl CreateWindowCore(int width, int height, HWND hwndParent);
extern "C" WINDOW_LIBRARY_API bool __cdecl DestroyWindowCore(HWND hwnd);
